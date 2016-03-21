<%@ Register TagPrefix="uc1" TagName="namedate" Src="namedate.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="medical.aspx.vb" Inherits="BenefitsVB.medical" %>
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
			<!-- header hyperlinks --><uc1:header id="header1" runat="server"></uc1:header><br>
			<table>
				<!-- name and birthdate -->
				<tr>
					<td><uc1:namedate id="Namedate1" runat="server"></uc1:namedate></td>
				</tr>
				<!-- primary care physician -->
				<tr>
					<td><br>
						<asp:label id="Label1" runat="server" Height="16px" Width="144px">Primary Care Physician:</asp:label><asp:textbox id="txtDoctor" runat="server"></asp:textbox><asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="doctors.aspx">Select a doctor</asp:hyperlink></td>
				</tr>
				<!-- Save button -->
				<tr>
					<td><br>
						<asp:button id="cmdSave" runat="server" Text="Save"></asp:button><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
