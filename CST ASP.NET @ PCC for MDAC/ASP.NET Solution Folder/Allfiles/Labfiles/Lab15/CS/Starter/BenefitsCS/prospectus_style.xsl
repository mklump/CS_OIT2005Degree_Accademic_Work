<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version='1.0'>

<xsl:template match="/">
	<html>
	<body>
	<center>
	<!-- The heading -->
	<div STYLE="font-family:Comic Sans MS;
		font-size:36pt;
		font-weight:bold;
		color:blue;
		text-align:center">
		Prospectus
	</div>
	<br/><br/>
	<xsl:apply-templates select="information/prospectus" />
	</center>
	</body>
	</html>
</xsl:template>

<xsl:template match="prospectus">
	<b style="font-family:Comic Sans MS; font-size:14pt; color:brown">Name of the fund</b><br/>
	<b><xsl:value-of select="fundName" /></b>
	<br/><br/><br/>
	<b style="font-family:Comic Sans MS; font-size:14pt; color:brown">General description</b><br/>
	<xsl:value-of select="fundGeneralDescription" />
	<br/><br/><br/>
	<b style="font-family:Comic Sans MS; font-size:14pt; color:brown">Detailed description</b><br/>
	<xsl:value-of select="fundDetailedDescription" />
	<br/><br/><br/>
</xsl:template>
</xsl:stylesheet>
