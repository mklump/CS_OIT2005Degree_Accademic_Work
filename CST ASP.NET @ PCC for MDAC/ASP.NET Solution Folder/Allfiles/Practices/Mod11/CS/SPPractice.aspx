<%@ Page Language="c#" AutoEventWireup="false" Codebehind="SPPractice.aspx.cs" Inherits="Mod11CS.SPPractice" %>
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
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 42px; POSITION: absolute; TOP: 46px" runat="server"></asp:DataGrid>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 402px; POSITION: absolute; TOP: 43px" runat="server"></asp:TextBox>
			<asp:DataGrid id="DataGrid2" style="Z-INDEX: 103; LEFT: 317px; POSITION: absolute; TOP: 81px" runat="server"></asp:DataGrid>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 313px; POSITION: absolute; TOP: 46px" runat="server">Customer ID</asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 105; LEFT: 574px; POSITION: absolute; TOP: 41px" runat="server" Text="Get Orders"></asp:Button>
		</form>
	</body>
</HTML>
