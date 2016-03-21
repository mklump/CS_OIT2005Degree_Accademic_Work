<%@ Page language="c#" Codebehind="SaveNestedXML.aspx.cs" AutoEventWireup="false" Inherits="Mod12CS.SaveNestedXML" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm3</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<asp:Button id="cmdSave" style="Z-INDEX: 105; LEFT: 37px; POSITION: absolute; TOP: 49px" runat="server" Text="Save as XML"></asp:Button>
			<asp:HyperLink id="lnkXML" style="Z-INDEX: 103; LEFT: 240px; POSITION: absolute; TOP: 48px" runat="server">View XML</asp:HyperLink>
			<asp:Button id="cmdSaveNested" style="Z-INDEX: 101; LEFT: 36px; POSITION: absolute; TOP: 83px" runat="server" Text="Save as Nested XML"></asp:Button>
			<asp:HyperLink id="lnkNestedXML" style="Z-INDEX: 104; LEFT: 240px; POSITION: absolute; TOP: 84px" runat="server">View Nested XML</asp:HyperLink></FORM>
	</body>
</HTML>
