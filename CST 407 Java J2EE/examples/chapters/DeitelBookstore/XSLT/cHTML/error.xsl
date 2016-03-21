<?xml version = "1.0"?>

<xsl:stylesheet version = "1.0"
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">


   <xsl:template match = "error">
      <html xmlns = "http://www.w3.org/1999/xhtml" 
         xml:lang = "en" lang = "en">

         <head>
            <title>Error Obtaining Product List</title>
            <link rel = "StyleSheet" href = "styles/default.css"/>
         </head>

         <body>
            <div class = "header"><h3>Error message:</h3></div>
            <div class = "error">
               <p><xsl:value-of select = "message"/></p>
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
