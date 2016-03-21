/*****************************************************************************

                        Copyright (c) Prolog Development Center A/S

******************************************************************************/

class scanner
open core

predicates
    classInfo : core::classInfo.
    % @short Class information  predicate. 
    % @detail This predicate represents information predicate of this class.
    % @end

domains
  tok = lbrack; rbrack; lpar; rpar; lcurly; rcurly;
		  var(string);	  atom(string);
		  int(integer); str(string); char(char);
		  comma; bar; dot.

domains
  cursortok	= t(tok,cursor_position).
  cursor_position	= integer.
  tokl		= cursortok*.

predicates
    tokl : (cursor_POSITION,string,tokl) determ(i,i,o).

end class scanner