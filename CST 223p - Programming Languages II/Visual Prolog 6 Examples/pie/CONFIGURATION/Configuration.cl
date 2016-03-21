/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class configuration
    open core

    predicates
        classInfo : core::classInfo.
        % @short Class information  predicate. 
        % @detail This predicate represents information predicate of this class.
        % @end

predicates
    save_cfg : () procedure.
    load_cfg : () procedure.
    init_ui : (vpiDomains::windowHandle Task, vpiDomains::windowHandle Msg) procedure(i,i).
    get_msg_font : (vpiDomains::font) procedure(o).
    get_edit_font : (vpiDomains::font) procedure(o).
    set_msg_font : (vpiDomains::font) procedure(i).
    set_edit_font : (vpiDomains::font) procedure(i).
    set_msg_pos : (vpiDomains::windowHandle) procedure(i).
    set_task_pos : (vpiDomains::windowHandle) procedure(i).
    get_src_dir : (string) procedure(o).
    set_src_dir : (string) procedure(i).
    taskWindow_maximized : () determ ().
    get_lru_list : (core::string_list) procedure(o).
    set_lru_pos : (vpiDomains::windowHandle,string) procedure(i,i).
    get_lru_pos : (vpiDomains::windowHandle,string,vpiDomains::rct,core::unsigned32) procedure(i,i,o,o).
    get_open_editors_list : (core::string_list) procedure(o).
    retract_open_editor : (string) procedure(i).
    get_start_error : (string) procedure(o).
   
end class configuration