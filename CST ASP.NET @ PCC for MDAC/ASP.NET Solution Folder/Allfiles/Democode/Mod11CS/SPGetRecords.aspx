<%@ Page Language="c#" AutoEventWireup="false" Codebehind="SPGetRecords.aspx.cs" Inherits="Mod11CS.SPGetRecords" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
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
