<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="prospectus.aspx.vb" Inherits="BenefitsVB.prospectus"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>prospectus</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body >

    <form id="Form1" method="post" runat="server">
<P>
<uc1:header id=header1 runat="server"></uc1:header></P>
<P>&nbsp;</P>
<P align=left>
<asp:Xml id=xmlProspectus runat="server" TransformSource="prospectus_style.xsl"></asp:Xml></P>
<P align=left>&nbsp;</P>
<P align=center>
<asp:HyperLink id=HyperLink1 runat="server" NavigateUrl="retirement.aspx">Back to retirement page</asp:HyperLink></P>

    </form>

  </body>
</HTML>
