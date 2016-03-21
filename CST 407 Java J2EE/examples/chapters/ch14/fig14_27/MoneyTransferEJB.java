// MoneyTransferEJB.java
// MoneyTransferEJB is a stateless session EJB for transferring
// funds from an Account at BankABC to an Account at BankXYZ
// using bean-managed transaction demarcation.
package com.deitel.advjhtp1.ejb.transactions.beanmanaged;

// Java core libraries
import java.util.*;
import java.sql.*;

// Java standard extensions
import javax.ejb.*;
import javax.naming.*;
import javax.transaction.*;
import javax.sql.*;

public class MoneyTransferEJB implements SessionBean {
   
   private SessionContext sessionContext;
   private Connection bankOneConnection;
   private Connection bankTwoConnection;
   private PreparedStatement withdrawalStatement;
   private PreparedStatement depositStatement;
   
   // transfer funds from BankABC to BankXYZ
   public void transfer( double amount ) throws EJBException
   {
      // create transaction for transferring funds
      UserTransaction transaction = 
         sessionContext.getUserTransaction();
      
      // begin bean-managed transaction demarcation
      try {
         transaction.begin();
      }
      
      // catch exception if method begin fails
      catch ( Exception exception ) {
          
         // throw EJBException indicating transaction failed
         throw new EJBException( exception );
      }
      
      // transfer funds from account in BankABC to account
      // in BankXYZ using bean-managed transaction demarcation
      try {

         withdrawalStatement.setDouble( 1, amount );

         // withdraw funds from account at BankABC
         withdrawalStatement.executeUpdate();
         
         depositStatement.setDouble( 1, amount );
         
         // deposit funds in account at BankXYZ
         depositStatement.executeUpdate();
         
         // commit transaction
         transaction.commit();
         
      } // end try
      
      // handle exceptions when withdrawing, depositing and
      // committing transaction
      catch ( Exception exception ) {
         
         // attempt rollback of transaction
         try {
            transaction.rollback();
         }
         
         // handle exception when rolling back transaction
         catch ( SystemException systemException ) {
            throw new EJBException( systemException );
         }
         
         // throw EJBException indicating transaction failed
         throw new EJBException( exception );
      }
      
   } // end method transfer

   // get balance of Account at BankABC
   public double getBankABCBalance() throws EJBException
   {
      // get balance of Account at BankABC
      try {
         
         // select balance for Account # 12345
         String select = "SELECT balance FROM Account " +
            "WHERE accountID = 12345";
         
         PreparedStatement selectStatement = 
            bankOneConnection.prepareStatement( select );
         
         ResultSet resultSet = selectStatement.executeQuery();
         
         // get first record in ResultSet and return balance
         if ( resultSet.next() )
            return resultSet.getDouble( "balance" );
         else
            throw new EJBException( "Account not found" );
         
      } // end try
      
      // handle exception when getting Account balance
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }
      
   } // end method getBankABCBalance
   
   // get balance of Account at BankXYZ
   public double getBankXYZBalance() throws EJBException
   {
      // get balance of Account at BankXYZ
      try {
         
         // select balance for Account # 54321
         String select = "SELECT balance FROM Account " +
            "WHERE accountID = 54321";
         
         PreparedStatement selectStatement = 
            bankTwoConnection.prepareStatement( select );
         
         ResultSet resultSet = selectStatement.executeQuery();
         
         // get first record in ResultSet and return balance
         if ( resultSet.next() )
            return resultSet.getDouble( "balance" );
         else
            throw new EJBException( "Account not found" );
         
      } // end try
      
      // handle exception when getting Account balance
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }    
      
   } // end method getBankXYZBalance   
   
   // set SessionContext
   public void setSessionContext( SessionContext context )
      throws EJBException
   {
      sessionContext = context;   
      
      openDatabaseResources();
   }
   
   // create MoneyTransfer instance
   public void ejbCreate() {}
   
   // remove MoneyTransfer instance
   public void ejbRemove() throws EJBException
   {
      closeDatabaseResources();
   }

   // passivate MoneyTransfer instance
   public void ejbPassivate() throws EJBException
   {
      closeDatabaseResources();
   }
   
   // activate MoneyTransfer instance
   public void ejbActivate() throws EJBException
   {
      openDatabaseResources();
   }
   
   // close database Connections and PreparedStatements
   private void closeDatabaseResources() throws EJBException
   {
      // close database resources
      try {
         
         // close PreparedStatements
         depositStatement.close();
         depositStatement = null;
         
         withdrawalStatement.close();
         withdrawalStatement = null;
         
         // close database Connections
         bankOneConnection.close();
         bankOneConnection = null;

         bankTwoConnection.close();
         bankTwoConnection = null;
      }
      
      // handle exception closing database connections
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }
      
   } // end method closeDatabaseConnections
   
   // open database Connections and create PreparedStatements
   private void openDatabaseResources() throws EJBException
   {   
      // look up the BankABC and BankXYZ DataSources and create 
      // Connections for each
      try {  
         Context initialContext = new InitialContext();

         // get DataSource reference from JNDI directory
         DataSource dataSource = ( DataSource )
            initialContext.lookup( 
               "java:comp/env/jdbc/BankABC" );

         // get Connection from DataSource
         bankOneConnection = dataSource.getConnection();
         
         dataSource = ( DataSource) initialContext.lookup(
            "java:comp/env/jdbc/BankXYZ" );
         
         bankTwoConnection = dataSource.getConnection();
         
         // prepare withdraw statement for account #12345 at 
         // BankABC
         String withdrawal = "UPDATE Account SET balance = " +
            "balance - ? WHERE accountID = 12345";

         withdrawalStatement = 
            bankOneConnection.prepareStatement( withdrawal );
      
         // prepare deposit statment for account #54321 at 
         // BankXYZ
         String deposit = "UPDATE Account SET balance = " +
            "balance + ? WHERE accountID = 54321";    

         depositStatement =
            bankTwoConnection.prepareStatement( deposit ); 
         
      } // end try
      
      // handle exception if DataSource not found in directory
      catch ( NamingException namingException ) {
         throw new EJBException( namingException );
      }
      
      // handle exception getting Connection to DataSource
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }   
      
   } // end method openDatabaseConnections
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