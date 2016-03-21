%{
#include <stdio.h>
#include <math.h>
%}

%token NUM
%token NEWLINE
%token PLUS_OP
%token MINUS_OP
%token MULT_OP

%%
inp : 
    | inp line
;

line : NEWLINE
;

line : exp NEWLINE { printf("expression value[%d]\n", $1); } 
;


exp : NUM       { $$ = $1; }
    | PLUS_OP exp exp {  $$ = $2 + $3;}
    | MINUS_OP exp exp { $$ = $2 - $3; }
    | MULT_OP exp exp { $$ = $2 * $3; }
;

%%
int main()
{
   yyparse();
   return 0;
}

void
yyerror(const char *s)
{
printf("%s\n",s);
}

int yywrap()
{
  return 1;
}