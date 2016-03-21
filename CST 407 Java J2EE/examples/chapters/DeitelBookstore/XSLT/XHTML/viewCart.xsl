<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      indent = "yes" doctype-system = "DTD/xhtml1-strict.dtd"
      doctype-public = "-//W3C//DTD XHTML 1.0 Strict//EN"/>

   <xsl:include href = "/XSLT/XHTML/error.xsl"/>

   <xsl:template match = "cart">
      <html xmlns = "http://www.w3.org/1999/xhtml" 
            xml:lang = "en" lang = "en">

         <head>
            <title>Your Online Shopping Cart</title>
            <link rel = "StyleSheet" href = "styles/default.css"/>
         </head>

         <body>

            <xsl:for-each select = 
               "document( '/XSLT/XHTML/navigation.xml' )">

               <xsl:copy-of select = "."/>
            </xsl:for-each>

            <div class = "header">Your Shopping Cart:</div>

            <table class = "cart">
               <tr>
                  <th>Title</th>
                  <th>Author(s)</th>
                  <th>ISBN</th>
                  <th>Price</th>
                  <th>Quantity</th>      
               </tr>

               <xsl:apply-templates 
                  select = "orderProduct"/>

            </table>

            <p>
               Your total: 
               <xsl:value-of select = "@total"/> 
            </p> 

            <p>
               <form action = "Checkout" method = "post">
                  <input name = "Submit" type = "submit" 
                     value = "Check Out"/>
               </form>
            </p>

         </body>
      </html>  
   </xsl:template>

   <xsl:template match = "orderProduct">
      <tr>
         <td>
            <a href = "GetProduct?ISBN={product/ISBN}">
               <xsl:value-of select = "product/title"/></a>
         </td>            

         <td><xsl:value-of select = "product/author"/></td>

         <td><xsl:value-of select = "product/ISBN"/></td>

         <td><xsl:value-of select = "product/price"/></td>

         <td>
            <form action = "UpdateCart" method = "post">
               <input type = "text" size = "2" 
                  name = "{product/ISBN}" 
                  value = "{quantity}"/>
               <input type = "submit" value = "Update"/>
            </form>
         </td>

         <td align = "center">
            <form action = "RemoveFromCart" method = "post">
               <input name = "ISBN" type = "hidden" 
                      value = "{product/ISBN}"/>
               <input type = "submit" value = "Remove"/>
            </form>
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
