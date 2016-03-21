// Fig. 14.14: fig14_14.cpp
// Reading a random access file sequentially
#include <iostream>

using std::cout;
using std::endl;
using std::ios;
using std::cerr;

#include <iomanip>

using std::setprecision;
using std::setiosflags;
using std::resetiosflags;
using std::setw;

#include <fstream>

using std::ifstream;
using std::ostream;

#include <cstdlib>
#include "clntdata.h"
 
void outputLine( ostream&, const clientData & );

int main()
{
   ifstream inCredit( "credit.dat", ios::in );

   if ( !inCredit ) {
      cerr << "File could not be opened." << endl;
      exit( 1 );
   }

   cout << setiosflags( ios::left ) << setw( 10 ) << "Account"
        << setw( 16 ) << "Last Name" << setw( 11 )
        << "First Name" << resetiosflags( ios::left )
        << setw( 10 ) << "Balance" << endl;

   clientData client;

   inCredit.read( reinterpret_cast<char *>( &client ), 
                  sizeof( clientData ) );

   while ( inCredit && !inCredit.eof() ) {

      if ( client.accountNumber != 0 )
         outputLine( cout, client );

      inCredit.read( reinterpret_cast<char *>( &client ),
                     sizeof( clientData ) );
   }

   return 0;
}

void outputLine( ostream &output, const clientData &c )
{
   output << setiosflags( ios::left ) << setw( 10 ) 
          << c.accountNumber << setw( 16 ) << c.lastName 
          << setw( 11 ) << c.firstName << setw( 10 ) 
          << setprecision( 2 ) << resetiosflags( ios::left )  
          << setiosflags( ios::fixed | ios::showpoint )
          << c.balance << '\n';
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
