/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class operator
    open core

    predicates
        classInfo : core::classInfo.
        % @short Class information  predicate. 
        % @detail This predicate represents information predicate of this class.
        % @end

    domains
        op = string.	% storing of operators
        xfy = string.	% xfy; yfx; xfx; yfy; fx; fy; xf; yf
        prior = integer.	% priority of operators
    predicates
          getop : (prior,xfy,op)determ (o,o,i) (i,o,i).

    predicates
          getop_nd : (prior,xfy,op)nondeterm (o,o,o).

    predicates
          setop : (prior,xfy,op)procedure.
end class operator