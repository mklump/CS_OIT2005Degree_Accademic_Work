<%@ Page Language="vb" CodeBehind="afteruser.aspx.vb" AutoEventWireup="false" Inherits="Mod08.afteruser" %>
<%@ Register TagPrefix="uc1" TagName="numberbox" Src="numberbox.ascx" %>
<HTML>
	<body>
		<FORM runat="server">
			<P>Num1:
				<uc1:numberbox id="Numberbox1" runat="server"></uc1:numberbox></P>
			<P>+
			</P>
			<P>Num2:
				<uc1:numberbox id="Numberbox2" runat="server"></uc1:numberbox></P>
			<P>=
				<asp:label id="lblSum" runat="server"></asp:label></P>
			<p><asp:button id="Button1" runat="server" Text="Compute"></asp:button></p>
		</FORM>
	</body>
</HTML>
