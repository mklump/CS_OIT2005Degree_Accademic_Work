<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SaveAsXML.aspx.vb" Inherits="Mod12VB.SaveAsXML" %>
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
			<asp:Button id="cmdSave" style="Z-INDEX: 101; LEFT: 26px; POSITION: absolute; TOP: 23px" runat="server" Text="Save as XML"></asp:Button><asp:Button id="cmdSchema" style="Z-INDEX: 102; LEFT: 26px; POSITION: absolute; TOP: 57px" runat="server" Text="Save Schema"></asp:Button><asp:HyperLink id="lnkXml" style="Z-INDEX: 103; LEFT: 162px; POSITION: absolute; TOP: 25px" runat="server">View XML</asp:HyperLink><asp:HyperLink id="lnkSchema" style="Z-INDEX: 104; LEFT: 162px; POSITION: absolute; TOP: 58px" runat="server">View Schema</asp:HyperLink><asp:DataGrid id="DataGrid1" style="Z-INDEX: 105; LEFT: 27px; POSITION: absolute; TOP: 99px" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
				<FooterStyle BackColor="#CCCCCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
