<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      indent = "yes" doctype-system = "DTD/xhtml1-strict.dtd"
      doctype-public = "-//W3C//DTD XHTML 1.0 Strict//EN"/>

   <xsl:include href = "/XSLT/XHTML/error.xsl"/>

   <xsl:template match = "order">
      <html xmlns = "http://www.w3.org/1999/xhtml" 
            xml:lang = "en" lang = "en">
      <head>
         <title>Order Details</title>
         <link rel = "StyleSheet" href = "styles/default.css"/>
      </head>

      <body>
         <xsl:for-each select = "document( '/XSLT/XHTML/navigation.xml' )">
            <xsl:copy-of select = "."/>
         </xsl:for-each>

         <div class = "header">
            OrderID: <xsl:value-of select = "orderID"/>
            Order Date: <xsl:value-of select = "orderDate"/>
         </div>
         
         <xsl:apply-templates select = "orderProducts"/>

         <p>Total: <xsl:value-of select = "totalCost"/></p>
      </body>
      </html>
   </xsl:template>

   <xsl:template match = "orderProducts">
         <table class = "cart">
            <tr>
               <th>Title</th>
               <th>Author</th>
               <th>ISBN</th>
               <th>Quantity</th>
               <th>Price</th>
            </tr>
            <xsl:apply-templates select = "orderProduct"/>
         </table>
   </xsl:template>

   <xsl:template match = "orderProduct">
      <tr>
         <td class = "title">
            <a href = "GetProduct?ISBN={product/ISBN}">
               <xsl:value-of select = "product/title"/>
            </a>
         </td>

         <td class = "author">
            <xsl:value-of select = "product/author"/>
         </td>

         <td><xsl:value-of select = "product/ISBN"/></td>

         <td><xsl:value-of select = "quantity"/></td>

         <td class = "price">
            <xsl:value-of select = "product/price"/>
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
