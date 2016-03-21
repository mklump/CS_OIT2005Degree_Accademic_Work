// ClientModel.java
// ClientModel is a utility class for determining the proper 
// Content-Type and path for XSL files for each type of client 
// supported by the Bookstore application.
package com.deitel.advjhtp1.bookstore.model;

// Java core packages
import java.io.*;

public class ClientModel implements Serializable {
   
   // ClientModel properties
   private String userAgent;
   private String contentType;
   private String XSLPath;

   // ClientModel constructor for initializing data members
   public ClientModel( String agent, String type, String path )
   {
      setUserAgent( agent );
      setContentType( type );
      setXSLPath( path );
   }

   // set UserAgent substring 
   public void setUserAgent( String agent )
   {
      userAgent = agent;
   }

   // get UserAgent substring
   public String getUserAgent()
   {
      return userAgent;
   }

   // set ContentType
   public void setContentType( String type )
   {
      contentType = type;
   }

   // get ContentType
   public String getContentType()
   {
      return contentType;
   }

   // set XSL path
   public void setXSLPath( String path )
   {
      XSLPath = path;
   }

   // get XSL path
   public String getXSLPath()
   {
      return XSLPath;
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
