<%@ Page language="c#" Codebehind="CustOrders.aspx.cs" AutoEventWireup="false" Inherits="Mod10CS.CustOrders" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustOrders</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<Div ID="queryDiv"><Table ID="queryTable" Width="100%">
					<TR>
						<TD>
						</TD>
						<TD><asp:Button runat="server" AccessKey="L" ID="buttonLoad" Text="Load"></asp:Button>
						</TD>
					</TR>
				</Table>
			</Div>
			<BR>
			<asp:DataGrid runat="server" DataKeyField="CustomerID" PageSize="5" AutoGenerateColumns="False" Height="50px" Width="100%" DataMember="Customers" ID="masterDataGrid" CellPadding="2" DataSource='<%# objdsCustOrders %>'>
				<Columns>
					<asp:ButtonColumn Text="Show Details" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="CustomerID" HeaderText="CustomerID"></asp:BoundColumn>
					<asp:BoundColumn DataField="CompanyName" HeaderText="CompanyName"></asp:BoundColumn>
					<asp:BoundColumn DataField="ContactName" HeaderText="ContactName"></asp:BoundColumn>
					<asp:BoundColumn DataField="ContactTitle" HeaderText="ContactTitle"></asp:BoundColumn>
					<asp:BoundColumn DataField="Address" HeaderText="Address"></asp:BoundColumn>
					<asp:BoundColumn DataField="City" HeaderText="City"></asp:BoundColumn>
					<asp:BoundColumn DataField="Region" HeaderText="Region"></asp:BoundColumn>
					<asp:BoundColumn DataField="PostalCode" HeaderText="PostalCode"></asp:BoundColumn>
					<asp:BoundColumn DataField="Country" HeaderText="Country"></asp:BoundColumn>
					<asp:BoundColumn DataField="Phone" HeaderText="Phone"></asp:BoundColumn>
					<asp:BoundColumn DataField="Fax" HeaderText="Fax"></asp:BoundColumn>
				</Columns>
				<HeaderStyle Font-Names="Verdana" Font-Bold="True" Height="10px" ForeColor="Black" BackColor="Silver"></HeaderStyle>
			</asp:DataGrid>
			<asp:DataGrid runat="server" DataKeyField="OrderID" PageSize="5" AutoGenerateColumns="False" Height="50px"
				Width="100%" DataMember="Orders" ID="detailDataGrid" CellPadding="2">
				<Columns>
					<asp:BoundColumn DataField="OrderID" HeaderText="OrderID"></asp:BoundColumn>
					<asp:BoundColumn DataField="CustomerID" HeaderText="CustomerID"></asp:BoundColumn>
					<asp:BoundColumn DataField="EmployeeID" HeaderText="EmployeeID"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrderDate" HeaderText="OrderDate"></asp:BoundColumn>
					<asp:BoundColumn DataField="RequiredDate" HeaderText="RequiredDate"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShippedDate" HeaderText="ShippedDate"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShipVia" HeaderText="ShipVia"></asp:BoundColumn>
					<asp:BoundColumn DataField="Freight" HeaderText="Freight"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShipName" HeaderText="ShipName"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShipAddress" HeaderText="ShipAddress"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShipCity" HeaderText="ShipCity"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShipRegion" HeaderText="ShipRegion"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShipPostalCode" HeaderText="ShipPostalCode"></asp:BoundColumn>
					<asp:BoundColumn DataField="ShipCountry" HeaderText="ShipCountry"></asp:BoundColumn>
				</Columns>
				<HeaderStyle Font-Names="Verdana" Font-Bold="True" Height="10px" ForeColor="Black" BackColor="Silver"></HeaderStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
