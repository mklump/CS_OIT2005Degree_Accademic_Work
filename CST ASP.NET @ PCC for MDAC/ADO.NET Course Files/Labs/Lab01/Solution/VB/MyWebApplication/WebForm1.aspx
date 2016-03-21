<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="MyWebApplication.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnQuery" style="Z-INDEX: 101; LEFT: 19px; POSITION: absolute; TOP: 23px" runat="server" Text="Query" Width="80px" Height="26px"></asp:Button>
			<asp:DataGrid id="dgResult" style="Z-INDEX: 102; LEFT: 19px; POSITION: absolute; TOP: 63px" runat="server" Width="378px" Height="145px"></asp:DataGrid>
		</form>
	</body>
</HTML>
