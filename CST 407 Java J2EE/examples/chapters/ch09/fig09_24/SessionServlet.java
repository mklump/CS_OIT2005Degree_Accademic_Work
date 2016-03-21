// Fig. 9.24: SessionServlet.java
// Using HttpSession to maintain client state information.
package com.deitel.advjhtp1.servlets;

import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;
import java.util.*;

public class SessionServlet extends HttpServlet {
   private final Map books = new HashMap();

   // initialize Map books
   public void init()
   {
      books.put( "C", "0130895725" );
      books.put( "C++", "0130895717" );
      books.put( "Java", "0130125075" );
      books.put( "VB6", "0134569555" );
   }

   // receive language selection and create HttpSession object
   // containing recommended book for the client
   protected void doPost( HttpServletRequest request,
      HttpServletResponse response )
         throws ServletException, IOException
   {
      String language = request.getParameter( "language" );

      // Get the user's session object.
      // Create a session (true) if one does not exist.
      HttpSession session = request.getSession( true );
      
      // add a value for user's choice to session
      session.setAttribute( language, books.get( language ) );

      response.setContentType( "text/html" );
      PrintWriter out = response.getWriter();         

      // send XHTML page to client

      // start XHTML document
      out.println( "<?xml version = \"1.0\"?>" );

      out.println( "<!DOCTYPE html PUBLIC \"-//W3C//DTD " +
         "XHTML 1.0 Strict//EN\" \"http://www.w3.org" +
         "/TR/xhtml1/DTD/xhtml1-strict.dtd\">" ); 

      out.println( 
         "<html xmlns = \"http://www.w3.org/1999/xhtml\">" );

      // head section of document
      out.println( "<head>" );
      out.println( "<title>Welcome to Sessions</title>" );
      out.println( "</head>" );

      // body section of document
      out.println( "<body>" );
      out.println( "<p>Welcome to Sessions! You selected " +
         language + ".</p>" );

      // display information about the session
      out.println( "<p>Your unique session ID is: " + 
         session.getId() + "<br />" );

      out.println( 
         "This " + ( session.isNew() ? "is" : "is not" ) +
         " a new session<br />" );
         
      out.println( "The session was created at: " + 
         new Date( session.getCreationTime() ) + "<br />" );

      out.println( "You last accessed the session at: " + 
         new Date( session.getLastAccessedTime() ) + "<br />" );

      out.println( "The maximum inactive interval is: " + 
         session.getMaxInactiveInterval() + " seconds</p>" );

      out.println( "<p><a href = " +
         "\"servlets/SessionSelectLanguage.html\">" +
         "Click here to choose another language</a></p>" );

      out.println( "<p><a href = \"sessions\">" +
         "Click here to get book recommendations</a></p>" );
      out.println( "</body>" );

      // end XHTML document
      out.println( "</html>" );
      out.close();    // close stream
   }

   // read session attributes and create XHTML document
   // containing recommended books
   protected void doGet( HttpServletRequest request,
      HttpServletResponse response )
         throws ServletException, IOException
   {
      // Get the user's session object.
      // Do not create a session (false) if one does not exist.
      HttpSession session = request.getSession( false );

      // get names of session object's values
      Enumeration valueNames;

      if ( session != null )
         valueNames = session.getAttributeNames();
      else
         valueNames = null;

      PrintWriter out = response.getWriter();
      response.setContentType( "text/html" ); 

      // start XHTML document
      out.println( "<?xml version = \"1.0\"?>" );

      out.println( "<!DOCTYPE html PUBLIC \"-//W3C//DTD " +
         "XHTML 1.0 Strict//EN\" \"http://www.w3.org" +
         "/TR/xhtml1/DTD/xhtml1-strict.dtd\">" ); 

      out.println( 
         "<html xmlns = \"http://www.w3.org/1999/xhtml\">" );

      // head section of document
      out.println( "<head>" );
      out.println( "<title>Recommendations</title>" );
      out.println( "</head>" );

      // body section of document
      out.println( "<body>" );

      if ( valueNames != null && 
           valueNames.hasMoreElements() ) {
         out.println( "<h1>Recommendations</h1>" );
         out.println( "<p>" );

         String name, value; 
         
         // get value for each name in valueNames
         while ( valueNames.hasMoreElements() ) {
            name = valueNames.nextElement().toString();
            value = session.getAttribute( name ).toString();
 
            out.println( name + " How to Program. " +
               "ISBN#: " + value + "<br />" );
         }    

         out.println( "</p>" );
      }
      else {
         out.println( "<h1>No Recommendations</h1>" );
         out.println( "<p>You did not select a language.</p>" );
      }

      out.println( "</body>" );

      // end XHTML document
      out.println( "</html>" );
      out.close();    // close stream
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

