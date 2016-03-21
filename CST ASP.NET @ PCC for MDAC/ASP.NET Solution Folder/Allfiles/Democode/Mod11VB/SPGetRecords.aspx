<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SPGetRecords.aspx.vb" Inherits="Mod11vb.SPGetRecords" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P><STRONG><FONT size="4">10 Most Expensive Products</FONT></STRONG></P>
			<P><asp:datagrid id="dgProducts" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#CC9966" BackColor="White" CellPadding="4">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
				</asp:datagrid></P>
		</form>
	</body>
</HTML>
