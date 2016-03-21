#include <stdio.h>
#include <malloc.h>
#include <assert.h>
#include "cst320_stack.h"

const int initial_capacity = 200;

typedef	struct	_stack_t
{
	int	tos;

	void	**stack_stor;

	int	length;

} stack_t;

int
initialize_stack()
{
	stack_t	*pStack = (stack_t *)malloc(sizeof(stack_t));

	pStack->tos = -1;

	pStack->stack_stor = (void **) malloc(initial_capacity * sizeof(void*));

	pStack->length = initial_capacity;

	return	(int) pStack;
}

void
push_item(
		  int	stack_id,
		  void	*item
		  )
{
	stack_t	*pStack = (stack_t *) stack_id;

	pStack->tos += 1;
	pStack->stack_stor[pStack->tos] = item;
}

void *
pop_item(
		 int stack_id
		 )
{
	void	*item_to_return = NULL;
	stack_t	*pStack = (stack_t *) stack_id;

	if ( pStack->tos < 0 )
	{
		assert(0);
	}
	else
	{
		item_to_return	=	pStack->stack_stor[pStack->tos];
		pStack->tos -= 1;
	}
	return item_to_return;
}

int
isStackEmpty(int stack_id)
{
	stack_t	*pStack = (stack_t *) stack_id;

	if ( pStack->tos < 0 )
		return 1;
	else
		return 0;
}

int  label_stack[300];

int			tos_label_stack = -1;

void
initialize_label_stack()
{
}

void
push_label(
		   int	label
		   )
{
	tos_label_stack += 1;
	label_stack[tos_label_stack] = label;
}

int
pop_label()
{
	int	top;

	top = label_stack[tos_label_stack];

	tos_label_stack -= 1;

	return top;
}

typedef	struct	_expression_stack_t
{
	symtableentry_t	**pExpressionStack;

	int							tos;	/* top of the stack */

	int						stack_size;
}	expression_stack_t, func_def_stack_t;

int
initialize_expression_stack()
{
	expression_stack_t	*p_new_stack;

	p_new_stack = (expression_stack_t	*)malloc(sizeof(expression_stack_t));

	p_new_stack->stack_size = 1000;

	p_new_stack->pExpressionStack = 
	(symtableentry_t **)malloc(sizeof(symtableentry_t *) * p_new_stack->stack_size);

	p_new_stack->tos = -1;

	return	(int)	p_new_stack;
}

void
push_expression_item(
					int	stack_id,
					 symtableentry_t	*pItem
					 )
{
	expression_stack_t	*pStack;

	pStack	=	(expression_stack_t	*) stack_id;

	pStack->tos += 1;

	pStack->pExpressionStack[pStack->tos] = pItem;
}

symtableentry_t **
pop_expression_item(
					int	stack_id,
					symtableentry_t	**ppItem
					)
{

	expression_stack_t	*pStack;

	pStack	=	(expression_stack_t	*) stack_id;

	assert(pStack->tos >= 0);

	*ppItem	=	pStack->pExpressionStack[pStack->tos];

	pStack->tos -= 1;

	return	ppItem;
}

int
initialize_formal_param_stack()
{
	expression_stack_t	*p_new_stack;

	p_new_stack = (expression_stack_t	*)malloc(sizeof(expression_stack_t));

	p_new_stack->stack_size = 1000;

	p_new_stack->pExpressionStack = 
	(symtableentry_t **)malloc(sizeof(symtableentry_t *) * p_new_stack->stack_size);

	p_new_stack->tos = -1;

	return	(int)	p_new_stack;
}

void
push_formal_parameter(
					int	stack_id,
					 symtableentry_t	*pItem
					 )
{
	expression_stack_t	*pStack;

	pStack	=	(expression_stack_t	*) stack_id;

	//assert(VAR_SUB_TYPE_FORMAL_PARAM == pItem->ident_ptr.ident_info.var.sub_type);

	pStack->tos += 1;

	pStack->pExpressionStack[pStack->tos] = pItem;
}

symtableentry_t	**
pop_formal_parameter(
					int	formal_parameter_stack,
					symtableentry_t		**ppItem
					)
{

	expression_stack_t	*pStack;

	pStack	=	(expression_stack_t	*) formal_parameter_stack;

	assert(pStack->tos >= 0);

	*ppItem	=	pStack->pExpressionStack[pStack->tos];

	pStack->tos -= 1;

	return	ppItem;
}

int
isFormalParamStackEmpty(int formal_parameter_stack)
{
	expression_stack_t	*pStack;

	pStack	=	(expression_stack_t	*) formal_parameter_stack;

	return	( (pStack->tos < 0) ? 1 : 0 );

}

int
init_function_def_stack()
{
	func_def_stack_t	*p_new_stack;

	p_new_stack = (func_def_stack_t	*)malloc(sizeof(func_def_stack_t));

	p_new_stack->stack_size = 1000;

	p_new_stack->pExpressionStack = 
	(symtableentry_t **)malloc(sizeof(symtableentry_t *) * p_new_stack->stack_size);

	p_new_stack->tos = -1;

	return	(int)	p_new_stack;
}

void
push_func_def(
			  int	func_def_stack,
			  symtableentry_t	*func_def_entry
			  )
{
	func_def_stack_t	*p_func_def_stack;

	p_func_def_stack = (func_def_stack_t *) func_def_stack;

	p_func_def_stack->tos += 1;

	p_func_def_stack->pExpressionStack[p_func_def_stack->tos] = 
		func_def_entry;
}

symtableentry_t	**
pop_func_def(
					int	func_def_stack,
					symtableentry_t		**ppItem
					)
{
	func_def_stack_t	*p_func_def_stack;

	p_func_def_stack = (func_def_stack_t *) func_def_stack;

	assert(p_func_def_stack->tos >= 0);

	*ppItem	=	p_func_def_stack->pExpressionStack[p_func_def_stack->tos];

	p_func_def_stack->tos -= 1;

	return	ppItem;
}

int
isFuncDefStackEmpty(int func_def_stack)
{
	func_def_stack_t	*p_func_def_stack;

	p_func_def_stack = (func_def_stack_t *) func_def_stack;

	return	( (p_func_def_stack->tos < 0) ? 1 : 0 );
}

symtableentry_t	**
get_top_function(
					int	func_def_stack,
					symtableentry_t		**ppItem
					)
{
	func_def_stack_t	*p_func_def_stack;

	p_func_def_stack = (func_def_stack_t *) func_def_stack;

	assert(p_func_def_stack->tos >= 0);

	*ppItem	=	p_func_def_stack->pExpressionStack[p_func_def_stack->tos];

	return	ppItem;
}

int
initialize_act_param_stack()
{
	return	initialize_formal_param_stack();
}

void
push_act_parameter(
					  int	act_parameter_stack,
					  symtableentry_t	*entry
					  )
{
	expression_stack_t	*pStack;

	pStack	=	(expression_stack_t	*) act_parameter_stack;

	pStack->tos += 1;

	pStack->pExpressionStack[pStack->tos] = entry;
}

symtableentry_t	**
pop_act_parameter(
					int	act_parameter_stack,
					symtableentry_t		**ppItem
					)
{
	expression_stack_t	*pStack;

	pStack	=	(expression_stack_t	*) act_parameter_stack;

	assert(pStack->tos >= 0);

	*ppItem	=	pStack->pExpressionStack[pStack->tos];

	pStack->tos -= 1;

	return	ppItem;
}

int
isactParamStackEmpty(int act_parameter_stack)
{
	return	isFormalParamStackEmpty(act_parameter_stack);
}