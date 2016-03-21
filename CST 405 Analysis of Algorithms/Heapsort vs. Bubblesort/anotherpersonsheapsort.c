/*-------------------Start heapsort.c program-------------------*/

/****************************************************************/
/*                         HEAPSORT                             */
/*                     C Program Source                         */
/*          Heapsort program for variable sized arrays          */
/*                 Version 1.0, 04 Oct 1992                     */
/*                Al Aburto, aburto@nosc.mil                    */
/*                                                              */
/* Based on the Heap Sort code in 'Numerical Recipes in C' by   */
/* William H. Press, Brian P. Flannery, Saul A. Teukolsky, and  */
/* William T. Vetterling, Cambridge University Press, 1990,     */
/* ISBN 0-521-35465-X.                                          */
/*                                                              */
/* The MIPS rating is based upon the program run time (runtime) */
/* for one iteration and a gcc 2.1 unoptimized (gcc -DUNIX)     */
/* assembly dump count of instructions per iteration for a i486 */
/* machine (assuming 80386 code).  This is the reference used.  */
/*                                                              */
/* The maximum amount of memory allocated is based on the 'imax'*/
/* variable in main(). Memory size = (2000*sizeof(long))*2^imax.*/
/* imax is currently set to 8, but this value may be increased  */
/* or decreased depending upon your system memory limits. For   */
/* standard Intel PC CPU machines a value of imax = 3 must be   */
/* used else your system may crash or hang up despite code in   */
/* the program to prevent this.                                 */
/****************************************************************/

/****************************************************/
/* Example Compilation:                             */
/* (1) UNIX Systems:                                */
/*     cc -DUNIX -O heapsort.c -o heapsort          */
/*     cc -DUNIX heapsort.c -o heapsort             */
/****************************************************/

/***************************************************************/
/* Timer options. You MUST uncomment one of the options below  */
/* or compile, for example, with the '-DUNIX' option.          */
/***************************************************************/
/* #define Amiga       */
/* #define UNIX        */
/* #define UNIX_Old    */
/* #define VMS         */
/* #define BORLAND_C   */
/* #define MSC         */
/* #define MAC         */
/* #define IPSC        */
/* #define FORTRAN_SEC */
/* #define GTODay      */
/* #define CTimer      */
/* #define UXPM        */
/* #define MAC_TMgr    */
/* #define PARIX       */
/* #define POSIX       */
/* #define WIN32       */
/* #define POSIX1      */
/***********************/

#include <stdio.h>
#include <math.h>

#ifdef Amiga
#include <exec/types.h>
#include <ctype.h>
#endif

#ifdef BORLAND_C
#include <ctype.h>
#include <dos.h>
#endif

#ifdef MSC
#include <ctype.h>
#endif

double nulltime,runtime,sta,stb,dtime();
double emips,hmips,lmips,smips[21];

long bplong,ErrorFlag;

long NLoops[21];


void main()
{

long  i,j,k,p,imax;

bplong = sizeof(long);

printf("\n   Heap Sort C Program\n");
printf("   Version 1.0, 04 Oct 1992\n\n");

printf("   Size of long (bytes): %d\n\n",bplong);

printf("   Array Size    RunTime      Scale    MIPS\n");       
printf("    (bytes)       (sec)\n");

				  /* NLoops[] holds number of loops  */
				  /* (iterations) to conduct. Preset */
				  /* to 1 iteration.                 */
for( i=0 ; i<= 20 ; i++)
{
 NLoops[i] = 1;
}
				  /* Predetermine runtime (sec) for  */
				  /* memory size 2000 * sizeof(long),*/
				  /* and 256 iterations. p = 0 means */
				  /* don't print the result.         */
j = 2000;
k = 256;
p = 0;
HSORT(j,k,p);
				  /* Set number of iterations (loops)*/
				  /* based on runtime above --- so   */
				  /* program won't take forever on   */
				  /* the slower machines.            */
i = 8;
if ( runtime > 0.125 ) i = 1;

NLoops[0] =  32 * i; 
NLoops[1] =  16 * i; 
NLoops[2] =   8 * i;
NLoops[3] =   4 * i;
NLoops[4] =   2 * i;
NLoops[5] =       i;
NLoops[6] =   i / 2;
NLoops[7] =   i / 4;

if ( i == 1 )
{
NLoops[6]  = 1;
NLoops[7]  = 1;
}
				  /* Redo the first run and print    */
				  /* the results.                    */
j = 2000;
k = NLoops[0];
p = 1;
HSORT(j,k,p);
				  /* Save estimated mips result      */
smips[0] = emips;

j = 2000;
ErrorFlag = 0;
				  /* Now do it for memory sizes up to */ 
				  /* (2000*sizeof(long)) * (2 ** imax)*/
				  /* where imax determines maximum    */
				  /* amount of memory allocated.      */
				  /* Currently I set imax = 8, so if  */
				  /* sizeof(long) = 4 program will run*/
				  /* from 8000, 16000, ..., and up to */
				  /* 2048000 byte memory size. You can*/
				  /* increase imax, but imax = 8 is   */
				  /* limit for this test program.     */
imax = 8;
for( i=1 ; i<= imax ; i++)
{
   j = 2 * j;

   k = NLoops[i];

   HSORT(j,k,p);
   smips[i] = emips;

   if( ErrorFlag > 0L ) break;

}

if( ErrorFlag == 2L )
{
printf("\n   Could Not Allocate Memory for Array Size: %ld\n",j*bplong);
}

hmips = 0.0;
lmips = 1.0e+06;
for( k = 0; k < i; k++)
{
if( smips[k] > hmips ) hmips = smips[k];
if( smips[k] < lmips ) lmips = smips[k];
}

printf("\n   Runtime is the average for 1 iteration.\n");
printf("   High MIPS = %8.2lf\n",hmips);
printf("   Low  MIPS = %8.2lf\n\n",lmips);

}                                  /* End of main */


/*************************/
/*  Heap Sort Program    */
/*************************/

HSORT(m,n,p)
long m,n,p;
{

register long *base;
register long i,j,k,l;
register long size;

long  iter,msize,iran,ia,ic,im,ih,ir;
long  count,ca,cb,cc,cd,ce,cf;

msize = m * bplong;
size  = m - 1;
base  = (long *)malloc((unsigned)msize);

ia = 106;
ic = 1283;
im = 6075;
ih = 1001;

   ErrorFlag = 0L;

   if( !base )
     {
     ErrorFlag = 2L;
     return 0;
     }

   sta = dtime();
   stb = dtime();
   nulltime = stb - sta;
   if ( nulltime < 0.0 ) nulltime = 0.0;

   count = 0;
   sta = dtime();                       /* Start timing */
   for(iter=1 ; iter<=n ; iter++)       /* Do 'n' iterations */             

   {
       iran = 47;                        /* Fill with 'random' numbers */
       for(i=1 ; i<=size ; i++)                      
       {
       iran = (iran * ia + ic) % im;
       *(base+i) = 1 + (ih * iran) / im;
       }
       
       k = (size >> 1) + 1;              /* Heap sort the array */
       l = size;
       ca = 0; cb = 0; cc = 0;
       cd = 0; ce = 0; cf = 0;

       for (;;)
       {
       ca++;
       if (k > 1)
       {
	  cb++;
	  ir = *(base+(--k));
       }
       else
       {  
	  cc++;
	  ir = *(base+l);
	  *(base+l) = *(base+1);
	  if (--l == 1)
	  {
	       *(base+1) = ir;
	       goto Done;
	  }
       }

       i = k;
       j = k << 1;

       while (j <= l)
       {
	  cd++;
	  if ( (j < l) && (*(base+j) < *(base+j+1)) ) ++j;
	  if (ir < *(base+j))
	  {
	       ce++;
	       *(base+i) = *(base+j);   
	       j += (i=j);
	  }
	  else 
	  {
	       cf++;
	       j = l + 1;
	  }
       }
       *(base+i) = ir;
       } 
Done:   
   count = count + ca;
   }
   stb = dtime();                       /* Stop timing */     
   runtime = stb - sta;
   if ( runtime < 0.0 ) runtime = 0.0;
				       /* Scale runtime per iteration */
   runtime = (runtime - nulltime) / (double)n;
       
   ir = count / n;
   ir = (ir + ca) / 2;
				       /* Estimate MIPS rating */
   emips = 24.0 * (double)size + 10.0 * (double)ir;
   emips = emips + 6.0 * (double)cb + 9.0 * (double)cc;
   emips = emips + 10.0 * (double)cd + 7.0 * (double)ce;
   emips = emips + 4.0 * (double)cf;
   sta   = 1.0e-06 * emips;
   emips = sta / runtime;

   if ( p != 0L )
   {
   printf("   %10ld %10.4lf %10.4lf %7.2lf\n",msize,runtime,sta,emips);
   }
free(base);
return 0;
}

/*****************************************************/
/* Various timer routines.                           */
/* Al Aburto, aburto@nosc.mil, 18 Feb 1997           */
/*                                                   */
/* t = dtime() outputs the current time in seconds.  */
/* Use CAUTION as some of these routines will mess   */
/* up when timing across the hour mark!!!            */
/*                                                   */
/* For timing I use the 'user' time whenever         */
/* possible. Using 'user+sys' time is a separate     */
/* issue.                                            */
/*                                                   */
/* Example Usage:                                    */
/* [timer options added here]                        */
/* main()                                            */
/* {                                                 */
/* double starttime,benchtime,dtime();               */
/*                                                   */
/* starttime = dtime();                              */ 
/* [routine to time]                                 */
/* benchtime = dtime() - starttime;                  */
/* }                                                 */
/*                                                   */
/* [timer code below added here]                     */
/*****************************************************/

/*********************************/
/* Timer code.                   */
/*********************************/
/*******************/
/*  Amiga dtime()  */
/*******************/
#ifdef Amiga
#include <ctype.h>
#define HZ 50

double dtime()
{
 double q;

 struct tt
       {
	long  days;
	long  minutes;
	long  ticks;
       } tt;

 DateStamp(&tt);

 q = ((double)(tt.ticks + (tt.minutes * 60L * 50L))) / (double)HZ;

 return q;
}
#endif

/*****************************************************/
/*  UNIX dtime(). This is the preferred UNIX timer.  */
/*  Provided by: Markku Kolkka, mk59200@cc.tut.fi    */
/*  HP-UX Addition by: Bo Thide', bt@irfu.se         */
/*****************************************************/
#ifdef UNIX
#include <sys/time.h>
#include <sys/resource.h>

#ifdef hpux
#include <sys/syscall.h>
#define getrusage(a,b) syscall(SYS_getrusage,a,b)
#endif

struct rusage rusage;

double dtime()
{
 double q;

 getrusage(RUSAGE_SELF,&rusage);

 q = (double)(rusage.ru_utime.tv_sec);
 q = q + (double)(rusage.ru_utime.tv_usec) * 1.0e-06;
	
 return q;
}
#endif

/***************************************************/
/*  UNIX_Old dtime(). This is the old UNIX timer.  */
/*  Make sure HZ is properly defined in param.h !! */
/***************************************************/
#ifdef UNIX_Old
#include <sys/types.h>
#include <sys/times.h>
#include <sys/param.h>

#ifndef HZ
#define HZ 60
#endif

struct tms tms;

double dtime()
{
 double q;

 times(&tms);

 q = (double)(tms.tms_utime) / (double)HZ;
	
 return q;
}
#endif

/*********************************************************/
/*  VMS dtime() for VMS systems.                         */
/*  Provided by: RAMO@uvphys.phys.UVic.CA                */
/*  Some people have run into problems with this timer.  */
/*********************************************************/
#ifdef VMS
#include time

#ifndef HZ
#define HZ 100
#endif

struct tbuffer_t
      {
       int proc_user_time;
       int proc_system_time;
       int child_user_time;
       int child_system_time;
      };

struct tbuffer_t tms;

double dtime()
{
 double q;

 times(&tms);

 q = (double)(tms.proc_user_time) / (double)HZ;
	
 return q;
}
#endif

/******************************/
/*  BORLAND C dtime() for DOS */
/******************************/
#ifdef BORLAND_C
#include <ctype.h>
#include <dos.h>
#include <time.h>

#define HZ 100
struct time tnow;

double dtime()
{
 double q;

 gettime(&tnow);

 q = 60.0 * (double)(tnow.ti_min);
 q = q + (double)(tnow.ti_sec);
 q = q + (double)(tnow.ti_hund)/(double)HZ;
	
 return q;
}
#endif

/**************************************/
/*  Microsoft C (MSC) dtime() for DOS */
/**************************************/
#ifdef MSC
#include <time.h>
#include <ctype.h>

#define HZ CLOCKS_PER_SEC
clock_t tnow;

double dtime()
{
 double q;

 tnow = clock();

 q = (double)tnow / (double)HZ;
	
 return q;
}
#endif

/*************************************/
/*  Macintosh (MAC) Think C dtime()  */
/*************************************/
#ifdef MAC
#include <time.h>

#define HZ 60

double dtime()
{
 double q;

 q = (double)clock() / (double)HZ;
	
 return q;
}
#endif

/************************************************************/
/*  iPSC/860 (IPSC) dtime() for i860.                       */
/*  Provided by: Dan Yergeau, yergeau@gloworm.Stanford.EDU  */
/************************************************************/
#ifdef IPSC
extern double dclock();

double dtime()
{
 double q;

 q = dclock();
	
 return q;
}
#endif

/**************************************************/
/*  FORTRAN dtime() for Cray type systems.        */
/*  This is the preferred timer for Cray systems. */
/**************************************************/
#ifdef FORTRAN_SEC

fortran double second();

double dtime()
{
 double q;

 second(&q);
	
 return q;
}
#endif

/***********************************************************/
/*  UNICOS C dtime() for Cray UNICOS systems.  Don't use   */
/*  unless absolutely necessary as returned time includes  */
/*  'user+system' time.  Provided by: R. Mike Dority,      */
/*  dority@craysea.cray.com                                */
/***********************************************************/
#ifdef CTimer
#include <time.h>

double dtime()
{
 double    q;
 clock_t   clock(void);

 q = (double)clock() / (double)CLOCKS_PER_SEC;

 return q;
}
#endif

/********************************************/
/* Another UNIX timer using gettimeofday(). */
/* However, getrusage() is preferred.       */
/********************************************/
#ifdef GTODay
#include <sys/time.h>

struct timeval tnow;

double dtime()
{
 double q;

 gettimeofday(&tnow,NULL);
 q = (double)tnow.tv_sec + (double)tnow.tv_usec * 1.0e-6;

 return q;
}
#endif

/*****************************************************/
/*  Fujitsu UXP/M timer.                             */
/*  Provided by: Mathew Lim, ANUSF, M.Lim@anu.edu.au */
/*****************************************************/
#ifdef UXPM
#include <sys/types.h>
#include <sys/timesu.h>
struct tmsu rusage;

double dtime()
{
 double q;

 timesu(&rusage);

 q = (double)(rusage.tms_utime) * 1.0e-06;
	
 return q;
}
#endif

/**********************************************/
/*    Macintosh (MAC_TMgr) Think C dtime()    */
/*   requires Think C Language Extensions or  */
/*    #include <MacHeaders> in the prefix     */
/*  provided by Francis H Schiffer 3rd (fhs)  */
/*         skipschiffer@genie.geis.com        */
/**********************************************/
#ifdef MAC_TMgr
#include <Timer.h>
#include <stdlib.h>

static TMTask   mgrTimer;
static Boolean  mgrInited = false;
static double   mgrClock;

#define RMV_TIMER RmvTime( (QElemPtr)&mgrTimer )
#define MAX_TIME  1800000000L
/* MAX_TIME limits time between calls to */
/* dtime( ) to no more than 30 minutes   */
/* this limitation could be removed by   */
/* creating a completion routine to sum  */
/* 30 minute segments (fhs 1994 feb 9)   */

static void Remove_timer( )
{
 RMV_TIMER;
 mgrInited = false;
}

double  dtime( )
{
 if( mgrInited ) {
   RMV_TIMER;
   mgrClock += (MAX_TIME + mgrTimer.tmCount)*1.0e-6;
 } else {
   if( _atexit( &Remove_timer ) == 0 ) mgrInited = true;
   mgrClock = 0.0;
 }
 
 if ( mgrInited )
   {
    mgrTimer.tmAddr = NULL;
    mgrTimer.tmCount = 0;
    mgrTimer.tmWakeUp = 0;
    mgrTimer.tmReserved = 0;
    InsTime( (QElemPtr)&mgrTimer );
    PrimeTime( (QElemPtr)&mgrTimer, -MAX_TIME );
   }
 return( mgrClock );
}
#endif

/***********************************************************/
/*  Parsytec GCel timer.                                   */
/*  Provided by: Georg Wambach, gw@informatik.uni-koeln.de */
/***********************************************************/
#ifdef PARIX
#include <sys/time.h>

double dtime()
{
 double q;

 q = (double) (TimeNowHigh()) / (double) CLK_TCK_HIGH;

 return q;
}
#endif

/************************************************/
/*  Sun Solaris POSIX dtime() routine           */
/*  Provided by: Case Larsen, CTLarsen.lbl.gov  */
/************************************************/
#ifdef POSIX
#include <sys/time.h>
#include <sys/resource.h>
#include <sys/rusage.h>

#ifdef __hpux
#include <sys/syscall.h>
#endif

struct rusage rusage;

double dtime()
{
 double q;

 getrusage(RUSAGE_SELF,&rusage);

 q = (double)(rusage.ru_utime.tv_sec);
 q = q + (double)(rusage.ru_utime.tv_nsec) * 1.0e-09;
	
 return q;
}
#endif


/****************************************************/
/*  Windows NT (32 bit) dtime() routine             */
/*  Provided by: Piers Haken, piersh@microsoft.com  */
/****************************************************/
#ifdef WIN32
#include <windows.h>

double dtime(void)
{
 double q;

 q = (double)GetTickCount() * 1.0e-03;
	
 return q;
}
#endif

/*****************************************************/
/* Time according to POSIX.1  -  <J.Pelan@qub.ac.uk> */
/* Ref: "POSIX Programmer's Guide"  O'Reilly & Assoc.*/
/*****************************************************/
#ifdef POSIX1
#define _POSIX_SOURCE 1
#include <unistd.h>
#include <limits.h>
#include <sys/times.h>

struct tms tms;

double dtime()
{
 double q;
 times(&tms);
 q = (double)tms.tms_utime / (double)CLK_TCK;
 return q;
}
#endif

/*------ End of heapsort.c, say goodnight Vicki! (Sep 1992) ------*/
