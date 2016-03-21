<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="Mod14VB.default1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtName" style="Z-INDEX: 101; LEFT: 254px; POSITION: absolute; TOP: 80px" runat="server"></asp:TextBox>
			<asp:Button id="btnSubmit" style="Z-INDEX: 102; LEFT: 192px; POSITION: absolute; TOP: 179px" runat="server" Text="Submit"></asp:Button>
			<asp:DropDownList id="lstColor" style="Z-INDEX: 103; LEFT: 260px; POSITION: absolute; TOP: 124px" runat="server" Width="86px">
				<asp:ListItem Value="Blue">Blue</asp:ListItem>
				<asp:ListItem Value="Green">Green</asp:ListItem>
				<asp:ListItem Value="Red">Red</asp:ListItem>
				<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
			</asp:DropDownList>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 58px; POSITION: absolute; TOP: 81px" runat="server">What is your name?</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 55px; POSITION: absolute; TOP: 125px" runat="server">What is your favorite color?</asp:Label>
		</form>
	</body>
</HTML>
