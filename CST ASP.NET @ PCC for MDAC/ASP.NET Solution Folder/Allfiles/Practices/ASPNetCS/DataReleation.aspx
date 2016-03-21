<%@ Page language="c#" Codebehind="DataReleation.aspx.cs" AutoEventWireup="false" Inherits="ASPNetCS.DataReleation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataReleation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList id="ddlCustomers" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 88px"
				runat="server" Width="264px" AutoPostBack="True"></asp:DropDownList>
			<asp:DataGrid id="dgOrders" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 184px" runat="server"
				Width="728px" Height="256px"></asp:DataGrid>
		</form>
	</body>
</HTML>
