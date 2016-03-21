%{ /* Beginning of Definitions */

/*--------------------------------------------------------------------
// Author:        Matthew Klump  mklump1@comcast.net
//				  CST 320p Compiler Methods
// Date Created:  5 May 2003
// Submission Date:  9 May 2003
// Project:        CST320_Assign_3
// Filename:       CST320_Assign_3.Lex.c ( A flex specification file )
//
// Overview:	Performs Lexical Analysis on a given source code file
//     	        as outlined in the language described by the Assignment 3
//				description.
//
// Input:       Any source code writen that is described by the language.
//
// Output:		Provides the tokens and their values for the interpreter
//				for further processing of the language tokens.
// 
//------------------------------------------------------------------*/

#include "Assign3.h"
#include "Assign3.y.tab.h"

extern int table_index,	lineno,	bVar_Declared;
int i;	// Loop variable

%}

%%

[ \t\f\v\r]		{ ; }  /* Do nothing to white space */

"+"			{
				yylval.exp_type = atoi(yytext);
				return PLUS_OP;
			}

"-"			{ 
				yylval.exp_type = atoi(yytext);
				return MINUS_OP;
			}

"*"			{ 
				yylval.exp_type = atoi(yytext);
				return MULT_OP;
			}

"/"			{
				yylval.exp_type = atoi(yytext);
				return DIVIDE_OP;
			}

"%"			{
				yylval.exp_type = atoi(yytext);
				return MODULO_OP;
			}

"START"		{
				yylval.exp_type = atoi(yytext);
				bVar_Declared = 0;
				varRetVal = (struct variable*) malloc( sizeof(struct variable) );
				varRetVal->name = (char *) malloc( sizeof(char *) );
				varRetVal->value = 0;
				for(i = 0; i < MAX_SIZE; ++i)
				{
					vbltable[i].name = (char *) malloc( sizeof(char *) );
					strcpy(vbltable[i].name, "");
				}
				return START;
			}

"END"		{
				yylval.exp_type = atoi(yytext);
				return END;
			}

"VAR"		{
				yylval.exp_type = atoi(yytext);
				return VAR;
			}

"INTEGER"	{
				yylval.exp_type = atoi(yytext);
				return INTEGER;
			}

"PRINT"		{
				yylval.exp_type = atoi(yytext);
				return PRINT;
			}

"READ"		{
				yylval.exp_type = atoi(yytext);
				return READ;
			}

"IF"		{
				yylval.exp_type = atoi(yytext);
				return IF;
			}

"THEN"		{
				yylval.exp_type = atoi(yytext);
				return THEN;
			}

"ELSE"		{
				yylval.exp_type = atoi(yytext);
				return ELSE;
			}

";"			{
				yylval.exp_type = atoi(yytext);
				return SEMI;
			}

":"			{
				yylval.exp_type = atoi(yytext);
				return COLON;
			}

","			{
				yylval.exp_type = atoi(yytext);
				return COMMA;
			}

":="		{
				yylval.exp_type = atoi(yytext);
				return ASSIGN_OP;
			}

"("			{
				yylval.exp_type = atoi(yytext);
				return LPAREN;
			}

")"			{
				yylval.exp_type = atoi(yytext);
				return RPAREN;
			}

"(*"  {		
		int	c1 = 0,     /* Comments handled here */
			c2 = input();
			
			for(;;)  {
				if( c2 == EOF )
					break;
				if( c2 == '\n' )
					lineno++;
				if( c1 == '*' && c2 == ')' )
					break;
				c1 = c2;
				c2 = input();
			}
	  }

[0-9][0-9]*		{
	varRetVal->value = atoi(yytext);
	return NUMBER;
}

[a-zA-Z][a-z0-9A-Z]*	{
	strcpy(varRetVal->name, yytext);
	return ID;
}

"\n"  {
		++lineno;
	  }

.	return yytext[0];

%%
