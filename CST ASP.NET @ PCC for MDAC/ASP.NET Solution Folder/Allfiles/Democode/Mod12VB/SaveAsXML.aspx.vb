Imports System.Data.SqlClient

Public Class SaveAsXML
    Inherits System.Web.UI.Page
        
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents cmdSchema As System.Web.UI.WebControls.Button
    Protected WithEvents lnkXml As System.Web.UI.WebControls.HyperLink
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lnkSchema As System.Web.UI.WebControls.HyperLink

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Dim ds As DataSet
            ds = CreateDataSet()
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
        End If
    End Sub

    Private Function CreateDataSet() As DataSet
        Dim conn As SqlConnection
        Dim daTitles As SqlDataAdapter
        Dim myDataSet As New DataSet()

        'create a connection to the Pubs database    
        conn = New SqlConnection _
            ("data source=localhost;integrated security=true;initial catalog=pubs")

        'create a dataset with information from the authors table
        daTitles = New SqlDataAdapter _
            ("select title_id, title, price, pub_id from Titles", conn)
        myDataSet = New DataSet()
        daTitles.Fill(myDataSet, "Titles")
        Return myDataSet
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ds As DataSet
        ds = CreateDataSet()
        ds.WriteXml(Server.MapPath("Titles.xml"), XmlWriteMode.IgnoreSchema)
        lnkXml.NavigateUrl = "Titles.xml"
    End Sub

    Private Sub cmdSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSchema.Click
        Dim ds As DataSet
        ds = CreateDataSet()
        ds.WriteXmlSchema(Server.MapPath("Titles.xsd"))
        lnkSchema.NavigateUrl = "Titles.xsd"
    End Sub
End Class
