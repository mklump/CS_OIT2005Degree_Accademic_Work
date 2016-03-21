/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

/*****************************************************************************
This scanner breaks a string up into a list of tokens of the following
kinds:

TOK	= lbrack; rbrack;    [ ]
	  lpar; rpar;        ( )
	  lcurly; rcurly;    { }
	  var(STRING);       X,  This, _ok
	  atom(STRING);      hello, :-, :::, fail

	  int(INTEGER);      123, -456
	  str(STRING);       "This is a string"
	  char(CHAR);        `*
	  
	  comma;             ,
	  bar;               |
	  dot                .

A symbol is either a name starting with a lowercase letter, or a sequence
of the following characters:

  +  -  *  /  =  `  :  .  \  ^  <  >  ?  @  #  $  &

******************************************************************************/


implement scanner
    open core

    constants
        className = "com/visual-prolog/Scanner/scanner".
        version = "$JustDate: 11.01.03 $$Revision: 3 $".

    clauses
        classInfo(className, version).

class predicates 
  scan_error : (string,cursor_POSITION) procedure anyflow.
  maketok : (cursor_POSITION,string,tok,string,string,cursor_POSITION) determ anyflow.
  scan_str : (cursor_POSITION,char,string,string,string) determ anyflow.
  search_ch : (char,string,core::integer32,core::integer32) determ anyflow.
  skipspaces : (string,string,core::integer32) determ anyflow.
  isspace : (char) determ anyflow.
  white_follow : (string) determ anyflow.
  is_symbchar : (char) determ anyflow.
  scan_atom : (string,cursor_POSITION) determ anyflow.
  commentlength : (core::integer32,string,cursor_POSITION,cursor_POSITION) determ anyflow.
  ok_follow_uscore : (char) determ anyflow.
clauses
  scan_error(STRING,_):-file5x::write("\n>> SCANNER ERROR: ",STRING),file5x::nl.

  tokl(POS,STR,[t(TOK,POS1)|TOKL]):-
	skipspaces(STR,STR1,NOOFSP),
	POS1=POS+NOOFSP,
	string5x::fronttoken(STR1,STRTOK,STR2),!,
	maketok(POS,STRTOK,TOK,STR2,STR3,LEN1),
	string5x::str_len(STRTOK,LEN),
	POS2=POS1+LEN+LEN1,
	tokl(POS2,STR3,TOKL).
  tokl(_,_,[]).

  skipspaces(STR,STR2,NOOFSP):-
	string5x::frontchar(STR,CH,STR1),isspace(CH),!,
	skipspaces(STR1,STR2,N1),
	NOOFSP=N1+1.
  skipspaces(STR,STR3,NOOFSP):-
	string5x::frontchar(STR,'%',STR1),
	search_ch('\n',STR1,0,N),
	string5x::frontstr(N,STR1,DROP,STR2),
	skipspaces(STR2,STR3,N1),
	string5x::str_len(DROP,N2),
	NOOFSP=N1+1+N2,!.
  skipspaces(STR,STR4,NOOFSP):-
	string5x::frontchar(STR,'/',STR1),
	string5x::frontchar(STR1,'*',STR2),
	commentlength(0,STR2,0,N),
	string5x::frontstr(N,STR2,DROP,STR3),
	skipspaces(STR3,STR4,N1),
	string5x::str_len(DROP,N2),
	NOOFSP=N1+2+N2,!.
  skipspaces(STR,STR,0).

  isspace(' ').  isspace('\t').  isspace('\n').

  white_follow(S):-
	string5x::frontchar(S,CH,_),
	not(isspace(CH)),!,fail.
  white_follow(_).

  ok_follow_uscore('_'):-!.
  ok_follow_uscore(CH):-CH>='0',CH<='9',!.
  ok_follow_uscore(CH):-CH>='a',CH<='z',!.
  ok_follow_uscore(CH):-CH>='A',CH<='Z',!.

  maketok(_,"(",lpar,S,S,0):-!.
  maketok(_,")",rpar,S,S,0):-!.
  maketok(_,"[",lbrack,S,S,0):-!.
  maketok(_,"]",rbrack,S,S,0):-!.
  maketok(_,"{",lcurly,S,S,0):-!.
  maketok(_,"}",rcurly,S,S,0):-!.
  maketok(_,"|",bar,S,S,0):-!.

  maketok(_,".",dot,S,S,0):-
	white_follow(S),!.

  maketok(_,",",comma,S,S,0):-!.
  maketok(_,";",atom(";"),S,S,0):-!.
  maketok(_,"!",atom("!"),S,S,0):-!.

  maketok(_,"`",char(T),S1,S2,1):-!,
	string5x::frontchar(S1,T,S2).
  maketok(_,STRING,atom(SYMB),S,S1,LEN):-
	conversion5x::str_char(STRING,CH),
	is_symbchar(CH),!,
	scan_atom(S,LEN),
	string5x::frontstr(LEN,S,SYMB1,S1),
	string5x::frontchar(SYMB,CH,SYMB1).
  maketok(CURSOR,"\"",str(STR),S1,S2,LEN):-!,
	scan_str(CURSOR,'"',S1,S2,STR),string5x::str_len(STR,LEN1),LEN=LEN1+1.
  maketok(CURSOR,"'",atom(ATOM),S1,S2,LEN):-!,
	scan_str(CURSOR,'\'',S1,S2,ATOM),
	/* ALL ATOMS TO UPPERCASE */
        %conversion5x::upper_lower(ATOM1,ATOM),
	string5x::str_len(ATOM,LEN1),LEN=LEN1+1.
  maketok(_,INTSTR,int(LONG),S,S,0):-conversion5x::str_int(INTSTR,LONG),!.
%  maketok(_,REALSTR,real(REAL),S,S,0):-str_real(REALSTR,REAL),!.
  maketok(_,STRING,var(STRING),S,S,0):-
	string5x::frontchar(STRING,CH,_),CH>='A',CH<='Z',string5x::isname(STRING),
	/* ALL VARS TO UPPERCASE */
	%conversion5x::upper_lower(VARSTRING,STRING),
	!.
  maketok(_,"_",var(NAME),S1,S2,LEN):-
	string5x::frontchar(S1,CH,_),ok_follow_uscore(CH),!,
	string5x::fronttoken(S1,TOK,S2),
	string5x::str_len(TOK,LEN),
	conversion5x::upper_lower(TOKU,TOK),
	string5x::frontchar(NAME,'_',TOKU).
  maketok(_,"_",var("_"),S,S,0):-!.
  maketok(_,STRING,atom(Name),S,S,0) :-
        string5x::isname(STRING),
        !,
        conversion5x::upper_lower(STRING,Name).
  maketok(CURSOR,STR,_,S,_,_):-
	file5x::write(STR,S),file5x::nl,
	scan_error("Illegal token",CURSOR),fail.

  scan_str(_,CH,IN,OUT,STR):-
	search_ch(CH,IN,0,N),
	string5x::frontstr(N,IN,STR,OUT1),!,
	string5x::frontchar(OUT1,_,OUT).
  scan_str(CURSOR,_,_,_,_):-
	scan_error("String not terminated",CURSOR),fail.

  commentlength(0,STR,N1,N):-
	string5x::frontchar(STR,'*',STR1),
	string5x::frontchar(STR1,'/',_),!,
	N=N1+2.
  commentlength(NEST,STR,N1,N):-
	string5x::frontchar(STR,'*',STR1),
	string5x::frontchar(STR1,'/',STR2),!,
	NEST1=NEST-1,
	N11=N1+2,
	commentlength(NEST1,STR2,N11,N).
  commentlength(NEST,STR,N1,N):-
	string5x::frontchar(STR,'/',STR1),
	string5x::frontchar(STR1,'*',STR2),!,
	NEST1=NEST+1,
	N11=N1+2,
	commentlength(NEST1,STR2,N11,N).
  commentlength(NEST,STR,N1,N):-
	string5x::frontchar(STR,_,STR1),
	N11=N1+1,
	commentlength(NEST,STR1,N11,N).

  search_ch(CH,STR,N,N):-
	string5x::frontchar(STR,CH,_),!.
  search_ch(CH,STR,N,N1):-
	string5x::frontchar(STR,_,S1),
	N2=N+1,
	search_ch(CH,S1,N2,N1).

  scan_atom(S1,LEN):-
	string5x::frontchar(S1,CH,S2),
	is_symbchar(CH),!,
	scan_atom(S2,LEN1),
	LEN=LEN1+1.
  scan_atom(_,0).

  is_symbchar('+').  is_symbchar('-').  is_symbchar('*').  is_symbchar('/').
  is_symbchar('=').  is_symbchar(':').  is_symbchar('.').  is_symbchar('&').
  is_symbchar('\\'). is_symbchar('^').  is_symbchar('<').  is_symbchar('>').
  is_symbchar('?').  is_symbchar('@').  is_symbchar('#').  is_symbchar('$').
end implement scanner
