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

/* Written by Richard Stallman by simplifying the original so called
   ``semantic'' parser.  */

/* All symbols defined below should begin with yy or YY, to avoid
   infringing on user name space.  This should be done even for local
   variables, as they might otherwise be expanded by user macros.
   There are some unavoidable exceptions within include files to
   define necessary library symbols; they are noted "INFRINGES ON
   USER NAME SPACE" below.  */

/* Identify Bison output.  */
#define YYBISON 1

/* Skeleton name.  */
#define YYSKELETON_NAME "yacc.c"

/* Pure parsers.  */
#define YYPURE 0

/* Using locations.  */
#define YYLSP_NEEDED 0



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




/* Copy the first part of user declarations.  */
#line 34 "parser.y"

#include <stdio.h>
#include	<assert.h>
#include	<malloc.h>
#include	<string.h>


extern int lineno;

static void yyerror(const char *s);

#include "cst320_stack.h"
#include "code_gen.h"
#include "cond_stack.h"
#include	"var_decl.h"
#include	"func_decl.h"

#define YYDEBUG 1

int			g_globalLevel = 1;

int			func_def_stack;

symtableQ_t	*g_SymbolTable = NULL;

FILE			*g_outFile;

/* If in a function, g_curFunction points to 
*   the entry in the main symbol table.
*
*/
symtableentry_t		*g_curFunction = NULL;


/* Enabling traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif

/* Enabling verbose error messages.  */
#ifdef YYERROR_VERBOSE
# undef YYERROR_VERBOSE
# define YYERROR_VERBOSE 1
#else
# define YYERROR_VERBOSE 0
#endif

#if ! defined (YYSTYPE) && ! defined (YYSTYPE_IS_DECLARED)
#line 79 "parser.y"
typedef union YYSTYPE {
	symtableentry_t	*pEntry;

	int						decl_type;
} YYSTYPE;
/* Line 191 of yacc.c.  */
#line 226 "parser.tab.c"
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
# define YYSTYPE_IS_TRIVIAL 1
#endif



/* Copy the second part of user declarations.  */


/* Line 214 of yacc.c.  */
#line 238 "parser.tab.c"

#if ! defined (yyoverflow) || YYERROR_VERBOSE

/* The parser invokes alloca or malloc; define the necessary symbols.  */

# if YYSTACK_USE_ALLOCA
#  define YYSTACK_ALLOC alloca
# else
#  ifndef YYSTACK_USE_ALLOCA
#   if defined (alloca) || defined (_ALLOCA_H)
#    define YYSTACK_ALLOC alloca
#   else
#    ifdef __GNUC__
#     define YYSTACK_ALLOC __builtin_alloca
#    endif
#   endif
#  endif
# endif

# ifdef YYSTACK_ALLOC
   /* Pacify GCC's `empty if-body' warning. */
#  define YYSTACK_FREE(Ptr) do { /* empty */; } while (0)
# else
#  if defined (__STDC__) || defined (__cplusplus)
#   include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#   define YYSIZE_T size_t
#  endif
#  define YYSTACK_ALLOC malloc
#  define YYSTACK_FREE free
# endif
#endif /* ! defined (yyoverflow) || YYERROR_VERBOSE */


#if (! defined (yyoverflow) \
     && (! defined (__cplusplus) \
	 || (YYSTYPE_IS_TRIVIAL)))

/* A type that is properly aligned for any stack member.  */
union yyalloc
{
  short yyss;
  YYSTYPE yyvs;
  };

/* The size of the maximum gap between one aligned stack and the next.  */
# define YYSTACK_GAP_MAXIMUM (sizeof (union yyalloc) - 1)

/* The size of an array large to enough to hold all stacks, each with
   N elements.  */
# define YYSTACK_BYTES(N) \
     ((N) * (sizeof (short) + sizeof (YYSTYPE))				\
      + YYSTACK_GAP_MAXIMUM)

/* Copy COUNT objects from FROM to TO.  The source and destination do
   not overlap.  */
# ifndef YYCOPY
#  if 1 < __GNUC__
#   define YYCOPY(To, From, Count) \
      __builtin_memcpy (To, From, (Count) * sizeof (*(From)))
#  else
#   define YYCOPY(To, From, Count)		\
      do					\
	{					\
	  register YYSIZE_T yyi;		\
	  for (yyi = 0; yyi < (Count); yyi++)	\
	    (To)[yyi] = (From)[yyi];		\
	}					\
      while (0)
#  endif
# endif

/* Relocate STACK from its old location to the new one.  The
   local variables YYSIZE and YYSTACKSIZE give the old and new number of
   elements in the stack, and YYPTR gives the new location of the
   stack.  Advance YYPTR to a properly aligned location for the next
   stack.  */
# define YYSTACK_RELOCATE(Stack)					\
    do									\
      {									\
	YYSIZE_T yynewbytes;						\
	YYCOPY (&yyptr->Stack, Stack, yysize);				\
	Stack = &yyptr->Stack;						\
	yynewbytes = yystacksize * sizeof (*Stack) + YYSTACK_GAP_MAXIMUM; \
	yyptr += yynewbytes / sizeof (*yyptr);				\
      }									\
    while (0)

#endif

#if defined (__STDC__) || defined (__cplusplus)
   typedef signed char yysigned_char;
#else
   typedef short yysigned_char;
#endif

/* YYFINAL -- State number of the termination state. */
#define YYFINAL  37
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   436

/* YYNTOKENS -- Number of terminals. */
#define YYNTOKENS  77
/* YYNNTS -- Number of nonterminals. */
#define YYNNTS  58
/* YYNRULES -- Number of rules. */
#define YYNRULES  149
/* YYNRULES -- Number of states. */
#define YYNSTATES  232

/* YYTRANSLATE(YYLEX) -- Bison symbol number corresponding to YYLEX.  */
#define YYUNDEFTOK  2
#define YYMAXUTOK   310

#define YYTRANSLATE(YYX) 						\
  ((unsigned int) (YYX) <= YYMAXUTOK ? yytranslate[YYX] : YYUNDEFTOK)

/* YYTRANSLATE[YYLEX] -- Bison symbol number corresponding to YYLEX.  */
static const unsigned char yytranslate[] =
{
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,    63,     2,     2,     2,     2,    68,     2,
      56,    57,    64,    61,    60,    62,     2,    65,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,    72,    74,
      66,    73,    67,    71,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,    58,     2,    59,    69,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,    75,    70,    76,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     1,     2,     3,     4,
       5,     6,     7,     8,     9,    10,    11,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    27,    28,    29,    30,    31,    32,    33,    34,
      35,    36,    37,    38,    39,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50,    51,    52,    53,    54,
      55
};

#if YYDEBUG
/* YYPRHS[YYN] -- Index of the first RHS symbol of rule number YYN in
   YYRHS.  */
static const unsigned short yyprhs[] =
{
       0,     0,     3,     5,     7,     9,    13,    15,    17,    22,
      27,    31,    33,    37,    39,    41,    46,    48,    52,    56,
      58,    62,    66,    68,    70,    74,    78,    82,    86,    88,
      92,    96,    98,   102,   104,   108,   110,   114,   116,   120,
     122,   126,   128,   134,   136,   140,   142,   144,   146,   148,
     150,   152,   154,   156,   158,   160,   162,   164,   168,   170,
     174,   177,   180,   182,   185,   187,   189,   193,   195,   199,
     201,   203,   205,   208,   210,   213,   215,   217,   219,   222,
     224,   228,   233,   237,   241,   246,   249,   251,   255,   257,
     261,   264,   267,   269,   271,   275,   277,   280,   282,   286,
     289,   293,   297,   302,   305,   309,   313,   318,   320,   324,
     329,   331,   335,   337,   339,   341,   343,   345,   347,   351,
     353,   356,   360,   364,   369,   371,   374,   376,   379,   381,
     384,   388,   390,   392,   394,   398,   404,   408,   412,   415,
     418,   421,   425,   427,   430,   432,   434,   439,   443,   447
};

/* YYRHS -- A `-1'-separated list of the rules' RHS. */
static const short yyrhs[] =
{
     132,     0,    -1,    79,    -1,    55,    -1,     6,    -1,    56,
      97,    57,    -1,     3,    -1,    78,    -1,    80,    58,    97,
      59,    -1,    80,    56,    81,    57,    -1,    80,    56,    57,
      -1,    95,    -1,    81,    60,    95,    -1,    80,    -1,    82,
      -1,    56,   113,    57,    83,    -1,    83,    -1,    84,    64,
      83,    -1,    84,    65,    83,    -1,    84,    -1,    85,    61,
      84,    -1,    85,    62,    84,    -1,    85,    -1,    86,    -1,
      87,    66,    86,    -1,    87,    67,    86,    -1,    87,    23,
      86,    -1,    87,    24,    86,    -1,    87,    -1,    88,    21,
      87,    -1,    88,    22,    87,    -1,    88,    -1,    89,    68,
      88,    -1,    89,    -1,    90,    69,    89,    -1,    90,    -1,
      91,    70,    90,    -1,    91,    -1,    92,    25,    91,    -1,
      92,    -1,    93,    26,    92,    -1,    93,    -1,    93,    71,
      97,    72,    94,    -1,    94,    -1,    82,    96,    95,    -1,
      73,    -1,    11,    -1,    12,    -1,    13,    -1,     9,    -1,
      10,    -1,    19,    -1,    20,    -1,    15,    -1,    14,    -1,
      16,    -1,    95,    -1,    97,    60,    95,    -1,    94,    -1,
     100,   101,    74,    -1,   100,    74,    -1,   103,   100,    -1,
     103,    -1,   105,   100,    -1,   105,    -1,   102,    -1,   101,
      60,   102,    -1,   106,    -1,   106,    73,   116,    -1,    54,
      -1,    33,    -1,    46,    -1,   103,   104,    -1,   103,    -1,
     105,   104,    -1,   105,    -1,    34,    -1,   108,    -1,   108,
      56,    -1,    79,    -1,    56,   106,    57,    -1,   108,    58,
      98,    59,    -1,   108,    58,    59,    -1,   107,   109,    57,
      -1,   108,    56,   112,    57,    -1,   107,    57,    -1,   110,
      -1,   110,    60,     8,    -1,   111,    -1,   110,    60,   111,
      -1,   100,   106,    -1,   100,   114,    -1,   100,    -1,    79,
      -1,   112,    60,    79,    -1,   104,    -1,   104,   114,    -1,
     115,    -1,    56,   114,    57,    -1,    58,    59,    -1,    58,
      98,    59,    -1,   115,    58,    59,    -1,   115,    58,    98,
      59,    -1,    56,    57,    -1,    56,   109,    57,    -1,   115,
      56,    57,    -1,   115,    56,   109,    57,    -1,    95,    -1,
      75,   117,    76,    -1,    75,   117,    60,    76,    -1,   116,
      -1,   117,    60,   116,    -1,   119,    -1,   121,    -1,   124,
      -1,   129,    -1,   130,    -1,   131,    -1,    79,    72,   118,
      -1,   122,    -1,    75,    76,    -1,    75,   123,    76,    -1,
      75,   120,    76,    -1,    75,   120,   123,    76,    -1,    99,
      -1,   122,    99,    -1,   118,    -1,   123,   118,    -1,    74,
      -1,    97,    74,    -1,    56,    97,    57,    -1,    45,    -1,
      53,    -1,    39,    -1,   126,   125,   118,    -1,   126,   125,
     118,   128,   118,    -1,   127,   125,   118,    -1,    44,    79,
      74,    -1,    35,    74,    -1,    31,    74,    -1,    49,    74,
      -1,    49,    97,    74,    -1,   133,    -1,   132,   133,    -1,
     134,    -1,    99,    -1,   100,   106,   122,   121,    -1,   100,
     106,   121,    -1,   106,   122,   121,    -1,   106,   121,    -1
};

/* YYRLINE[YYN] -- source line where rule number YYN was defined.  */
static const unsigned short yyrline[] =
{
       0,   105,   105,   106,   111,   112,   116,   120,   121,   122,
     131,   141,   160,   172,   182,   183,   187,   188,   195,   205,
     206,   213,   223,   227,   228,   235,   242,   249,   259,   260,
     267,   277,   278,   282,   283,   287,   288,   292,   293,   297,
     298,   302,   303,   307,   311,   323,   324,   325,   326,   327,
     328,   329,   330,   331,   332,   333,   337,   338,   342,   346,
     390,   394,   395,   396,   397,   401,   402,   406,   407,   412,
     413,   414,   418,   419,   420,   421,   426,   430,   434,   450,
     451,   452,   453,   454,   481,   483,   508,   509,   513,   514,
     518,   544,   545,   549,   550,   554,   555,   559,   563,   564,
     565,   566,   567,   568,   569,   570,   571,   575,   576,   577,
     581,   582,   588,   589,   590,   591,   592,   593,   597,   606,
     618,   619,   620,   621,   625,   626,   630,   631,   635,   636,
     646,   653,   659,   665,   671,   676,   684,   692,   698,   703,
     708,   714,   725,   726,   730,   731,   735,   781,   830,   860
};
#endif

#if YYDEBUG || YYERROR_VERBOSE
/* YYTNME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals. */
static const char *const yytname[] =
{
  "$end", "error", "$undefined", "IDENTIFIER", "TYPEDEF_NAME", "FLOATING", 
  "CHARACTER", "STRING", "ELLIPSIS", "ADDEQ", "SUBEQ", "MULEQ", "DIVEQ", 
  "MODEQ", "XOREQ", "ANDEQ", "OREQ", "SL", "SR", "SLEQ", "SREQ", "EQ", 
  "NOTEQ", "LTEQ", "GTEQ", "ANDAND", "OROR", "PLUSPLUS", "MINUSMINUS", 
  "ARROW", "AUTO", "BREAK", "CASE", "CHAR", "CONST", "CONTINUE", 
  "DEFAULT", "DO", "DOUBLE", "ELSE", "ENUM", "EXTERN", "FLOAT", "FOR", 
  "GOTO", "IF", "INT", "LONG", "REGISTER", "RETURN", "SHORT", "SIGNED", 
  "SIZEOF", "WHILE", "VOID", "INTEGER", "'('", "')'", "'['", "']'", "','", 
  "'+'", "'-'", "'!'", "'*'", "'/'", "'<'", "'>'", "'&'", "'^'", "'|'", 
  "'?'", "':'", "'='", "';'", "'{'", "'}'", "$accept", 
  "primary_expression", "identifier", "postfix_expression", 
  "argument_expression_list", "unary_expression", "cast_expression", 
  "multiplicative_expression", "additive_expression", "shift_expression", 
  "relational_expression", "equality_expression", "and_expression", 
  "exclusive_or_expression", "inclusive_or_expression", 
  "logical_and_expression", "logical_or_expression", 
  "conditional_expression", "assignment_expression", 
  "assignment_operator", "expression", "constant_expression", 
  "declaration", "declaration_specifiers", "init_declarator_list", 
  "init_declarator", "type_specifier", "specifier_qualifier_list", 
  "type_qualifier", "declarator", "func_declaration_start", 
  "direct_declarator", "parameter_type_list", "parameter_list", 
  "parameter_declaration", "identifier_list", "type_name", 
  "abstract_declarator", "direct_abstract_declarator", "initializer", 
  "initializer_list", "statement", "labeled_statement", 
  "compound_statement_declaration_list", "compound_statement", 
  "declaration_list", "statement_list", "expression_statement", 
  "selection_expression", "start_if_decision", "start_while_decision", 
  "start_else_decision", "selection_statement", "iteration_statement", 
  "jump_statement", "translation_unit", "external_declaration", 
  "function_definition", 0
};
#endif

# ifdef YYPRINT
/* YYTOKNUM[YYLEX-NUM] -- Internal token number corresponding to
   token YYLEX-NUM.  */
static const unsigned short yytoknum[] =
{
       0,   256,   257,   258,   259,   260,   261,   262,   263,   264,
     265,   266,   267,   268,   269,   270,   271,   272,   273,   274,
     275,   276,   277,   278,   279,   280,   281,   282,   283,   284,
     285,   286,   287,   288,   289,   290,   291,   292,   293,   294,
     295,   296,   297,   298,   299,   300,   301,   302,   303,   304,
     305,   306,   307,   308,   309,   310,    40,    41,    91,    93,
      44,    43,    45,    33,    42,    47,    60,    62,    38,    94,
     124,    63,    58,    61,    59,   123,   125
};
# endif

/* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const unsigned char yyr1[] =
{
       0,    77,    78,    78,    78,    78,    79,    80,    80,    80,
      80,    81,    81,    82,    83,    83,    84,    84,    84,    85,
      85,    85,    86,    87,    87,    87,    87,    87,    88,    88,
      88,    89,    89,    90,    90,    91,    91,    92,    92,    93,
      93,    94,    94,    95,    95,    96,    96,    96,    96,    96,
      96,    96,    96,    96,    96,    96,    97,    97,    98,    99,
      99,   100,   100,   100,   100,   101,   101,   102,   102,   103,
     103,   103,   104,   104,   104,   104,   105,   106,   107,   108,
     108,   108,   108,   108,   108,   108,   109,   109,   110,   110,
     111,   111,   111,   112,   112,   113,   113,   114,   115,   115,
     115,   115,   115,   115,   115,   115,   115,   116,   116,   116,
     117,   117,   118,   118,   118,   118,   118,   118,   119,   120,
     121,   121,   121,   121,   122,   122,   123,   123,   124,   124,
     125,   126,   127,   128,   129,   129,   130,   131,   131,   131,
     131,   131,   132,   132,   133,   133,   134,   134,   134,   134
};

/* YYR2[YYN] -- Number of symbols composing right hand side of rule YYN.  */
static const unsigned char yyr2[] =
{
       0,     2,     1,     1,     1,     3,     1,     1,     4,     4,
       3,     1,     3,     1,     1,     4,     1,     3,     3,     1,
       3,     3,     1,     1,     3,     3,     3,     3,     1,     3,
       3,     1,     3,     1,     3,     1,     3,     1,     3,     1,
       3,     1,     5,     1,     3,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     1,     1,     3,     1,     3,
       2,     2,     1,     2,     1,     1,     3,     1,     3,     1,
       1,     1,     2,     1,     2,     1,     1,     1,     2,     1,
       3,     4,     3,     3,     4,     2,     1,     3,     1,     3,
       2,     2,     1,     1,     3,     1,     2,     1,     3,     2,
       3,     3,     4,     2,     3,     3,     4,     1,     3,     4,
       1,     3,     1,     1,     1,     1,     1,     1,     3,     1,
       2,     3,     3,     4,     1,     2,     1,     2,     1,     2,
       3,     1,     1,     1,     3,     5,     3,     3,     2,     2,
       2,     3,     1,     2,     1,     1,     4,     3,     3,     2
};

/* YYDEFACT[STATE-NAME] -- Default rule to reduce with in state
   STATE-NUM when YYTABLE doesn't specify something else to do.  Zero
   means the default is an error.  */
static const unsigned char yydefact[] =
{
       0,     6,    70,    76,    71,    69,     0,    79,   145,     0,
      62,    64,     0,     0,    77,     0,   142,   144,     0,    60,
       0,    65,    67,    61,    63,     0,   124,     0,   149,     0,
      85,    92,     0,    86,    88,    78,     0,     1,   143,    80,
       0,    59,     0,   147,     0,     4,     0,     0,     0,   131,
       0,   132,     3,     0,   128,   120,     7,     2,    13,    14,
      16,    19,    22,    23,    28,    31,    33,    35,    37,    39,
      41,    43,    56,     0,   126,   112,     0,   113,   119,     0,
     114,     0,     0,   115,   116,   117,    67,   125,   148,     0,
       0,    90,    91,    97,    83,     0,    93,     0,    82,     2,
      14,    58,     0,    66,     0,   107,    68,   146,   139,   138,
       0,   140,     0,     0,    73,    95,    75,     0,     0,     0,
       0,    49,    50,    46,    47,    48,    54,    53,    55,    51,
      52,    45,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
     129,   122,     0,   121,   127,     0,     0,     0,   103,     0,
       0,    99,     0,     0,     0,    87,    89,    84,     0,    81,
     110,     0,   137,   141,     5,    72,     0,    96,    74,     0,
     118,    10,     0,    11,     0,    44,    17,    18,    20,    21,
      26,    27,    24,    25,    29,    30,    32,    34,    36,    38,
      40,     0,    57,   123,     0,   134,   136,   104,    98,   100,
     105,     0,   101,     0,    94,     0,   108,    15,     9,     0,
       8,     0,   130,   133,     0,   106,   102,   109,   111,    12,
      42,   135
};

/* YYDEFGOTO[NTERM-NUM]. */
static const short yydefgoto[] =
{
      -1,    56,    99,    58,   182,    59,    60,    61,    62,    63,
      64,    65,    66,    67,    68,    69,    70,    71,    72,   132,
      73,   102,    26,    27,    20,    21,    10,   115,    11,    12,
      13,    14,   159,    33,    34,    97,   117,   160,    93,   106,
     171,    74,    75,    76,    77,    29,    79,    80,   156,    81,
      82,   224,    83,    84,    85,    15,    16,    17
};

/* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
   STATE-NUM.  */
#define YYPACT_NINF -105
static const short yypact[] =
{
     321,  -105,  -105,  -105,  -105,  -105,    18,  -105,  -105,     9,
     382,   382,   337,   360,    70,   289,  -105,  -105,   -37,  -105,
     -46,  -105,   335,  -105,  -105,   139,  -105,     9,  -105,   337,
    -105,    67,     1,    37,  -105,    83,   145,  -105,  -105,  -105,
      18,  -105,    39,  -105,   337,  -105,    65,    76,    83,  -105,
      16,  -105,  -105,   330,  -105,  -105,  -105,    41,   104,   301,
    -105,    -2,    71,  -105,    69,   159,   101,    85,   148,   194,
     -18,  -105,  -105,   -42,  -105,  -105,   172,  -105,   382,   205,
    -105,   115,   115,  -105,  -105,  -105,   147,  -105,  -105,   304,
     176,  -105,  -105,   105,  -105,   237,  -105,    -6,  -105,  -105,
    -105,  -105,   174,  -105,    39,  -105,  -105,  -105,  -105,  -105,
     163,  -105,   -14,    60,   382,   109,   382,   181,   253,   284,
     135,  -105,  -105,  -105,  -105,  -105,  -105,  -105,  -105,  -105,
    -105,  -105,   135,   135,   135,   135,   135,   135,   135,   135,
     135,   135,   135,   135,   135,   135,   135,   135,   135,   135,
    -105,  -105,   220,  -105,  -105,   135,   253,   253,  -105,   182,
     184,  -105,   183,   365,   297,  -105,  -105,  -105,    83,  -105,
    -105,   -27,  -105,  -105,  -105,  -105,   346,  -105,  -105,   135,
    -105,  -105,    80,  -105,   146,  -105,  -105,  -105,    -2,    -2,
    -105,  -105,  -105,  -105,    69,    69,   159,   101,    85,   148,
     194,   -49,  -105,  -105,    86,   204,  -105,  -105,  -105,  -105,
    -105,   195,  -105,   198,  -105,   121,  -105,  -105,  -105,   135,
    -105,   135,  -105,  -105,   253,  -105,  -105,  -105,  -105,  -105,
    -105,  -105
};

/* YYPGOTO[NTERM-NUM].  */
static const short yypgoto[] =
{
    -105,  -105,     0,  -105,  -105,   -35,  -104,    63,  -105,   -71,
      68,   110,   118,   122,   117,   119,  -105,   -34,    15,  -105,
      11,   -80,    44,    26,  -105,   228,   -36,   -64,   -29,     7,
    -105,  -105,   -10,  -105,   177,  -105,  -105,   -24,  -105,   -99,
    -105,   -75,  -105,  -105,   200,   133,   201,  -105,   192,  -105,
    -105,  -105,  -105,  -105,  -105,  -105,   263,  -105
};

/* YYTABLE[YYPACT[STATE-NUM]].  What to do in state STATE-NUM.  If
   positive, shift that token.  If negative, reduce the rule which
   number is the opposite.  If zero, do what YYDEFACT says.
   If YYTABLE_NINF, syntax error.  */
#define YYTABLE_NINF -1
static const unsigned char yytable[] =
{
       7,   100,   101,    32,   154,   170,     7,    92,   147,     7,
     162,   149,     1,    18,    40,     7,    22,   114,   149,     1,
      39,     1,    45,   221,   116,    57,     9,     7,    41,   186,
     187,     7,   150,   215,    86,    96,    23,    24,    91,    31,
       7,     9,     1,   180,     8,    45,   149,    86,   110,   216,
     175,   167,   178,   148,   168,   100,   101,   105,    94,     8,
     173,   112,   133,   134,   113,     6,   190,   191,   192,   193,
       1,    52,    53,    87,     6,   217,    57,   154,   114,    57,
     114,   205,   206,    19,   213,   116,     1,   116,    87,     7,
     111,   177,   137,   138,    52,    53,    18,    95,   100,   100,
     100,   100,   100,   100,   100,   100,   100,   100,   100,   100,
     100,   100,   100,   118,   104,    31,   228,   174,    57,   105,
     149,    31,    87,    89,     1,    90,    35,    45,    36,   100,
     101,   184,   135,   136,   183,   139,   140,   218,     1,   108,
     219,    45,     1,   222,   100,    45,   149,   185,     1,   231,
     109,    45,    57,   211,   144,    44,    57,    57,    78,   201,
     119,   163,   120,   164,   202,   176,   204,    90,   214,   143,
      46,   155,     2,     3,    47,     1,    52,    53,    45,     1,
     141,   142,    45,    48,    49,     4,   100,   230,    50,    31,
      52,    53,    51,     5,    52,    53,   104,   227,   188,   189,
      52,    53,    31,    46,    98,   220,   149,    47,     1,   194,
     195,    45,    28,    54,    25,    55,    48,    49,   145,   146,
      42,    50,    43,     1,    57,    51,    45,    52,    53,    88,
     105,    52,    53,   169,   229,   161,    46,   172,   179,   207,
      47,   208,   209,   223,   107,   165,    54,    25,   151,    48,
      49,    46,   225,   196,    50,    47,     1,   226,    51,    45,
      52,    53,   197,   199,    48,    49,   200,   198,   103,    50,
       2,     3,   166,    51,   157,    52,    53,   152,    38,    54,
      25,   153,     0,     4,    46,     0,     0,     1,    47,    37,
      45,     5,     1,     0,    54,    25,   203,    48,    49,     0,
       1,     0,    50,    45,     0,     0,    51,     1,    52,    53,
     121,   122,   123,   124,   125,   126,   127,   128,     0,     0,
     129,   130,     2,     3,     1,     0,     0,    54,    25,     0,
       0,     0,     0,     1,     0,     4,    45,     2,     3,    52,
      53,   181,     0,     5,     0,     6,     0,     0,     0,     0,
       4,     0,    52,    53,     2,     3,   212,     0,     5,     0,
      89,   158,    90,     2,     3,     0,     0,     4,     2,     3,
       2,     3,     0,     0,   131,     5,     4,     6,     0,     2,
       3,     4,     0,     4,     5,    52,    53,     0,     0,     5,
       0,     5,     4,     2,     3,     0,     0,     0,     2,     3,
       5,     0,   176,   158,    90,     0,     4,     0,    42,     0,
      25,     4,    25,     0,     5,     2,     3,    30,     0,     5,
       0,     0,   210,     0,     0,     0,     0,     0,     4,     0,
       0,     0,     0,     0,     0,     0,     5
};

static const short yycheck[] =
{
       0,    36,    36,    13,    79,   104,     6,    31,    26,     9,
      90,    60,     3,     6,    60,    15,     9,    53,    60,     3,
      57,     3,     6,    72,    53,    25,     0,    27,    74,   133,
     134,    31,    74,    60,    27,    35,    10,    11,    31,    13,
      40,    15,     3,   118,     0,     6,    60,    40,    48,    76,
     114,    57,   116,    71,    60,    90,    90,    42,    57,    15,
      74,    50,    64,    65,    53,    56,   137,   138,   139,   140,
       3,    55,    56,    29,    56,   179,    76,   152,   114,    79,
     116,   156,   157,    74,   164,   114,     3,   116,    44,    89,
      74,   115,    23,    24,    55,    56,    89,    60,   133,   134,
     135,   136,   137,   138,   139,   140,   141,   142,   143,   144,
     145,   146,   147,    72,    75,    89,   215,    57,   118,   104,
      60,    95,    78,    56,     3,    58,    56,     6,    58,   164,
     164,   120,    61,    62,   119,    66,    67,    57,     3,    74,
      60,     6,     3,    57,   179,     6,    60,   132,     3,   224,
      74,     6,   152,   163,    69,    22,   156,   157,    25,   148,
      56,    56,    58,    58,   149,    56,   155,    58,   168,    68,
      31,    56,    33,    34,    35,     3,    55,    56,     6,     3,
      21,    22,     6,    44,    45,    46,   221,   221,    49,   163,
      55,    56,    53,    54,    55,    56,    75,    76,   135,   136,
      55,    56,   176,    31,    59,    59,    60,    35,     3,   141,
     142,     6,    12,    74,    75,    76,    44,    45,    70,    25,
      73,    49,    22,     3,   224,    53,     6,    55,    56,    29,
     215,    55,    56,    59,   219,    59,    31,    74,    57,    57,
      35,    57,    59,    39,    44,     8,    74,    75,    76,    44,
      45,    31,    57,   143,    49,    35,     3,    59,    53,     6,
      55,    56,   144,   146,    44,    45,   147,   145,    40,    49,
      33,    34,    95,    53,    82,    55,    56,    76,    15,    74,
      75,    76,    -1,    46,    31,    -1,    -1,     3,    35,     0,
       6,    54,     3,    -1,    74,    75,    76,    44,    45,    -1,
       3,    -1,    49,     6,    -1,    -1,    53,     3,    55,    56,
       9,    10,    11,    12,    13,    14,    15,    16,    -1,    -1,
      19,    20,    33,    34,     3,    -1,    -1,    74,    75,    -1,
      -1,    -1,    -1,     3,    -1,    46,     6,    33,    34,    55,
      56,    57,    -1,    54,    -1,    56,    -1,    -1,    -1,    -1,
      46,    -1,    55,    56,    33,    34,    59,    -1,    54,    -1,
      56,    57,    58,    33,    34,    -1,    -1,    46,    33,    34,
      33,    34,    -1,    -1,    73,    54,    46,    56,    -1,    33,
      34,    46,    -1,    46,    54,    55,    56,    -1,    -1,    54,
      -1,    54,    46,    33,    34,    -1,    -1,    -1,    33,    34,
      54,    -1,    56,    57,    58,    -1,    46,    -1,    73,    -1,
      75,    46,    75,    -1,    54,    33,    34,    57,    -1,    54,
      -1,    -1,    57,    -1,    -1,    -1,    -1,    -1,    46,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    54
};

/* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
   symbol of state STATE-NUM.  */
static const unsigned char yystos[] =
{
       0,     3,    33,    34,    46,    54,    56,    79,    99,   100,
     103,   105,   106,   107,   108,   132,   133,   134,   106,    74,
     101,   102,   106,   100,   100,    75,    99,   100,   121,   122,
      57,   100,   109,   110,   111,    56,    58,     0,   133,    57,
      60,    74,    73,   121,   122,     6,    31,    35,    44,    45,
      49,    53,    55,    56,    74,    76,    78,    79,    80,    82,
      83,    84,    85,    86,    87,    88,    89,    90,    91,    92,
      93,    94,    95,    97,   118,   119,   120,   121,   122,   123,
     124,   126,   127,   129,   130,   131,   106,    99,   121,    56,
      58,   106,   114,   115,    57,    60,    79,   112,    59,    79,
      82,    94,    98,   102,    75,    95,   116,   121,    74,    74,
      79,    74,    97,    97,   103,   104,   105,   113,    72,    56,
      58,     9,    10,    11,    12,    13,    14,    15,    16,    19,
      20,    73,    96,    64,    65,    61,    62,    23,    24,    66,
      67,    21,    22,    68,    69,    70,    25,    26,    71,    60,
      74,    76,   123,    76,   118,    56,   125,   125,    57,   109,
     114,    59,    98,    56,    58,     8,   111,    57,    60,    59,
     116,   117,    74,    74,    57,   104,    56,   114,   104,    57,
     118,    57,    81,    95,    97,    95,    83,    83,    84,    84,
      86,    86,    86,    86,    87,    87,    88,    89,    90,    91,
      92,    97,    95,    76,    97,   118,   118,    57,    57,    59,
      57,   109,    59,    98,    79,    60,    76,    83,    57,    60,
      59,    72,    57,    39,   128,    57,    59,    76,   116,    95,
      94,   118
};

#if ! defined (YYSIZE_T) && defined (__SIZE_TYPE__)
# define YYSIZE_T __SIZE_TYPE__
#endif
#if ! defined (YYSIZE_T) && defined (size_t)
# define YYSIZE_T size_t
#endif
#if ! defined (YYSIZE_T)
# if defined (__STDC__) || defined (__cplusplus)
#  include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  define YYSIZE_T size_t
# endif
#endif
#if ! defined (YYSIZE_T)
# define YYSIZE_T unsigned int
#endif

#define yyerrok		(yyerrstatus = 0)
#define yyclearin	(yychar = YYEMPTY)
#define YYEMPTY		(-2)
#define YYEOF		0

#define YYACCEPT	goto yyacceptlab
#define YYABORT		goto yyabortlab
#define YYERROR		goto yyerrlab1


/* Like YYERROR except do call yyerror.  This remains here temporarily
   to ease the transition to the new meaning of YYERROR, for GCC.
   Once GCC version 2 has supplanted version 1, this can go.  */

#define YYFAIL		goto yyerrlab

#define YYRECOVERING()  (!!yyerrstatus)

#define YYBACKUP(Token, Value)					\
do								\
  if (yychar == YYEMPTY && yylen == 1)				\
    {								\
      yychar = (Token);						\
      yylval = (Value);						\
      yytoken = YYTRANSLATE (yychar);				\
      YYPOPSTACK;						\
      goto yybackup;						\
    }								\
  else								\
    { 								\
      yyerror ("syntax error: cannot back up");\
      YYERROR;							\
    }								\
while (0)

#define YYTERROR	1
#define YYERRCODE	256

/* YYLLOC_DEFAULT -- Compute the default location (before the actions
   are run).  */

#ifndef YYLLOC_DEFAULT
# define YYLLOC_DEFAULT(Current, Rhs, N)         \
  Current.first_line   = Rhs[1].first_line;      \
  Current.first_column = Rhs[1].first_column;    \
  Current.last_line    = Rhs[N].last_line;       \
  Current.last_column  = Rhs[N].last_column;
#endif

/* YYLEX -- calling `yylex' with the right arguments.  */

#ifdef YYLEX_PARAM
# define YYLEX yylex (YYLEX_PARAM)
#else
# define YYLEX yylex ()
#endif

/* Enable debugging if requested.  */
#if YYDEBUG

# ifndef YYFPRINTF
#  include <stdio.h> /* INFRINGES ON USER NAME SPACE */
#  define YYFPRINTF fprintf
# endif

# define YYDPRINTF(Args)			\
do {						\
  if (yydebug)					\
    YYFPRINTF Args;				\
} while (0)

# define YYDSYMPRINT(Args)			\
do {						\
  if (yydebug)					\
    yysymprint Args;				\
} while (0)

# define YYDSYMPRINTF(Title, Token, Value, Location)		\
do {								\
  if (yydebug)							\
    {								\
      YYFPRINTF (stderr, "%s ", Title);				\
      yysymprint (stderr, 					\
                  Token, Value);	\
      YYFPRINTF (stderr, "\n");					\
    }								\
} while (0)

/*------------------------------------------------------------------.
| yy_stack_print -- Print the state stack from its BOTTOM up to its |
| TOP (cinluded).                                                   |
`------------------------------------------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yy_stack_print (short *bottom, short *top)
#else
static void
yy_stack_print (bottom, top)
    short *bottom;
    short *top;
#endif
{
  YYFPRINTF (stderr, "Stack now");
  for (/* Nothing. */; bottom <= top; ++bottom)
    YYFPRINTF (stderr, " %d", *bottom);
  YYFPRINTF (stderr, "\n");
}

# define YY_STACK_PRINT(Bottom, Top)				\
do {								\
  if (yydebug)							\
    yy_stack_print ((Bottom), (Top));				\
} while (0)


/*------------------------------------------------.
| Report that the YYRULE is going to be reduced.  |
`------------------------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yy_reduce_print (int yyrule)
#else
static void
yy_reduce_print (yyrule)
    int yyrule;
#endif
{
  int yyi;
  unsigned int yylno = yyrline[yyrule];
  YYFPRINTF (stderr, "Reducing stack by rule %d (line %u), ",
             yyrule - 1, yylno);
  /* Print the symbols being reduced, and their result.  */
  for (yyi = yyprhs[yyrule]; 0 <= yyrhs[yyi]; yyi++)
    YYFPRINTF (stderr, "%s ", yytname [yyrhs[yyi]]);
  YYFPRINTF (stderr, "-> %s\n", yytname [yyr1[yyrule]]);
}

# define YY_REDUCE_PRINT(Rule)		\
do {					\
  if (yydebug)				\
    yy_reduce_print (Rule);		\
} while (0)

/* Nonzero means print parse trace.  It is left uninitialized so that
   multiple parsers can coexist.  */
int yydebug;
#else /* !YYDEBUG */
# define YYDPRINTF(Args)
# define YYDSYMPRINT(Args)
# define YYDSYMPRINTF(Title, Token, Value, Location)
# define YY_STACK_PRINT(Bottom, Top)
# define YY_REDUCE_PRINT(Rule)
#endif /* !YYDEBUG */


/* YYINITDEPTH -- initial size of the parser's stacks.  */
#ifndef	YYINITDEPTH
# define YYINITDEPTH 200
#endif

/* YYMAXDEPTH -- maximum size the stacks can grow to (effective only
   if the built-in stack extension method is used).

   Do not make this value too large; the results are undefined if
   SIZE_MAX < YYSTACK_BYTES (YYMAXDEPTH)
   evaluated with infinite-precision integer arithmetic.  */

#if YYMAXDEPTH == 0
# undef YYMAXDEPTH
#endif

#ifndef YYMAXDEPTH
# define YYMAXDEPTH 10000
#endif



#if YYERROR_VERBOSE

# ifndef yystrlen
#  if defined (__GLIBC__) && defined (_STRING_H)
#   define yystrlen strlen
#  else
/* Return the length of YYSTR.  */
static YYSIZE_T
#   if defined (__STDC__) || defined (__cplusplus)
yystrlen (const char *yystr)
#   else
yystrlen (yystr)
     const char *yystr;
#   endif
{
  register const char *yys = yystr;

  while (*yys++ != '\0')
    continue;

  return yys - yystr - 1;
}
#  endif
# endif

# ifndef yystpcpy
#  if defined (__GLIBC__) && defined (_STRING_H) && defined (_GNU_SOURCE)
#   define yystpcpy stpcpy
#  else
/* Copy YYSRC to YYDEST, returning the address of the terminating '\0' in
   YYDEST.  */
static char *
#   if defined (__STDC__) || defined (__cplusplus)
yystpcpy (char *yydest, const char *yysrc)
#   else
yystpcpy (yydest, yysrc)
     char *yydest;
     const char *yysrc;
#   endif
{
  register char *yyd = yydest;
  register const char *yys = yysrc;

  while ((*yyd++ = *yys++) != '\0')
    continue;

  return yyd - 1;
}
#  endif
# endif

#endif /* !YYERROR_VERBOSE */



#if YYDEBUG
/*--------------------------------.
| Print this symbol on YYOUTPUT.  |
`--------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yysymprint (FILE *yyoutput, int yytype, YYSTYPE *yyvaluep)
#else
static void
yysymprint (yyoutput, yytype, yyvaluep)
    FILE *yyoutput;
    int yytype;
    YYSTYPE *yyvaluep;
#endif
{
  /* Pacify ``unused variable'' warnings.  */
  (void) yyvaluep;

  if (yytype < YYNTOKENS)
    {
      YYFPRINTF (yyoutput, "token %s (", yytname[yytype]);
# ifdef YYPRINT
      YYPRINT (yyoutput, yytoknum[yytype], *yyvaluep);
# endif
    }
  else
    YYFPRINTF (yyoutput, "nterm %s (", yytname[yytype]);

  switch (yytype)
    {
      default:
        break;
    }
  YYFPRINTF (yyoutput, ")");
}

#endif /* ! YYDEBUG */
/*-----------------------------------------------.
| Release the memory associated to this symbol.  |
`-----------------------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yydestruct (int yytype, YYSTYPE *yyvaluep)
#else
static void
yydestruct (yytype, yyvaluep)
    int yytype;
    YYSTYPE *yyvaluep;
#endif
{
  /* Pacify ``unused variable'' warnings.  */
  (void) yyvaluep;

  switch (yytype)
    {

      default:
        break;
    }
}


/* Prevent warnings from -Wmissing-prototypes.  */

#ifdef YYPARSE_PARAM
# if defined (__STDC__) || defined (__cplusplus)
int yyparse (void *YYPARSE_PARAM);
# else
int yyparse ();
# endif
#else /* ! YYPARSE_PARAM */
#if defined (__STDC__) || defined (__cplusplus)
int yyparse (void);
#else
int yyparse ();
#endif
#endif /* ! YYPARSE_PARAM */



/* The lookahead symbol.  */
int yychar;

/* The semantic value of the lookahead symbol.  */
YYSTYPE yylval;

/* Number of syntax errors so far.  */
int yynerrs;



/*----------.
| yyparse.  |
`----------*/

#ifdef YYPARSE_PARAM
# if defined (__STDC__) || defined (__cplusplus)
int yyparse (void *YYPARSE_PARAM)
# else
int yyparse (YYPARSE_PARAM)
  void *YYPARSE_PARAM;
# endif
#else /* ! YYPARSE_PARAM */
#if defined (__STDC__) || defined (__cplusplus)
int
yyparse (void)
#else
int
yyparse ()

#endif
#endif
{
  
  register int yystate;
  register int yyn;
  int yyresult;
  /* Number of tokens to shift before error messages enabled.  */
  int yyerrstatus;
  /* Lookahead token as an internal (translated) token number.  */
  int yytoken = 0;

  /* Three stacks and their tools:
     `yyss': related to states,
     `yyvs': related to semantic values,
     `yyls': related to locations.

     Refer to the stacks thru separate pointers, to allow yyoverflow
     to reallocate them elsewhere.  */

  /* The state stack.  */
  short	yyssa[YYINITDEPTH];
  short *yyss = yyssa;
  register short *yyssp;

  /* The semantic value stack.  */
  YYSTYPE yyvsa[YYINITDEPTH];
  YYSTYPE *yyvs = yyvsa;
  register YYSTYPE *yyvsp;



#define YYPOPSTACK   (yyvsp--, yyssp--)

  YYSIZE_T yystacksize = YYINITDEPTH;

  /* The variables used to return semantic value and location from the
     action routines.  */
  YYSTYPE yyval;


  /* When reducing, the number of symbols on the RHS of the reduced
     rule.  */
  int yylen;

  YYDPRINTF ((stderr, "Starting parse\n"));

  yystate = 0;
  yyerrstatus = 0;
  yynerrs = 0;
  yychar = YYEMPTY;		/* Cause a token to be read.  */

  /* Initialize stack pointers.
     Waste one element of value and location stack
     so that they stay on the same level as the state stack.
     The wasted elements are never initialized.  */

  yyssp = yyss;
  yyvsp = yyvs;

  goto yysetstate;

/*------------------------------------------------------------.
| yynewstate -- Push a new state, which is found in yystate.  |
`------------------------------------------------------------*/
 yynewstate:
  /* In all cases, when you get here, the value and location stacks
     have just been pushed. so pushing a state here evens the stacks.
     */
  yyssp++;

 yysetstate:
  *yyssp = yystate;

  if (yyss + yystacksize - 1 <= yyssp)
    {
      /* Get the current used size of the three stacks, in elements.  */
      YYSIZE_T yysize = yyssp - yyss + 1;

#ifdef yyoverflow
      {
	/* Give user a chance to reallocate the stack. Use copies of
	   these so that the &'s don't force the real ones into
	   memory.  */
	YYSTYPE *yyvs1 = yyvs;
	short *yyss1 = yyss;


	/* Each stack pointer address is followed by the size of the
	   data in use in that stack, in bytes.  This used to be a
	   conditional around just the two extra args, but that might
	   be undefined if yyoverflow is a macro.  */
	yyoverflow ("parser stack overflow",
		    &yyss1, yysize * sizeof (*yyssp),
		    &yyvs1, yysize * sizeof (*yyvsp),

		    &yystacksize);

	yyss = yyss1;
	yyvs = yyvs1;
      }
#else /* no yyoverflow */
# ifndef YYSTACK_RELOCATE
      goto yyoverflowlab;
# else
      /* Extend the stack our own way.  */
      if (YYMAXDEPTH <= yystacksize)
	goto yyoverflowlab;
      yystacksize *= 2;
      if (YYMAXDEPTH < yystacksize)
	yystacksize = YYMAXDEPTH;

      {
	short *yyss1 = yyss;
	union yyalloc *yyptr =
	  (union yyalloc *) YYSTACK_ALLOC (YYSTACK_BYTES (yystacksize));
	if (! yyptr)
	  goto yyoverflowlab;
	YYSTACK_RELOCATE (yyss);
	YYSTACK_RELOCATE (yyvs);

#  undef YYSTACK_RELOCATE
	if (yyss1 != yyssa)
	  YYSTACK_FREE (yyss1);
      }
# endif
#endif /* no yyoverflow */

      yyssp = yyss + yysize - 1;
      yyvsp = yyvs + yysize - 1;


      YYDPRINTF ((stderr, "Stack size increased to %lu\n",
		  (unsigned long int) yystacksize));

      if (yyss + yystacksize - 1 <= yyssp)
	YYABORT;
    }

  YYDPRINTF ((stderr, "Entering state %d\n", yystate));

  goto yybackup;

/*-----------.
| yybackup.  |
`-----------*/
yybackup:

/* Do appropriate processing given the current state.  */
/* Read a lookahead token if we need one and don't already have one.  */
/* yyresume: */

  /* First try to decide what to do without reference to lookahead token.  */

  yyn = yypact[yystate];
  if (yyn == YYPACT_NINF)
    goto yydefault;

  /* Not known => get a lookahead token if don't already have one.  */

  /* YYCHAR is either YYEMPTY or YYEOF or a valid lookahead symbol.  */
  if (yychar == YYEMPTY)
    {
      YYDPRINTF ((stderr, "Reading a token: "));
      yychar = YYLEX;
    }

  if (yychar <= YYEOF)
    {
      yychar = yytoken = YYEOF;
      YYDPRINTF ((stderr, "Now at end of input.\n"));
    }
  else
    {
      yytoken = YYTRANSLATE (yychar);
      YYDSYMPRINTF ("Next token is", yytoken, &yylval, &yylloc);
    }

  /* If the proper action on seeing token YYTOKEN is to reduce or to
     detect an error, take that action.  */
  yyn += yytoken;
  if (yyn < 0 || YYLAST < yyn || yycheck[yyn] != yytoken)
    goto yydefault;
  yyn = yytable[yyn];
  if (yyn <= 0)
    {
      if (yyn == 0 || yyn == YYTABLE_NINF)
	goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }

  if (yyn == YYFINAL)
    YYACCEPT;

  /* Shift the lookahead token.  */
  YYDPRINTF ((stderr, "Shifting token %s, ", yytname[yytoken]));

  /* Discard the token being shifted unless it is eof.  */
  if (yychar != YYEOF)
    yychar = YYEMPTY;

  *++yyvsp = yylval;


  /* Count tokens shifted since error; after three, turn off error
     status.  */
  if (yyerrstatus)
    yyerrstatus--;

  yystate = yyn;
  goto yynewstate;


/*-----------------------------------------------------------.
| yydefault -- do the default action for the current state.  |
`-----------------------------------------------------------*/
yydefault:
  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;
  goto yyreduce;


/*-----------------------------.
| yyreduce -- Do a reduction.  |
`-----------------------------*/
yyreduce:
  /* yyn is the number of a rule to reduce with.  */
  yylen = yyr2[yyn];

  /* If YYLEN is nonzero, implement the default value of the action:
     `$$ = $1'.

     Otherwise, the following line sets YYVAL to garbage.
     This behavior is undocumented and Bison
     users should not rely upon it.  Assigning to YYVAL
     unconditionally makes the parser a bit smaller, and it avoids a
     GCC warning that YYVAL may be used uninitialized.  */
  yyval = yyvsp[1-yylen];


  YY_REDUCE_PRINT (yyn);
  switch (yyn)
    {
        case 2:
#line 105 "parser.y"
    { yyval.pEntry = yyvsp[0].pEntry; ;}
    break;

  case 3:
#line 106 "parser.y"
    { yyval.pEntry = generate_code_for_const_int(
											g_outFile,
											yyvsp[0].pEntry->ident_ptr.ident_info.const_int
											);
											;}
    break;

  case 5:
#line 112 "parser.y"
    { yyval.pEntry = yyvsp[-1].pEntry; ;}
    break;

  case 6:
#line 116 "parser.y"
    { yyval.pEntry = yylval.pEntry; ;}
    break;

  case 7:
#line 120 "parser.y"
    { yyval.pEntry = yyvsp[0].pEntry; ;}
    break;

  case 8:
#line 121 "parser.y"
    { assert(0); yyval.pEntry = yyvsp[-3].pEntry;;}
    break;

  case 9:
#line 122 "parser.y"
    { 

						yyval.pEntry = produce_code_for_function_call(
																		g_outFile,
																		yyvsp[-3].pEntry,
																		yyvsp[-1].pEntry
																		);
						
	 ;}
    break;

  case 10:
#line 131 "parser.y"
    { 
						yyval.pEntry = produce_code_for_function_call(
																		g_outFile,
																		yyvsp[-2].pEntry,
																		NULL
																		);
	;}
    break;

  case 11:
#line 141 "parser.y"
    { 
			symtableentry_t	*pActualParamSpaceInfo;

			pActualParamSpaceInfo = 
			create_symbol_table_entry();

			pActualParamSpaceInfo->ident_ptr.ident_type = 
					IDENT_DEF_FUNCTION_CALL;

			pActualParamSpaceInfo->ident_ptr.ident_info.actual_param_stack =
					initialize_act_param_stack();

			push_act_parameter(
							pActualParamSpaceInfo->ident_ptr.ident_info.actual_param_stack,
							yyvsp[0].pEntry
							);

			yyval.pEntry = pActualParamSpaceInfo;
	;}
    break;

  case 12:
#line 160 "parser.y"
    {
					
			push_act_parameter(
				yyvsp[-2].pEntry->ident_ptr.ident_info.actual_param_stack,
				yyvsp[0].pEntry
				);

				yyval.pEntry  = yyvsp[-2].pEntry;
	;}
    break;

  case 13:
#line 172 "parser.y"
    { yyval.pEntry = yyvsp[0].pEntry; ;}
    break;

  case 14:
#line 182 "parser.y"
    { yyval.pEntry = yyvsp[0].pEntry; ;}
    break;

  case 15:
#line 183 "parser.y"
    { yyval.pEntry = yyvsp[0].pEntry;;}
    break;

  case 17:
#line 188 "parser.y"
    {
			yyval.pEntry = generate_code_mult_op(
								g_outFile,
								yyvsp[-2].pEntry,
								yyvsp[0].pEntry
								);
	;}
    break;

  case 18:
#line 195 "parser.y"
    {
			yyval.pEntry = generate_code_div_op(
								g_outFile,
								yyvsp[-2].pEntry,
								yyvsp[0].pEntry
								);
	;}
    break;

  case 20:
#line 206 "parser.y"
    {
			yyval.pEntry = generate_code_add_op(
								g_outFile,
								yyvsp[-2].pEntry,
								yyvsp[0].pEntry
								);
	;}
    break;

  case 21:
#line 213 "parser.y"
    {
			yyval.pEntry = generate_code_sub_op(
								g_outFile,
								yyvsp[-2].pEntry,
								yyvsp[0].pEntry
								);
	;}
    break;

  case 24:
#line 228 "parser.y"
    {
				yyval.pEntry = generate_code_for_lt_op(
											g_outFile,
											yyvsp[-2].pEntry,
											yyvsp[0].pEntry
											);
	;}
    break;

  case 25:
#line 235 "parser.y"
    {
				yyval.pEntry = generate_code_for_gt_op(
											g_outFile,
											yyvsp[-2].pEntry,
											yyvsp[0].pEntry
											);
	;}
    break;

  case 26:
#line 242 "parser.y"
    {
				yyval.pEntry = generate_code_for_lte_op(
											g_outFile,
											yyvsp[-2].pEntry,
											yyvsp[0].pEntry
											);
	;}
    break;

  case 27:
#line 249 "parser.y"
    {
				yyval.pEntry = generate_code_for_gte_op(
											g_outFile,
											yyvsp[-2].pEntry,
											yyvsp[0].pEntry
											);
	;}
    break;

  case 29:
#line 260 "parser.y"
    {
				yyval.pEntry = generate_code_for_eq_op(
											g_outFile,
											yyvsp[-2].pEntry,
											yyvsp[0].pEntry
											);
	;}
    break;

  case 30:
#line 267 "parser.y"
    {
				yyval.pEntry = generate_code_for_ne_op(
											g_outFile,
											yyvsp[-2].pEntry,
											yyvsp[0].pEntry
											);
	;}
    break;

  case 43:
#line 307 "parser.y"
    { 
											printf("conditional expression source line%d\n", lineno);
											yyval.pEntry = yyvsp[0].pEntry; 
	;}
    break;

  case 44:
#line 311 "parser.y"
    { 
			printf("assignment operator. source line %d\n", lineno);

			yyval.pEntry = process_assignment(
									g_outFile,
									yyvsp[-2].pEntry,
									yyvsp[0].pEntry
									);
	;}
    break;

  case 56:
#line 337 "parser.y"
    { yyval.pEntry = yyvsp[0].pEntry; ;}
    break;

  case 57:
#line 338 "parser.y"
    { ;}
    break;

  case 59:
#line 346 "parser.y"
    {
				
				if ( IDENT_DEF_VARIABLE == yyvsp[-1].pEntry->ident_ptr.ident_type  )
				{
					if ( isFuncDefStackEmpty(func_def_stack) == 0 )
					{
						symtableentry_t	*pFuncDef;
						printf("[%d] sourcel line#[%d] process local variable definition[%s]\n", 
						__LINE__,lineno, yyvsp[-1].pEntry->id_name);

						get_top_function(
												func_def_stack,
												&pFuncDef
												);

						insert_symbol(
										pFuncDef->ident_ptr.ident_info.func.pFuncSymbolTable,
										yyvsp[-1].pEntry
										);

						process_local_var_definition(
												g_outFile,
												yyvsp[-2].decl_type,
												yyvsp[-1].pEntry,
												pFuncDef
												);
					}
					else
					{
						printf("[%d] source line#[%d] process local variable definition[%s]\n", 
						__LINE__, lineno, yyvsp[-1].pEntry->id_name);

						insert_symbol(
										g_SymbolTable,
										yyvsp[-1].pEntry
										);

						process_global_var_definition(
												yyvsp[-2].decl_type,
												yyvsp[-1].pEntry
												);
					}
				}
	;}
    break;

  case 60:
#line 390 "parser.y"
    { ;}
    break;

  case 61:
#line 394 "parser.y"
    { yyval.decl_type = yyvsp[-1].decl_type; assert(0); ;}
    break;

  case 62:
#line 395 "parser.y"
    { yyval.decl_type = yyvsp[0].decl_type; ;}
    break;

  case 63:
#line 396 "parser.y"
    { assert(0); ;}
    break;

  case 64:
#line 397 "parser.y"
    { assert(0); ;}
    break;

  case 69:
#line 412 "parser.y"
    { yyval.decl_type = yyvsp[0].decl_type; ;}
    break;

  case 70:
#line 413 "parser.y"
    { yyval.decl_type = yyvsp[0].decl_type; ;}
    break;

  case 71:
#line 414 "parser.y"
    { yyval.decl_type = yyvsp[0].decl_type; ;}
    break;

  case 72:
#line 418 "parser.y"
    { ;}
    break;

  case 73:
#line 419 "parser.y"
    { ;}
    break;

  case 74:
#line 420 "parser.y"
    { ;}
    break;

  case 75:
#line 421 "parser.y"
    { ;}
    break;

  case 78:
#line 434 "parser.y"
    {
				yyvsp[-1].pEntry->ident_ptr.ident_type	=	IDENT_DEF_FUNCTION;

				yyvsp[-1].pEntry->ident_ptr.ident_info.func.pFuncSymbolTable = create_symbol_table();

				yyvsp[-1].pEntry->ident_ptr.ident_info.func.formal_parameter_stack = 
								initialize_formal_param_stack();


				push_func_def(func_def_stack, yyvsp[-1].pEntry);

				yyval.pEntry = yyvsp[-1].pEntry;
		;}
    break;

  case 79:
#line 450 "parser.y"
    { yyvsp[0].pEntry->ident_ptr.ident_type = IDENT_DEF_VARIABLE; ;}
    break;

  case 80:
#line 451 "parser.y"
    { assert(0); ;}
    break;

  case 81:
#line 452 "parser.y"
    { assert(0); ;}
    break;

  case 82:
#line 453 "parser.y"
    { assert(0); ;}
    break;

  case 83:
#line 454 "parser.y"
    {
					/* this is the place where we put the code to process the 
					*	function definition 
					*/
					printf("[%d] source line #[%d] function definition\n", __LINE__, lineno);

					/* insert this function into the global symbol table.
					*   By definition the name of a function is always within the 
					*   global scope.
					*
					*/

					insert_symbol(
							g_SymbolTable,
							yyvsp[-2].pEntry
							);

					process_function_definition(
														yyvsp[-2].pEntry
														);

					produce_function_prologue(
														g_outFile,
														yyvsp[-2].pEntry
														);

	 ;}
    break;

  case 84:
#line 481 "parser.y"
    { assert(0); yyvsp[-3].pEntry->ident_ptr.ident_type = IDENT_DEF_FUNCTION; 
	;}
    break;

  case 85:
#line 483 "parser.y"
    { /* mark the identifier as being a function */

					insert_symbol(
							g_SymbolTable,
							yyvsp[-1].pEntry
							);


				process_function_definition(
													yyvsp[-1].pEntry
													);

				produce_function_prologue(
														g_outFile,
														yyvsp[-1].pEntry
														);
	;}
    break;

  case 90:
#line 518 "parser.y"
    { 

			symtableentry_t *pFuncEntry = NULL;

			get_top_function(
									func_def_stack,
									&pFuncEntry
									);

			assert(pFuncEntry);

			process_formal_param_declaration(
									yyvsp[-1].decl_type,
									yyvsp[0].pEntry
									);

			insert_symbol(
						pFuncEntry->ident_ptr.ident_info.func.pFuncSymbolTable,
						yyvsp[0].pEntry
						);

			push_formal_parameter(
							pFuncEntry->ident_ptr.ident_info.func.formal_parameter_stack,
							yyvsp[0].pEntry
							);										
	;}
    break;

  case 91:
#line 544 "parser.y"
    { ;}
    break;

  case 92:
#line 545 "parser.y"
    { ;}
    break;

  case 93:
#line 549 "parser.y"
    { ;}
    break;

  case 94:
#line 550 "parser.y"
    { ;}
    break;

  case 107:
#line 575 "parser.y"
    { ;}
    break;

  case 108:
#line 576 "parser.y"
    { ;}
    break;

  case 109:
#line 577 "parser.y"
    { ;}
    break;

  case 112:
#line 588 "parser.y"
    { ;}
    break;

  case 118:
#line 597 "parser.y"
    {
		yyvsp[-2].pEntry = generate_code_for_labeled_statement(
							g_outFile,
							yyvsp[-2].pEntry->id_name
							);
	;}
    break;

  case 119:
#line 606 "parser.y"
    {
			/* at this point we know we have processed
			*	all local variables within a function.
			*/

			process_function_local_variables(
									g_outFile
									);
	;}
    break;

  case 129:
#line 636 "parser.y"
    { 
					/* if the expression is a register, mark it free */
					if ( yyvsp[-1].pEntry->ident_ptr.ident_type == IDENT_DEF_EXPR_REG )
					{
						markRegFree(yyvsp[-1].pEntry->ident_ptr.ident_info.expr.expr_reg);
					}
	;}
    break;

  case 130:
#line 646 "parser.y"
    { 

			produce_code_for_selection_expression(g_outFile, yyvsp[-1].pEntry);
	;}
    break;

  case 131:
#line 653 "parser.y"
    { 
			produce_code_for_if_decision(g_outFile);
		;}
    break;

  case 132:
#line 659 "parser.y"
    { 
				produce_code_for_while_loop_begin(g_outFile);
			;}
    break;

  case 133:
#line 665 "parser.y"
    { 
			produce_code_for_else_decision(g_outFile);
			;}
    break;

  case 134:
#line 671 "parser.y"
    {
			produce_code_for_if_statement(
								g_outFile
								);
	;}
    break;

  case 135:
#line 676 "parser.y"
    {
			produce_code_for_if_else_statement(
								g_outFile
								);
	;}
    break;

  case 136:
#line 684 "parser.y"
    {
			produce_code_for_while_statement(
								g_outFile
								);
	;}
    break;

  case 137:
#line 692 "parser.y"
    {
			produce_code_for_goto(
							g_outFile,
							yyvsp[-1].pEntry->id_name
							);
						;}
    break;

  case 138:
#line 698 "parser.y"
    {
			 produce_code_for_continue(
								g_outFile
								);
							;}
    break;

  case 139:
#line 703 "parser.y"
    {
			produce_code_for_break(
								g_outFile
								);
							;}
    break;

  case 140:
#line 708 "parser.y"
    {
			produce_code_for_return_statement(
								g_outFile,
								NULL
								);
	;}
    break;

  case 141:
#line 714 "parser.y"
    {
			produce_code_for_return_statement(
								g_outFile,
								yyvsp[-1].pEntry
								);
	;}
    break;

  case 146:
#line 735 "parser.y"
    {

					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					switch(yyvsp[-3].decl_type)
					{
						case VOID:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_VOID;
							break;

						case INT:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_INT;
							break;

						case CHAR:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_CHAR;
							break;

						default:
							assert(0);
							break;
					}

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							

					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}
					g_curFunction = NULL;
									
	;}
    break;

  case 147:
#line 781 "parser.y"
    { 
					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					switch(yyvsp[-2].decl_type)
					{
						case VOID:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_VOID;
							break;

						case INT:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_INT;
							break;

						case CHAR:
							pFuncDef->ident_ptr.ident_info.func.func_declared_type = FUNC_DEF_DECLARED_CHAR;
							break;

						default:
							assert(0);
							break;
					}

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							


					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}



					g_curFunction = NULL;

	;}
    break;

  case 148:
#line 830 "parser.y"
    { 
					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					pFuncDef->ident_ptr.ident_info.func.func_declared_type = 
							FUNC_DEF_DECLARED_INT;

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							

					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}

					g_curFunction = NULL;

	;}
    break;

  case 149:
#line 860 "parser.y"
    { 
					symtableentry_t	*pFuncDef = NULL;
					int i;

					pop_func_def(
								func_def_stack,
								&pFuncDef
								);

					assert(pFuncDef);

					pFuncDef->ident_ptr.ident_info.func.func_declared_type = 
							FUNC_DEF_DECLARED_INT;

					pFuncDef->ident_ptr.ident_info.func.func_sub_type =
							IDENT_DEF_FUNC_SUB_TYPE_USER_DEFINED;							

					produce_function_epilogue(
											g_outFile,
											pFuncDef
											);

					for ( i = 0; i < max_reg; i++ )
					{
						markRegFree(i);
					}

					g_curFunction = NULL;
	;}
    break;


    }

/* Line 999 of yacc.c.  */
#line 2237 "parser.tab.c"

  yyvsp -= yylen;
  yyssp -= yylen;


  YY_STACK_PRINT (yyss, yyssp);

  *++yyvsp = yyval;


  /* Now `shift' the result of the reduction.  Determine what state
     that goes to, based on the state we popped back to and the rule
     number reduced by.  */

  yyn = yyr1[yyn];

  yystate = yypgoto[yyn - YYNTOKENS] + *yyssp;
  if (0 <= yystate && yystate <= YYLAST && yycheck[yystate] == *yyssp)
    yystate = yytable[yystate];
  else
    yystate = yydefgoto[yyn - YYNTOKENS];

  goto yynewstate;


/*------------------------------------.
| yyerrlab -- here on detecting error |
`------------------------------------*/
yyerrlab:
  /* If not already recovering from an error, report this error.  */
  if (!yyerrstatus)
    {
      ++yynerrs;
#if YYERROR_VERBOSE
      yyn = yypact[yystate];

      if (YYPACT_NINF < yyn && yyn < YYLAST)
	{
	  YYSIZE_T yysize = 0;
	  int yytype = YYTRANSLATE (yychar);
	  const char* yyprefix;
	  char *yymsg;
	  int yyx;

	  /* Start YYX at -YYN if negative to avoid negative indexes in
	     YYCHECK.  */
	  int yyxbegin = yyn < 0 ? -yyn : 0;

	  /* Stay within bounds of both yycheck and yytname.  */
	  int yychecklim = YYLAST - yyn;
	  int yyxend = yychecklim < YYNTOKENS ? yychecklim : YYNTOKENS;
	  int yycount = 0;

	  yyprefix = ", expecting ";
	  for (yyx = yyxbegin; yyx < yyxend; ++yyx)
	    if (yycheck[yyx + yyn] == yyx && yyx != YYTERROR)
	      {
		yysize += yystrlen (yyprefix) + yystrlen (yytname [yyx]);
		yycount += 1;
		if (yycount == 5)
		  {
		    yysize = 0;
		    break;
		  }
	      }
	  yysize += (sizeof ("syntax error, unexpected ")
		     + yystrlen (yytname[yytype]));
	  yymsg = (char *) YYSTACK_ALLOC (yysize);
	  if (yymsg != 0)
	    {
	      char *yyp = yystpcpy (yymsg, "syntax error, unexpected ");
	      yyp = yystpcpy (yyp, yytname[yytype]);

	      if (yycount < 5)
		{
		  yyprefix = ", expecting ";
		  for (yyx = yyxbegin; yyx < yyxend; ++yyx)
		    if (yycheck[yyx + yyn] == yyx && yyx != YYTERROR)
		      {
			yyp = yystpcpy (yyp, yyprefix);
			yyp = yystpcpy (yyp, yytname[yyx]);
			yyprefix = " or ";
		      }
		}
	      yyerror (yymsg);
	      YYSTACK_FREE (yymsg);
	    }
	  else
	    yyerror ("syntax error; also virtual memory exhausted");
	}
      else
#endif /* YYERROR_VERBOSE */
	yyerror ("syntax error");
    }



  if (yyerrstatus == 3)
    {
      /* If just tried and failed to reuse lookahead token after an
	 error, discard it.  */

      /* Return failure if at end of input.  */
      if (yychar == YYEOF)
        {
	  /* Pop the error token.  */
          YYPOPSTACK;
	  /* Pop the rest of the stack.  */
	  while (yyss < yyssp)
	    {
	      YYDSYMPRINTF ("Error: popping", yystos[*yyssp], yyvsp, yylsp);
	      yydestruct (yystos[*yyssp], yyvsp);
	      YYPOPSTACK;
	    }
	  YYABORT;
        }

      YYDSYMPRINTF ("Error: discarding", yytoken, &yylval, &yylloc);
      yydestruct (yytoken, &yylval);
      yychar = YYEMPTY;

    }

  /* Else will try to reuse lookahead token after shifting the error
     token.  */
  goto yyerrlab1;


/*----------------------------------------------------.
| yyerrlab1 -- error raised explicitly by an action.  |
`----------------------------------------------------*/
yyerrlab1:
  yyerrstatus = 3;	/* Each real token shifted decrements this.  */

  for (;;)
    {
      yyn = yypact[yystate];
      if (yyn != YYPACT_NINF)
	{
	  yyn += YYTERROR;
	  if (0 <= yyn && yyn <= YYLAST && yycheck[yyn] == YYTERROR)
	    {
	      yyn = yytable[yyn];
	      if (0 < yyn)
		break;
	    }
	}

      /* Pop the current state because it cannot handle the error token.  */
      if (yyssp == yyss)
	YYABORT;

      YYDSYMPRINTF ("Error: popping", yystos[*yyssp], yyvsp, yylsp);
      yydestruct (yystos[yystate], yyvsp);
      yyvsp--;
      yystate = *--yyssp;

      YY_STACK_PRINT (yyss, yyssp);
    }

  if (yyn == YYFINAL)
    YYACCEPT;

  YYDPRINTF ((stderr, "Shifting error token, "));

  *++yyvsp = yylval;


  yystate = yyn;
  goto yynewstate;


/*-------------------------------------.
| yyacceptlab -- YYACCEPT comes here.  |
`-------------------------------------*/
yyacceptlab:
  yyresult = 0;
  goto yyreturn;

/*-----------------------------------.
| yyabortlab -- YYABORT comes here.  |
`-----------------------------------*/
yyabortlab:
  yyresult = 1;
  goto yyreturn;

#ifndef yyoverflow
/*----------------------------------------------.
| yyoverflowlab -- parser overflow comes here.  |
`----------------------------------------------*/
yyoverflowlab:
  yyerror ("parser stack overflow");
  yyresult = 2;
  /* Fall through.  */
#endif

yyreturn:
#ifndef yyoverflow
  if (yyss != yyssa)
    YYSTACK_FREE (yyss);
#endif
  return yyresult;
}


#line 891 "parser.y"


static void
yyerror(const char *s)
{
	fprintf(stderr, "%d: %s\n", lineno, s);
}

extern	FILE	*yyin;

int
main(int	argc, char *argv[])
{
	symtableentry_t	*pFunc; 
	if ( argc != 3 )
	{
		printf("%s <C program to compile> <file for IL code>\n", argv[0]);
		return 1;
	}

	yyin	=	fopen(argv[1], "r");

	if ( NULL == yyin)
	{
		printf("%s	<cannot open file[%s] for reading\n", argv[0], argv[1]);
		return 1;
	}

	g_outFile = fopen(argv[2], "w");

	if ( NULL == g_outFile )
	{
		printf("%s <cannot open file[%s] for writing\n", argv[0], argv[2]);
		return 1;
	}

	g_SymbolTable = 
	create_symbol_table();

	pFunc = create_symbol_table_entry();

	pFunc->id_name =	strdup("print");
	pFunc->p_next	=	NULL;

	pFunc->ident_ptr.ident_type = IDENT_DEF_FUNCTION;
	pFunc->ident_ptr.ident_info.func.total_formal_parameters = 1;
	pFunc->ident_ptr.ident_info.func.func_sub_type = 
		IDENT_DEF_FUNC_SUB_TYPE_BUILT_IN;

	insert_symbol(
				g_SymbolTable,
				pFunc
				);

	pFunc = create_symbol_table_entry();

	pFunc->id_name =	strdup("printreg");
	pFunc->p_next	=	NULL;

	pFunc->ident_ptr.ident_type = IDENT_DEF_FUNCTION;
	pFunc->ident_ptr.ident_info.func.total_formal_parameters= 0;
	pFunc->ident_ptr.ident_info.func.func_sub_type = 
		IDENT_DEF_FUNC_SUB_TYPE_BUILT_IN;

	insert_symbol(
				g_SymbolTable,
				pFunc
				);

	pFunc = create_symbol_table_entry();

	pFunc->id_name =	strdup("accept");
	pFunc->p_next	=	NULL;

	pFunc->ident_ptr.ident_type = IDENT_DEF_FUNCTION;
	pFunc->ident_ptr.ident_info.func.total_formal_parameters = 1;
	pFunc->ident_ptr.ident_info.func.func_sub_type = 
		IDENT_DEF_FUNC_SUB_TYPE_BUILT_IN;

	insert_symbol(
				g_SymbolTable,
				pFunc
				);

	func_def_stack=
	init_function_def_stack();

	init_reg_list();

	yydebug = 1;
	lineno = 1;
	yyparse();

	return 0;
}
