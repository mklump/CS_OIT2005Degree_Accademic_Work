#ifndef BISON_MFCALC_TAB_H
# define BISON_MFCALC_TAB_H

#ifndef YYSTYPE
typedef union {
int val;
int	exp_reg;
symrec *tptr; 
} yystype;
# define YYSTYPE yystype
# define YYSTYPE_IS_TRIVIAL 1
#endif
# define	NUM	257
# define	VAR	258
# define	FUNC	259
# define	NEG	260
# define	INPUT_FUNCTION	261


extern YYSTYPE yylval;

#endif /* not BISON_MFCALC_TAB_H */
