<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UseXmlDataDoc.aspx.vb" Inherits="Mod12VB.UseXmlDataDoc" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>UseXmlDataDoc</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body >

    <form id="Form1" method="post" runat="server">
<P><asp:TextBox id=txtRow runat="server" Width="79px"></asp:TextBox><asp:Button id=cmdReadXML runat="server" Text="Get Row As XML"></asp:Button></P>
<P><asp:TextBox id=txtOutput runat="server" Width="580px" Rows="3" Height="24px"></asp:TextBox></P>
<P><asp:DataGrid id=DataGrid1 runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C">
</SelectedItemStyle>

<AlternatingItemStyle BackColor="#DCDCDC">
</AlternatingItemStyle>

<ItemStyle ForeColor="Black" BackColor="#EEEEEE">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084">
</HeaderStyle>

<FooterStyle ForeColor="Black" BackColor="#CCCCCC">
</FooterStyle>

<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages">
</PagerStyle>
</asp:DataGrid></P>

    </form>

  </body>
</HTML>
