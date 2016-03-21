/*****************************************************************************

                        Copyright (c) 

******************************************************************************/

implement projectToolbar
    open core, vpiDomains, vpiToolbar, resourceIdentifiers

    constants
        className = "TaskWindow/Toolbar/projectToolbar".
        classVersion = "".

    clauses
        classInfo(className, classVersion).
    clauses
        create(Parent):-
            _ = vpiToolbar::create(style, Parent, controlList).

    % This code is maintained by the VDE. Do not update it manually, 13:00:24-10.6.2003
    constants
        style : vpiToolbar::style = tb_top.
        controlList : vpiToolbar::control_list =
            [
            tb_ctrl(id_file_new,pushb,resId(idb_NewFileBitmap),"New;New File",1,1),
            tb_ctrl(id_file_open,pushb,resId(id_OpenFileBitmap),"Open;Open File",1,1),
            tb_ctrl(id_file_save,pushb,resId(id_SaveFileBitmap),"Save;Save File",1,1),
            vpiToolbar::separator,
            tb_ctrl(id_edit_undo,pushb,resId(id_UndoBitmap),"Undo;Undo",1,1),
            tb_ctrl(id_edit_redo,pushb,resId(id_RedoBitmap),"Redo;Redo",1,1),
            vpiToolbar::separator,
            tb_ctrl(id_edit_cut,pushb,resId(id_CutBitmap),"Cut;Cut to Clipboard",1,1),
            tb_ctrl(id_edit_copy,pushb,resId(id_CopyBitmap),"Copy;Copy to Clipboard",1,1),
            tb_ctrl(id_edit_paste,pushb,resId(id_PasteBitmap),"Paste;Paste from Clipboard",1,1),
            vpiToolbar::separator,
            tb_ctrl(id_help_contents,pushb,resId(id_HelpBitmap),"Help;Help",1,1)
            ].
    % end of automatic code
end implement projectToolbar
