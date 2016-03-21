// WelcomeServlet.java
// Delivers appropriate "Welcome" screen to client
package com.deitel.advjhtp1.wireless;

// Java core package
import java.io.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;

public class WelcomeServlet extends HttpServlet {

   // respond to get request
   protected void doGet( HttpServletRequest request,
      HttpServletResponse response )
      throws ServletException, IOException
   {
      // determine User-Agent header
      String userAgent = request.getHeader( "User-Agent" );

      // send welcome screen to appropriate client
      if ( userAgent.indexOf ( 
         ClientUserAgentHeaders.IE ) != -1 )
         sendIEClientResponse( request, response );

      else if ( userAgent.indexOf( // WAP
            ClientUserAgentHeaders.WAP ) != -1 )
            sendWAPClientResponse( request, response );

      else if ( userAgent.indexOf( // i-mode
            ClientUserAgentHeaders.IMODE ) != -1 )
            sendIModeClientResponse( request, response );

      else if ( userAgent.indexOf( // J2ME
            ClientUserAgentHeaders.J2ME ) != -1 )
            sendJ2MEClientResponse( request, response );

   } // end method doGet

   // send welcome screen to IE client
   private void sendIEClientResponse( 
      HttpServletRequest request, HttpServletResponse response ) 
      throws IOException, ServletException
   {
      redirect( "text/html", "/XHTML/index.html", request, 
         response );
   }

   // send welcome screen to Nokia WAP client
   private void sendWAPClientResponse( 
      HttpServletRequest request, HttpServletResponse response ) 
      throws IOException, ServletException
   {
      redirect( "text/vnd.wap.wml", "/WAP/index.wml", request, 
         response );
   }

   // send welcome screen to i-mode client
   private void sendIModeClientResponse( 
      HttpServletRequest request, HttpServletResponse response )
      throws IOException, ServletException
   {
      redirect( "text/html", "/iMode/index.html", request, 
         response );
   }

   // send welcome screen to J2ME client
   private void sendJ2MEClientResponse(
      HttpServletRequest request, HttpServletResponse response ) 
      throws IOException
   {
      // send J2ME client text data
      response.setContentType( "text/plain" );
      PrintWriter out = response.getWriter();

      // open file to send J2ME client
      BufferedReader bufferedReader =
          new BufferedReader( new FileReader( 
            getServletContext().getRealPath( 
               "j2me/index.txt" ) ) );

      String inputString = bufferedReader.readLine();

      // send each line in file to J2ME client
      while ( inputString != null ) {
         out.println( inputString );
         inputString = bufferedReader.readLine();
      }

      out.close(); // done sending data

   } // end method sendJ2MEClientResponse

   // redirects client request to another page
   private void redirect( String contentType, String redirectPage,
      HttpServletRequest request, HttpServletResponse response )
      throws IOException, ServletException
   {
      // set new content type
      response.setContentType( contentType );
      RequestDispatcher dispatcher = 
         getServletContext().getRequestDispatcher( 
            redirectPage );

      // forward user to redirectPage
      dispatcher.forward( request, response );
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

