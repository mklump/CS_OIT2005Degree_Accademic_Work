<%@ Page language="c#" CodeBehind="beforebinding.aspx.cs" AutoEventWireup="false" Inherits="Mod05CS.beforebinding" %>
<HTML>
	<body>
		<form runat="server">
			Profession:
			<asp:dropdownlist id="lstTitle" AutoPostBack="True" runat="server">
				<asp:listitem>Program Manager</asp:listitem>
				<asp:listitem>Tester</asp:listitem>
				<asp:listitem>User Assistance</asp:listitem>
			</asp:dropdownlist>
			<p><asp:Label ID="lblListValue" runat="server" /></p>
		</form>
	</body>
</HTML>
