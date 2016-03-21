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

   <xsl:template match = "cart">
      <html>

         <head>
            <title>Your Online Shopping Cart</title>
         </head>

         <body>
            <div class = "header">
               Your Shopping Cart:
            </div>
        
            <p>
               Your total: 
               <xsl:value-of select = "@total"/> 
            </p> 
 
            <p>Title</p>
            <p>Author(s)</p>
            <p>ISBN</p>
            <p>Price</p>
            <p>Quantity</p>      
                    
            <ul>
               <xsl:apply-templates 
                  select = "orderProduct"/>
            </ul>

            <p>
               <form method = "post" action = "Checkout">
                  <input type = "submit" name = "Checkout" 
                         value = "Checkout"/>
               </form>
            </p>

         </body>

      </html>  
   </xsl:template>

   <xsl:template match = "orderProduct">
      <li>
         <a href = "GetProduct?ISBN={product/ISBN}">
               <xsl:value-of select = "product/title"/></a>
         <br/>            
         <p><xsl:value-of select = "product/author"/></p>
         <p><xsl:value-of select = "product/ISBN"/></p>
         <p><xsl:value-of select = "product/price"/></p>
         <p>
            <form method = "post" action = "UpdateCart">
               <input type = "text" size = "2" 
                  name = "{product/ISBN}" 
                  value = "{quantity}"/>
               <input type = "submit" value = "Update"/>
            </form>
         </p>
         <p>
            <form method = "post" action = "RemoveFromCart">
               <input type = "hidden" name = "ISBN"
                  value = "{product/ISBN}"/>
               <input type = "submit" value = "Remove"/>
            </form>
         </p>
         <br/>
      </li>
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
