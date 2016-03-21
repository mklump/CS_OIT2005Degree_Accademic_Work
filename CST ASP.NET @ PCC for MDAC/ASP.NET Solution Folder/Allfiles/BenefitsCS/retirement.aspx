<%@ Page language="c#" Inherits="BenefitsCS.retirement" CodeFile="retirement.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>retirement</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<P align="center"><STRONG><FONT size="5">Retirement</FONT></STRONG></P>
			<P align="center">
				<asp:DataGrid id="dgRetirement" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
					BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
					<FooterStyle BackColor="#CCCCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
						<asp:HyperLinkColumn Text="Prospectus" DataNavigateUrlField="Prospectus" DataNavigateUrlFormatString="prospectus.aspx?ProspID={0}"
							HeaderText="Link to prospectus"></asp:HyperLinkColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
				</asp:DataGrid></P>
		</form>
	</body>
</HTML>
