<%@ Page language="c#" Codebehind="TransformPubTitles.aspx.cs" AutoEventWireup="false" Inherits="Mod12CS.TransformPubTitles" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm5</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<P>
				<asp:button id="cmdTransform" runat="server" Text="Transform Data"></asp:button></P>
			<P>
				<asp:hyperlink id="HyperLink1" runat="server"> View Transform Output</asp:hyperlink></P>
			<TABLE id="Table1">
				<TR>
					<TD><B>Publishers DataTable</B></TD>
					<TD><B>Titles DataTable</B></TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid></TD>
					<TD>
						<asp:DataGrid id="DataGrid2" runat="server"></asp:DataGrid></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
