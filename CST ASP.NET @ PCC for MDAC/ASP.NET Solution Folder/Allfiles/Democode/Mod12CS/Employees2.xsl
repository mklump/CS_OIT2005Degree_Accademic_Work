<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

	<xsl:template match="/">
		<HTML>
		<BODY>

		<!-- The heading -->
		<DIV STYLE="font-family:Comic Sans MS;
		            font-size:36pt;
		            font-weight:bold;
		            color:red;
		            text-align:center">
		   	Employees
		</DIV>
		<BR/>

		<!-- Define an HTML table -->
		<TABLE WIDTH="100%" BORDER="2">
			<xsl:apply-templates select="//employee" />
		</TABLE>

		</BODY>
		</HTML>
	</xsl:template>


	<!-- Each row in the table is a separate employee -->
	<xsl:template match="employee">
		<TR VALIGN="top">

		<!-- Display the "name" in the first column -->
		<TD STYLE="font-family:Comic Sans MS;
		           font-size:12pt;
		           color:darkblue">
			<xsl:value-of select="name"/>
		</TD>

		<!-- Display the "region" in the second column -->
		<TD STYLE="font-family:Comic Sans MS;
		           font-size:12pt;
		           color:red">
			<xsl:value-of select="region"/>
		</TD>

		<!-- Display the "jobtitle" in the third column -->
		<TD STYLE="font-family:Comic Sans MS;
		           font-size:12pt;
		           color:orange">
			<xsl:value-of select="jobtitle"/>
		</TD>

		<!-- Display the "salary" in the last column -->
		<TD STYLE="font-family:Comic Sans MS;
		           font-size:12pt;
		           color:darkgreen">
			<xsl:value-of select="salary"/>
		</TD>

		</TR>
	</xsl:template>

</xsl:stylesheet>

