<%@ Control Language="c#" AutoEventWireup="false" Codebehind="namedate.ascx.cs" Inherits="BenefitsCS.namedate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<P>
	<asp:Label id="Label2" runat="server">Name:</asp:Label>
	<asp:TextBox id="txtName" runat="server"></asp:TextBox>
	<asp:RequiredFieldValidator id="vldName" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="txtName">*</asp:RequiredFieldValidator></P>
<P>
	<asp:Label id="Label3" runat="server">Birth Date:</asp:Label>
	<asp:TextBox id="txtBirth" runat="server"></asp:TextBox>
	<asp:RequiredFieldValidator id="vldBirth" runat="server" ErrorMessage="Birth date cannot be blank" ControlToValidate="txtBirth">*</asp:RequiredFieldValidator>
	<asp:CompareValidator id="vldBirthType" runat="server" ErrorMessage="Birth date format is invalid" ControlToValidate="txtBirth" Type="Date" Operator="DataTypeCheck">*</asp:CompareValidator></P>
