// JNITintImage.cpp tints an array of RGB values by given colors.
// Throws exception if image is larger than 256x256, also returns 
// an int array of indexes of pixels that could not be fully tinted. 

// max image size is 256x256
#define MAX_IMAGE_SIZE 65536

// include JNI header
#include "JNITintWrapper.h"

JNIEXPORT jintArray JNICALL Java_JNITintWrapper_tintImage
   ( JNIEnv * env, jobject thisObject, jintArray imageRGB, 
      jint length, jint rTint, jint gTint, jint bTint ) {
   
   jclass sizeException, pixelTintException;
   
   if ( length > MAX_IMAGE_SIZE ) {
  
      // obtain the jclass ImageSizeException
      sizeException = env->FindClass( "ImageSizeException" );
     
      // throw the exception
      env->ThrowNew( sizeException, "Image is too large" );
      
      // return and allow Java to handle the exception
      return NULL;
   }

   // obtain jclass of PixelTintException for use later
   pixelTintException = env->FindClass( "PixelTintException" );
   
   jthrowable exception;
   int warningCount = 0;
   jboolean isCopy, isCopy1;
   unsigned int red, blue, green;

   // create a new array of size length
   jintArray warningArray = env->NewIntArray( length );

   // obtain a pointer to the array object
   jint * warningArrayPointer = 
      env->GetIntArrayElements( warningArray, &isCopy );

   // storage location for RGB array elements
   long* elements;

   // points elements to the integer array
   elements = env->GetIntArrayElements( imageRGB, &isCopy1 );

   
   for ( int i = 0 ; i < length ; i++ ) {

         // determine red element by bit shifting
         red = elements[ i ] & 0xFF0000;
      
         // determine green element by bit shifting
         green = elements[ i ] & 0xFF00;
         
         // determine blue element by bit shifting    
         blue = elements[ i ] & 0xFF;
         
         red += rTint << 16;
         green += gTint << 8;
         blue += bTint;

         // throw exception if red value is too large
         if ( red  > 0xFF0000 ) {
            env->ThrowNew( 
               pixelTintException, "red value reduced to 255" );
            red = 0xFF0000;
         }

         if ( green > 0xFF00 ) {
            env->ThrowNew( 
               pixelTintException, "green value reduced to 255");
            green = 0xFF00;
         }

         if ( blue > 0xFF ) {
            env->ThrowNew( 
               pixelTintException, "blue value reduced to 255" );
            blue = 0xFF;
         }

         // if an exception occurs store it in exception
         if ( ( exception = env->ExceptionOccurred() ) != NULL ) {

            // if exception was of type pixelTintException record 
            // the index in an array and clear the exception
            if ( env->IsInstanceOf(  
               exception, pixelTintException ) == JNI_TRUE ) {
               warningArrayPointer[warningCount] = i;
               warningCount++;
               env->ExceptionClear();
            }

            //else we do not know the exception type, return.
            else
               return warningArray;
         }

         // shift bits to recreate pixel
         elements[i]  = 
            0xFF000000 | red | green | blue;
   }
   
   // if first array is copy, release it
   if ( isCopy ) 
      env->ReleaseIntArrayElements( warningArray, 
         warningArrayPointer, 0);

   // if second array is copy, release it
   if ( isCopy1 ) 
      env->ReleaseIntArrayElements( imageRGB, elements, 0);

   if ( warningCount != 0 )
      // return any warnings
      return warningArray;
   else
      // no warnings
      return NULL;
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

