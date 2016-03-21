<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page language="c#" Inherits="BenefitsCS.prospectus" CodeFile="prospectus.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>prospectus</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<P>
				<uc1:header id="Header1" runat="server"></uc1:header></P>
			<P align="left">&nbsp;</P>
			<P id="P1" align="left" runat="server">
				<asp:Xml id="xmlProspectus" runat="server" TransformSource="prospectus_style.xsl"></asp:Xml></P>
			<P align="left">&nbsp;</P>
			<P align="left">&nbsp;</P>
			<P align="center">
				<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="retirement.aspx">Back to retirement page</asp:HyperLink></P>
		</FORM>
	</body>
</HTML>
