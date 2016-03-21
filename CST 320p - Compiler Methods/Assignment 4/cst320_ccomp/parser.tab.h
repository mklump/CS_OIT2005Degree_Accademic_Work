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
     IDENTIFIER = 258,
     TYPEDEF_NAME = 259,
     FLOATING = 260,
     CHARACTER = 261,
     STRING = 262,
     ELLIPSIS = 263,
     ADDEQ = 264,
     SUBEQ = 265,
     MULEQ = 266,
     DIVEQ = 267,
     MODEQ = 268,
     XOREQ = 269,
     ANDEQ = 270,
     OREQ = 271,
     SL = 272,
     SR = 273,
     SLEQ = 274,
     SREQ = 275,
     EQ = 276,
     NOTEQ = 277,
     LTEQ = 278,
     GTEQ = 279,
     ANDAND = 280,
     OROR = 281,
     PLUSPLUS = 282,
     MINUSMINUS = 283,
     ARROW = 284,
     AUTO = 285,
     BREAK = 286,
     CASE = 287,
     CHAR = 288,
     CONST = 289,
     CONTINUE = 290,
     DEFAULT = 291,
     DO = 292,
     DOUBLE = 293,
     ELSE = 294,
     ENUM = 295,
     EXTERN = 296,
     FLOAT = 297,
     FOR = 298,
     GOTO = 299,
     IF = 300,
     INT = 301,
     LONG = 302,
     REGISTER = 303,
     RETURN = 304,
     SHORT = 305,
     SIGNED = 306,
     SIZEOF = 307,
     WHILE = 308,
     VOID = 309,
     INTEGER = 310
   };
#endif
#define IDENTIFIER 258
#define TYPEDEF_NAME 259
#define FLOATING 260
#define CHARACTER 261
#define STRING 262
#define ELLIPSIS 263
#define ADDEQ 264
#define SUBEQ 265
#define MULEQ 266
#define DIVEQ 267
#define MODEQ 268
#define XOREQ 269
#define ANDEQ 270
#define OREQ 271
#define SL 272
#define SR 273
#define SLEQ 274
#define SREQ 275
#define EQ 276
#define NOTEQ 277
#define LTEQ 278
#define GTEQ 279
#define ANDAND 280
#define OROR 281
#define PLUSPLUS 282
#define MINUSMINUS 283
#define ARROW 284
#define AUTO 285
#define BREAK 286
#define CASE 287
#define CHAR 288
#define CONST 289
#define CONTINUE 290
#define DEFAULT 291
#define DO 292
#define DOUBLE 293
#define ELSE 294
#define ENUM 295
#define EXTERN 296
#define FLOAT 297
#define FOR 298
#define GOTO 299
#define IF 300
#define INT 301
#define LONG 302
#define REGISTER 303
#define RETURN 304
#define SHORT 305
#define SIGNED 306
#define SIZEOF 307
#define WHILE 308
#define VOID 309
#define INTEGER 310




#if ! defined (YYSTYPE) && ! defined (YYSTYPE_IS_DECLARED)
#line 79 "parser.y"
typedef union YYSTYPE {
	symtableentry_t	*pEntry;

	int						decl_type;
} YYSTYPE;
/* Line 1252 of yacc.c.  */
#line 153 "parser.tab.h"
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
# define YYSTYPE_IS_TRIVIAL 1
#endif

extern YYSTYPE yylval;



