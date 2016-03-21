<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template match="NewDataSet">
  <HTML>
  <STYLE>
  BODY {font-family:verdana;font-size:9pt}
  TD   {font-size:8pt}
  </STYLE>
    <BODY>
    <TABLE>
      <xsl:apply-templates select="Customers"/>
    </TABLE>
    </BODY>
  </HTML>
</xsl:template>

<xsl:template match="Customers">
    <TR><TD><B>
      <xsl:value-of select="ContactName"/>, <xsl:value-of select="Phone"/><BR/>
    </B></TD>
      <xsl:apply-templates select="Orders"/>
	</TR>
</xsl:template>

<xsl:template match="Orders">
  <TD><TABLE BORDER="1">
    <TR><TD valign="top"><B>Order:</B></TD><TD valign="top"><xsl:value-of select="OrderID"/></TD></TR>
    <TR><TD valign="top"><B>Date:</B></TD><TD valign="top"><xsl:value-of select="OrderDate"/></TD></TR>
    <TR><TD valign="top"><B>Ship To:</B></TD>
        <TD valign="top"><xsl:value-of select="ShipName"/><BR/>
        <xsl:value-of select="ShipAddress"/><BR/>
        <xsl:value-of select="ShipCity"/>, <xsl:value-of select="ShipRegion"/>  <xsl:value-of select="ShipPostalCode"/><BR/>
        <xsl:value-of select="ShipCountry"/></TD></TR>
  </TABLE></TD>
</xsl:template>

</xsl:stylesheet>



  