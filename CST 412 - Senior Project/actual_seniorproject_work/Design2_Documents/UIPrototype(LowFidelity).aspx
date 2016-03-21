<%@ Page language="c#" Codebehind="UIPrototype(LowFidelity).aspx.cs" AutoEventWireup="false" Inherits="thepuzzler_3dstyle.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="True">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:ListBox id="ListBox1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 40px" runat="server"
				Width="152px" Height="640px"></asp:ListBox>
			<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 16px" runat="server"
				Width="96px">Words Found:</asp:Label>
			<asp:ListBox id="ListBox2" style="Z-INDEX: 103; LEFT: 184px; POSITION: absolute; TOP: 40px" runat="server"
				Width="152px" Height="640px"></asp:ListBox>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 16px" runat="server"
				Width="96px">Dictionary:</asp:Label>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 105; LEFT: 344px; POSITION: absolute; TOP: 64px"
				runat="server" Width="608px" Height="606px" BorderColor="Black" BorderWidth="2px"></asp:DataGrid>
			<asp:DropDownList id="DropDownList1" style="Z-INDEX: 106; LEFT: 344px; POSITION: absolute; TOP: 40px"
				runat="server" Width="168px"></asp:DropDownList>
			<asp:Label id="Label3" style="Z-INDEX: 107; LEFT: 344px; POSITION: absolute; TOP: 16px" runat="server"
				Width="96px">Current Layer:</asp:Label>
			<asp:DataGrid id="DataGrid2" style="Z-INDEX: 108; LEFT: 23px; POSITION: absolute; TOP: 707px"
				runat="server" Width="926px"></asp:DataGrid>
			<asp:Label id="Label4" style="Z-INDEX: 109; LEFT: 23px; POSITION: absolute; TOP: 680px" runat="server"
				Width="158px">Statistics for This Puzzle:</asp:Label>
		</form>
	</body>
</HTML>
