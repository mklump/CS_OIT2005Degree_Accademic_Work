<%@ Control Language="c#" AutoEventWireup="false" Codebehind="numberbox.ascx.cs" Inherits="Mod08CS.numberbox" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:textbox id="txtNum1" runat="server"></asp:textbox>
<asp:RequiredFieldValidator id="txtNumValidator1" runat="server" controlToValidate="txtNum1" errorMessage="You must enter a value" display="dynamic"></asp:RequiredFieldValidator>
<asp:RangeValidator id="txtNumRngValidator1" runat="server" controlToValidate="txtNum1" errorMessage="Please enter a whole number between 0 and 99" display="dynamic" type="Integer" minimumValue="0" maximumValue="99"></asp:RangeValidator>
