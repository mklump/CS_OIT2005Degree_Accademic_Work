<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LoginDemo.aspx.vb" Inherits="Mod16VB.LoginDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>LoginDemo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center"><STRONG></STRONG>&nbsp;</P>
			<P align="center"><STRONG>User Name (Email)</STRONG></P>
			<P align="center">
				<asp:TextBox id="txtUserName" runat="server"></asp:TextBox></P>
			<P>&nbsp;</P>
			<P align="center"><STRONG>Password</STRONG></P>
			<P align="center">
				<asp:TextBox id="txtPassword" runat="server"></asp:TextBox></P>
			<P>&nbsp;</P>
			<P align="center">
				<asp:Button id="cmdLogin" runat="server" Text="Sign In Now"></asp:Button></P>
			<P>&nbsp;</P>
			<P align="center">
				<asp:Label id="lblInfo" runat="server"></asp:Label></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
