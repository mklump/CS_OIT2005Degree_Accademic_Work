<?xml version = "1.0"?>

<!-- Fig. D.18 : author.xsl              -->
<!-- xsl:include example using usage.xml -->

<xsl:stylesheet version = "1.0" 
         xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "author">

      <p>Author:
         <xsl:value-of select = "lastName"/>,
         <xsl:value-of select = "firstName"/>
      </p>

   </xsl:template>

</xsl:stylesheet>
