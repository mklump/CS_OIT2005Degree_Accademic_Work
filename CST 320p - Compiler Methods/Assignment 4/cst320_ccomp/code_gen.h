#ifndef _code_gen_h
#define	_code_gen_h

#ifdef	__cplusplus
extern "C"
{
#endif


#include	"symtable.h"

typedef	int	reg_number_t;


symtableentry_t *
generate_code_for_const_int(
				FILE	*outFile,
				int			const_int
				);

symtableentry_t *
generate_code_add_op(
				FILE	*outFile,
				symtableentry_t		*plhs,
				symtableentry_t		*prhs
				);

symtableentry_t *
generate_code_sub_op(
				FILE	*outFile,
				symtableentry_t		*plhs,
				symtableentry_t		*prhs
				);

symtableentry_t *
generate_code_mult_op(
				FILE	*outFile,
				symtableentry_t		*plhs,
				symtableentry_t		*prhs
				);

symtableentry_t *
generate_code_div_op(
				FILE	*outFile,
				symtableentry_t		*plhs,
				symtableentry_t		*prhs
				);

symtableentry_t *
generate_code_for_lt_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t	*prhs
				);

symtableentry_t *
generate_code_for_gt_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t	*prhs
				);

symtableentry_t *
generate_code_for_lte_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t	*prhs
				);

symtableentry_t *
generate_code_for_gte_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t	*prhs
				);

symtableentry_t *
generate_code_for_eq_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t	*prhs
				);

symtableentry_t *
generate_code_for_ne_op(
				FILE	*outFile,
				symtableentry_t	*plhs,
				symtableentry_t	*prhs
				);

int
generate_label();

void
produce_code_for_break(
					   FILE	*outFile
					   );

void
produce_code_for_continue(
						  FILE	*outFile
						  );

symtableentry_t *
produce_code_for_goto(
					  FILE	*outFile,
					  const char *s
					  );

symtableentry_t *
generate_code_for_labeled_statement(
					  FILE	*outFile,
					  const char *s
					  );

char *
generate_code_for_if_stmt(
						  FILE	*outFile,
						  int		reg_number
						  );

char *
generate_code_for_if_else_stmt(
						FILE	*outFile,
						int		reg_number
						);

int
produce_code_for_logicaland_op(
							FILE	*outFile,
							int lhs_reg,
							int	rhs_reg
							);

int
produce_code_for_logicalor_op(
							FILE	*outFile,
							int lhs_reg,
							int	rhs_reg
							);

int
produce_code_for_assignment(
							FILE	*outFile,
							int lhs_reg,
							int	rhs_reg
							);

void	produce_function_prologue(
								FILE	*outFile,
								symtableentry_t	*pFuncEntry
								);

void	produce_function_epilogue(
								FILE	*outFile,
								symtableentry_t	*pFunc
								);

symtableentry_t *
produce_code_for_var(
					 FILE	*outFile,
					 symtableentry_t	*pVarEntry
					 );

symtableentry_t *
produce_code_for_function_call(
									FILE	*outFile,
									symtableentry_t	*pFuncEntry,
									symtableentry_t	*pActParamSpaceInfo
									);

int
produce_code_for_actual_param(
							  FILE	*outFile,
							  symtableentry_t	*pActParam,
							  int		*p_stack_offset
							  );

void
produce_code_for_selection_expression(
								FILE	*outFile,
								symtableentry_t	*pExpr
								);

void
produce_code_for_while_loop_begin(
								  FILE	*outFile
								  );

void
produce_code_for_else_decision(
							   FILE	*outFile
							   );

void
produce_code_for_if_decision(
								FILE	*outFile
								);

void
produce_code_for_if_decision(
								FILE	*outFile
								);

void
produce_code_for_if_statement(
							  FILE	*outFile
							  );

void
produce_code_for_if_else_statement(
							FILE	*outFile
							);

void
produce_code_for_while_statement(
								FILE	*outFile
								);

symtableentry_t *
process_assignment(
							FILE	*outFile,
							symtableentry_t	*pVarEntry, /* left hand side */
							symtableentry_t	*pRhs
							);

void
process_function_local_variables(
							FILE	*outFile
							);

void
produce_code_for_return_statement(
							FILE	*outFile,
							symtableentry_t	*pExpr
							);

#ifdef __cplusplus
}
#endif

#endif _code_gen_h