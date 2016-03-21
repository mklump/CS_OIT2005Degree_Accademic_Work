<%@ Page Language="cs" CodeBehind="beforeuser.aspx.cs" AutoEventWireup="false" Inherits="Mod08CS.beforeuser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>beforeuser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM runat="server" ID="Form1">
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
