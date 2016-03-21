#ifndef _symtable_h
#define	_symtable_h

#ifdef __cplusplus
extern "C"
{
#endif

#include "var_def.h"

typedef	struct	_symtableentry_t
{
	struct	_symtableentry_t	*p_next;
	char	*id_name;

	ident_t			ident_ptr;
} symtableentry_t;

typedef struct	_symtableQ_t
{
	symtableentry_t	*pFront;
	symtableentry_t	*pTail;
} symtableQ_t;

symtableQ_t	*
create_symbol_table();

void
clear_symbol_table(symtableQ_t *Q);

void
insert_symbol(
			  symtableQ_t		*pQ,
			  symtableentry_t	*pSym
			  );

symtableentry_t *
getSymtablePtr(
			   symtableQ_t	*pQ,
			   const char	*name
			   );

symtableentry_t *
create_symbol_table_entry();

void
allocate_offset_for_var(
						symtableentry_t	*pEntry
						);

/* 
* function :- get_ident_entry() returns a pointer to
* the entry in the symbol table for a symbol with the name.
*
* It searches both the current function's symbol table as well
* as the global symbol table.
*
*/
symtableentry_t *
get_ident_entry(
				const	char *s
				);

symtableentry_t *
isSymbolPresentInLocalScope(
				const	char	*s
				);

symtableentry_t *
isSymbolPresentInGlobalScope(
				const	char	*s
				);

static const int max_reg = 16;

/* register services */

/* get a Free Register */
int
getFreeReg();

/* mark the register free */
void
markRegFree(int reg);

/* mark the register busy */
void
markRegBusy(int reg);

int
isSymbolVariable(
				 symtableentry_t	*pSymbol
				 );

int
isSymbolExpression(
				symtableentry_t	*pExpr
				);

int 
isVariableLocalVariable(
						symtableentry_t	*pVar
						);

int
isVariableGlobalVariable(
						 symtableentry_t	*pVar
						 );

int
isVariableFormalParameter(
						  symtableentry_t	*pVar
						  );

int
getVarOffset(
			 symtableentry_t	*pVar
			 );

int
getVarLengthInBytes(
			symtableentry_t	*pVar
			);

int
getFunctionLocalStorageInBytes(
			symtableentry_t	*pVar
			);

void
init_reg_list();

#ifdef __cplusplus
}
#endif


#endif	_symtable_h