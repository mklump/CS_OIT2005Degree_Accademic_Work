// JNIArrayWrapperImpl.cpp
// Implements the header created by java to integrate with JNI
// Creates a new array of random integers and returns it to java.

// C++ core header
#include <stdlib.h>
#include <time.h>

// header produced by javah
#include "JNIArrayWrapper.h"

// creates and fills 2 arrays
JNIEXPORT jintArray JNICALL Java_JNIArrayWrapper_newRandomArray
                ( JNIEnv * env, jobject thisObject, jint size )
{
   srand( time( NULL ) );

   // boolean to determine if elements are copied
   jboolean isCopy;

   // temporary variables
   int randomInt;
   jobject randomIntegerObject;

   // locate object and constructor
   jclass integerClass = env->FindClass( "java/lang/Integer" );
   jmethodID mid = 
      env->GetMethodID( integerClass, "<init>", "(I)V" );
   
   // build new Integer array of length size
   jobjectArray objectArray = 
      env->NewObjectArray( size, integerClass, NULL );
   
   // create new primitive int array
   jintArray intArray = env->NewIntArray( size );
   
   // return pointer to array of elements
   jint * intArrayPointer = 
      env->GetIntArrayElements( intArray, &isCopy );
   
   // fill arrays with pseudo random numbers
   for ( int i = 0 ; i < size ; i++ ) {

      // create random int
      randomInt = rand() % 100;
      
      // create Integer with random int
      randomIntegerObject =  
         env->NewObject( integerClass, mid, randomInt );
      
      // add element to Integer array
      env->SetObjectArrayElement( 
         objectArray, i, randomIntegerObject );

      // assign random int to primitive array
      intArrayPointer[ i ] = randomInt;
   }

   // if JNI made a copy, release it and update Java
   if ( isCopy == JNI_TRUE ) {
      env->ReleaseIntArrayElements( intArray, intArrayPointer, 0 );
   }

   return intArray;
}

/***************************************************************
 * (C) Copyright 2002 by Deitel & Associates, Inc. and         *
 * Prentice Hall. All Rights Reserved.                         *
 *                                                             *
 * DISCLAIMER: The authors and publisher of this book have     *
 * used their best efforts in preparing the book. These        *
 * efforts include the development, research, and testing of   *
 * the theories and programs to determine their effectiveness. *
 * The authors and publisher make no warranty of any kind,     *
 * expressed or implied, with regard to these programs or to   *
 * the documentation contained in these books. The authors     *
 * and publisher shall not be liable in any event for          *
 * incidental or consequential damages in connection with, or  *
 * arising out of, the furnishing, performance, or use of      *
 * these programs.                                             *
 ***************************************************************/

