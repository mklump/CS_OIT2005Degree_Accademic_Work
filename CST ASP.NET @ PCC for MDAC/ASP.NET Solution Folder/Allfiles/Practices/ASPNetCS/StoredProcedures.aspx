<%@ Page language="c#" Codebehind="StoredProcedures.aspx.cs" AutoEventWireup="false" Inherits="ASPNetCS.StoredProcedures" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StoredProcedures</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList id="ddlCustomers" style="Z-INDEX: 102; LEFT: 96px; POSITION: absolute; TOP: 80px"
				runat="server" AutoPostBack="True" Width="264px"></asp:DropDownList>
			<DIV style="DISPLAY: inline; Z-INDEX: 106; LEFT: 352px; WIDTH: 160px; POSITION: absolute; TOP: 136px; HEIGHT: 19px"
				ms_positioning="FlowLayout">Phone</DIV>
			<asp:DataGrid id="dgOrders" style="Z-INDEX: 101; LEFT: 88px; POSITION: absolute; TOP: 200px" runat="server"
				Width="728px" Height="256px"></asp:DataGrid>
			<asp:TextBox id="txtCompanyName" style="Z-INDEX: 103; LEFT: 96px; POSITION: absolute; TOP: 160px"
				runat="server" Width="240px"></asp:TextBox>
			<asp:TextBox id="txtPhone" style="Z-INDEX: 104; LEFT: 344px; POSITION: absolute; TOP: 160px"
				runat="server" Width="176px"></asp:TextBox>
			<DIV style="DISPLAY: inline; Z-INDEX: 105; LEFT: 104px; WIDTH: 190px; POSITION: absolute; TOP: 136px; HEIGHT: 19px"
				ms_positioning="FlowLayout">Company Name</DIV>
			<asp:Button id="btnUpdate" style="Z-INDEX: 107; LEFT: 576px; POSITION: absolute; TOP: 152px"
				runat="server" Width="88px" Text="Update"></asp:Button>
		</form>
	</body>
</HTML>
