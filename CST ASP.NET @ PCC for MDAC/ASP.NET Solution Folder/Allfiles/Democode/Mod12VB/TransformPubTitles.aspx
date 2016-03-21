<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TransformPubTitles.aspx.vb" Inherits="Mod12VB.TransformPubTitles" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CustomerOrders</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P><asp:button id="cmdTransform" runat="server" Text="Transform Data"></asp:button></P>
			<P><asp:hyperlink id="HyperLink1" runat="server"> View Transform Output</asp:hyperlink></P>
			<table>
				<TBODY>
					<tr>
						<td><B>Publishers DataTable</B></td>
						<td><B>Titles DataTable</B></td>
					</tr>
					<tr>
						<td><asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid></td>
						<td><asp:DataGrid id="DataGrid2" runat="server"></asp:DataGrid></td>
					</tr>
				</TBODY>
			</table>
		</form>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
