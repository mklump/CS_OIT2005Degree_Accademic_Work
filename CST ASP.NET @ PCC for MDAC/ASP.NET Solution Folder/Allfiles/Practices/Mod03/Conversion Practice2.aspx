<%@ Page Language="c#"  %>
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
Sub cmdRunCode_onclick (s As Object, e As EventArgs)
	lblOutput.Text = Test()	
End Sub
Private Function Test() As String
	Dim sReturn As String
	Dim i As Integer = 10
	Dim j As Integer = 1
	Do While j < i
		sReturn = sReturn & j
		j += 2
	Loop
	Return sReturn
End Function
</pre>
<script language=C# runat=server>
void cmdRunCode_onclick (Object s, EventArgs e)
{
	lblOutput.Text = Test();	
}
string Test()
{	string sReturn = "";
	int i = 10;
	int j = 1;
	while (j < i)
	{
		sReturn = sReturn + j;
		j += 2;
	}
	return sReturn;
}

</script>
<form runat=server>
	<p><asp:Button id=cmdRunCode runat="server" onclick="cmdRunCode_onclick" Text="Run Code" ></asp:Button>
	<asp:Label id=lblOutput  runat="server" ></asp:Label></p>
    <p>&nbsp;</p>
</form>
  </body>
</HTML>
