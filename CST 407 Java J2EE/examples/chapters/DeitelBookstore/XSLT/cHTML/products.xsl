<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "html" 
      omit-xml-declaration = "yes" 
      indent = "yes" 
      doctype-system = 
         "http://www.w3.org/MarkUp/html-spec/html-spec_toc.html"
      doctype-public = "-//W3C//DTD HTML 2.0//EN"/>

  <xsl:include href = "/XSLT/cHTML/error.xsl"/>

   <!-- template for catalog element -->
   <xsl:template match = "catalog">
      <html>

         <head>
            <title>Deitel Bookstore</title>
         </head>

         <body>
            <div class = "header">Products</div>
           
            <p>
               <b>Title</b>
               <br/>Author
               <br/>Price
            </p>

            <!-- match product elements to product template -->
            <xsl:apply-templates select = "/catalog/product">

               <!-- sort products by title -->
               <xsl:sort select = "title"/>

            </xsl:apply-templates>
         </body>

      </html>
   </xsl:template>

   <!-- template for building row of Product information -->
   <xsl:template match = "product">
      <p>
         <!-- GetProductServlet link for Product details -->
         <a href = "GetProduct?ISBN={ISBN}">
            <xsl:value-of select = "title"/>
         </a>
         <br/>
         <xsl:value-of select = "author"/>
         <br/>
         <xsl:value-of select = "price"/>
      </p>
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
