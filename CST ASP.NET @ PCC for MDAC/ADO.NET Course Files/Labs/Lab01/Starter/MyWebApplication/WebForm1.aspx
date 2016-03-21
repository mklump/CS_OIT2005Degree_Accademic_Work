<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="MyWebApplication.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnQuery" style="Z-INDEX: 101; LEFT: 30px; POSITION: absolute; TOP: 31px" runat="server"
				Text="Query" Width="164px" Height="30px"></asp:Button>
			<asp:DataGrid id="dgResult" style="Z-INDEX: 102; LEFT: 29px; POSITION: absolute; TOP: 77px" runat="server"></asp:DataGrid>
		</form>
	</body>
</HTML>
