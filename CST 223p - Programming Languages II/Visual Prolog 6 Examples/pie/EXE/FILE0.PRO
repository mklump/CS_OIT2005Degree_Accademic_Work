
p(X):-write(X),nl.

f(X):- call(X).

member(X,[X|_]).
member(X,[_|L]):-member(X,L).

d(1). d(2).  d(3).
p("Hello World!").

loop :- repeat,
	write ("Pass"),nl,
	fail.