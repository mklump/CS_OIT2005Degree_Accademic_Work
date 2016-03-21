<%@ Page Language="c#" AutoEventWireup="false" Codebehind="UseDataSet.aspx.cs" Inherits="Mod10CS.UseDataSet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="cmdRows" style="Z-INDEX: 101; LEFT: 31px; POSITION: absolute; TOP: 28px" runat="server" Text="Get Number of Rows"></asp:Button>
			<asp:Label id="lblRows" style="Z-INDEX: 102; LEFT: 224px; POSITION: absolute; TOP: 33px" runat="server"></asp:Label>
			<asp:Button id="cmdGetValues" style="Z-INDEX: 103; LEFT: 33px; POSITION: absolute; TOP: 72px" runat="server" Text="Get Values"></asp:Button>
			<asp:Label id="lblNames" style="Z-INDEX: 104; LEFT: 242px; POSITION: absolute; TOP: 75px" runat="server"></asp:Label>
			<asp:DropDownList id="lstItems" style="Z-INDEX: 105; LEFT: 150px; POSITION: absolute; TOP: 73px" runat="server"></asp:DropDownList>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 106; LEFT: 264px; POSITION: absolute; TOP: 176px" runat="server" Width="208px" Height="88px"></asp:DataGrid>
		</form>
	</body>
</HTML>
