<%@ Page Language="vb" CodeBehind="beforeuser.aspx.vb" AutoEventWireup="false" Inherits="Mod08.beforeuser" %>
<HTML>
	<body>
		<FORM runat="server">
			<p>Num1:
				<asp:textbox id="txtNum1" runat="server" />
				<asp:RequiredFieldValidator id="txtNumValidator1" runat="server" controlToValidate="txtNum1" errorMessage="You must enter a value" display="dynamic"></asp:RequiredFieldValidator>
				<asp:RangeValidator id="txtNumRngValidator1" runat="server" controlToValidate="txtNum1" errorMessage="Please enter a whole number between 0 and 99" type="Integer" minimumValue="0" maximumValue="99" display="dynamic"></asp:RangeValidator>
			</p>
			<p>+</p>
			<P>Num2:
				<asp:textbox id="txtNum2" runat="server" />
				<asp:RequiredFieldValidator id="txtNumValidator2" runat="server" controlToValidate="txtNum2" errorMessage="You must enter a value" display="dynamic"></asp:RequiredFieldValidator>
				<asp:RangeValidator id="txtNumRngValidator2" runat="server" controlToValidate="txtNum2" errorMessage="Please enter a whole number between 0 and 99" type="Integer" minimumValue="0" maximumValue="99" display="dynamic"></asp:RangeValidator>
			</P>
			<p>=
				<asp:label id="lblSum" runat="server" /></p>
			<p><asp:Button Text="Compute" runat="server" id="Button1" /></p>
		</FORM>
	</body>
</HTML>
