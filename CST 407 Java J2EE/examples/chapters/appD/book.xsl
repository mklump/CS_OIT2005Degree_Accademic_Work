<?xml version = "1.0"?>

<!-- Fig. D.17 : book.xsl                -->
<!-- xsl:include example using usage.xml -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "/">

   <html>
      <body>
         <xsl:apply-templates select = "book"/>
      </body>
   </html>

   </xsl:template>

   <xsl:template match = "book">

      <h2>
         <xsl:value-of select = "title"/>
      </h2>

      <xsl:apply-templates/>
   </xsl:template>

   <xsl:include href = "author.xsl"/>
   <xsl:include href = "chapters.xsl"/>
  
   <xsl:template match = "*|text()"/>

</xsl:stylesheet>
