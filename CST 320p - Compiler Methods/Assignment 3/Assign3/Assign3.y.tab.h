/* A Bison parser, made by GNU Bison 1.875b.  */

/* Skeleton parser for Yacc-like parsing with Bison,
   Copyright (C) 1984, 1989, 1990, 2000, 2001, 2002, 2003 Free Software Foundation, Inc.

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2, or (at your option)
   any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program; if not, write to the Free Software
   Foundation, Inc., 59 Temple Place - Suite 330,
   Boston, MA 02111-1307, USA.  */

/* As a special exception, when this file is copied by Bison into a
   Bison output file, you may use that output file without restriction.
   This special exception was added by the Free Software Foundation
   in version 1.24 of Bison.  */

/* Tokens.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
   /* Put the tokens into the symbol table, so that GDB and other debuggers
      know about them.  */
   enum yytokentype {
     START = 258,
     END = 259,
     VAR = 260,
     PRINT = 261,
     READ = 262,
     IF = 263,
     THEN = 264,
     ELSE = 265,
     INTEGER = 266,
     ASSIGN_OP = 267,
     RPAREN = 268,
     LPAREN = 269,
     MINUS_OP = 270,
     PLUS_OP = 271,
     MODULO_OP = 272,
     DIVIDE_OP = 273,
     MULT_OP = 274,
     COLON = 275,
     SEMI = 276,
     COMMA = 277,
     ID = 278,
     NUMBER = 279
   };
#endif
#define START 258
#define END 259
#define VAR 260
#define PRINT 261
#define READ 262
#define IF 263
#define THEN 264
#define ELSE 265
#define INTEGER 266
#define ASSIGN_OP 267
#define RPAREN 268
#define LPAREN 269
#define MINUS_OP 270
#define PLUS_OP 271
#define MODULO_OP 272
#define DIVIDE_OP 273
#define MULT_OP 274
#define COLON 275
#define SEMI 276
#define COMMA 277
#define ID 278
#define NUMBER 279




#if ! defined (YYSTYPE) && ! defined (YYSTYPE_IS_DECLARED)
#line 31 "Assign3.y.c"
typedef union YYSTYPE {
	int exp_type; /* simply a 32-bit integer */
	struct variable *var_rec;   /* value type of struct variables */
} YYSTYPE;
/* Line 1252 of yacc.c.  */
#line 90 "Assign3.y.tab.h"
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
# define YYSTYPE_IS_TRIVIAL 1
#endif

extern YYSTYPE yylval;



