<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      indent = "yes" doctype-system = "DTD/xhtml1-strict.dtd"
      doctype-public = "-//W3C//DTD XHTML 1.0 Strict//EN"/>

   <!-- include template for processing error elements -->
   <xsl:include href = "/XSLT/XHTML/error.xsl"/>

   <!-- template for catalog element -->
   <xsl:template match = "catalog">
      <html xmlns = "http://www.w3.org/1999/xhtml" 
            xml:lang = "en" lang = "en">

         <head>
            <title>Deitel Bookstore</title>
            <link rel = "StyleSheet" href = "styles/default.css"/>
         </head>

         <body>

            <!-- copy navigation header into XHTML document -->
            <xsl:for-each select = "document( '/XSLT/XHTML/navigation.xml' )">
               <xsl:copy-of select = "."/>
            </xsl:for-each>

            <div class = "header">Products</div>

            <!-- table of Product information -->
            <table class = "catalog">
               <tr>
                  <th>Title</th>
                  <th>Author</th>
                  <th>Price</th>
               </tr>

               <!-- match product elements to product template -->
               <xsl:apply-templates select = "/catalog/product">

                  <!-- sort products by title -->
                  <xsl:sort select = "title"/>

               </xsl:apply-templates>

            </table>

         </body>
      </html>
   </xsl:template>

   <!-- template for building row of Product information -->
   <xsl:template match = "product">
      <tr>
         <td>
            <!-- GetProductServlet link for Product details -->
            <a href = "GetProduct?ISBN={ISBN}">
               <xsl:value-of select = "title"/>
            </a>
         </td>
         <td>
            <xsl:value-of select = "author"/>
         </td>
         <td class = "price">
            <xsl:value-of select = "price"/>
         </td>
      </tr>

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
