<%@ Page Language="c#" AutoEventWireup="false" Codebehind="ValidationSummary.aspx.cs" Inherits="mod07.ValidationSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ValidationSummary</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="cmdSubmit" style="Z-INDEX: 101; LEFT: 302px; POSITION: absolute; TOP: 300px" runat="server" Text="Submit"></asp:button><asp:textbox id="TextBox1" style="Z-INDEX: 102; LEFT: 230px; POSITION: absolute; TOP: 115px" runat="server"></asp:textbox><asp:textbox id="TextBox2" style="Z-INDEX: 103; LEFT: 230px; POSITION: absolute; TOP: 215px" runat="server"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" style="Z-INDEX: 104; LEFT: 445px; POSITION: absolute; TOP: 120px" runat="server" ControlToValidate="TextBox1" ErrorMessage="This field cannot be empty!">*</asp:requiredfieldvalidator><asp:label id="lblMessage" style="Z-INDEX: 105; LEFT: 289px; POSITION: absolute; TOP: 373px" runat="server"></asp:label><asp:rangevalidator id="RangeValidator1" style="Z-INDEX: 106; LEFT: 466px; POSITION: absolute; TOP: 120px" runat="server" ControlToValidate="TextBox1" ErrorMessage="Out of range!" Type="Integer" MinimumValue="16" MaximumValue="100">*</asp:rangevalidator><asp:label id="Label1" style="Z-INDEX: 107; LEFT: 202px; POSITION: absolute; TOP: 74px" runat="server">Enter a value between 16 and 100:</asp:label><asp:label id="Label2" style="Z-INDEX: 108; LEFT: 236px; POSITION: absolute; TOP: 177px" runat="server">Enter an e-mail address:</asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" style="Z-INDEX: 109; LEFT: 466px; POSITION: absolute; TOP: 226px" runat="server" ControlToValidate="TextBox2" ErrorMessage="Invalid E-mail address!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" style="Z-INDEX: 111; LEFT: 445px; POSITION: absolute; TOP: 226px" runat="server" ControlToValidate="TextBox2" ErrorMessage="This field cannot be empty!">*</asp:RequiredFieldValidator></form>
	</body>
</HTML>
