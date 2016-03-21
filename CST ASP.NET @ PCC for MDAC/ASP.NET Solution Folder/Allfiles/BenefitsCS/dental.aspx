<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page language="c#" Inherits="BenefitsCS.dental" CodeFile="dental.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>dental</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<asp:TextBox id="txtPostalCode" style="Z-INDEX: 102; LEFT: 339px; POSITION: absolute; TOP: 191px"
				runat="server" Width="109px" ontextchanged="txtPostalCode_TextChanged"></asp:TextBox>
			<asp:Button id="cmdSubmit" style="Z-INDEX: 103; LEFT: 470px; POSITION: absolute; TOP: 190px"
				runat="server" Text="Submit" onclick="cmdSubmit_Click"></asp:Button>
			<asp:Button id="cmdGetAllDentists" style="Z-INDEX: 104; LEFT: 393px; POSITION: absolute; TOP: 157px"
				runat="server" Text="Get All Dentists" onclick="cmdGetAllDentists_Click"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 243px; POSITION: absolute; TOP: 191px" runat="server">Postal Code:</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 106; LEFT: 355px; POSITION: absolute; TOP: 117px" runat="server"
				Font-Bold="True" Font-Size="Large">Dentists</asp:Label>
			<uc1:header id="Header1" runat="server"></uc1:header>
			<asp:DataGrid id="dgDentists" style="Z-INDEX: 107; LEFT: 43px; POSITION: absolute; TOP: 261px"
				runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" BackColor="White"
				CellPadding="3" GridLines="Vertical" ForeColor="Black" onselectedindexchanged="dgDentists_SelectedIndexChanged">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
				<FooterStyle BackColor="#CCCCCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
			</asp:DataGrid></FORM>
	</body>
</HTML>
