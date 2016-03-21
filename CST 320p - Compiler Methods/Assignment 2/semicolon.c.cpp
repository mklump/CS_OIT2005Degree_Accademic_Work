%{
/*
 * Word recognizer with a symbol table.
 */

%}

%%
";"   { printf("\n C Operator: %s", yytext); }

%%

int main()
{
    yylex();
	return 0;
}
