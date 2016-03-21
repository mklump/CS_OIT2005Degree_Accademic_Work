#ifndef _assg1_val_h
#define _assg1_val_h

typedef enum	_keyword_t {
	KEY_AUTO,
	KEY_DOUBLE,
	KEY_INT,
	KEY_STRUCT,
	KEY_BREAK,
	KEY_ELSE,
	KEY_LONG,
	KEY_SWITCH,
	KEY_CASE,
	KEY_ENUM,
	KEY_REGISTER,
	KEY_TYPEDEF,
	KEY_CHAR,
	KEY_EXTERN,
	KEY_RETURN,
	KEY_UNION,
	KEY_CONST,
	KEY_FLOAT,
	KEY_SHORT,
	KEY_UNSIGNED,
	KEY_CONTINUE,
	KEY_FOR,
	KEY_SIGNED,
	KEY_VOID,
	KEY_DEFAULT,
	KEY_GOTO,
	KEY_SIZEOF,
	KEY_VOLATILE,
	KEY_DO,
	KEY_IF,
	KEY_STATIC,
	KEY_WHILE
} keyword_t;

static const char *keyword_as_str[] = {
	"auto",
	"double",
	"int",
	"struct",
	"break",
	"else",
	"long",
	"switch",
	"case",
	"enum",
	"register",
	"typedef",
	"char",
	"extern",
	"return",
	"union",
	"const",
	"float",
	"short",
	"unsigned",
	"continue",
	"for",
	"signed",
	"void",
	"default",
	"goto",
	"sizeof",
	"volatile",
	"do",
	"if",
	"static",
	"while"
};

typedef	enum	_c_op_t
{
	C_OP_LEFT_BRACE = 32,  /* { */
	C_OP_RIGHT_BRACE, /* } */
	C_OP_COMMA, /* , */
	C_OP_ASSIGNMENT, /* = */
	C_OP_QUESTION, /* ? */
	C_OP_COLON, /* : */
	C_OP_LOR, /* || */
	C_OP_LAND, /* && */
	C_OP_BITOR, /* | */
	C_OP_BITAND, /* & */
	C_OP_BITXOR, /* ^ */
	C_OP_NEQ, /* != */
	C_OP_LTEQ, /* <= */
	C_OP_GTEQ, /* >= */
	C_OP_EQ, /* == */
	C_OP_GT, /* > */
	C_OP_LT, /* < */
	C_OP_LSHIFT, /* << */
	C_OP_RSHIFT, /* >> */
	C_OP_ADD, /* + */
	C_OP_SUB, /* - */
	C_OP_MULT, /* * */
	C_OP_DIV, /* / */
	C_OP_MOD, /* % */
	C_OP_COMPLEMENT, /* ~ */
	C_OP_POSTINCR, /* ++ */
	C_OP_POSTDEC, /* -- */
	C_OP_POINTER, /* -> */
	C_OP_FIELD_REF, /* . */
	C_OP_LSQR, /* [ */
	C_OP_RSQR, /* ] */
	C_OP_PLUSEQ,	/* += */
	C_OP_MINUSEQ,	/* -= */
	C_OP_DIVEQ, /* /= */
	C_OP_MODEQ, /* %= */
	C_OP_MULTQ, /* *= */
	C_OP_SEMI, /* ; */
	C_OP_LPAREN,	/* ( */
	C_OP_RPAREN,	/* ) */
	C_OP_ANDEQ,	/* &= */
	C_OP_OREQ,	/* |= */
	C_OP_XOREQ,	/* ^= */
	C_OP_NOT	/* ! */
} c_op_t;

static const	char	*c_opt_t_sz[] = {
	"{",
	"}",
	",",
	"=",
	"?",
	":",
	"||",
	"&&",
	"|",
	"&",
	"^",
	"!=",
	"<=",
	">=",
	"==",
	">",
	"<",
	"<<",
	">>",
	"+",
	"-",
	"*",
	"",
	"%",
	"~",
	"++",
	"--",
	"->",
	".",
	"[",
	"]",
	"+=",
	"-=",
	"/=",
	"%=",
	"*=",
	";",
	"(",
	")",
	"&=",
	"|=",
	"^=",
	"!"
};

typedef	union	_token_val_t {

	/* token_int_val. contains an integer */
	int			token_int_val;

	/* token_float_val. contains a float */
	float		token_float_val;

	/* double token val. Contains a double value.
	*	This is big enough to fit all real
	*/
	double		token_double_val;

	/* contains the keyword */
	keyword_t	token_keyword;


	/* contains an identifier */
	char		*token_id;


	/* contains a token as an operator */
	c_op_t		token_op;

	/* contains a token as a string */
	char		*token_str;

	/* illegal token. */
	char		*token_illegal;

	/* unknown token */
	char		*token_unknown;

	/**** character constants.
		An integer is big enough to 
	fit all characters
	*/

	int			token_char;

} token_val_t;

/****
*  Various types of tokens.
*
*/
#define	TOKEN_INT									300
#define	TOKEN_REAL								301
#define	TOKEN_KEYWORD						302
#define	TOKEN_IDENTIFIER						303
#define	TOKEN_OP									304
#define	TOKEN_STRING							305
#define	TOKEN_CHAR								306
#define	TOKEN_ILLEGAL								307
#define	TOKEN_UNKNOWN						308

typedef	struct	_symbol_table_entry_t
{

	/*** line_num contains the # of the line
	*	in the source file where this token is
	*	detected.
	*
	*/
	int		line_num;

	/**** pointer to the value of the token.
	*
	*
	*/
	token_val_t	token_val;


	/**** token_type contains the type of
	*	the token. See the constants TOKEN_XXX
	*	above.
	*
	*	Comments SHOULD never be returned here.
	*
	*
	*	If an illegal token is present, the type to use
	*	is TOKEN_ILLEGAL.
	*/
	int			token_type;
} symbol_table_entry_t;

#endif
