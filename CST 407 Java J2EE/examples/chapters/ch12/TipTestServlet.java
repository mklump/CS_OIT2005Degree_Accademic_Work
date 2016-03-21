// TipTestServlet.java
// TipTestServlet sends Tip Test to clients.
package com.deitel.advjhtp1.wireless;

// Java core packages
import java.io.*;
import java.sql.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.xml.parsers.*;
import javax.xml.transform.*;
import javax.xml.transform.dom.*;
import javax.xml.transform.stream.*;

// import third-party packages
import org.w3c.dom.*;
import org.xml.sax.SAXException;

public class TipTestServlet extends HttpServlet {

   private Connection connection; // database connection

   private DocumentBuilderFactory factory;
   private TransformerFactory transformerFactory;

   // initialize servlet
   public void init() throws ServletException
   {
      // load database driver and instantiate XML factories
      try {

         // get JDBC driver from servlet container
         String jdbcDriver = 
            getServletConfig().getInitParameter( 
               "JDBC_DRIVER" );

         Class.forName( jdbcDriver ); // load JDBC driver

         // get database URL from servlet container
         String databaseUrl = 
            getServletConfig().getInitParameter( 
               "DATABASE_URL" );

         connection = DriverManager.getConnection( databaseUrl );

         // create a Factory to build XML Documents
         factory = DocumentBuilderFactory.newInstance();

         // create new TransformerFactory
         transformerFactory = TransformerFactory.newInstance();

      } // end try

      // handle exception database driver class does not exist
      catch ( ClassNotFoundException classNotFoundException ) {
         classNotFoundException.printStackTrace();
      }

      // handle exception in making Connection
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }

   } // end method init

   // respond to get requests
   protected void doGet( HttpServletRequest request,
      HttpServletResponse response )
      throws ServletException, IOException
   {
      // get Statement from database, then send Tip-Test Question
      try {

         // SQL query to database
         Statement statement = connection.createStatement();

         // get database information using SQL query
         ResultSet resultSet = 
            statement.executeQuery( "SELECT * FROM tipInfo" );

         // parse and send ResultSet to client
         if ( resultSet != null ) {

            // ensure that client does not cache questions
            response.setHeader( "Cache-Control", 
               "no-cache, must-revalidate" );
            response.setHeader( "Pragma", "no-cache" );

            sendTipTestQuestion( request, response, resultSet );
         }

         statement.close(); // close Statement
      }

      // handle exception in exectuting Statement
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }

   } // end method doGet

   // respond to post requests
   protected void doPost( HttpServletRequest request,
      HttpServletResponse response )
      throws ServletException, IOException
   {
      // send ResultSet to appropriate client
      try {

         // determine User-Agent header
         String userAgent = request.getHeader( "User-Agent" );

         // if Internet Explorer is requesting client
         if ( userAgent.indexOf(
            ClientUserAgentHeaders.IE ) != -1 ) {

            Document document = 
               createXMLTipTestAnswer( request );

            // set appropriate Content-Type for client
            response.setContentType( "text/html" );

            // send XML content to client after XSLT
            applyXSLT( "XHTML/XHTMLTipAnswer.xsl", document, 
               response );
         }

         // if WAP client is requesting client
         else if ( userAgent.indexOf(
            ClientUserAgentHeaders.WAP ) != -1 ) {

            Document document = 
               createXMLTipTestAnswer( request );

            // set appropriate Content-Type for client
            response.setContentType( "text/vnd.wap.wml" );

            // send XML content to client after XSLT
            applyXSLT( "WAP/WAPTipAnswer.xsl", document, 
               response );
         }

         // if i-mode client is requesting client
         else if ( userAgent.indexOf(
            ClientUserAgentHeaders.IMODE ) != -1 ) {

            Document document = 
               createXMLTipTestAnswer( request );

            // set appropriate Content-Type for client
            response.setContentType( "text/html" );

            // send XML content to client after XSLT
            applyXSLT( "iMode/IMODETipAnswer.xsl", document, 
               response );
         }

         // if J2ME client is requesting client
         else if ( userAgent.indexOf(
            ClientUserAgentHeaders.J2ME ) != -1 )
            sendJ2MEAnswer( request, response );

      } // end try

      // handle exception if Document is null
      catch ( NullPointerException nullPointerException ) {
         nullPointerException.printStackTrace();
      }

   } // end method doPost

   // send Tip-Test data to client
   private void sendTipTestQuestion( 
      HttpServletRequest request, HttpServletResponse response, 
      ResultSet resultSet ) throws IOException
   {
      // send ResultSet to appropriate client
      try {

         // determine User-Agent header
         String userAgent = request.getHeader( "User-Agent" );

         // if Internet Explorer is requesting client
         if ( userAgent.indexOf(
            ClientUserAgentHeaders.IE ) != -1 ) {

            Document document = 
               createXMLTipTestQuestion( resultSet, request, 
                  request.getContextPath() + "/XHTML/images/", 
                     ".gif" );

            // set appropriate Content-Type for client
            response.setContentType( "text/html" );
            applyXSLT( "XHTML/XHTMLTipQuestion.xsl", document, 
               response );
         }

         // if WAP client is requesting client
         else if ( userAgent.indexOf(
            ClientUserAgentHeaders.WAP ) != -1 ) {

            Document document = 
               createXMLTipTestQuestion( resultSet, request,
                  request.getContextPath() + "/WAP/images/", 
                     ".wbmp" );

            // set appropriate Content-Type for client
            response.setContentType( "text/vnd.wap.wml" );
            applyXSLT( "WAP/WAPTipQuestion.xsl", document, 
               response );
         }

         // if i-mode client is requesting client
         else if ( userAgent.indexOf(
            ClientUserAgentHeaders.IMODE ) != -1 ) {

            Document document = 
               createXMLTipTestQuestion( resultSet, request,
                  request.getContextPath() + "/iMode/images/", 
                     ".gif" );

            // set appropriate Content-Type for client
            response.setContentType( "text/html" );
            applyXSLT( "iMode/IMODETipQuestion.xsl", document, 
               response );
         }

         // if J2ME client is requesting client
         else if ( userAgent.indexOf(
            ClientUserAgentHeaders.J2ME ) != -1 )
            sendJ2MEClientResponse( resultSet, request, 
               response );

      } // end try

      // handle exception if Document is null
      catch ( NullPointerException nullPointerException ) {
         nullPointerException.printStackTrace();
      }

   } // end method sendTipTestQuestion

   // send tip test to Internet Explorer client
   private Document createXMLTipTestQuestion( 
      ResultSet resultSet, HttpServletRequest request,
      String imagePrefix, String imageSuffix )
      throws IOException
   {
      // convert ResultSet to two-dimensional String array
      String resultTable[][] = getResultTable( resultSet );

      // create random-number generator
      Random random = new Random( System.currentTimeMillis() );

      // create 4 random tips
      int randomRow[] = getRandomIndices( random );

      // randomly determine correct index from 4 random indices
      int correctAnswer = Math.abs( random.nextInt() ) % 
         randomRow.length;

      int correctRow = randomRow[ correctAnswer ];

      // open new session
      HttpSession session = request.getSession();

      // store correct answer in session
      session.setAttribute( "correctAnswer", 
         new Integer( correctAnswer ) );

      // store correct tip name
      session.setAttribute( "correctTipName", new String( 
         resultTable[ correctRow ][ 1 ] ) );

      // store correct tip description
      session.setAttribute( "correctTipDescription", new String( 
         resultTable[ correctRow ][ 2 ] ) );

      // determine image to send client
      String imageName = imagePrefix  + 
         resultTable[ correctRow ][ 3 ] + imageSuffix;

      // create XML document based on randomly determined info
      try {

         // create document
         DocumentBuilder builder = factory.newDocumentBuilder();
         Document document = builder.newDocument();

         // create question root Element
         Element root = document.createElement( "question" );
         document.appendChild( root );

         // append Element image, which references image name
         Element image = document.createElement( "image" );
         image.appendChild( 
            document.createTextNode( imageName ) );
         root.appendChild( image );

         // create choices Element to hold 4 choice Elements
         Element choices = document.createElement( "choices" );

         // append 4 choice Elements that represent user choices
         for ( int i = 0; i < randomRow.length; i++ )
         {
            // determine choice Elements from resultTable
            Element choice = document.createElement( "choice" );
            choice.appendChild( document.createTextNode( 
               resultTable[ randomRow[ i ] ][ 4 ] ) );

            // set choice Element as correct or incorrect
            Attr attribute = 
               document.createAttribute( "correct" );

            if ( i == correctAnswer )
               attribute.setValue( "true" );
            else
               attribute.setValue( "false" );

            // append choice Element to choices Element
            choice.setAttributeNode( attribute );
            choices.appendChild( choice );
         }

         root.appendChild( choices );

         return document;

      } // end try

      // handle exception building Document
      catch ( ParserConfigurationException parserException ) {
         parserException.printStackTrace();
      }

      return null;

   } // end method createXMLTipTestQuestion

   // send tip test to J2ME client
   private void sendJ2MEClientResponse( ResultSet resultSet,
      HttpServletRequest request,
      HttpServletResponse response ) throws IOException
   {
      // convert ResultSet to two-dimensional String array
      String resultTable[][] = getResultTable( resultSet );

      // create random-number generator
      Random random = new Random( System.currentTimeMillis() );

      // create 4 random tips
      int randomRow[] = getRandomIndices( random );

      // randomly determine correct index from 4 random indices
      int correctAnswer = Math.abs( random.nextInt() ) % 
         randomRow.length;

      int correctRow = randomRow[ correctAnswer ];

      // open old session
      HttpSession session = request.getSession();

      // store correct answer in session
      session.setAttribute( "correctAnswer", 
         new Integer( correctAnswer ) );

      // store correct tip name in session
      session.setAttribute( "correctTipName", new String( 
         resultTable[ correctRow ][ 1 ] ) );

      // store correct tip description in session
      session.setAttribute( "correctTipDescription", new String( 
         resultTable[ correctRow ][ 2 ] ) );

      // send J2ME client image name
      String imageName = "/j2me/images/"  + 
         resultTable[ correctRow ][ 3 ] + ".png";

      response.setContentType( "text/plain" );
      PrintWriter out = response.getWriter();
      out.println( imageName );

      // send J2ME client test
      for ( int i = 0; i < randomRow.length; i++ )
         out.println( resultTable[ randomRow[ i ] ][ 4 ] );

   } // end method sendJ2MEClientResponse

   // convert ResultSet to two-dimensional String array
   private String[][] getResultTable( ResultSet resultSet )
   {
      // create table of Strings to store ResultSet
      String resultTable[][] = new String[ 7 ][ 5 ];

      for ( int i = 0; i < 7; i++ ) {

         for ( int j = 0; j < 5; j++ )
            resultTable[ i ][ j ] = "";
      }

      // store all columns in table
      try {

         // for each row in resultSet
         for ( int row = 0; resultSet.next(); row++ ) {

            // for each column in resultSet
            for ( int column = 0; column < 5; column++ ) {

               // store resultSet element in resultTable
               resultTable[ row ][ column ] += 
                  resultSet.getObject( column + 1 );
            }
         }
      }

      // handle exception if servlet cannot get ResultSet Object
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
         return null;
      }

      return resultTable;

   } // end method getResultTable

   // get 4 randomly generated indices from resultTable
   private int[] getRandomIndices( Random random )
   {
      // create list containing row indices for resultTable
      int list[] = new int[ 7 ];

      for ( int i = 0; i < list.length; i++ )
         list[ i ] = i;

      int randomRow[] = new int[ 4 ];

      // select 4 randomly generated indices from list
      for ( int i = 0; i < randomRow.length; i++ )
         randomRow[ i ] = getRandomRow( list, random );

      return randomRow; // return these indices

   } // end method getRandomIndices

   // get random element from list, then nullify element
   private int getRandomRow( int list[], Random random )
   {
      // get random element from list
      int randomRow = Math.abs( random.nextInt() ) % list.length;

      while ( list[ randomRow ] < 0 )
         randomRow = Math.abs( random.nextInt() ) % list.length;

      list[ randomRow ] = -1; // nullify element

      return randomRow;

   } // end method getRandomRow

   // apply XSLT style sheet to XML document
   private void applyXSLT( String xslFile,
      Document xmlDocument, HttpServletResponse response )
      throws IOException
   {
      // apply XSLT
      try {

         // open InputStream for XSL document 
         InputStream xslStream = 
            getServletContext().getResourceAsStream( xslFile );

         // create StreamSource for XSLT document
         Source xslSource = new StreamSource( xslStream );

         // create DOMSource for source XML document
         Source xmlSource = new DOMSource( xmlDocument );

         // get PrintWriter for writing data to client
         PrintWriter output = response.getWriter();

         // create StreamResult for transformation result
         Result result = new StreamResult( output );

         // create Transformer for XSL transformation
         Transformer transformer =
            transformerFactory.newTransformer( xslSource );

         // transform and deliver content to client
         transformer.transform( xmlSource, result );

      } // end try

      // handle exception transforming content
      catch ( TransformerException exception ) {
         exception.printStackTrace();
      }

   } // end method applyXSLT

   // create XML Document that stores Tip Test answer
   private Document createXMLTipTestAnswer( 
      HttpServletRequest request ) throws IOException
   {
      // get session
      HttpSession session = request.getSession();

      // match correct answer with session answer
      Integer integer = 
         ( Integer ) session.getAttribute( "correctAnswer" );
      int correctAnswer = integer.intValue();

      // give client correct tip name and description
      String correctTipName = 
         ( String ) session.getAttribute( "correctTipName" );

      String correctTipDescription = 
         ( String ) session.getAttribute( 
            "correctTipDescription" );

      // get user selection
      int selection = Integer.parseInt( 
         request.getParameter( "userAnswer" ) );

      String answer;

      // determine if user answer is correct
      if ( correctAnswer == selection )
         answer = "Correct";
      else
         answer = "Incorrect";

      // get link to TipTestServlet
      String servletName = request.getContextPath() + "/" +
         getServletConfig().getServletName();

      // create XML document based on randomly determined info
      try {

         // create document
         DocumentBuilder builder = factory.newDocumentBuilder();
         Document document = builder.newDocument();

         // create question root Element
         Element root = document.createElement( "answer" );
         document.appendChild( root );

         // append Element that informs client of correct answer
         Element correct = document.createElement( "correct" );
         correct.appendChild( 
            document.createTextNode( answer ) );
         root.appendChild( correct );

         // append Element that describes tip name
         Element name = 
            document.createElement( "correctTipName" );
         name.appendChild( 
            document.createTextNode( correctTipName ) );
         root.appendChild( name );

         // append Element that describes tip description
         Element description = 
            document.createElement( "correctTipDescription" );
         description.appendChild( 
            document.createTextNode( correctTipDescription ) );
         root.appendChild( description );

         // append Element that links to TipTestServlet
         Element servletLink = 
            document.createElement( "servletName" );
         servletLink.appendChild( 
            document.createTextNode( servletName ) );
         root.appendChild( servletLink );

         return document;

      } // end try

      // handle exception building Document
      catch ( ParserConfigurationException parserException ) {
         parserException.printStackTrace();
      }

      return null;

   } // end method createXMLTipTestAnswer

   // send answer to J2ME client
   private void sendJ2MEAnswer( HttpServletRequest request,
      HttpServletResponse response ) throws IOException
   {
      // get client test response
      BufferedReader in = request.getReader();
      int selection = Integer.parseInt( in.readLine().trim() );

      // send J2ME client text data
      response.setContentType( "text/plain" );
      PrintWriter out = response.getWriter();

      // inform client whether client is correct or incorrect
      HttpSession session = request.getSession();

      // match correct answer with session answer
      Integer integer = 
         ( Integer ) session.getAttribute( "correctAnswer" );
      int correctAnswer = integer.intValue();

      // send correct tip name and description
      String correctTipName = 
         ( String ) session.getAttribute( "correctTipName" );

      String correctTipDescription = 
         ( String ) session.getAttribute( 
            "correctTipDescription" );

      // determine whether answer is correct
      if ( selection == correctAnswer )
         out.println( "Correct" );
      else
         out.println( "Incorrect" );

      // give client correct tip name and description
      out.println( correctTipName );
      out.println( correctTipDescription );

   } // end method sendJ2MEAnswer

   // invoked when servlet is destroyed
   public void destroy()
   {
      // close database connection
      try {
         connection.close();
      }

      // handle if connection cannot be closed
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }

   } // end method destroy
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
