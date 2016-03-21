<%@ Control Language="c#" Inherits="BenefitsCS.namedate" CodeFile="namedate.ascx.cs" %>
<P>
	<asp:Label id="Label3" runat="server">Name:</asp:Label>
	<asp:TextBox id="txtName" tabIndex="1" runat="server"></asp:TextBox>
	<asp:RequiredFieldValidator id="vldName" runat="server" ControlToValidate="txtName" ErrorMessage="Name cannot be blank">*</asp:RequiredFieldValidator></P>
<P>
	<asp:Label id="Label4" runat="server">Birth Date:</asp:Label>
	<asp:TextBox id="txtBirth" tabIndex="2" runat="server"></asp:TextBox>
	<asp:RequiredFieldValidator id="vldBirth" runat="server" ControlToValidate="txtBirth" ErrorMessage="Brith date cannot be blank">*</asp:RequiredFieldValidator>
	<asp:CompareValidator id="vldBirthType" runat="server" ControlToValidate="txtBirth" ErrorMessage="Birth date format is invalid"
		Type="Date" Operator="DataTypeCheck">*</asp:CompareValidator></P>
