'Needed in order to use FormsAuthentication.RedirectFromLoginPage
Imports System.Web.Security

'Imports used by the function login in order to access the database
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class LoginDemo
    Inherits System.Web.UI.Page
    Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents cmdLogin As System.Web.UI.WebControls.Button


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
    End Sub



    '*******************************************************
    '
    ' Login() Function
    '
    ' The Login method validates a email/password pair
    ' against credentials stored in the Coho database.
    ' If the email/password pair is valid, the method returns
    ' the "EmployeeId" number of the employee.  Otherwise
    ' it returns an empty string.
    '
    '*******************************************************

    Function Login(ByVal strEmail As String, ByVal strPassword As String) As String

        'Retrieve the connection string from the <appSettings> section of Web.config
        Dim conStrCoho As String = ConfigurationSettings.AppSettings("conStrCoho")

        'Create Instance of Connection and Command Object
        Dim objConnection As SqlConnection = New SqlConnection(conStrCoho)
        Dim objCommand As SqlCommand = New SqlCommand("EmployeeLogin", objConnection)

        'Mark the Command as a SPROC
        objCommand.CommandType = CommandType.StoredProcedure


        'Add Parameters to SPROC

        'Email (user name) input parameter
        Dim parameterEmail As SqlParameter = New SqlParameter("@userName", SqlDbType.VarChar, 50)
        parameterEmail.Value = strEmail
        objCommand.Parameters.Add(parameterEmail)

        'Password input parameter
        Dim parameterPassword As SqlParameter = New SqlParameter("@password", SqlDbType.VarChar, 20)
        parameterPassword.Value = strPassword
        objCommand.Parameters.Add(parameterPassword)

        'EmployeeID output parameter
        Dim parameterEmployeeID As SqlParameter = New SqlParameter("@employeeID", SqlDbType.Int, 4)
        parameterEmployeeID.Direction = ParameterDirection.Output
        objCommand.Parameters.Add(parameterEmployeeID)

        Try
            'Open the connection and execute the Command
            objConnection.Open()
            objCommand.ExecuteNonQuery()
        Catch e As Exception
            'An error occurred
            lblInfo.Text = "Error of connection to the database, please try again later."
        Finally
            'Close the Connection
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try

        Dim EmployeeId As Integer = CInt(parameterEmployeeID.Value)

        If EmployeeId = 0 Then
            Return ""
        Else
            Return EmployeeId.ToString()
        End If

    End Function




    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        Dim strCustomerID As String

        'Attempt to validate User Credentials 
        strCustomerID = Login(txtUserName.Text, txtPassword.Text)

        If (strCustomerID <> "") Then
            'Redirect browser back to originating page
            'and generate a non-persistant authentication cookie containing
            'the strCustomerID
            FormsAuthentication.RedirectFromLoginPage(strCustomerID, False)
        Else
            'Otherwise display an error message
            lblInfo.Text = "Login Failed!"
        End If

    End Sub
End Class
