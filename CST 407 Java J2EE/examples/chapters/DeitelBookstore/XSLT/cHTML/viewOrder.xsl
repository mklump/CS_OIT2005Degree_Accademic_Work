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

   <xsl:template match = "order">
      <html>

         <head>
            <title>Order Details</title>
         </head>

         <body>
            <div class = "header">
               OrderID: <xsl:value-of select = "orderID"/>
               Order Date: <xsl:value-of select = "orderDate"/>
            </div>
         
            <xsl:apply-templates select = "orderProducts"/>
            <hr/>
            <p>Total: <xsl:value-of select = "totalCost"/></p>
         </body>

      </html>
   </xsl:template>

   <xsl:template match = "orderProducts">
      <table>
         <tr>
            <p>Title</p>
            <p>Author</p>
            <p>ISBN</p>
            <p>Quantity</p>
            <p>Price</p>
         </tr>

         <xsl:apply-templates select = "orderProduct"/>
      </table>
   </xsl:template>

   <xsl:template match = "orderProduct">
      <hr/>
      <tr>
         <p>
            <a href = "GetProduct?ISBN={product/ISBN}">
               <xsl:value-of select = "product/title"/>
            </a>
         </p>
         <p>
            <xsl:value-of select = "product/author"/>
         </p>
         <p><xsl:value-of select = "product/ISBN"/></p>
         <p><xsl:value-of select = "quantity"/></p>
         <p>
            <xsl:value-of select = "product/price"/>
         </p>         
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
