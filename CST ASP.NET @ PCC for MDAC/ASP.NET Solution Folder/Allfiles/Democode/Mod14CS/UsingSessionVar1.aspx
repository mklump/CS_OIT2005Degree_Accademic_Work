<%@ Page Language="c#" AutoEventWireup="false" Codebehind="UsingSessionVar1.aspx.cs" Inherits="Mod14CS.UsingSessionVar1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UsingSessionVar1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>Here is the value in the session variable named intNumber:</P>
			<P>
				<asp:Label id="lblSessionVar" runat="server"></asp:Label></P>
			<P>
				<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="UsingSessionVar2.aspx">Next Page</asp:HyperLink></P>
			<P>PS: The first time you open this page you will get the initial value that was 
				set in global.asax
			</P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>