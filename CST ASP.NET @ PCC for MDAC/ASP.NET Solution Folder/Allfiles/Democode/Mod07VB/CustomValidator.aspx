<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CustomValidator.aspx.vb" Inherits="Mod07VB.CustomValidator" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<script language=javascript>
		<!--
			// function MyClientValidation(source, arguments) { 
			//	alert("I am running on the client! ");
			//	var intValue = arguments.Value;
			//	if (intValue % 2 == 0) {
			//		arguments.IsValid = true;
			//	} else {
			//	arguments.IsValid = false;
			//	}
			// }
		//-->
		</script>
		<title>CustomValidatorDemo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="TextBox1" style="Z-INDEX: 101; LEFT: 218px; POSITION: absolute; TOP: 150px" runat="server"></asp:TextBox>
			<asp:Button id="cmdSubmit" style="Z-INDEX: 102; LEFT: 289px; POSITION: absolute; TOP: 245px" runat="server" Text="Submit"></asp:Button>
		</form>
	</body>
</HTML>
