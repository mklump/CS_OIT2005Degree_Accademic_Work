<%@ Page Language="vb" AutoEventWireup="false" Codebehind="doctors.aspx.vb" Inherits="BenefitsVB.doctors1" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>doctors</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 128px" runat="server" Font-Size="Large" Font-Bold="True">Doctors</asp:label><asp:label id="Label2" style="Z-INDEX: 102; LEFT: 264px; POSITION: absolute; TOP: 128px" runat="server">City</asp:label><asp:label id="lblSpecialties" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 176px" runat="server">Specialties</asp:label><asp:button id="cmdSubmit" style="Z-INDEX: 104; LEFT: 416px; POSITION: absolute; TOP: 128px" runat="server" Text="Submit"></asp:button><uc1:header id="header1" runat="server"></uc1:header><asp:listbox id="lstSpecialties" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 199px" runat="server"></asp:listbox><asp:datagrid id="dgDoctors" style="Z-INDEX: 106; LEFT: 145px; POSITION: absolute; TOP: 179px" runat="server" PageSize="5" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#999999">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:dropdownlist id="lstCities" style="Z-INDEX: 107; LEFT: 297px; POSITION: absolute; TOP: 128px" runat="server" AutoPostBack="True"></asp:dropdownlist></form>
	</body>
</HTML>
