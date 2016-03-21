<%@ Page Language="vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title></title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
<script language=vb runat=server>
Sub button1_onclick (s As Object, e As EventArgs)
	Dim i As Integer = 0
	Dim x As Double = Textbox1.Text	
	
	For i=0 To 4
		x *= 2
		Label1.Text = Label1.Text & x & ","
	Next
	Label1.Text = Label1.Text & "<p>"
	Label1.Text = getPi()
End Sub
Sub cmdRandom_onclick (s As Object, e As EventArgs)
	Dim iRandom As Random = new Random()
	lblRandom.Text = iRandom.Next(100)	
End Sub
Function getPi() As Double
	Dim pi As Double
	pi = 4 * system.math.Atan(1)
	return pi
End Function
</script>
<script language=vbscript>
Sub cmd_click
	x = 2
	For i=0 To 4
		x = x * 2
		test.innerHTML = test.innerHTML & x & ","
	Next
End Sub
</script>
<form runat=server>
    <asp:TextBox ID="Textbox1" Runat="server"></asp:TextBox>
    <asp:Label id=Label1 runat="server" ></asp:Label>
    <asp:Button id="Button1" text="Double It" onclick="button1_onclick" runat="server" ></asp:Button>
	<p><asp:Button id=cmdRandom runat="server" onclick="cmdRandom_onclick" Text="Random Number" ></asp:Button>
	<asp:Label id=lblRandom  runat="server" ></asp:Label></p>
    <p><input type="button" name="cmd" value="Client-Side" onclick="cmd_click" >
    <span id="test">here's some text</span></p>
</form>
  </body>
</HTML>
