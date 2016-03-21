#include	<assert.h>
#include "symtable.h"
#include "func_decl.h"
#include "code_gen.h"

extern int lineno;

void
process_function_definition(
							symtableentry_t	*pFuncEntry
							)
{
	/* we have the symbol entry for a function.
	*  we could be seeing the definition or declaration
	*	of a function. It does not matter what it is.
	*	We just process it. Unless we can lookahead and see a ;
	*	or { } we will not know if it is a declaration or a
	*	definition.
	*
	*/

	int	temp_stack;
	symtableentry_t	*pNextFormalParam;

	symtableentry_t	*next_item;

	int		total_formal_parameters = 0;

	int	formal_param_offset;

	temp_stack = initialize_stack();

	pFuncEntry->ident_ptr.ident_info.func.local_variables_stack =
		initialize_formal_param_stack();

	assert(IDENT_DEF_FUNCTION == pFuncEntry->ident_ptr.ident_type);

	/* generate a label that we will use as the target for the 
	*	epilogue of the function.
	*
	*/

	pFuncEntry->ident_ptr.ident_info.func.epilog_label =
		generate_label();

	/* retrieve each formal parameter. Remember that the last declared
	*	is on the top of the stack.
	*
	*	We need to reverse them so we can give correct offsets to each
	*	variable.
	*
	*	At this point, all we do is to just set up their offsets and their types.
	*
	*	To 
	*/

	pFuncEntry->ident_ptr.ident_info.func.cur_formal_param_offset = 0;
	pFuncEntry->ident_ptr.ident_info.func.cur_local_var_offset = 0;
	pFuncEntry->ident_ptr.ident_info.func.total_length_of_local_variables = 0;

	while ( 
		isFormalParamStackEmpty(pFuncEntry->ident_ptr.ident_info.func.formal_parameter_stack) == 0 
		)
	{
		pop_formal_parameter(
										pFuncEntry->ident_ptr.ident_info.func.formal_parameter_stack,
										&pNextFormalParam
										);

		pNextFormalParam->ident_ptr.ident_info.var.pFuncPtr = 
			&pFuncEntry->ident_ptr.ident_info.func;

		pFuncEntry->ident_ptr.ident_info.func.total_length_of_local_variables =
			pFuncEntry->ident_ptr.ident_info.func.total_length_of_local_variables + 
				pNextFormalParam->ident_ptr.ident_info.var.var_length;

		push_item(
						temp_stack,
						(void *) pNextFormalParam
						);
	}
	
	formal_param_offset = pFuncEntry->ident_ptr.ident_info.func.cur_formal_param_offset;

	while ( isStackEmpty(temp_stack) == 0 )
	{
		next_item = (symtableentry_t*)pop_item(temp_stack);

		total_formal_parameters += 1;

		next_item->ident_ptr.ident_info.var.offset = 
			formal_param_offset  + 8;

		formal_param_offset += 
			next_item->ident_ptr.ident_info.var.var_length;
	}

	pFuncEntry->ident_ptr.ident_info.func.total_formal_parameters = 
		total_formal_parameters;

	pFuncEntry->ident_ptr.ident_info.func.lineno = lineno;
}