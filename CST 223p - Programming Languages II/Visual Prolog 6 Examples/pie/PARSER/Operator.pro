/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

implement operator
    open core

    constants
        className = "com/visual-prolog/Parser/operator".
        version = "$JustDate: 20.12.02 $$Revision: 2 $".

    clauses
        classInfo(className, version).

class facts - operators
        op : (prior,xfy,op).
    	
    clauses
        op(1200,"xfx",":-").
        op(1100,"xfy",";").
        op(1000,"xfy",",").
        op(900,"fy","not").
    
        op(700,"xfx","=").
        op(700,"xfx","\\=").
        op(700,"xfx","is").
        op(700,"xfx","<").
        op(700,"xfx","=<").
        op(700,"xfx",">").
        op(700,"xfx",">=").
        op(700,"xfx","==").
        op(700,"xfx","\\==").
        op(700,"xfx","=..").
        op(700,"xfx","<>").
        op(700,"xfx","><").
      
        op(500,"yfx","+").
        op(500,"yfx","-").
      
        op(400,"yfx","*").
        op(400,"yfx","/").
        op(400,"yfx","div").
      
        op(300,"xfx","mod").
      
        op(200,"fx","+").
        op(200,"fx","-").

    clauses
        getOp(PRIOR,XFY,OP) :- op(PRIOR,XFY,OP), !.

    clauses
        getOp_nd(PRIOR,XFY,OP) :- op(PRIOR,XFY,OP).

    clauses
        setOp(PRIOR,XFY,OP) :-
            retractall(op(_,_,OP)),
            assert(op(PRIOR,XFY,OP)).
end implement operator
