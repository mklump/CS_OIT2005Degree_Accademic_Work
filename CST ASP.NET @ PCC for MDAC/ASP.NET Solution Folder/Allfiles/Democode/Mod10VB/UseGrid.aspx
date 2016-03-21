<%@ Page Language="vb" smartnavigation="true" CodeBehind="UseGrid.aspx.vb" AutoEventWireup="false" Inherits="Mod10VB.UseGrid" %>
<HTML>
	<body>
		<form runat="server">
			<h2>All Authors</h2>
			<ASP:DataGrid id="dgAuthors" runat="server" Width="700px" BackColor="#CCCCFF" BorderColor="Black" CellPadding="3" Font-Name="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" Font-Names="Verdana">
				<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
			</ASP:DataGrid>
			<H2>California Authors</H2>
			<ASP:DataGrid id="dgCAAuthors" runat="server" CellPadding="4" BorderColor="#3366CC" BackColor="White" BorderStyle="None" BorderWidth="1px" AllowSorting="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</ASP:DataGrid>
		</form>
	</body>
</HTML>
