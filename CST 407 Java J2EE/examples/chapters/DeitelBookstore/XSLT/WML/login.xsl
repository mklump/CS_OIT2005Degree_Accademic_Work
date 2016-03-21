<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      doctype-system = "http://www.wapforum.org/DTD/wml_1.1.xml"
      doctype-public = "-//WAPFORUM//DTD WML 1.1//EN"/>

   <xsl:include href = "/XSLT/WML/error.xsl"/> 

   <xsl:template match = "login">   
      <wml>

         <card id = "card1" title = "Deitel Wireless Shopping">
            <do type = "accept" label = "Main Menu">
               <go href = "#menu"/>
            </do>
	
            <p>
               Welcome to Deitel Wireless Shopping, 
               <xsl:value-of select = "firstName"/>
            </p>
         </card>

         <card id = "menu" title = "Deitel Wireless Shopping">
            <do type = "Products" label = "Products">
               <go href = "GetAllProducts" method = "get"/>
            </do>
            <do type = "Search" label = "Search">
               <go href = "#search"/>
            </do>
            <do type = "Log in" label = "Log in">
               <go href = "login.wml"/>
            </do>
            <do type = "viewCart" label = "View Cart">
               <go href = "ViewCart" method = "get"/>
            </do>
            <do type = "OrderHistory" label = "Order History">
               <go href = "ViewOrderHistory" method = "get"/>
            </do>
            <p>
               <em>
                  Welcome 
                  <xsl:value-of select = "firstName"/>
                  <br/>
               </em>
            </p>
            <p>Select Options or Scroll Down for Menu</p>
            <p>
               <a href = "GetAllProducts">
                  Products
               </a>
            </p>
            <p><a href = "#search">Search</a></p>
            <p><a href = "login.wml">Log in</a></p>
            <p><a href = "ViewCart">View Cart </a></p>
            <p>
               <a href = "ViewOrderHistory">
                  Order History
               </a>
            </p>	    
         </card>

         <card id = "search" title = "Search for Books">
            <onevent type = "onenterforward">
               <refresh>
                  <setvar name = "query" value = ""/>
               </refresh>
            </onevent>
                
            <p>Enter Query:</p>
            <p>
               <input name = "query" format ="*"
                  type = "text" maxlength = "25"/>
               <anchor title = "search">
                  Search
                  <go href = "ProductSearch" method = "get">
                     <postfield name = "searchString" value = "$(query)"/>
                  </go>
               </anchor>
            </p>
            <p><a href = "#menu">Back</a></p>
         </card>
 
      </wml>
    </xsl:template>


<!-- 
 ************************************************************************** 
 * (C) Copyright 2002 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************
-->

</xsl:stylesheet>
