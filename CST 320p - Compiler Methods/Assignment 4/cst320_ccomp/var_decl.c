#include <assert.h>
#include "cst320_stack.h"
#include "var_decl.h"

extern int lineno;

void
process_local_var_definition(
							FILE	*outFile,
							 int	var_type,
							 symtableentry_t	*pVarEntry,
							 symtableentry_t	*pFuncEntry
							 )
{
	pVarEntry->ident_ptr.ident_info.var.sub_type =
		VAR_SUB_TYPE_LOCAL_VAR;

	pVarEntry->ident_ptr.ident_type = IDENT_DEF_VARIABLE;

	switch(var_type)
	{
	case VOID:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_VOID;

			assert(0);

			break;

		case INT:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_INT;

			pVarEntry->ident_ptr.ident_info.var.var_length = 4;

			break;

		case CHAR:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_CHAR;

			pVarEntry->ident_ptr.ident_info.var.var_length = 1;

			break;

		default:
			assert(0);
			break;

	}

	pVarEntry->ident_ptr.ident_info.var.pFuncPtr = 
		&pFuncEntry->ident_ptr.ident_info.func;

	/* do not allocate the offset for variable yet.
	*   This is because we do not yet know what the
	*	offset would be. We could have more
	*	local variables after us. We just push onto the
	*	functions' local variable stack. When all the local
	*	variable declarations are done, then we pop off
	*	each one and assign the offset.
	*
	*/

	push_formal_parameter(
						pFuncEntry->ident_ptr.ident_info.func.local_variables_stack,
						pVarEntry
						);

#if 0
	allocate_offset_for_var(
							pVarEntry
							);

	/* produce the code to subtract the 
	*	required offset from the stack pointer
	*
	*/

	fprintf(
				outFile,
				"\tsub	%%r13,	$%d\n",
				pVarEntry->ident_ptr.ident_info.var.var_length
				);
#endif
}

void
process_global_var_definition(
							 int	var_type,
							 symtableentry_t	*pVarEntry
							 )
{
	pVarEntry->ident_ptr.ident_info.var.sub_type =
			VAR_SUB_TYPE_GLOBAL_VAR;

	pVarEntry->ident_ptr.ident_type = IDENT_DEF_VARIABLE;

	switch(var_type)
	{
	case VOID:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_VOID;

			assert(0);

			break;

		case INT:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_INT;

			pVarEntry->ident_ptr.ident_info.var.var_length = 4;

			break;

		case CHAR:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_CHAR;

			pVarEntry->ident_ptr.ident_info.var.var_length = 1;

			break;

		default:
			assert(0);
			break;

	}

	allocate_offset_for_var(
							pVarEntry
							);

}

void
process_formal_param_declaration(
							int	var_type,
							symtableentry_t	*pVarEntry
							)
{
	pVarEntry->ident_ptr.ident_info.var.sub_type = 
		VAR_SUB_TYPE_FORMAL_PARAM;

	pVarEntry->ident_ptr.ident_type = IDENT_DEF_VARIABLE;

	switch(var_type)
	{
	case VOID:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_VOID;

			assert(0);

			break;

		case INT:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_INT;

			pVarEntry->ident_ptr.ident_info.var.var_length = 4;

			break;

		case CHAR:
			pVarEntry->ident_ptr.ident_info.var.var_declared_type =
				IDENT_DEF_DECLARED_CHAR;

			pVarEntry->ident_ptr.ident_info.var.var_length = 1;

			break;

		default:
			assert(0);
			break;
	}
}

