<%@ Register TagPrefix="uc1" TagName="numberbox" Src="numberbox.ascx" %>
<%@ Page Language="vb" CodeBehind="afteruser.aspx.cs" AutoEventWireup="false" Inherits="Mod08CS.afteruser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>afteruser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM runat="server" ID="Form1">
			<P>Num1:
				<uc1:numberbox id="Numberbox1" runat="server"></uc1:numberbox></P>
			<P>+
			</P>
			<P>Num2:
				<uc1:numberbox id="Numberbox2" runat="server"></uc1:numberbox></P>
			<P>=
				<asp:label id="lblSum" runat="server"></asp:label></P>
			<p><asp:button id="Button1" runat="server" Text="Compute"></asp:button></p>
		</FORM>
	</body>
</HTML>
