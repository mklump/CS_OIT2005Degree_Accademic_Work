<%@ Page Language="c#" AutoEventWireup="false" Codebehind="DataSetCode.aspx.cs" Inherits="Mod10CS.DataSetCode" %>
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
    } else if (sValue == "DataSet ds = new DataSet();"){ 
		arguments.IsValid = true;
		box1 = sValue;
    } else {
		arguments.IsValid = false;
    }
  }
  function Box2Validation(source, arguments) 
  { 
	var sValue = arguments.Value; 
		if (sValue == "SqlDataAdapter da = new SqlDataAdapter('select * from Authors', conn);")
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
		else if (sValue == "DataSet ds = new DataSet();")
		{ 
			if (box1 != "DataSet ds = new DataSet();")
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
	if (sValue == "SqlDataAdapter da = new SqlDataAdapter('select * from Authors', conn);")
		{
			if (box1 == "SqlDataAdapter da = new SqlDataAdapter('select * from Authors', conn);")
			{
				arguments.IsValid = false;
			}
			else if (box2 == "SqlDataAdapter da = new SqlDataAdapter('select * from Authors', conn);")
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
	else if (sValue == "DataSet ds = new DataSet();")
	{ 
		if (box1 == "DataSet ds = new DataSet();")
		{
		arguments.IsValid = false;
		}
		else if (box2 == "DataSet ds = new DataSet();")
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
	if (sValue == "da.Fill(ds, 'Authors');") {
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
				<asp:Button id="Button1" runat="server" Text="Check Answers"></asp:Button></P>
			<P>
				<asp:Label id="Label2" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
