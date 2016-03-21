<%@ Page Language="c#" AutoEventWireup="false" Codebehind="register.aspx.cs" Inherits="BenefitsCS.register" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>register</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<P><STRONG><FONT size="6">Registration</FONT></STRONG></P>
			<P>Email:</P>
			<P><asp:textbox id="txtEmail" runat="server"></asp:textbox><asp:requiredfieldvalidator id="vldEmailReq" runat="server" ErrorMessage="Email cannot be blank" Display="Dynamic" ControlToValidate="txtEmail">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="vldEmailExpr" runat="server" ErrorMessage="Invalid Email address" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail">*</asp:regularexpressionvalidator></P>
			<P>Password:</P>
			<P><asp:textbox id="txtPassword" runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="vldPasswordReq" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="txtPassword">*</asp:requiredfieldvalidator></P>
			<P>Confirm Password:</P>
			<P><asp:textbox id="txtConfirmPassword" runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="vldConfirmPasswordReq" runat="server" ErrorMessage="Confirm Password cannot be blank" Display="Dynamic" ControlToValidate="txtConfirmPassword">*</asp:requiredfieldvalidator><asp:comparevalidator id="vldConfirmPasswordComp" runat="server" ErrorMessage="Password fields do not match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword">*</asp:comparevalidator></P>
			<P><asp:button id="cmdValidation" runat="server" Text="Submit"></asp:button></P>
			<P>
				<asp:ValidationSummary id="vldSummary" runat="server" HeaderText="These errors were found:"></asp:ValidationSummary></P>
			<P>
				<asp:Label id="lblInfo" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
