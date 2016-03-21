<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page language="c#" Codebehind="doctors.aspx.cs" AutoEventWireup="false" Inherits="BenefitsCS.doctors" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>doctors</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="doctors" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 108; LEFT: 144px; POSITION: absolute; TOP: 125px" runat="server" Font-Bold="True" Font-Size="Large">Doctors</asp:label>
			<asp:label id="Label2" style="Z-INDEX: 102; LEFT: 264px; POSITION: absolute; TOP: 128px" runat="server">City</asp:label>
			<asp:Label id="lblSpecialties" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 176px" runat="server">Specialties</asp:Label>
			<asp:Button id="cmdSubmit" style="Z-INDEX: 104; LEFT: 416px; POSITION: absolute; TOP: 128px" runat="server" Text="Submit"></asp:Button>
			<asp:ListBox id="lstSpecialties" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 199px" runat="server"></asp:ListBox>
			<asp:DataGrid id="dgDoctors" style="Z-INDEX: 106; LEFT: 145px; POSITION: absolute; TOP: 179px" runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" PageSize="5" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:DropDownList id="lstCities" style="Z-INDEX: 107; LEFT: 297px; POSITION: absolute; TOP: 128px" runat="server" AutoPostBack="True"></asp:DropDownList>
			<uc1:header id="Header1" runat="server"></uc1:header>
		</form>
	</body>
</HTML>
