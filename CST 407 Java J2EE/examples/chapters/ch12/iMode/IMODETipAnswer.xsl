<?xml version="1.0"?>

<!-- IMODETipAnswer.xsl -->
<!-- i-mode stylesheet  -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:output method = "html" omit-xml-declaration = "yes" 
      doctype-public = "-//W3C//DTD Compact HTML 1.0 Draft//EN"/>
         
   <!-- specify the root of the XML document -->
   <!-- that references this stylesheet      -->
   <xsl:template match = "answer">
      <html>

         <head>
            <title>Tip Test Answer</title>
         </head>

         <body>

            <p>
               <h1>
                  <xsl:value-of select = "correct"/>
               </h1>
            </p>

            <p>
               <h2>Tip Name</h2>
            </p>

            <p>
               <h3>
                  <xsl:value-of select = "correctTipName"/>
               </h3>
            </p>

            <p>
               <h2>Tip Description</h2>
            </p>

            <p>
               <h3>
                  <xsl:value-of 
                     select = "correctTipDescription"/>
               </h3>
            </p>

            <p>
               <h2>
                  <a href="{servletName}">Next Tip</a>
               </h2>
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