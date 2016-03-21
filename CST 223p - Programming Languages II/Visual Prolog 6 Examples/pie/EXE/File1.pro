
p(X):-write(X),nl.

f(X):- call(X).

member(X,[X|_]).
member(X,[_|L]):-member(X,L).

d(1). d(2).  d(3).
p("Hello World!").

terml:-
	term("A",1,i(A)) =.. L,
	write (L),
	nl.
	