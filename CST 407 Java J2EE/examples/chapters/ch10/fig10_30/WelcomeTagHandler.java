// Fig. 10.31: WelcomeTagHandler.java
// Custom tag handler that handles a simple tag.
package com.deitel.advjhtp1.jsp.taglibrary;

// Java core packages
import java.io.*;

// Java extension packages
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class WelcomeTagHandler extends TagSupport {
 
   // Method called to begin tag processing
   public int doStartTag() throws JspException
   {
      // attempt tag processing
      try {
         // obtain JspWriter to output content
         JspWriter out = pageContext.getOut();

         // output content
         out.print( "Welcome to JSP Tag Libraries!" );
      }
      
      // rethrow IOException to JSP container as JspException
      catch( IOException ioException ) {
         throw new JspException( ioException.getMessage() );
      }
      
      return SKIP_BODY;  // ignore the tag's body
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