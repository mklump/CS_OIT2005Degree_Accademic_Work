/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class output
open core

predicates
    classInfo : core::classInfo.
    % @short Class information  predicate. 
    % @detail This predicate represents information predicate of this class.
    % @end

domains
  mode	= list(); write(); display().	% display mode for term writer
predicates
    wterm : (mode,engine::term) procedure.
    wsterm : (mode,parser::sterm) procedure.
end class output