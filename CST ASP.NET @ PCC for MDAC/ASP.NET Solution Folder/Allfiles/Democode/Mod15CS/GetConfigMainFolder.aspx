<%@ Page language="c#" Codebehind="GetConfigMainFolder.aspx.cs" AutoEventWireup="false" Inherits="Mod15CS.GetConfigMainFolder" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GetConfigMainFolder</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="WebForm1" method="post" runat="server">
			Here is the value read from the Web.config appsettings section:
			<BR>
			<BR>
			<B>
				<asp:Label id="label1" runat="server"></asp:Label></B><BR>
			<BR>
			<asp:button id="cmdNext" runat="server" Text="Next >"></asp:button></FORM>
	</body>
</HTML>
