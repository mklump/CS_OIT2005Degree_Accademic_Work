<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dental.aspx.cs" Inherits="dental" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="Summary Error Message" Display="Dynamic">An input is required
            </asp:RequiredFieldValidator><asp:RangeValidator
                ID="RangeValidator1" runat="server" ErrorMessage="Summary error message"
                ControlToValidate="TextBox1"
                MaximumValue=100 MinimumValue=16 Type=Integer>Out of range</asp:RangeValidator>
        <br /><asp:TextBox ID="TextBox2" runat="server" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
        ErrorMessage="Invalid E-mail address!" ControlToValidate="TextBox2" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
        <asp:Button ID="Button1" runat="server" Text="Button" Width="155px" />
    </div>
    </form>
</body>
</html>
