<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="MyWebApplication.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnQuery" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 21px" runat="server"
				Text="Query"></asp:Button>
			<asp:DataGrid id="dgResult" style="Z-INDEX: 102; LEFT: 20px; POSITION: absolute; TOP: 63px" runat="server"
				Width="340px" Height="133px"></asp:DataGrid>
		</form>
	</body>
</HTML>
