<%@ Page language="c#" Codebehind="ReviewConfiguration.aspx.cs" AutoEventWireup="false" Inherits="thepuzzler_3dstyle.ReviewConfiguration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReviewConfiguration</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ReviewConfigForm" method="post" runat="server">
			<asp:button id="buttonYESRESPONSE" style="Z-INDEX: 111; LEFT: 504px; POSITION: absolute; TOP: 488px"
				runat="server" Height="72px" Width="176px" Font-Bold="True" Text="YES" Font-Size="X-Large"
				BorderStyle="Outset" ToolTip="Click this button to select yes."></asp:button>
			<HR style="Z-INDEX: 101; LEFT: 32px; WIDTH: 82.75%; POSITION: absolute; TOP: 8px; HEIGHT: 1px"
				width="82.75%" SIZE="1">
			<DIV id="Config_Question" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-WEIGHT: bold; FONT-SIZE: 24pt; Z-INDEX: 103; LEFT: 240px; BORDER-LEFT: black thin solid; WIDTH: 256px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 488px; HEIGHT: 56px; BACKGROUND-COLOR: lightyellow; TEXT-ALIGN: center"
				runat="server" ms_positioning="FlowLayout">Configuration Okay?</DIV>
			<asp:button id="buttonNORESPONSE" style="Z-INDEX: 104; LEFT: 48px; POSITION: absolute; TOP: 488px"
				runat="server" Height="72px" Width="185px" Font-Bold="True" Text="NO" Font-Size="X-Large"
				BorderStyle="Outset" ToolTip="Click this button to select no."></asp:button>
			<DIV id="StatusPanel" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 14px; Z-INDEX: 118; LEFT: 48px; BORDER-LEFT: black thin solid; WIDTH: 744px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 16px; HEIGHT: 320px; BACKGROUND-COLOR: lightyellow"
				runat="server" ms_positioning="FlowLayout">
				<FONT style="FONT-SIZE: 20px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<STRONG>Review Configuration</STRONG></FONT>
				<UL>
					<LI>
						<FONT style="FONT-SIZE: 16px">Please review the dictionary and puzzle 
							specifications. To proceed&nbsp;click "Yes" to check the&nbsp;specifications or 
							click "No" to go back and re-enter the specifications.</FONT>
					<LI>
						<FONT style="FONT-SIZE: 16px">Extremely large values will cause the application to 
							stop responding.</FONT>
					<LI>
						<FONT style="FONT-SIZE: 16px">Tips for the Dictionary: </FONT><font style="FONT-SIZE: 14px">
							<UL>
								<LI>
								Only specify the base dictionaries 1 through 4.
								<LI>
								The size should be at least 1000 words and idealy less than 25000 words.
								<LI>
								On base dictionary #1, the size should not be more than 38,622 words.
								<LI>
								On base dictionary #2, the size should not be more than 106,249 words.
								<LI>
								On base dictionary #3, the size should not be more than 213,558 words.
								<LI>
								On base dictionary #4, the size should not be more than 869,230 words.
								<LI>
									The Minimum Word Length should be at least 3 characters and not more than any 
									length of the puzzle.</LI></UL>
						</font>
					<LI>
						<FONT style="FONT-SIZE: 16px">Tips for the Puzzle: </FONT><font style="FONT-SIZE: 14px">
							<UL>
								<LI>
								The puzzle lengths/measurements can be anything, however,
								<LI>
									the puzzle lengths/measurements longer than 100 tend to take exponentially 
									longer to create and to solve.</LI></UL>
						</font>
					</LI>
				</UL>
			</DIV>
			<DIV id="Dictionary_Label" style="DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 117; LEFT: 56px; WIDTH: 160px; POSITION: absolute; TOP: 352px; HEIGHT: 24px; TEXT-ALIGN: center"
				runat="server" ms_positioning="FlowLayout">Dictionary Specifications:
			</DIV>
			<DIV id="DIV2" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 116; LEFT: 80px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 384px; HEIGHT: 24px; TEXT-ALIGN: right"
				runat="server" ms_positioning="FlowLayout">Base Dictionary [1 - 4]:
			</DIV>
			<asp:textbox id="BASEDICTIONARY" style="Z-INDEX: 114; LEFT: 232px; POSITION: absolute; TOP: 384px"
				runat="server" Height="24px" Width="176px" Font-Bold="True" Enabled="False"></asp:textbox>
			<DIV id="DIV3" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 115; LEFT: 80px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 416px; HEIGHT: 24px; TEXT-ALIGN: right"
				runat="server" ms_positioning="FlowLayout">Dictionary Size:
			</DIV>
			<asp:textbox id="DICTIONARYSIZE" style="Z-INDEX: 119; LEFT: 232px; POSITION: absolute; TOP: 416px"
				runat="server" Height="24px" Width="176px" Font-Bold="True" Enabled="False"></asp:textbox>
			<DIV id="DIV4" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 109; LEFT: 80px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 448px; HEIGHT: 24px; TEXT-ALIGN: right"
				runat="server" ms_positioning="FlowLayout">Minimum Word Length:
			</DIV>
			<asp:textbox id="MINIMUMDICTIONARYWORDSIZE" style="Z-INDEX: 108; LEFT: 232px; POSITION: absolute; TOP: 448px"
				runat="server" Height="24px" Width="176px" Font-Bold="True" Enabled="False"></asp:textbox>
			<DIV id="Puzzle_Label" style="DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 113; LEFT: 432px; WIDTH: 160px; POSITION: absolute; TOP: 352px; HEIGHT: 24px; TEXT-ALIGN: center"
				runat="server" ms_positioning="FlowLayout">Puzzle Specifications:
			</DIV>
			<DIV id="Div17" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 112; LEFT: 456px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 384px; HEIGHT: 24px; TEXT-ALIGN: right"
				runat="server" ms_positioning="FlowLayout">Puzzle Length [x size]:
			</DIV>
			<DIV id="Div18" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 110; LEFT: 456px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 416px; HEIGHT: 24px; TEXT-ALIGN: right"
				runat="server" ms_positioning="FlowLayout">Puzzle Height [y size]:
			</DIV>
			<DIV id="Div19" style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; DISPLAY: inline; FONT-SIZE: 12pt; Z-INDEX: 107; LEFT: 456px; VERTICAL-ALIGN: super; BORDER-LEFT: black thin solid; WIDTH: 152px; BORDER-BOTTOM: black thin solid; POSITION: absolute; TOP: 448px; HEIGHT: 24px; TEXT-ALIGN: right"
				runat="server" ms_positioning="FlowLayout">Puzzle Depth [z size]:
			</DIV>
			<asp:textbox id="PUZZLE_X_LENGTH" style="Z-INDEX: 106; LEFT: 608px; POSITION: absolute; TOP: 384px"
				runat="server" Height="24px" Width="176px" Font-Bold="True" Enabled="False"></asp:textbox><asp:textbox id="PUZZLE_Y_LENGTH" style="Z-INDEX: 105; LEFT: 608px; POSITION: absolute; TOP: 416px"
				runat="server" Height="24px" Width="176px" Font-Bold="True" Enabled="False"></asp:textbox><asp:textbox id="PUZZLE_Z_LENGTH" style="Z-INDEX: 102; LEFT: 608px; POSITION: absolute; TOP: 448px"
				runat="server" Height="24px" Width="176px" Font-Bold="True" Enabled="False"></asp:textbox>
			<DIV id="DIV5" style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; Z-INDEX: 120; LEFT: 48px; BORDER-LEFT: gray thin solid; WIDTH: 368px; BORDER-BOTTOM: gray thin solid; POSITION: absolute; TOP: 344px; HEIGHT: 136px"
				runat="server" ms_positioning="GridLayout"></DIV>
			<DIV id="DIV1" style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; Z-INDEX: 121; LEFT: 424px; BORDER-LEFT: gray thin solid; WIDTH: 368px; BORDER-BOTTOM: gray thin solid; POSITION: absolute; TOP: 344px; HEIGHT: 136px"
				runat="server" ms_positioning="GridLayout"></DIV>
			<HR style="Z-INDEX: 122; LEFT: 32px; WIDTH: 83.26%; POSITION: absolute; TOP: 568px; HEIGHT: 1px"
				width="83.26%" SIZE="1">
			<asp:Button id="HELP" style="Z-INDEX: 123; LEFT: 688px; POSITION: absolute; TOP: 488px" runat="server"
				Height="72px" Width="104px" Font-Bold="True" Text="HELP" Font-Size="Large" BorderStyle="Outset"
				ToolTip="Click this button to go to the help page."></asp:Button></form>
	</body>
</HTML>
