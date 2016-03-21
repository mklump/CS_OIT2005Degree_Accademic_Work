// Fig. 14.12: fig14_12.cpp
// Writing to a random access file
#include <iostream>

using std::cerr;
using std::endl;
using std::cout;
using std::cin;
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

   cout << "Enter account number "
        << "(1 to 100, 0 to end input)\n? ";

   clientData client;
   cin >> client.accountNumber;

   while ( client.accountNumber > 0 && 
           client.accountNumber <= 100 ) {
      cout << "Enter lastname, firstname, balance\n? ";
      cin >> client.lastName >> client.firstName 
          >> client.balance;

      outCredit.seekp( ( client.accountNumber - 1 ) * 
                       sizeof( clientData ) );
      outCredit.write( 
         reinterpret_cast<const char *>( &client ), 
         sizeof( clientData ) );

      cout << "Enter account number\n? ";
      cin >> client.accountNumber;
   }

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
