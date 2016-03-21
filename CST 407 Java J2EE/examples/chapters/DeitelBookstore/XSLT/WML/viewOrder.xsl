<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      doctype-system = "http://www.wapforum.org/DTD/wml_1.1.xml"
      doctype-public = "-//WAPFORUM//DTD WML 1.1//EN"/>

   <xsl:include href = "/XSLT/WML/error.xsl"/> 

   <xsl:template match = "order">
      <wml>

         <card title = "Order Details">
            <do type = "prev"><prev/></do>
            <p>OrderID: <xsl:value-of select = "orderID"/></p>
            <p>Order Date: <xsl:value-of select = "orderDate"/></p>
            <p><xsl:apply-templates select = "orderProducts"/></p>
            <p>Total: $<xsl:value-of select = "totalCost"/></p>
         </card>

      </wml>
   </xsl:template>

   <xsl:template match = "orderProducts">
      <table columns = "3">
         <tr>
            <td>Title</td>
            <td>Quantity</td>
            <td>Price</td>
         </tr>
         <xsl:apply-templates select = "orderProduct"/>
      </table>
   </xsl:template>

   <xsl:template match = "orderProduct">
      <tr>
         <td>
            <a href = "GetProduct?ISBN={product/ISBN}">
               <xsl:value-of select = "product/title"/>
            </a>
         </td>
         <td>
            <xsl:value-of select = "quantity"/>
         </td>
         <td class = "price">
            $<xsl:value-of select = "product/price"/>
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
