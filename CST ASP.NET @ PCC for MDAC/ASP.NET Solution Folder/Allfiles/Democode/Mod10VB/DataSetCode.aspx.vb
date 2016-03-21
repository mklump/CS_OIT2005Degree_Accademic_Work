Imports System.Data.SqlClient

Public Class DataSetCode
    Inherits System.Web.UI.Page
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList4 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator2 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator3 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator4 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Label2.Text = ""
        If Not Page.IsPostBack Then
            Dim aCode As New ArrayList()
            aCode.Add("----")
            aCode.Add("Dim conn As New SqlConnection('valid connection string')")
            aCode.Add("da.Fill(ds, 'Authors')")
            aCode.Add("Dim da As New SqlDataAdapter('select * from Authors', conn)")
            aCode.Add("Dim ds As New DataSet()")

            DropDownList1.DataSource = aCode
            DropDownList1.DataBind()
            DropDownList2.DataSource = aCode
            DropDownList2.DataBind()
            DropDownList3.DataSource = aCode
            DropDownList3.DataBind()
            DropDownList4.DataSource = aCode
            DropDownList4.DataBind()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'there are a couple of valid answers. the required parts are declare before use, 
        'create conn, da, then dataset

        If Page.IsValid Then
            Label2.Text = "Good job! All answers are correct."
        Else
            Label2.Text = "Sorry, try again."
        End If
    End Sub

End Class
