<%@ Page Language="c#" AutoEventWireup="false" Codebehind="DataList.aspx.cs" Inherits="Mod09CS.DataList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataList id=DataList1 style="Z-INDEX: 101; LEFT: 222px; POSITION: absolute; TOP: 29px" runat="server" DataSource="<%# DataSet1 %>" DataMember="authors" >
				<HeaderTemplate>
					<P align="center">-------- HEADER --------</P>
				</HeaderTemplate>
				<FooterTemplate>
					<P align="center">-------- FOOTER --------</P>
				</FooterTemplate>
				<ItemTemplate>
					<FONT color="#009966">
						<P align="center">
							<B>
								<%# DataBinder.Eval(Container.DataItem, "au_fname") %>
								<%# DataBinder.Eval(Container.DataItem, "au_lname") %>
							</B>
							<%# DataBinder.Eval(Container.DataItem, "phone") %>
						</P>
					</FONT>
				</ItemTemplate>
				<SeparatorTemplate>
					<hr color="#3300ff" size="1">
				</SeparatorTemplate>
				<AlternatingItemTemplate>
					<FONT color="#cc3300">
						<P align="center"><%# DataBinder.Eval(Container.DataItem, "au_fname") %><%# DataBinder.Eval(Container.DataItem, "au_lname") %></P>
					</FONT>
				</AlternatingItemTemplate>
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
