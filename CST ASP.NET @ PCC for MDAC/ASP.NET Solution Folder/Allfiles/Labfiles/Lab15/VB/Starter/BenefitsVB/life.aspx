<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="life.aspx.vb" Inherits="BenefitsVB.life" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>life</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<P><asp:calendar id="Calendar1" style="Z-INDEX: 101; LEFT: 287px; POSITION: absolute; TOP: 265px" runat="server" CellPadding="1" BorderColor="#3366CC" Font-Names="Verdana" Font-Size="8pt" Height="200px" ForeColor="#003399" DayNameFormat="FirstLetter" Width="220px" BackColor="White" BorderWidth="1px">
					<TodayDayStyle ForeColor="White" BackColor="#99CCCC"></TodayDayStyle>
					<SelectorStyle ForeColor="#336666" BackColor="#99CCCC"></SelectorStyle>
					<NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>
					<DayHeaderStyle Height="1px" ForeColor="#336666" BackColor="#99CCCC"></DayHeaderStyle>
					<SelectedDayStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedDayStyle>
					<TitleStyle Font-Size="10pt" Font-Bold="True" Height="25px" BorderWidth="1px" ForeColor="#CCCCFF" BorderStyle="Solid" BorderColor="#3366CC" BackColor="#003399"></TitleStyle>
					<WeekendDayStyle BackColor="#CCCCFF"></WeekendDayStyle>
					<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
				</asp:calendar><asp:label id="Label5" style="Z-INDEX: 109; LEFT: 43px; POSITION: absolute; TOP: 249px" runat="server">Name</asp:label><asp:label id="Label4" style="Z-INDEX: 108; LEFT: 26px; POSITION: absolute; TOP: 287px" runat="server">Birthdate</asp:label><asp:label id="Label3" style="Z-INDEX: 107; LEFT: 20px; POSITION: absolute; TOP: 328px" runat="server">Coverage</asp:label><asp:label id="Label2" style="Z-INDEX: 106; LEFT: 294px; POSITION: absolute; TOP: 238px" runat="server">Proof of good health appointment:</asp:label><asp:textbox id="txtName" style="Z-INDEX: 102; LEFT: 96px; POSITION: absolute; TOP: 251px" runat="server"></asp:textbox><asp:textbox id="txtBirth" style="Z-INDEX: 103; LEFT: 96px; POSITION: absolute; TOP: 288px" runat="server"></asp:textbox><asp:textbox id="txtCoverage" style="Z-INDEX: 104; LEFT: 94px; POSITION: absolute; TOP: 327px" runat="server"></asp:textbox><asp:label id="Label1" style="Z-INDEX: 105; LEFT: 133px; POSITION: absolute; TOP: 177px" runat="server" Font-Size="Large">Life Insurance Application</asp:label><asp:checkbox id="chkShortTerm" style="Z-INDEX: 110; LEFT: 35px; POSITION: absolute; TOP: 379px" runat="server" Text="Short-term disability"></asp:checkbox><asp:checkbox id="chkLongTerm" style="Z-INDEX: 111; LEFT: 33px; POSITION: absolute; TOP: 413px" runat="server" Text="Long-term disability"></asp:checkbox><asp:button id="cmdSave" style="Z-INDEX: 112; LEFT: 231px; POSITION: absolute; TOP: 509px" runat="server" Text="Save"></asp:button><uc1:header id="Header1" runat="server"></uc1:header></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P><asp:comparevalidator id="CompareValidator1" style="Z-INDEX: 118; LEFT: 269px; POSITION: absolute; TOP: 289px" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txtBirth" ErrorMessage="The birth date is in an invalid format.">*</asp:comparevalidator></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P><asp:requiredfieldvalidator id="RequiredFieldValidator1" style="Z-INDEX: 113; LEFT: 256px; POSITION: absolute; TOP: 255px" runat="server" ControlToValidate="txtName" ErrorMessage="Name cannot be blank">*</asp:requiredfieldvalidator></P>
			<P>&nbsp;</P>
			<P><asp:requiredfieldvalidator id="RequiredFieldValidator2" style="Z-INDEX: 114; LEFT: 256px; POSITION: absolute; TOP: 289px" runat="server" ControlToValidate="txtBirth" ErrorMessage="Birth date cannot be blank">*</asp:requiredfieldvalidator></P>
			<P>&nbsp;</P>
			<P><asp:requiredfieldvalidator id="RequiredFieldValidator3" style="Z-INDEX: 115; LEFT: 256px; POSITION: absolute; TOP: 328px" runat="server" ControlToValidate="txtCoverage" ErrorMessage="Coverage cannot be blank">*</asp:requiredfieldvalidator></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 116; LEFT: 319px; POSITION: absolute; TOP: 503px" runat="server" HeaderText="The follow errors occurred:"></asp:validationsummary><asp:label id="lblMessage" style="Z-INDEX: 117; LEFT: 74px; POSITION: absolute; TOP: 489px" runat="server"></asp:label><asp:regularexpressionvalidator id="vldCoverageType" style="Z-INDEX: 119; LEFT: 269px; POSITION: absolute; TOP: 328px" runat="server" ControlToValidate="txtCoverage" ErrorMessage="Coverage must be a currency value." ValidationExpression="\d+(\.\d{2})?">*</asp:regularexpressionvalidator></P>
		</form>
	</body>
</HTML>
