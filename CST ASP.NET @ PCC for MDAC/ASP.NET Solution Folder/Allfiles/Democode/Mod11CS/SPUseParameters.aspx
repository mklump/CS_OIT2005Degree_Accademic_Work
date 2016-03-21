<%@ Page Language="c#" AutoEventWireup="false" Codebehind="SPUseParameters.aspx.cs" Inherits="Mod11CS.SPUseParameters" %>
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
			<P>Beginning Date:
				<asp:textbox id="txtStartDate" runat="server" Text="14">1/1/1996</asp:textbox></P>
			<P>Ending Date:
				<asp:textbox id="txtEndDate" runat="server" Text="14">8/1/1996</asp:textbox>&nbsp;</P>
			<P>
				<asp:button id="cmdSales" runat="server" text="Get Sales by Year"></asp:button></P>
			<H2>
				<asp:datagrid id="dgSales" runat="server" BorderStyle="Solid" BorderWidth="3px" BorderColor="#999999" BackColor="#CCCCCC" CellPadding="4" ForeColor="Black" CellSpacing="2">
					<FooterStyle BackColor="#CCCCCC"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="#CCCCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
					<ItemStyle BackColor="White"></ItemStyle>
				</asp:datagrid><BR>
			</H2>
		</form>
	</body>
</HTML>
