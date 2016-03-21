<%@ Page Language="c#" AutoEventWireup="false" Codebehind="ErrorHandling.aspx.cs" Inherits="Mod10CS.ErrorHandling" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtConnString" style="Z-INDEX: 101; LEFT: 177px; POSITION: absolute; TOP: 62px" runat="server" Width="465px" Height="23px"> data source=localhost;initial catalog= Pubs;integrated security=true</asp:TextBox>
			<asp:TextBox id="txtSelectString" style="Z-INDEX: 105; LEFT: 178px; POSITION: absolute; TOP: 96px" runat="server" Height="23px" Width="464px"> Select * from Authors</asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 44px; POSITION: absolute; TOP: 97px" runat="server" Height="23px" Width="166px">Select Statement</asp:Label>
			<asp:Button id="cmdOpen" style="Z-INDEX: 102; LEFT: 130px; POSITION: absolute; TOP: 151px" runat="server" Width="175px" Height="26px" Text="Get Data"></asp:Button>
			<asp:Label id="lblName" style="Z-INDEX: 103; LEFT: 45px; POSITION: absolute; TOP: 65px" runat="server" Width="122px" Height="23px">Connection String</asp:Label>
			<asp:Label id="lblErrors" style="Z-INDEX: 106; LEFT: 335px; POSITION: absolute; TOP: 145px" runat="server">Errors:</asp:Label>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 107; LEFT: 46px; POSITION: absolute; TOP: 221px" runat="server" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Vertical" ForeColor="Black">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
				<ItemStyle BackColor="#F7F7DE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
				<FooterStyle BackColor="#CCCC99"></FooterStyle>
				<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="Label2" style="Z-INDEX: 108; LEFT: 45px; POSITION: absolute; TOP: 14px" runat="server" Width="601px" ForeColor="Red" Font-Bold="True">Warning: You should never solicit SQL connection strings or select statements in this way. This is only for demonstration purposes.</asp:Label>
		</form>
	</body>
</HTML>
