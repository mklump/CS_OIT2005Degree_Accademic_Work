%{
#include <stdio.h>
#include "prefix.tab.h"
int lineno = 0;
%}

%%
"\n"					{ ++lineno; return NEWLINE;}
[\t\f\v\r ]+				{ /* Ignore whitespace. */ }
"+"					{ return PLUS_OP; }
"-"					{ return MINUS_OP; }
"*"					{ return MULT_OP; }

[0-9][0-9]* { yylval = atoi(yytext); return NUM; }
. { return yytext[0]; }

%%


