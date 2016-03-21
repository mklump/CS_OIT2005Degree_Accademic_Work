<%@ Page Language="c#" AutoEventWireup="false" Codebehind="SecurePageDemo2.aspx.cs" Inherits="Mod16CS.SecurePageDemo2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SecurePageDemo2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<STRONG><FONT size="6">Congratulations, you are on the second secure page!</FONT></STRONG>
			</P>
			<P>&nbsp;</P>
			<P><STRONG>Authenticated User:</STRONG>
				<asp:Label id="lblAuthUser" runat="server"></asp:Label></P>
			<P><STRONG>Authentication Type:</STRONG>
				<asp:Label id="lblAuthType" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
