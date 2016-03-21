<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="BenefitsVB._default" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>default</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:header id="Header1" runat="server"></uc1:header></P>
			<P>
				<asp:CheckBoxList id="chkListBenefits" runat="server">
					<asp:ListItem Value="First Item">First Item</asp:ListItem>
					<asp:ListItem Value="Second Item">Second Item</asp:ListItem>
					<asp:ListItem Value="Third Item">Third Item</asp:ListItem>
				</asp:CheckBoxList></P>
			<P>
				<asp:Button id="cmdSubmit" runat="server" Text="Submit"></asp:Button></P>
			<P>
				<asp:Label id="lblSelections" runat="server">Selected Items:</asp:Label></P>
		</form>
	</body>
</HTML>
