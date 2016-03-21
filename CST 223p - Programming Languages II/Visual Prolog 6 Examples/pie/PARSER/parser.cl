/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class parser
open core

predicates
    classInfo : core::classInfo.
    % @short Class information  predicate. 
    % @detail This predicate represents information predicate of this class.
    % @end

domains
    sterml = sterm*.
    sterm  = 
        var(string);
	cmp(symbol,sterml);
	list(sterm,sterm);
	nill;
	atom(symbol);
	int(integer);
	str(string);
	char(char).


predicates
    s_term : (scanner::tokl,scanner::tokl,sterm) determ(i,o,o).
end class parser