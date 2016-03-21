/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement editor
    open core, vpiDomains, resourceIdentifiers, vpiCommonDialogs

    constants
        className = "com/visual-prolog/Editor/editor".
        version = "$JustDate: 11.01.03 $$Revision: 3 $".

    clauses
        classInfo(className, version).

class facts - edit_window
    edit_window : (vpiDomains::windowHandle, string FileName) nondeterm.
    app_close : () determ.

clauses
    editor_Create(TW, FileName, Prompt) :-
        get_file_data(FileName, Text, Prompt), 
        _ = create(TW, FileName, Text).

class predicates
    get_file_data : (string, string, core::booleanInt) determ anyflow.
clauses
    get_file_data(FileName, Text, _) :-
        FileName<>"", 
        trap(file5x::existfile(FileName), _, (fail, fail)), !, 
        string5x::format(ERROR_MSG, "Unable to load file %", FileName), 
        trap(file5x::file_str(FileName, Text), E, (error_handler(ERROR_MSG, E), fail)).
    get_file_data(FN, "", b_true) :- !, 
        string5x::format(Msg, "File %s does not exist. Create", FN), 
        Resp = vpiCommonDialogs::ask("Prolog Inference Engine", Msg, ["Yes", "No", ""]), 
        Resp = vpiCommonDialogs::resp_default.
    get_file_data(_, "", _).

clauses
    create(TW, FileName, Text) :-
        configuration::get_lru_pos(TW, FILENAME, RCT, POS), 
        FLAGS = [wsf_Close, wsf_SizeBorder, wsf_TitleBar, 
                wsf_Minimize, wsf_Maximize, wsf_ClipChildren, 
                wsf_ClipSiblings], 
        configuration::get_edit_font(FONT), 
        ReadOnly = b_false, 
        Indent = b_true, 
        show_menu_with_filelists(id_TaskMenu, NewMenu), 
        get_title(FileName, Title), 
        EW = vpiEditor::create(w_TopLevel, RCT, Title, 
                NewMenu, TW, FLAGS, FONT, 
                ReadOnly, Indent, Text, Pos, eventHandler), 
        assert(edit_window(EW, FileName)),
        configuration::set_lru_pos(EW, FileName), 
        replace_menu_in_all_windows.
    
class predicates
    error_handler : (string, integer) procedure.
clauses
    error_handler(S, E) :-
        string5x::format(STR, "% - Error code = %", S, E), 
        vpiCommonDialogs::error(STR).

clauses
    show_menu_with_filelists(MENU, NewMenu):-
        OldMenu = vpi::menuGetRes(MENU), 
        OldMenu = vpidomains::dynMenu([vpidomains::txt(F1, F2, F3, F4, F5, OldFSubmenu)|REST]),
        !,
        build_file_submenu(OldFSubmenu, NewFSubMenu), 
        NewMenu = vpidomains::dynMenu([vpidomains::txt(F1, F2, F3, F4, F5, NewFSubmenu)|REST]).
    show_menu_with_filelists(MENU, _) :-
        common_exception::raise_error(classInfo, predicate_name(), "Obtained menu is not a dynMenu. ResID = ", MENU).

class predicates
    get_title : (string, string) procedure anyflow.
clauses
    get_title(FileName, Title) :-
        file5x::disk(Path), 
        string5x::str_len(Path, Len), 
        string5x::frontstr(Len, FileName, Front, Title1),
        Front = Path,
        string5x::frontstr(1, Title1, _, Title),
        !.
    get_title(FileName, FileName).

class predicates
    replace_menu_in_all_windows : () procedure.
clauses
    replace_menu_in_all_windows() :-
        Task_win = uncheckedConvert(vpiDomains::windowHandle, vpi::getAttrVal(attr_task_window)), 
        show_menu_with_filelists(id_TaskMenu, NewMenu), 
        vpi::menuSet(Task_win, NewMenu), 
        fail.
    replace_menu_in_all_windows() :-
        edit_window(EW, _), 
                show_menu_with_filelists(id_TaskMenu, NewMenu), 
                vpi::menuSet(EW, NewMenu), 
        fail.
    replace_menu_in_all_windows().

class predicates
    build_file_submenu : (vpiDomains::menuItem_list, vpiDomains::menuItem_list) procedure anyflow.
clauses
    build_file_submenu(InSubmenu, OutSubmenu):-
        configuration::get_lru_list(SList), 
        not(Slist=[]),
        !,
        stringlist2itemlist(filemenutagbase, filemenutagbase, SList, IList), 
        append(InSubMenu, [vpidomains::separator|IList], OutSubmenu).
    build_file_submenu(Submenu, Submenu).

class predicates
    check_true_item : (vpiDomains::windowHandle, integer) nondeterm (i,o).
clauses
    check_true_item(WIN, id_edit_undo):-    %     if undo buffer is not empty
        vpiEditor::possibleUndoRedo(WIN, IsUndo, _), IsUndo=b_true.
    check_true_item(WIN, id_edit_redo):-    %     if undo buffer is not empty
        vpiEditor::possibleUndoRedo(Win, _, IsRedo), IsRedo=b_true.
    check_true_item(WIN, Item):-    % if block marked
        vpiEditor::getSelection(WIN, Sel1, Sel2), not(Sel1=Sel2), 
        member_nd(Item, [id_edit_cut, id_edit_copy, id_edit_delete]).
    check_true_item(_, id_edit_paste) :-
        vpi::cbStringAvailable.
    check_true_item(_WIN, Item):-
        member_nd(Item, [id_file_save, 
                         id_file_save_as, 
                         id_Engine_reconsult, 
                         id_edit_goto_line, 
                         id_edit_goto_pos, 
                         id_edit_goto_clause, 
                         id_edit_insert, 
                         id_edit_search, 
                         id_edit_replace, 
                         id_edit_search_again]).

class predicates  
    append : (vpiDomains::menuItem_list,vpiDomains::menuItem_list,vpiDomains::menuItem_list) procedure (i,i,o).
clauses
    append([],L,L).
    append([X|L1],L2,[X|L3]) :- append(L1,L2,L3).

class predicates
    member : (integer,core::integer_list) nondeterm (i,i).
clauses
    member(H,[H|_]).
    member(X,[_|T]) :- member(X,T).

class predicates
    member_nd : (vpiDomains::wsflag,vpiDomains::wsflags) nondeterm (o,i).
clauses
    member_nd(H,[H|_]).
    member_nd(X,[_|T]) :- member_nd(X,T).
  

class predicates
    check_false_item : (vpiDomains::windowHandle, integer) nondeterm (i,o).
clauses
    check_false_item(WIN, id_edit_undo):- %     if undo buffer is empty
        vpiEditor::possibleUndoRedo(WIN, IsUndo, _), IsUndo=b_false.
    check_false_item(WIN, id_edit_redo):- %     if undo buffer is empty
        vpiEditor::possibleUndoRedo(Win, _, IsRedo), IsRedo=b_false.
    check_false_item(WIN, Item):-    % block is not marked
        vpiEditor::getSelection(WIN, Sel1, Sel2), Sel1=Sel2, 
        member_nd(Item, [id_edit_cut, id_edit_copy, id_edit_delete]).
    check_false_item(_, id_edit_paste) :-
        not(vpi::cbStringAvailable).

class predicates
    save_as : (vpiDomains::windowHandle, string) procedure.
clauses
    save_as(_, NewName) :-
        edit_window(_, NewName), !, 
        vpiCommonDialogs::note("Can't write(process active)").
    save_as(_, NewName) :-
        file5x::existfile(NewName), 
        string5x::format(Prompt, "Rewrite %s?", NewName), 
        Resp = vpiCommonDialogs::ask("Prolog Inference Engine", Prompt, ["Yes", "No", ""]), 
        Resp <> vpiCommonDialogs::resp_default, !.
    save_as(EW, NewName) :-
        retractall(edit_window(EW, _)), 
        assert(edit_window(EW, NewName)), 
        get_title(NewName, Title), 
        vpi::winSetText(EW, Title),
        Text = vpiEditor::getText(EW), 
        file5x::file_str(NewName, Text), 
        vpiEditor::clearModified(EW).

class predicates
    menuitem_switch : (vpiDomains::windowHandle, core::integer_list, core::booleanInt) procedure.
clauses
    menuitem_switch(W, [], _):-
        vpi::menuUpdate(W),
        !.
    menuitem_switch(W, [First|Rest], Boolean):-
        vpi::menuEnable(W, First, Boolean), 
        menuitem_switch(W, Rest, Boolean).
        
class predicates
    menuPopup_Switch : (vpiDomains::menuItem_list, core::integer_list, core::booleanInt, vpiDomains::menuItem_list) procedure(i, i, i, o).
clauses
    menuPopup_Switch([], _, _, []) :-
        !.
    menuPopup_Switch(
            [vpidomains::txt(TAG, TEXT, CHR, _, CHCK, ChildMNU)|T], 
            TAGLIST, 
            Bool, 
            [vpidomains::txt(TAG, TEXT, CHR, Bool, CHCK, NewChildMNU)|MNU]) :-
        menuPopup_Switch(ChildMNU, TAGLIST, Bool, NewChildMNU), 
        member(TAG, TAGLIST), 
        !, 
        menuPopup_Switch(T, TAGLIST, Bool, MNU).
    menuPopup_Switch(
            [vpidomains::txt(TAG, TEXT, CHR, Enable, CHCK, ChildMNU)|T], 
            TAGLIST, 
            Bool, 
            [vpidomains::txt(TAG, TEXT, CHR, Enable, CHCK, NewChildMNU)|MNU]) :-
        menuPopup_Switch(ChildMNU, TAGLIST, Bool, NewChildMNU), 
        !, 
        menuPopup_Switch(T, TAGLIST, Bool, MNU).
    menuPopup_Switch([H|T], TAGLIST, Bool, [H|MNU]) :-
        menuPopup_Switch(T, TAGLIST, Bool, MNU).

class predicates
    insert_clause : (vpiDomains::windowHandle) procedure.
clauses
    insert_clause(Win):-
        findall(X, engine::std_clause(X, _), SLIST ), 
        not(SLIST=[]), 
        Title="Select Clause", 
        PreSel=0, 
        _ = vpiCommonDialogs::listSelect(Title, SLIST, PreSel, StrSel, _), 
        engine::std_clause(StrSel, Prototype), 
        string5x::format(StrToInsert, "\t%s, \n", Prototype), 
        Pos=vpiEditor::getPos(Win),
        !, 
        insert_predicate(Win, Pos, StrToInsert).
    insert_clause(_).

class predicates
    clean_up_data : (vpiDomains::windowHandle, core::booleanInt) determ (i,o).
clauses
    clean_up_data(EW, Close) :-
        edit_window(EW, FileName), 
        b_true = vpiEditor::isModified(EW),
        !, 
        get_title(FileName, Title), 
        string5x::format(Prompt, "Save %s?", Title), 
        Resp = vpiCommonDialogs::ask("Prolog Inference Engine", Prompt, ["Yes", "No", "Cancel"]), 
        NewData = vpiEditor::getText(EW), 
        save_no_cancel(Resp, FileName, NewData, Close).
    clean_up_data(EW, b_True) :-
        retract(edit_window(EW, FileName)), !, 
        retract_editor(FileName).

class predicates
    stringlist2itemlist : (integer, integer, core::string_list, vpiDomains::menuItem_list) procedure anyflow.
clauses
    stringlist2itemlist(_, _, [], []):-!.
    stringlist2itemlist(Base, Tag, [Str|RestS], [vpidomains::txt(Tag, Line, noAccelerator(), b_true, b_false, [])|RestI]):-
        Tag1 = Tag+1, 
        Number = Tag1 - Base, 
        reduce_menuTag(Str, StrReduced, 45), %YI
        string5x::format(Line, "&% %", Number, StrReduced), 
        stringlist2itemlist(Base, Tag1, RestS, RestI).

class predicates
    insert_predicate : (vpiDomains::windowHandle, integer, string) procedure.
clauses
    insert_predicate(EdWin, Pos, What):-
        vpiEditor::doLineHome(EdWin), 
        trap(BeginPos = vpiEditor::getPos(EdWin), E, (error_handler("unable_get_curpos", E), fail)), 
        vpiEditor::doLineEnd(EdWin), 
        trap(EndPos = vpiEditor::getPos(EdWin), E1, (error_handler("unable_get_curpos", E1), fail)), 
        BeginPos = EndPos, !, 
        del_last_enter(What, What1), 
        _ = vpiEditor::pasteStr(EdWin, Pos, What1).
    insert_predicate(EdWin, Pos, What):-
        vpiEditor::doLineEnd(EdWin), 
        trap(EndPos = vpiEditor::getPos(EdWin), E, (error_handler("unable_get_curpos", E), fail)), 
        Pos = EndPos, !, 
        Pos1 = Pos + 1, 
        _ = vpiEditor::pasteStr(EdWin, Pos1, What).
    insert_predicate(EdWin, Pos, What):-
        vpiEditor::doLineHome(EdWin), 
        trap(BeginPos = vpiEditor::getPos(EdWin), E, (error_handler("unable_get_curpos", E), fail)), 
        Text=vpiEditor::getText(EdWin), 
        NBytes = Pos - BeginPos, 
        NBytes > 0, !, 
        string5x::substring(Text, BeginPos, NBytes, SubString), 
        insert_predicate_in_line(EdWin, SubString, What, BeginPos, Pos).
    insert_predicate(EdWin, Pos, What):-
        _ = vpiEditor::pasteStr(EdWin, Pos, What).

class predicates
    insert_predicate_in_line : (vpiDomains::windowHandle, string, string, integer, integer) procedure.
clauses
    insert_predicate_in_line(EdWin, SubString, What, _, Pos):-
        is_space_and_tab(SubString), !, 
        del_last_enter(What, What1), 
        del_first_tab(What1, What2), 
        _ = vpiEditor::pasteStr(EdWin, Pos, What2).
    insert_predicate_in_line(EdWin, _, What, BeginPos, _):-!, 
        _ = vpiEditor::pasteStr(EdWin, BeginPos, What).

class predicates
    save_no_cancel : (integer, string, string, core::booleanInt) procedure anyflow.
clauses
    save_no_cancel(vpiCommonDialogs::resp_default, FN, Data, b_True) :-
        trap(file5x::file_str(FN, Data), C, (error_handler("Failed writing", C), fail)), !, 
        retractall(edit_window(_, FN)), 
        retract_editor(FN).
    save_no_cancel(vpiCommonDialogs::resp_2, FN, _, b_True) :- !, 
        retractall(edit_window(_, FN)), !, 
        retract_editor(FN).
    save_no_cancel(_, _, _, b_False).
    
class predicates
    retract_editor : (string) procedure.
clauses
    retract_editor(_) :-
        app_close, !.
    retract_editor(FN) :-
        configuration::retract_open_editor(FN).
            
class predicates
    reduce_menuTag : (string, string, integer) procedure anyflow.
clauses
    reduce_menuTag(Str, Str, MLen):-
        string5x::str_len(Str, Len), 
        Len < MLen,
        !.
    reduce_menuTag(Str, StrReduced, _):-
        find_head(Str, Head), 
        find_tail(0, Str, Tail),
        !,
        string5x::format(StrReduced, "%s...%s", Head, Tail), !.
    reduce_menuTag(Str, Str, _).

class predicates
    del_last_enter : (string, string) procedure anyflow.
clauses
    del_last_enter(What, What1):-
        string5x::concat(What1, "\n", What), !.
    del_last_enter(What, What):-!.

class predicates
    is_space_and_tab : (string) determ.
clauses
    is_space_and_tab(""):-!.
    is_space_and_tab(S):-
        string5x::frontchar(S, ' ', S1), !, 
        is_space_and_tab(S1).
    is_space_and_tab(S):-
        string5x::frontchar(S, '\t', S1), !, 
        is_space_and_tab(S1).

class predicates 
    find_head : (string, string) determ anyflow.
clauses
    find_head(Str, Head):-
        string5x::searchchar(Str, '\\', Pos1), 
        string5x::frontstr(Pos1, Str, Start1, Rest), 
        string5x::searchchar(Rest, '\\', Pos2), 
        string5x::frontstr(Pos2, Rest, Start2, _), 
        string5x::concat(Start1, Start2, Head), !.

class predicates 
    find_tail : (integer, string, string) determ anyflow.
clauses
    find_tail(2, _, ""):-!.
    find_tail(I, Str, Tail):-
        string5x::str_len(Str, Len), 
        Pos = Len - 1, 
        string5x::frontstr(Pos, Str, Start, Rest), 
        Rest = "\\", !, 
        I1 = I + 1, 
        find_tail(I1, Start, Tail1), 
        string5x::concat(Tail1, Rest, Tail).
    find_tail(I, Str, Tail):-!, 
        string5x::str_len(Str, Len), 
        Pos = Len - 1, 
        string5x::frontstr(Pos, Str, Start, Rest), 
        find_tail(I, Start, Tail1), 
        string5x::concat(Tail1, Rest, Tail).

class predicates 
    del_first_tab : (string, string) procedure anyflow.
clauses    
    del_first_tab(S, S1):-
        string5x::frontchar(S, '\t', S1), !.
    del_first_tab(S, S):-!.

clauses    
     close_editors(b_False) :-
        retractall(app_close),
        assert(app_close),
        edit_window(W, _), 
                clean_up_data(W, Continue), 
        Continue = b_False,  % CANCEL is Pressed
        !,
        retractall(app_close).
     close_editors(b_True) :-
        retractall(app_close).

clauses
    open_file(FileName, _) :-
        edit_window(EW, FileName),
        !, 
        vpi::winSetFocus(EW).
    open_file(FileName, Prompt) :-
        TASK_ATTR = vpi::getAttrVal(attr_task_window), 
        TASK_WIN = uncheckedConvert(vpiDomains::windowHandle, TASK_ATTR), 
        editor::editor_Create(TASK_WIN, FileName, Prompt).

clauses
    getText(FileName) = Text :-
        edit_window(EW, FileName),
        !,
        Text = vpiEditor::getText(EW).

class predicates
    initMenu : (vpiDomains::windowHandle Window) procedure (i).
clauses
    initMenu(WIN) :-
        findall(TrueItem, check_true_item(WIN, TrueItem), TList), 
        findall(FalseItem, check_false_item(WIN, FalseItem), FList), 
        menuitem_switch(WIN, TList, b_true), 
        menuitem_switch(WIN, FList, b_false).

    facts
        thisWin : vpiDomains::windowHandle := uncheckedConvert(vpiDomains::windowHandle, 0).

    predicates
        eventHandler : vpiDomains::ehandler.
    clauses
        eventHandler(Win, Event) = Result :-
            Result = generatedEventHandler(Win, Event),
            !.
        eventHandler(Win, e_Menu(Id, CAS)) = Result :-
            Parent = vpi::winGetParent(Win),
            Result = vpi::winSendEvent(Parent, e_Menu(Id, CAS)).

    predicates
        onCreate : vpiDomains::createHandler.
    clauses
        onCreate(_CreationData) = handled(b_true) :-
            TASKWIN = vpi::getTaskWindow(),
            vpiToolbar::mesRedirect(TASKWIN,thisWin).    

    predicates
        onSizeChanged : vpiDomains::sizeHandler.
    clauses
        onSizeChanged(_Width, _Height) = defaultHandling() :-
            edit_window(thisWin, FILENAME),
            !, 
            configuration::set_lru_pos(thisWin, FILENAME).
        onSizeChanged(_Width, _Height) = defaultHandling().

    predicates
        onMouseDown : vpiDomains::mouseDownHandler.
    clauses
        onMouseDown(Point, _ShiftControlAlt, 1) = handled(b_true) :-
            !,
            contextMenu(Point).
        onMouseDown(_Point, _ShiftControlAlt, _) = defaultHandling().

    predicates
        contextMenu : (vpiDomains::pnt Point) procedure (i).
    clauses
        contextMenu(Point) :-
            MNU = vpi::menuGetRes(popup_menu), 
            MNU = vpidomains::dynMenu(MLIST1),
            !,
            findall(Item1, check_True_Item(thisWin, Item1), ItemList1), 
            findall(Item2, check_False_Item(thisWin, Item2), ItemList2), 
            menuPopup_Switch(MLIST1, ItemList1, b_True, MLIST2), 
            menuPopup_Switch(MLIST2, ItemList2, b_False, MLIST3), 
            MNU2 = vpidomains::dynMenu(MLIST3), 
            vpi::menuPopUp(thisWin, MNU2, Point, align_Left).
        contextMenu(_Point) :-
            common_exception::raise_error(classInfo, predicate_name(), "Context menu is not a dynMenu").

    predicates
        onGetFocus : vpiDomains::getFocusHandler.
    clauses
        onGetFocus() = handled(0) :-
            Taskwin = vpi::getTaskWindow(), 
            vpiToolbar::mesRedirect(Taskwin, thisWin).

    predicates
        onMove : vpiDomains::moveHandler.
    clauses
        onMove(_X, _Y) = defaultHandling() :-
            edit_window(thisWin, FILENAME),
            !, 
            configuration::set_lru_pos(thisWin, FILENAME).
        onMove(_X, _Y) = defaultHandling().


    predicates
        onFileSave : vpiDomains::menuItemHandler.
    clauses
        onFileSave(_MenuTag) = handled(0) :-
            b_true = vpiEditor::isModified(thisWin), 
            edit_window(thisWin, FileName), 
            !,
            Text = vpiEditor::getText(thisWin), 
            file5x::file_str(FileName, Text), 
            vpiEditor::clearModified(thisWin).
        onFileSave(_MenuTag) = handled(0).

    predicates
        onFileSaveAs : vpiDomains::menuItemHandler.
    clauses
        onFileSaveAs(_MenuTag) = handled(0) :-
            configuration::get_src_dir(SavedDir), 
            NewName = vpiCommonDialogs::getFileName("*.pro", 
                    ["Prolog files(*.pro)", "*.pro", 
                    "PIE Files(*.pie)", "*.pie", 
                    "All files(*.*)", "*, *"], 
                    "Open file", 
                    [dlgfn_Save], 
                    SavedDir, 
                    _), 
            configuration::set_src_dir(NewName), 
            edit_window(thisWin, OldName), 
            OldName <> NewName,
            !, 
            save_as(thisWin, NewName).
        onFileSaveAs(_MenuTag) = handled(0) :-
            b_true = vpiEditor::isModified(thisWin),
            edit_window(thisWin, Name), 
            !, 
            Text = vpiEditor::getText(thisWin), 
            file5x::file_str(Name, Text), 
            vpiEditor::clearModified(thisWin), 
            !.
        onFileSaveAs(_MenuTag) = _ :-
            common_exception::raise_error(classInfo, predicate_name(), "").

    predicates
        onEditCut : vpiDomains::menuItemHandler.
    clauses
        onEditCut(_MenuTag) = handled(0) :-
            vpiEditor::cut(thisWin).

    predicates
        onEditCopy : vpiDomains::menuItemHandler.
    clauses
        onEditCopy(_MenuTag) = handled(0) :-
            vpiEditor::copy(thisWin).

    predicates
        onEditPaste : vpiDomains::menuItemHandler.
    clauses
        onEditPaste(_MenuTag) = handled(0) :-
            vpiEditor::paste(thisWin).

    predicates
        onEditUndo : vpiDomains::menuItemHandler.
    clauses
        onEditUndo(_MenuTag) = handled(0) :-
            vpiEditor::undo(thisWin).

    predicates
        onEditRedo : vpiDomains::menuItemHandler.
    clauses
        onEditRedo(_MenuTag) = handled(0) :-
            vpiEditor::redo(thisWin).

    predicates
        onEditDelete : vpiDomains::menuItemHandler.
    clauses
        onEditDelete(_MenuTag) = handled(0) :-
            vpiEditor::delete(thisWin).

    predicates
        onEditSearch : vpiDomains::menuItemHandler.
    clauses
        onEditSearch(_MenuTag) = handled(0) :-
            vpiEditor::searchDialog(thisWin).

    predicates
        onEditReplace : vpiDomains::menuItemHandler.
    clauses
        onEditReplace(_MenuTag) = handled(0) :-
            vpiEditor::replaceDialog(thisWin).

    predicates
        onEditSearchAgain : vpiDomains::menuItemHandler.
    clauses
        onEditSearchAgain(_MenuTag) = handled(0) :-
            vpiEditor::searchAgain(thisWin).

    predicates
        onEditGotoLine : vpiDomains::menuItemHandler.
    clauses
        onEditGotoLine(_MenuTag) = handled(0) :-
            vpiEditor::gotoLineDialog(thisWin).

    predicates
        onEditGotoPos : vpiDomains::menuItemHandler.
    clauses
        onEditGotoPos(_MenuTag) = handled(0) :-
            vpiEditor::gotoPosDialog(thisWin).

    predicates
        onEditInsert : vpiDomains::menuItemHandler.
    clauses
        onEditInsert(_MenuTag) = handled(0) :-
            insert_clause(thisWin).

    predicates
        onEditGotoClause : vpiDomains::menuItemHandler.
    clauses
        onEditGotoClause(_MenuTag) = handled(0) :-
            engine::get_clause_list(RUN_PREDICATES), 
            not(RUN_PREDICATES=[]), 
            Title="Select clause", 
            PreSel=1, 
            _ = vpiCommonDialogs::listSelect(Title, RUN_PREDICATES, PreSel, StrSel, _), 
            Text=vpiEditor::getText(thisWin), 
            string5x::searchstring(Text, StrSel, FoundPos),
            FoundPos>0, 
            _ = vpiEditor::gotoPos(thisWin, FoundPos),
            !.
        onEditGotoClause(_MenuTag) = handled(0).


    predicates
        onInitMenu : vpiDomains::initMenuHandler.
    clauses
        onInitMenu() = handled(0) :-
            initMenu(thisWin).


    predicates
        onEngineReconsult : vpiDomains::menuItemHandler.
    clauses
        onEngineReconsult(_MenuTag) = handled(0) :-
            edit_window(thisWin, FileName),
            !,
            Text = vpiEditor::getText(thisWin), 
            engine::recons_text(Text), 
            string5x::format(Status, "Reconsult %s", FileName), 
            taskWindow::system_status(Status), 
            file5x::write("Reconsulted from: ", FileName), file5x::nl, 
            taskWindow::system_status("Ready").
        onEngineReconsult(_MenuTag) = _ :-
            common_exception::raise_error(classInfo, predicate_name(), "change file name to fact variable").
        

    predicates
        onHelpLocal : vpiDomains::menuItemHandler.
    clauses
        onHelpLocal(_MenuTag) = handled(0) :-
            vpiEditor::getSelection(thisWIN, Sel1, Sel2),
            not(Sel1=Sel2),
            !,
            Key = vpiEditor::getText(thisWin, Sel1, Sel2), 
            vpi::showHelpKeyWord("pie.hlp", Key).
        onHelpLocal(_MenuTag) = handled(0) :-
            vpi::showHelp("pie.hlp").

    predicates
        onCloseRequest : vpiDomains::closeRequestHandler.
    clauses
        onCloseRequest() = handled(0) :-
            clean_up_data(thisWin, Close), 
            TASKWIN=vpi::getTaskWindow(), 
            vpiToolbar::mesRedirect(TASKWIN, TASKWIN), 
            Close=b_False,
            !.
        onCloseRequest() = defaultHandling().

    predicates
        onEditFont : vpiDomains::menuItemHandler.
    clauses
        onEditFont(_MenuTag) = handled(0) :-
            vpiEditor::setFontDialog(thisWin), 
            Font = vpi::winGetFont(thisWin), 
            configuration::set_edit_font(Font).

    predicates
        onChangeCaseSetLower : vpiDomains::menuItemHandler.
    clauses
        onChangeCaseSetLower(_MenuTag) = handled(0) :-
            vpiEditor::lowerCase(thisWin).

    predicates
        onChangeCaseSetUpper : vpiDomains::menuItemHandler.
    clauses
        onChangeCaseSetUpper(_MenuTag) = handled(0) :-
            vpiEditor::upperCase(thisWin).

    predicates
        onChangeCaseToggle : vpiDomains::menuItemHandler.
    clauses
        onChangeCaseToggle(_MenuTag) = handled(0) :-
            vpiEditor::reverseCase(thisWin).

    predicates
        onEditAutoindent : vpiDomains::menuItemHandler.
    clauses
        onEditAutoindent(_MenuTag) = handled(0) :-
            b_false = vpiEditor::getIndent(thisWin), 
            !, 
            vpiEditor::setIndent(thisWin, b_true).
        onEditAutoindent(_MenuTag) = handled(0) :-
            vpiEditor::setIndent(thisWin, b_false).

    constants
%        windowType : vpiDomains::wintype = w_TopLevel.
%        windowFlags : vpiDomains::wsflags = [wsf_SizeBorder,wsf_TitleBar,wsf_Maximize,wsf_Minimize,wsf_Close,wsf_ClipSiblings,wsf_ClipChildren].
%        rectangle : vpiDomains::rct = rct(100,80,440,240).
%        menu : vpiDomains::menu = resMenu(popup_menu).
%        title : string = "editor".

    predicates
        generatedEventHandler : vpiDomains::ehandler.
    clauses
        generatedEventHandler(Win, e_create(_CreationData)) = _Result :-
            thisWin := Win,
            fail.
        generatedEventHandler(_Win, e_Create(CreationData)) = Result :-
            handled(Result) = onCreate(CreationData).
        generatedEventHandler(_Win, e_Size(Width, Height)) = Result :-
            handled(Result) = onSizeChanged(Width, Height).
        generatedEventHandler(_Win, e_Move(X, Y)) = Result :-
            handled(Result) = onMove(X, Y).
        generatedEventHandler(_Win, e_InitMenu()) = Result :-
            handled(Result) = onInitMenu().
        generatedEventHandler(_Win, e_Menu(id_edit_font, _)) = Result :-
            handled(Result) = onEditFont(id_edit_font).
        generatedEventHandler(_Win, e_Menu(id_Change_Case_set_lower, _)) = Result :-
            handled(Result) = onChangeCaseSetLower(id_Change_Case_set_lower).
        generatedEventHandler(_Win, e_Menu(id_Change_Case_set_upper, _)) = Result :-
            handled(Result) = onChangeCaseSetUpper(id_Change_Case_set_upper).
        generatedEventHandler(_Win, e_Menu(id_Change_Case_toggle, _)) = Result :-
            handled(Result) = onChangeCaseToggle(id_Change_Case_toggle).
        generatedEventHandler(_Win, e_Menu(id_edit_autoindent, _)) = Result :-
            handled(Result) = onEditAutoindent(id_edit_autoindent).
        generatedEventHandler(_Win, e_GetFocus()) = Result :-
            handled(Result) = onGetFocus().
        generatedEventHandler(_Win, e_CloseRequest()) = Result :-
            handled(Result) = onCloseRequest().
        generatedEventHandler(_Win, e_MouseDown(Point, ShiftControlAlt, Button)) = Result :-
            handled(Result) = onMouseDown(Point, ShiftControlAlt, Button).
        generatedEventHandler(_Win, e_Menu(id_file_save, _)) = Result :-
            handled(Result) = onFileSave(id_file_save).
        generatedEventHandler(_Win, e_Menu(id_file_save_as, _)) = Result :-
            handled(Result) = onFileSaveAs(id_file_save_as).
        generatedEventHandler(_Win, e_Menu(id_edit_cut, _)) = Result :-
            handled(Result) = onEditCut(id_edit_cut).
        generatedEventHandler(_Win, e_Menu(id_edit_copy, _)) = Result :-
            handled(Result) = onEditCopy(id_edit_copy).
        generatedEventHandler(_Win, e_Menu(id_edit_paste, _)) = Result :-
            handled(Result) = onEditPaste(id_edit_paste).
        generatedEventHandler(_Win, e_Menu(id_edit_undo, _)) = Result :-
            handled(Result) = onEditUndo(id_edit_undo).
        generatedEventHandler(_Win, e_Menu(id_edit_redo, _)) = Result :-
            handled(Result) = onEditRedo(id_edit_redo).
        generatedEventHandler(_Win, e_Menu(id_edit_delete, _)) = Result :-
            handled(Result) = onEditDelete(id_edit_delete).
        generatedEventHandler(_Win, e_Menu(id_edit_search, _)) = Result :-
            handled(Result) = onEditSearch(id_edit_search).
        generatedEventHandler(_Win, e_Menu(id_edit_replace, _)) = Result :-
            handled(Result) = onEditReplace(id_edit_replace).
        generatedEventHandler(_Win, e_Menu(id_edit_search_again, _)) = Result :-
            handled(Result) = onEditSearchAgain(id_edit_search_again).
        generatedEventHandler(_Win, e_Menu(id_edit_goto_line, _)) = Result :-
            handled(Result) = onEditGotoLine(id_edit_goto_line).
        generatedEventHandler(_Win, e_Menu(id_edit_goto_pos, _)) = Result :-
            handled(Result) = onEditGotoPos(id_edit_goto_pos).
        generatedEventHandler(_Win, e_Menu(id_edit_insert, _)) = Result :-
            handled(Result) = onEditInsert(id_edit_insert).
        generatedEventHandler(_Win, e_Menu(id_edit_goto_clause, _)) = Result :-
            handled(Result) = onEditGotoClause(id_edit_goto_clause).
        generatedEventHandler(_Win, e_Menu(id_Engine_reconsult, _)) = Result :-
            handled(Result) = onEngineReconsult(id_Engine_reconsult).
        generatedEventHandler(_Win, e_Menu(id_help_local, _)) = Result :-
            handled(Result) = onHelpLocal(id_help_local).
end implement editor
