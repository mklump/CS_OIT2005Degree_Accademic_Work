<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="BenefitsVB.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P><FONT size="6"> Please enter your credentials</FONT></P>
			<P>Email:</P>
			<P>
				<asp:TextBox id="txtEmail" runat="server"></asp:TextBox></P>
			<P><FONT size="1"></FONT>&nbsp;</P>
			<P>Password:</P>
			<P>
				<asp:TextBox id="txtPassword" runat="server" TextMode="Password"></asp:TextBox></P>
			<P>&nbsp;</P>
			<P>
				<asp:Button id="cmdLogin" runat="server" Text="Sign In Now"></asp:Button></P>
			<P>
				<asp:Label id="lblInfo" runat="server"></asp:Label></P>
			<P>
				If you are a new employee and you don't have an account, then register for one 
				now.
				<asp:HyperLink id="lnkRegister" runat="server" NavigateUrl="register.aspx">Click here!</asp:HyperLink></P>
		</form>
	</body>
</HTML>
