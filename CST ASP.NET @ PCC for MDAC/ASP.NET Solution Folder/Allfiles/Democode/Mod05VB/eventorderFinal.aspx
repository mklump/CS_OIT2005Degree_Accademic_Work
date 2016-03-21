<%@ Page Language="vb" %>
<HTML>
	<head>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<SCRIPT language="VB" runat="Server"> 
	Sub Page_Load(s As Object, e As EventArgs) 
		If Not Page.IsPostBack Then
			label1.Text = label1.Text & "<P>page_load first time, "
		Else
			label1.Text = label1.Text & "<P>page_load postback, "
		End If
	End Sub 
	Sub Page_Unload(s As Object, e As EventArgs) 
		label1.Text = label1.text & "Page_Unload, "
	End Sub 
	Sub buttonServerClick(s As Object, e As EventArgs) 
		label1.Text = label1.text & "server button click, "
	End Sub 
	Sub textServerChange(s As Object, e As EventArgs) 
		label1.Text = label1.text & "server text change, "
	End Sub 
	Sub checkServerClick(s As Object, e As EventArgs) 
		label1.Text = label1.text & "server checkbox click, "
	End Sub 
	Sub checkServerChange(s As Object, e As EventArgs) 
		label1.Text = label1.text & "server checkbox change, "
	End Sub 
	Sub listServerClick(s As Object, e As EventArgs) 
		label1.Text = label1.text & "server listbox click, "
	End Sub 
	Sub listServerChange(s As Object, e As EventArgs) 
		label1.Text = label1.text & "server listbox change, "
	End Sub 
		</SCRIPT>
		<SCRIPT language="javascript"> 
	function buttonClick() 
	{
		span1.innerHTML = span1.innerHTML + "button clicked, ";
	} 
	function textChange() 
	{
		span1.innerHTML = span1.innerHTML + "textbox changed, ";
	} 
	function checkClick() 
	{
		span1.innerHTML = span1.innerHTML + "checkbox clicked, ";
	} 
	function listChange() 
	{
		span1.innerHTML = span1.innerHTML + "listbox changed, ";
	} 
		</SCRIPT>
		<FORM runat="server">
			Name: <input type="text" onchange="textChange()" onserverchange="textServerChange" id="txtName" runat="server">
			<P>Profession:
				<SELECT id="lstTitle" onchange="listChange()" onserverchange="listserverchange" onserverclick="listserverclick" runat="server">
					<OPTION selected>Software Engineer</OPTION>
					<OPTION>Software Tester</OPTION>
					<OPTION>Program Manager</OPTION>
				</SELECT>
			</P>
			<P><asp:checkbox autopostback="True" onclick="checkClick()" onserverclick="checkserverclick" oncheckedchanged="checkserverchange" runat="server" id="Checkbox1" text="Certified Professional" /></P>
			<P><INPUT type="submit" Value="Save" onServerClick="buttonServerClick" onClick="buttonClick()" runat="server" id="Submit1" name="Submit1"></P>
			<p>Client-Side events: <span id="span1" runat="server" /></p>
			<p>Server-Side events:
				<asp:label id="Label1" runat="server" /></p>
		</FORM>
	</BODY>
</HTML>
