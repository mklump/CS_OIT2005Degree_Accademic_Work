Imports System.Data.SqlClient
Imports System.Xml

Public Class SaveNestedXML
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
    Protected WithEvents cmdSaveNested As System.Web.UI.WebControls.Button
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents lnkNestedXML As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkXML As System.Web.UI.WebControls.HyperLink

#End Region
    Private myDataSet As DataSet

    Private Sub CreateDataSet()
        Dim conn As SqlConnection
        Dim daTitles As SqlDataAdapter
        Dim daPublishers As SqlDataAdapter

        'create a connection to the Pubs database    
        conn = New SqlConnection _
            ("data source=localhost;integrated security=true;initial catalog=pubs")

        'create a dataset with information from the authors table
        daTitles = New SqlDataAdapter _
            ("select title_id, title, price, pub_id from Titles", conn)
        myDataSet = New DataSet()
        daTitles.Fill(myDataSet, "Titles")

        'create the second DataTable
        daPublishers = New SqlDataAdapter _
            ("select pub_id, pub_name from Publishers", conn)
        daPublishers.Fill(myDataSet, "Publishers")
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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        CreateDataSet()
        MakeDataRelation(False)
        myDataSet.WriteXml(Server.MapPath("PubTitlesNotNested.xml"), XmlWriteMode.IgnoreSchema)
        lnkXML.NavigateUrl = "PubTitlesNotNested.xml"
    End Sub

    Private Sub cmdSaveNested_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveNested.Click
        CreateDataSet()
        MakeDataRelation(True)
        myDataSet.WriteXml(Server.MapPath("PubTitlesNested.xml"), XmlWriteMode.IgnoreSchema)
        lnkNestedXML.NavigateUrl = "PubTitlesNested.xml"
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
