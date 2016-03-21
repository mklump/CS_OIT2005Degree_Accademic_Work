<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="BenefitsVB._default" trace="true"%>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>default</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<uc1:header id="header1" runat="server"></uc1:header>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:CheckBoxList id="chkListBenefits" runat="server"></asp:CheckBoxList></P>
			<P><asp:Button id="cmdSubmit" runat="server" Text="Submit"></asp:Button>&nbsp;<asp:Label id="lblSelections" runat="server">Selected items:</asp:Label></P>
		</form>
	</body>
</HTML>
