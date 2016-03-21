<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

	<xsl:template match="/">
		<xsl:apply-templates select="//employee" />
	</xsl:template>

	<xsl:template match="employee">
		<P><HR/>
		<xsl:apply-templates/>
		<HR/></P>
	</xsl:template>

	<xsl:template match="name">
		<FONT COLOR="red"/>
		<B>
		<xsl:value-of select="."/>
		</B>
	</xsl:template>

	<xsl:template match="salary">
		($ <xsl:value-of select="."/>)
		<BR/>
	</xsl:template>

	<xsl:template match="jobtitle">
		<FONT COLOR="blue"/>
		<xsl:value-of select="."/>
	</xsl:template>

	<xsl:template match="region">
		<FONT COLOR="black"/>
		<I>
		<xsl:value-of select="."/>
		</I>
	</xsl:template>

</xsl:stylesheet>
