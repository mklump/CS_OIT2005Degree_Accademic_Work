<%@ Page Language="c#" AutoEventWireup="false" Codebehind="DemoSolution.aspx.cs" Inherits="Mod09CS.DemoSolution" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 70px; POSITION: absolute; TOP: 31px" runat="server" Text="Button"></asp:Button>
			<asp:DataGrid id=DataGrid1 style="Z-INDEX: 102; LEFT: 70px; POSITION: absolute; TOP: 69px" runat="server" DataSource="<%# DataSet11 %>" DataMember="authors" BorderStyle="None" BorderWidth="1px" BorderColor="#DEBA84" BackColor="#DEBA84" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" PageSize="4" AllowPaging="True" AllowSorting="True">
				<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
				<ItemStyle ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="au_lname" SortExpression="au_lname" HeaderText="Last Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="au_fname" SortExpression="au_fname" HeaderText="First Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="phone" SortExpression="phone" HeaderText="Phone"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Label id="lblSortText" style="Z-INDEX: 103; LEFT: 190px; POSITION: absolute; TOP: 267px" runat="server" Visible="False"></asp:Label>
		</form>
	</body>
</HTML>
