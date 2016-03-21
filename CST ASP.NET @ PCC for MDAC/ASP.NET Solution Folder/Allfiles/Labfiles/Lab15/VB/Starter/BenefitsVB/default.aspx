<%@ Page trace="false" Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="BenefitsVB._default"%>
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
		<form id="Form1" method="post" runat="server">
			<P>
				&nbsp;&nbsp;&nbsp;
				<uc1:header id="Header1" runat="server"></uc1:header><asp:button id="cmdSubmit" style="Z-INDEX: 101; LEFT: 53px; POSITION: absolute; TOP: 232px" runat="server" Text="Submit"></asp:button><asp:label id="lblSelections" style="Z-INDEX: 102; LEFT: 35px; POSITION: absolute; TOP: 273px" runat="server" Width="96px">Selected Items:</asp:label><asp:checkboxlist id="chkList" style="Z-INDEX: 103; LEFT: 36px; POSITION: absolute; TOP: 136px" runat="server"></asp:checkboxlist></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>
				<asp:Label id="Label1" runat="server">Doctor</asp:Label></P>
			<P>
				<asp:TextBox id="txtDoctor" runat="server" Width="450px"></asp:TextBox></P>
			<P>
				<asp:Label id="Label2" runat="server">Life Insurance</asp:Label></P>
			<P>
				<asp:TextBox id="txtLife" runat="server" Width="450px"></asp:TextBox></P>
			<P>&nbsp;&nbsp;&nbsp;</P>
		</form>
	</body>
</HTML>
