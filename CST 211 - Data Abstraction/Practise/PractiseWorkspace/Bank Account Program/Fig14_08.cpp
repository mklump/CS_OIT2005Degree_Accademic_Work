// Fig. 14.8: fig14_08.cpp
// Credit inquiry program
#include <iostream>

using std::cout;
using std::cin;
using std::ios;
using std::cerr;
using std::endl;

#include <fstream>

using std::ifstream;

#include <iomanip>

using std::setiosflags;
using std::resetiosflags;
using std::setw;
using std::setprecision;

#include <cstdlib>    
 
enum RequestType { ZERO_BALANCE = 1, CREDIT_BALANCE, 
                   DEBIT_BALANCE, END };
int getRequest();
bool shouldDisplay( int, double );
void outputLine( int, const char * const, double );

int main()
{
   // ifstream constructor opens the file
   ifstream inClientFile( "clients.dat", ios::in );

   if ( !inClientFile ) {
      cerr << "File could not be opened" << endl;
      exit( 1 );
   }

   int request, account;
   char name[ 30 ];
   double balance;

   cout << "Enter request\n"
        << " 1 - List accounts with zero balances\n"
        << " 2 - List accounts with credit balances\n"
        << " 3 - List accounts with debit balances\n" 
        << " 4 - End of run"
        << setiosflags( ios::fixed | ios::showpoint );
   request = getRequest();

   while ( request != END ) {

      switch ( request ) {
         case ZERO_BALANCE:
            cout << "\nAccounts with zero balances:\n";
            break;
         case CREDIT_BALANCE:
            cout << "\nAccounts with credit balances:\n";
            break;
         case DEBIT_BALANCE:
            cout << "\nAccounts with debit balances:\n";
            break;
      }

      inClientFile >> account >> name >> balance;

      while ( !inClientFile.eof() ) {
         if ( shouldDisplay( request, balance ) )
            outputLine( account, name, balance );

         inClientFile >> account >> name >> balance;
      }
      
      inClientFile.clear();    // reset eof for next input
      inClientFile.seekg( 0 ); // move to beginning of file
      request = getRequest();
   }

   cout << "End of run." << endl;

   return 0;   // ifstream destructor closes the file
}

int getRequest()
{ 
   int request;
   
   do {
      cout << "\n? ";
      cin >> request;
   } while( request < ZERO_BALANCE && request > END );

   return request;
}

bool shouldDisplay( int type, double balance )
{
   if ( type == CREDIT_BALANCE && balance < 0 )
      return true;

   if ( type == DEBIT_BALANCE && balance > 0 )
      return true;

   if ( type == ZERO_BALANCE && balance == 0 )
      return true;

   return false;
}

void outputLine( int acct, const char * const name, double bal )
{
   cout << setiosflags( ios::left ) << setw( 10 ) << acct
        << setw( 13 ) << name << setw( 7 ) << setprecision( 2 )
        << resetiosflags( ios::left )        
        << bal << '\n';
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
