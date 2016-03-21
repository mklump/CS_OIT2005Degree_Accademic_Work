// JNICallMethod.cpp
// Calls methods on the PIContainer object sent to it.
// Creates new Java objects.

// standard c header
#include <iostream.h>

// header produced by javah
#include "JNIPIWrapper.h"

// retrieves value of PI based on passed PIContainer.
JNIEXPORT jdouble JNICALL Java_JNIPIWrapper_getPI__LPIContainer_2
(JNIEnv * env, jobject thisObject, jobject containerObject)
{
   // retrieve PIContainer class
   jclass PIClass = env->GetObjectClass( containerObject );
   
   // retrieve method ID of getPI
   jmethodID mid = env->GetMethodID( PIClass, "getPI", "()D" );
   
   // call method getPI of class PIContainer with no arguments
   jdouble PI = env->CallDoubleMethod( containerObject, mid, NULL );

   return PI;
}

// retrives value of PI by creating new PIContainer
JNIEXPORT jdouble JNICALL Java_JNIPIWrapper_getPI__
  (JNIEnv * env, jobject thisObject) {

   // finds Class PIContainer
   jclass PIClass = env->FindClass( "PIContainer" );

   // retrieves ID of constructor
   jmethodID constructorID = 
      env->GetMethodID( PIClass, "<init>", "()V" );
   
   // creates new PIContainer
   jobject newContainer =
       env->NewObject( PIClass, constructorID, NULL );
   
   // retrieves method ID of getPI
   jmethodID mid = env->GetMethodID( PIClass, "getPI", "()D" );

    // call method getPI of class PIContainer with no arguments
   jdouble PI = env->CallDoubleMethod( newContainer, mid, NULL );

   return PI;
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
