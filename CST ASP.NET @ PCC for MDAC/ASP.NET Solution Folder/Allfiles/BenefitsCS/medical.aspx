<%@ Register TagPrefix="uc1" TagName="namedate" Src="namedate.ascx" %>
<%@ Page Language="c#" Inherits="BenefitsCS.medical" CodeFile="medical.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>medical</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<!-- header hyperlinks -->
			<uc1:header id="header1" runat="server"></uc1:header>
			<br>
			<table>
				<!-- name and birthdate -->
				<tr>
					<td>
						<uc1:namedate id="Namedate1" runat="server"></uc1:namedate>
					</td>
				</tr>
				<!-- primary care physician -->
				<tr>
					<td>
						<br>
						<asp:Label id="Label1" runat="server" Width="144px" Height="16px">Primary Care Physician:</asp:Label>
						<asp:TextBox id="txtDoctor" runat="server"></asp:TextBox>
						<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="doctors.aspx">Select a doctor</asp:HyperLink>
					</td>
				</tr>
				<!-- Save button -->
				<tr>
					<td>
						<br>
						<asp:Button id="cmdSave" runat="server" Text="Save" onclick="cmdSave_Click"></asp:Button>
						<asp:Label id="Label2" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="Invalid input, errors are:"></asp:ValidationSummary>
		</form>
	</body>
</HTML>