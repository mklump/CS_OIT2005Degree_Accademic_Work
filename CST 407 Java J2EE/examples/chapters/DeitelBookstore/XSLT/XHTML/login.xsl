<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      indent = "yes" doctype-system = "DTD/xhtml1-strict.dtd"
      doctype-public = "-//W3C//DTD XHTML 1.0 Strict//EN"/>

   <xsl:include href = "/XSLT/XHTML/error.xsl"/>

   <xsl:template match = "login">
      <html xmlns = "http://www.w3.org/1999/xhtml" 
            xml:lang = "en" lang = "en">		

         <head>
            <title>
               Welcome, <xsl:value-of select = "firstName"/>
            </title> 
            <link rel = "StyleSheet" href = "styles/default.css"/>
         </head>

         <body>
            <xsl:for-each select = "document( '/XSLT/XHTML/navigation.xml' )">
               <xsl:copy-of select = "."/>
            </xsl:for-each>

            <div class = "header">
               Welcome to the Deitel Bookstore, 
               <xsl:value-of select = "firstName" />
            </div>

            <p>
               <a href = "GetAllProducts">
                  Click here to browse our products.
               </a>
            </p>

            <p>
               <a href = "ViewOrderHistory">
                  Click here to view your order history.
               </a>
            </p>
         </body>

      </html>
   </xsl:template>

<!-- 
  (C) Copyright 2001 by Deitel & Associates, Inc. and         
  Prentice Hall. All Rights Reserved.                         
                                                              
  DISCLAIMER: The authors and publisher of this book have     
  used their best efforts in preparing the book. These        
  efforts include the development, research, and testing of   
  the theories and programs to determine their effectiveness. 
  The authors and publisher make no warranty of any kind,     
  expressed or implied, with regard to these programs or to   
  the documentation contained in these books. The authors     
  and publisher shall not be liable in any event for          
  incidental or consequential damages in connection with, or  
  arising out of, the furnishing, performance, or use of      
  these programs.                                             
 -->

</xsl:stylesheet>
