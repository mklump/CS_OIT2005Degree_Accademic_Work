<%@ Page language="c#" CodeBehind="binding.aspx.cs" AutoEventWireup="false" Inherits="Mod05CS.binding" %>
<HTML>
	<body>
		<form runat="server">
			Profession:
			<asp:dropdownlist id="lstTitle" AutoPostBack="True" runat="server">
				<asp:listitem>Program Manager</asp:listitem>
				<asp:listitem>Tester</asp:listitem>
				<asp:listitem>User Assistance</asp:listitem>
			</asp:dropdownlist>
			<p><asp:Label ID="lblListValue" Text="<%# lstTitle.SelectedItem.Text %>" runat="server" /></p>
		</form>
	</body>
</HTML>
