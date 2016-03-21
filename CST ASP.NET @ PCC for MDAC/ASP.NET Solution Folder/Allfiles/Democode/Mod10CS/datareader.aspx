<%@ Page Language="c#" CodeBehind="datareader.aspx.cs" AutoEventWireup="false" Inherits="Mod10CS.datareader" %>
<HTML>
	<body>
		<form runat="server">
			<P>Author Names (bound):
			</P>
			<P>
				<asp:ListBox id="lstBoundNames" runat="server" Width="129px" Height="123px"></asp:ListBox></P>
			<P>Author Names (built):
			</P>
			<P><asp:listbox id="lstBuiltNames" runat="server" Width="127px" Height="141px"></asp:listbox></P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
