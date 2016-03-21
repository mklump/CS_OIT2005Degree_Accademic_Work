<%@ Page Language="c#" %>
<HTML>
	<body>
		<SCRIPT language="c#" runat="Server"> 
void ImageButton_Click(object sender, ImageClickEventArgs e)
{ 
	Label1.Text = "You clicked the ImageButton control at Coordinates: ("
				+ e.X.ToString() + ", " + e.Y.ToString() + ")";
}
		</SCRIPT>
		<SCRIPT language="javascript"> 
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
			<input type="image" id="InputImage" src="frog.jpg" onMouseOver="Image_onMouseOver()" onMouseOut="Image_onMouseOut()" OnServerClick="ImageButton_Click" runat="server">
			<asp:Label id="Label1" runat="server" />
		</FORM>
	</body>
</HTML>
