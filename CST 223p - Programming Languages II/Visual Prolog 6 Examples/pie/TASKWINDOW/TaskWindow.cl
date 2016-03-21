/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class taskWindow : taskWindow
    open core

    predicates
        classInfo : core::classInfo.
        % @short Class information  predicate. 
        % @detail This predicate represents information predicate of this class.
        % @end

    predicates
        system_status : (string) procedure.

end class taskWindow