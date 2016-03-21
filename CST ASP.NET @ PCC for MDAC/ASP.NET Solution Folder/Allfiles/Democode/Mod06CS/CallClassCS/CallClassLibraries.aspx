<%@ Page language="c#" Codebehind="CallClassLibraries.aspx.cs" AutoEventWireup="false" Inherits="CallClassCS.CallClassLibraries" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CallClassLibraries</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<DIV style="LEFT: 8px; WIDTH: 476px; POSITION: absolute; TOP: 8px; HEIGHT: 313px" ms_positioning="FlowLayout">
			<FORM id="Form1" method="post" runat="server">
				<P>
					<asp:Button id="Button1" runat="server" Height="38px" Text="Test VB .NET Component"></asp:Button>&nbsp;
					<asp:Button id="Button2" runat="server" Height="40px" Text="Test C# Component"></asp:Button></P>
				<P><BR>
					<asp:Label id="Label4" runat="server" Height="15px" Width="455px" Font-Size="Large" Font-Bold="True">Using Functions and Components</asp:Label><BR>
				</P>
				<P>
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
						<TR>
							<TD>
								<asp:Label id="Label3" runat="server" Height="27px" Width="99px">Price</asp:Label></TD>
							<TD>
								<asp:TextBox id="TextBox1" runat="server" Height="24px" Width="129px"></asp:TextBox></TD>
							<TD>
								<asp:Button id="cmdUseCSharp" runat="server" Height="41px" Text="C# Shipping Cost" Width="200px"></asp:Button></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label5" runat="server" Height="24px" Width="102px">Shipping Cost</asp:Label></TD>
							<TD>
								<asp:Label id="Label1" runat="server" Width="133px"></asp:Label></TD>
							<TD>
								<asp:Button id="cmdUseVB" runat="server" Height="41px" Text="VB .NET Shipping Cost" Width="200px"></asp:Button></TD>
						</TR>
						<TR>
							<TD></TD>
							<TD></TD>
							<TD>
								<asp:Button id="cmdUseWS" runat="server" Height="41px" Text="Web Service Shipping Cost" Width="200px"></asp:Button></TD>
						</TR>
					</TABLE>
				</P>
			</FORM>
		</DIV>
	</body>
</HTML>
