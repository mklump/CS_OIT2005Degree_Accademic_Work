tst:-
	write ("Enter:"),
	dlg_Clause (C),
	write (C).

op(200,xfx,has).

has(man,head).
has(man,legs).
has(dog,head).
has(dog,tail).	
	
my_cons:-
	dlg_str("Enter file name","",F),
	see(F),
	repeat,
		readln(S),
		write(S),nl,
	eof,
	seen.

t:-
	str_toklist("all kids do fine 1 int(A)",L),
	write(L),nl.
	
t2:-
	L = ["all","1","int(atom)","aaa"],
	str_toklist(S,L),
	write(S),nl.
