<%@ Page Language="vb" CodeBehind="GetConfigMainFolder.aspx.vb" AutoEventWireup="false" Inherits="Mod15VB.GetConfigMainFolder" %>
<HTML>
	<body>
		<form id="WebForm1" method="post" runat="server">
			Here is the value read from the Web.config appsettings section:
			<br>
			<br>
			<b>
				<asp:Label id="label1" runat="server" />
			</b>
			<br>
			<br>
			<asp:button id="cmdNext" Text="Next >" runat="server" />
		</form>
	</body>
</HTML>
