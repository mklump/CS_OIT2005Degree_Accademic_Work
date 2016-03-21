<%@ Page Language="c#" AutoEventWireup="false" Codebehind="UsingSessionVar2.aspx.cs" Inherits="Mod14CS.UsingSessionVar2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UsingSessionVar2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>Here is the value in the session variable increased by 4:</P>
			<P>
				<asp:Label id="lblSessionVar" runat="server"></asp:Label></P>
			<P>
				<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="UsingSessionVar1.aspx">Previous Page</asp:HyperLink></P>
		</form>
	</body>
</HTML>
