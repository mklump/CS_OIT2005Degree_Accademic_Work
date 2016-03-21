%{
#include <stdio.h>
#include <string.h>
#include <malloc.h>
#include <ctype.h>
#include "mfcalc.h"

extern FILE *yyin;
extern FILE *g_ILOutFile;

%}

/* Specifies the type of a token.
*   A token is either an integer(for constants)
*   or a pointer to a symbol table.
*
*	for the NT exp type, the type is 
*	a register in which the expression value
*	is computed.
*
*/
%union {
int val;
int	exp_reg;
symrec *tptr;
}

%token<val>	NUM	/* integer */
%token<tptr> VAR FUNC /* token types . pointer to symbol tables */

%type<exp_reg> exp /* expression. only an integer */

%right '=' /* right associative */
%left '*' '/'
%left '-' '+' /* left associative */
%left NEG
%token INPUT_FUNCTION "read"

%%

inp : /* empty file */
    | inp line	{ }
;

line:
	'\n'
	| exp '\n' { }
;

exp : NUM { 
					//$$ = $1; 
						$$ = produce_code_for_constant(
									g_ILOutFile,
									$1
									);
				}
	| VAR { 
					//$$ = $1->value.offset;
					$$ = produce_code_for_var(
									g_ILOutFile,
									$1
									);
			 }
	| VAR '=' exp {
								//$1->value.offset = $3; 
								//$$ = $1->value.offset; 
								$$ = produce_code_for_assignment(
												g_ILOutFile,
												$1,
												$3
												);
						}

	| FUNC '(' exp ')' { 
					/* when the code contains a call to add() , sub() or print()
					*/

					$$ = produce_code_for_func_call(
												g_ILOutFile,
												$1, 
												$3);
					}

	| INPUT_FUNCTION '('')'{ 

					$$ = produce_code_for_read_call(g_ILOutFile);
				} /* when the input code contains read() */
	| exp '+' exp {
					$$ = produce_code_for_op(
										g_ILOutFile,
										$1, 
										$3, 
										1);
					//$$ = $1 + $3; 
					}
	| exp '-' exp {
					$$ = produce_code_for_op(
										g_ILOutFile,
										$1, 
										$3, 
										2);

					// $$ = $1- $3; 
					}
	| '(' exp ')' { 
					$$ = produce_code_for_paren(
										g_ILOutFile,
										$2);
					//$$ = $2; 
					}
;

%%
extern FILE *g_ILOutFile;
int main(int argc, char *argv[])
{

   if ( argc != 3 )
   {
	printf("%s [file to compile] [name of file for IL code]\n",argv[0]);
	return 1;
	}
	else
	{
	   yyin = fopen(argv[1],"r");

	   if ( NULL == yyin)
	   {
		printf("%s [file to compile->%s . unable to open]\n",argv[0],argv[1]);
		 return 1;
		}

		g_ILOutFile = fopen(argv[2], "w");

		if( NULL == g_ILOutFile )
		{
			printf("%s [ output file -> %s. unable to open for writing]\n",
			argv[0], argv[2]);
			return 1;
		}
	}

	init_cpu();

	init_table();



	   yyparse();

	   produce_return_from_start(
							g_ILOutFile
							);
	   return 0;
}