<%@ Control Language="vb" AutoEventWireup="false" Codebehind="numberbox.ascx.vb" Inherits="Mod08.numberbox" %>
<asp:textbox id="txtNum1" runat="server" />
<asp:RequiredFieldValidator id="txtNumValidator1" runat="server" controlToValidate="txtNum1" errorMessage="You must enter a value" display="dynamic"></asp:RequiredFieldValidator>
<asp:RangeValidator id="txtNumRngValidator1" runat="server" controlToValidate="txtNum1" errorMessage="Please enter a whole number between 0 and 99" type="Integer" minimumValue="0" maximumValue="99" display="dynamic"></asp:RangeValidator>
<P></P>
