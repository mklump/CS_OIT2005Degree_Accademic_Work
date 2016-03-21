/*****************************************************************************

                        Copyright (c) 

******************************************************************************/

implement statusLine
    open core, vpiDomains, vpiToolbar, resourceIdentifiers

    constants
        className = "TaskWindow/Toolbar/statusLine".
        classVersion = "".

    clauses
        classInfo(className, classVersion).
    clauses
        create(Parent):-
            _ = vpiToolbar::create(style, Parent, controlList).

    % This code is maintained by the VDE. Do not update it manually, 13:00:24-10.6.2003
    constants
        style : vpiToolbar::style = tb_bottom.
        controlList : vpiToolbar::control_list =
            [
            tb_text(idt_help_line,tb_context,452,0,4,10,0x0,"")
            ].
    % end of automatic code
end implement statusLine
