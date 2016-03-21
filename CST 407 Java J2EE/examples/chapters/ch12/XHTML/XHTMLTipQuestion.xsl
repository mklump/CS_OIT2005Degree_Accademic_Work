<?xml version="1.0"?>

<!-- XHTMLTipQuestion.xsl -->
<!-- XHTML stylesheet     -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      doctype-system = "DTD/xhtml1-strict.dtd"
      doctype-public = "-//W3C//DTD XHTML 1.0 Strict//EN"/>

   <!-- specify the root of the XML document -->
   <!-- that references this stylesheet      -->
   <xsl:template match = "question">
      <html xmlns="http://www.w3.org/1999/xhtml">


         <head>
            <title>Tip Test</title>
         </head>

         <body>

            <p>

               <!-- display image -->
               <img name = "image" alt = "Tip Image" 
                  src = "{image}"> 
               </img>

            </p>

            <p>
               What is the name of the icon shown?
            </p>

            <p>

               <!-- create a form with four checkboxes -->
               <form method = "post" 
                  action = "/advjhtp1/tiptest">

                  <!-- build a table for the options -->
                  <table>
                     <tr>
                        <td>
                           <input type = "radio" 
                              name = "userAnswer" value = "0">
                           </input>
                           <xsl:value-of select = 
                              "choices/choice[1]"/>
                        </td>
                        <td>
                           <input type = "radio" 
                              name = "userAnswer" value = "1">
                           </input>
                           <xsl:value-of select = 
                              "choices/choice[2]"/>
                        </td>
                     </tr>
                     <tr>
                        <td>
                           <input type = "radio" 
                              name = "userAnswer" value = "2">
                           </input>
                           <xsl:value-of select = 
                              "choices/choice[3]"/>
                        </td>
                        <td>
                           <input type = "radio" 
                              name = "userAnswer" value = "3">
                           </input>
                           <xsl:value-of select = 
                              "choices/choice[4]"/>
                        </td>
                     </tr>
                  </table>

                  <input type = "submit" value = "Submit"/>
               </form>
            </p>

         </body>
      </html>
   </xsl:template>
</xsl:stylesheet>

<!--
 ************************************************************************** 
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
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
