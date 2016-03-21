<%@ Page Language="c#" %>
<HTML>
	<head>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<SCRIPT language="c#" runat="Server"> 
	void Page_Load(object s, EventArgs e)
	{
		Label1.Text = Label1.Text + "<P>page_load, ";
	}
	void Page_Unload(object s, EventArgs e)
	{ 
		Label1.Text = Label1.Text + "Page_Unload, ";
	}
	void buttonServerClick(object s, EventArgs e)
	{
		Label1.Text = Label1.Text + "server button click, ";
	}
	void textServerChange(object s, EventArgs e)
	{
		Label1.Text = Label1.Text + "server text change, ";
	}
	void checkServerClick(object s, EventArgs e)
	{
		Label1.Text = Label1.Text + "server checkbox click, ";
	}
	void checkServerChange(object s, EventArgs e)
	{
		Label1.Text = Label1.Text + "server checkbox change, ";
	}
	void listServerClick(object s, EventArgs e)
	{
		Label1.Text = Label1.Text + "server listbox click, ";
	}
	void listServerChange(object s, EventArgs e)
	{
		Label1.Text = Label1.Text + "server listbox change, ";
	}
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
				<SELECT id="lstTitle" onchange="listChange()" onserverchange="listServerChange" onserverclick="listServerClick" runat="server">
					<OPTION selected>
						Software Engineer
					</OPTION>
					<OPTION>
						Software Tester
					</OPTION>
					<OPTION>
						Program Manager
					</OPTION>
				</SELECT>
			</P>
			<P><input type="checkbox" onclick="checkClick()" onserverclick="checkServerClick" onserverchange="checkServerChange" runat="server" id="Checkbox1">Certified 
				Professional
			</P>
			<P><INPUT type="submit" Value="Save" onServerClick="buttonServerClick" onClick="buttonClick()" runat="server" id="Submit1"></P>
			<p>Client-Side events: <span id="span1" runat="server"></span>
			</p>
			<p>Server-Side events:
				<asp:label id="Label1" runat="server" />
			</p>
		</FORM>
	</body>
</HTML>
