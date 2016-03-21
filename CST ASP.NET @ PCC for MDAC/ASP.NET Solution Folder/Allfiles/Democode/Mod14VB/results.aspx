<%@ Page Language="vb" AutoEventWireup="false" Codebehind="results.aspx.vb" Inherits="Mod14VB.results" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>results</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblWelcome" style="Z-INDEX: 101; LEFT: 74px; POSITION: absolute; TOP: 73px" runat="server" Font-Size="Medium"></asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 52px; POSITION: absolute; TOP: 194px" runat="server">This page has been visited</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 279px; POSITION: absolute; TOP: 194px" runat="server">times.</asp:Label>
			<asp:TextBox id="txtHits" style="Z-INDEX: 104; LEFT: 221px; POSITION: absolute; TOP: 191px" runat="server" Width="44px" ReadOnly="True"></asp:TextBox>
			<asp:Label id="lblTime" style="Z-INDEX: 105; LEFT: 54px; POSITION: absolute; TOP: 143px" runat="server">You last signed in at: </asp:Label>
		</form>
	</body>
</HTML>
