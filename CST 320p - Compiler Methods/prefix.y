%{
#include <stdio.h>
#include <math.h>
%}

%token NUM
%token NEWLINE
%token PLUS_OP
%token MINUS_OP
%token MULT_OP
%token LEFT_PAREN
%token RIGHT_PAREN


%%
inp : inp line
;

inp : 
;

line : NEWLINE
;

line : exp NEWLINE { printf("expression value[%d]\n", $1); }
;

exp : NUM { $$ = $1; }
;

exp : PLUS_OP exp exp {  $$ = $2 + $3;}
;

exp : MINUS_OP exp exp { $$ = $2 - $3; }
;

exp : MULT_OP exp exp { $$ = $2 * $3; }
;

exp : LEFT_PAREN exp RIGHT_PAREN { $$ = $2; }
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