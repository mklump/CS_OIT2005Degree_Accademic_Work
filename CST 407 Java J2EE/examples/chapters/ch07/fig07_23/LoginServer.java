// LoginServer.java
// LoginServer uses an SSLServerSocket to demonstrate JSSE's
// SSL implementation.
package com.deitel.advjhtp1.security.jsse;

// Java core packages
import java.io.*;

// Java extension packages
import javax.net.ssl.*;

public class LoginServer {
   
   private static final String CORRECT_USER_NAME = "Java";
   private static final String CORRECT_PASSWORD = "HowToProgram";
   
   private SSLServerSocket serverSocket;
   
   // LoginServer constructor
   public LoginServer() throws Exception
   {       
      // SSLServerSocketFactory for building SSLServerSockets
      SSLServerSocketFactory socketFactory = 
         ( SSLServerSocketFactory ) 
            SSLServerSocketFactory.getDefault(); 
      
      // create SSLServerSocket on specified port
      serverSocket = ( SSLServerSocket ) 
         socketFactory.createServerSocket( 7070 );   
      
   } // end LoginServer constructor
   
   // start server and listen for clients
   private void runServer()
   {
      // perpetually listen for clients
      while ( true ) {
         
         // wait for client connection and check login information
         try {
         
            System.err.println( "Waiting for connection..." );
            
            // create new SSLSocket for client
            SSLSocket socket = 
               ( SSLSocket ) serverSocket.accept();

            // open BufferedReader for reading data from client
            BufferedReader input = new BufferedReader( 
               new InputStreamReader( socket.getInputStream() ) );
            
            // open PrintWriter for writing data to client
            PrintWriter output = new PrintWriter( 
               new OutputStreamWriter( 
                  socket.getOutputStream() ) );
           
            String userName = input.readLine();
            String password = input.readLine();

            if ( userName.equals( CORRECT_USER_NAME ) && 
                 password.equals( CORRECT_PASSWORD ) ) {

               output.println( "Welcome, " + userName );
            }

            else {
               output.println( "Login Failed." );
            }
            
            // clean up streams and SSLSocket
            output.close();
            input.close();
            socket.close();
            
         } // end try
         
         // handle exception communicating with client
         catch ( IOException ioException ) {
            ioException.printStackTrace();
         }
         
      } // end while      
   
   } // end method runServer
   
   // execute application
   public static void main( String args[] ) throws Exception
   {
      LoginServer server = new LoginServer();
      server.runServer();
   }
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