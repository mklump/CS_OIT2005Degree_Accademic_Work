#ifndef _var_def_h
#define _var_def_h

struct	_symtableentry_t;

struct	_symtableQ_t;

/* each token has one of the following
*	type. 
*
*/
typedef enum	_IDENT_DEF_TYPE
{
	/* The identifier is a function .
	*	The return type of this
	*	function is specified 
	*	in the declared type of the
	*	function
	*/
	IDENT_DEF_FUNCTION,

	/* There is really no identifier corresponding
	*	to this type. This just implies that the token
	*	on the parser's stack is a function call.
	*	We use this type to propogate a token on
	*	the parser's stack . This token resembles the
	*	the stack containing actual parameters. When
	*	a function is called, the actual parameters are built
	*	up on this stack and when the code for the function
	*	call is produced, the code for the parameters may be 
	*	passed as well.
	*
	*/
	IDENT_DEF_FUNCTION_CALL,

	/* The identifier is a variable. The type of the 
	*	variable is given in the declared type.
	*
	*/
	IDENT_DEF_VARIABLE,

	/* If the token is a constant( integer or character )
	*  this type is used to indicate its value.
	*
	*/
	IDENT_DEF_CONSTANT_INT,

	/* there is no really no identifier corresponding
	*	to this type. This again is used to resemble a
	*  token that is passed on the parser's stack.
	*
	*	This resembles an expression whose value is 
	*	in a register (0 through 14 inclusive).
	*
	*/
	IDENT_DEF_EXPR_REG,

	/* This is used to mark as a sentinel.
	*
	*/
	IDENT_DEF_INVALID
} IDENT_DEF_TYPE;

/* IDENT_DEF_DECLARED_TYPE.
*	Indicates the declared type of the function
*	or the variable.
*
*	Variable can be a local variable, global variable
*	or a formal parameter.
*
*
*	The value IDENT_DEF_DECLARED_VOID is
*	only valid for functions.
*/
typedef	enum	_IDENT_DEF_DECLARED_TYPE
{
	IDENT_DEF_DECLARED_VOID,
	IDENT_DEF_DECLARED_INT,
	IDENT_DEF_DECLARED_CHAR,
	IDENT_DEF_DECLARED_INVALID
} IDENT_DEF_DECLARED_TYPE;

typedef	enum	_FUNC_DEF_RETURN_TYPE
{
	FUNC_DEF_DECLARED_VOID,
	FUNC_DEF_DECLARED_INT,
	FUNC_DEF_DECLARED_CHAR,
	FUNC_DEF_DECLARED_INVALID
} FUNC_DEF_DECLARED_TYPE;

/*
* enumeration EXPR_TYPE.
*
*	Indicates the type of an expression.
*
*	All expressions have types. This is used
*	by the compiler to ensure type safety.
*
*
*	For example, the expression foo(5) where foo
*	is a function taking an integer and returning nothing
*	has the type VOID. If this is used within another expression,
*	the type of the expression is used to check type consistency.
*
*/
typedef	enum	_EXPR_TYPE
{
	EXPR_TYPE_VOID,	/* expression is void. This makes sense if it is a function returning void */
	EXPR_TYPE_INT,	/* expression type is integer */
	EXPR_TYPE_CHAR,	/* expression type is character which is again an integer. Not used*/
	EXPR_TYPE_BOOLEAN,	/*zero or non-zero */
	EXPR_TYPE_INVALID	/* used as a marker */
} EXPR_TYPE;


/* VAR_SUB_TYPE.
*	Only tokens having variable type
*	have this property.
*
*	VAR_SUB_TYPE_LOCAL_VAR indicates
*	variable is locally declared to a function.
*
*
*	VAR_SUB_TYPE_FORMAL_PARAM indicates
*		that the variable is a formal parameter.
*
*	VAR_SUB_TYPE_GLOBAL_VAR indicates that
*		the variable is a global variable.
*
*/

typedef	enum	_VAR_SUB_TYPE
{
	VAR_SUB_TYPE_LOCAL_VAR,
	VAR_SUB_TYPE_FORMAL_PARAM,
	VAR_SUB_TYPE_GLOBAL_VAR
} VAR_SUB_TYPE;

/* IDENT_DEF_FUNC_SUB_TYPE.
*	Indicates if the function is a built-in function
*	or a user-defined function.
*
*	There are a limited number of built-in
*	functions, print, printreg and accept.
*
*/
typedef	enum	_IDENT_DEF_FUNC_SUB_TYPE
{
	IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED,
	IDENT_DEF_FUNC_SUB_TYPE_BUILT_IN
} IDENT_DEF_FUNC_SUB_TYPE;

struct	_func_t; /* forward declaration */


/* Structure describing a token representing
*	a variable.
*
*	This structure is used to represent all kinds
*	of variables including local, global and formal
*	parameters. In general, a variable indicates anything
*	that has a memory location attached to it.
*
*	Arrays and simple variables are represented in this
*	structure.
*
*/
typedef	struct	_var_t {

	/* var_declared_type indicates the type of
	*	the variable as it appears in the source code.
	*
	*	We only support 3 types, void, int and char.
	*
	*	The type void is invalid for variables.
	*/
	IDENT_DEF_DECLARED_TYPE	
		var_declared_type;

	/* lineno.
	*	linenumber where the variable is defined.
	*	This linenumber is the linenumber in the source
	*	file.
	*
	*/
	int				lineno;

	/* var_length indicates the length of
	*  the variable. If the variable is a
	*  integer, it is 4 bytes long else
	*  it is 1 byte long.
	*
	*/
	int	var_length;

	/* offset of the variable into the global
	*   data space or the local stack.
	*
	*/
	int	offset;

	/* if rank is 0, this is just a variable else it is an array 
	*  . Only values of 0 or 1 are valid 
	*/

	int	rank;

	/* if rank is 1, this indicates the dimension of
	*  the array. 
	*
	*/
	int dim;

	/* this indicates whether this is a local variable
	*   , global variable or formal parameters.
	*
	*  In this subset of C formal parameters cannot
	*  be arrays */

	VAR_SUB_TYPE		sub_type;

	/* pFuncPtr is the back pointer to the
	*   function definition for variables that
	*   are defined within a function 
	*
	*	For global variables, this field is set to NULL.
	*
	*	For example, if this variable is a local or a formal
	*	parameter, this field would be valid.
	*
	*/
	struct	_func_t						*pFuncPtr;
} var_t;	

typedef	struct	_func_t
{	
	IDENT_DEF_FUNC_SUB_TYPE	func_sub_type;

	FUNC_DEF_DECLARED_TYPE	func_declared_type;

	/* pFuncSymbolTable is the list of all
	*	variables that are defined within the 
	*	function definition.
	*
	*	This includes all formal parameters and local
	*	variables. Since nested function definitions
	*	are not allowed, this symbol table only
	*	contains symbols within one level.
	*
	*/
	struct	_symtableQ_t		*pFuncSymbolTable;

	/* lineno.
	*	linenumber where the function is defined.
	*	This linenumber is the linenumber in the source
	*	file.
	*
	*/
	int				lineno;

	/* total_formal_parameters.
	*	This indicates the total # of formal parameters
	*	in the function definition.
	*
	*/

	int	total_formal_parameters;

	/* total_length_of_local_variables indicates
	*	in bytes the # of bytes all the local variables
	*	collectively need on the stack.
	*
	*/
	int	total_length_of_local_variables;

	/* cur_local_var_offset is used as a running
	*	counter to keep track of the current local
	*	variable during code generation.
	*
	*
	*/
	
	int				cur_local_var_offset;

	/* cur_formal_param_offset is used as a running
	*	counter to keep track of the current formal
	*	parameter. Is not a reliable counter.
	*
	*/

	int				cur_formal_param_offset;

	/*formal_parameter_stack is a stack used
	*  to push formal parameters as they are seen
	*  in the production rules.
	*
	*/

	int				formal_parameter_stack;

	/* local variable stack is a stack that is used
	*   to push local variables as they are seen in
	*   the declaration list.
	*
	*/

	int				local_variables_stack;

	/* added. Each function now has a 
	*	epilog label. This label is used to
	*	label the epilogue of a function.
	*
	*	At all other points in the function,
	*	whenever a return statement is 
	*	encountered, the code produces
	*	code in the r0 register and puts 
	*	an unconditional jump to this label.
	*
	*	This way, we do not need to duplicate
	*	the code at each return point.
	*
	*/

	int			epilog_label;

} func_t;

/* structure _expr_reg_t.
*	Used to keep track of the register
*	that contains the value of an expression.
*
*	As the parser reduces the symbols using
*	shift-reduce parsing, the register is carried
*
*
*	expr_reg. Identifies the register # in which
*	the value of the expression is contained.
*
*	bSpill. Indicates whether the register needs to
*	be spilt. Normally do not need to use this but
*	is there. If 1, the register needs to spilt onto
*	the stack or some other place.
*/
typedef	struct	_expr_reg_t
{
	int	expr_reg;

	int	bSpill;

	EXPR_TYPE	expr_type;
}	expr_reg_t;

typedef	union	_ident_info_t
{
	/* var is the field containing information
	*	about a variable(local, global or formal).
	*
	*	This field is only valid if the ident_type
	*	field is equal to IDENT_DEF_VARIABLE
	*
	*/
	var_t		var;

	/* func is the field containing information
	*	about the function including its symbol
	*	table.
	*
	*	For variables that are defined within this
	*	function, the variables contain a link to
	*	this field.
	*
	*	This field is only valid if the ident_type
	*	is equal to IDENT_DEF_FUNCTION
	*
	*/
	func_t		func;

	/* If the token is a constant integer, then
	*	this field contains the value of the integer.

	*	Only valid if ident_type == IDENT_DEF_CONST_INT
	*
	*/

	int				const_int;

	/* if the token is an expression, then this field
	*  contains information about the register that
	*	holds the value of the expression.
	*
	*	This field is only valid if ident_type ==
	*	IDENT_DEF_EXPR_REG.
	*
	*/

	expr_reg_t	expr;

	/* If the token is an actual parameter list, then
	*	this field indicates the stack that contains
	*	the actual parameters. When  processing
	*	a function call at the point of generating
	*	code for the function , the token for the
	*	actual parameter list contains the id of the 
	*	stack which hold the actual parameters.
	*
	*/

	int				actual_param_stack;
} ident_info_t;

typedef	struct	_ident_t
{
	IDENT_DEF_TYPE		ident_type;

	ident_info_t			ident_info;
} ident_t;

#endif /* var_def_h */