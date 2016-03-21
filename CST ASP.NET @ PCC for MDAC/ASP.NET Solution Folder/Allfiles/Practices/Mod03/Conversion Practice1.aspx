<%@ Page Language="VB"  %>
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
<pre>
void cmdRunCode_onclick (Object s, EventArgs e)
{
	lblOutput.Text = getPi();	
}
public double getPi()
{
	double pi;
	pi = 4 * System.Math.Atan(1);
	return pi;
}
</pre>

<script language="VB" runat=server>
Sub cmdRunCode_onclick (s As Object, e As EventArgs)
	lblOutput.Text = getPi()	
End Sub

Function getPi() As Double
	Dim pi As Double
	pi = 4 * System.Math.Atan(1)
	return pi
End Function
</script>
<form runat=server>
	<p><asp:Button id=cmdRunCode runat="server" onclick="cmdRunCode_onclick" Text="Run Code" ></asp:Button>
	<asp:Label id=lblOutput  runat="server" ></asp:Label></p>
    <p>&nbsp;</p>
</form>

  </body>
</HTML>








