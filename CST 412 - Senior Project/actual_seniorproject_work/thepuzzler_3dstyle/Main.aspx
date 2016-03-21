<%@ Page language="c#" Codebehind="Main.aspx.cs" AutoEventWireup="false" Inherits="thepuzzler_3dstyle.MainWebForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>The Puzzler - 3D Style</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="VBScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="MainWebForm" method="post" runat="server">
			<asp:dropdownlist id="Cross_sectionDropDownList" style="Z-INDEX: 115; LEFT: 620px; POSITION: absolute; TOP: 118px"
				runat="server" Height="37px" Width="300px" ForeColor="Goldenrod"></asp:dropdownlist><asp:button id="SingleThreadSolution" style="Z-INDEX: 124; LEFT: 659px; POSITION: absolute; TOP: 15px"
				runat="server" Height="27px" Width="318px" ToolTip="Click this button to solve the puzzle with a single-threaded solution." Text="Single Threaded Solution"></asp:button><asp:listbox id="DictionaryListBox" style="Z-INDEX: 123; LEFT: 17px; POSITION: absolute; TOP: 98px"
				runat="server" Height="599px" Width="158px" ForeColor="Black" BackColor="LightYellow"></asp:listbox><asp:dropdownlist id="DictionaryViewControl" style="Z-INDEX: 120; LEFT: 17px; POSITION: absolute; TOP: 75px"
				runat="server" Height="37px" Width="160px" ForeColor="Goldenrod"></asp:dropdownlist><asp:dropdownlist id="WordsMatchedViewControl" style="Z-INDEX: 119; LEFT: 177px; POSITION: absolute; TOP: 75px"
				runat="server" Height="37px" Width="160px" ForeColor="Goldenrod"></asp:dropdownlist><asp:label id="PuzzleSize" style="FONT-SIZE: 16px; Z-INDEX: 118; LEFT: 651px; POSITION: absolute; TOP: 71px"
				runat="server" Width="326px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge" ToolTip="This display indicates the dimentions of the 3D cubic hidden word puzzle."></asp:label><asp:label id="WordsFound_VS_DictionarySize" style="FONT-SIZE: 16px; Z-INDEX: 117; LEFT: 339px; POSITION: absolute; TOP: 71px"
				runat="server" Width="312px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge" ToolTip="This display indicates the number of words that the solution has found vs. the size of the dictionary."></asp:label><asp:label id="Label5" style="FONT-SIZE: 16px; Z-INDEX: 114; LEFT: 459px; POSITION: absolute; TOP: 118px"
				runat="server" Height="7px" Width="161px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge" ToolTip='The drop down list box to the right selects which 2D "slice" of the puzzle to display from left to right (0 - Maxmum Length).'>Current Cross Section:</asp:label><asp:button id="Exit" style="Z-INDEX: 113; LEFT: 843px; POSITION: absolute; TOP: 47px" runat="server"
				Height="23px" Width="135px" ToolTip="Click this button to exit the application." Text="EXIT"></asp:button><asp:button id="StartOver" style="Z-INDEX: 112; LEFT: 516px; POSITION: absolute; TOP: 47px"
				runat="server" Height="23px" Width="174px" ToolTip="Click this button to start over back at the welcome page." Text="Start Over"></asp:button><asp:button id="HELP" style="Z-INDEX: 111; LEFT: 693px; POSITION: absolute; TOP: 47px" runat="server"
				Height="23px" Width="147px" ToolTip="Click this button to show an explaination and view the credits." Text="HELP"></asp:button><asp:button id="GetStats" style="Z-INDEX: 110; LEFT: 339px; POSITION: absolute; TOP: 47px" runat="server"
				Height="23px" Width="174px" ToolTip="Click this button to display the execution statistics for the current puzzle." Text="Get Statistics"></asp:button><asp:label id="Label2" style="FONT-SIZE: 16px; Z-INDEX: 103; LEFT: 176px; POSITION: absolute; TOP: 10px"
				runat="server" Height="36px" Width="158px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge">Solution Words Found that matched dictionary:</asp:label><asp:listbox id="WordsFound" style="Z-INDEX: 102; LEFT: 176px; POSITION: absolute; TOP: 98px"
				runat="server" Height="599px" Width="158px" ForeColor="Black" BackColor="LightYellow"></asp:listbox><asp:label id="Label1" style="FONT-SIZE: 16px; Z-INDEX: 101; LEFT: 17px; POSITION: absolute; TOP: 9px"
				runat="server" Height="40px" Width="158px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge"> Dictionary Word List: (First 2000 Words)</asp:label><asp:dropdownlist id="DirectionDropDownList" style="Z-INDEX: 104; LEFT: 620px; POSITION: absolute; TOP: 96px"
				runat="server" Height="32px" Width="300px" ForeColor="Goldenrod"></asp:dropdownlist><asp:label id="Label3" style="FONT-SIZE: 16px; Z-INDEX: 105; LEFT: 459px; POSITION: absolute; TOP: 95px"
				runat="server" Width="162px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge" ToolTip='The drop down list box to the right selects 1 of 13 directions for sampling a 2D planar "slice" of the 3D puzzle.'>Current Direction Section:</asp:label><asp:label id="Label4" style="FONT-SIZE: 18; Z-INDEX: 106; LEFT: 15px; POSITION: absolute; TOP: 694px" runat="server"
				Width="319px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge" Font-Size="Small">Statistics for This Puzzle:</asp:label>
			<TABLE id="PuzzleView" style="BORDER-RIGHT: #000000 thin; TABLE-LAYOUT: auto; BORDER-TOP: #000000 thin; FONT-SIZE: 18px; Z-INDEX: 107; LEFT: 340px; BORDER-LEFT: #000000 thin; WIDTH: 25px; BORDER-BOTTOM: #000000 thin; POSITION: absolute; TOP: 149px; BORDER-COLLAPSE: collapse; HEIGHT: 24px; BACKGROUND-COLOR: snow; TEXT-ALIGN: center; Design_Time_Lock: True"
				borderColor="#daa520" cellSpacing="1" borderColorDark="goldenrod" cellPadding="1" align="center"
				bgColor="black" borderColorLight="goldenrod" border="1" runat="server" Design_Time_Lock="True">
			</TABLE>
			<TABLE id="StatisticsView" style="BORDER-RIGHT: black thin; TABLE-LAYOUT: auto; BORDER-TOP: black thin; FONT-WEIGHT: normal; FONT-SIZE: 10pt; Z-INDEX: 108; LEFT: 15px; BORDER-LEFT: black thin; WIDTH: 320px; COLOR: black; BORDER-BOTTOM: black thin; FONT-FAMILY: Impact; POSITION: absolute; TOP: 720px; BORDER-COLLAPSE: collapse; HEIGHT: 31px; BACKGROUND-COLOR: snow; TEXT-ALIGN: center; Design_Time_Lock: True"
				borderColor="blue" cellSpacing="0" borderColorDark="blue" cellPadding="0" width="320"
				borderColorLight="#0000ff" border="1" runat="server" Design_Time_Lock="True">
			</TABLE>
			<asp:button id="SolvePuzzle" style="Z-INDEX: 109; LEFT: 339px; POSITION: absolute; TOP: 15px"
				runat="server" Height="28px" Width="318px" ToolTip="Click this button to solve the puzzle with the power of a mulit-threaded solution."
				Text="Multi-Threaded Solution"></asp:button><asp:label id="Label6" style="FONT-SIZE: 36px; Z-INDEX: 116; LEFT: 339px; POSITION: absolute; TOP: 95px"
				runat="server" Height="46px" Width="118px" ForeColor="Goldenrod" BorderWidth="2px" BorderStyle="Ridge" Font-Size="X-Large" Font-Bold="True"
				Font-Italic="True" Font-Names="Impact">Puzzle:</asp:label><asp:button id="Get_Puzzle" style="Z-INDEX: 121; LEFT: 923px; POSITION: absolute; TOP: 95px"
				runat="server" Height="41px" Width="55px" ToolTip="Click this button to display the current selectional / two dimentional cut of the puzzle." Text="Display!"
				Font-Size="X-Small" Font-Bold="True" Font-Names="Arial"></asp:button><asp:button id="Get_Lists" style="Z-INDEX: 122; LEFT: 17px; POSITION: absolute; TOP: 53px" runat="server"
				Width="318px" Height="22px" Text="Display Words Beginning With" Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" ToolTip="Click this button to display the current selections for the dictionary list and the list for the words found in the puzzle."></asp:button>
			<DIV style="Z-INDEX: 125; LEFT: 16px; WIDTH: 319px; POSITION: absolute; TOP: 888px; HEIGHT: 246px; BACKGROUND-COLOR: goldenrod"
				ms_positioning="GridLayout" title="Much thanks are due to Matthew Monroe (http://jjorg.chem.unc.edu/personal/monroe/cube/Denny3x3/terminology/terminology.html) for providing these helpful images."
				id="DIV1">
				<asp:adrotator id="CubeImageRotator" style="Z-INDEX: 127; LEFT: 34px; POSITION: absolute; TOP: 24px"
					runat="server" Width="247px" Height="198px" BackColor="LightYellow" AdvertisementFile="images/cube_images.xml"
					ToolTip='At the center cube, a single hidden word can exist in 26 different directions along a straight line or "direction" through the puzzle.'></asp:adrotator></DIV>
		</form>
	</body>
</HTML>
