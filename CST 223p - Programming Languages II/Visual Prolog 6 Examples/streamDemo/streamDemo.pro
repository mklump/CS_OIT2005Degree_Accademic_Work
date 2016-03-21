/*****************************************************************************

		Copyright (c) Prolog Developement Center

 Written by: Visual Prolog
******************************************************************************/

implement streamDemo
    clauses
        run() :-
           stringStreamDemo(),
           fileStreamDemo(),
           consoleStreamDemo().
           
       class predicates
           stringStreamDemo : ().
       clauses
           stringStreamDemo() :-
               StringStream = outputStream_string::new(),
               writeToStream(StringStream),
               String = StringStream:getString(),
               console::writef("String stream content:\n%End\n", String).

       class predicates
           fileStreamDemo : ().
       clauses
           fileStreamDemo() :-
               FileStream = outputStream_file::create8("myFile.txt"),
               writeToStream(FileStream),
               FileStream:close().

       class predicates
           consoleStreamDemo : ().
       clauses
           consoleStreamDemo() :-
               ConsoleStream = console::getConsoleOutputStream(),
               writeToStream(ConsoleStream).


       domains
           bind = bind(string Name, integer Value).
           environment = bind*.
       class facts - someFacts
           fact : (environment Environment) nondeterm.
       clauses
           fact([bind("X", 7), bind("Y", 13)]).
           fact([bind("A", 203), bind("b", -173)]).

       class predicates
           writeToStream : (outputStream Stream) procedure (i).
       clauses
           writeToStream(Stream) :-
               Something = "there",
               Stream:writef("Hello %!\nhere are some facts:", Something),
               Stream:save(someFacts),
               Stream:writef("That was it\n").
end implement streamDemo

goal
    mainExe::run(streamDemo::run).
