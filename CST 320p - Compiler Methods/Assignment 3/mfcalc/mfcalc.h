#ifndef _mfcalc_h
#define _mfcalc_h

#include <stdio.h>

#ifdef __cplusplus
extern "C"
{
#endif

typedef int (*func_t)(int val);

typedef	union	identDetails {
	int	offset;
} identDetails_t;
typedef struct symrec
{
	char *name; /* name of the symbol */
	int type; /* type of symbol. either VAR or FUNCT */
	identDetails_t	value;
} symrec;

extern symrec	sym_table[];

symrec *putsym(const char *, int type);
symrec *getsym(const char *);

void	init_table();

int exec_function(symrec *function, int exp);

int read_int();

static const int max_reg = 16;

int
produce_code_for_constant(
										FILE	*outFile,
										int		exp
										);

int
produce_code_for_var(
					 FILE	*outFile,
					 symrec	*ptr_to_sym_table
					 );

int
produce_code_for_assignment(
					FILE	*outFile,
					symrec	*ptr_to_variable,
					int		exp_reg_number
					);

int
produce_code_for_op(
					FILE	*outFile,
					int		lhs_exp_reg,
					int		rhs_exp_reg,
					int		op_code
					);

int
produce_code_for_paren(
					FILE	*outFile,
					int		exp_reg_number
					);

void
produce_return_from_start(
						  FILE	*outFile
						  );


int
produce_code_for_func_call(
						FILE	*outFile,
						symrec	*symrec,
						int		exp_reg_number
						);

int
produce_code_for_read_call(
						   FILE	*outFile
						   );


void
init_cpu();

int
getFreeReg();

void
markRegFree(int regNum);

void
markRegBusy(int regNum);

#ifdef __cplusplus
}
#endif

#endif