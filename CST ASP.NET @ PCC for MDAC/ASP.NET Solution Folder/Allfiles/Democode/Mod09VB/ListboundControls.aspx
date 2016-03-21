<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListboundControls.aspx.vb" Inherits="Mod09VB.ListboundControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td><STRONG>Dropdown List</STRONG></td>
					<td></td>
					<td><STRONG>CheckBox List</STRONG></td>
					<td><STRONG>RadioButton List</STRONG></td>
				</tr>
				<tr>
					<td vAlign="top">
						<P><asp:dropdownlist id=DropDownList1 runat="server" DataTextField="stor_name" DataMember="stores" DataSource="<%# DataSet3 %>"></asp:dropdownlist></P>
						<P><STRONG>ListBox<BR>
							</STRONG><STRONG>
								<asp:listbox id=ListBox1 runat="server" DataTextField="stor_name" DataMember="stores" DataSource="<%# DataSet3 %>">
								</asp:listbox></STRONG></P>
					</td>
					<td vAlign="top"></td>
					<td><asp:checkboxlist id=CheckBoxList1 runat="server" DataTextField="stor_name" DataMember="stores" DataSource="<%# DataSet3 %>"></asp:checkboxlist></td>
					<td><asp:radiobuttonlist id=RadioButtonList1 runat="server" DataTextField="stor_name" DataMember="stores" DataSource="<%# DataSet3 %>"></asp:radiobuttonlist></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
