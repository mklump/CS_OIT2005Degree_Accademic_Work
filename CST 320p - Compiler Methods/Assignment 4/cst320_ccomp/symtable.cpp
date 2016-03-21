#include <stdio.h>
#include <malloc.h>
#include <string.h>
#include <assert.h>
#include "cst320_stack.h"
#include "symtable.h"

extern "C"
{
	extern int lineno;
}

static	int	g_DataOffset = 0;

symtableQ_t *
create_symbol_table()
{

	symtableQ_t	*pSymTableHead = 
		(symtableQ_t *)malloc(sizeof(symtableQ_t));

	pSymTableHead->pFront= NULL;
	pSymTableHead->pTail = NULL;


	return pSymTableHead;
}

void
insert_symbol(
			  symtableQ_t	*pHead,
			  symtableentry_t	*pSym
			  )
{
	if ( pHead->pFront == NULL )
	{
		pHead->pFront = pSym;

		pHead->pTail = pSym;
	}
	else
	{
		pHead->pTail->p_next = pSym;
		pHead->pTail = pSym;
	}
}

symtableentry_t *
getSymtablePtr(
			   symtableQ_t	*pQ,
			   const char	*name
			   )
{
	symtableentry_t	*ptemp;

	ptemp = pQ->pFront;

	while (ptemp)
	{
		if ( 0 == strcmp(name, ptemp->id_name) )
		{
			return ptemp;
		}
		ptemp = ptemp->p_next;
	}

	return NULL;
}

class	Reg
{
private:
	int	m_number;

	bool	m_busy;

public:
	Reg(int num) { m_number = num;  m_busy = false; }

	void	setBusy() { m_busy = true; }

	void	setFree() { m_busy = false; }

	bool	isFree() { return (true == m_busy) ? false : true; }

};

static Reg	*reg_list[max_reg];

int
getFreeReg()
{
	int i;

	for ( i = 0; i < max_reg; i++ )
	{
		if ( reg_list[i]->isFree() == true )
			return	i;
	}

	printf("CST320 CCOMP. error file[%s] line[%d]. no more free registers. source file line[%d]\n",
		__FILE__,__LINE__, lineno
		);
	assert(0);
	return	max_reg;
}

/* mark the register free */
void
markRegFree(int reg)
{
	reg_list[reg]->setFree();
}

/* mark the register busy */
void
markRegBusy(int reg)
{
	reg_list[reg]->setBusy();
}

extern "C"
void
init_reg_list()
{
	int	i;
	for ( i = 0; i < max_reg; i++ )
	{
		reg_list[i] = new Reg(i);

		reg_list[i]->setFree();
	}
}

symtableentry_t *
create_symbol_table_entry()
{
	symtableentry_t *pEntry;

	pEntry = (symtableentry_t *) malloc(sizeof(symtableentry_t));

	memset(pEntry, 0, sizeof(symtableentry_t));

	pEntry->id_name = NULL;
	pEntry->p_next = NULL;

	pEntry->ident_ptr.ident_type = IDENT_DEF_INVALID;

	return	pEntry;
}

void
allocate_offset_for_var(
						symtableentry_t	*pEntry
						)
{
	assert(IDENT_DEF_VARIABLE == pEntry->ident_ptr.ident_type);

	switch(pEntry->ident_ptr.ident_info.var.sub_type)
	{
		case VAR_SUB_TYPE_GLOBAL_VAR :

			pEntry->ident_ptr.ident_info.var.offset = g_DataOffset;

			g_DataOffset += pEntry->ident_ptr.ident_info.var.var_length ;
			break;

		case VAR_SUB_TYPE_LOCAL_VAR:
			pEntry->ident_ptr.ident_info.var.offset = 
				pEntry->ident_ptr.ident_info.var.pFuncPtr->cur_local_var_offset;

			pEntry->ident_ptr.ident_info.var.pFuncPtr->cur_local_var_offset = 
				pEntry->ident_ptr.ident_info.var.var_length + 
				pEntry->ident_ptr.ident_info.var.pFuncPtr->cur_local_var_offset ;
			break;

		case VAR_SUB_TYPE_FORMAL_PARAM:
			/* mark the offset correctly. account for the return address */
			pEntry->ident_ptr.ident_info.var.offset =
				pEntry->ident_ptr.ident_info.var.pFuncPtr->cur_formal_param_offset + 4;

			pEntry->ident_ptr.ident_info.var.pFuncPtr->cur_formal_param_offset += 
				pEntry->ident_ptr.ident_info.var.var_length ;
			break;

		default:
			assert(0);
			break;
	}
}


extern "C"
{
extern	symtableQ_t	*g_SymbolTable;

int			func_def_stack;
}

symtableentry_t *
get_ident_entry(
				const	char *s
				)
{
	symtableentry_t	*retValue = NULL;

	/* If we are within a function definition
	*	, we could be a formal parameter within
	*	the function or a local variable.
	*
	*
	*/

	if ( isFuncDefStackEmpty(func_def_stack) == 0 )
	{
		symtableentry_t	*pFuncEntry;

		get_top_function(
									func_def_stack,
									&pFuncEntry
									);

		assert(pFuncEntry);

		retValue = 
			getSymtablePtr(
									pFuncEntry->ident_ptr.ident_info.func.pFuncSymbolTable,
									s
									);
	}

	if ( retValue ) 
		return retValue;

	if ( NULL == retValue )
	{
		retValue = getSymtablePtr(
								g_SymbolTable,
								s
								);
	}

	return retValue;
}

void
clear_symbol_table(symtableQ_t	*Q)
{
	Q->pFront = NULL;
	Q->pTail = NULL;
}

symtableentry_t *
isSymbolPresentInLocalScope(
				const	char	*s
				)
{
	symtableentry_t	*retValue = NULL;

	/* If we are within a function definition
	*	, we could be a formal parameter within
	*	the function or a local variable.
	*
	*
	*/

	if ( isFuncDefStackEmpty(func_def_stack) == 0 )
	{
		symtableentry_t	*pFuncEntry;

		get_top_function(
									func_def_stack,
									&pFuncEntry
									);

		assert(pFuncEntry);

		retValue = 
			getSymtablePtr(
									pFuncEntry->ident_ptr.ident_info.func.pFuncSymbolTable,
									s
									);
	}

	return retValue;
}

symtableentry_t *
isSymbolPresentInGlobalScope(
				const	char	*s
				)
{
	symtableentry_t	*retValue;

	retValue = getSymtablePtr(
							g_SymbolTable,
							s
							);

	return retValue;
}