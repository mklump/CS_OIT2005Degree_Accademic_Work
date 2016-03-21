<%@ Page language="c#" Codebehind="ErrorHandling.aspx.cs" AutoEventWireup="false" Inherits="ASPNetCS.WebForm1" %>
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
			<asp:TextBox id="txtInfoMessages" style="Z-INDEX: 106; LEFT: 128px; POSITION: absolute; TOP: 272px"
				runat="server" TextMode="MultiLine" Height="80px" Width="352px"></asp:TextBox>
			<DIV style="DISPLAY: inline; Z-INDEX: 107; LEFT: 128px; WIDTH: 200px; POSITION: absolute; TOP: 248px; HEIGHT: 19px"
				ms_positioning="FlowLayout">Info Messages:</DIV>
			<asp:TextBox id="txtErrors" style="Z-INDEX: 108; LEFT: 128px; POSITION: absolute; TOP: 144px"
				runat="server" TextMode="MultiLine" Height="80px" Width="352px"></asp:TextBox>
			<DIV style="DISPLAY: inline; Z-INDEX: 109; LEFT: 128px; WIDTH: 200px; POSITION: absolute; TOP: 120px; HEIGHT: 19px"
				ms_positioning="FlowLayout">Errors:</DIV>
			<asp:Button id="btnOpenConnection" style="Z-INDEX: 110; LEFT: 128px; POSITION: absolute; TOP: 64px"
				runat="server" Width="128px" Text="Open Connection"></asp:Button>
		</form>
	</body>
</HTML>
