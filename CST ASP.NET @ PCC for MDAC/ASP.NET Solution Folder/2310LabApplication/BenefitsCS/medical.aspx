<%@ Page Language="c#" AutoEventWireup="false" CodeFile="medical.aspx.cs" Inherits="BenefitsCS.medical" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>medical</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<!-- header hyperlinks -->
			<uc1:header id="header1" runat="server"></uc1:header>
			<br>
			<table>
			<!-- name and birthdate -->
			<tr><td>

			</td></tr>
			<!-- primary care physician -->
			<tr><td>
				<br>
				<asp:Label id="Label1" runat="server" Width="144px" Height="16px">Primary Care Physician:</asp:Label>
				<asp:TextBox id="txtDoctor" runat="server"></asp:TextBox>
				<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="doctors.aspx">Select a doctor</asp:HyperLink>
			</td></tr>
			<!-- Save button -->
			<tr><td>
				<br>
				<asp:Button id="cmdSave" runat="server" Text="Save"></asp:Button>
				<asp:Label id="Label2" runat="server"></asp:Label>
			</td></tr>
			</table>
		</form>
	</body>
</HTML>
