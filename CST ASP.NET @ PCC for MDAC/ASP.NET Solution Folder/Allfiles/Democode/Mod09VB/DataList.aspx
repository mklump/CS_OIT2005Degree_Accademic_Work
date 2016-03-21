<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DataList.aspx.vb" Inherits="Mod09VB.DataList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataList id=DataList1 style="Z-INDEX: 101; LEFT: 222px; POSITION: absolute; TOP: 29px" runat="server" DataSource="<%# DataSet1 %>" DataMember="authors" >
				<HeaderTemplate>
					<p align="center">-------- HEADER --------</p>
				</HeaderTemplate>
				<ItemTemplate>
					<font color="#009966">
						<p align="center"><b>
								<%# container.dataitem("au_fname") %>
								<%# container.dataitem("au_lname") %>
							</b>
							<%# container.dataitem("phone") %>
						</p>
					</font>
				</ItemTemplate>
				<SeparatorTemplate>
					<hr color="#3300ff" size="1">
				</SeparatorTemplate>
				<AlternatingItemTemplate>
					<font color="#cc3300">
						<p align="center">
							<%# container.dataitem("au_fname") %>
							<%# container.dataitem("au_lname") %>
						</p>
					</font>
				</AlternatingItemTemplate>
				<FooterTemplate>
					<p align="center">-------- FOOTER --------</p>
				</FooterTemplate>
			</asp:DataList>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 77px" runat="server" Font-Bold="True">Column Direction</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 22px; POSITION: absolute; TOP: 19px" runat="server" Font-Bold="True">Number of Columns</asp:Label>
			<asp:RadioButtonList id="rbColumns" style="Z-INDEX: 104; LEFT: 15px; POSITION: absolute; TOP: 38px" runat="server" Width="99px" Height="15px" RepeatDirection="Horizontal" AutoPostBack="True">
				<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="3">3</asp:ListItem>
			</asp:RadioButtonList>
			<asp:RadioButtonList id="rbDirection" style="Z-INDEX: 106; LEFT: 17px; POSITION: absolute; TOP: 97px" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
				<asp:ListItem Value="Vertical" Selected="True">Vertical</asp:ListItem>
				<asp:ListItem Value="Horizontal">Horizontal</asp:ListItem>
			</asp:RadioButtonList>
		</form>
	</body>
</HTML>
