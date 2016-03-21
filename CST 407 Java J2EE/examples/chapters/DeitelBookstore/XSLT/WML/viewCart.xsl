<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      doctype-system = "http://www.wapforum.org/DTD/wml_1.1.xml"
      doctype-public = "-//WAPFORUM//DTD WML 1.1//EN"/>

   <xsl:include href = "/XSLT/WML/error.xsl"/> 

   <xsl:template match = "cart">
      <wml>
         
         <card title = "Shopping Cart">
            <do type = "prev">
               <prev/>
            </do>

            <do type = "accept" label = "Check Out">
               <go href = "Checkout" method = "post"/>
            </do>

            <p><em>Shopping Cart</em></p>

            <p>
               Your total: $<xsl:value-of select = "@total"/> 

               <table columns = "2">
                  <tr>
                     <td>Title</td>
                     <td>Price</td>
                  </tr>       

                  <xsl:for-each select = "orderProduct">
                     <tr>
                        <td>
                           <a href = "#ISBN{product/ISBN}">
                              <xsl:value-of select = "product/title"/>
                           </a>
                        </td>            
                        <td>
                           $<xsl:value-of select = "product/price"/>
                        </td>
                     </tr>
                  </xsl:for-each>

               </table>
            </p>
	
         </card>

         <xsl:for-each select = "orderProduct" >
            <card id = "ISBN{product/ISBN}">
               <do label = "OK" type = "prev"><prev/></do>
               <do label = "Change Quant" type = "options">
                  <go href = "#quant{product/ISBN}"/>
               </do>
               <p><xsl:value-of select = "product/title"/></p>
               <p>Quantity: <xsl:value-of select = "quantity"/></p>
               <p><xsl:value-of select = "product/author"/></p>
               <p><xsl:value-of select = "product/ISBN"/></p>		
     	    </card>

            <card id = "quant{product/ISBN}">
               <p>Enter new quantity
                  <input name = "quantity" emptyok = "false"
                     type = "text" format = "*n"/>
               </p>
	   
               <do type = "accept" label = "Update Quantity">
                  <go href = "UpdateCart" method = "post">
                     <postfield name = "{product/ISBN}" value = "$quantity"/>
                  </go>
               </do>

               <do type = "prev" label = "Cancel"><prev/></do>

            </card>
         </xsl:for-each>
	
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
