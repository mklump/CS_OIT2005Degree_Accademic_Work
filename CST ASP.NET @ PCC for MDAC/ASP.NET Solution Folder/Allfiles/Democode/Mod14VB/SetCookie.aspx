<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SetCookie.aspx.vb" Inherits="Mod14VB.SetCookie" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SetCookie</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>A cookie has been issued with the folowing info:</P>
			<P>- The time/date of now</P>
			<P>- A ForeColor</P>
			<P>- A BackColor</P>
			<P>&nbsp;</P>
			<P><asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="GetCookie.aspx">Read the cookie</asp:hyperlink></P>
		</form>
	</body>
</HTML>
