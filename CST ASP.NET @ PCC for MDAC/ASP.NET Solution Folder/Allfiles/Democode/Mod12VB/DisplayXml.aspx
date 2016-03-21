<%@ Page Language="vb" CodeBehind="DisplayXml.aspx.vb" AutoEventWireup="false" Inherits="Mod12VB.DisplayXml" %>
<HTML>
	<body>
		<form id="xml" method="post" runat="server">
			<P><asp:Label id="Label1" runat="server">XML File </asp:Label>
				<asp:DropDownList id="lstFileName" runat="server">
					<asp:ListItem Value="Books.xml">Books.xml</asp:ListItem>
					<asp:ListItem Value="Employees.xml">Employees.xml</asp:ListItem>
				</asp:DropDownList></P>
			<P><asp:Button id="cmdLoad" runat="server" DESIGNTIMEDRAGDROP="15" Text="Load"></asp:Button></P>
			<P><asp:DataGrid id="dgBooks" runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
					<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid></P>
		</form>
	</body>
</HTML>
