<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      doctype-system = "http://www.wapforum.org/DTD/wml_1.1.xml"
      doctype-public = "-//WAPFORUM//DTD WML 1.1//EN"/>

   <xsl:include href = "/XSLT/WML/error.xsl"/> 

   <xsl:template match = "product">
      <wml>

         <card id = "product" title = "{title}">
            <do type = "accept" label = "Add To Cart">
               <go href = "AddToCart" method = "post">
                  <postfield name = "ISBN" value = "{ISBN}"/>
               </go>
            </do>

            <do type = "prev" label = "Back">
               <prev/>
            </do>
      
            <p>Description:</p>
            <p><xsl:value-of select = "title"/></p>
            <p>by <xsl:value-of select = "author"/></p>

            <p>
               <table columns = "2" title = "info">
                  <tr>
                     <td>ISBN: 
                        <xsl:value-of select = "ISBN"/>
                     </td>
                     <td>Price: 
                        $<xsl:value-of select = "price"/>
                     </td>
                  </tr>
                  <tr>
                     <td>Publisher: 
                        <xsl:value-of select = "publisher"/>
                     </td>
                     <td>Pages: 
                        <xsl:value-of select = "pages"/>
                     </td>
                  </tr>
               </table>
            </p>
         </card>

      </wml>
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
