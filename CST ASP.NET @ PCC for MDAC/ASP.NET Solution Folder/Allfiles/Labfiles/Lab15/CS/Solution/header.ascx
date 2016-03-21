<%@ Control CodeBehind="header.ascx.cs" Language="c#" AutoEventWireup="false" Inherits="BenefitsCS.header" %>
<%@ OutputCache Duration="120" VaryByParam="none"%>
<HEAD>
	<script language="JavaScript">


	</script>
</HEAD>
<body marginwidth="0" marginheight="0" topmargin="0" leftmargin="0">
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td valign="top">
				<P align="center"><FONT face="Verdana" size="2"> <a href="default.aspx">Home</a> <a href="Dental.aspx" id="A1" runat="server">
							Dental</a> <a href="Medical.aspx" id="A2" runat="server">Medical</a> <a href="retirement.aspx" id="A3" runat="server">
							Retirement Account</a> <a href="Life.aspx" id="A4" runat="server">Life 
							Insurance</a>
				</P>
				</FONT>
			</td>
		</tr>
		<tr>
			<td><br>
			</td>
		</tr>
		<tr>
			<td>
				<P align="center">&nbsp;<STRONG><EM><FONT face="Verdana" size="5">Benefits Selection Site</FONT></EM></STRONG>
					<asp:Label id="lblTime" runat="server">Label</asp:Label>
				</P>
			</td>
		</tr>
	</table>
</body>
