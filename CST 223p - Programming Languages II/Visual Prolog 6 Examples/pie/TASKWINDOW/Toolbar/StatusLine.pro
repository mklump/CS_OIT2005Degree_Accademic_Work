/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement statusLine
    open core, vpiDomains, vpiToolbar, resourceIdentifiers

    constants
        className = "com/visual-prolog/TaskWindow/Toolbar/statusLine".
        version = "$JustDate: 20.12.02 $$Revision: 2 $".

    clauses
        classInfo(className, version).
    clauses
        create(Parent):-
            _ = vpiToolbar::create(style, Parent, controlList).

    % This code is maintained by the VDE. Do not update it manually, 12:33:48-5.12.2002
    constants
        style : vpiToolbar::style = tb_bottom.
        controlList : vpiToolbar::control_list =
            [
            tb_text(idt_help_line,tb_context,200,0,4,8,0x0,""),
            tb_text(idt_help_line_1,tb_static,49,1,4,8,0x0,"Stack:"),
            tb_text(idt_help_stack,tb_static,64,0,4,8,0x0,"Static text"),
            tb_text(idt_help_line_4,tb_static,60,1,4,8,0x0,"Heap:"),
            tb_text(idt_help_memory,tb_static,100,0,4,8,0x0,"Memory:"),
            tb_text(idt_help_line_5,tb_static,56,1,4,8,0x0,"GStack:"),
            tb_text(idt_help_gstack,tb_static,80,0,4,8,0x0,"Static text"),
            tb_text(idt_help_pause,tb_static,50,0,4,8,0x80,""),
            tb_text(idt_help_trace,tb_static,50,0,4,8,0x80,"")
            ].
    % end of automatic code
end implement statusLine
