/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class editor : editor
    open core

    predicates
        classInfo : core::classInfo.
        % @short Class information  predicate. 
        % @detail This predicate represents information predicate of this class.
        % @end

    constructors
        create : (vpiDomains::windowHandle Parent, string FileName, string Text).

    predicates
        editor_Create : (vpiDomains::windowHandle, string, core::booleanInt) determ.
    constants
        filemenutagbase : integer = 2000.
    predicates
        show_menu_with_filelists : (integer, vpiDomains::menu) procedure (i,o).
    predicates
        close_editors : (core::booleanInt) procedure (o).
    predicates
        open_file : (string, core::booleanInt) determ.
    predicates
        getText : (string FileName) -> string Text determ.
end class editor