<%@ Page Language="vb" AutoEventWireup="false" Codebehind="retirement.aspx.vb" Inherits="BenefitsVB.retirement"%>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>retirement</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:header id="header1" runat="server"></uc1:header></P>
			<P align="center"><STRONG><FONT size="5">Retirement</FONT></STRONG></P>
			<P align="center">
				<asp:DataGrid id="dgRetirement" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
					<FooterStyle BackColor="#CCCCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
						<asp:HyperLinkColumn Text="Prospectus" DataNavigateUrlField="Prospectus" DataNavigateUrlFormatString="prospectus.aspx?ProspID={0}" HeaderText="Link to prospectus"></asp:HyperLinkColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
				</asp:DataGrid></P>
			<P align="center">
				<asp:Label id="Label1" runat="server">This page has been visited </asp:Label>&nbsp;
				<asp:TextBox id="txtVisits" runat="server" Width="35px"></asp:TextBox>&nbsp;
				<asp:Label id="Label2" runat="server">times.</asp:Label></P>
		</form>
	</body>
</HTML>
