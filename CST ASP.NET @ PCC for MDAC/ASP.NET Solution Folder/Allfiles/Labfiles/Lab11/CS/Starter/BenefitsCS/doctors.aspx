<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="c#" AutoEventWireup="false" Codebehind="doctors.aspx.cs" Inherits="BenefitsCS.doctors" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>doctors</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 128px" runat="server" Font-Bold="True" Font-Size="Large">Doctors</asp:label>
			<asp:label id="Label2" style="Z-INDEX: 102; LEFT: 264px; POSITION: absolute; TOP: 128px" runat="server">City</asp:label>
			<asp:Label id="lblSpecialties" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 176px" runat="server">Specialties</asp:Label>
			<asp:Button id="cmdSubmit" style="Z-INDEX: 104; LEFT: 416px; POSITION: absolute; TOP: 128px" runat="server" Text="Submit"></asp:Button>
			<uc1:header id="header1" runat="server"></uc1:header>
			<asp:DataGrid id="dgDoctors" style="Z-INDEX: 105; LEFT: 144px; POSITION: absolute; TOP: 167px" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black" PageSize="5" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
				<FooterStyle BackColor="#CCCCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:DropDownList id=lstCities style="Z-INDEX: 106; LEFT: 301px; POSITION: absolute; TOP: 127px" runat="server" DataSource="<%# dsDoctors1 %>" DataTextField="city" AutoPostBack="True">
			</asp:DropDownList>
			<asp:ListBox id="lstSpecialties" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 199px" runat="server"></asp:ListBox></form>
	</body>
</HTML>
