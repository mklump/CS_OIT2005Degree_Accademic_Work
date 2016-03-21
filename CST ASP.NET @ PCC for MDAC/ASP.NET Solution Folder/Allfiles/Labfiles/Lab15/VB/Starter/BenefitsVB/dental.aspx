<%@ Page Language="vb" AutoEventWireup="false" Codebehind="dental.aspx.vb" Inherits="BenefitsVB.dental"%>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>dental</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<asp:DataGrid id="dgDentists" style="Z-INDEX: 101; LEFT: 37px; POSITION: absolute; TOP: 252px" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
				<FooterStyle BackColor="#CCCCCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
			</asp:DataGrid>
			<asp:TextBox id="txtPostalCode" style="Z-INDEX: 102; LEFT: 339px; POSITION: absolute; TOP: 191px" runat="server" Width="109px"></asp:TextBox>
			<asp:Button id="cmdSubmit" style="Z-INDEX: 103; LEFT: 470px; POSITION: absolute; TOP: 190px" runat="server" Text="Submit"></asp:Button>
			<asp:Button id="cmdGetAllDentists" style="Z-INDEX: 104; LEFT: 393px; POSITION: absolute; TOP: 157px" runat="server" Text="Get All Dentists"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 243px; POSITION: absolute; TOP: 191px" runat="server">Postal Code:</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 106; LEFT: 355px; POSITION: absolute; TOP: 117px" runat="server" Font-Bold="True" Font-Size="Large">Dentists</asp:Label></form>
	</body>
</HTML>
