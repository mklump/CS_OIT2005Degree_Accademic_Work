/*****************************************************************************

		Copyright (c) Prolog Developement Center

 Written by: Visual Prolog
******************************************************************************/

class myDll
    predicates
        touch : (string String) -> string Touched
            procedure (i)
            language stdcall
            as "touch".
end class myDll
