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

   <xsl:template match = "login">
      <html>		

         <head>
            <title>
               Welcome, <xsl:value-of select = "firstName"/>
            </title> 
         </head>

         <body>
            <div class = "header">
               Welcome to the Deitel Bookstore,
               <xsl:value-of select = "firstName"/>
            </div>
            <h6>
               <form action = "ProductSearch" method="get">
                  <p>
                     <input type = "text" size="15" 
                        name = "searchString"/>
                     <input type="submit" value="Search"/>
                  </p>
               </form>
               <p><a href = "GetAllProducts">Products</a></p>
               <p><a href = "login.html">Log In</a></p>
               <p><a href = "ViewCart">Shopping Cart</a></p>
               <p><a href = "ViewOrderHistory">View Order History</a></p>
            </h6>
            <p><h3><a href = "index.html">Home</a></h3></p>
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
