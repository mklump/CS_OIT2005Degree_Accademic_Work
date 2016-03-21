/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement taskWindow
open core, vpiDomains, resourceIdentifiers, vpiCommonDialogs, vpiEditor, stdIO

constants
    className = "com/visual-prolog/TaskWindow/taskWindow".
    version = "$JustDate: 11.01.03 $$Revision: 3 $".

clauses
    classInfo(className, version).

class facts - edit_window
    edit_count : (integer).

class predicates
    open_editors : (core::string_list) procedure anyflow.
clauses
    open_editors([]).
    open_editors([H|T]) :-
        editor::open_file(H, b_true), !, 
        open_editors(T).
    open_editors([H|T]) :-
        configuration::retract_open_editor(H), !, 
        open_editors(T).

class predicates
    set_enabled_menu : (vpiDomains::windowHandle) determ anyflow.
clauses
    set_enabled_menu(W) :-
        vpi::menuEnable(W, id_file_save, b_true), 
        vpi::menuEnable(W, id_file_save_as, b_true), 
        vpi::menuEnable(W, id_edit_cut, b_true), 
        vpi::menuEnable(W, id_edit_copy, b_true), 
        vpi::menuEnable(W, id_edit_paste, b_true), 
        vpi::menuEnable(W, id_edit_delete, b_true), 
        vpi::menuEnable(W, id_edit_undo, b_true), 
        vpi::menuEnable(W, id_edit_redo, b_true).

class predicates
    next_filename : (string) procedure anyflow.
clauses
    next_filename(FileName) :-
        retract(edit_count(N)),
        !, 
        Path = directory::getCurrentDirectory(), 
        FileName0 = string::format("%s\\FILE%u.PRO", Path, N), 
        N1 = N + 1, 
        assert(edit_count(N1)), 
        next_filename(FileName0, FileName).
    next_filename(FileName) :-
        assert(edit_count(0)), 
        next_filename(FileName).

class predicates
    next_filename : (string, string) procedure anyflow.
clauses
    next_filename(FileName0, FileName1) :-
        file::existFile(FileName0), !, 
        next_filename(FileName1).
    next_filename(FileName, FileName).


class predicates 
    clean_the_application : (core::booleanInt) determ anyflow.
clauses
     clean_the_application(b_True) :- !, 
        engine::pauseOff,                                 % resume Engine
        engine::break_execution.                        % break current goal
     clean_the_application(b_False).
     
class predicates
    getWindowFlags : () -> vpiDomains::wsflags Flags procedure anyflow.
clauses
   getWindowFlags() = [wsf_Maximized|windowFlags] :-
        configuration::taskWindow_maximized(),
        !.
  getWindowFlags() = windowFlags.



/******************************************************
 *        Display system information                            *
 ******************************************************/
clauses
    system_status(STATUS):-
        _ = vpi::processEvents(0), 
        Task = vpi::getTaskWindow(), 
        UsedStack = memory::getUsedStack(),  
        TotalGStack = memory::getTotalGlobalStack(),
        FreeGStack = memory::getFreeGlobalStack(),
        UsedGStack = TotalGStack - FreeGStack,
        UsedHeap = memory::getUsedHeap(),
        StackTxt = string::format("%", UsedStack), 
        MEMTxt = string::format("%", UsedHeap), 
        GStackTxt = string::format("%", UsedGStack), 
        get_pause_txt(PT), 
        get_trace_txt(TT), 
        vpiToolbar::setValue(Task, idt_help_stack, vpitoolbar::text_value(StackTxt)), 
        vpiToolbar::setValue(Task, idt_help_memory, vpitoolbar::text_value(MEMTxt)), 
        vpiToolbar::setValue(Task, idt_help_gstack, vpitoolbar::text_value(GStackTxt)), 
        vpiToolbar::setValue(Task, idt_help_line, vpitoolbar::text_value(STATUS)), 
        vpiToolbar::setValue(Task, idt_help_pause, vpitoolbar::text_value(PT)), 
        vpiToolbar::setValue(Task, idt_help_trace, vpitoolbar::text_value(TT)), 
        !.
        
class predicates 
     get_pause_txt : (string) procedure anyflow.
clauses
    get_pause_txt("PAUSE") :- engine::is_system_paused, !.
    get_pause_txt("").
    
class predicates 
     get_trace_txt : (string) procedure anyflow.
clauses
    get_trace_txt("TRACE") :- engine::is_system_trace, !.
    get_trace_txt("").

/******************************************************
 *    File menu handling                                *
 ******************************************************/
class predicates 
    get_file : (integer, integer, core::string_list, string) determ anyflow.
clauses
    get_file(_, _, [], "noname"):-!, fail.
    get_file(N, I, _, "noname"):-N < I, !, fail.
    get_file(N, N, [Name|_], Name):-!.
    get_file(N, I, [_|LISTNAMES], Name):-!, 
        I1 = I + 1, 
        get_file(N, I1, LISTNAMES, Name).

    facts
        thisWin : vpiDomains::windowHandle := uncheckedConvert(vpiDomains::windowHandle, 0).

    constants
        mdiProperty : integer = core::b_true.

    clauses
        show():-
            vpi::setAttrVal(attr_win_mdi, mdiProperty), 
            vpi::setAttrVal(attr_win_tbar, b_true), 
            vpi::setAttrVal(attr_win_sbar, b_true), 
            configuration::load_cfg(),
            TaskFlags = getWindowFlags(), 
            vpi::setErrorHandler(vpi::dumpErrorHandler), 
            vpi::init(TaskFlags, eventHandler, menu, "resolut", title).

    predicates
        eventHandler : vpiDomains::ehandler.
    clauses
        eventHandler(_Win, vpidomains::e_Menu(FileListTag, _)) = 0 :-
            FileListTag >= editor::filemenutagbase, 
            FileListTag < editor::filemenutagbase+10,
            !, 
            N = FileListTag - editor::filemenutagbase, 
            configuration::get_lru_list(FNLIST), 
            get_file(N, 0, FNLIST, Name), 
            editor::open_file(Name, b_true).
        eventHandler(_Win, e_Move(X, Y)) = Result :-
            !,
            handled(Result) = onMove(X, Y).
        eventHandler(Win, Event) = Result :-
            Result = generatedEventHandler(Win, Event).

    predicates
        onCreate : vpiDomains::createHandler.
    clauses
        onCreate(_CreationData) = defaultHandling() :-
            projectToolbar::create(thisWin), 
            statusLine::create(thisWin), 
            vpiEditor::setAssociations(
                [vpieditor::ass("pro", edit_ftype_pro), 
                vpieditor::ass("pie", edit_ftype_pro), 
                vpieditor::ass("pre", edit_ftype_pro), 
                vpieditor::ass("con", edit_ftype_pro), 
                vpieditor::ass("dom", edit_ftype_pro), 
                vpieditor::ass("inc", edit_ftype_pro)]), 
            goalWindow::create(MsgWin), 
            configuration::init_ui(thisWin, MsgWin), 
            configuration::get_open_editors_list(LRU), 
            open_editors(LRU), 
            vpi::winSetState(thisWin, [wsf_Visible]), 
            editor::show_menu_with_filelists(id_TaskMenu, NewMenu), 
            vpi::menuSet(thisWin, NewMenu), 
            system_status("Ready"), 
            configuration::get_start_error(Err), 
            engine::initpie(), 
            write(Err), nl, 
            write("Use OnlineHelp to see descriptions ..."), nl, 
            write("To load example files choose File\\Consult menu entry ..."), nl, 
            write("Type your predicate calls here like\nwrite(\"Hello world!\"). <- Set Caret here and press Enter\n").

    predicates
        onHelpAbout : vpiDomains::menuItemHandler.
    clauses
        onHelpAbout(_MenuTag) = handled(0) :-
            AboutDialog = aboutDialog::new(),
            AboutDialog:show(thisWin).

    predicates
        onFileExit : vpiDomains::menuItemHandler.
    clauses
        onFileExit(_MenuTag) = handled(0) :-
%            vpi::winPostEvent(thisWin, vpidomains::e_CloseRequest), 
            vpi::winDestroy(thisWin).

    predicates
        onSizeChanged : vpiDomains::sizeHandler.
    clauses
        onSizeChanged(_Width, _Height) = defaultHandling():-
            configuration::set_task_pos(thisWin), 
            vpiToolbar::resize(thisWin).

    predicates
        onMove : vpiDomains::moveHandler.
    clauses
        onMove(_X, _Y) = defaultHandling() :-
            configuration::set_task_pos(thisWin).

    predicates
        onHelpContents : vpiDomains::menuItemHandler.
    clauses
        onHelpContents(_MenuTag) = handled(0) :-
            vpi::showHelp("pie.hlp").


    predicates
        onHelpLocal : vpiDomains::menuItemHandler.
    clauses
        onHelpLocal(_MenuTag) = handled(0).

    predicates
        onCloseRequest : vpiDomains::closeRequestHandler.
    clauses
        onCloseRequest() = handled(0) :-
            goalWindow::aboutToClose(),
            configuration::save_cfg(),
            editor::close_editors(Close), 
            clean_the_application(Close), 
            destroy_goalWin(Close), 
            Close = b_False,
            !.
        onCloseRequest() = defaultHandling().

    class predicates 
        destroy_goalWin : (core::booleanInt Close) procedure anyflow.
    clauses
        destroy_goalWin(b_True) :- !, goalWindow::destroy().
        destroy_goalWin( _).
        

    predicates
        onFileNew : vpiDomains::menuItemHandler.
    clauses
        onFileNew(_MenuTag) = handled(0) :-
            next_filename(FileName), 
            editor::open_file(FileName, b_false),
            !.
        onFileNew(_MenuTag) = handled(0).

    predicates
        onFileOpen : vpiDomains::menuItemHandler.
    clauses
        onFileOpen(_MenuTag) = handled(0) :-
            configuration::get_src_dir(SavedDir), 
            FileName = vpiCommonDialogs::getFileName("*.pro", 
                                        ["Prolog files(*.pro)", "*.pro", 
                                            "PIE Files(*.pie)", "*.pie", 
                                            "All Files(*.*)", "*.*"], 
                                        "Open file", 
                                        [], 
                                        SavedDir, _), 
            configuration::set_src_dir(SavedDir), 
            editor::open_file(FileName, b_true), 
            !.
        onFileOpen(_MenuTag) = handled(0).

    predicates
        onFileConsult : vpiDomains::menuItemHandler.
    clauses
        onFileConsult(_MenuTag) = handled(0) :-
            configuration::get_src_dir(SavedDir), 
            FileName = vpiCommonDialogs::getFileName("*.pro", 
                                        ["Prolog files(*.pro)", "*.pro", 
                                            "PIE Files(*.pie)", "*.pie", 
                                            "All Files(*.*)", "*.*"], 
                                        "Open file", 
                                        [], 
                                        SavedDir, _), 
            configuration::set_src_dir(SavedDir), 
            editor::open_file(FileName, b_true), 
            Text = editor::getText(FileName),
             !,
            engine::recons_text(Text), 
            Status = string::format("Reconsult %s", FileName), 
            system_status(Status), 
            write("Consulted from: ", FileName), nl, 
            system_status("Ready").
        onFileConsult(_MenuTag) = handled(0).

    predicates
        onEngineReset : vpiDomains::menuItemHandler.
    clauses
        onEngineReset(_MenuTag) = handled(0) :-
            engine::reset_engine(),
            vpiCommonDialogs::note("The Inference Engine is reset."), 
            system_status("Ready").

    predicates
        onEnginePause : vpiDomains::menuItemHandler.
    clauses
        onEnginePause(_MenuTag) = handled(0) :-
            engine::is_system_paused(),
            !, 
            engine::pauseOff(), 
            write("Pause is Off"), nl, 
            system_status("Ready").
        onEnginePause(_MenuTag) = handled(0) :-
            engine::pauseOn(), 
            write("Pause is On"), nl, 
            system_status("Ready").


    predicates
        onEngineTraceCalls : vpiDomains::menuItemHandler.
    clauses
        onEngineTraceCalls(_MenuTag) = handled(0) :-
            engine::is_system_trace,
            !, 
            engine::traceOff(), 
            write("Trace is OFF"), nl, 
            system_status("Ready").
        onEngineTraceCalls(_MenuTag) = handled(0) :-
            engine::traceOn(), 
            write("Trace is On"), nl, 
            system_status("Ready").

    predicates
        onEngineStopExecution : vpiDomains::menuItemHandler.
    clauses
        onEngineStopExecution(_MenuTag) = handled(0) :-
            engine::break_execution(), 
            write("System stopped via user break\n").

    predicates
        onGetFocus : vpiDomains::getFocusHandler.
    clauses
        onGetFocus() = defaultHandling() :-
            vpiToolbar::mesRedirect(thisWin, thisWin).


    % This code is maintained by the VDE. Do not update it manually, 12:47:28-6.12.2002
    constants
        windowFlags : vpiDomains::wsflags = [wsf_SizeBorder,wsf_TitleBar,wsf_Close,wsf_Maximize,wsf_Minimize,wsf_ClipSiblings].
        menu : vpiDomains::menu = resMenu(id_TaskMenu).
        title : string = "Prolog Inference Engine".

    predicates
        generatedEventHandler : vpiDomains::ehandler.
    clauses
        generatedEventHandler(Win, e_create(_)) = _ :-
            thisWin := Win,
            projectToolbar::create(thisWin),
            statusLine::create(thisWin),
            fail.
        generatedEventHandler(_Win, e_Create(CreationData)) = Result :-
            handled(Result) = onCreate(CreationData).
        generatedEventHandler(_Win, e_Size(Width, Height)) = Result :-
            handled(Result) = onSizeChanged(Width, Height).
        generatedEventHandler(_Win, e_Menu(id_help_about, _)) = Result :-
            handled(Result) = onHelpAbout(id_help_about).
        generatedEventHandler(_Win, e_Menu(id_file_exit, _)) = Result :-
            handled(Result) = onFileExit(id_file_exit).
        generatedEventHandler(_Win, e_Menu(id_help_contents, _)) = Result :-
            handled(Result) = onHelpContents(id_help_contents).
        generatedEventHandler(_Win, e_Menu(id_help_local, _)) = Result :-
            handled(Result) = onHelpLocal(id_help_local).
        generatedEventHandler(_Win, e_Menu(id_file_new, _)) = Result :-
            handled(Result) = onFileNew(id_file_new).
        generatedEventHandler(_Win, e_Menu(id_file_open, _)) = Result :-
            handled(Result) = onFileOpen(id_file_open).
        generatedEventHandler(_Win, e_Menu(id_file_consult, _)) = Result :-
            handled(Result) = onFileConsult(id_file_consult).
        generatedEventHandler(_Win, e_Menu(id_engine_reset, _)) = Result :-
            handled(Result) = onEngineReset(id_engine_reset).
        generatedEventHandler(_Win, e_Menu(id_Engine_pause, _)) = Result :-
            handled(Result) = onEnginePause(id_Engine_pause).
        generatedEventHandler(_Win, e_Menu(id_Engine_trace_calls, _)) = Result :-
            handled(Result) = onEngineTraceCalls(id_Engine_trace_calls).
        generatedEventHandler(_Win, e_Menu(id_Engine_stop_execution, _)) = Result :-
            handled(Result) = onEngineStopExecution(id_Engine_stop_execution).
        generatedEventHandler(_Win, e_GetFocus()) = Result :-
            handled(Result) = onGetFocus().
        generatedEventHandler(_Win, e_CloseRequest()) = Result :-
            handled(Result) = onCloseRequest().
    % end of automatic code
end implement taskWindow
