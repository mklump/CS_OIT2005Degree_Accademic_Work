<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="doctors.aspx.vb" Inherits="BenefitsVB.doctors1" %>
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
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 128px" runat="server" Font-Bold="True" Font-Size="Large">Doctors</asp:label>
			<asp:label id="Label2" style="Z-INDEX: 103; LEFT: 264px; POSITION: absolute; TOP: 128px" runat="server">City</asp:label>
			<asp:Label id="lblSpecialties" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 176px" runat="server">Specialties</asp:Label>
			<asp:Button id="cmdSubmit" style="Z-INDEX: 107; LEFT: 416px; POSITION: absolute; TOP: 128px" runat="server" Text="Submit"></asp:Button>
			<uc1:header id="header1" runat="server"></uc1:header>
			<asp:ListBox id="lstSpecialties" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 199px" runat="server"></asp:ListBox>
			
		</form>
	</body>
</HTML>
