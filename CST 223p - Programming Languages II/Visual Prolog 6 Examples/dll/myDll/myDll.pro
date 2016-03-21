/*****************************************************************************

		Copyright (c) Prolog Developement Center

 Written by: Visual Prolog
******************************************************************************/


implement myDll
    clauses
       touch(String) = string::concat(String, ", touched!").
end implement myDll
