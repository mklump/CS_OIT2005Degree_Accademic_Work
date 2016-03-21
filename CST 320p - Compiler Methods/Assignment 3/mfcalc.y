%{
#include <stdio.h>
#include "mfcalc.h"

extern FILE *yyin;
%}

/* Specifies the type of a token.
*   A token is either an integer(for constants)
*   or a pointer to a symbol table.
*
*/
%union {
int val;
symrec *tptr;
}

%token<val>	NUM	/* integer */
%token<tptr> VAR FUNC /* token types . pointer to symbol tables */
%type<val> exp /* expression. only an integer */

%right '=' /* right associative */
%left '*' '/'
%left '-' '+' /* left associative */
%left NEG
%token INPUT_FUNCTION "read"

%%

inp : /* empty */
    | inp line
;

line:
	'\n'
	| exp '\n' { }
;

exp : NUM { $$ = $1; }
	| VAR { $$ = $1->value.var; }
	| VAR '=' exp { $1->value.var = $3; $$ = $1->value.var; }
	| FUNC '(' exp ')' { $$ = exec_function($1, $3); } /* when the code contains add(x) or add(y) */
	| INPUT_FUNCTION '('')'{ $$ = read_int(); } /* when the input code contains read() */
	| exp '+' exp { $$ = $1 + $3; }
	| exp '-' exp { $$ = $1 - $3; }
	| exp '*' exp { $$ = $1 * $3; }
	| '(' exp ')' { $$ = $2; }
;

%%
int main(int argc, char *argv[])
{
   init_table();

   yyin = fopen(argv[1],"r");

   if ( NULL == yyin)
   return 0;

   yyparse();
   return 0;
   }

void yyerror(const char *s)
{
printf("%s\n",s);
}