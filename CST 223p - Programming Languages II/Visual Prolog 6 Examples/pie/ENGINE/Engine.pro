/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement engine
    open core, file5x, fileSelector %, vpiDomains, resourceIdentifiers, 

    constants
        className = "com/visual-prolog/Engine/engine".
        version = "$JustDate: 11.01.03 $$Revision: 4 $".

    clauses
        classInfo(className, version).

    domains
        e     = reference e(vid,term).
        env   = reference e*.

class predicates
    handle_retract : (term) nondeterm anyflow.
    call : (string,terml) nondeterm anyflow.

class facts
    traceflag : () determ .
    pause_execution : () determ .
    stop_execution : () determ .
    topmost : (programControl::stackMark) determ .


class predicates 
    listlen : (terml,core::integer32,core::integer32) procedure (i,i,o) determ (i,i,i). % Gives the length of a list
    listlen : (parser::sterml,core::integer32,core::integer32)  procedure (i,i,o) determ (i,i,i). % Gives the length of a list
    member : (e,env) determ anyflow.
    member : (string,core::string_list) determ anyflow.
    repeat :() multi anyflow.
    for : (core::integer32,core::integer32,core::integer32) multi anyflow.
    getfilename : (term,string) determ anyflow.       % construct the filename with extension
    remove_duplicates : (core::string_list,core::string_list) procedure anyflow.
    selected_item_index : (string,core::string_list,core::integer32,core::integer32) procedure anyflow.
    clause : (parser::sterm,parser::sterm)nondeterm anyflow.
    named_clause : (string,parser::sterml,parser::sterm)nondeterm anyflow.

clauses
    initPIE() :-
        createClauseBase().
  
clauses
    selected_item_index(_,[],_,0).
    selected_item_index(H,[H|_],Index,Index):-!.
    selected_item_index(H,[_|T],Index,Solution):-
        NextIndex = Index + 1,
        selected_item_index(H,T,NextIndex,Solution).

    remove_duplicates([],[]):-!.
    remove_duplicates([X|T],[X|RESULT]):-
        not (member(X,T)),!,
        remove_duplicates(T,RESULT).
    remove_duplicates([_|T],RESULT):-
        remove_duplicates(T,RESULT).

    listlen([],N,N):-!.
    listlen([_|T],SUB,N):-SUB1=SUB+1,listlen(T,SUB1,N).
    
    member(X,[X|_]):-!.
    member(X,[_|L]):-member(X,L).
    
    repeat().
    repeat():-repeat.
    
    for(I,I,_).
    for(I,Start,Stop):-
        Start < Stop,Next=Start+1,
        for(I,Next,Stop).

    getfilename(atom(S),FILENAME):-!,
        string5x::concat(S,".pro",FILENAME).
    getfilename(str(FILENAME),FILENAME).

/*****************************************************************************
        Expression evaluation
*****************************************************************************/

class predicates 
    eval : (term,refint) determ anyflow.

clauses
    eval(T,_):- free(T), !, fail.  % or 'exit(1040)' free var not allowed
    eval(int(I),I):- !.
    eval(cmp("+",[T1,T2]),R):- !, eval(T1,R1), eval(T2,R2), R=R1+R2.
    eval(cmp("-",[T1,T2]),R):- !, eval(T1,R1), eval(T2,R2), R=R1-R2.
    eval(cmp("*",[T1,T2]),R):- !, eval(T1,R1), eval(T2,R2), R=R1*R2.
    eval(cmp("/",[T1,T2]),R):- !, eval(T1,R1), eval(T2,R2), R=R1 div R2.  % reals are not supported anyway
    eval(cmp("-",[T1]),R):-    !, eval(T1,R1), R=-R1.
    eval(cmp("mod",[T1,T2]),R):- !, eval(T1,R1), eval(T2,R2), R=R1 mod R2.
    eval(cmp("div",[T1,T2]),R):- !, eval(T1,R1), eval(T2,R2), R=R1 div R2.
    eval(cmp("abs",[T]),R):- !, eval(T,R1),R=math::abs(R1).


/*****************************************************************************
        File system
*****************************************************************************/

class facts - seetell
    seeing_name : (string) determ.
    telling_name : (string) determ.

class predicates 
    tell : (string) procedure anyflow.
    tellingP : (string) determ anyflow.
    told : () procedure anyflow.
    see : (string) procedure anyflow.
    seeingP : (string) determ anyflow.
    seen : () procedure anyflow.
    handle_eof : () determ anyflow.

clauses
    tell(FILENAME):-
        file5x::closefile(telling),
        file5x::openwrite(telling,FILENAME),
        file5x::writedevice(telling),
        retractall(telling_name(_)),
        assert(telling_name(FILENAME)).

    tellingP(FILENAME):-
        telling_name(FILENAME).

    told():-
        retract(telling_name(_)),!,
        file5x::closefile(telling).
    told().

    see(FILENAME):-
        file5x::closefile(seeing),
        file5x::openread(seeing,FILENAME),
        file5x::readdevice(seeing),
        retractall(seeing_name(_)),
        assert(seeing_name(FILENAME)).

    seeingP(FILENAME):-
        seeing_name(FILENAME).

    seen():-
        retract(seeing_name(_)),!,
        file5x::closefile(seeing).
    seen().

    handle_eof():-
        seeing_name(_),!,
        file5x::eof(seeing).

/*****************************************************************************
                Handle clause listing
*****************************************************************************/


class predicates 
    list : () procedure anyflow.
    list : (string) procedure anyflow.
    listP : (string,core::integer32) procedure anyflow.
    wclause : (parser::sterm,parser::sterm) procedure anyflow.
    wor : (parser::sterm,core::integer32) procedure anyflow.
    wand : (parser::sterm,core::integer32) procedure anyflow.
    handle_list : (terml) determ anyflow.
    indent : (core::integer32) procedure anyflow.

clauses
    wclause(HEAD,parser::atom("true")):-!,
        file5x::write("  "),
        output::wsterm(output::list(),HEAD),
        file5x::write(".\n").
    wclause(HEAD,BODY):-
        file5x::write("  "),
        output::wsterm(output::list(),HEAD),
        file5x::write(":-\n"),
        wor(BODY,1),
        file5x::write(".\n").

    wor(parser::cmp(";",[G,GG]),INDENT):-!,
        Indent1=INDENT+1,
        wor(G,INDENT1),
        file5x::nl,indent(INDENT),file5x::write(";\n"),
        wor(GG,INDENT1).
    wor(G,INDENT):-wand(G,INDENT).


    wand(parser::cmp(",",[G,GG]),Indent) :-!,
        indent(Indent),
        output::wsterm(output::list(),G),
        file5x::write(",\n"),
        wand(GG,Indent).
    wand(G,Indent) :-
        indent(Indent),
        output::wsterm(output::list(),G).

    indent(0):-!.
    indent(N):-N1=N-1,file5x::write('\t'),indent(N1).
    
    
    % list  pred for all arities
    list(ID):-
        named_clause(ID,TERML,BODY),
        wclause(parser::cmp(ID,TERML),BODY),
        fail.
    list(_). 

    % list  pred/arity
    listP(ID,N):-
        named_clause(ID,TERML,BODY),
        listlen(TERML,0,N),
        wclause(parser::cmp(ID,TERML),BODY),
        fail.
    listP(_,_).

    handle_list([]):-!,list.
    handle_list([atom(Pid)]):-!,list(PID).
    handle_list([cmp("/",[atom(PID),int(N)])]):-listP(PID,N).

/*****************************************************************************
                Handle assert
*****************************************************************************/

class predicates 
    convhead : (parser::sterm,parser::sterm) procedure (i,o).
    ascla : (char,parser::sterm,parser::sterm) determ anyflow.
    assertclause : (char,parser::sterm) determ anyflow.

clauses
        convhead(parser::atom(ID),parser::cmp(ID,[])):-!.
        convhead(T, T).
    
    assertclause(C,parser::cmp(":-",[HEAD,BODY])):-!,
        convhead(HEAD,HEAD1),
        ascla(C,HEAD1,BODY).
    assertclause(C,HEAD):-
        convhead(HEAD,HEAD1),
        ascla(C,HEAD1,parser::atom("true")).

/*****************************************************************************
                Handle Consult
*****************************************************************************/

class predicates 
    cons : (string)  determ.
    sav : (string) procedure.
    parse_clauses : (scanner::tokl) determ.

clauses
    parse_clauses([]):-!.
    parse_clauses(TOKL):-
        parser::s_term(TOKL,TOKL1,TERM),!,
        assertclause('0',TERM),
        parse_clauses(TOKL1).
    parse_clauses(_).

    cons(FIL):-
        file5x::file_str(FIL,TXT),
        scanner::tokl(0,TXT,TOKL),!,
        parse_clauses(TOKL).
    cons(_).

    sav(FIL):-
        file5x::openwrite(temp,FIL),
        file5x::writedevice(temp),
        list,
        file5x::closefile(temp).

/*****************************************************************************
                Handle ReConsult
*****************************************************************************/

class predicates 
    recons : (string) procedure anyflow.
    %recons_text(STRING) - declared as global
    recons_parse : (scanner::tokl) procedure anyflow.
    recons_newclause : (parser::sterm) procedure anyflow.
    recons_newclause_change : (parser::sterm,parser::sterm) determ anyflow.
    recons_delete_old : (string) procedure anyflow.

class facts - reconsulted
    removed : (string).

clauses
  recons_newclause_change(parser::cmp(PID,TERML),BODY):-
        not(removed(PID)),
        recons_delete_old(PID),
        assert(removed(PID)),
        fail;
        ascla('0',parser::cmp(PID,TERML),BODY).

  recons_newclause(parser::cmp(":-",[HEAD,BODY])):-
        convhead(HEAD,Head1),
        recons_newclause_change(Head1,BODY),
        !.
  recons_newclause(HEAD):-
        convhead(HEAD,Head1),
        recons_newclause_change(Head1,parser::atom("true")),
        !.
  recons_newclause(Clause):-
        file5x::write("\nIllegal Clause "),
        output::wsterm(output::list(), Clause),
        file5x::nl().

  recons_parse(TOKL):-
        parser::s_term(TOKL,TOKL1,TERM),
        !,
        recons_newclause(TERM),
        recons_parse(TOKL1).
  recons_parse(_).

  recons(FIL):-
        retractall(_,reconsulted),
        file5x::file_str(FIL,TXT),
        recons_text(TXT).

  recons_text(TXT):-
        retractall(_,reconsulted),
        scanner::tokl(0,TXT,TOKL),!,
        recons_parse(TOKL).
  recons_text(_).

/*****************************************************************************
        Misc help predicates for implementing standard predicates
*****************************************************************************/

class predicates 
  eeq : (term,term) determ anyflow.                % True equality
  eeqterml : (terml,terml) determ anyflow.
  list_terml : (term,terml) determ anyflow.        % Conversion between list and TERML
  retractclause : (parser::sterm,parser::sterm) determ anyflow.    % Used to give a deterministic retract
   handle_op : (refint,refsymb,refsymb)nondeterm anyflow.
  functor : (term,refsymb,refint) determ anyflow.
  arg : (integer,terml,term) determ anyflow.
  writeterml : (output::mode,terml) procedure anyflow.

clauses
  eeq(T1,T2) :- 
      free(T1),free(T2),
      T1=int(0),
      T2=int(1),
      !,
      fail.
  eeq(T1,T2) :-
    free(T1),free(T2),
    !.
  eeq(T1,_T2):-
    free(T1),
    !,
    fail.
  eeq(_T1,T2):-
    free(T2),
    !,
    fail.
  eeq(cmp(ID,TERML1), cmp(ID,TERML2)):-
    !,
    eeqterml(TERML1,TERML2).
  eeq(list(H1,T1), list(H2,T2)):-
    !,
    eeq(H1,H2),
    eeq(T1,T2).
  eeq(X,X).

  eeqterml([],[]):-!.
  eeqterml([H1|T1],[H2|T2]):-
        eeq(H1,H2),eeqterml(T1,T2).

  list_terml(nill,[]):-!.
  list_terml(list(H,T),[H|TT]):-list_terml(T,TT).

clauses
  handle_op(PRIOR,XFY,OP):-
        bound(PRIOR),bound(XFY),bound(OP),
        !,
        P1 = PRIOR, XFY1 = XFY, OP1=OP,
        operator::setop(P1,XFY1,OP1).
  handle_op(PRIOR,XFY,OP):-
        operator::getop_nd(P1,A1,O1),
        P1=PRIOR,A1=XFY,O1=OP.

  functor(cmp(ID,TERML),ID,N):-
        bound(N),!,bound(ID),listlen(TERML,0,N).
  functor(cmp(ID,TERML),ID,N):-!,
        bound(ID),free(N),
        listlen(TERML,0,N1),N=N1.
  functor(atom(S),S,0):-!.

  arg(1,[X|_],X):-!.
  arg(N,[_|T],X):-
        N1=N-1,
        arg(N1,T,X).

  writeterml(_,[]):-!.
  writeterml(DISPLAY,[H|T]):-output::wterm(DISPLAY,H),writeterml(DISPLAY,T).

/*****************************************************************************
        Variable name generator for assert of rules
*****************************************************************************/

class facts - varno
   current_var : (integer) determ .

class predicates 
  reset_vargenerator : () procedure anyflow.
  createVar : (term,env,string) determ anyflow.
  lookup_termid : (term,env,string) determ anyflow.
  get_next_unused : (env,core::integer32,core::integer32,string) procedure anyflow.
  vid_exist : (string,env) determ anyflow.

clauses
  reset_vargenerator():-
        retractall(current_var(_)),
        assert(current_var(0)).

  createVar(TERM,ENV,ID):-
        lookup_termid(TERM,ENV,ID),!.
  createVar(TERM,ENV,NEWID):-
        retract(current_var(NO)),
        NO1=NO+1,
        get_next_unused(ENV,NO1,NO2,NEWID),
        member(e(NEWID,TERM),ENV),
        assert(current_var(NO2)).

  lookup_termid(_,ENV,_):-free(ENV),!,fail.
  lookup_termid(TERM,[e(ID,TERM1)|_],ID):-
        eeq(TERM,TERM1),!.
  lookup_termid(TERM,[_|ENV],ID):-
        lookup_termid(TERM,ENV,ID).

  get_next_unused(ENV,NO,NO,NEWID):-
        conversion5x::str_int(ID,NO),string5x::concat("_",ID,NEWID),
        not(vid_exist(NEWID,ENV)),!.
  get_next_unused(ENV,NO1,NO3,ID):-
        NO2=NO1+1,
        get_next_unused(ENV,NO2,NO3,ID).

  vid_exist(_,ENV):-free(ENV),!,fail.
  vid_exist(VID,[e(VID,_)|_]):-!.
  vid_exist(VID,[_|L]):-vid_exist(VID,L).

/*****************************************************************************
        Implementation of trace
*****************************************************************************/
class predicates 
    showtrace : (string,string,terml) procedure anyflow.
    trace_call : (string,terml)nondeterm anyflow.
    report_redo : (string,terml) multi anyflow.
    check_pause_execution : () failure anyflow.
clauses
    check_pause_execution():-not(pause_execution),!,fail.
    check_pause_execution():-
        pause_execution,
        repeat,
        _ = vpi::processEvents(),
        not(pause_execution),!,fail.
        
    trace_call(_,_):-_ = vpi::processEvents(),fail.
    trace_call(_,_):-retract(stop_execution),!,
        retract(topmost(BTOP)),
        programControl::cutBackTrack(BTOP),
        fail.
    trace_call(_,_):-check_pause_execution.
%    trace_call(_,_):-platformSupport5x::date(Year,Month,_),Year=1996,Month>10,!,fail. %should be removed according to TLP letter
    trace_call(PID,TERML):-not(traceflag),!,
        conversion5x::upper_lower(PID,LOWER_CALLNAME),
        call(LOWER_CALLNAME,TERML).
    trace_call(PID,TERML):-
        conversion5x::upper_lower(PID,LOWER_CALLNAME),
        showtrace("CALL:   ",PID,TERML),
        call(LOWER_CALLNAME,TERML),
        report_redo(LOWER_CALLNAME,TERML),
        showtrace("RETURN: ",PID,TERML).
    trace_call(PID,TERML):-
        showtrace("FAIL:   ",PID,TERML),
        fail.

    report_redo(_,_).
    report_redo(PID,TERML):-
        showtrace("REDO:   ",PID,TERML),
        fail.

  showtrace(STR,PID,TERML):-
          file5x::write("Trace: >> ",STR),
          output::wterm(output::write(),cmp(PID,TERML)),file5x::nl,
          !.

/*****************************************************************************
        The inference engine
*****************************************************************************/

class predicates 
  % nondeterm call(STRING,TERML) declared as first predicate due to memory problems
  unify_term : (term,parser::sterm,env) determ anyflow.
  unify_terml : (terml,parser::sterml,env) determ anyflow.
   unify_body : (parser::sterm,env,programControl::stackMark)nondeterm anyflow.
  handle_assert : (char,parser::sterm,env) procedure anyflow.
%  nondeterm handle_retract(TERM)
  term_to_slist : (term,core::string_list) determ anyflow.
  stringlist_to_term : (core::string_list,term) determ anyflow.
  slist_to_string : (core::string_list,string) procedure anyflow.
  slist_to_parm_str : (core::string_list,string) procedure anyflow.
  string_slist : (string,core::string_list) procedure anyflow.
  /* TREE SUPPORT */
  sort : (core::string_list,core::string_list) procedure anyflow.
  sort : (core::string_list,core::string_list,core::string_list) procedure anyflow.
  split : (core::string_list,string,core::string_list,core::string_list) procedure anyflow.
  
  tok_value : (scanner::cursortok,string VALUE) procedure anyflow.
clauses

tok_value(scanner::t(scanner::atom(VALUE),_),VALUE):-!.
tok_value(scanner::t(scanner::int(VALUE),_),VAL):-conversion5x::str_int(VAL,VALUE),!.
tok_value(INVALID,_):-file5x::write(">> Invalid token ",INVALID),file5x::nl,fail.

    sort(LIST,RESULT):-
          sort(LIST,[],RESULT).    
    sort([HEAD|TAIL],SORTEDBIGGER,RESULT):-
          split(TAIL,HEAD,LESSLIST,BIGGERLIST),
          sort(BIGGERLIST,SORTEDBIGGER,NEWSORTEDBIGGER),
          sort(LESSLIST,[HEAD|NEWSORTEDBIGGER],RESULT).
    sort([],SORTED,SORTED).

    split([],_,[],[]).
    split([Y|L],X,[Y|L1],L2):-Y<X,!,split(L,X,L1,L2).
    split([Y|L],X,L1,[Y|L2]):-split(L,X,L1,L2).

  stringlist_to_term([],nill).
  stringlist_to_term([H|TAIL],list(str(H),SubList)):-
        stringlist_to_term(TAIL,SubList).

  term_to_slist(nill,[]):-!.
  term_to_slist(list(str(S),TAIL),[S|RESULT]):-
        term_to_slist(TAIL,RESULT).

  slist_to_string([],""):-!.
  slist_to_string([H|T],RESULT):-
        slist_to_string(T,TEMP),
        string5x::concat(H,TEMP,RESULT).

  slist_to_parm_str([H],RESULT):-!,string5x::format(RESULT,"\"%\"",H).
  slist_to_parm_str([H|T],RESULT):-
        slist_to_parm_str(T,TEMP),
        string5x::format(RESULT,"\"%\",%",H,TEMP).

  string_slist(STRING,[H|TAIL]):-
        string5x::fronttoken(STRING,H,REST),!,
        string_slist(REST,TAIL).
  string_slist(STRING,[STRING]).

  handle_assert(Poscode,TERM,ENV):-
        unify_term(CALL,TERM,ENV),
        reset_vargenerator,
        unify_term(CALL,STERM,ENV),
        assertclause(Poscode,STERM),
        fail.   % Remove generated identifiers from environment
  handle_assert(_,_,_).

  handle_retract(cmp(":-",[cmp(ID,TERML),BODY])):-
        bound(ID),!,
        named_clause(ID,STERML,SBODY),
        free(ENV),
        unify_terml(TERML,STERML,ENV),
        unify_term(BODY,SBODY,ENV),
        retractclause(parser::cmp(ID,STERML),SBODY),succeed.

  handle_retract(cmp(":-",[HEAD,BODY])):-free(HEAD),!,
        clause(SHEAD,SBODY),
        free(ENV),
        unify_term(HEAD,SHEAD,ENV),
        unify_term(BODY,SBODY,ENV),
        retractclause(SHEAD,SBODY),succeed.

  handle_retract(cmp(ID,TERML)):-
        named_clause(ID,TERML1,parser::atom("true")),
        free(ENV),
        unify_terml(TERML,TERML1,ENV),
        retractclause(parser::cmp(ID,TERML1),parser::atom("true")),succeed.


  unify_terml([],[],_):-!.
  unify_terml([TERM1|TL1],[TERM2|TL2],ENV):-
        unify_term(TERM1,TERM2,ENV),unify_terml(TL1,TL2,ENV).

  unify_term(TERM,parser::var(ID),ENV):-free(ID),free(TERM),!,createVar(TERM,ENV,ID).
  unify_term(_,STerm,_):-bound(STerm),Sterm=parser::var("_"),!.
  unify_term(Term,parser::var(ID),ENV):-bound(ID),!,member(e(string::toUpperCase(ID),Term1),ENV),Term1=Term.
  unify_term(int(I),parser::int(I),_):-!.
  unify_term(atom(A),parser::atom(A),_):-!.
  unify_term(str(S),parser::str(S),_):-!.
  unify_term(char(C),parser::char(C),_):-!.
  unify_term(list(H1,T1),parser::list(H2,T2),ENV):-!,
        unify_term(H1,H2,ENV),unify_term(T1,T2,ENV).
  unify_term(nill,parser::nill,_):-!.
  unify_term(cmp(ID,L1),parser::cmp(ID,L2),ENV):-!,unify_terml(L1,L2,ENV).

  unify_body(parser::atom("true"),_,_):-!.
  unify_body(parser::cmp(",",[TERM1,TERM2]),ENV,BTOP):-!,
        unify_body(TERM1,ENV,BTOP),unify_body(TERM2,ENV,BTOP).
  unify_body(parser::atom("!"),_,BTOP):-!,programControl::cutBackTrack(BTOP).
  unify_body(parser::cmp(";",[TERM,_]),ENV,BTOP):-unify_body(TERM,ENV,BTOP).
  unify_body(parser::cmp(";",[_,TERM]),ENV,BTOP):-!,unify_body(TERM,ENV,BTOP).
  unify_body(parser::cmp("not",[TERM]),ENV,_):-
        platformSupport5x::getBackTrack(BTOP),unify_body(TERM,ENV,BTOP),!,fail.
  unify_body(parser::cmp("not",_),_,_):-!.
  unify_body(parser::cmp("call",[TERM]),ENV,_):-!,
        platformSupport5x::getBackTrack(BTOP),unify_body(TERM,ENV,BTOP).
  unify_body(parser::cmp("assert",[TERM]),ENV,_):- !,handle_assert('0',TERM,ENV).
  unify_body(parser::cmp("asserta",[TERM]),ENV,_):-!,handle_assert('a',TERM,ENV).
  unify_body(parser::cmp("assertz",[TERM]),ENV,_):-!,handle_assert('z',TERM,ENV).
  unify_body(parser::cmp(PID,TERML),ENV,_):-
        unify_terml(CALL,TERML,ENV),trace_call(PID,CALL).
  unify_body(parser::var(ID),ENV,_):-!,
        member(e(string::toUpperCase(ID),TERM),ENV),bound(TERM),
        TERM=cmp(PID,TERML), trace_call(PID,TERML).
  unify_body(parser::atom(PID),_,_):-
        trace_call(PID,[]).

  call("fail",[]):-!,fail.

  call("repeat",[]):-!,repeat.

  call("for",[int(INDEX),int(FROM),int(TO)]):-!,
        for(I,FROM,TO),
        INDEX = I.

  call("halt",[]):-!,breakControl5x::exit(-1).

  call("write",TERML):-!, writeterml(output::write(),TERML).

  call("nl",[]):-!, file5x::nl.

  call("display",TERML):-!,writeterml(output::display(),TERML).
  
  call("read",[TERM]):-!,
        file5x::readln(L),
        scanner::tokl(0,L,TOKL),
        parser::s_term(TOKL,_,STERM),
        free(E),
        unify_term(TERM,STERM,E).

  call("readln",[str(L1)]):-!,
        file5x::readln(L),L1=L.

  call("readchar",[char(CH)]):-!,file5x::readchar(CH1),CH=CH1.
  
  call("eof",[]) :-!, handle_eof.

  %call("help",[]):-!,view("resolut.hlp").

  call("retract",[TERM]):-!,handle_retract(TERM).

  call("tell",[str(FILENAME)]):-!,bound(FILENAME),tell(FILENAME).
  call("telling",[str(FILENAME)]):-!,tellingP(FILENAME1),FILENAME=FILENAME1.
  call("told",[]):-!,told.

  call("see",[str(FILENAME)]):-!,bound(FILENAME),see(FILENAME).
  call("seeing",[str(FILENAME)]):-!,seeingP(FILENAME1),FILENAME=FILENAME1.
  call("seen",[]):-!,seen.

  call("=..",[cmp(ID,TERML),list(atom(ID),LIST)]):-!,
        list_terml(LIST,TERML).

  call("arg",[int(N),cmp(FID,TERML),X]):-!,
        bound(N),bound(FID),N>0,
        arg(N,TERML,X).

  call("functor",[TERM,atom(FID),int(ARITY)]):-!,
        functor(TERM,FID,ARITY).

  call("clause",[HEAD,BODY]):-!,
        clause(SHEAD,SBODY),
        free(ENV),
        unify_term(HEAD,SHEAD,ENV),
        unify_term(BODY,SBODY,ENV).

  call("concat",[str(A),str(B),str(C)]):-!,string5x::concat(A,B,C).

  call("str_int",[str(STR),int(I)]):-!,conversion5x::str_int(STR,I).

  call("str_atom",[str(STR),atom(SYMB)]):-!,STR=SYMB.

  call("is",[int(Res),T2]):-!, eval(T2,Res).

  call("==",[T1,T2]):-!, eeq(T1,T2).
  call("\\==",[T1,T2]):-!, not(eeq(T1,T2)).

  call("=",[X,X]):-!.
  call("\\=",[X,Y]):-!,not(X=Y).
  call("<",[T1,T2]):-!,eval(T1,X),eval(T2,Y),X<Y.
  call(">",[T1,T2]):-!,eval(T1,X),eval(T2,Y),X>Y.
  call("=<",[T1,T2]):-!,eval(T1,X),eval(T2,Y),X<=Y.
  call(">=",[T1,T2]):-!,eval(T1,X),eval(T2,Y),X>=Y.
  call("><",[T1,T2]):-!,eval(T1,X),eval(T2,Y),X><Y.
  call("<>",[T1,T2]):-!,eval(T1,X),eval(T2,Y),X><Y.

  call("integer",[TERM]):-!,bound(TERM),TERM=int(_).

  call("var",[TERM]):-!,free(TERM).
  call("nonvar",[TERM]):-!,bound(TERM).

  call("list",TERML):-handle_list(TERML).

  %call("edit",TERML):-handle_edit(TERML).

  call("trace",_):-traceflag,!.
  call("trace",_):-!,assert(traceflag).
  call("notrace",_):-!,retractall(traceflag).

  call("time",[int(H),int(M),int(S),int(HH)]):-
        free(H),free(M),free(S),free(HH),!,
        platformSupport5x::time(H,M,S,HH).
  call("date",[int(Y),int(M),int(D)]):-
        free(Y),free(M),free(D),!,
        platformSupport5x::date(Y,M,D).
  call("char_int",[char(CH),int(INT)]):-!,
        conversion5x::char_int(CH,INT).

  call("consult",[TERM]):-!,
        bound(TERM),getfilename(TERM,FILENAME),cons(FILENAME).

  call("reconsult",[TERM]):-!,
        bound(TERM),getfilename(TERM,FILENAME),recons(FILENAME).

  call("save",[TERM]):-!,
        bound(TERM),getfilename(TERM,FILENAME),sav(FILENAME).

  call("op",[int(PRIOR),atom(ASSOC),atom(OP)]):-!,
        handle_op(PRIOR,ASSOC,OP).


/*****************************STUFF WRITTEN BY SERG PENKOV ************/
  call("fronttoken",[str(IN),str(FRONT),str(REST)]):-!,
        string5x::fronttoken(IN,FRONT,REST).

/* PLACE STRING IN QUOTES - 
        parser doesn't allow to enter strings with '"' inside
*/
  call("enquote_str",[str(STR),str(RESULT)]):-
        string5x::format(MSG,"\"%s\"",STR),
        RESULT = MSG,
        !.
/* Enter clause in dialogue */
  call("dlg_term",[TERM]):-!,
        Msg="Enter term:",
        InitStr="",
        Title="Prolog Inference Engine",
        NewString=vpiCommonDialogs::getString(Title,Msg,InitStr),
        scanner::tokl(0,NewString,TOKL),
        parser::s_term(TOKL,_,STERM),
        free(E),
        unify_term(TERM,STERM,E).
  call("dlg_str",[str(Prompt),str(Init),str(L1)]):-!,
        Title="Enter string",
        InitStr=Init,
        NewString=vpiCommonDialogs::getString(Title,Prompt,InitStr),
        L1=NewString.
  call("dlg_openfilename",[str(Title),str(Type),str(Extension),str(L1)]):-!,
        FileName=vpiCommonDialogs::getOpenFileName("*.*",[Type,Extension],Title),
        L1 = FileName.
  call("dlg_savefilename",[str(Title),str(Type),str(Extension),str(L1)]):-!,
        FileName=vpiCommonDialogs::getSaveFileName("*.*",[Type,Extension],Title),
        L1 = FileName.
  call("dlg_ask",[str(Prompt),BUTTON_LIST,int(RESULT)]):-
        term_to_slist(BUTTON_LIST,SLIST),
        Answer = vpiCommonDialogs::ask("Prolog Inference Engine",Prompt,SLIST),
        RESULT = Answer,
        !.
  call("dlg_ask",[_,_,_]):-!,fail.
  call("dlg_note",[str(Title),str(Msg)]):-
        vpiCommonDialogs::note(Title,Msg),
        !.
  call("filenamepath",[str(FILENAME),str(PATH),str(FILE)]):-
        free(FILENAME),bound(PATH),bound(FILE),!,
        file5x::filenamepath(TEMP,PATH,FILE),
        FILENAME = TEMP.
  call("filenamepath",[str(FILENAME),str(PATH),str(FILE)]):-
        free(PATH),free(FILE),bound(FILENAME),!,
        file5x::filenamepath(FILENAME,PATH1,FILE1),
        string5x::str_len(PATH1,PLEN),LEN = PLEN-1,string5x::frontstr(LEN,PATH1,PATH2,_),
        PATH = PATH2, FILE = FILE1.
  call("filenameext",[str(FILENAME),str(NAME),str(EXT)]):-
        free(FILENAME),bound(NAME),bound(EXT),!,
        file5x::filenameext(TEMP,NAME,EXT),
        FILENAME = TEMP.
  call("filenameext",[str(FILENAME),str(NAME),str(EXT)]):-
        free(NAME),free(EXT),bound(FILENAME),!,
        file5x::filenameext(FILENAME,NAME1,EXT1),
        NAME = NAME1,string5x::frontchar(EXT1,_,EXT2),EXT = EXT2.
  call("str_toklist",[str(STRING),TOKLIST]):-
        free(TOKLIST),bound(STRING),!,
        string_slist(STRING,TOKL),
        stringlist_to_term(TOKL,TOKLIST).
  call("str_toklist",[str(STRING),TERM]):-
        free(STRING),bound(TERM),!,
        term_to_slist(TERM,SLIST),
        slist_to_string(SLIST,TEMP),
        STRING = TEMP,
        !.
  call("files",[str(Wild),FILELIST]):-!,
        findall(X,file5x::dirfiles(Wild,fa_normal,X,_,_,_,_,_,_,_,_),SLIST),
        stringlist_to_term(SLIST,Temp),
        FileList = Temp.
  call("directories",[str(Root),DirList]):-!,
        string5x::format(Wild,"%*.*",Root),
        findall(X,file5x::dirfiles(Wild,fa_subdir,X,_,_,_,_,_,_,_,_),SLIST),
        sort(SLIST,SORTED),
        stringlist_to_term(SORTED,Temp),
        DirList = Temp.
  call("filedetails",[str(File),int(Attr),int(H),int(M),int(S),int(Y),int(MM),int(D),int(SSize)]):-!,
        file5x::dirfiles(File,fa_normal,FName,RetAttr,Hour,Min,Sec,Year,Month,Day,Size),
        Fname = File,
        Attr = RetAttr, H = Hour, M = Min, S = Sec, Y = Year, MM = Month, D = Day, SSize = Size,
        !.

  /* STD syntax error handling here */
  call(CLAUSE,TERML):-
        std_clause(CLAUSE,SYNTAX),
        !,
        file5x::write("Syntax error in standard predicate ",CLAUSE),file5x::nl,
        output::wterm(output::display(),
        cmp(CLAUSE,TERML)),file5x::nl,
        file5x::write("Predicate syntax is\t",SYNTAX),file5x::nl,
        file5x::write("Check number of parameters, their types and assignment."),file5x::nl,
        fail.

  call(ID,TERML):-
        platformSupport5x::getBackTrack(BTOP),
        named_clause(ID,TERML1,BODY),
        free(ENV),
        unify_terml(TERML,TERML1,ENV),
        unify_body(BODY,ENV,BTOP).
  /*UNKNOWN CLAUSE CHECK */
  call(CLAUSE,TERML):-
        not(clause(parser::cmp(CLAUSE,_),_)),!,
        file5x::write("Unknown clause found "),output::wterm(output::write(),cmp(CLAUSE,TERML)),file5x::nl,
        retract(topmost(TOP)),
        programControl::cutBackTrack(TOP),
        %assert(stop_execution),
        file5x::write("Execution terminated"),file5x::nl,
        fail.


class facts - counter
   counter : (integer) single.

class predicates 
  handle_usergoal : (parser::sterm) determ anyflow.
  scan_parse : (string,parser::sterm) determ anyflow.
  init_counter : () procedure anyflow.
  count : () procedure anyflow.
  wsol : (integer) procedure anyflow.
  wenv : (env) determ anyflow.

clauses
  run(L):- 
        L><"",
        init_counter,
        scan_parse(L,TERM),
        finally(handle_usergoal(TERM),
            retractall(topmost(_))),
        fail.
  run(_).

clauses
  handle_usergoal(parser::cmp(":-",[HEAD,BODY])):-!,
        convhead(HEAD,HEAD1),
        ascla('z',HEAD1,BODY),
        file5x::write("Asserted "),
        output::wsterm(output::write(), parser::cmp(":-",[HEAD1,BODY])),
        file5x::nl().
  handle_usergoal(TERM):-
        free(ENV),
        platformSupport5x::getBackTrack(BTOP),
        retractall(topmost(_)),
        assert(topmost(BTOP)),
        unify_body(TERM,ENV,BTOP),
        wenv(ENV),file5x::nl,
        count,
        free(ENV), % Give only one solution when there are no variables
        programControl::cutBackTrack(BTOP),
        fail.
  handle_usergoal(_):-
        file5x::closefile(seeing),file5x::closefile(telling),
        counter(X),wsol(X),
        !.

  scan_parse(STR,TERM):-
        scanner::tokl(0,STR,TOKL),
        parser::s_term(TOKL,_,TERM),!.
  scan_parse(_,_):-file5x::write(">> Syntax error"),file5x::nl,fail.

  counter(0).

  init_counter():-
        assert(counter(0)).

  count() :- counter(N), N1=N+1, assert(counter(N1)).

  wsol(0):-!,file5x::write("No solutions"),file5x::nl.
  wsol(1):-!,file5x::write("1 Solution"),file5x::nl.
  wsol(N):-file5x::write(N," Solutions"),file5x::nl.

  wenv(L):-free(L),!,file5x::write("True").
  wenv([e(VAR,TERM)|T]):-free(T),!,file5x::write(VAR,"= "),output::wterm(output::write(),TERM).
  wenv([e(VAR,TERM)|T]):-file5x::write(VAR,"= "),output::wterm(output::write(),TERM),file5x::write(", "),wenv(T).

  traceOff() :- retractall(traceflag).
  traceOn() :- retractall(traceflag),assert(traceflag).
  
  pauseOff() :- retractall(pause_execution).
  pauseOn() :- retractall(pause_execution), assert(pause_execution).
  
  resume_execution() :- retractall(stop_execution).
  break_execution():- retractall(stop_execution),assert(stop_execution).
  
  is_system_trace() :- traceflag.
  is_system_paused() :- pause_execution.
  
  get_clause_list (RUN_PREDICATES) :-
        findall(X,clause(parser::cmp(X,_),_), SLIST1 ),
        remove_duplicates(SLIST1,RUN_PREDICATES).

domains
    clause = clausef(parser::sterm,parser::sterm).

class facts
    clauseBase : chainDB := uncheckedConvert(chainDB, null).

clauses
    clause(H,B):-
        clauseBase:db_chains(CHAIN),
        hasDomain(clause, VariableGeneratedByMigration_0),
        (clauseBase:chain_terms(CHAIN,VariableGeneratedByMigration_0,_),
        clausef(H,B) = VariableGeneratedByMigration_0).

clauses
    named_clause(PID,TERML,B):-
        hasDomain(clause, VariableGeneratedByMigration_1),
        (clauseBase:chain_terms(PID,VariableGeneratedByMigration_1,_),
        clausef(H,B) = VariableGeneratedByMigration_1),
        H = parser::cmp(PID,TERML).

clauses
    list():-
        clauseBase:db_chains(CHAIN),
        clauseBase:chain_first(CHAIN,FIRST),
        hasDomain(clause, Clause),
        clauseBase:ref_term(FIRST,Clause),
        clausef(parser::cmp(_,ARGL),_) = Clause,
        listlen(ARGL,0,N),
        file5x::write("\n  % ",CHAIN,'/',N),file5x::nl,
        hasDomain(clause, VariableGeneratedByMigration_3),
        clauseBase:chain_terms(CHAIN,VariableGeneratedByMigration_3,_),
        clausef(H,B) = VariableGeneratedByMigration_3,
        wclause(H,B),
        fail.
    list().


clauses
  ascla('a',parser::cmp(PID,TERML),B):-
          !,
          H = parser::cmp(PID,TERML),
          clauseBase:chain_inserta(PID,convert(clause,clausef(H,B)),_).
  ascla(_,parser::cmp(PID,TERML),B):-
          H = parser::cmp(PID,TERML),
          clauseBase:chain_insertz(PID,convert(clause,clausef(H,B)),_).

clauses
  recons_delete_old(PID):-
          clauseBase:chain_delete(PID),
          !.
  recons_delete_old(_).

clauses
  retractclause(parser::cmp(PID,TEML),BODY):-
          hasDomain(clause, TERM),
            clauseBase:chain_terms(PID,TERM,REF),
          TERM=clausef(parser::cmp(PID,TEML),BODY),!,
          clauseBase:term_delete(PID,REF).

class predicates 
    createClauseBase : () procedure anyflow.
clauses
    createClauseBase() :-
        clauseBase := chainDB::db_create("clauses.bin",chainDB::in_memory()).

clauses
  reset_engine() :-
      clauseBase:db_close(),
      createClauseBase().

clauses
    std_clause ("arg/3","arg(N,Term,A)").
    std_clause ("assert/1","assert(Term)").
    std_clause ("asserta/1","asserta(Term)").
    std_clause ("assertz/1","assertz(Term)").
    std_clause ("call/1","call(SubGoal)").
    std_clause ("char_int/2","char_int(Char,Int)").
    std_clause ("clause/2","clause(Head,Body)").
    std_clause ("consult/1","consult(FileName)").
    std_clause ("date/3","date(Year,Month,Day)").
    std_clause ("display/?","display(Terms)").
    std_clause ("fail/0","fail").
    std_clause ("for/3","for(Index,From,To)").
    std_clause ("functor/3","functor(Term,Func,Arity)").
    std_clause ("integer/1","integer(X)").
    std_clause ("list/0","list").
    std_clause ("list/1","list(Predicate)").
    std_clause ("list/2","list(Predicate,Arity)").
    std_clause ("nl/0","nl").
    std_clause ("nonvar/1","nonvar(X)").
    std_clause ("notrace/0","notrace").
    std_clause ("op/3","op(Prior,Assoc,Func)").
    std_clause ("operator <","X < Y").
    std_clause ("operator <>","X <> Y").
    std_clause ("operator =","X = Y").
    std_clause ("operator =..","Term =.. List").
    std_clause ("operator =<","X =< Y").
    std_clause ("operator ==","X == Y").
    std_clause ("operator >","X > Y").
    std_clause ("operator ><","X >< Y").
    std_clause ("operator >=","X >= Y").
    std_clause ("operator \\==","X \\== Y").
    std_clause ("operator is","X is Y").
    std_clause ("readchar/1","readchar(Char)").
    std_clause ("reconsult/1","reconsult(FileName)").
    std_clause ("repeat/0","repeat").
    std_clause ("retract/1","retract(Term)").
    std_clause ("save/1","save(FileName)").
    std_clause ("see/1","see(FileName)").
    std_clause ("seeing/1","seeing(FileName)").
    std_clause ("seen/0","seen").
    std_clause ("tell/1","tell(FileName)").
    std_clause ("telling/1","telling(FileName)").
    std_clause ("time/4","time(Hours,Minutes,Seconds,Hundreths)").
    std_clause ("told/0","told").
    std_clause ("trace/0","trace").
    std_clause ("true/0","true").
    std_clause ("var/1","var(X)").
    std_clause ("write/?","write(Terms)").
end implement engine
