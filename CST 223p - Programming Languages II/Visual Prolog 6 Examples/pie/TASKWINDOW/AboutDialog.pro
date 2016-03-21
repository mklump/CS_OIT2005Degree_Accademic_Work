/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement aboutDialog
    open core, vpiDomains, resourceIdentifiers

    constants
        className = "com/visual-prolog/TaskWindow/aboutDialog".
        version = "$JustDate: 20.12.02 $$Revision: 2 $".

    clauses
        classInfo(className, version).

    facts
        thisWin : vpiDomains::windowHandle := uncheckedConvert(vpiDomains::windowHandle, 0).
            
    clauses
        show(Parent):-
            _ = vpi::winCreateDynDialog(Parent, controlList, eventHandler, 0).

    predicates
        eventHandler : vpiDomains::ehandler.
    clauses
        eventHandler(Win, Event) = Result :-
            Result = generatedEventHandler(Win, Event).

    predicates
        onCreate : vpiDomains::createHandler.
    clauses
        onCreate(_CreationData) = defaultHandling() :-
            TWH = vpi::wingetctlhandle(thisWin,idc_dlg_about_st_prj),
            Font = vpi::winGetFont(TWH),
            Font1 = vpi::fontsetattrs(Font,[fs_Bold],dialogFontSize+4),
            vpi::winSetFont(TWH, Font1).
            
            
            
                        
    predicates
        onControlOK : vpiDomains::controlHandler.
    clauses
        onControlOK(_Ctrl, _CtrlType, _CtrlWin, _CtrlInfo) = handled(0) :-
            vpi::winDestroy(thisWin).
                        
    predicates
        onControlCancel : vpiDomains::controlHandler.
    clauses
        onControlCancel(_Ctrl, _CtrlType, _CtrlWin, _CtrlInfo) = handled(0) :-
            vpi::winDestroy(thisWin).

    % This code is maintained by the VDE. Do not update it manually, 22:23:26-3.12.2002
    constants
        dialogType : vpiDomains::wintype = wd_Modal.
        title : string = "About".
        rectangle : vpiDomains::rct = rct(122,26,336,176).
        dialogFlags : vpiDomains::wsflags = [wsf_Close,wsf_TitleBar].
        dialogFont = "MS Sans Serif".
        dialogFontSize = 8.

    constants
        controlList : vpiDomains::windef_list =
            [
            dlgFont(wdef(dialogType, rectangle, title, u_DlgBase),
                    dialogFont, dialogFontSize, dialogFlags),
            ctl(wdef(wc_PushButton,rct(10,95,46,110),"OK",u_DlgBase),idc_ok,[wsf_Default,wsf_Group,wsf_TabStop]),
            ctl(wdef(wc_Text,rct(65,15,195,30),"Prolog Inference Engine",u_DlgBase),idc_dlg_about_st_prj,[wsf_AlignCenter]),
            ctl(wdef(wc_Text,rct(65,35,195,55),"Copyright (c) 1984 - 2000 Prolog Development Center A/S",u_DlgBase),idc_dlg_about_st_copy,[wsf_AlignCenter]),
            ctl(wdef(wc_Text,rct(65,90,195,110),"Some portion of code is ported to VPI by Serguei Penkov",u_DlgBase),idc_dlg_about_st_firm,[wsf_AlignCenter]),
            ctl(wdef(wc_Text,rct(65,110,195,120),"Australia, (+612) 9314 3360",u_DlgBase),idc_about_dialog_4,[wsf_AlignCenter]),
            ctl(wdef(wc_Text,rct(65,120,195,130),"spenkov@ozemail.com.au",u_DlgBase),idc_about_dialog_8,[wsf_AlignCenter]),
            icon(wdef(wc_Icon,rct(20,20,36,36),"",u_DlgBase),project_icon,application_icon,[]),
            ctl(wdef(wc_Text,rct(65,55,195,65),"Copenhagen, Denmark",u_DlgBase),idct_hjholstvej,[wsf_AlignCenter]),
            ctl(wdef(wc_Text,rct(65,65,195,75),"sales@visual-prolog.com",u_DlgBase),idct_internet_email,[wsf_AlignCenter]),
            ctl(wdef(wc_Text,rct(65,75,195,85),"http://www.visual-prolog.com",u_DlgBase),idct_web_httpwwwpdcdk,[wsf_AlignCenter]),
            ctl(wdef(wc_GroupBox,rct(55,5,205,135),"",u_DlgBase),idc_about_dialog_1,[])
            ].

    predicates
        generatedEventHandler : vpiDomains::ehandler.
    clauses
        generatedEventHandler(Win, e_create(_)) = _ :-
            thisWin := Win,
            fail.
        generatedEventHandler(_Win, e_Create(CreationData)) = Result :-
            handled(Result) = onCreate(CreationData).
        generatedEventHandler(_Win, e_Control(idc_ok, CtrlType, CtrlWin, CtlInfo)) = Result :-
            handled(Result) = onControlOk(idc_ok, CtrlType, CtrlWin, CtlInfo).
    % end of automatic code
end implement aboutDialog
