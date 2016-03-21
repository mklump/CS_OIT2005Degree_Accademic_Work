<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template match="NewDataSet">
  <HTML>
  <STYLE>
  BODY {font-family:verdana;font-size:9pt}
  TD   {font-size:8pt}
  </STYLE>
    <BODY>
      <xsl:apply-templates select="Publishers"/>
    </BODY>
  </HTML>
</xsl:template>

<xsl:template match="Publishers">
    <B>
      <xsl:value-of select="pub_name"/><BR/>
    </B>
    <table border="1">
    <TR><TD valign="top"><B>Title</B></TD>
    <TD valign="top"><B>Price</B></TD></TR>
      <xsl:apply-templates select="Titles"/>
    </table>
    <BR></BR>
</xsl:template>

<xsl:template match="Titles">
    <TR><TD valign="top"><xsl:value-of select="title"/></TD>
    <TD valign="top"><xsl:value-of select="price"/></TD></TR>
</xsl:template>

</xsl:stylesheet>



  