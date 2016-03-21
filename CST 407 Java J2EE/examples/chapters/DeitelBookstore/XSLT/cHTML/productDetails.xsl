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

   <xsl:template match = "product">
      <html>

         <head>
            <title>
               <xsl:value-of select = "title"/> -- Description
            </title>
         </head>

         <body>
            <div class = "header">
               <xsl:value-of select = "title"/>
            </div>
         
            <div class = "author">
               by <xsl:value-of select = "author"/>
            </div>

            <!-- create div element with details of Product -->
            <div class = "productDetails">
               <table>
                  <tr>
                     <td style = "text-align: center;">
                        <img class = "bookCover" 
                           src = "images/{image}"/>   
                     </td>

                     <td>
                        <p style = "text-align: right;">
                           Price: <xsl:value-of select = "price"/>
                        </p>

                        <p style = "text-align: right;">
                           ISBN: <xsl:value-of select = "ISBN"/>
                        </p>
 
                        <p style = "text-align: right;">
                           Pages: <xsl:value-of select = "pages"/>
                        </p> 

                        <p style = "text-align: right;">
                           Publisher: 
                           <xsl:value-of select = "publisher"/>
                        </p>

                        <!-- AddToCart button -->
                        <form method = "post" action = "AddToCart">
                           <p style = "text-align: center;">
                              <input type = "submit" 
                                 value = "Add to cart"/>
                           </p>

                           <input type = "hidden" name = "ISBN" 
                              value = "{ISBN}"/>
                        </form>
                     </td>
                  </tr>
               </table>
            </div>
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
