#ifndef		_stack_h
#define		_stack_h

#ifdef	__cplusplus
extern "C"
{
#endif

#include "symtable.h"

int
initialize_stack();

void
push_item(
			int	stack_id,
			void	*item
			);

void *
pop_item(
		 int	stack_id
		 );

int
isStackEmpty(int stack_id);


void
initialize_label_stack();

void
push_label(
			int	label
			);

int
pop_label();

int
initialize_expression_stack();

void
push_expression_item(
					int	stack_id,
					 symtableentry_t	*pItem
					 );

symtableentry_t **
pop_expression_item(
					int	stack_id,
					symtableentry_t	**ppItem
					);

int
initialize_formal_param_stack();

void
push_formal_parameter(
					  int	formal_parameter_stack,
					  symtableentry_t	*entry
					  );

symtableentry_t	**
pop_formal_parameter(
					int	formal_parameter_stack,
					symtableentry_t		**ppItem
					);

int
isFormalParamStackEmpty(int formal_parameter_stack);

int
init_function_def_stack();

void
push_func_def(
			  int	func_def_stack,
			  symtableentry_t	*func_def_entry
			  );

symtableentry_t	**
pop_func_def(
					int	func_def_stack,
					symtableentry_t		**ppItem
					);

int
isFuncDefStackEmpty(int func_def_stack);

symtableentry_t **
get_top_function(
					int	func_def_stack,
					symtableentry_t	**ppFuncDef
					);

int
initialize_act_param_stack();

void
push_act_parameter(
					  int	act_parameter_stack,
					  symtableentry_t	*entry
					  );

symtableentry_t	**
pop_act_parameter(
					int	act_parameter_stack,
					symtableentry_t		**ppItem
					);

int
isactParamStackEmpty(int act_parameter_stack);


#ifdef __cplusplus
}
#endif

#endif _stack_h