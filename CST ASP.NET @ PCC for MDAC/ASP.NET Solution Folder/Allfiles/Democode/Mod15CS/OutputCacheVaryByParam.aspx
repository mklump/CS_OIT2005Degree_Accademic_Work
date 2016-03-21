<%@ Page language="c#" Codebehind="OutputCacheVaryByParam.aspx.cs" AutoEventWireup="false" Inherits="Mod15CS.OutputCacheVaryByParam" %>

<%@ OutputCache Duration="20" VaryByParam="Name" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OutputCacheVaryByParam</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<P>Param=
				<asp:Label id="lblParam" runat="server">Label</asp:Label></P>
			<P>Now=
				<asp:Label id="lblTime" runat="server">Label</asp:Label></P>
			<P>&nbsp;</P>
		</FORM>
	</body>
</HTML>
