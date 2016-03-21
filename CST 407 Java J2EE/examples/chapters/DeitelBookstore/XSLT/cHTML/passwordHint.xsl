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

   <xsl:template match= "passwordHint">
      <html>

         <head>
            <title>Your Password Hint</title>
            <link rel = "StyleSheet" href = "styles/default.css"/>
         </head>
	
         <body>
            <div class = "header">
               Password hint:<br/>
               <xsl:value-of select = "."/>
            </div>

            <div class = "login">
               <form method = "post" action = "Login">
                  <table>
                     <tr>
                        <td>Email Address:</td>
                        <td>
                           <input type = "text" name = "userID"/>
                        </td>
                     </tr>
                     <tr>  
                        <td>Password:</td>
                        <td>
                           <input type = "password" name = "password"/>
                        </td>
                     </tr>
                     <tr>
                        <td colspan = "2" style = "text-align:center;">
                           <input type = "submit" value = "Log In"/>
                        </td>
                     </tr>
                  </table>   
               </form>
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
