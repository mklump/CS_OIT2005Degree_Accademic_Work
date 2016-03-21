/******
*	Assignment 1 CST 320 Spring 2003. 
*	Instructor :- Ramakrishna Saripalli.
*
*	03/31/2003.
*
*		See the sample token.c on how to
*		write the functions needed here.
*/

#include <stdio.h>
#include "assg1_val.h"

#define TOKEN_DEFINE		309

extern	int	init_tokenizer(FILE *input_stream);

extern	int	run_tokenizer();

extern	symbol_table_entry_t	*get_next_token();

int main(int argc, char *argv[])
{
	FILE *fp;

	symbol_table_entry_t	*p_token;

	if ( 1 == argc )
	{
		printf("%s [ name of file to tokenize ]\n", argv[0]);
		return;
	}

	fp = fopen(argv[1], "r");

	if ( NULL == fp )
	{
		printf("%s. cannot open file[%s] for reading\n",
			argv[0], argv[1]);
		return;
	}

	if ( !init_tokenizer(fp) )
	{
		printf("%s. init_tokenizer() failed on file[%s]\n",
			argv[0], argv[1]);
		return;
	}

	if ( !run_tokenizer() )
	{
		printf("%s. run_tokenizer() failed on file[%s]\n",
			argv[0], argv[1]);
		return;
	}

	while ( 1 )
	{
		p_token = get_next_token();

		if ( p_token == NULL )
		{
			break;
		}

		switch(p_token->token_type)
		{
		case TOKEN_INT:
			printf("line[%d] token is an integer value[%d]\n",
				p_token->line_num, p_token->token_val.token_int_val
				);
			break;

		case TOKEN_REAL:
			printf("line[%d] token is a float value[%f]\n",
				p_token->line_num, p_token->token_val.token_float_val
				);
			break;

		case TOKEN_KEYWORD:
			printf("line[%d] token is a keyword[%s]\n",
				p_token->line_num, keyword_as_str[p_token->token_val.token_keyword]
				);
			break;

		case TOKEN_IDENTIFIER:
			printf("line[%d] token is an identifier[%s]\n",
				p_token->line_num, p_token->token_val.token_id
				);			
			break;

		case TOKEN_OP:
			printf("line[%d] token is an operator[%s]\n",
				p_token->line_num, keyword_as_str[p_token->token_val.token_op]
				);

			break;

		case TOKEN_STRING:
			printf("line[%d] token is a string[%s]\n",
				p_token->line_num, p_token->token_val.token_str
				);

			break;

		case TOKEN_CHAR:
			printf("line[%d] token is a character[%s]\n",
				p_token->line_num, (char*)p_token->token_val.token_char
				);

			break;

		case TOKEN_ILLEGAL:
			printf("*******line[%d]***** illegal token detected\n",
				p_token->line_num
				);

			if ( p_token->token_val.token_illegal )
			{
				printf("line: [%d] ILLEGAL TOKEN: [%s]\nAbborting ...\n",
					p_token->line_num, p_token->token_val.token_illegal
					);
			}
			exit(-1);

		case TOKEN_UNKNOWN:
			printf("*******line[%d]***** unknown token detected\n",
				p_token->line_num
				);

			if ( p_token->token_val.token_unknown )
			{
				printf("line[%d] unknown token[%s]\n",
					p_token->line_num, p_token->token_val.token_unknown
					);
			}

			break;

		case TOKEN_DEFINE:
			printf("line[%d] token is a \"#define statement\" [%s]\n",
				p_token->line_num, p_token->token_val.token_str
				);

			break;

		default:
			break;
		}
	}
	return 0;
}
