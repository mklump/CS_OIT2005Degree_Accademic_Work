<%@ Page language="c#" Codebehind="MyUseXmlControl.aspx.cs" AutoEventWireup="false" Inherits="Mod12CS.MyUseXmlControl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MyUseXmlControl</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Xml id="Xml1" runat="server" DocumentSource="PubTitlesData.xml" TransformSource="PubTitles.xsl"></asp:Xml>
		</form>
	</body>
</HTML>
