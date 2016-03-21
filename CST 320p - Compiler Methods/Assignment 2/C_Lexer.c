%{ /* Beginning of Definitions */

/*--------------------------------------------------------------------
// Author:        Matthew Klump  mklump1@comcast.net
//		  CST 320 Compiler Methods
// Date Created:  17 April 2003
// Submission Date:  21 April 2003
// Project:        C_Lexical_Analyzer
// Filename:       C_Lexer.c ( A flex specification file )
//
// Overview:	Performs Lexical Analysis on a given C source file
//     	        as outlined by run_tokenizer funtion call.
//	        This program is used as follows:
//	        c:\lexical_analyzer.exe < [inputfile.txt]
//
// Input:       Accepts only a pointer to a FILE object 
//	        as outlined by init_tokenizer function call.
//
// Output:	Returns a pointer to the next token as outlined
//		by the get_next_token function call.
//
//------------------------------------------------------------------*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "assg1_val.h"

#define TOKEN_LIMIT 65535

void Add_Keyword(int token_type);
void Add_Operator(int token_type);

char ch,			 // char to int conversion
	 ID[256],		 // for #define directive parsing
	 LITERAL[256],	 // for #define directive parsing
	 *_define[2][256], *szLITER;// For storing #define directive
								// variables and their values.

int lineno = 1,		 // Line number counter
	i = 0,			 // Loop variable
	token_type = -1, // Token type
	c1, c2,			 // Comment consumption
	cWhite_Space = 0,// Number of white space tokens parsed
	bAbort, bGetNext_Called = 0, // To abort or not to abort, flag for get_next_token()
	bRegular_Identifier = 0,	 // flag for regular identifier vs. a #define identifier
	cLeftParen = 0, cRightParn = 0,
	cRightBrace = 0, cLeftBrace = 0,
	cLeftSquare = 0, cRightSquare = 0;

static int id = 0, literal = 0;  // for storing #define directives
#define TOKEN_DEFINE		309  // #define directive token identification

%} /* End of definitions */

   /* Definitions for Lex states and other tokens */
%s _DEFINE 

%% /* Beginning of rules specification section */

"/*"  {		
			c1 = 0;     /* Comments handled here */
			c2 = input();
			
			for(;;)  {
				if( c2 == EOF )
					break;
				if( c2 == '\n' )
					lineno++;
				printf("\nConsuming comment token within \"/*\" and \"*/\".\n");
				if( c1 == '*' && c2 == '/' )
					break;
				c1 = c2;
				c2 = input();
			}
	  }

\n	{ lineno++; }

"auto" {			/* Beginning section of rules code for keyword matching */
		printf("\n C Keyword: %s\n", yytext);
		return KEY_AUTO;
	}
"double" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_DOUBLE;
	}
"int" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_INT;
	}
"struct" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_STRUCT;
	}
"break" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_BREAK;
	}
"else"	{
		printf("\n C Keyword: %s\n", yytext);
		return KEY_ELSE;
	}
"long"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_LONG;
	}
"switch" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_SWITCH;
	}
"case"	{
		printf("\n C Keyword: %s\n", yytext);
		return KEY_CASE;
	}
"enum"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_ENUM;
	}
"register" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_REGISTER;
	}
"typedef"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_TYPEDEF;
	}
"char"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_CHAR;
	}
"extern" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_EXTERN;
	}
"return" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_RETURN;
	}
"union"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_UNION;
	}
"const"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_CONST;
	}
"float"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_FLOAT;
	}
"short"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_SHORT;
	}
"unsigned" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_UNSIGNED;
	}
"continue" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_CONTINUE;
	}
"for"   {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_FOR;
	}
"signed"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_SIGNED;
	}
"void"    {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_VOID;
	}
"default" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_DEFAULT;
	}
"goto"    {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_GOTO;
	}
"sizeof"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_SIZEOF;
	}
"volatile" {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_VOLATILE;
	}
"do"	  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_DO;
	}
"if"	  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_IF;
	}
"static"  {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_STATIC;
	}
"while"	   {
		printf("\n C Keyword: %s\n", yytext);
		return KEY_WHILE;
					/* End of keyword rules */
	}

"{"   {				/* Beginning of C operator recognition section */
	printf("\n C Operator: %s\n", yytext);
	cRightBrace++;
	return C_OP_LEFT_BRACE;
}
"}"   {
	printf("\n C Operator: %s\n", yytext);
	cLeftBrace++;
	return C_OP_RIGHT_BRACE;
}
","   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_COMMA;
}
"="   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_ASSIGNMENT;
}
"?"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_QUESTION;
}
":"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_COLON;
}
"||"  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_LOR;
}
"&&"  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_LAND;
}
"|"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_BITOR;
}
"&"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_BITAND;
}
"^"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_BITXOR;
}
"!="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_NEQ;
}
"<="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_LTEQ;
}
">="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_GTEQ;
}
"=="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_EQ;
}
">"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_GT;
}
"<"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_LT;
}
"<<"  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_LSHIFT;
}
">>"  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_RSHIFT;
}
"+"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_ADD;
}
"-"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_SUB;
}
"*"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_MULT;
}
"/"    {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_DIV;
}
"%"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_MOD;
}
"~"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_COMPLEMENT;
}
"++"  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_POSTINCR;
}
"--"  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_POSTDEC;
}
"->"  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_POINTER;
}
"."   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_FIELD_REF;
}
"["   {
	printf("\n C Operator: %s\n", yytext);
	cLeftSquare++; 
	return C_OP_LSQR;
}
"]"   {
	printf("\n C Operator: %s\n", yytext);
	cRightSquare++;
	return C_OP_RSQR;
}
"+="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_PLUSEQ;
}
"-="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_MINUSEQ;
}
"/="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_DIVEQ;
}
"%="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_MODEQ;
}
"*="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_MULTQ;
}
";"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_SEMI;
}
"("   {
	printf("\n C Operator: %s\n", yytext);
	cLeftParen++;
	return C_OP_LPAREN;
}
")"   {
	printf("\n C Operator: %s\n", yytext);
	cRightParn++;
	return C_OP_RPAREN;
}
"&="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_ANDEQ;
}
"|="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_OREQ;
}
"^="  {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_XOREQ;
}
"!"   {
	printf("\n C Operator: %s\n", yytext);
	return C_OP_NOT;
						/* End of C operator recognition section */
    }

"#include".* {
	printf("\n Error on line: %d \
		   \n This scanner does not process #include. Aborting ...", lineno);
	abort();
}

"#define" { BEGIN _DEFINE; }

<_DEFINE>.*  {
	char _defin[256];
	strcpy(_defin,"#define");
	strcat(_defin,yytext);

	printf("\n Processing #define statement: %s", _defin);
	sscanf(yytext, "%s", ID);
	while( yytext[0] == ' ' )
	{	// Eliminate the trailing spaces
		for( i = 0; i < (int)strlen(yytext); ++i )
			yytext[i] = yytext[i+1];
	}
	while( yytext[0] != ' ' )
	{	// Over write the #define identifier in yytext buffer
		for( i = 0; i < (int)strlen(yytext); ++i )
			yytext[i] = yytext[i+1];
	}
	while( yytext[0] == ' ' )
	{	// Eliminate the trailing spaces
		for( i = 0; i < (int)strlen(yytext); ++i )
			yytext[i] = yytext[i+1];
	}
	strcpy( LITERAL, yytext );
	_define[id][literal] = strdup(ID);
	id++;
	_define[id][literal] = strdup(LITERAL);
	literal++;
	id = 0;
	yytext = strdup( _defin );
	BEGIN INITIAL;
	return TOKEN_DEFINE;
}

[a-zA-Z_][^*][_a-zA-Z0-9]* {
			for( i = 0; i < 32; ++i )
			{
				if( strcmp( yytext, keyword_as_str[i] ) == 0 )
				{
					for( i = 0; i < 80; ++i )
					{
						yyless(yytext[yyleng - 1]);
						return -1;
					}
				}
			}
			for( i = 0; i < 256; ++i )
			{
				if( _define[0][i] == NULL )
				{
					bRegular_Identifier = 1;
					break;
				}
				if( strcmp( yytext, _define[0][i] ) == 0 )
				{
					szLITER = strdup( _define[1][i] );
					printf("\n Found identifier: %s, changing to: %s",
							_define[0][i], _define[1][i]);
					bRegular_Identifier = 0;
					return TOKEN_IDENTIFIER;
				}
			}
			printf("\n Possible C identifier: %s\n", yytext);
			return TOKEN_IDENTIFIER;
	}

[-+]?([0-9]+)?"."[0-9]+[eE]?[-+]?([0-9]+)? {
	printf("\n Real or floating point: %s", yytext); /* Recognize real and */
	return TOKEN_REAL;								 /*	floating point */
	} 
													   
"0"[0-7]+ {								/* Recognize Octal values */
	printf("\n Octal: %s", yytext);
	return TOKEN_STRING;
	}

"0x"[a-fA-F0-9]+ {						/* Recognize Hexadecimal values */
	printf("\n Hexadecimal: %s", yytext);
	return TOKEN_STRING;
	}

-?[0-9]+ { printf("\n Integer: %s", yytext); /* Recognize integer values */
	return TOKEN_INT;
	}

"\"".+"\\"\n.*"\"" {
	lineno++;
	printf("\n Legal C-style string: %s", yytext);
	return TOKEN_STRING;
	}

"\"".+"\"" {
	printf("\n Legal C-style string: %s", yytext);
	return TOKEN_STRING;
	}

"\"".+\n.*"\"" {
	printf("\n Illegal C-style string: %s, On line: %d\n", yytext, lineno);
	return TOKEN_ILLEGAL;
	}

"\'"[a-zA-Z0-9_ ]"\'" |
"\'"[0-9]+"\'"	  {
	printf("\n Character constant: %s", yytext);
	return TOKEN_CHAR;
	}

"\'".*"\'" {
	printf("\n Illegal character constant: %s, on line: %d\n", yytext, lineno);
	return TOKEN_ILLEGAL;
	} 

[ \t] { ; } /* Ignore spaces and tabs */

.	{ 
	printf("\n Unknown token: %s\n", yytext);
	return TOKEN_UNKNOWN;
	}

%% /* End of rules specification section */

/* Beginning of C code verbatim section */

extern void* malloc();
extern void free();
extern void exit( int );

int yywrap()
{
	return 1;
}

typedef struct _symbol_table {

	struct _symbol_table_entry_t *entry;
	struct _symbol_table *next;

} def_symbol_table;

struct _symbol_table	*table,			// first element in the token list
						*token_entry;	// New entry in the list

int
init_tokenizer( FILE *fp )
{
	int bSeek_Status;
	table = NULL;

	/* Set pointer to beginning of file: */
    bSeek_Status = fseek( fp, 0L, SEEK_SET );
	yyrestart( fp );
	if( !fp )
		bSeek_Status = 1;

	yyin = fp;

    if( bSeek_Status != 0 )
        return 0;			 // Fseek failed on initialization
    else
		return 1;			 // Fseek succeeded
}

symbol_table_entry_t *
get_next_token()
{
	int j = 0;
	static int k;
	static struct _symbol_table   *temp1[TOKEN_LIMIT],
								  *temp2[TOKEN_LIMIT];

	if( bGetNext_Called == 0 )
	{
		for( i = 0; token_entry != NULL; ++i, token_entry = token_entry->next )
			temp1[i] = token_entry;
		k = j = i;
		for( i = 0; j - 1 >= 0; ++i, --j )
			temp2[i] = temp1[j];
		for( k = 0; k + 1 < i; ++k )
			temp2[k] = temp2[k + 1];
		k = 0;
		bGetNext_Called = 1;
	}
	else
		k++;

	if( temp2[k] == NULL )
	{
		free( temp2[k] );
		free( table );
		return NULL;
	}
	else
	{
		return	temp2[k]->entry;
	}
}

void Add_Keyword(int token_type)
{
	switch( token_type )
	{
	case KEY_AUTO:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_AUTO;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_DOUBLE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_DOUBLE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_INT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_INT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_STRUCT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_STRUCT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_BREAK:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_BREAK;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_ELSE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_ELSE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_LONG:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_LONG;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_SWITCH:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_SWITCH;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_CASE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_CASE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_ENUM:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_ENUM;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_REGISTER:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_REGISTER;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_TYPEDEF:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_TYPEDEF;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_CHAR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_CHAR;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_EXTERN:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_EXTERN;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_RETURN:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_RETURN;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_UNION:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_UNION;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_CONST:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_CONST;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_FLOAT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_FLOAT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_SHORT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_SHORT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_UNSIGNED:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_UNSIGNED;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_CONTINUE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_CONTINUE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_FOR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_FOR;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_SIGNED:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_SIGNED;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_VOID:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_VOID;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_DEFAULT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_DEFAULT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_GOTO:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_GOTO;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_SIZEOF:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_SIZEOF;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_VOLATILE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_VOLATILE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_DO:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_DO;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_IF:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_IF;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_STATIC:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_STATIC;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case KEY_WHILE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_KEYWORD;
		token_entry->entry->token_val.token_keyword = KEY_WHILE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	default:
		break;
	}
}
void Add_Operator(int token_type)
{
	switch( token_type )
	{
	case C_OP_LEFT_BRACE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_LEFT_BRACE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_RIGHT_BRACE:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_RIGHT_BRACE;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_COMMA:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_COMMA;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_ASSIGNMENT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_ASSIGNMENT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_QUESTION:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_QUESTION;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_COLON:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_COLON;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_LOR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_LOR;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_LAND:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_LAND;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_BITOR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_BITOR;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_BITAND:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_BITAND;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_BITXOR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_BITXOR;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_NEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_NEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_LTEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_LTEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_GTEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_GTEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_EQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_EQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_GT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_GT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_LT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_LT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_LSHIFT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_LSHIFT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_RSHIFT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_RSHIFT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_ADD:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_ADD;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_SUB:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_SUB;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_MULT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_MULT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_DIV:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_DIV;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_MOD:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_MOD;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_COMPLEMENT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_COMPLEMENT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_POSTINCR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_POSTINCR;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_POSTDEC:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_POSTDEC;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_POINTER:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_POSTDEC;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_FIELD_REF:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_FIELD_REF;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_LSQR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_FIELD_REF;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_RSQR:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_RSQR;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_PLUSEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_PLUSEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_MINUSEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_MINUSEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_DIVEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_DIVEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_MODEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_MODEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_MULTQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_MULTQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_SEMI:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_SEMI;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_LPAREN:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_LPAREN;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_RPAREN:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_RPAREN;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_ANDEQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_ANDEQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_OREQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_OREQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_XOREQ:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_XOREQ;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	case C_OP_NOT:
		token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
		token_entry->entry = (struct _symbol_table_entry_t *)
								malloc(sizeof(struct _symbol_table_entry_t));
		token_entry->next = table;

		token_entry->entry->token_type = TOKEN_OP;
		token_entry->entry->token_val.token_op = C_OP_NOT;
		token_entry->entry->line_num = lineno;

		table = token_entry;
		break;
	default:
		break;
	}
}

int
run_tokenizer()
{
	i = 0;
	while ( 1 )
	{
		i++;
		if( i >= TOKEN_LIMIT || bAbort == 1 )
			return 0;   // Tokenizing did not complete

		if( token_type == 0 )
		{
			if( cLeftParen != cRightParn )
			{
				printf("\nLeft and right parenthesis do not match. Aborting");
				abort();
			}
			if( cRightBrace != cLeftBrace )
			{
				printf("\nLeft and right braces do not match. Aborting");
				abort();
			}
			if( cLeftSquare != cRightSquare )
			{
				printf("\nLeft and right square brackets do not match. Aborting");
				abort();
			}
			return 1;   // Tokenizing completed
		}

		token_type = yylex();

        for( i = 0; i < 32; ++i )
		{
			if( strcmp( yytext, keyword_as_str[i] ) == 0 )
			{
				Add_Keyword( token_type );
				break;
			}
		}
		for( i = 0; i < 43; ++i )
		{
			if( strcmp( yytext, c_opt_t_sz[i] ) == 0 )
			{
				Add_Operator( token_type );
				break;
			}
		}

		switch( token_type )
		{
		case TOKEN_INT:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;

			token_entry->entry->token_type = TOKEN_INT;
			token_entry->entry->token_val.token_int_val = atoi(yytext);
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		case TOKEN_REAL:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;

			token_entry->entry->token_type = TOKEN_REAL;
			token_entry->entry->token_val.token_float_val = (float)atof(yytext);
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		case TOKEN_STRING:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;

			token_entry->entry->token_type = TOKEN_STRING;
			token_entry->entry->token_val.token_str = (char*) strdup(yytext);
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		case TOKEN_CHAR:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;
			token_entry->entry->token_type = TOKEN_CHAR;
			yytext[0] = ' ';
			yytext[strlen(yytext) - 1] = ' ';

			sscanf(yytext, "%s", yytext); // Eliminate leading and trailing spaces.
			token_entry->entry->token_val.token_char = (int)yytext;
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		case TOKEN_DEFINE:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;

			token_entry->entry->token_type = TOKEN_DEFINE;
			token_entry->entry->token_val.token_str = (char*) strdup(yytext);
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		case TOKEN_IDENTIFIER:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;

			token_entry->entry->token_type = TOKEN_IDENTIFIER;
			if( bRegular_Identifier )
				token_entry->entry->token_val.token_id = (char*) strdup(yytext);
			else
				token_entry->entry->token_val.token_id = (char*) strdup(szLITER);
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		case TOKEN_UNKNOWN:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;

			token_entry->entry->token_type = TOKEN_UNKNOWN;
			token_entry->entry->token_val.token_unknown = (char*) strdup(yytext);
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		case TOKEN_ILLEGAL:
			token_entry = (struct _symbol_table *) malloc(sizeof(struct _symbol_table));
			token_entry->entry = (struct _symbol_table_entry_t *)
								 malloc(sizeof(struct _symbol_table_entry_t));
			token_entry->next = table;

			token_entry->entry->token_type = TOKEN_ILLEGAL;
			token_entry->entry->token_val.token_illegal = (char*) strdup(yytext);
			token_entry->entry->line_num = lineno;

			table = token_entry;
			break;
		default:
			break;
		}
	}
}

/* End of C code verbatim section */
