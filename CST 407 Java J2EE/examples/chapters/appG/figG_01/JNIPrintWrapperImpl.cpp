// JNIPrintWrapperImpl.cpp
// Implements the header created by java
// to integrate with JNI.

// C++ core header
#include <iostream.h>

// header produced by javah
#include "JNIPrintWrapper.h"

// prints the string given from java
JNIEXPORT void JNICALL Java_JNIPrintWrapper_printMessage
   ( JNIEnv * env, jobject thisObject, jstring message )
{
   // boolean to determine if string is copied
   jboolean copied;

   // call JNI method to convert jstring to cstring
   const char* charMessage = 
       env->GetStringUTFChars( message, &copied );
   
   // print the message
   cout << charMessage;

   // release the string to prevent memory leak
   env->ReleaseStringUTFChars( message, charMessage );
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
