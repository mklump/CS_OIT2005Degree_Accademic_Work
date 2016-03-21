<%@ Page Language="c#" AutoEventWireup="false" Codebehind="life.aspx.cs" Inherits="BenefitsCS.life" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>life</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:RequiredFieldValidator id="vldName" style="Z-INDEX: 115; LEFT: 295px; POSITION: absolute; TOP: 171px" runat="server" Height="20px" ErrorMessage="Name cannot be blank" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="vldBirth" style="Z-INDEX: 112; LEFT: 293px; POSITION: absolute; TOP: 218px" runat="server" ErrorMessage="Birth date cannot be blank" ControlToValidate="txtBirth">*</asp:RequiredFieldValidator>
			<asp:CompareValidator id="vldBirthType" style="Z-INDEX: 113; LEFT: 313px; POSITION: absolute; TOP: 218px" runat="server" ErrorMessage="Birth date format is invalid" ControlToValidate="txtBirth" Type="Date" Operator="DataTypeCheck">*</asp:CompareValidator>
			<uc1:header id="Header1" runat="server"></uc1:header>
			<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 167px; POSITION: absolute; TOP: 114px" runat="server" Font-Size="Large" Width="328px" Height="35px">Life Insurance Application</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 101; LEFT: 60px; POSITION: absolute; TOP: 171px" runat="server">Name:</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 102; LEFT: 30px; POSITION: absolute; TOP: 220px" runat="server">Birth Date:</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 103; LEFT: 30px; POSITION: absolute; TOP: 270px" runat="server">Coverage:</asp:Label>
			<asp:TextBox id="txtName" style="Z-INDEX: 104; LEFT: 111px; POSITION: absolute; TOP: 168px" runat="server"></asp:TextBox>
			<asp:TextBox id="txtBirth" style="Z-INDEX: 105; LEFT: 111px; POSITION: absolute; TOP: 214px" runat="server"></asp:TextBox>
			<asp:TextBox id="txtCoverage" style="Z-INDEX: 106; LEFT: 111px; POSITION: absolute; TOP: 266px" runat="server"></asp:TextBox>
			<asp:CheckBox id="chkShortTerm" style="Z-INDEX: 107; LEFT: 29px; POSITION: absolute; TOP: 315px" runat="server" Text="Short-term disability"></asp:CheckBox>
			<asp:CheckBox id="chkLongTerm" style="Z-INDEX: 108; LEFT: 190px; POSITION: absolute; TOP: 316px" runat="server" Text="Long-term disability"></asp:CheckBox>
			<asp:Button id="cmdSave" style="Z-INDEX: 109; LEFT: 31px; POSITION: absolute; TOP: 352px" runat="server" Text="Save"></asp:Button>
			<asp:Calendar id="Calendar1" style="Z-INDEX: 110; LEFT: 376px; POSITION: absolute; TOP: 175px" runat="server" Height="200px" Width="220px" Font-Size="8pt" BorderWidth="1px" BackColor="#FFFFCC" DayNameFormat="FirstLetter" ForeColor="#663399" Font-Names="Verdana" BorderColor="#FFCC66" ShowGridLines="True">
				<TodayDayStyle ForeColor="White" BackColor="#FFCC66"></TodayDayStyle>
				<SelectorStyle BackColor="#FFCC66"></SelectorStyle>
				<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
				<DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle>
				<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
				<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
			</asp:Calendar>
			<asp:Label id="Label7" style="Z-INDEX: 111; LEFT: 378px; POSITION: absolute; TOP: 153px" runat="server" Width="258px">Proof of good health appointment:</asp:Label>
			<asp:RequiredFieldValidator id="vldCoverage" style="Z-INDEX: 116; LEFT: 291px; POSITION: absolute; TOP: 269px" runat="server" ControlToValidate="txtCoverage" ErrorMessage="Coverage cannot be blank">*</asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator id="vldCoverageType" style="Z-INDEX: 114; LEFT: 313px; POSITION: absolute; TOP: 270px" runat="server" ControlToValidate="txtCoverage" ErrorMessage="Coverage must be a currency value" ValidationExpression="\d+(\.\d{2})?">*</asp:RegularExpressionValidator>
			<asp:Label id="lblMessage" style="Z-INDEX: 120; LEFT: 32px; POSITION: absolute; TOP: 394px" runat="server"></asp:Label>
			<asp:ValidationSummary id="vldSummary" style="Z-INDEX: 119; LEFT: 94px; POSITION: absolute; TOP: 359px" runat="server" HeaderText="These errors were found"></asp:ValidationSummary>
		</form>
	</body>
</HTML>
