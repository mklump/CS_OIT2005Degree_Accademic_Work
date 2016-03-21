<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UseDataSet.aspx.vb" Inherits="Mod10VB.UseDataSet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="cmdRows" style="Z-INDEX: 102; LEFT: 31px; POSITION: absolute; TOP: 28px" runat="server" Text="Get Number of Rows"></asp:Button>
			<asp:Label id="lblRows" style="Z-INDEX: 103; LEFT: 224px; POSITION: absolute; TOP: 33px" runat="server"></asp:Label>
			<asp:Button id="cmdGetValues" style="Z-INDEX: 104; LEFT: 33px; POSITION: absolute; TOP: 72px" runat="server" Text="Get Values"></asp:Button>
			<asp:Label id="lblNames" style="Z-INDEX: 105; LEFT: 242px; POSITION: absolute; TOP: 75px" runat="server"></asp:Label>
			<asp:DropDownList id="lstItems" style="Z-INDEX: 106; LEFT: 150px; POSITION: absolute; TOP: 73px" runat="server"></asp:DropDownList>
		</form>
	</body>
</HTML>
