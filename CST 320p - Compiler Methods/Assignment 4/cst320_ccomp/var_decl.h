#ifndef _var_decl_h
#define	_var_decl_h

#include	<stdio.h>
#include "symtable.h"
#include "parser.tab.h"

void
process_local_var_definition(
							 FILE	*outFile,
							 int	var_type,
							 symtableentry_t	*pVarEntry,
							 symtableentry_t	*pFuncEntry
							 );

void
process_global_var_definition(
							 int	var_type,
							 symtableentry_t	*pVarEntry
							 );

void
process_formal_param_declaration(
							int	var_type,
							symtableentry_t	*pVarEntry
							);

#endif	_var_decl_h