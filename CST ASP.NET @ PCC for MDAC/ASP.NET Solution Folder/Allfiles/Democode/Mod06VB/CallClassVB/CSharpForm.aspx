<%@ Page Language="C#" %>
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
<script language=C# runat=server>
void button1_onclick (Object s, EventArgs e)
{
	int i = 0;
	double x = Convert.ToDouble(Textbox1.Text);	
	for ( i=0; i<=4; i++)
	{
		x *= 2;
		Label1.Text = Label1.Text + x + ",";
	}
	Label1.Text = Label1.Text + "<p>";
}
void cmdRandom_onclick (Object s, EventArgs e)
{
	Random iRandom = new Random();
	lblRandom.Text = iRandom.Next(100).ToString();	
}
</script>
<form runat=server>
    <asp:TextBox ID="Textbox1" Runat="server"></asp:TextBox>
    <asp:Label id=Label1 runat="server" ></asp:Label>
    <asp:Button id="Button1" text="Double It" onclick="button1_onclick" runat="server" ></asp:Button>
	<p><asp:Button id=cmdRandom runat="server" onclick="cmdRandom_onclick" Text="Random Number" ></asp:Button>
	<asp:Label id=lblRandom  runat="server" ></asp:Label></p>
</form>
  </body>
</HTML>
