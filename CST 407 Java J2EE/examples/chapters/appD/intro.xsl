<?xml version = "1.0"?>

<!-- Fig. D.2 : intro.xsl               -->
<!-- Simple XSLT document for intro.xml -->

<xsl:stylesheet version = "1.0" 
         xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "myMessage">
      <html>
         <body><xsl:value-of select = "message"/></body>
      </html>
   </xsl:template>

</xsl:stylesheet>