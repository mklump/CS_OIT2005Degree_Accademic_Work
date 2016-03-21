/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement output
    open core

    constants
        className = "com/visual-prolog/Output/output".
        version = "$JustDate: 31.01.03 $$Revision: 5 $".

    clauses
        classInfo(className, version).

domains
  assoc = x; y.		% the associavity to the left or the right

class predicates 
  wterml : (mode,engine::terml) procedure anyflow.
  wcmp : (mode,engine::refsymb,engine::terml) procedure anyflow.
  wfix : (mode,operator::prior,operator::xfy,operator::op,engine::terml) determ anyflow.
  wleft : (mode,assoc,operator::prior,engine::term) procedure anyflow.
  wright : (mode,assoc,operator::prior,engine::term) procedure anyflow.
  wpfixop : (operator::op) procedure anyflow.
  quotepfixop : (string) determ anyflow.
%  rest_composable(string)
  prefix : (operator::xfy,assoc) determ anyflow.
  suffix : (operator::xfy,assoc) determ anyflow.
  infix : (operator::xfy,assoc,assoc) determ anyflow.
  brackets_needed : (assoc,operator::prior,engine::term) determ anyflow.
  wlist : (mode,engine::term) procedure anyflow.

class  predicates
    toTerm : (parser::sterm, engine::term) procedure (i,o).
    toTermL : (parser::sterml, engine::terml) procedure (i,o).
clauses
    toTerm(parser::var(S), engine::var(S)).
    toTerm(parser::cmp(S,SL), engine::cmp(S,L)) :-
        toTermL(SL, L).
    toTerm(parser::list(SH,ST), engine::list(H,T)) :-
        toTerm(SH, H),
        toTerm(ST, T).
    toTerm(parser::nill, engine::nill).
    toTerm(parser::atom(S), engine::atom(S)).
    toTerm(parser::int(V), engine::int(V)).
    toTerm(parser::str(V), engine::str(V)).
    toTerm(parser::char(V), engine::char(V)).

clauses
    toTerml([], []).
    toTerml([SH|SL], [H|L]) :-
        toTerm(SH, H),
        toTerml(SL, L).

clauses
    wsterm(Mode, Sterm) :-
        toTerm(Sterm, Term),
        wterm(Mode, Term).

clauses
  wterm(_,TERM):-free(TERM),!,file5x::write('_').
  wterm(_,engine::int(X)):-!,file5x::write(X).
  wterm(write(),engine::str(X)):-!,file5x::write(X).
  wterm(_,engine::str(X)):-!,file5x::write('"',X,'"').
  wterm(write(),engine::char(X)):-!,file5x::write(X).
  wterm(_,engine::char(X)):-!,file5x::write('`',X).
  wterm(_,engine::atom(X)):-!,file5x::write(X).
  wterm(_,engine::var(X)):-!,file5x::write(X).
  wterm(_,engine::nill):-!,file5x::write("[]").
  wterm(MODE,engine::list(HEAD,TAIL)):-!,
	file5x::write('['),wlist(MODE,engine::list(HEAD,TAIL)),file5x::write(']').
  wterm(MODE,engine::cmp(FID,TERML)):-wcmp(MODE,FID,TERML).

  wcmp(MODE,FID,TERML):-
	not(MODE = display()),
	OP=FID, operator::getop(PRIOR,ASSOC,OP),
	wfix(MODE,PRIOR,ASSOC,OP,TERML),!.
  wcmp(MODE,FID,TERML):-
	FID=OP,
	wpfixop(OP),file5x::write('('),wterml(MODE,TERML),file5x::write(')').

  wpfixop(OP):-
	quotepfixop(OP),!,
	file5x::write('\'',OP,'\'').
  wpfixop(OP):-
	file5x::write(OP).

  quotepfixop(OP):-operator::getop(_,_,OP),!.
  quotepfixop(OP):-
	string5x::frontchar(OP,CH,_),CH><'_',conversion5x::upper_lower_char(CH,LO),CH=LO,
	string5x::isname(OP),!,fail.
/*
  quotepfixop(OP):-
	frontchar(OP,CH,REST),CH><'.',is_composable(CH),
	rest_composable(REST),!,fail.
*/
  quotepfixop(_).

/*
  rest_composable(""):-!.
  rest_composable(STR):-
	frontchar(STR,CH,REST),
	is_composable(CH),
	rest_composable(REST).
*/

  prefix("fx",x).	prefix("fy",y).

  suffix("xf",x).	suffix("yf",y).

  infix("xfx",x,x). infix("xfy",x,y). infix("yfx",y,x). infix("yfy",y,y).

  wfix(MODE,PRIOR,ASSOC,OP,[TERM]):-
	prefix(ASSOC,XY),!,
	file5x::write(OP,' '),wright(MODE,XY,PRIOR,TERM).
  wfix(MODE,PRIOR,ASSOC,OP,[TERM]):-
	suffix(ASSOC,XY),!,
	wleft(MODE,XY,PRIOR,TERM),file5x::write(' ',OP).
  wfix(MODE,PRIOR,ASSOC,OP,[TERM1,TERM2]):-
	infix(ASSOC,LEFT_XY,RIGHT_XY),
	wleft(MODE,LEFT_XY,PRIOR,TERM1),
	file5x::write(' ',OP,' '),
	wright(MODE,RIGHT_XY,PRIOR,TERM2).

  brackets_needed(_,PRIOR,TERM):-
	bound(TERM),TERM=engine::cmp(FID,_),
	OP=FID, operator::getop(PRIOR1,_,OP), PRIOR1>PRIOR,!.
  brackets_needed(x,PRIOR,TERM):-
	bound(TERM),TERM=engine::cmp(FID,_),
	OP=FID, operator::getop(PRIOR,_,OP),!.

  wright(MODE,XY,PRIOR,TERM):-
	brackets_needed(XY,PRIOR,TERM),!,
	file5x::write('('),wterm(MODE,TERM),file5x::write(')').
  wright(MODE,_,_,TERM):-wterm(MODE,TERM).

  wleft(MODE,XY,PRIOR,TERM):-
	brackets_needed(XY,PRIOR,TERM),!,
	file5x::write('('),wterm(MODE,TERM),file5x::write(')').
  wleft(MODE,_,_,TERM):-wterm(MODE,TERM).

  wterml(_,[]):-!.
  wterml(MODE,[H]):-!,wterm(MODE,H).
  wterml(MODE,[H|T]):-wterm(MODE,H),file5x::write(','),wterml(MODE,T).

  wlist(_,engine::nill):-!.
  wlist(MODE,engine::list(H,T)):-free(T),!,wterm(MODE,H),file5x::write("|_").
  wlist(MODE,engine::list(H,engine::var(VAR))):-!,wterm(MODE,H),file5x::write("|"),file5x::write(VAR).
  wlist(MODE,engine::list(H,engine::nill)):-!,wterm(MODE,H).
  wlist(MODE,engine::list(H,T)):- !,wterm(MODE,H),file5x::write(','),wlist(MODE,T).
  wlist(MODE,T):- file5x::write("Not a List <<<"), wterm(MODE,T), file5x::write(">>>").
  
  end implement output
