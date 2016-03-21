<%@ Page Language="c#" AutoEventWireup="false" Codebehind="DataReaderCode.aspx.cs" Inherits="Mod10CS.DataReaderCode" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="jscript">
		var box1 = "";
		var box2 = "";
  function Box1Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
	if (sValue == "SqlConnection conn = new SqlConnection('valid connection string');") {
		arguments.IsValid = true; 
		box1 = sValue;
	} else if (sValue == "SqlDataReader dr;"){ 
		arguments.IsValid = true;
		box1 = sValue;
    } else { 
        Label2.InnerHtml = ""
		arguments.IsValid = false;
    } 
  }
    function Box2Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
	if (sValue == "SqlCommand cmdAuthors = new SqlCommand('select * from Authors', conn);")
		{
			if (box1 == "SqlConnection conn = new SqlConnection('valid connection string');")
			{
			arguments.IsValid = true; 
			box2 = sValue;
			}
			else
			{
			arguments.IsValid = false;
			}
		} 
		else if (sValue == "SqlConnection conn = new SqlConnection('valid connection string');")
		{
			if (box1 != "SqlConnection conn = new SqlConnection('valid connection string');")
			{
			arguments.IsValid = true; 
			box2 = sValue;
			}
			else
			{
			arguments.IsValid = false;
			}
		} 
		else if (sValue == "SqlDataReader dr;")
		{ 
			if (box1 != "SqlDataReader dr;")
			{
			arguments.IsValid = true; 
			box2 = sValue;
			}
			else
			{
			arguments.IsValid = false;
			}
		}
		else 
		{ 
			arguments.IsValid = false; 
		}
  }
    function Box3Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
	if (sValue == "SqlCommand cmdAuthors = new SqlCommand('select * from Authors', conn);")
		{
			if (box1 == "SqlCommand cmdAuthors = new SqlCommand('select * from Authors', conn);")
			{
				arguments.IsValid = false;
			}
			else if (box2 == "SqlCommand cmdAuthors = new SqlCommand('select * from Authors', conn);")
			{
				arguments.IsValid = false; 
			}
			else
			{
				if (box1 == "SqlConnection conn = new SqlConnection('valid connection string');")
				{
				arguments.IsValid = true; 
				}
				else if (box2 == "SqlConnection conn = new SqlConnection('valid connection string');")
				{
				arguments.IsValid = true; 
				}
				else
				{
				arguments.IsValid = false;
				}
			}
		} 
	else if (sValue == "SqlConnection conn = new SqlConnection('valid connection string');")
	{
		if (box1 == "SqlConnection conn = new SqlConnection('valid connection string');")
		{
			arguments.IsValid = false;
		}
		else if (box2 == "SqlConnection conn = new SqlConnection('valid connection string');")
		{
			arguments.IsValid = false; 
		}
		else
		{
			arguments.IsValid = true;
		}
	} 
	else if (sValue == "SqlDataReader dr;")
	{ 
		if (box1 == "SqlDataReader dr;")
		{
		arguments.IsValid = false;
		}
		else if (box2 == "SqlDataReader dr;")
		{
		arguments.IsValid = false;
		}
		else
		{
			arguments.IsValid = true; 
		}
	}
	else 
	{ 
		arguments.IsValid = false; 
	}
  }
    function Box4Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
	if (sValue == "conn.Open();") {
		arguments.IsValid = true; 
    } else { 
		arguments.IsValid = false;
    } 
  }
  function Box5Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
	if (sValue == "dr = cmdAuthors.ExecuteReader();") {
		arguments.IsValid = true; 
    } else { 
		arguments.IsValid = false;
    } 
  }
  function Box6Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
	if (sValue == "dr.Close();") {
		arguments.IsValid = true; 
    } else { 
		arguments.IsValid = false;
    } 
  }
  function Box7Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
	if (sValue == "conn.Close();") {
		arguments.IsValid = true; 
    } else { 
		arguments.IsValid = false;
    } 
  }
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="Label1" runat="server" Font-Size="Medium" Font-Bold="True" Height="18px" Width="421px">Put the following lines of code in the correct order:</asp:Label></P>
			<P>
				<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList>
				<asp:CustomValidator id="CustomValidator1" runat="server" ErrorMessage="incorrect" ControlToValidate="DropDownList1" ClientValidationFunction="Box1Validation"></asp:CustomValidator></P>
			<P>
				<asp:DropDownList id="DropDownList2" runat="server"></asp:DropDownList>
				<asp:CustomValidator id="CustomValidator2" runat="server" ErrorMessage="incorrect" ControlToValidate="DropDownList2" ClientValidationFunction="Box2Validation"></asp:CustomValidator></P>
			<P>
				<asp:DropDownList id="DropDownList3" runat="server"></asp:DropDownList>
				<asp:CustomValidator id="CustomValidator3" runat="server" ErrorMessage="incorrect" ControlToValidate="DropDownList3" ClientValidationFunction="Box3Validation"></asp:CustomValidator></P>
			<P>
				<asp:DropDownList id="DropDownList4" runat="server"></asp:DropDownList>
				<asp:CustomValidator id="CustomValidator4" runat="server" ControlToValidate="DropDownList4" ErrorMessage="incorrect" ClientValidationFunction="Box4Validation"></asp:CustomValidator></P>
			<P>
				<asp:DropDownList id="DropDownList5" runat="server"></asp:DropDownList>
				<asp:CustomValidator id="CustomValidator5" runat="server" ErrorMessage="incorrect" ControlToValidate="DropDownList5" ClientValidationFunction="Box5Validation"></asp:CustomValidator></P>
			<P>
				<asp:DropDownList id="DropDownList6" runat="server"></asp:DropDownList>
				<asp:CustomValidator id="CustomValidator6" runat="server" ErrorMessage="incorrect" ControlToValidate="DropDownList6" ClientValidationFunction="Box6Validation"></asp:CustomValidator></P>
			<P><asp:DropDownList id="DropDownList7" runat="server"></asp:DropDownList><asp:CustomValidator id="CustomValidator7" runat="server" ClientValidationFunction="Box7Validation" ControlToValidate="DropDownList7" ErrorMessage="incorrect"></asp:CustomValidator></P>
			<P>
				<asp:Button id="Button1" runat="server" Text="Check Answers"></asp:Button></P>
			<P>
				<asp:Label id="Label2" runat="server" Font-Names="Tahoma"></asp:Label></P>
		</form>
	</body>
</HTML>
