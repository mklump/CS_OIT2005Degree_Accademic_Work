<%@ Page language="c#" Inherits="thepuzzler_3dstyle.WebForm1" CodeFile="UIPrototype.aspx.cs" CodeBehind="UIPrototype.aspx.cs" AutoEventWireup="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>High Fidelity Prototype</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="VBScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:listbox id="ListBox1" style="Z-INDEX: 100; LEFT: 24px; POSITION: absolute; TOP: 40px" runat="server"
				Height="640px" Width="152px" ForeColor="ForestGreen" BackColor="LightYellow"></asp:listbox>
			<asp:Button id="Exit" style="Z-INDEX: 115; LEFT: 624px; POSITION: absolute; TOP: 8px" runat="server"
				Width="112px" Text="EXIT"></asp:Button>
			<asp:Button id="StartOver" style="Z-INDEX: 114; LEFT: 520px; POSITION: absolute; TOP: 8px" runat="server"
				Width="97px" Text="Start Over"></asp:Button>
			<asp:Button id="Help" style="Z-INDEX: 113; LEFT: 744px; POSITION: absolute; TOP: 24px" runat="server"
				Width="160px" Text="Help / Documentation"></asp:Button>
			<asp:Button id="GetStats" style="Z-INDEX: 112; LEFT: 624px; POSITION: absolute; TOP: 40px" runat="server"
				Width="112px" Text="Get Statistics"></asp:Button><asp:label id="Label2" style="Z-INDEX: 103; LEFT: 184px; POSITION: absolute; TOP: 16px" runat="server"
				Width="109px" BorderWidth="2px" ForeColor="Red" BorderStyle="Ridge">Words Found:</asp:label><asp:listbox id="ListBox2" style="Z-INDEX: 102; LEFT: 184px; POSITION: absolute; TOP: 40px" runat="server"
				Height="640px" Width="152px" ForeColor="Red" BackColor="LightYellow"></asp:listbox><asp:label id="Label1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 16px" runat="server"
				Width="117px" BorderWidth="2px" ForeColor="ForestGreen" BorderStyle="Ridge">Words to Find:</asp:label><asp:dropdownlist id="DropDownList1" style="Z-INDEX: 104; LEFT: 344px; POSITION: absolute; TOP: 40px"
				runat="server" Width="168px" ForeColor="Goldenrod"></asp:dropdownlist><asp:label id="Label3" style="Z-INDEX: 105; LEFT: 344px; POSITION: absolute; TOP: 16px" runat="server"
				Width="164px" BorderWidth="2px" ForeColor="Goldenrod" BorderStyle="Ridge">Current Cross Section:</asp:label><asp:label id="Label4" style="Z-INDEX: 106; LEFT: 23px; POSITION: absolute; TOP: 680px" runat="server"
				Width="179px" BorderWidth="2px" ForeColor="Blue" BorderStyle="Ridge">Statistics for This Puzzle:</asp:label>
			<TABLE id="Table1" style="BORDER-RIGHT: #000000 thin; TABLE-LAYOUT: auto; BORDER-TOP: #000000 thin; Z-INDEX: 107; LEFT: 343px; BORDER-LEFT: #000000 thin; WIDTH: 560px; BORDER-BOTTOM: #000000 thin; POSITION: absolute; TOP: 68px; BORDER-COLLAPSE: collapse; HEIGHT: 604px; BACKGROUND-COLOR: snow"
				borderColor="#daa520" cellSpacing="0" borderColorDark="goldenrod" cellPadding="0" width="560"
				align="center" borderColorLight="goldenrod" border="1" runat="server">
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 24px"></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="BORDER-RIGHT: black thin; TABLE-LAYOUT: auto; BORDER-TOP: black thin; Z-INDEX: 108; LEFT: 21px; BORDER-LEFT: black thin; WIDTH: 881px; BORDER-BOTTOM: black thin; POSITION: absolute; TOP: 703px; BORDER-COLLAPSE: collapse; HEIGHT: 106px; BACKGROUND-COLOR: snow"
				borderColor="blue" cellSpacing="0" borderColorDark="blue" cellPadding="0" width="881"
				borderColorLight="#0000ff" border="1">
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 128px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 128px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 128px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px"></TD>
					<TD style="HEIGHT: 25px"></TD>
					<TD style="HEIGHT: 25px"></TD>
					<TD style="HEIGHT: 25px"></TD>
					<TD style="HEIGHT: 25px"></TD>
					<TD style="HEIGHT: 25px"></TD>
					<TD style="WIDTH: 128px; HEIGHT: 25px"></TD>
				</TR>
			</TABLE>
			<HR style="Z-INDEX: 109; LEFT: 13px; POSITION: absolute; TOP: 833px" width="100%" SIZE="1">
			<asp:Button id="SolvePuzzle" style="Z-INDEX: 110; LEFT: 520px; POSITION: absolute; TOP: 40px"
				runat="server" Width="97px" Text="Solve Puzzle"></asp:Button>
		</form>
	</body>
</HTML>
