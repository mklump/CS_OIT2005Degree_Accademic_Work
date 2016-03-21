%{ /* Beginning of Definitions */

/*--------------------------------------------------------------------
// Author:        Matthew Klump  mklump1@comcast.net
//				  CST 320p Compiler Methods
// Date Created:  5 May 2003
// Submission Date:  9 May 2003
// Project:        CST320_Assign_3
// Filename:       CST320_Assign_3.Bison.c ( A Bison specification file )
//
//
// Overview:	Performs Semantic Analysis on a given source code file
//     	        as outlined in the language described by the Assignment 3
//				description.
//
// Input:       Any source code writen that is described by the language.
//
// Output:		Provides the value of a program described by the language.
//
//------------------------------------------------------------------*/

#include "Assign3.h"

int table_index = 0,	/* index into the struct variable table array */
	lineno = 1,			/* line number counter */
	bVar_Declared = 0,	/* true if a struct variable is declared */
	bCondition = 0;

%}

%union {
	int exp_type; /* simply a 32-bit integer */
	struct variable *var_rec;   /* value type of struct variables */
}

/*
 *	token declaration for keywords
 */
%token <exp_type> START
%token <exp_type> END
%token <exp_type> VAR
%token <exp_type> PRINT
%token <exp_type> READ
%token <exp_type> IF
%token <exp_type> THEN
%token <exp_type> ELSE
%token <exp_type> INTEGER

/*
 *	Associativity declarations
 */
%right ASSIGN_OP
%left LPAREN RPAREN
%left PLUS_OP MINUS_OP
%left MULT_OP DIVIDE_OP MODULO_OP

/*
 *	More token declarations
 */
%token <exp_type> PLUS_OP
%token <exp_type> MINUS_OP
%token <exp_type> MULT_OP
%token <exp_type> DIVIDE_OP
%token <exp_type> MODULO_OP
%token <exp_type> COLON
%token <exp_type> SEMI
%token <exp_type> COMMA
%token <exp_type> LPAREN
%token <exp_type> RPAREN
%type <exp_type> ASSIGN_OP

/*
 *	Type declaration for simple_exp and other non-terminal
 */
%token <var_rec> ID

%token <exp_type> NUMBER
%type <exp_type> TYPE
%type <exp_type> CONDITION

%type <exp_type> PROGRAM
%type <exp_type> program
%type <exp_type> simple_exp
%type <exp_type> var_decls
%type <exp_type> var_decl
%type <exp_type> exp
%type <exp_type> EXPRS
%type <exp_type> actual_param_list
%type <exp_type> actual_param
%type <exp_type> assign_statement

%%

program : PROGRAM { program_value = $1; }
;

PROGRAM : START END	{}
	| START EXPRS END { $$ = $2; }
	| START var_decls END {
		if( !bVar_Declared )
			program_value = $$ = 0;
		else
			program_value = $$ = $2;
	}
	| START var_decls EXPRS END { $$ = $3; }
	| START EXPRS var_decls END { $$ = $2; }
;
var_decls : var_decl	{}
	| var_decls var_decl {}
;
var_decl : VAR ID COLON TYPE SEMI {
		put_Var( varRetVal->name, varRetVal->value = 0 );
		bVar_Declared = 1;
	 }
;
EXPRS : exp			{ $$ = $1; }
	  | EXPRS exp	{ $$ = $1 = $2; }
;
exp : simple_exp SEMI	{ $$ = $1; }
	| assign_statement	{ $$ = $1; }
	| IF simple_exp THEN exp ELSE exp {
		int temp = $2;
		if( temp )
			$$ = vbltable[table_index - 1].value;
		else
			$$ = vbltable[table_index - 3].value;
	}
;
actual_param_list : actual_param	{}
	| actual_param_list COMMA actual_param {}
;
actual_param : simple_exp	{}
;
assign_statement : ID ASSIGN_OP exp	{
		 if( get_Var( varRetVal->name ) == NULL )
		 {
			 yyerror(strcat(strcat("Variable \"", varRetVal->name),
						 "\" must be declared before use.") );
		 }
		 else
			 get_Var( varRetVal->name )->value = $$ = $3;
	}
;
simple_exp : LPAREN simple_exp RPAREN   { $$ = ($2); }
   |  simple_exp PLUS_OP simple_exp		{ $$ = $1 + $3; }
   |  simple_exp MINUS_OP simple_exp	{ $$ = $1 - $3; }
   |  simple_exp MULT_OP simple_exp		{ $$ = $1 * $3; }
   |  simple_exp DIVIDE_OP simple_exp { 
				 if( $3 == 0 )
					 yyerror("Divide by zero exeption.");
				 else
					 $$ = $1 / $3;
			}
   |  simple_exp MODULO_OP simple_exp	{
				 if( $3 == 0 )
					 yyerror("Divide by zero exeption.");
				 else
					 $$ = $1 % $3;
				}
   |  PRINT LPAREN actual_param_list RPAREN {
					int temp = $3;
					if( bCondition )
					{
						printf("%d ", vbltable[table_index - 1].value);
						$$ = vbltable[table_index - 1].value;
					}
					else
					{
						printf("%d ", temp);
						$$ = $3;
					}
				}
   |  READ LPAREN RPAREN	{
					int temp;
					printf("\nPlease enter an integer :");
					scanf( "%d", &temp ); 
					$$ = temp;			 /*	Program tempararily blocks waiting for
										  *	input from the user
										  */
				}

   |  ID		{
					varRetVal = get_Var( varRetVal->name );
				    $$ = varRetVal->value;
				}

   |  NUMBER	{ $$ = varRetVal->value; }

   |  CONDITION { $$ = $1 }
;

CONDITION : LPAREN ID ASSIGN_OP NUMBER RPAREN {

		 if( get_Var( varRetVal->name ) == NULL )
		 {
			 yyerror(strcat(strcat("Variable \"", varRetVal->name),
						 "\" must be declared before use.") );
		 }
		 else
		 {
			 get_Var( varRetVal->name )->value = $$ = varRetVal->value;
			 bCondition = 1;
		 }
	}
;

TYPE : INTEGER	{}
;

%%

struct variable*
put_Var(const char *name, int value)
{
	struct variable *temp;

	for( temp = vbltable; temp < &vbltable[MAX_SIZE]; ++temp )
	{	/* Is the struct variable already defined? */
		if( temp->name && !strcmp( temp->name, name ) )
			return NULL;
	}
	strcpy(vbltable[table_index].name, name);
	vbltable[table_index].value = value;

	table_index++;
	
	if( table_index > MAX_SIZE )
	{
		yyerror("Too many struct variables defined");	/* Could not continue */
		return NULL;
	}
}

struct variable *
get_Var(const char *name)
{
	int i;
	for ( i = 0 ; i < table_index; ++i )
	{
		if ( strcmp(vbltable[i].name, name) == 0 )
			return &vbltable[i];
	}

	return NULL;
}

void
yyerror(const char *s)
{
	printf("\nyyerror produced an error:\n%s\nOn line: %d\n", s, lineno);
	exit(1);
}

int yywrap()
{
	return 1;
}