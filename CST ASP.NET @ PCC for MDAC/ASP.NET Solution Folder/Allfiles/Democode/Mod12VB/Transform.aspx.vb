Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Xsl

Public Class Transform
    Inherits System.Web.UI.Page
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents cmdTransform As System.Web.UI.WebControls.Button

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private myDataSet As DataSet

    Private Sub cmdTransform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransform.Click
        'create and fill dataset
        myDataSet = CreateCustOrdersDataset()

        'save data into XmlDataDocument 
        Dim xmlDoc As New XmlDataDocument(myDataSet)

        'apply stylesheet and save into new XML file
        Dim xslTran As New XslTransform()
        xslTran.Load(Server.MapPath("CustomerOrders.xslt"))
        Dim writer As New XmlTextWriter(Server.MapPath("CustOrders_output.html"), System.Text.Encoding.UTF8)
        xslTran.Transform(xmlDoc, Nothing, writer)
        writer.Close()
        'attach hyperlink to the new file
        HyperLink1.NavigateUrl = "CustOrders_output.html"
    End Sub

    Private Function CreateCustOrdersDataset() As DataSet
        Dim nwindConn As New SqlConnection("Data Source=localhost;Initial Catalog=northwind;Integrated Security=SSPI")
        Dim custDA As New SqlDataAdapter("SELECT * FROM Customers", nwindConn)
        Dim myDataSet As New DataSet()
        custDA.Fill(myDataSet, "Customers")
        Dim ordersDA As New SqlDataAdapter("SELECT * FROM Orders", nwindConn)
        ordersDA.Fill(myDataSet, "Orders")

        'create and add relation between Customers and Orders tables
        myDataSet.Relations.Add("CustOrders", _
                myDataSet.Tables("Customers").Columns("CustomerID"), _
                myDataSet.Tables("Orders").Columns("CustomerID")).Nested = True

        Return myDataSet
    End Function
End Class
