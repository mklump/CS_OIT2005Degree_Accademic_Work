<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UseXmlControl.aspx.vb" Inherits="Mod12VB.UseXmlControl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UseXmlControl</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>&nbsp;</P>
			<P><asp:Xml id="Xml1" runat="server" DocumentSource="PubTitlesData.xml" TransformSource="PubTitles.xsl"></asp:Xml></P>
		</form>
	</body>
</HTML>
