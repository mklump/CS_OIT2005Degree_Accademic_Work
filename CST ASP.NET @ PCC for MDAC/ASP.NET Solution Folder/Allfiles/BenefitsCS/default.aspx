<%@ Page language="c#"
Inherits="BenefitsCS._default" Trace="false" CodeFile="default.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta name="vs_showGrid" content="True">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:header id="Header1" runat="server"></uc1:header></P>
			<asp:CheckBoxList id="chkListBenefits" runat="server"></asp:CheckBoxList>
			<P>
				<asp:Button id="cmdSubmit" runat="server" Text="Submit" EnableViewState="False" onclick="cmdSubmit_Click"></asp:Button></P>
			<P>
				<asp:Label id="lblSelections" runat="server" Width="486px" EnableViewState="False" Height="45px">Selected Items:</asp:Label></P>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Doctor"></asp:Label>:</p>
            <p>
                <asp:TextBox ID="txtDoctor" runat="server"></asp:TextBox>&nbsp;</p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Life Insureance"></asp:Label>&nbsp;</p>
            <p>
                <asp:TextBox ID="txtLife" runat="server"></asp:TextBox>&nbsp;</p>
		</form>
	</body>
</HTML>
