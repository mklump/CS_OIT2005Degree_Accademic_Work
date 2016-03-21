<%@ Page language="c#" Codebehind="UseXmlControl.aspx.cs" AutoEventWireup="false" Inherits="Mod12CS.UseXmlControl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm6</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<P>&nbsp;</P>
			<P>
				<asp:Xml id="Xml1" runat="server" DocumentSource="PubTitlesData.xml" TransformSource="PubTitles.xsl"></asp:Xml></P>
		</FORM>
	</body>
</HTML>
