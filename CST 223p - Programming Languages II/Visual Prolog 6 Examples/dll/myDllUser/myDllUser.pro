/*****************************************************************************

		Copyright (c) Prolog Developement Center

 Written by: Visual Prolog
******************************************************************************/

implement myDllUser
    clauses
        run() :-
            console::write(myDll::touch("Hello World")).
end implement myDllUser

goal
    mainExe::run(myDllUser::run).
