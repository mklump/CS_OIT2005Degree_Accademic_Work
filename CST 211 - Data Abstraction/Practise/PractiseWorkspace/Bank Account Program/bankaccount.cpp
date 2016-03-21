// Fig. 14.15: fig14_15.cpp
// This program reads a random access file sequentially,
// updates data already written to the file, creates new
// data to be placed in the file, and deletes data
// already in the file.
#ifndef CLNTDATA_H
#define CLNTDATA_H

struct clientData {
   int accountNumber;
   char lastName[ 15 ];
   char firstName[ 10 ];
   double balance;
};

#endif

#include <iostream>

using std::cout;
using std::cerr;
using std::cin;
using std::endl;
using std::ios;

#include <fstream>

using std::ofstream;
using std::ostream;
using std::fstream;

#include <iomanip>

using std::setiosflags;
using std::resetiosflags;
using std::setw;
using std::setprecision;

#include <cstdlib>
//#include "clntdata.h"

int enterChoice();
void textFile( fstream& );
void updateRecord( fstream& );
void newRecord( fstream& );
void deleteRecord( fstream& );
void outputLine( ostream&, const clientData & );
int getAccount( const char * const );

enum Choices { TEXTFILE = 1, UPDATE, NEW, DELETE, END };

int main()
{
   fstream inOutCredit( "credit.txt", ios::in | ios::out );

   if ( !inOutCredit ) {
      cerr << "File could not be opened." << endl;
      exit ( 1 );
   }
   
   int choice;

   while ( ( choice = enterChoice() ) != END ) {

      switch ( choice ) {
         case TEXTFILE:
            textFile( inOutCredit );
            break;
         case UPDATE:
            updateRecord( inOutCredit );
            break;
         case NEW:
            newRecord( inOutCredit );
            break;
         case DELETE:
            deleteRecord( inOutCredit );
            break;
         default:
            cerr << "Incorrect choice\n";
            break;
      }

      inOutCredit.clear();  // resets end-of-file indicator
   }

   return 0;
}

// Prompt for and input menu choice
int enterChoice()
{
   cout << "\nEnter your choice" << endl
        << "1 - store a formatted text file of accounts\n"
        << "    called \"print.txt\" for printing\n"
        << "2 - update an account\n"
        << "3 - add a new account\n"
        << "4 - delete an account\n"
        << "5 - end program\n? ";

   int menuChoice;
   cin >> menuChoice;
   return menuChoice;
}

// Create formatted text file for printing
void textFile( fstream &readFromFile )
{
   ofstream outPrintFile( "print.txt", ios::out );

   if ( !outPrintFile ) {
      cerr << "File could not be opened." << endl;
      exit( 1 );
   }

   outPrintFile << setiosflags( ios::left ) << setw( 10 ) 
       << "Account" << setw( 16 ) << "Last Name" << setw( 11 )
       << "First Name" << resetiosflags( ios::left ) 
       << setw( 10 ) << "Balance" << endl;
   readFromFile.seekg( 0 );

   clientData client;
   readFromFile.read( reinterpret_cast<char *>( &client ),
                      sizeof( clientData ) );

   while ( !readFromFile.eof() ) {
      if ( client.accountNumber != 0 )
         outputLine( outPrintFile, client );

      readFromFile.read( reinterpret_cast<char *>( &client ), 
                         sizeof( clientData ) );
   }
}

// Update an account's balance
void updateRecord( fstream &updateFile )
{
   int account = getAccount( "Enter account to update" );

   updateFile.seekg( ( account - 1 ) * sizeof( clientData ) );

   clientData client;
   updateFile.read( reinterpret_cast<char *>( &client ), 
                    sizeof( clientData ) );

   if ( client.accountNumber != 0 ) {
      outputLine( cout, client );
      cout << "\nEnter charge (+) or payment (-): ";

      double transaction;   // charge or payment
      cin >> transaction;   // should validate
      client.balance += transaction;
      outputLine( cout, client );
      updateFile.seekp( ( account-1 ) * sizeof( clientData ) );
      updateFile.write( 
         reinterpret_cast<const char *>( &client ), 
         sizeof( clientData ) );
   }
   else
      cerr << "Account #" << account 
           << " has no information." << endl; 
}

// Create and insert new record
void newRecord( fstream &insertInFile )
{
   int account = getAccount( "Enter new account number" );

   insertInFile.seekg( ( account-1 ) * sizeof( clientData ) );

   clientData client;
   insertInFile.read( reinterpret_cast<char *>( &client ), 
                      sizeof( clientData ) );

   if ( client.accountNumber == 0 ) {
      cout << "Enter lastname, firstname, balance\n? ";
      cin >> client.lastName >> client.firstName 
          >> client.balance;
      client.accountNumber = account;
      insertInFile.seekp( ( account - 1 ) * 
                          sizeof( clientData ) );
      insertInFile.write( 
         reinterpret_cast<const char *>( &client ), 
         sizeof( clientData ) );
   }
   else
      cerr << "Account #" << account
           << " already contains information." << endl;
}

// Delete an existing record
void deleteRecord( fstream &deleteFromFile )
{
   int account = getAccount( "Enter account to delete" );

   deleteFromFile.seekg( (account-1) * sizeof( clientData ) );

   clientData client;
   deleteFromFile.read( reinterpret_cast<char *>( &client ), 
                        sizeof( clientData ) );

   if ( client.accountNumber != 0 ) {
      clientData blankClient = { 0, "", "", 0.0 };

      deleteFromFile.seekp( ( account - 1) * 
                            sizeof( clientData ) );
      deleteFromFile.write( 
         reinterpret_cast<const char *>( &blankClient ), 
         sizeof( clientData ) );
      cout << "Account #" << account << " deleted." << endl;
   }
   else
      cerr << "Account #" << account << " is empty." << endl;
}

// Output a line of client information
void outputLine( ostream &output, const clientData &c )
{
   output << setiosflags( ios::left ) << setw( 10 ) 
          << c.accountNumber << setw( 16 ) << c.lastName 
          << setw( 11 ) << c.firstName << setw( 10 ) 
          << setprecision( 2 ) << resetiosflags( ios::left )
          << setiosflags( ios::fixed | ios::showpoint )          
          << c.balance << '\n';
}

// Get an account number from the keyboard
int getAccount( const char * const prompt )
{
   int account;

   do {
      cout << prompt << " (1 - 100): ";
      cin >> account;
   } while ( account < 1 || account > 100 );

   return account;
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
