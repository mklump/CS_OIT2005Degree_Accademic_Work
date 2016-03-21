/*--------------------------------------------------------------------
// Author:        Matthew Klump  mklump1@comcast.net
//				  CST 320p Compiler Methods
// Date Created:  5 May 2003
// Submission Date:  9 May 2003
// Project:        Assign3
// Filename:       Assign3.h
//
//
// Overview:	Performs Semantic Analysis on a given source code file
//     	        as outlined in the language described by the Assignment 3
//				description.
//
// Input:       Any source code writen that is described by the language.
//
// Output:		Provides the value of a program described by the language.
//
//------------------------------------------------------------------*/
#ifndef ASSIGN3_H
#define ASSIGN3_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <malloc.h>

struct variable
{
	char *name; /* name of the struct variable */
	int	value;  /* value of the struct variable as an integer *only*  */
};

#define MAX_SIZE	512
struct variable vbltable[MAX_SIZE];
struct variable *varRetVal;

extern int program_value; /* final value of the program interpreted */

struct variable*
put_Var(const char *name, int value);

struct variable*
get_Var(const char *name);

void
yyerror(const char *s);

#endif // ASSIGN3_H
