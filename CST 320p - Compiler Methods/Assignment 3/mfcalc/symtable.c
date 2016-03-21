#include <stdio.h>
#include <string.h>
#include "mfcalc.h"
#include "mfcalc.tab.h"

FILE		*g_ILOutFile = NULL;

symrec	sym_table[300];
int g_curentry = 0;

int	g_curdataoffset = 0;

int addbyone(int val)
{
	return val + 1;
}

int subbyone(int val)
{
	return val-1;
}

int readint(int val)
{
	int temp;
	scanf("%d", &temp);

	return temp;
}

int printvalue(int val)
{
	printf("%d\n",val);
	return val;
}

void
write_function_prologue(
						FILE	*outFile
						)
{
	fprintf(
				outFile,
				"\tpush	%%r14	//Save bp register\n"
				);

	fprintf(
				outFile,
				"\tmov	%%r14,	%%r13	// bp <- sp\n"
				);
}

void
write_function_epilogue(
						FILE	*outFile
						)
{
	fprintf(
				outFile,
				"\tmov	%%r13,	%%r14	// sp <- bp\n"
				);

	fprintf(
				outFile,
				"\tpop	%%r14	// restore bp\n"
				);

	fprintf(
				outFile,
				"\treturn	// return back to caller\n\n"
				);
}

void
compile_code(
			 FILE	*outFile,
			 const char *func_name
			 )
{
	char	func_entry_label[1000];

	if ( 0 == strcmp(func_name,"start") )
		sprintf(func_entry_label,"^%s\t // function entry point\n", func_name);
	else
		sprintf(func_entry_label,"^%s_func\t // function entry point\n", func_name);

	fprintf(
				outFile,
				"%s",
				func_entry_label
				);

	/* we write out the 
	*  prologue for the function
	*/

	write_function_prologue(
		outFile
		);



	/* all of our functions 
	*   use the r0 register as the 
	*   return value.
	*  
	*   Register r0 need not be saved.
	*/

	if ( 0 == strcmp(func_name,"add") )
	{
		fprintf(
					outFile,
					"\tmov	%%r0,	<%%r14, $8, $4>	// r0 <- stack[sp+8]\n"
					);

		fprintf(
					outFile,
					"\tadd	%%r0,	<%%r14, $12, $4>  // r0 <- r0 + stack[bp+12]\n"
					);
	}
	else if ( 0 == strcmp(func_name,"sub") )
	{
		fprintf(
					outFile,
					"\tmov	%%r0,	<%%r14, $8, $4>	// r0 <- stack[bp+8]\n"
					);

		fprintf(
					outFile,
					"\tsub	%%r0,	<%%r14, $12, $4>  // r0 <- r0 - stack[bp+12]\n"
					);
	}
	else if ( 0 == strcmp(func_name,"print") )
	{
		fprintf(
					outFile,
					"\tmov	%%r0,	<%%r14, $8, $4>	// r0 <- stack[sp+8]\n"
					);

		fprintf(
					outFile,
					"\tprint	%%r0	// print value of r0\n"
					);
	}
	else if ( 0 == strcmp(func_name,"read") )
	{
		fprintf(
					outFile,
					"\taccept	%%r0	// read integer into r0\n"
					);
	}
	else if ( 0 == strcmp(func_name, "start") )
	{
		/* for the start function, we do not write
		*  the epilogue since we need to spit out
		*  the code. We will write it out someother
		*  place.
		*
		*	
		*
		*/

		return;
	}

	write_function_epilogue(
		outFile
		);
}

void init_table()
{
	int i;
	symrec *rec;

	for ( i  = 0; i < 300; i++ )
	{
		sym_table[i].name = NULL;
	}

	rec = putsym("add",FUNC);
	compile_code(
		g_ILOutFile, 
		"add"
		);
	//rec->value.fnctptr = addbyone;
	
	rec = putsym("sub", FUNC);
	compile_code(
		g_ILOutFile,
		"sub"
		);
	//rec->value.fnctptr = subbyone;

	rec = putsym("read", FUNC);
	compile_code(
		g_ILOutFile,
		"read"
		);
	//rec->value.fnctptr = readint;
	rec->type = INPUT_FUNCTION; /* indicate a different type */

	rec = putsym("print", FUNC);
	compile_code(
		g_ILOutFile,
		"print"
		);
	//rec->value.fnctptr = printvalue;

	compile_code(
		g_ILOutFile,
		"start"
		);
}

symrec *
putsym(const char *name, int type)
{
	symrec *return_value;
	sym_table[g_curentry].name = strdup(name);
	sym_table[g_curentry].type = type;

	return_value = &sym_table[g_curentry];

	g_curentry += 1;

	return return_value;
}

symrec *
getsym(const char *name)
{
	int i;
	symrec *entry = NULL;

	for ( i = 0 ; i < g_curentry; i++ )
	{
		if ( 0 == strcmp( sym_table[i].name, name) )
		{
			return &sym_table[i];
		}

	}
	return NULL;
}

int exec_function(symrec *function, int exp)
{
	// return (*(function->value.fnctptr))(exp);
	return 1;
}

int read_int()
{
	return readint(0);
}

void yyerror(const char *s)
{
	printf("%s\n",s);
}

int yywrap()
{
	return 1;
}

int
produce_code_for_constant(
						  FILE	*outFile,
						  int exp
						  )
{
	int	reg_to_use;

	reg_to_use = getFreeReg();

	fprintf(outFile,
				"\tmov	%%r%d,	$%d	// rx<- constant\n",
				reg_to_use,
				exp
				);

	return	reg_to_use;
}

int
produce_code_for_var(
					 FILE	*outFile,
					 symrec	*ptr_to_sym_table
					 )
{
	int	reg_to_use;

	reg_to_use	=	getFreeReg();

	/*
	*  allocate an offset to the variable.
	*
	*
	*/

	fprintf(
			outFile,
			"\tmov	%%r%d,	<$0,	$%d,	$4>	// move var into register\n",
			reg_to_use,
			ptr_to_sym_table->value.offset
			);

	return	reg_to_use;
}

int
produce_code_for_assignment(
					FILE	*outFile,
					symrec	*ptr_to_variable,
					int	exp_reg_number
					)
{
	fprintf(
		outFile,
		"\tmov	<$0,	$%d,	$4>,	%%r%d	//move from reg to memory\n",
		ptr_to_variable->value.offset,
		exp_reg_number
		);

	return	exp_reg_number;
}

int
produce_code_for_op(
					FILE	*outFile,
					int		lhs_exp_reg,
					int		rhs_exp_reg,
					int		op_code
					)
{
	fprintf(
			outFile,
			"\tpush	%%r%d	//push parameter onto stack\n",
			rhs_exp_reg
			);

	fprintf(
			outFile,
			"\tpush	%%r%d	//push parameter onto stack\n",
			lhs_exp_reg
			);
	if ( 1 == op_code )
	{
		/* plus */
		fprintf(
				outFile,
				"\tcall	add_func\n"
				);
	}
	else if ( 2 == op_code )
	{
		fprintf(
				outFile,
				"\tcall	sub_func\n"
				);
	}

	fprintf(
				outFile,
				"\tadd	%%r13,	$8	// adjust the stack\n"
				);

	return	0;	/* all the functions above always return their values in register 0 */
}

int
produce_code_for_paren(
					FILE	*outFile,
					int		exp_reg_number
					)
{
	// no code to produce for parantheses
	return	exp_reg_number;
}

void
produce_return_from_start(
						  FILE	*outFile
						  )
{
	fprintf(
		outFile,
		"\tmov	%%r13,	%%r14	// sp <- bp\n"
		);

	fprintf(
		outFile,
		"\tpop	%%r14	//restore bp\n"
		);

#ifdef _DEBUG
	fprintf(
		outFile,
		"\tprintreg	//print all the registers for fun\n"
		);
#endif

	fprintf(
		outFile,
		"\treturn	//return from main function\n"
		);
}

int
produce_code_for_func_call(
						FILE	*outFile,
						symrec	*symrec,
						int		exp_reg_number
						)
{
	if ( 0 == strcmp(symrec->name, "add") )
	{
		/* produce code for pushing 1 and exp reg number
		*   onto the stack.
		*
		*/

		fprintf(
					outFile,
					"\tpush	$1	// add(x) <-  add_func(x,1)\n"
					);

		fprintf(
			outFile,
			"\tpush	%%r%d	// push register onto stack\n",
			exp_reg_number
			);

		fprintf(
			outFile,
			"\tcall	add_func	// call intrinsic add function for add(x)\n"
			);

		fprintf(
			outFile,
			"\tadd	%%r13,	$8	//remove parameters from stack\n"
			);
	}
	else if ( 0== strcmp(symrec->name, "sub") )
	{
		fprintf(
					outFile,
					"\tpush	$1	// add(x) <-  add_func(x,1)\n"
					);

		fprintf(
			outFile,
			"\tpush	%%r%d	// push register onto stack\n",
			exp_reg_number
			);

		fprintf(
			outFile,
			"\tcall	sub_func	// call intrinsic sub function for sub(x)\n"
			);

		fprintf(
			outFile,
			"\tadd	%%r13,	$4	//remove parameter from stack\n"
			);
	}
	else if ( 0 == strcmp(symrec->name, "print") )
	{
		fprintf(
			outFile,
			"\tpush	%%r%d	// push register onto stack\n",
			exp_reg_number
			);

		fprintf(
			outFile,
			"\tcall	print_func	// call intrinsic print function for print(x)\n"
			);

		fprintf(
			outFile,
			"\tadd	%%r13,	$4	//remove parameter from stack\n"
			);
	}
	return 0;
}

int
produce_code_for_read_call(
						   FILE	*outFile
						   )
{
	fprintf(
		outFile,
		"\tcall	read_func	// call intrinsic read function for read(x)\n"
		);

	/* the read_function always returns its results in register 0 */
	return 0;
}