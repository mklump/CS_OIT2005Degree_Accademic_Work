// Fig C.9 : MyErrorHandler.java
// Error Handler for validation errors.

import org.xml.sax.ErrorHandler;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;

public class MyErrorHandler implements ErrorHandler 
{

   // throw SAXException for fatal errors
   public void fatalError( SAXParseException exception )
      throws SAXException 
   {
      throw exception;
   }

   public void error( SAXParseException errorException )
      throws SAXParseException
   {
      throw errorException;
   }

   // print any warnings 
   public void warning( SAXParseException warningError )
      throws SAXParseException
   {
      System.err.println( "Warning: " + warningError.getMessage() );
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
