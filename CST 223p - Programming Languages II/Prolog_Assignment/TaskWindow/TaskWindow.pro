/*****************************************************************************

                        Copyright (c) 

******************************************************************************/

implement taskWindow
    open core, vpiDomains, resourceIdentifiers

    constants
        className = "TaskWindow/taskWindow".
        classVersion = "".

    clauses
        classInfo(className, classVersion).

    facts
        thisWin : vpiDomains::windowHandle := uncheckedConvert(vpiDomains::windowHandle, 0).

    constants
        mdiProperty : integer = core::b_true.
    clauses
        show():-
            vpi::setAttrVal(attr_win_mdi, mdiProperty),
            vpi::setErrorHandler(vpi::dumpErrorHandler),
            vpi::init(windowFlags, eventHandler, menu, "", title).

    predicates
        eventHandler : vpiDomains::ehandler.
    clauses
        eventHandler(Win, Event) = Result :-
            Result = generatedEventHandler(Win, Event).

    constants
        maxMessageLines : integer = 100.
    predicates
        onCreate : vpiDomains::createHandler.
    clauses
        onCreate(_CreationData) = defaultHandling() :-
            _ = vpiMessage::create(maxMessageLines).

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
            vpi::winDestroy(thisWin).

    predicates
        onSizeChanged : vpiDomains::sizeHandler.
    clauses
        onSizeChanged(_Width, _Height) = defaultHandling():-
            vpiToolbar::resize(thisWin),
            vpiMessage::resize(thisWin).

    % This code is maintained by the VDE. Do not update it manually, 13:00:24-10.6.2003
    constants
        windowFlags : vpiDomains::wsflags = [wsf_SizeBorder,wsf_TitleBar,wsf_Close,wsf_Maximize,wsf_Minimize,wsf_ClipSiblings].
        menu : vpiDomains::menu = resMenu(id_TaskMenu).
        title : string = "Prolog_Assignment".

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
    % end of automatic code
end implement taskWindow
