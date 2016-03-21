<%@ Page Language="c#" AutoEventWireup="false" Codebehind="GetCookie.aspx.cs" Inherits="Mod14CS.GetCookie" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>GetCookie</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>Cookie.Value("Time") =
				<asp:Label id="Label1" runat="server">Label</asp:Label></P>
			<P>Cookie.Value("ForeColor") =
				<asp:Label id="Label2" runat="server">Label</asp:Label></P>
			<P>Cookie.Value("BackColor") =
				<asp:Label id="Label3" runat="server">Label</asp:Label></P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
