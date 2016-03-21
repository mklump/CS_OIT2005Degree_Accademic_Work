<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      doctype-system = "http://www.wapforum.org/DTD/wml_1.1.xml"
      doctype-public = "-//WAPFORUM//DTD WML 1.1//EN"/>

   <xsl:include href = "/XSLT/WML/error.xsl"/> 

   <xsl:template match = "orderHistory">
      <wml>

         <card title = "Order History">
            <do type = "prev" label="back"><prev/></do>

            <p>
               <table columns = "4">
                  <tr>
                     <td>Order ID</td>
                     <td>Order Date</td>
                     <td>Total</td>
                     <td>Shipped</td>
                  </tr>
                  <xsl:apply-templates select = "order"/>
               </table>
            </p>
         </card>

      </wml>
   </xsl:template>

   <xsl:template match = "order">
      <tr>
         <td>
            <a href = "ViewOrder?orderID={orderID}">
               <xsl:value-of select = "orderID"/>
            </a>
         </td>
         <td>
            <xsl:value-of select = "orderDate"/>
         </td>
         <td>
            $<xsl:value-of select = "totalCost"/>
         </td>
         <td>
            <xsl:value-of select = "shipped"/>
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
