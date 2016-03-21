%{
#include <stdio.h>
#include <string.h>
#include <malloc.h>
#include <ctype.h>

#include "mfcalc.h"
#include "mfcalc.tab.h"

extern	int	g_curdataoffset;
int lineno = 0;
%}

%%
"\n"					{ ++lineno; return yytext[0];}
[\t\f\v\r ]+				{ /* Ignore whitespace. */ }
"+"					{ return yytext[0]; }
"-"					{ return yytext[0]; }

[a-zA-Z_][a-zA-Z_0-9]*			{
												/* See if the symbol is already present
												*  in the symbol table. If it is , then it is
												*  either a variable already used earlier or
												*  a predefined function.
												*
												*  If it is not present, then it is a variable.
												*  Add the variable to the symbol table.
												*
												*
												*  Either case, return the type of the token
												*  as the return type from this action.
												*
												*  Also, return the value of the token(
												*  the string of the identifier or function )
												*  in the yylval shared variable.
												*
												*  yylval is a shared variable that is known
												*  to bison. We just use it here.
												*
												*  yylval is of type %union declared in
												*  the parser. This is in the file mfcalc.tab.h
												*  header file that is produced by the parser.
												*/
												symrec *s; 
												s = getsym(yytext);
												if ( NULL == s )
												{
													s = putsym(yytext,VAR);
													s->value.offset = g_curdataoffset;
													g_curdataoffset += 4;
												}

												yylval.tptr = s;

												return s->type;
												}

[0-9][0-9]* { yylval.val = atoi(yytext); return NUM; }

. { return yytext[0]; }

%%

