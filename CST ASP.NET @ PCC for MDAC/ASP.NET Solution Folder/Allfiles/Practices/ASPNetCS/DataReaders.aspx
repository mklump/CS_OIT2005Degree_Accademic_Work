<%@ Page language="c#" Codebehind="DataReaders.aspx.cs" AutoEventWireup="false" Inherits="ASPNetCS.DataReaders" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataReaders</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="dgOrders" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 168px" runat="server"
				Height="256px" Width="728px"></asp:DataGrid>
			<asp:DropDownList id="ddlCustomers" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 88px"
				runat="server" Width="264px" AutoPostBack="True"></asp:DropDownList>
		</form>
	</body>
</HTML>
