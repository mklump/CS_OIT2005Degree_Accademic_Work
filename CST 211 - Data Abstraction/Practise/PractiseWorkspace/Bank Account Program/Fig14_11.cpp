// Fig. 14.11: fig14_11.cpp
// Creating a randomly accessed file sequentially
#include <iostream>

using std::cerr;
using std::endl;
using std::ios;

#include <fstream>

using std::ofstream;

#include <cstdlib>

#include "clntdata.h"

int main()
{
   ofstream outCredit( "credit.dat", ios::binary );

   if ( !outCredit ) {
      cerr << "File could not be opened." << endl;
      exit( 1 );
   }

   clientData blankClient = { 0, "", "", 0.0 };

   for ( int i = 0; i < 100; i++ )
      outCredit.write( 
         reinterpret_cast<const char *>( &blankClient ), 
         sizeof( clientData ) );
   return 0;
}



/**************************************************************************
 * (C) Copyright 2000 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
