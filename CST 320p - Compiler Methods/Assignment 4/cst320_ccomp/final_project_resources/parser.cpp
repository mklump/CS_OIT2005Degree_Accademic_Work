/*	$Id: parser.y,v 1.4 1997/11/23 12:52:22 sandro Exp $	*/

/*
 * Copyright (c) 1997 Sandro Sigala <ssigala@globalnet.it>.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

/*
 * ISO C parser.
 *
 * Based on the ISO C 9899:1990 international standard.
 */

%{
#include <stdio.h>
#include	<assert.h>
#include	<malloc.h>
#include	<string.h>


extern int lineno;

static void yyerror(const char *s);

#include "cst320_stack.h"
#include "code_gen.h"
#include "cond_stack.h"
#include	"var_decl.h"
#include	"func_decl.h"

#define YYDEBUG 1

int			g_globalLevel = 1;

int			func_def_stack;

symtableQ_t	*g_SymbolTable = NULL;

FILE			*g_outFile;



/* If in a function, g_curFunction points to 
*   the entry in the main symbol table.
*
*/
symtableentry_t		*g_curFunction = NULL;
%}

%token IDENTIFIER TYPEDEF_NAME  FLOATING CHARACTER STRING

%token ELLIPSIS ADDEQ SUBEQ MULEQ DIVEQ MODEQ XOREQ ANDEQ OREQ SL SR
%token SLEQ SREQ EQ NOTEQ LTEQ GTEQ ANDAND OROR PLUSPLUS MINUSMINUS ARROW

%token AUTO BREAK CASE CHAR CONST CONTINUE DEFAULT DO DOUBLE ELSE ENUM
%token EXTERN FLOAT FOR GOTO IF INT LONG REGISTER RETURN SHORT SIGNED SIZEOF
%token WHILE VOID

%start translation_unit

%union {
	symtableentry_t	*pEntry;

	int			  decl_type;
}

%token<pEntry>	IDENTIFIER
%token<pEntry>	INTEGER
%type<pEntry>	identifier	direct_declarator	declarator	init_declarator	init_declarator_list
%token<pEntry>	CHARACTER
%type<pEntry>	primary_expression	expression assignment_expression argument_expression_list
%type<pEntry>	unary_expression postfix_expression cast_expression multiplicative_expression
%type<pEntry>	additive_expression shift_expression relational_expression equality_expression
%type<pEntry>	and_expression exclusive_or_expression inclusive_or_expression
%type<pEntry>	logical_and_expression logical_or_expression conditional_expression constant_expression
%type<pEntry>	func_declaration_start 

%token<decl_type>	INT	CHAR	VOID
%type<decl_type>	type_specifier
%type<decl_type>	declaration_specifiers

%%

/* B.2.1 Expressions. */

primary_expression:
	identifier	{ $$ = $1; }
											
	| INTEGER	{ $$ = generate_code_for_const_int(
											g_outFile,
											$1->ident_ptr.ident_info.const_int
											);
											}
	| CHARACTER
	| '(' expression ')'	{ $$ = $2; }
	;

identifier:
	IDENTIFIER {
		$$ = yylval.pEntry;
	}
	;

postfix_expression:
	primary_expression { $$ = $1; }
	| postfix_expression '[' expression ']'	{ assert(0); $$ = $1;}
	| postfix_expression '(' argument_expression_list ')' { 

						$$ = produce_code_for_function_call(
																		g_outFile,
																		$1,
																		$3
																		);
						
	 }
	| postfix_expression '(' ')' { 
						$$ = produce_code_for_function_call(
																		g_outFile,
																		$1,
																		NULL
																		);
	}
	;

argument_expression_list:
	assignment_expression { 
			symtableentry_t	*pActualParamSpaceInfo;

			pActualParamSpaceInfo = 
			create_symbol_table_entry();

			pActualParamSpaceInfo->ident_ptr.ident_type = 
					IDENT_DEF_FUNCTION_CALL;

			pActualParamSpaceInfo->ident_ptr.ident_info.actual_param_stack =
					initialize_act_param_stack();

			push_act_parameter(
							pActualParamSpaceInfo->ident_ptr.ident_info.actual_param_stack,
							$1
							);

			$$ = pActualParamSpaceInfo;
	}
	| argument_expression_list ',' assignment_expression {
					
			push_act_parameter(
				$1->ident_ptr.ident_info.actual_param_stack,
				$3
				);

				$$  = $1;
	}
	;

unary_expression:
	postfix_expression { $$ = $1; }
	;

unary_operator:
	| '+'	{ assert(0); }
	| '-'	{ assert(0);}
	| '!'	{ assert(0); }
	;

cast_expression:
	unary_expression { $$ = $1; }
	| '(' type_name ')' cast_expression { $$ = $4;}
	;

multiplicative_expression:
	cast_expression
	| multiplicative_expression '*' cast_expression { assert(0); }
	| multiplicative_expression '/' cast_expression { assert(0); }
	;

additive_expression:
	multiplicative_expression
	| additive_expression '+' multiplicative_expression {

			$$ = generate_code_add_op(
								g_outFile,
								$1,
								$3
								);
					
	}
	| additive_expression '-' multiplicative_expression { assert(0); }
	;

shift_expression:
	additive_expression
	;

relational_expression:
	shift_expression
	| relational_expression '<' shift_expression {
				$$ = generate_code_for_lt_op(
											g_outFile,
											$1,
											$3
											);
	}
	| relational_expression '>' shift_expression { assert(0); }
	| relational_expression LTEQ shift_expression { assert(0); }
	| relational_expression GTEQ shift_expression { assert(0); }
	;

equality_expression:
	relational_expression
	| equality_expression EQ relational_expression { assert(0); }
		/* evaluate */
	| equality_expression NOTEQ relational_expression { assert(0); }
	;

and_expression:
	equality_expression
	| and_expression '&' equality_expression
	;

exclusive_or_expression:
	and_expression
	| exclusive_or_expression '^' and_expression
	;

inclusive_or_expression:
	exclusive_or_expression
	| inclusive_or_expression '|' exclusive_or_expression
	;

logical_and_expression:
	inclusive_or_expression
	| logical_and_expression ANDAND inclusive_or_expression
	;

logical_or_expression:
	logical_and_expression
	| logical_or_expression OROR logical_and_expression
	;

conditional_expression:
	logical_or_expression
	| logical_or_expression '?' expression ':' conditional_expression
	;

assignment_expression:
	conditional_expression { 
											printf("conditional expression source line%d\n", lineno);
											$$ = $1; 
	}
	| unary_expression assignment_operator assignment_expression { 
			printf("assignment operator. source line %d\n", lineno);

			$$ = process_assignment(
									g_outFile,
									$1,
									$3
									);
	}
	;

assignment_operator:
	'='
	| MULEQ
	| DIVEQ
	| MODEQ
	| ADDEQ
	| SUBEQ
	| SLEQ
	| SREQ
	| ANDEQ
	| XOREQ
	| OREQ
	;

expression:
	assignment_expression { $$ = $1; }
	| expression ',' assignment_expression { }
	;

constant_expression:
	conditional_expression
	;

declaration:
	declaration_specifiers init_declarator_list ';' {
				
				if ( IDENT_DEF_VARIABLE == $2->ident_ptr.ident_type  )
				{
					if ( isFuncDefStackEmpty(func_def_stack) == 0 )
					{
						symtableentry_t	*pFuncDef;
						printf("[%d] sourcel line#[%d] process local variable definition[%s]\n", 
						__LINE__,lineno, $2->id_name);

						get_top_function(
												func_def_stack,
												&pFuncDef
												);

						insert_symbol(
										pFuncDef->ident_ptr.ident_info.func.pFuncSymbolTable,
										$2
										);

						process_local_var_definition(
												g_outFile,
												$1,
												$2,
												pFuncDef
												);
					}
					else
					{
						printf("[%d] source line#[%d] process local variable definition[%s]\n", 
						__LINE__, lineno, $2->id_name);

						insert_symbol(
										g_SymbolTable,
										$2
										);

						process_global_var_definition(
												$1,
												$2
												);
					}
				}
	}
	| declaration_specifiers ';' { }
	;

declaration_specifiers:
	type_specifier declaration_specifiers { $$ = $1; assert(0); }
	| type_specifier { $$ = $1; }
	| type_qualifier declaration_specifiers { assert(0); }
	| type_qualifier { assert(0); }
	;

init_declarator_list:
	init_declarator
	| init_declarator_list ',' init_declarator
	;

init_declarator:
	declarator
	| declarator '=' initializer
	;


type_specifier:
	VOID { $$ = $1; }
	| CHAR { $$ = $1; }
	| INT { $$ = $1; }
	;

specifier_qualifier_list:
	type_specifier specifier_qualifier_list { }
	| type_specifier { }
	| type_qualifier specifier_qualifier_list { }
	| type_qualifier { }
	;


type_qualifier:
	CONST
	;

declarator:
	direct_declarator
	;

func_declaration_start :
		direct_declarator '(' {
				$1->ident_ptr.ident_type	=	IDENT_DEF_FUNCTION;

				$1->ident_ptr.ident_info.func.pFuncSymbolTable = create_symbol_table();

				$1->ident_ptr.ident_info.func.formal_parameter_stack = 
								initialize_formal_param_stack();


				push_func_def(func_def_stack, $1);

				$$ = $1;
		}
;

direct_declarator:
	identifier { $1->ident_ptr.ident_type = IDENT_DEF_VARIABLE; }
	| '(' declarator ')' { assert(0); }
	| direct_declarator '[' constant_expression ']' { assert(0); }
	| direct_declarator '[' ']' { assert(0); }
	| func_declaration_start parameter_type_list ')' {
					/* this is the place where we put the code to process the 
					*	function definition 
					*/
					printf("[%d] source line #[%d] function definition\n", __LINE__, lineno);

					/* insert this function into the global symbol table.
					*   By definition the name of a function is always within the 
					*   global scope.
					*
					*/

					insert_symbol(
							g_SymbolTable,
							$1
							);

					process_function_definition(
														$1
														);

					produce_function_prologue(
														g_outFile,
														$1
														);

	 }
	| direct_declarator '(' identifier_list ')' { assert(0); $1->ident_ptr.ident_type = IDENT_DEF_FUNCTION; 
	}
	| func_declaration_start  ')' { /* mark the identifier as being a function */

					insert_symbol(
							g_SymbolTable,
							$1
							);


				process_function_definition(
													$1
													);

				produce_function_prologue(
														g_outFile,
														$1
														);
	}
	;

type_qualifier_list:
	type_qualifier
	| type_qualifier_list type_qualifier
	;

parameter_type_list:
	parameter_list
	| parameter_list ',' ELLIPSIS
	;

parameter_list:
	parameter_declaration
	| parameter_list ',' parameter_declaration
	;

parameter_declaration:
	declaration_specifiers declarator { 

			symtableentry_t *pFuncEntry = NULL;

			get_top_function(
									func_def_stack,
									&pFuncEntry
									);

			assert(pFuncEntry);

			process_formal_param_declaration(
									$1,
									$2
									);

			insert_symbol(
						pFuncEntry->ident_ptr.ident_info.func.pFuncSymbolTable,
						$2
						);

			push_formal_parameter(
							pFuncEntry->ident_ptr.ident_info.func.formal_parameter_stack,
							$2
							);										
	}
	| declaration_specifiers abstract_declarator { }
	| declaration_specifiers	{ }
	;

identifier_list:
	identifier { }
	| identifier_list ',' identifier { }
	;

type_name:
	specifier_qualifier_list
	| specifier_qualifier_list abstract_declarator
	;

abstract_declarator:
	direct_abstract_declarator
	;

direct_abstract_declarator:
	'(' abstract_declarator ')'
	| '[' ']'
	| '[' constant_expression ']'
	| direct_abstract_declarator '[' ']'
	| direct_abstract_declarator '[' constant_expression ']'
	| '(' ')'
	| '(' parameter_type_list ')'
	| direct_abstract_declarator '(' ')'
	| direct_abstract_declarator '(' parameter_type_list ')'
	;

initializer:
	assignment_expression { }
	| '{' initializer_list '}' { }
	| '{' initializer_list ',' '}' { }
	;

initializer_list:
	initializer
	| initializer_list ',' initializer
	;

/* B.2.3 Statements. */

statement:
    labeled_statement { }
	| compound_statement
	| expression_statement
	| selection_statement
	| iteration_statement
	| jump_statement
	;

labeled_statement :
    identifier ':' statement {
		$1 = generate_code_for_labeled_statement(
									g_outFile,
									$1->id_name
									);
	}
;

compound_statement_declaration_list :
	declaration_list {
			/* at this point we know we have processed
			*	all local variables within a function.
			*/

			process_function_local_variables(
									g_outFile
									);
	}
;

compound_statement:
	'{' '}'
	| '{' statement_list '}'
	| '{' compound_statement_declaration_list '}'
	| '{' compound_statement_declaration_list statement_list '}'
	;

declaration_list:
	declaration
	| declaration_list declaration
	;

statement_list:
	statement
	| statement_list statement
	;

expression_statement:
	';'
	| expression ';' { 
					/* if the expression is a register, mark it free */
					if ( $1->ident_ptr.ident_type == IDENT_DEF_EXPR_REG )
					{
						markRegFree($1->ident_ptr.ident_info.expr.expr_reg);
					}
	}
	;

selection_expression : 
	'(' expression ')' { 

			produce_code_for_selection_expression(g_outFile, $2);
	}
;

start_if_decision :
	IF	{ 
			produce_code_for_if_decision(g_outFile);
		}
;

start_while_decision :
	WHILE { 
				produce_code_for_while_loop_begin(g_outFile);
			}
;

start_else_decision :
	ELSE { 
			produce_code_for_else_decision(g_outFile);
			}
;

selection_statement:
	start_if_decision selection_expression statement {
			produce_code_for_if_statement(
								g_outFile
								);
	}
	| start_if_decision selection_expression statement start_else_decision statement {
			produce_code_for_if_else_statement(
								g_outFile
								);
	}
	;

iteration_statement:
	start_while_decision selection_expression statement	{
			produce_code_for_while_statement(
								g_outFile
								);
	}
	;

jump_statement:
    GOTO identifier ';' { produce_code_for_goto(
										g_outFile,
										$2->id_name
										);
										}
	| CONTINUE ';' { produce_code_for_continue(
									g_outFile
									);
									}
	| BREAK ';' { produce_code_for_break(
							g_outFile
							);
							}
	| RETURN ';' { assert(0); }
	| RETURN expression ';' {
			produce_code_for_return_statement(
								g_outFile,
								$2
								);
	}
	;

/* B.2.4 External definitions. */

translation_unit:
	external_declaration
	| translation_unit external_declaration
	;

external_declaration:
	function_definition
	| declaration
	;

function_definition:
	declaration_specifiers declarator declaration_list compound_statement {

					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					switch($1)
					{
						case VOID:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_VOID;
							break;

						case INT:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_INT;
							break;

						case CHAR:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_CHAR;
							break;

						default:
							assert(0);
							break;
					}

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							

					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}
					g_curFunction = NULL;
									
	}
	| declaration_specifiers declarator compound_statement { 
					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					switch($1)
					{
						case VOID:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_VOID;
							break;

						case INT:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_INT;
							break;

						case CHAR:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_CHAR;
							break;

						default:
							assert(0);
							break;
					}

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							


					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}



					g_curFunction = NULL;

	}
	| declarator declaration_list compound_statement { 
					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					pFuncDef->ident_ptr.ident_info.func.func_declared_type = 
							FUNC_DEF_DECLARED_INT;

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							

					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}

					g_curFunction = NULL;

	}
	| declarator compound_statement { 
					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					pFuncDef->ident_ptr.ident_info.func.func_declared_type = 
							FUNC_DEF_DECLARED_INT;

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							

					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}

					g_curFunction = NULL;
	}
	;

%%

static void
yyerror(const char *s)
{
	fprintf(stderr, "%d: %s\n", lineno, s);
}

extern	FILE	*yyin;

int
main(int	argc, char *argv[])
{
	symtableentry_t	*pFunc; 
	if ( argc != 3 )
	{
		printf("%s <C program to compile> <file for IL code>\n", argv[0]);
		return 1;
	}

	yyin	=	fopen(argv[1], "r");

	if ( NULL == yyin)
	{
		printf("%s	<cannot open file[%s] for reading\n", argv[0], argv[1]);
		return 1;
	}

	g_outFile = fopen(argv[2], "w");

	if ( NULL == g_outFile )
	{
		printf("%s <cannot open file[%s] for writing\n", argv[0], argv[2]);
		return 1;
	}

	g_SymbolTable = 
	create_symbol_table();

	pFunc = create_symbol_table_entry();

	pFunc->id_name =	strdup("print");
	pFunc->p_next	=	NULL;

	pFunc->ident_ptr.ident_type = IDENT_DEF_FUNCTION;
	pFunc->ident_ptr.ident_info.func.total_formal_parameters = 1;
	pFunc->ident_ptr.ident_info.func.func_sub_type = 
		IDENT_DEF_FUNC_SUB_TYPE_BUILT_IN;

	insert_symbol(
				g_SymbolTable,
				pFunc
				);

	pFunc = create_symbol_table_entry();

	pFunc->id_name =	strdup("printreg");
	pFunc->p_next	=	NULL;

	pFunc->ident_ptr.ident_type = IDENT_DEF_FUNCTION;
	pFunc->ident_ptr.ident_info.func.total_formal_parameters= 0;
	pFunc->ident_ptr.ident_info.func.func_sub_type = 
		IDENT_DEF_FUNC_SUB_TYPE_BUILT_IN;

	insert_symbol(
				g_SymbolTable,
				pFunc
				);

	pFunc = create_symbol_table_entry();

	pFunc->id_name =	strdup("accept");
	pFunc->p_next	=	NULL;

	pFunc->ident_ptr.ident_type = IDENT_DEF_FUNCTION;
	pFunc->ident_ptr.ident_info.func.total_formal_parameters = 1;
	pFunc->ident_ptr.ident_info.func.func_sub_type = 
		IDENT_DEF_FUNC_SUB_TYPE_BUILT_IN;

	insert_symbol(
				g_SymbolTable,
				pFunc
				);

	func_def_stack=
	init_function_def_stack();

	init_reg_list();

	yydebug = 1;
	lineno = 1;
	yyparse();

	return 0;
}