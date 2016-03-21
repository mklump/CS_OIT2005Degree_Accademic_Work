#include <stdio.h>
#include <assert.h>
#include <string.h>
#include "cst320_stack.h"
#include "code_gen.h"
#include "cond_stack.h"

extern "C"
{
	extern int lineno;
	extern int func_def_stack;
}

/*
* Function :- generate_code_for_const_int
*
*	Generates code for a constant integer.
*
*	The code just picks a free register and produces
*	code to move the constant to the register.
*
*	If there is no free register, it snatches an existing
*	one( by default 0 ), marks it as split and uses that
*	as the register.
*
*	It returns a token to identify the register that contains
*	the constant value.
*
*
*/
symtableentry_t *
generate_code_for_const_int(
				FILE	*outFile,
				int			const_int
				)
{
	symtableentry_t	*ret;
	bool	bSpill = false;

	ret = create_symbol_table_entry();

	ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
	ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();
	ret->ident_ptr.ident_info.expr.expr_type = EXPR_TYPE_INT;

	if ( ret->ident_ptr.ident_info.expr.expr_reg  == max_reg )
	{
		/* we will choose register 0*/

		ret->ident_ptr.ident_info.expr.expr_reg  = 0;
		bSpill = true;

		/* we will need to spill register 0 */
	}

	if ( true == bSpill )
	{
		fprintf(
				outFile,
				"\tpush	%%r%d	// spill register %d\n",
				ret->ident_ptr.ident_info.expr.expr_reg ,
				ret->ident_ptr.ident_info.expr.expr_reg 
				);
		ret->ident_ptr.ident_info.expr.bSpill = 1;
	}
	else
	{
		ret->ident_ptr.ident_info.expr.bSpill = 0;
	}

	fprintf(
			outFile,
			"\tmov %%r%d,	$%d\n",
			ret->ident_ptr.ident_info.expr.expr_reg,
			const_int
			);

	markRegBusy(ret->ident_ptr.ident_info.expr.expr_reg);

	return	ret;
}

reg_number_t
generate_code_for_const_char(
				FILE	*outFile,
				char		const_char
				)
{
	int	free_reg = getFreeReg();
	bool	bSpill = false;

	if ( free_reg == max_reg )
	{
		/* we will choose register 0*/

		free_reg = 0;
		bSpill = true;

		/* we will need to spill register 0 */
	}

	if ( true == bSpill )
	{
		fprintf(
				outFile,
				"\tpush	%%r%d	// spill register %d\n",
				free_reg,
				free_reg
				);
	}

	fprintf(outFile,
		"\tmov	%%r%d,	$%d //move constant %d into register r%d\n",
		free_reg,
		0,
		0,
		free_reg
		);

	fprintf(outFile,
		"\tmov	%%r%d,	$%d	\n",
		free_reg,
		const_char
		);

	if ( true == bSpill )
	{
		fprintf(outFile,
			"\tpop	%%r%d	//unspill register %d\n",
			free_reg,
			free_reg
			);
	}

	/* we cannot mark the register as free since
	*   this may be used as part of an expression.
	*
	*/
	return	free_reg;
}

int
generate_label()
{
	static	int	label_number = 0;

	label_number += 1;

	return	label_number;
}



void	produce_function_prologue(
								FILE	*outFile,
								symtableentry_t	*pFuncEntry
								)
{
	if ( 0 == strcmp(pFuncEntry->id_name , "main") )
	{
		fprintf(
					outFile,
					"\t^start	\n"
					);

		fprintf(
					outFile,
					"\tpush	%%r14\n",
					pFuncEntry->id_name
					);
	}
	else
	{
		fprintf(
					outFile,
					"\t^%s_func push	%%r14\n",
					pFuncEntry->id_name
					);
	}

	fprintf(
				outFile,
				"\tmov	%%r14,	%%r13\n"
				);
}

void	produce_function_epilogue(
								  FILE	*outFile,
								  symtableentry_t	*pFunc
								)
{

	fprintf(
				outFile,
				"\t^label%d\n",
				pFunc->ident_ptr.ident_info.func.epilog_label
				);

	fprintf(
				outFile,
				"\tmov	%%r13,	%%r14\n"
				);

	fprintf(
				outFile,
				"\tpop	%%r14\n"
				);

	fprintf(
				outFile,
				"\treturn // end of function\n\n"
				);
}

symtableentry_t *
produce_code_for_function_call(
									FILE	*outFile,
									symtableentry_t	*pFuncEntry,
									symtableentry_t	*pActParamSpaceInfo
									)
{
	symtableentry_t	*p_entry = create_symbol_table_entry();
	int		stack_offset = 0;

	symtableentry_t	*pNextActualParam;

	int			total_space_on_stack = 0;

	if ( pActParamSpaceInfo )
	while ( 
		isactParamStackEmpty(pActParamSpaceInfo->ident_ptr.ident_info.actual_param_stack) == 0 )
	{
		pop_act_parameter(
			pActParamSpaceInfo->ident_ptr.ident_info.actual_param_stack,
			&pNextActualParam
			);

		assert(pNextActualParam);
		
		total_space_on_stack += produce_code_for_actual_param(
								outFile,
								pNextActualParam,
								&stack_offset
								);
	}

	fprintf(
				outFile,
				"\tcall	%s_func\n",
				pFuncEntry->id_name
				);

	if ( pActParamSpaceInfo )
	fprintf(
				outFile,
				"\tadd	%%r13,	$%d\n",
				total_space_on_stack
				);

	p_entry->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;

	/* a function used in an expression always has a return type.
	*   the type of the expression is the same as the return type
	*   of the function if any.
	*
	*/

	switch(pFuncEntry->ident_ptr.ident_info.func.func_declared_type)
	{
	case FUNC_DEF_DECLARED_VOID:
		p_entry->ident_ptr.ident_info.expr.expr_type = 
				EXPR_TYPE_VOID;

		break;

	case FUNC_DEF_DECLARED_INT:
		p_entry->ident_ptr.ident_info.expr.expr_type = 
				EXPR_TYPE_INT;

		break;

	case FUNC_DEF_DECLARED_CHAR:
		p_entry->ident_ptr.ident_info.expr.expr_type = 
				EXPR_TYPE_CHAR;

		break;

	case FUNC_DEF_DECLARED_INVALID:
		assert(0);
		break;
	}

	/* a function always returns its value via register r0 */
	p_entry->ident_ptr.ident_info.expr.expr_reg = 0;

	return	p_entry;
}

int
produce_code_for_actual_param(
							  FILE	*outFile,
							  symtableentry_t	*pActParam,
							  int	*p_stack_offset
							  )
{
	int	space_for_param_on_stack = 0;
	/* we could be given a variable or an expression
	*   as a handle here.
	*
	*   If it is an expression it is in a register.
	*	If it is a variable, we know the offset & stuff.
	*	if it is a constant, we know the value.
	*
	*/

	if ( pActParam->ident_ptr.ident_type == IDENT_DEF_VARIABLE )
	{
		/* the variable could be a local variable, global variable
		*   or a formal parameter.
		*
		*	We MUST produce the correct code.
		*
		*/

		switch( pActParam->ident_ptr.ident_info.var.sub_type )
		{
		case VAR_SUB_TYPE_LOCAL_VAR:
			fprintf(
						outFile,
						"\tpush	<%%r13,	$%d, $%d>\n",
						pActParam->ident_ptr.ident_info.var.offset + *p_stack_offset,
						pActParam->ident_ptr.ident_info.var.var_length
						);

			break;

		case VAR_SUB_TYPE_FORMAL_PARAM:
			fprintf(
						outFile,
						"\tpush	<%%r14,	$%d, $%d>\n",
						pActParam->ident_ptr.ident_info.var.offset,
						pActParam->ident_ptr.ident_info.var.var_length
						);

			break;

		case VAR_SUB_TYPE_GLOBAL_VAR:
			fprintf(
						outFile,
						"\tpush	<$0,	$%d, $%d>\n",
						pActParam->ident_ptr.ident_info.var.offset,
						pActParam->ident_ptr.ident_info.var.var_length
						);

			break;

		default:
			assert(0);
			break;
		}

		
		space_for_param_on_stack = 
			pActParam->ident_ptr.ident_info.var.var_length;

		*p_stack_offset = 
			*p_stack_offset + pActParam->ident_ptr.ident_info.var.var_length;
	}
	else if ( pActParam->ident_ptr.ident_type == IDENT_DEF_EXPR_REG )
	{
		fprintf(outFile,
					"\tpush	%%r%d\n",
					pActParam->ident_ptr.ident_info.expr.expr_reg
					);

		space_for_param_on_stack = 4;

		*p_stack_offset = *p_stack_offset + 4;
	}
	else if ( IDENT_DEF_CONSTANT_INT == pActParam->ident_ptr.ident_type )
	{
		fprintf(outFile,
					"\tpush	$%d\n",
					pActParam->ident_ptr.ident_info.const_int
					);

		space_for_param_on_stack = 4;

		*p_stack_offset = *p_stack_offset + 4;
	}
	else
	{
		assert(0);
	}

	return	space_for_param_on_stack ;
}

symtableentry_t *
generate_code_add_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t *prhs
				)
{
	symtableentry_t	*p_ret;

	p_ret = create_symbol_table_entry();

	/* produce code for moving from variable to register
	*  and adding it in register 
	*/

	if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tadd	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tadd	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tadd	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tadd	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tadd	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tadd	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* first operand is a variable get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*/

		fprintf( outFile,
				 "\tadd  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		fprintf( outFile,
				 "\tadd  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else
	{
		assert(0);
	}

	/* an expression that is the product of an addition
	*   is always an integer.
	*
	*/
	p_ret->ident_ptr.ident_info.expr.expr_type = 
		EXPR_TYPE_INT;

	return p_ret;
}

symtableentry_t *
generate_code_sub_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t *prhs
				)
{ 
	symtableentry_t	*p_ret;

	p_ret = create_symbol_table_entry();

	/* produce code for moving from variable to register
	*  and adding it in register 
	*/

	if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tsub	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tsub	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tsub	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tsub	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tsub	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tsub	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* first operand is a variable get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*/

		fprintf( outFile,
				 "\tsub  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		fprintf( outFile,
				 "\tsub  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else
	{
		assert(0);
	}

	/* an expression that is the product of an addition
	*   is always an integer.
	*
	*/
	p_ret->ident_ptr.ident_info.expr.expr_type = 
		EXPR_TYPE_INT;

	return p_ret;
}

symtableentry_t *
generate_code_mult_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t *prhs
				)
{
	symtableentry_t	*p_ret;

	p_ret = create_symbol_table_entry();

	/* produce code for moving from variable to register
	*  and adding it in register 
	*/

	if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmult	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmult	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmult	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmult	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmult	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmult	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* first operand is a variable get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*/

		fprintf( outFile,
				 "\tmult  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		fprintf( outFile,
				 "\tmult  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else
	{
		assert(0);
	}

	/* an expression that is the product of an addition
	*   is always an integer.
	*
	*/
	p_ret->ident_ptr.ident_info.expr.expr_type = 
		EXPR_TYPE_INT;

	return p_ret;
}

symtableentry_t *
generate_code_div_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t *prhs
				)
{
	symtableentry_t	*p_ret;

	p_ret = create_symbol_table_entry();

	/* produce code for moving from variable to register
	*  and adding it in register 
	*/

	if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tdiv	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tdiv	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tdiv	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tdiv	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tdiv	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == prhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tdiv	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					prhs->ident_ptr.ident_info.var.offset,
					prhs->ident_ptr.ident_info.var.var_length
					);
		}
	}
	else if ( IDENT_DEF_VARIABLE == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* first operand is a variable get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			/* produce code to move the lhs of + into
			*  the temporary register
			*
			*	if the variable is a local variable
			*/
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r13,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_GLOBAL_VAR == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<$0, $%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		else if ( VAR_SUB_TYPE_FORMAL_PARAM == plhs->ident_ptr.ident_info.var.sub_type )
		{
			fprintf(
					outFile,
					"\tmov	%%r%d,	<%%r14,	$%d, $%d>\n",
					p_ret->ident_ptr.ident_info.expr.expr_reg,
					plhs->ident_ptr.ident_info.var.offset,
					plhs->ident_ptr.ident_info.var.var_length
					);
		}
		
		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*/

		fprintf( outFile,
				 "\tdiv  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else if ( IDENT_DEF_EXPR_REG == plhs->ident_ptr.ident_type &&
			IDENT_DEF_EXPR_REG == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		/* now produce the code to add the value of the 2nd variable
		* to the temporary register.
		*
		*/

		fprintf( outFile,
				 "\tdiv  %%r%d, %%r%d\n",
				 p_ret->ident_ptr.ident_info.expr.expr_reg,
				 prhs->ident_ptr.ident_info.expr.expr_reg );
		markRegFree( prhs->ident_ptr.ident_info.expr.expr_reg );
	}
	else
	{
		assert(0);
	}

	/* an expression that is the product of an addition
	*   is always an integer.
	*
	*/
	p_ret->ident_ptr.ident_info.expr.expr_type = 
		EXPR_TYPE_INT;

	return p_ret;
}

symtableentry_t *
generate_code_for_lt_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t	*prhs
				)
{
	symtableentry_t	*p_ret = NULL;

	int	cond_true_label;
	int	cond_out_label;

	p_ret = create_symbol_table_entry();

	if ( plhs->ident_ptr.ident_type == IDENT_DEF_VARIABLE &&
			IDENT_DEF_VARIABLE == prhs->ident_ptr.ident_type )
	{
		/* both operands are variables get a temporary register
		*	we will return this register as the result of this
		*	expression evaluation
		*/

		char	*plhs_offset_str, *prhs_offset_str;

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			plhs_offset_str = "%r13";
		}
		else if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_GLOBAL_VAR )
		{
			plhs_offset_str	=	"$0";
		}
		else if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_FORMAL_PARAM)
		{
			plhs_offset_str	=	"%r14";
		}

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			prhs_offset_str = "%r13";
		}
		else if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_GLOBAL_VAR )
		{
			prhs_offset_str	=	"$0";
		}
		else if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_FORMAL_PARAM)
		{
			prhs_offset_str	=	"%r14";
		}

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = getFreeReg();

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		cond_true_label = generate_label();

		cond_out_label = generate_label();

		fprintf(
				outFile,
				"\tjmp	{lt, <%s, $%d, $%d>, <%s, $%d, $%d>}, label%d\n",
				plhs_offset_str,
				plhs->ident_ptr.ident_info.var.offset,
				plhs->ident_ptr.ident_info.var.var_length,
				prhs_offset_str,
				prhs->ident_ptr.ident_info.var.offset,
				prhs->ident_ptr.ident_info.var.var_length,
				cond_true_label
				);

		fprintf(outFile,
				"\tmov	%%r%d, $0\n",
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t	jmp	{}, label%d\n",
				cond_out_label
				);

		fprintf(
				outFile,
				"\t^label%d	mov	%%r%d,	$1\n",
				cond_true_label,
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t^label%d\n",
				cond_out_label
				);
	}
	else if ( plhs->ident_ptr.ident_type == IDENT_DEF_EXPR_REG &&
				prhs->ident_ptr.ident_type == IDENT_DEF_EXPR_REG
				)
	{
		/* both are expressions and their values are in registers */

		cond_true_label = generate_label();

		cond_out_label = generate_label();

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);
		markRegFree(prhs->ident_ptr.ident_info.expr.expr_reg);

		fprintf(
				outFile,
				"\tjmp	{lt, %%r%d, %%r%d }, label%d\n",
				plhs->ident_ptr.ident_info.expr.expr_reg,
				prhs->ident_ptr.ident_info.expr.expr_reg,
				cond_true_label
				);

		fprintf(outFile,
				"\tmov	%%r%d, $0\n",
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t	jmp	{}, label%d\n",
				cond_out_label
				);

		fprintf(
				outFile,
				"\t^label%d	mov	%%r%d,	$1\n",
				cond_true_label,
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t^label%d\n",
				cond_out_label
				);
	}
	else if ( plhs->ident_ptr.ident_type == IDENT_DEF_EXPR_REG &&
				prhs->ident_ptr.ident_type == IDENT_DEF_VARIABLE
				)
	{
		/* lhs is an expression and the rhs is a variable.
		*/

		char	*prhs_offset_str;

		if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			prhs_offset_str = "%r13";
		}
		else if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_GLOBAL_VAR )
		{
			prhs_offset_str	=	"$0";
		}
		else if ( prhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_FORMAL_PARAM)
		{
			prhs_offset_str	=	"%r14";
		}

		cond_true_label = generate_label();

		cond_out_label = generate_label();

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			plhs->ident_ptr.ident_info.expr.expr_reg;

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		fprintf(
				outFile,
				"\tjmp	{lt, %%r%d, <%s, $%d, $%d> }, label%d\n",
				p_ret->ident_ptr.ident_info.expr.expr_reg,
				prhs_offset_str,
				prhs->ident_ptr.ident_info.var.offset,
				prhs->ident_ptr.ident_info.var.var_length,
				cond_true_label
				);

		fprintf(outFile,
				"\tmov	%%r%d, $0\n",
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t	jmp	{}, label%d\n",
				cond_out_label
				);

		fprintf(
				outFile,
				"\t^label%d	mov	%%r%d,	$1\n",
				cond_true_label,
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t^label%d\n",
				cond_out_label
				);
	}
	else if ( plhs->ident_ptr.ident_type == IDENT_DEF_VARIABLE &&
				prhs->ident_ptr.ident_type == IDENT_DEF_EXPR_REG
				)
	{
		/* lhs is an expression and the rhs is a variable.
		*/

		char	*plhs_offset_str;

		if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_LOCAL_VAR )
		{
			plhs_offset_str = "%r13";
		}
		else if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_GLOBAL_VAR )
		{
			plhs_offset_str	=	"$0";
		}
		else if ( plhs->ident_ptr.ident_info.var.sub_type == VAR_SUB_TYPE_FORMAL_PARAM)
		{
			plhs_offset_str	=	"%r14";
		}

		cond_true_label = generate_label();

		cond_out_label = generate_label();

		p_ret->ident_ptr.ident_type = IDENT_DEF_EXPR_REG;
		p_ret->ident_ptr.ident_info.expr.expr_reg = 
			prhs->ident_ptr.ident_info.expr.expr_reg;

		markRegBusy(p_ret->ident_ptr.ident_info.expr.expr_reg);

		fprintf(
				outFile,
				"\tjmp	{lt, <%s, $%d, $%d> , %%r%d}, label%d\n",
				plhs_offset_str,
				plhs->ident_ptr.ident_info.var.offset,
				plhs->ident_ptr.ident_info.var.var_length,
				p_ret->ident_ptr.ident_info.expr.expr_reg,
				cond_true_label
				);

		fprintf(outFile,
				"\tmov	%%r%d, $0\n",
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t	jmp	{}, label%d\n",
				cond_out_label
				);

		fprintf(
				outFile,
				"\t^label%d	mov	%%r%d,	$1\n",
				cond_true_label,
				p_ret->ident_ptr.ident_info.expr.expr_reg
				);

		fprintf(
				outFile,
				"\t^label%d\n",
				cond_out_label
				);
	}
	else {
		assert(0);
	}

	/* although the result of this function is a boolean
	*   value, since in C all booleans are int, we return
	*	an integer.
	*
	*/
	p_ret->ident_ptr.ident_info.expr.expr_type = 
		EXPR_TYPE_INT;

	return	p_ret;
}

void
produce_code_for_while_loop_begin(
								  FILE	*outFile
								  )
{
		condition_stack_item_t	item;
		item.cond_code	=	cond_while;
		item._while.while_label	=	generate_label();
		item._while.out_while_label	=	generate_label();
		fprintf(outFile,"^label%d\n", item._while.while_label);
		push_condition_item(&item);
}
void
produce_code_for_selection_expression(
								FILE	*outFile,
								symtableentry_t	*pExpr
								)
{
		condition_stack_item_t	Item, *pItem;
		char	*expr_offset_str;

		/* expression is either a register or a variable */
		
		pItem = get_tos_condition_stack(&Item);
		
		if ( pItem->cond_code == cond_if )
		{
			if ( IDENT_DEF_EXPR_REG == pExpr->ident_ptr.ident_type )
			{
				fprintf(outFile,"jmp	{eq, %%r%d, $0}, label%d\n",
								pExpr->ident_ptr.ident_info.expr.expr_reg,
								pItem->_if.if_label);

			}
			else if ( IDENT_DEF_VARIABLE == pExpr->ident_ptr.ident_type)
			{

				if ( VAR_SUB_TYPE_LOCAL_VAR == pExpr->ident_ptr.ident_info.var.sub_type )
				{
					expr_offset_str = "%r13";
				}
				else 
					if ( VAR_SUB_TYPE_GLOBAL_VAR ==
						pExpr->ident_ptr.ident_info.var.sub_type
						)
					{
						expr_offset_str = "$0";
					}
					else
						if (VAR_SUB_TYPE_FORMAL_PARAM ==
							pExpr->ident_ptr.ident_info.var.sub_type 
							)
						{
							expr_offset_str	=	"%r14";
						}
						else
						{
							assert(0);
						}
							
				fprintf(outFile,"jmp	{eq, <%s, $%d, $%d>, $0}, label%d\n",
								expr_offset_str,
								pExpr->ident_ptr.ident_info.var.offset,
								pExpr->ident_ptr.ident_info.var.var_length,
								pItem->_if.if_label);
			}
			else
			{
				assert(0);
			}
		}
		else if (cond_while == pItem->cond_code )
		{
			if ( IDENT_DEF_EXPR_REG == pExpr->ident_ptr.ident_type )
			{
				fprintf(outFile,"jmp	{eq, %%r%d, $0}, label%d\n",
								pExpr->ident_ptr.ident_info.expr.expr_reg,
								pItem->_while.out_while_label);

			}
			else if ( IDENT_DEF_VARIABLE == pExpr->ident_ptr.ident_type)
			{
				if ( VAR_SUB_TYPE_LOCAL_VAR == pExpr->ident_ptr.ident_info.var.sub_type )
				{
					expr_offset_str = "%r13";
				}
				else 
					if ( VAR_SUB_TYPE_GLOBAL_VAR ==
						pExpr->ident_ptr.ident_info.var.sub_type
						)
					{
						expr_offset_str = "$0";
					}
					else
						if (VAR_SUB_TYPE_FORMAL_PARAM ==
							pExpr->ident_ptr.ident_info.var.sub_type 
							)
						{
							expr_offset_str	=	"%r14";
						}
						else
						{
							assert(0);
						}

				fprintf(outFile,"jmp	{eq, <%s, $%d, $%d>, $0}, label%d\n",
								expr_offset_str,
								pExpr->ident_ptr.ident_info.var.offset,
								pExpr->ident_ptr.ident_info.var.var_length,
								pItem->_while.out_while_label
								);

			}
		}
}

void
produce_code_for_else_decision(
							   FILE	*outFile
							   )
{
	condition_stack_item_t	item, *pItem, new_item;

	pItem = pop_condition_item(&item);

	new_item.cond_code	=	cond_if_else;
	new_item.if_else.out_if_else_label	=	generate_label();

	push_condition_item(&new_item);

	fprintf(outFile,"jmp	{},	label%d\n", new_item.if_else.out_if_else_label);
	fprintf(outFile,"^label%d\n",item._if.if_label);
}

void
produce_code_for_if_decision(
								FILE	*outFile
								)
{
		condition_stack_item_t	item;
		item.cond_code	=	cond_if;

		item._if.if_label	=	generate_label();
		push_condition_item(&item);
}

void
produce_code_for_if_statement(
							  FILE	*outFile
							  )
{
		condition_stack_item_t	item, *pItem;

		pItem	=	pop_condition_item(&item);

		assert(pItem->cond_code == cond_if);

		fprintf(
			outFile,
			"^label%d\n",
			pItem->_if.if_label
			);
}

void
produce_code_for_if_else_statement(
							FILE	*outFile
							)
{
		condition_stack_item_t	item,	*pItem;

		pItem = pop_condition_item(&item);

		assert(pItem->cond_code == cond_if_else);

		fprintf(
					outFile,
					"^label%d\n",
					pItem->if_else.out_if_else_label
					);
}

void
produce_code_for_while_statement(
								FILE	*outFile
								)
{
		condition_stack_item_t	item,	*pItem;

		pItem	=	pop_condition_item(&item);

		assert(pItem->cond_code == cond_while);

		fprintf(
			outFile,
			"jmp	{},	label%d\n", 
			pItem->_while.while_label
			);

		fprintf(
			outFile,
			"^label%d\n", 
			pItem->_while.out_while_label
			);
}
/* Process the code for assignment.
*   the lhs MUST be a variable.
*	the rhs may be a variable or an expression.
*
*	In either case, the types MUST match.
*
*	we always return the left hand side 
*	of the assignment as our return value.
*
*	remember, this is not optimized code because
*	if the assignment is used in another expression,
*	we will be generating a memory move.
*/
symtableentry_t *
process_assignment(
							FILE	*outFile,
							symtableentry_t	*pVarEntry, /* left hand side */
							symtableentry_t	*pRhs
							)
{
	/* 
	*  assert that the left hand side is indeed a variable.
	*
	*/
	if ( pVarEntry->ident_ptr.ident_type != IDENT_DEF_VARIABLE )
	{
		printf("cst320 : ccomp. error file[%s] line[%d] source line[%d]. lhs of assignment is not a l-value\n",
				__FILE__,__LINE__, lineno
				);

		assert(0);
	}
	else
	{
		/* produce the code for the case where the right hand side is an expression.
		*
		*/

		/* produce code only for formal parameters,
		*	local variables and global variables.
		*
		*/

		if ( pRhs->ident_ptr.ident_type  == IDENT_DEF_EXPR_REG)
		{
			printf("cst320.ccompiler. error file[%s] line[%d] source line[%d] error[%s]\n",
				__FILE__,__LINE__, lineno,
				"type of rhs is void or incompatible with the lhs"
				);

			assert(pRhs->ident_ptr.ident_info.expr.expr_type != EXPR_TYPE_VOID);
			assert(pRhs->ident_ptr.ident_info.expr.expr_type != EXPR_TYPE_INVALID);

			switch (pVarEntry->ident_ptr.ident_info.var.sub_type )
			{
			case VAR_SUB_TYPE_LOCAL_VAR:
				fprintf(
							outFile,
							"\tmov	<%%r13, $%d, $%d>,	%%r%d\n",
							pVarEntry->ident_ptr.ident_info.var.offset,
							pVarEntry->ident_ptr.ident_info.var.var_length,
							pRhs->ident_ptr.ident_info.expr.expr_reg
							);

				/* local variable */
				break;

			case VAR_SUB_TYPE_FORMAL_PARAM:

				fprintf(
							outFile,
							"\tmov	<%%r14, $%d, $%d>,	%%r%d\n",
							pVarEntry->ident_ptr.ident_info.var.offset, 
							pVarEntry->ident_ptr.ident_info.var.var_length,
							pRhs->ident_ptr.ident_info.expr.expr_reg
							);
				break;

			case VAR_SUB_TYPE_GLOBAL_VAR:
				fprintf(
							outFile,
							"\tmov	<$0, $%d, $%d>,	%%r%d\n",
							pVarEntry->ident_ptr.ident_info.var.offset,
							pVarEntry->ident_ptr.ident_info.var.var_length,
							pRhs->ident_ptr.ident_info.expr.expr_reg
							);
				break;

			default:
				assert(0);
				break;
			}

			/* mark the register containing the rhs as being free */
			markRegFree(pRhs->ident_ptr.ident_info.expr.expr_reg);
		}
		else if ( pRhs->ident_ptr.ident_type  == IDENT_DEF_VARIABLE )
		{
			char *plhs_offset_str = NULL;
			char *prhs_offset_char =NULL;

			/* this is the case where the right hand side is also a variable.
			*
			*	first assert that the right hand side type is not void.
			*/

			printf("cst320.ccompiler. error file[%s] line[%d] source line[%d] error[%s]\n",
				__FILE__,__LINE__, lineno,
				"type of rhs is void or incompatible with the lhs"
				);
			assert(pRhs->ident_ptr.ident_info.var.var_declared_type != IDENT_DEF_DECLARED_VOID);
			assert(pRhs->ident_ptr.ident_info.var.var_declared_type != IDENT_DEF_DECLARED_INVALID);

			switch (pVarEntry->ident_ptr.ident_info.var.sub_type )
			{
			case VAR_SUB_TYPE_LOCAL_VAR:
				plhs_offset_str = "%r13";
				break;
			case VAR_SUB_TYPE_FORMAL_PARAM:
				plhs_offset_str = "%r14";
				break;
			case VAR_SUB_TYPE_GLOBAL_VAR:
				plhs_offset_str = "$0";
				break;

			default:
				assert(0);
				break;
			}

			switch (pRhs->ident_ptr.ident_info.var.sub_type )
			{
			case VAR_SUB_TYPE_LOCAL_VAR:
				prhs_offset_char = "%r13";
				break;
			case VAR_SUB_TYPE_FORMAL_PARAM:
				prhs_offset_char = "%r14";
				break;
			case VAR_SUB_TYPE_GLOBAL_VAR:
				prhs_offset_char = "$0";
				break;

			default:
				assert(0);
				break;
			}

			fprintf(
				outFile,
				"\tmov	<%s, $%d, $%d>, <%s, $%d, $%d>\n",
				plhs_offset_str,
				pVarEntry->ident_ptr.ident_info.var.offset,
				pVarEntry->ident_ptr.ident_info.var.var_length,
				prhs_offset_char,
				pRhs->ident_ptr.ident_info.var.offset,
				pRhs->ident_ptr.ident_info.var.var_length
				);
		}
	}

	return	pVarEntry;
}

/* function :- process_function_local_variables.
*	We are invoked at this point when we see the
*	end of all declarations and are ready to see the
*	first executable statement.
*
*/
void
process_function_local_variables(
							FILE	*outFile
							)
{
	symtableentry_t	*pCurrentFunction;

	symtableentry_t	*pCurLocalVar;

	if ( isFuncDefStackEmpty(func_def_stack) == 0 )
	{
		get_top_function(
								func_def_stack,
								&pCurrentFunction
								);

		assert(pCurrentFunction->ident_ptr.ident_type == IDENT_DEF_FUNCTION);

		pCurrentFunction->ident_ptr.ident_info.func.cur_local_var_offset = 
			0;

		pCurrentFunction->ident_ptr.ident_info.func.total_length_of_local_variables =
			0;
		
		while ( isFormalParamStackEmpty(
					pCurrentFunction->ident_ptr.ident_info.func.local_variables_stack
					) == 0 )
		{
			pop_formal_parameter(
					pCurrentFunction->ident_ptr.ident_info.func.local_variables_stack,
					&pCurLocalVar
					);

			assert(pCurLocalVar);

			pCurLocalVar->ident_ptr.ident_info.var.offset =
				pCurrentFunction->ident_ptr.ident_info.func.cur_local_var_offset;

			pCurrentFunction->ident_ptr.ident_info.func.cur_local_var_offset  =
				pCurrentFunction->ident_ptr.ident_info.func.cur_local_var_offset + 
				pCurLocalVar->ident_ptr.ident_info.var.var_length;

			pCurrentFunction->ident_ptr.ident_info.func.total_length_of_local_variables =
				pCurrentFunction->ident_ptr.ident_info.func.total_length_of_local_variables +
				pCurLocalVar->ident_ptr.ident_info.var.var_length;
		}

		/* now produce one single statement to actually reduce the stack
		*	by that much size.
		*
		*/

		fprintf(
					outFile,
					"\tsub	%%r13,	$%d  //create space for local variables\n",
					pCurrentFunction->ident_ptr.ident_info.func.total_length_of_local_variables
					);
	}
}

void
produce_code_for_return_statement(
							FILE	*outFile,
							symtableentry_t	*pExpr
							)
{
	/* The expression could be either a constant,
	*   an expression or a variable.
	*
	*	In all cases, we move the value of the expression
	*	into the register r0. We assume that the register
	*	r0 is available.( we will not check to see if it is free ).
	*
	*/

	symtableentry_t		*pCurFunction = NULL;

	get_top_function(
								func_def_stack,
								&pCurFunction
								);

	assert(pCurFunction);
	assert( IDENT_DEF_FUNCTION == pCurFunction->ident_ptr.ident_type );

	switch( pExpr->ident_ptr.ident_type )
	{
	case IDENT_DEF_CONSTANT_INT:
		fprintf(
				outFile,
				"\tmov	%%r0,	$%d\n",
				pExpr->ident_ptr.ident_info.const_int
				);

		fprintf(
				outFile,
				"\tjmp {}, label%d\n",
				pCurFunction->ident_ptr.ident_info.func.epilog_label
				);

		break;

	case IDENT_DEF_EXPR_REG:
		if ( pExpr->ident_ptr.ident_info.expr.expr_reg == 0 )
		{
			/* do nothing. the expression is in register 0
			*   and we want the result in 0
			*
			*/
		}
		else
		{
			fprintf(
					outFile,
					"\tmov	%%r0, %%r%d\n",
					pExpr->ident_ptr.ident_info.expr.expr_reg
					);

			/* mark the register as being free */
			markRegFree(pExpr->ident_ptr.ident_info.expr.expr_reg);
		}

		fprintf(
				outFile,
				"\tjmp {}, label%d\n",
				pCurFunction->ident_ptr.ident_info.func.epilog_label
				);
		break;

	case IDENT_DEF_VARIABLE:
		/* The variable could be a global variable,
		*	a formal parameter or a local variable.
		*
		*/

		switch(pExpr->ident_ptr.ident_info.var.sub_type )
		{
		case VAR_SUB_TYPE_LOCAL_VAR:
			fprintf(
						outFile,
						"\tmov	%%r0,	<%%r13,	$%d, $%d>\n",
						pExpr->ident_ptr.ident_info.var.offset,
						pExpr->ident_ptr.ident_info.var.var_length
						);
			break;

		case VAR_SUB_TYPE_FORMAL_PARAM:
			fprintf(
						outFile,
						"\tmov	%%r0,	<%%r14,	$%d, $%d>\n",
						pExpr->ident_ptr.ident_info.var.offset,
						pExpr->ident_ptr.ident_info.var.var_length
						);
			break;

		case VAR_SUB_TYPE_GLOBAL_VAR:
			fprintf(
						outFile,
						"\tmov	%%r0,	<$0, $%d, $%d>\n",
						pExpr->ident_ptr.ident_info.var.offset,
						pExpr->ident_ptr.ident_info.var.var_length
						);
			break;
		}

		fprintf(
				outFile,
				"\tjmp {}, label%d\n",
				pCurFunction->ident_ptr.ident_info.func.epilog_label
				);

		break;

	default:
		assert(0);
		break;
	}
}