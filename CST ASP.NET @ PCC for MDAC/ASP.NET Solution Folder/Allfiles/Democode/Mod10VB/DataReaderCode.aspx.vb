Imports System.Data.SqlClient

Public Class DataReaderCode
    Inherits System.Web.UI.Page
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList4 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList5 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator2 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator3 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator4 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator5 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents CustomValidator6 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents CustomValidator7 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents DropDownList7 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DropDownList6 As System.Web.UI.WebControls.DropDownList

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

            aCode.Add("-----")
            aCode.Add("conn.Close()")
            aCode.Add("Dim cmdAuthors As New SqlCommand('select * from Authors', conn)")
            aCode.Add("dr = cmdAuthors.ExecuteReader()")
            aCode.Add("Dim dr As SqlDataReader")
            aCode.Add("Dim conn As New SqlConnection('valid connection string')")
            aCode.Add("conn.Open()")
            aCode.Add("dr.Close()")

            DropDownList1.DataSource = aCode
            DropDownList1.DataBind()
            DropDownList2.DataSource = aCode
            DropDownList2.DataBind()
            DropDownList3.DataSource = aCode
            DropDownList3.DataBind()
            DropDownList4.DataSource = aCode
            DropDownList4.DataBind()
            DropDownList5.DataSource = aCode
            DropDownList5.DataBind()
            DropDownList6.DataSource = aCode
            DropDownList6.DataBind()
            DropDownList7.DataSource = aCode
            DropDownList7.DataBind()
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
