<?xml version = "1.0"?>

<!-- Fig. D.15 : usage1.xsl            -->
<!-- xsl:import example using usage.xml -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:import href = "usage2.xsl"/>

   <!-- this template has higher precedence over 
        templates being imported  -->
   <xsl:template match = "title">

      <h2>
         <xsl:value-of select = "."/>
      </h2>

   </xsl:template>

</xsl:stylesheet>
