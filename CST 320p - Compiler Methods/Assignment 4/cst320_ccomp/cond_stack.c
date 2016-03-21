#include <stdio.h>
#include <malloc.h>
#include "cond_stack.h"

const	int	max_items = 300;

static	int	g_Tos = -1;

static	condition_stack_item_t	*g_Stack[300];

void
initialize_condition_stack() {
	g_Tos	=	-1;
}

void
push_condition_item(
					condition_stack_item_t	*pItem
					)
{
	condition_stack_item_t	*p_new_item  =
		(condition_stack_item_t *) malloc(sizeof(condition_stack_item_t));
	*p_new_item	=	*pItem;
	g_Tos += 1;
	g_Stack[g_Tos] = p_new_item;
}

condition_stack_item_t	*
pop_condition_item(
				   condition_stack_item_t	*pItemToReturn
				   )
{
	condition_stack_item_t	*p_item = NULL;

	if ( g_Tos == -1 )
	{
		return	NULL;
	}
	else
	{
		p_item	=	g_Stack[g_Tos];

		*pItemToReturn	=	*p_item;

		free(p_item);

		g_Tos -= 1;

		p_item	=	pItemToReturn;
	}

	return	pItemToReturn;
}

condition_stack_item_t	*
get_tos_condition_stack(
						condition_stack_item_t	*pItemToReturn
						)
{
	if ( g_Tos == -1 )
	{
		return NULL;
	}
	else
	{
		*pItemToReturn	=	*(g_Stack[g_Tos]);
		return	pItemToReturn;
	}
}