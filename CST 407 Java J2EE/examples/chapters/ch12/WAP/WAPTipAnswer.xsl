<?xml version="1.0"?>

<!-- WAPTipAnswer.xsl -->
<!-- WAP stylesheet   -->

<xsl:stylesheet 
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
      version="1.0">

   <xsl:output method = "xml" omit-xml-declaration = "no" 
      doctype-system = "http://www.wapforum.org/DTD/wml_1.1.xml"
      doctype-public = "-//WAPFORUM//DTD WML 1.1//EN"/>

   <!-- specify the root of the XML document -->
   <!-- that references this stylesheet      -->
   <xsl:template match = "answer">

      <wml>

         <card id = "card1" title = "Tip Test Answer">

            <do type = "accept" label = "OK">
               <go method = "get" 
                  href = "/advjhtp1/tiptest">
               </go>
            </do>

            <p>
               <xsl:value-of select = "correct"/>
            </p>

            <p>
               Tip Name
            </p>

            <p>
               <xsl:value-of select = "correctTipName"/>
            </p>

            <p>
               Tip Description
            </p>

            <p>
               <xsl:value-of select = "correctTipDescription"/>
            </p>

         </card>

      </wml>
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
