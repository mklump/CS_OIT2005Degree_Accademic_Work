/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement parser
    open core

    constants
        className = "com/visual-prolog/Parser/parser".
        version = "$JustDate: 11.01.03 $$Revision: 3 $".

    clauses
        classInfo(className, version).

domains
  assoc = x; y.		% the associavity to the left or the right

class predicates 
  s_lowerterm : (scanner::tokl,scanner::tokl,sterm) determ anyflow.
  s_lowerterm1 : (scanner::tokl,scanner::tokl,sterm,sterm) determ anyflow.
  s_priorterm : (operator::prior,assoc,scanner::tokl,scanner::tokl,sterm) determ anyflow.
  s_basisterm : (operator::prior,assoc,scanner::tokl,scanner::tokl,sterm) determ anyflow.
  s_higher : (operator::prior,assoc,scanner::tokl,scanner::tokl,sterm,sterm) determ anyflow.
  s_higher_something : (operator::prior,assoc,scanner::tokl,scanner::tokl,sterm,sterm) determ anyflow.
  treat_prefix : (operator::prior,operator::xfy,scanner::tokl,scanner::tokl,sterm) determ anyflow.
  treat_sufinfix : (operator::prior,operator::xfy,operator::op,scanner::tokl,scanner::tokl,sterm,sterm) determ anyflow.
  s_list : (scanner::tokl,scanner::tokl,sterm) determ anyflow.
  s_list1 : (scanner::tokl,scanner::tokl,sterm) determ anyflow.
  s_terml : (scanner::tokl,scanner::tokl,sterml) determ anyflow.
  s_terml1 : (scanner::tokl,scanner::tokl,sterml) determ anyflow.
  s_term6 : (scanner::tokl,scanner::tokl,string,sterm) determ anyflow.
  is_op : (scanner::tok,operator::prior,operator::xfy,operator::op) determ anyflow.
  ok_rightop : (operator::prior,assoc,operator::prior) determ anyflow.
  check_ok_rightop : (scanner::cursor_position,operator::prior,assoc,operator::prior) determ anyflow.
  is_prefix : (operator::xfy) determ anyflow.
  prefix_op : (operator::prior,operator::xfy,operator::op) determ anyflow.

clauses
  s_term(IL,OL,TERM):-s_lowerterm(IL,OL,TERM),!.
  s_term([_|_],_,_):-file5x::write("Syntax error in parser"),file5x::nl,fail.

  s_lowerterm(LL1,LL0,TERM_):-
	PRIOR=1201,
	s_basisterm(PRIOR,y,LL1,LL2,TERM1),
	s_higher(PRIOR,y,LL2,LL3,TERM1,TERM2),
	s_lowerterm1(LL3,LL0,TERM2,TERM_),!.
 
  s_basisterm(_,_,[scanner::t(scanner::atom("-"),_),scanner::t(scanner::int(X),_)|LL],LL,int(I)):-!,I=-X.
  s_basisterm(PRIOR,ASSOC,[scanner::t(scanner::atom(ID),CURSOR)|LL1],LL2,cmp(FID,[TERM])):-
	FID=ID, OP=FID,
	prefix_op(NEWPRIOR,XFY,OP),!,
	check_ok_rightop(CURSOR,PRIOR,ASSOC,NEWPRIOR),
	treat_prefix(NEWPRIOR,XFY,LL1,LL2,TERM).
  s_basisterm(_,_,[scanner::t(scanner::var(STRING),_)|LL],LL,var(STRING)):-!.
  s_basisterm(_,_,[scanner::t(scanner::atom(STRING),_)|LL1],LL0,TERM_):-!,
	s_term6(LL1,LL0,STRING,TERM_).
  s_basisterm(_,_,[scanner::t(scanner::int(X),_)|LL],LL,int(X)):-!.
  s_basisterm(_,_,[scanner::t(scanner::char(X),_)|LL],LL,char(X)):-!.
  s_basisterm(_,_,[scanner::t(scanner::str(X),_)|LL],LL,str(X)):-!.
  s_basisterm(_,_,[scanner::t(scanner::lbrack,_)|LL1],LL0,TERM):-!,
	s_list(LL1,LL0,TERM).
  s_basisterm(_,_,[scanner::t(scanner::lpar,_)|LL1],LL0,TERM):-!,
	s_priorterm(1201,y,LL1,LL2,TERM),
	LL2=[scanner::t(scanner::rpar,_)|LL0].

  s_list([scanner::t(scanner::rbrack,_)|IL],IL,nill):-!.
  s_list(IL,OL,list(TERM,REST)):-
	s_priorterm(1000,x,IL,OL1,TERM),
	s_list1(OL1,OL,REST).

  s_list1([scanner::t(scanner::rbrack,_)|IL],IL,nill):-!.
  s_list1([scanner::t(scanner::comma,_)|IL],OL,list(TERM,REST)):-
	s_priorterm(1000,x,IL,OL1,TERM),
	s_list1(OL1,OL,REST).
  s_list1([scanner::t(scanner::bar,_)|IL],OL,TERM):-
	s_priorterm(1000,x,IL,OL1,TERM),
	OL1=[scanner::t(scanner::rbrack,_)|OL].

  s_term6([scanner::t(scanner::lpar,_)|LL1],LL0,ID,cmp(FID,TERML)):-!,
	FID=ID,
	s_terml(LL1,LL2,TERML),
	LL2=[scanner::t(scanner::rpar,_)|LL0].
  s_term6(LL,LL,STRING,atom(STRING)):-!.

  s_terml(LL1,LL0,[TERM|TERML]):-
	s_priorterm(999,y,LL1,LL2,TERM),!,
	s_terml1(LL2,LL0,TERML).
  s_terml(LL,LL,[]).

  s_terml1([scanner::t(scanner::comma,_)|LL1],LL2,TERML):-!,
	s_terml(LL1,LL2,TERML).
  s_terml1(LL,LL,[]).

  treat_prefix(PRIOR,"fx",LL1,LL2,TERM):-
	s_priorterm(PRIOR,x,LL1,LL2,TERM).
  treat_prefix(PRIOR,"fy",LL1,LL2,TERM):-
	s_priorterm(PRIOR,y,LL1,LL2,TERM).

  s_lowerterm1([],[],TERM,TERM):-!.
  s_lowerterm1([scanner::t(scanner::dot,_)|LL],LL,TERM,TERM):-!.
  s_lowerterm1(LL2,LL0,TERM1,TERM_):-
	PRIOR=1201,
	s_higher_something(PRIOR,y,LL2,LL3,TERM1,TERM2),
	s_lowerterm1(LL3,LL0,TERM2,TERM_),!.
  s_lowerterm1(_,_,TERM1,_):-
  	output::wsterm(output::write(),TERM1),file5x::nl,!,
  	fail.

  s_priorterm(PRIOR,ASSOC,LL1,LL0,TERM_):-
	s_basisterm(PRIOR,ASSOC,LL1,LL2,TERM),
	s_higher(PRIOR,ASSOC,LL2,LL0,TERM,TERM_).

  prefix_op(NEWPRIOR,XFY,FID):-
	operator::getop(NEWPRIOR,XFY,FID),
	is_prefix(XFY),!.

  is_prefix("fx").
  is_prefix("fy").

  ok_rightop(PRIOR,_,NEWPRIOR):-
	NEWPRIOR<PRIOR,!.
  ok_rightop(PRIOR,y,PRIOR).

  check_ok_rightop(_,PRIOR,ASSOC,NEWPRIOR):-
	ok_rightop(PRIOR,ASSOC,NEWPRIOR),!.
  check_ok_rightop(_,_,_,_):-file5x::write(">> Parser priority error"),file5x::nl,fail.

  is_op(scanner::comma,PRIOR,XFY,OP):-
	OP=",",	operator::getop(PRIOR,XFY,OP),!.
  is_op(scanner::dot,PRIOR,XFY,OP):-
	OP=".",	operator::getop(PRIOR,XFY,OP),!.
  is_op(scanner::atom(ID),PRIOR,XFY,OP):-
	ID=OP, operator::getop(PRIOR,XFY,OP),!.

  s_higher_something(PRIOR,ASSOC,[scanner::t(TOK,_)|LL1],LL0,TERM,TERM_):-
	is_op(TOK,NEWPRIOR,XFY,OP),
	ok_rightop(PRIOR,ASSOC,NEWPRIOR),
	treat_sufinfix(NEWPRIOR,XFY,OP,LL1,LL2,TERM,TERM1),
	s_higher(PRIOR,ASSOC,LL2,LL0,TERM1,TERM_).

  s_higher(PRIOR,ASSOC,[scanner::t(TOK,_)|LL1],LL0,TERM,TERM_):-
	is_op(TOK,NEWPRIOR,XFY,OP),
	ok_rightop(PRIOR,ASSOC,NEWPRIOR),!,
	treat_sufinfix(NEWPRIOR,XFY,OP,LL1,LL2,TERM,TERM1),
	s_higher(PRIOR,ASSOC,LL2,LL0,TERM1,TERM_).
  s_higher(_,_,LL,LL,TERM,TERM).

  treat_sufinfix(PRIOR,"yfx",OP,LL1,LL2,TERM1,cmp(FID,[TERM1,TERM2])):-
	OP=FID,	s_priorterm(PRIOR,x,LL1,LL2,TERM2).
  treat_sufinfix(PRIOR,"xfx",OP,LL1,LL2,TERM1,cmp(FID,[TERM1,TERM2])):-
	OP=FID,	s_priorterm(PRIOR,x,LL1,LL2,TERM2).
  treat_sufinfix(PRIOR,"xfy",OP,LL1,LL2,TERM1,cmp(FID,[TERM1,TERM2])):-
	OP=FID,	s_priorterm(PRIOR,y,LL1,LL2,TERM2).
  treat_sufinfix(_,"xf",OP,LL,LL,TERM,cmp(FID,[TERM])):-OP=FID.
  treat_sufinfix(_,"yf",OP,LL,LL,TERM,cmp(FID,[TERM])):-OP=FID.
  end implement parser
