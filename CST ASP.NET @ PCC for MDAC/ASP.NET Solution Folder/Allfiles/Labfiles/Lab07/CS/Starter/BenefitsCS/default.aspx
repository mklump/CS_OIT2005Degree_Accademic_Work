<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="c#" AutoEventWireup="false" Codebehind="default.aspx.cs" Inherits="BenefitsCS._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<uc1:header id="header1" runat="server"></uc1:header>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:CheckBoxList id="chkListBenefits" runat="server"></asp:CheckBoxList></P>
			<P><asp:Button id="cmdSubmit" runat="server" Text="Submit"></asp:Button>&nbsp;<asp:Label id="lblSelections" runat="server">Selected items:</asp:Label></P>
		</form>
	</body>
</HTML>
