Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Xsl

Public Class TransformPubTitles
    Inherits System.Web.UI.Page
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
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

    Private Sub CreateDataSet()
        Dim conn As SqlConnection
        Dim daTitles As SqlDataAdapter
        Dim daPublishers As SqlDataAdapter

        'create a connection to the Pubs database    
        conn = New SqlConnection _
            ("data source=localhost;integrated security=true;initial catalog=pubs")

        'create the second DataTable
        daPublishers = New SqlDataAdapter _
            ("select pub_id, pub_name from Publishers", conn)
        myDataSet = New DataSet()
        daPublishers.Fill(myDataSet, "Publishers")

        'create a dataset with information from the authors table
        daTitles = New SqlDataAdapter _
            ("select title_id, title, price, pub_id from Titles", conn)
        daTitles.Fill(myDataSet, "Titles")

    End Sub

    Private Sub MakeDataRelation(ByVal bNest As Boolean)
        ' DataRelation requires two DataColumn (parent and child) and a name.
        Dim myDataRelation As DataRelation
        Dim parentColumn As DataColumn
        Dim childColumn As DataColumn
        'relationship: each publisher publishes many titles
        parentColumn = myDataSet.Tables("Publishers").Columns("pub_id")
        childColumn = myDataSet.Tables("Titles").Columns("pub_id")
        myDataRelation = New DataRelation("TitlePublishers", parentColumn, childColumn)
        'mark the dataRelation as nested so the XML looks correct
        myDataRelation.Nested = bNest
        myDataSet.Relations.Add(myDataRelation)
    End Sub

    Private Sub cmdTransform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransform.Click
        'create and fill dataset
        CreateDataSet()
        MakeDataRelation(True)

        'save data into XmlDataDocument 
        Dim xmlDoc As New XmlDataDocument(myDataSet)

        'apply stylesheet and save into new XML file
        Dim xslTran As New XslTransform()
        xslTran.Load(Server.MapPath("PubTitles.xsl"))
        Dim writer As New XmlTextWriter(Server.MapPath("PubTitles_output.html"), System.Text.Encoding.UTF8)
        xslTran.Transform(xmlDoc, Nothing, writer)
        writer.Close()
        'attach hyperlink to the new file
        HyperLink1.NavigateUrl = "PubTitles_output.html"
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CreateDataSet()
            MakeDataRelation(True)

            DataGrid1.DataSource = myDataSet
            DataGrid1.DataMember = "Publishers"
            DataGrid1.DataBind()
            DataGrid2.DataSource = myDataSet
            DataGrid2.DataMember = "Titles"
            DataGrid2.DataBind()

        End If

    End Sub
End Class
