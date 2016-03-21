// JNIStaticWrapperImpl.cpp
// Integrates with JNI to retrieve the static
// members of the given MathConstant object

// C++ core headers
#include <iostream.h>

// header produced by javah
#include "JNIStaticWrapper.h"

JNIEXPORT void JNICALL Java_JNIStaticWrapper_printStaticMembers
   (JNIEnv * env, jobject thisObject, jobject MathObject) 
{
   jclass constantClass;
   jfieldID fieldID;
   jmethodID methodID; 
  
   // get class of MathObject
   constantClass = env->GetObjectClass( MathObject );

   // retrieve FieldID of static member variable E
   fieldID = env->GetFieldID( constantClass, "E", "D" );
   
   // retrieves double at given fieldID
   const jdouble E = env->GetDoubleField( MathObject, fieldID );
   
   // output to show proper retrieval
   cout << "Value of E in MathConstants is " << E << endl;

   fieldID = env->GetStaticFieldID( constantClass, "PI", "D" );
   const jdouble PI = env->GetStaticDoubleField( constantClass, fieldID );
   
   cout << "Value of PI in MathConstants is " << PI << endl;
   
   // retrieve static method id
   methodID = env->GetStaticMethodID( 
      constantClass, "getPI", "()D" );

   // invoke static method getPI
   env->CallStaticDoubleMethod( constantClass , methodID);
}
