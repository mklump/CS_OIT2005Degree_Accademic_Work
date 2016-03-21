/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class goalWindow
    open core

    predicates
        classInfo : core::classInfo.
        % @short Class information  predicate. 
        % @detail This predicate represents information predicate of this class.
        % @end

    predicates
        create : (vpiDomains::windowHandle) procedure (o).
    predicates 
        aboutToClose : ().
    predicates
        destroy : ().
end class goalWindow