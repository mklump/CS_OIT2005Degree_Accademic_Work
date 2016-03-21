<%@ Page Language="c#" AutoEventWireup="false" Codebehind="ListboundControls.aspx.cs" Inherits="Mod09CS.ListboundControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
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
