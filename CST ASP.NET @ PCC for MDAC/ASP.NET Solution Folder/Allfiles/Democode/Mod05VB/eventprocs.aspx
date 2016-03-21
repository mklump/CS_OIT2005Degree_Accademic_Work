<%@ Page Language="vb" %>

<HTML>
<body>
<SCRIPT language="VB" runat="Server"> 
Sub ImageButton_Click(sender As Object, e As ImageClickEventArgs) 
	Label1.Text="You clicked the ImageButton control at " & _
		"Coordinates: (" & e.X.ToString() & ", " & _
		e.Y.ToString() & ")"
End Sub
</SCRIPT> 
<SCRIPT language="javascript" > 
function Image_onMouseOver()
{
        window.event.srcElement.src="question.jpg";
}
function Image_onMouseOut() 
{
        window.event.srcElement.src="frog.jpg";
}
</SCRIPT> 

<FORM runat="server">
   <input type=image id="InputImage" src="frog.jpg"
          onMouseOver="Image_onMouseOver()" onMouseOut="Image_onMouseOut()"
          OnServerClick="ImageButton_Click" runat="server" >
   <asp:Label id=Label1 runat=server/>
</FORM>


</body>
</HTML>
