<%@ Page Language="vb" Trace="false" Smartnavigation="true" AutoEventWireup="false" Codebehind="CallClassLibraries.aspx.vb" Inherits="CallClassVB.CallClassLibraries" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Button id="Button1" runat="server" Height="38px" Text="Test VB .NET Component"></asp:Button>&nbsp;
				<asp:Button id="Button2" runat="server" Height="40px" Text="Test C# Component"></asp:Button></P>
			<P>
				<br>
				<asp:Label id="Label4" runat="server" Width="455px" Height="15px" Font-Size="Large" Font-Bold="True">Using Functions and Components</asp:Label>
				<br>
			</P>
			<P>
				<TABLE cellSpacing="1" cellPadding="1" width="300" border="0">
					<TR>
						<TD><asp:Label id="Label3" runat="server" Width="99px" Height="27px">Price</asp:Label></TD>
						<TD>
							<asp:TextBox id="TextBox1" runat="server" Width="129px" Height="24px"></asp:TextBox></TD>
						<TD>
							<asp:Button id="cmdUseCSharp" runat="server" Text="C# Shipping Cost" Width="200px" Height="41px"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label5" runat="server" Width="102px" Height="24px">Shipping Cost</asp:Label></TD>
						<TD>
							<asp:Label id="Label1" runat="server" Width="133px"></asp:Label></TD>
						<TD>
							<asp:Button id="cmdUseVB" runat="server" Text="VB .NET Shipping Cost" Width="200px" Height="41px"></asp:Button></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD><asp:Button id="cmdUseWS" runat="server" Text="Web Service Shipping Cost" Width="200px" Height="41px"></asp:Button></TD>
					</TR>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>
