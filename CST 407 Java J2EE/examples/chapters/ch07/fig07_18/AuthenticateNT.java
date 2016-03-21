// AuthenticateNT.java
// Authenticates a user using the NTLoginModule and performs
// a WriteFileAction PrivilegedAction.
package com.deitel.advjhtp1.security.jaas;

// Java extension packages
import javax.swing.*;
import javax.security.auth.*;
import javax.security.auth.login.*;

public class AuthenticateNT {   
   
   // launch application
   public static void main( String[] args )
   {
      // authenticate user and perform PrivilegedAction
      try {
         
         // create LoginContext for AuthenticateNT context
         LoginContext loginContext = 
            new LoginContext( "AuthenticateNT" );
         
         // perform login
         loginContext.login();
         
         // if login executes without exceptions, login
         // was successful
         System.out.println( "Login Successful" );
         
         // get Subject now associated with LoginContext
         Subject subject = loginContext.getSubject();
         
         // display Subject details
         System.out.println( subject );
         
         // perform the WriteFileAction as current Subject
         Subject.doAs( subject, new WriteFileAction() );
         
         // log out current Subject
         loginContext.logout();         
         
         System.exit( 0 );

      } // end try
      
      // handle exception loggin in
      catch ( LoginException loginException ) {
         loginException.printStackTrace();
         System.exit( -1 );
      }
      
   } // end method main
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