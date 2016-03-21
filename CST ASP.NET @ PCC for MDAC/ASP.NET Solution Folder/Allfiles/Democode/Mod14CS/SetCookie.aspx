<%@ Page Language="c#" AutoEventWireup="false" Codebehind="SetCookie.aspx.cs" Inherits="Mod14CS.SetCookie" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SetCookie</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
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
