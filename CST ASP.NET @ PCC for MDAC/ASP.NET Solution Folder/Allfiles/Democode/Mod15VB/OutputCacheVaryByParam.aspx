<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OutputCacheVaryByParam.aspx.vb" Inherits="Mod15VB.OutputCacheVaryByParam" %>

<%@ OutputCache Duration = "20 " VaryByParam= "Name" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OutputCacheVaryByParam</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>Param=
				<asp:Label id="lblParam" runat="server">Label</asp:Label></P>
			<P>Now=
				<asp:Label id="lblTime" runat="server">Label</asp:Label></P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
