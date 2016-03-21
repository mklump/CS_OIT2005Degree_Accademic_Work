/*****************************************************************************

                        Copyright (c) 

******************************************************************************/

implement prolog_Assignment
    open core

    constants
        className = "prolog_Assignment".
        classVersion = "".

    clauses
        classInfo(className, classVersion).

    clauses
        run():-
            TaskWindow = taskWindow::new(),
            TaskWindow:show().
end implement prolog_Assignment

goal
    mainExe::run(prolog_Assignment::run).
