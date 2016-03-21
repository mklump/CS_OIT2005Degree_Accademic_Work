<?xml version = "1.0"?>

<!-- Fig. D.14 : usage2.xsl    -->
<!-- xsl:import example        -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "book">
      <html>

         <body>
            <xsl:apply-templates/>
         </body>
      </html>

   </xsl:template>

   <xsl:template match = "title">
      <xsl:value-of select = "."/>
   </xsl:template>

   <xsl:template match = "author">
      <br/>

      <p>Author:
         <xsl:value-of select = "lastName"/>,
         <xsl:value-of select = "firstName"/>
      </p>

   </xsl:template>

   <xsl:template match = "*|text()"/>

</xsl:stylesheet>
