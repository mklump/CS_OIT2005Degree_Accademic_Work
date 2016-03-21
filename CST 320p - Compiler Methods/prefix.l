%{
#include <stdio.h>
#include "infix.tab.h"
int lineno = 0;
%}

%%
"\n"					{ ++lineno; return NEWLINE;}
[\t\f\v\r ]+				{ /* Ignore whitespace. */ }
"+"					{ return PLUS_OP; }
"-"					{ return MINUS_OP; }
"*"					{ return MULT_OP; }
"("					{ return LEFT_PAREN; }
")"					{	return RIGHT_PAREN; }

[0-9][0-9]* { yylval = atoi(yytext); return NUM; }
. { return yytext[0]; }

%%


