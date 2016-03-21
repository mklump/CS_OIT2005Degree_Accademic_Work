/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement configuration
    open core, vpiDomains
    resolve getSystemDirectory externally

    constants
        className = "com/visual-prolog/configuration/configuration".
        version = "$JustDate: 11.01.03 $$Revision: 3 $".

    clauses
        classInfo(className, version).

constants
    config_file_name : string = "pie32.ini".

class predicates
   getSystemDirectory : (string LpszSysPath,unsigned CbSysPath) -> unsigned 
                   procedure (i,i) language apicall as "GetSystemDirectory".

class facts - start_error
    start_error : (string) determ.

class facts - config
    src_dir : (string) determ.
    msg_font : (vpiDomains::font) determ.
    msg_pos :  (vpiDomains::rct) determ.
    edit_font : (vpiDomains::font) determ.
    edit_opts : (core::integer_list) determ.
    task_pos : (vpiDomains::rct) determ.
    task_max : (integer) determ.
   lru_file_pos : (string, vpiDomains::rct).
   open_editors : (string Filename, vpiDomains::rct, core::unsigned32 Pos).
/***************************************************************************
        Locate the windows directory
***************************************************************************/

class predicates 
   is_WindowMaximized : (vpiDomains::windowHandle, integer) procedure(i,o).
  save_init_file : (string) procedure anyflow.
  getsysdir : (string Path) procedure anyflow.
  errorMessagePrompt : (string) procedure anyflow.
  consult_systemINIfile : (string FILENAME) procedure anyflow.
  load_defaults : () procedure anyflow.
  resize_Task : (vpiDomains::windowHandle) procedure anyflow.
  resize_Msg :  (vpiDomains::windowHandle) procedure anyflow.
  get_win_restore_rct : (vpiDomains::windowHandle,vpiDomains::rct) procedure anyflow.
clauses

  getsysdir(Path):-
        BufLen = 1000,
        string5x::str_len(Path,BufLen),
        _ = getSystemDirectory(Path,BufLen).

  save_cfg():-
        getsysdir(WinPath),
        file5x::filenamepath(FullName,WinPATH,config_file_name),
        save_init_file(FullName),!.
  save_cfg():-!.

  save_init_file(FullName):-
        trap(file5x::save(FullName,config),_,fail),
        !,
        file5x::writef("\nFile % saved",config_file_name).
  save_init_file(_):-
        file5x::write("\nCan't save file ",config_file_name).

  consult_systemINIfile(FILENAME):-
        file5x::existfile(FILENAME),
        string5x::format(MSG,"Can not load %s. Ignored and defaults been set.",FILENAME),
        trap(file5x::consult(FILENAME,config),_,(errorMessagePrompt(MSG), fail)),!.
  consult_systemINIfile(FILENAME):-
        string5x::format(MSG,"There is no %s file. Defaults been set.",FILENAME),
        errorMessagePrompt(MSG),!.
  consult_systemINIfile(_):-!,
        load_defaults.

  load_cfg():-
        getsysdir(WinPath),
        file5x::filenamepath(FILENAME,WinPATH,config_file_name),
        consult_systemINIfile(FILENAME).

  errorMessagePrompt (Err) :-
        retractall (_,start_error),
        assert (start_error(Err)).
        
  get_start_error (Err) :-
        start_error (Err),!.
  get_start_error ("Ready").
        
  load_defaults() :-
        retractall (_,config),
        assert(src_dir("")).
   %
   %  Particular options settings
   % 
   get_msg_font (FONT) :- msg_font (FONT),!.
   get_msg_font (FONT) :- FONT=vpi::fontCreate (ff_System,[],10).
   
   set_msg_font (FONT) :-
        retractall (msg_font(_)),
        assert (msg_font(FONT)).

   get_edit_font (FONT) :- edit_font (FONT),!.
   get_edit_font (FONT) :- FONT=vpi::fontCreate (ff_Fixed,[],10).
   
   set_edit_font (FONT) :-
        retractall (edit_font(_)),
        assert (edit_font(FONT)).
        
   init_ui (TaskWin, MsgWin) :-
        resize_Task (TaskWin),
        resize_Msg  (MsgWin),
        get_msg_font (MFONT),
        get_edit_font (EFONT),
        set_msg_font (MFONT),
        set_edit_font (EFONT),
        vpi::winSetFont (MsgWin,MFONT),!.
   init_ui (_,_).
        
   resize_Task (Win) :-
        is_WindowMaximized (Win,Max),
        Max = b_True,!.
   resize_Task (Win) :-
        task_pos(RCT),!,
        vpi::winMove(Win,RCT).
   resize_Task (Win) :-
        set_task_pos (Win).
        
   set_task_pos (Win) :-
        RCT=vpi::winGetOuterRect(Win),
        WSF=[wsf_SizeBorder,wsf_TitleBar],
        RCT1=vpi::rectGetClient (WSF,b_True,RCT),
        retractall (task_pos(_)),
        assert(task_pos(RCT1)),
        is_WindowMaximized (Win,Max),
        retractall (task_max(_)),
        assert (task_max(Max)).
           
   resize_Msg (Win) :-
        msg_pos(RCT),!,
        vpi::winMove(Win,RCT).
   resize_Msg (Win) :-
        set_msg_pos (Win).
        
   set_msg_pos (Win) :-
        get_win_restore_rct (Win,RCT),
        retractall (msg_pos(_)),
        assert(msg_pos(RCT)).
        
   get_src_dir (Dir) :- src_dir (Dir),!.
   get_src_dir ("").
   
   set_src_dir (FN) :-
        file5x::filenamepath (FN,Dir,_),
        retractall (src_dir(_)),
        assert (src_dir(Dir)).


   taskWindow_maximized() :-        
        task_max (1).

  set_lru_pos (WIN,FN) :-
        retractall (lru_file_pos(FN,_)),
        retractall (open_editors(FN,_,_)),
        get_win_restore_rct (WIN,RCT),
        Pos=vpiEditor::getPos (WIN),
        asserta(lru_file_pos(FN,RCT)),
        asserta(open_editors(FN,RCT,Pos)),!.
  set_lru_pos (WIN,FN) :-
        retractall (lru_file_pos(FN,_)),
        retractall (open_editors(FN,_,_)),
        get_win_restore_rct (WIN,RCT),
        asserta(lru_file_pos(FN,RCT)),
        asserta(open_editors(FN,RCT,1)).
        
  get_lru_list (LRU) :-
        findall (FN,lru_file_pos(FN,_),LRU).
 
  get_lru_pos (_,FN,RCT,POS) :-
        open_editors (FN,RCT,POS),!.
  get_lru_pos (_,FN,RCT,1) :-
        lru_file_pos (FN,RCT),!.
  get_lru_pos (WIN,_FN,RCT,1) :-
        CRCT = vpi::winGetClientRect(WIN),
        CRCT = vpidomains::rct(L,T,R,B),
        L1 = L + 50,
        T1 = T + 50,
        R1 = 2*R div 3,
        B1 = 2*B div 3,
        RCT = vpidomains::rct (L1,T1,R1,B1).
        
  get_open_editors_list (LRU) :-
        findall (FN,open_editors(FN,_,_),LRU).
        
  retract_open_editor (FN) :-
        retractall (open_editors(FN,_,_)).

  get_win_restore_rct(W,RCT):-
        OuterRCT=vpi::winGetOuterRect(W),
        RCT = vpi::rectGetClient ([wsf_SizeBorder,wsf_TitleBar],b_False,OuterRCT).

  is_WindowMaximized (Win,1) :-
        F = vpi::winGetState (Win),
        member(wsf_Maximized,F),
        !.
  is_WindowMaximized (_,0).
   
class predicates
    member : (vpiDomains::wsflag,vpiDomains::wsflags) determ (i,i).
clauses
    member(H,[H|_]) :- !.
    member(X,[_|T]) :- member(X,T).
  
end implement configuration
