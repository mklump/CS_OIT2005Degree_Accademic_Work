Public Class SQLSecurityModes
    Inherits System.Web.UI.Page
    Protected WithEvents cmdOpen As System.Web.UI.WebControls.Button
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrors As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rbnSecurityMethod As System.Web.UI.WebControls.RadioButtonList
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


    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        Dim strConn As String

        lblErrors.Text = ""
        DataGrid1.Visible = False

        If rbnSecurityMethod.SelectedIndex = 0 Then
            strConn = "data source=localhost;initial catalog=pubs;integrated security=true"
        Else
            strConn = "data source=localhost;initial catalog=pubs;user id=CohoUser;password=1Coho"
        End If

        Try
            Dim conn As New SqlClient.SqlConnection(strConn)
            Dim da As New SqlClient.SqlDataAdapter("select * from Publishers", conn)
            Dim ds As New DataSet()
            da.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            DataGrid1.Visible = True

        Catch ex1 As System.Data.SqlClient.SqlException
            Dim erData As SqlClient.SqlErrorCollection = ex1.Errors
            Dim strError As String
            Dim i As Integer
            For i = 0 To erData.Count - 1
                strError = ("Error " & i & ": " & _
                     erData(i).Number & ", " & erData(i).Class & ", " & erData(i).Message & _
                    "<br>")
                lblErrors.Text &= ("Error " & i & ": " & _
                     erData(i).Number & ", " & erData(i).Class & ", " & erData(i).Message & _
                    "<br>")
            Next i

            Select Case ex1.Number
                Case 17
                    lblErrors.Text &= "invalid server name"
                Case 156, 170 'bad SQL syntax
                    lblErrors.Text &= "incorrect syntax"
                Case 207 'bad field name in select
                    lblErrors.Text &= "invalid column name"
                Case 208 'bad table name in select
                    lblErrors.Text &= "invalid object name"
                Case 18452
                    lblErrors.Text &= "invalid user name"
                Case 18456
                    lblErrors.Text &= "invalid password"
                Case 4060
                    lblErrors.Text &= "invalid database"
            End Select
        Catch ex2 As System.Exception
            lblErrors.Text &= "Unexpected exception: " & ex2.Message & ". "
        End Try


    End Sub

  
End Class
