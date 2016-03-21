'Imports used by the function login in order to access the database
Imports System
Imports System.Data
Imports System.Data.SqlClient

'Imports statment used for forms-based authentication
Imports System.Web.Security


Public Class register
    Inherits System.Web.UI.Page
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents vldEmailReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtConfirmPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdValidation As System.Web.UI.WebControls.Button
    Protected WithEvents vldPasswordReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents vldConfirmPasswordReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents vldConfirmPasswordComp As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents vldSummary As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents vldEmailExpr As System.Web.UI.WebControls.RegularExpressionValidator

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
    ' AddEmployee() Function
    '
    ' The AddCustomer method inserts a new employee record
    ' into the Coho database.  A unique "EmployeeId"
    ' key is then returned from the method.  This can be 
    ' used later within the Web application.
    '
    '*******************************************************


    Public Function AddEmployee(ByVal strEmail As String, ByVal strPassword As String) As String

        'Retrieve the connection string from the <appSettings> section of Web.config
        Dim conStrCoho As String = ConfigurationSettings.AppSettings("conStrCoho")

        'Create Instance of Connection and Command Object
        Dim objConnection As SqlConnection = New SqlConnection(conStrCoho)
        Dim objCommand As SqlCommand = New SqlCommand("EmployeeAdd", objConnection)

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

        'Return the EmployeeID Output Param from SPROC
        Dim EmployeeId As Integer
        EmployeeId = CInt(parameterEmployeeID.Value)

        Return EmployeeId.ToString()

    End Function



    Private Sub cmdValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidation.Click

        'Only attempt a validation if all form fields on this
        'page are valid

        If Page.IsValid Then

            'ID of a employee
            Dim strEmployeeId As String

            'TODO Lab 16: Call the AddEmployee function
            'Add new employee to Coho database
            strEmployeeId = AddEmployee(txtEmail.Text, txtPassword.Text)

            If (strEmployeeId <> "") Then

                'TODO Lab 16: Login users and generate an auth. cookie
                'Set the user's authentication name to the customerId
                FormsAuthentication.SetAuthCookie(strEmployeeId, False)

                'Redirect browser back to default page
                Response.Redirect("default.aspx")

            End If

        End If
    End Sub
End Class
