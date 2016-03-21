<?xml version = "1.0"?>

<!-- Fig. D.6 : elements.xsl             -->
<!-- Using xsl:element and xsl:attribute -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "/">
      <xsl:apply-templates/>
   </xsl:template>

   <xsl:template match = "sports">
      <sports>
         <xsl:apply-templates/>
      </sports>
   </xsl:template>

   <xsl:template match = "game">
      <xsl:element name = "@title">

         <xsl:attribute name = "id">
            <xsl:value-of select = "id"/>
         </xsl:attribute>

         <comment>
            <xsl:value-of select = "para"/>
         </comment>

      </xsl:element> 
   </xsl:template>

</xsl:stylesheet>
