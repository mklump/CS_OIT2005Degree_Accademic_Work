<%@ Page Language="vb" AutoEventWireup="false" Codebehind="securitytest.aspx.vb" Inherits="BenefitsVB.SecurityTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WinSecurePage</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P><STRONG><FONT size="5">Current security info:</FONT></STRONG></P>
			<P><STRONG>Authenticated User:</STRONG>
				<asp:Label id="lblAuthUser" runat="server">Label</asp:Label></P>
			<P><STRONG>Authentication Type:</STRONG>
				<asp:Label id="lblAuthType" runat="server">Label</asp:Label></P>
		</form>
	</body>
</HTML>
