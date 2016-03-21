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

   <xsl:template match = "orderHistory">
      <html>

         <head>
            <title>Your Order History</title>
         </head>

         <body>
            <div class = "header">Order History</div> 

            <table class = "cart">
               <tr>
	          <h5>
                     <p>Order ID</p>
                     <p>Order Date</p>
                     <p>Total</p>
                     <p>Shipped</p>
                  </h5>
               </tr>

               <xsl:apply-templates select = "order"/>
               <hr/>
            </table>

            <b>
               <a href = "index.html">HOME</a>
            </b>      
         </body>

      </html>
   </xsl:template>

   <xsl:template match = "order">
      <hr/>
      <tr>
         <h6>
            <p>
               <a href = "ViewOrder?orderID={orderID}">
                  <xsl:value-of select = "orderID" />
               </a>
            </p>
            <p><xsl:value-of select = "orderDate"/></p>
            <p><xsl:value-of select = "totalCost"/></p>
            <p>Shipped: <xsl:value-of select = "shipped"/></p>
         </h6>
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
