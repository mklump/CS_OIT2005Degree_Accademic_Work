<?xml version = "1.0"?>

<!-- Fig. D.21 : variables.xsl  -->
<!-- using xsl:variables        -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "/">

      <total>
         Number of pages = 
         <xsl:variable name = "pageCount" 
            select = "sum(book/chapters/*/@pages)"/>
         <xsl:value-of select = "$pageCount"/>
      </total>

   </xsl:template>

</xsl:stylesheet>
