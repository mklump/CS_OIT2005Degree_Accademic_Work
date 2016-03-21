/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class statusLine
    open core

    predicates
        classInfo : core::classInfo.
        % @short Class information  predicate. 
        % @detail This predicate represents information predicate of this class.
        % @end

    predicates
        create : (vpiDomains::windowHandle Parent) procedure (i).
end class statusLine