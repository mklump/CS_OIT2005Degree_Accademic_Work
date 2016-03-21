/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement pie
    open core

    constants
        className = "com/visual-prolog/pie".
        version = "$JustDate: 20.12.02 $$Revision: 6 $".

    clauses
        classInfo(className, version).

    clauses
        run():-
            TaskWindow = taskWindow::new(),
            TaskWindow:show().
end implement pie

goal
    mainExe::run(pie::run).
