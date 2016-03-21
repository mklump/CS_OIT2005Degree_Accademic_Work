<%@ Page language="c#" Codebehind="DisplayXml.aspx.cs" AutoEventWireup="false" Inherits="Mod12CS.DisplayXml" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="xml" method="post" runat="server">
			<P>
				<asp:Label id="Label1" runat="server">XML File </asp:Label>
				<asp:DropDownList id="lstFileName" runat="server">
					<asp:ListItem Value="Books.xml">Books.xml</asp:ListItem>
					<asp:ListItem Value="Employees.xml">Employees.xml</asp:ListItem>
				</asp:DropDownList></P>
			<P>
				<asp:Button id="cmdLoad" runat="server" DESIGNTIMEDRAGDROP="15" Text="Load"></asp:Button></P>
			<P>
				<asp:DataGrid id="dgBooks" runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
					<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid></P>
		</FORM>
	</body>
</HTML>
