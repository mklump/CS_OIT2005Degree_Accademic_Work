//--------------------------------------------------------------------
// Author:        Matthew Klump  mklump1@qwest.net
//				  CST 223 Languages II	
// Date Created:  7 April 2003
// Submission Date:  14 April 2003
// Project:        Lexical_Analyzer
// Filename:       token.c
//
// Overview:   Performs Lexical Analysis on a given source file
//			   as outlined by run_tokenizer funtion call.
//			   This program is used as follows:
//			   c:\lexical_analyzer.exe < [inputfile.txt]
//			   where [inputfile.txt] was used as hello.c file
//			   that is included for testing and debugging (still needs much work.)
//   
// Input:      Accepts only a pointer to a FILE object 
//			   as outlined by init_tokenizer function call.
//   
// Output:	   Returns a pointer to the next token as outlined
//			   by the get_next_token function call.
//   
//--------------------------------------------------------------------

#include <stdio.h>
#include <malloc.h>
#include <string.h>
#include "assg1_val.h"

#define MAX_SIZE 90
#define TABLE_MAXSIZE 65536 // Approx. pow( 2, 16 )

FILE   *fpointer;					// Prointer to input file for tokenizing
static symbol_table_entry_t *p_TOKEN; // Pointer to symbol table entry array
int    cTokenCount = 0,				// Token number counter
	   max_tokens = 0,				// The maximum number of tokens
	   cLineNumber = 0,				// Line Number counter
	   bKeyword_Found = 0;			// The keyword parse flag

char token[10][ MAX_SIZE ];			// The next token [9][],
									// and the previous token[8][].

int operator_search(); // Local helper method for token : operator comparisons
int keyword_search();  // Local helper method for token : keyword comparisons

/*****
*
* Initialize the tokenizer
*	with a file stream.
*
*
*	This function returns a non-zero value
*		if successful.
*
*	Else returns a 0 error code.
*/
int
init_tokenizer(
			   FILE	*fp
			   )
{
	int bSeek_Status;

	/* Set pointer to beginning of file: */
    bSeek_Status = fseek( fp, 0L, SEEK_SET );
	fpointer = fp;

    if( bSeek_Status != 0 )
        return 0;			 // Fseek failed on initialization
    else
		return 1;			 // Fseek succeeded
}


/***** run_tokenizer.
*
*	Runs the tokenizer over
*	the input stream provided earlier
*	and builds up a token stream.
*
*	Returns a +ve value if successful.
*
*	Else returns a 0 for an error.
*
*/
int
run_tokenizer()
{
	int x = 0, y = 0,	 // Loop Variable
		bSingle_Quote=0, // Single quote parse flag
		bDouble_Quotes=0,// Double quote parse flag
		bComment = 0;	 // Comment parse flag

	token_val_t value_m; // For getting the value of the token

	char szLine_Buffer[ MAX_SIZE ];	   // The next line in source file
	for( x = 0; x < 10; ++x )
		strcpy( token[x], "" );

	p_TOKEN = (symbol_table_entry_t *) // Data structure for the categorized tokens
			malloc( sizeof(symbol_table_entry_t[TABLE_MAXSIZE]) );
	// Initialize string portions of the data structure
	for( x = 0; x < TABLE_MAXSIZE; ++x )
	{
		p_TOKEN[x].token_val.token_id = (char *) malloc( sizeof(char [MAX_SIZE]) );
		strcpy( p_TOKEN[x].token_val.token_id, "" );
	}

	// Get the next line in the source file.
	while( fgets( szLine_Buffer, MAX_SIZE, fpointer ) != NULL )
	{
		if( ferror(fpointer) )
		{
			fclose( fpointer );
			return 0;   // Tokenizing did not complete
		}
		cLineNumber++;  // Onto the next line number

		// Begin parsing for tokens
		while( szLine_Buffer[0] != '\n' )
		{
			while( szLine_Buffer[0] == ' ' )
			{   // Eliminates the leading spaces
				for( x = 0; x < (int)strlen(szLine_Buffer); ++x )
					szLine_Buffer[x] = szLine_Buffer[x+1];
			}
			// Get the next token delimited by a space
			// (I understand this is an incorrect implementation of this)
			sscanf(szLine_Buffer, "%s", &token[9]);

			// Store history of preivious tokens
			for( x = 0; x < 9; ++x )
				strcpy( token[x], token[x + 1] );

			// This section utilized for token identifying starts here

			if( strcmp( token[9], "\"" ) == 0 )// Check for double quotes delimiting
			{								   // a string within.
				if( bDouble_Quotes )
				{
					p_TOKEN[cTokenCount].token_type = TOKEN_STRING;
					p_TOKEN[cTokenCount].token_val.token_str, token[9];
					p_TOKEN[cTokenCount].line_num = cLineNumber;
					bDouble_Quotes = 0;
					break;
				}
				bDouble_Quotes = 1;
			}
			else if( strcmp( token[9], "\'" ) == 0 )// Check for single quotes delimiting
			{										// a character sequence
				if( bSingle_Quote )
				{
					p_TOKEN[cTokenCount - 1].token_type = TOKEN_CHAR;
					p_TOKEN[cTokenCount - 1].token_val.token_char = token[8];
					p_TOKEN[cTokenCount - 1].line_num = cLineNumber;
					bSingle_Quote = 0;
					break;
				}
				bSingle_Quote = 1;
			}
			else if( strcmp( token[9], "/*" ) == 0 ) // Check for a comment
				bComment = 1;

			else if( bComment && strcmp(token[9], "*/" ) == 0 )
			{
				p_TOKEN[cTokenCount].token_type = TOKEN_STRING;
				p_TOKEN[cTokenCount].token_val.token_str = token[9];
				p_TOKEN[cTokenCount].line_num = cLineNumber;
				bComment = 0;
			}

			else if( keyword_search() )  // Check to see if it is a keyword
				;
			else if( operator_search() ) // Check to see if it is an operator
				;
			else if( bKeyword_Found ) // Check for an identifyer assumed to
			{					      // follow a keyword.
				p_TOKEN[cTokenCount].token_type = TOKEN_IDENTIFIER;
				p_TOKEN[cTokenCount].token_val.token_id = token[9];
				p_TOKEN[cTokenCount].line_num = cLineNumber;
				bKeyword_Found = 0;
			}
			else if( sscanf( token[9], "%i", &value_m.token_int_val ) )
			{	// Check for an integer
				p_TOKEN[cTokenCount].token_type = TOKEN_INT;
				p_TOKEN[cTokenCount].token_val.token_int_val = value_m.token_int_val;
				p_TOKEN[cTokenCount].line_num = cLineNumber;
			}
			else if( sscanf( token[9], "%f", &value_m.token_float_val ) )
			{	// Check for a float
				p_TOKEN[cTokenCount].token_type = TOKEN_REAL;
				p_TOKEN[cTokenCount].token_val.token_float_val = value_m.token_float_val;
				p_TOKEN[cTokenCount].line_num = cLineNumber;
			}
			else
			{
				p_TOKEN[cTokenCount].token_type = TOKEN_UNKNOWN;
				strcpy(p_TOKEN[cTokenCount].token_val.token_unknown, token[9]);
				p_TOKEN[cTokenCount].line_num = cLineNumber;
			}
			// Now increment the token counter
			cTokenCount++;

			// The section for token identifying ends here

			while( szLine_Buffer[0] != ' ' )
			{	// Eliminate the trailing spaces
				if( szLine_Buffer[0] == '\n' )
					break;
				for( x = 0; x < (int)strlen(szLine_Buffer); ++x )
					szLine_Buffer[x] = szLine_Buffer[x+1];
			}
		}
	}
	max_tokens = cTokenCount;
	cTokenCount = 0;  // Reset token counter for retrival
	fclose( fpointer );
	return 1;		  // Tokenizing completed successfully
}


/***** function :- get_next_token.
*	Returns the next token as it is detected
*	in the input stream.
*
*	This is just an example.
*
*	Return value. If a valid token is present,
*		return a pointer to the symbol table where the
*		token is stored. 
*
*	Else return NULL.
*
*
*/
symbol_table_entry_t *
get_next_token()
{
	symbol_table_entry_t	*p_token;

	p_token = (symbol_table_entry_t *)
			malloc(sizeof(symbol_table_entry_t));

	if( cTokenCount == max_tokens + 1 )
	{
		free( p_TOKEN );
		free( p_token );
		return NULL;
	}

	p_token = &p_TOKEN[cTokenCount];
	cTokenCount++;
	return	p_token;
}

int keyword_search()
{
	int x;
	keyword_t token_key;
	for( x = 0; x < 32; ++x )
	{
		if( strcmp( token[9], keyword_as_str[x] ) == 0 )
		{
			p_TOKEN[cTokenCount].token_type = TOKEN_KEYWORD;
			token_key = x;
			p_TOKEN[cTokenCount].token_val.token_keyword = token_key;
			p_TOKEN[cTokenCount].line_num = cLineNumber;
			bKeyword_Found = 1;
			return 1;
		}
	}
	return 0;
}

int operator_search()
{
	int x;
	c_op_t token_oper;
	for( x = 0; x < 43; ++x )
	{
		if( strcmp( token[9], c_opt_t_sz[x] ) == 0 )
		{
			p_TOKEN[cTokenCount].token_type = TOKEN_OP;
			token_oper = x;
			p_TOKEN[cTokenCount].token_val.token_op = token_oper;
			p_TOKEN[cTokenCount].line_num = cLineNumber;
			return 1;
		}
	}
	return 0;
}