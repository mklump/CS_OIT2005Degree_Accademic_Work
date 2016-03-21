Imports System.Data.SqlClient

Public Class datareader
    Inherits System.Web.UI.Page
    Protected WithEvents lstBuiltNames As System.Web.UI.WebControls.ListBox
    Protected WithEvents lstBoundNames As System.Web.UI.WebControls.ListBox
            
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
        Dim dr As SqlDataReader
        Dim conn As SQLConnection
        Dim cmdAuthors As SQLCommand

        conn = New SqlConnection _
            ("data source=localhost;integrated security=true;initial catalog=pubs")
        conn.Open()
        cmdAuthors = New SQLCommand("select * from Authors", conn)

        'now bind the same datareader to a listbox
        dr = cmdAuthors.ExecuteReader()
        lstBoundNames.DataSource = dr
        lstBoundNames.DataTextField = "au_lname"
        lstBoundNames.DataBind()

        'now display (last name, first name) in a listbox
        'to do this you have to build the items for the listbox manually
        dr.Close()
        dr = cmdAuthors.ExecuteReader()
        Do While dr.Read()
            lstBuiltNames.Items.Add(dr("au_lname") + ", " + dr("au_fname"))
        Loop

        'close the datareader and the connection
        dr.Close()
        conn.Close()
    End Sub

End Class
