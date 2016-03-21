<%@ Page language="c#" Codebehind="Welcome.aspx.cs" AutoEventWireup="false" Inherits="thepuzzler_3dstyle.Welcome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Welcome</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<HR style="Z-INDEX: 101; LEFT: 8px; WIDTH: 86.68%; POSITION: absolute; TOP: 560px; HEIGHT: 1px"
				width="86.68%" SIZE="1">
			<HR style="Z-INDEX: 102; LEFT: 8px; WIDTH: 86.66%; POSITION: absolute; TOP: 16px; HEIGHT: 1px"
				width="86.66%" SIZE="1">
			<DIV id="DIV5" style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; Z-INDEX: 103; LEFT: 40px; BORDER-LEFT: gray thin solid; WIDTH: 368px; BORDER-BOTTOM: gray thin solid; POSITION: absolute; TOP: 352px; HEIGHT: 136px"
				runat="server" ms_positioning="GridLayout"><asp:textbox id="textboxBASEDICTIONARY" style="Z-INDEX: 102; LEFT: 184px; POSITION: absolute; TOP: 40px"
					runat="server" Width="176px" Height="24px" ToolTip="Use this field to enter the base dictionary.">1</asp:textbox>
				<DIV id="DIV2" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 103; LEFT: 32px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 40px; HEIGHT: 24px; TEXT-ALIGN: right"
					runat="server" ms_positioning="FlowLayout">Base Dictionary [1 - 4]:
				</DIV>
				<asp:textbox id="textboxDICTIONARYSIZE" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 72px"
					runat="server" Width="176px" Height="24px" ToolTip="Use this field to enter the dictionary size.">5000</asp:textbox>
				<DIV id="DIV3" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 105; LEFT: 32px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 72px; HEIGHT: 24px; TEXT-ALIGN: right"
					runat="server" ms_positioning="FlowLayout">Dictionary Size:
				</DIV>
				<asp:textbox id="textboxMINIMUMDICTIONARYWORDSIZE" style="Z-INDEX: 106; LEFT: 184px; POSITION: absolute; TOP: 104px"
					runat="server" Width="176px" Height="24px" ToolTip="Use this field to enter the minimum length of each dictionary word.">3</asp:textbox>
				<DIV id="DIV4" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 107; LEFT: 32px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 104px; HEIGHT: 24px; TEXT-ALIGN: right"
					runat="server" ms_positioning="FlowLayout">Minimum Word Length:
				</DIV>
				<DIV id="Div1" style="DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 101; LEFT: 8px; WIDTH: 160px; POSITION: absolute; TOP: 8px; HEIGHT: 24px; TEXT-ALIGN: center"
					runat="server" ms_positioning="FlowLayout">Dictionary Specifications:
				</DIV>
			</DIV>
			<DIV id="Div16" style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; Z-INDEX: 104; LEFT: 424px; BORDER-LEFT: gray thin solid; WIDTH: 368px; BORDER-BOTTOM: gray thin solid; POSITION: absolute; TOP: 352px; HEIGHT: 136px"
				runat="server" ms_positioning="GridLayout"><asp:textbox id="textboxPUZZLE_X_LENGTH" style="Z-INDEX: 110; LEFT: 184px; POSITION: absolute; TOP: 40px"
					runat="server" Width="176px" Height="24px" ToolTip="Use this field to enter the puzzle's length.">15</asp:textbox>
				<DIV id="Div17" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 110; LEFT: 32px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 40px; HEIGHT: 24px; TEXT-ALIGN: right"
					runat="server" ms_positioning="FlowLayout">Puzzle Length [x size]:
				</DIV>
				<asp:textbox id="textboxPUZZLE_Y_LENGTH" style="Z-INDEX: 110; LEFT: 184px; POSITION: absolute; TOP: 72px"
					runat="server" Width="176px" Height="24px" ToolTip="Use this field to enter the puzzle's height.">20</asp:textbox>
				<DIV id="Div18" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 110; LEFT: 32px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 72px; HEIGHT: 24px; TEXT-ALIGN: right"
					runat="server" ms_positioning="FlowLayout">Puzzle Height [y size]:
				</DIV>
				<asp:textbox id="textboxPUZZLE_Z_LENGTH" style="Z-INDEX: 110; LEFT: 184px; POSITION: absolute; TOP: 104px"
					runat="server" Width="176px" Height="24px" ToolTip="Use this field to enter the puzzle's depth.">25</asp:textbox>
				<DIV id="Div19" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 110; LEFT: 32px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 104px; HEIGHT: 24px; TEXT-ALIGN: right"
					runat="server" ms_positioning="FlowLayout">Puzzle Depth [z size]:
				</DIV>
				<DIV id="Div20" style="DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 104; LEFT: 8px; WIDTH: 160px; POSITION: absolute; TOP: 8px; HEIGHT: 24px; TEXT-ALIGN: center"
					runat="server" ms_positioning="FlowLayout">Puzzle Specifications:
				</DIV>
			</DIV>
			<asp:button id="SubmitConfiguration" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 504px"
				runat="server" Width="560px" Height="39px" Font-Size="Medium" Text="Submit Configuration"
				Font-Bold="True" ToolTip="Click this button to submit the configuration for the dictionary and puzzle you've entered."></asp:button>
			<DIV id="DIV6" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-WEIGHT: bold; FONT-SIZE: 36px; Z-INDEX: 106; LEFT: 40px; VERTICAL-ALIGN: baseline; BORDER-LEFT: black thin solid; WIDTH: 752px; BORDER-BOTTOM: black thin solid; FONT-STYLE: italic; POSITION: absolute; TOP: 40px; HEIGHT: 288px; BACKGROUND-COLOR: lightyellow; TEXT-ALIGN: center"
				runat="server" ms_positioning="FlowLayout">
				<P>Welcome to:</P>
				<P><U>The Puzzler - 3D Style</U></P>
				<P><FONT style="FONT-SIZE: 22px">"An Exploration of Algorithms with .NET Technologies"</FONT></P>
				<P><FONT style="FONT-SIZE: 16px">A 3-Dimentional Hidden Word Puzzle Generator and 
						Solver</FONT></P>
				<P>By: Matthew Klump</P>
			</DIV>
			<asp:Button id="HELP" style="Z-INDEX: 107; LEFT: 616px; POSITION: absolute; TOP: 504px" runat="server"
				Height="40px" Width="177px" Font-Bold="True" Text="HELP" Font-Size="Medium" BorderStyle="Outset"
				ToolTip="Click this button to go to the help page."></asp:Button>
		</form>
	</body>
</HTML>
