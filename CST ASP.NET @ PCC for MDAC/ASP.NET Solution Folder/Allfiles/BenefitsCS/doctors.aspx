<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="c#" Inherits="BenefitsCS.doctors" CodeFile="doctors.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>doctors</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 128px" runat="server"
				Font-Size="Large" Font-Bold="True">Doctors</asp:label><asp:label id="Label2" style="Z-INDEX: 102; LEFT: 264px; POSITION: absolute; TOP: 128px" runat="server">City</asp:label><asp:label id="lblSpecialties" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 176px"
				runat="server">Specialties</asp:label><asp:button id="cmdSubmit" style="Z-INDEX: 104; LEFT: 416px; POSITION: absolute; TOP: 128px"
				runat="server" Text="Submit" onclick="cmdSubmit_Click"></asp:button><uc1:header id="header1" runat="server"></uc1:header><asp:listbox id="lstSpecialties" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 199px"
				runat="server"></asp:listbox>
			<asp:DataGrid id="dgDoctors" style="Z-INDEX: 106; LEFT: 151px; POSITION: absolute; TOP: 178px"
				runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" BackColor="White"
				CellPadding="3" GridLines="Vertical" ForeColor="Black" PageSize="5" AllowPaging="True" onselectedindexchanged="dgDoctors_SelectedIndexChanged">
				<FooterStyle BackColor="#CCCCCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:DropDownList id="lstCities" style="Z-INDEX: 107; LEFT: 302px; POSITION: absolute; TOP: 128px"
				runat="server" DataTextField="city" AutoPostBack="True" onselectedindexchanged="lstCities_SelectedIndexChanged"></asp:DropDownList></form>
	</body>
</HTML>
