#include <stdio.h>

extern int yyparse(void *YYPARSE_PARAM);
extern FILE *yyin;

int	program_value = 0;

int main(int argc, char *argv[])
{
	int i;
	FILE	*file;

	if ( argc == 1 )
	{
		printf("[%s] <file to interpret> <file to interpret>\n", argv[0]);
		return -1;
	}

	for ( i = 1; i < argc; i++ )
	{
		file = fopen(argv[i], "r");
		yyin = file;

		if ( NULL == yyin )
		{
			printf("[%s] cannot open file[%s] for reading\n",
				argv[0], argv[i]);

			continue;
		}

		program_value = 0;

		if (0 != yyparse(i)) // no paricular reason
		{
			printf("parsing file[%s] failed\n", argv[i]);

			continue;
		}

		printf("value of program[%s] is [%d]\n",
			argv[i], program_value);
	}
}
