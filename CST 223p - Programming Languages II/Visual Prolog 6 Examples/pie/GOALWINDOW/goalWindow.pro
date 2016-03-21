/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

        Message window but catches Return Key
******************************************************************************/

implement goalWindow
    open core

    constants
        className = "com/visual-prolog/goalWindow/goalWindow".
        version = "$JustDate: 20.12.02 $$Revision: 2 $".

    clauses
        classInfo(className, version).

class facts - my_msg_win
     oldhandler : (vpiDomains::ehandler)determ.

clauses
    create(MsgWin):-
        MsgWin = vpiMessage::create(1000, "Dialog"), 
        OldEhandler=vpi::winGetHandler(MsgWin), 
        assert(oldhandler(OldEhandler)), 
        vpi::winSetHandler(MsgWin, eventHandler).

class predicates 
    eventHandler : vpiDomains::ehandler.
clauses
    eventHandler(Win, vpidomains::e_Char(13, _)) = 0 :-
        vpiEditor::doLineHome( Win ), 
        StartPos=vpiEditor::getPos(Win), 
        vpiEditor::doLineEnd( Win ), 
        EndPos=vpiEditor::getPos(Win), 
        EndPos>StartPos, !, 
        Text=vpiEditor::getText(Win), 
        NBytes=EndPos-StartPos, 
        string5x::substring(Text, StartPos, NBytes, MyGoal), 
        EndPos1=EndPos-1, 
        string5x::frontstr(EndPos1, Text, NewText, _RestString), 
        vpiEditor::pasteStr(Win, NewText), file5x::nl, 
        try_run_goal(MyGoal).
    eventHandler(Win, vpidomains::e_Size(_, _)) = 0 :- 
        configuration::set_msg_pos(Win), 
        fail.
    eventHandler(Win, vpidomains::e_Move(_, _)) = 0 :- 
        configuration::set_msg_pos(Win), 
        fail.
    eventHandler(_Win, vpidomains::e_CloseRequest()) = 0 :-!.
    
    eventHandler(_, vpidomains::e_GetFocus) = 0 :-!, 
        Task=vpi::getTaskWindow(), 
        vpiToolbar::mesRedirect(Task, Task).
    eventHandler(Win, Event) = 0 :-
        oldhandler(OldEhandler), 
        _ = OldEHandler(Win, Event).

class predicates 
    try_run_goal : (string) procedure.
clauses
    try_run_goal(TheGoal) :-
        engine::is_system_paused, !, 
        string5x::format(Msg, "The system is paused, so the goal [%s] is rejected", TheGoal), 
        file5x::write(Msg), file5x::nl.
    try_run_goal(TheGoal) :-
        string5x::format(Status, "Run goal: %s", TheGoal), 
        taskWindow::system_status(Status), 
        engine::run(TheGoal), 
        taskWindow::system_status("Ready").

clauses
    aboutToClose() :-
        MesWin = vpiMessage::getWin(), 
        !,
        FONT = vpi::winGetFont(MesWin), 
        configuration::set_msg_font(FONT).
    aboutToClose().

clauses
    destroy() :-
        MesWin = vpiMessage::getWin(), 
        !,
        vpi::winDestroy(MesWin).
    destroy().
end implement goalWindow
