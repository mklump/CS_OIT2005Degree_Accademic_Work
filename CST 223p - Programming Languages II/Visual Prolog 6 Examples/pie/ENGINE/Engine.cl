/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class engine
open core

predicates
    classInfo : core::classInfo.
    % @short Class information  predicate. 
    % @detail This predicate represents information predicate of this class.
    % @end

domains
    refint = reference integer.
    refsymb = reference string.
    refstr = reference string.
    refchar = reference char.
    vid = reference string.

domains
    terml = reference term*.
    term  = reference
        var(vid);
        cmp(refsymb,terml);
        list(term,term);
        nill;
        atom(refsymb);
        int(refint);
        str(refstr);
        char(refchar).

predicates
    initPIE : () procedure.
    run : (string) procedure(i).
    traceOn : () procedure ().
    traceOff : () procedure ().
    pauseOn : () procedure ().
    pauseOff : () procedure ().
    get_clause_list : (core::string_list) procedure(o).
    reset_engine : () procedure.
    is_system_trace : () determ.
    is_system_paused : () determ.
    recons_text : (string) procedure(i).
    break_execution : () procedure.
    resume_execution : () procedure.
    std_clause : (string,string) multi (o,o) determ (i,o).
end class engine