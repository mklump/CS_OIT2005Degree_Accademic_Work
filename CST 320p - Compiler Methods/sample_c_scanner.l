%{
#include <stdio.h>
#include <ctype.h>
int num_chars = 0;
%}


%%
"void" { printf("matched[%s]\n",yytext); }
"switch" { printf("matched[%s]\n",yytext); }
[a-zA-Z_][_a-zA-Z0-9]* { printf("saw identifier[%s]\n",
                         yytext);
			}
[0-9]*\.[0-9]+ { float val;

                  sscanf(yytext,"%f",&val);
                  printf("saw floating[%f]\n", val);
                }

[0-9]+ { printf("saw integer[%d]\n",atoi(yytext)); }
. { }
\n { }

%%
void main(int argc, char *argv[])
{
  FILE *fp;

  if ( argc == 1 )
  {
     printf("please enter a file to tokenize\n");
     return;
  }

  fp = fopen(argv[1],"r");
  if ( NULL == fp )
  {
     printf("cannot open file[%s] for reading\n",argv[1]);
     return;
  }

  yyin = fp;

  yylex();

  fclose(fp);
}

int yywrap()
{
  return 1;
}