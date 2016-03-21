/*****************************************************************************

        Copyright (c) Prolog Developement Center

 Written by: Visual Prolog
******************************************************************************/

implement myDllMain inherits mainDll
    clauses
        new():-
            mainDll::new(This),
            addDestroyListener(onDestroy).
            %add your initialization code here

    predicates
        onDestroy : resourceEventSource::destroyListener.
    clauses
        onDestroy(_ObjectMainDll).
            %add your code for unloading DLL here
end implement myDllMain

goal
    _ = myDllMain::new().
