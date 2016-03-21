/*****************************************************************************

                        Copyright (c) PDC

 Written by: ST
******************************************************************************/
implement hanoi
    constants
        className = "hanoi".
        classVersion = "Version 1.0".

    clauses
        classInfo(className, classVersion).

    domains
        loc = right; middle; left.

    class predicates
        hanoi : (integer NumberOfDisks) procedure (i).
    clauses
        hanoi(N) :-
  	    N <= 0,
            !,
  	    stdIO::write("<p>You must enter positive number.").
        hanoi(N) :-
	    move(N, left, middle, right).

    class predicates
        move : (unsigned NumberofDisks, loc Left, loc Middle, loc Right) procedure (i,i,i,i).
    clauses
        move(1, A, _, C) :-
            !,
	    inform(A, C).
        move(N, A, B, C):-
	    N1 = N-1,
            move(N1, A, C, B),
	    inform(A, C),
            move(N1, B, A, C).

    class predicates
        inform : (loc From, loc To) procedure (i,i).
    clauses
        inform(Loc1, Loc2):-
	    stdIO::write("Move a disk from ", Loc1, " to ", Loc2, "<br>").

    class predicates
        runme : (core::namedValue_list List) procedure (i).
    clauses
        runme(Parmlist) :-
  	    core::string(Value) = core::tryMapLookUp(Parmlist, "nd"),
            trap(NumberOfDisks = toTerm(Value), _, fail),
            !,
  	    hanoi(NumberOfDisks).
        runme(_) :-
  	    stdIO::write("<p>Error while executing Hanoi.exe").

    clauses
        run() :-
            OutStream = console::getConsoleOutputStream(),
            OutStream:setMode(stream::ansi(core::ansi)),
            %stdIO::setOutputStream(OutStream) has been set in mainExe::runConsole
            stdIO::write("Content-type: text/html\n\n<html><body>"),
            ParmList = cgi::getParamList(),
            runme(ParmList),
            stdIO::write("</body></html>").
	
end implement hanoi

goal
    console::init,
    mainExe::run(hanoi::run).