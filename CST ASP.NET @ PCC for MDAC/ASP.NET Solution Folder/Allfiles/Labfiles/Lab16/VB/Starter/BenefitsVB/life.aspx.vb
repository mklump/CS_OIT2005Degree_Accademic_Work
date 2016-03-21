Public Class life
    Inherits System.Web.UI.Page
    Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBirth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCoverage As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents chkShortTerm As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkLongTerm As System.Web.UI.WebControls.CheckBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents vldCoverageType As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

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
        If Not (Page.IsPostBack) Then
            Dim strName As String = CStr(Session("Name"))
            Dim strBirth As String = CStr(Session("Birth"))
            txtName.Text = strName
            txtBirth.Text = strBirth
        End If


    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, cmdSave.Click
        If Page.IsValid Then
            lblMessage.Text = "Valid!"

            'TODO Lab 14: Set Session Variables
            Session("Name") = txtName.Text
            Session("Birth") = txtBirth.Text

            Dim objCookie As HttpCookie = Request.Cookies("Benefits")
            Dim strDoc As String
            Dim strLife As String

            If Not objCookie Is Nothing Then
                strDoc = objCookie.Values("doctor")
                strLife = objCookie.Values("life")
            End If

            'TODO Lab 14: Build the string
            If (chkShortTerm.Checked) Then
                If (chkLongTerm.Checked) Then
                    strLife = "Short Term and Long Term"
                Else
                    strLife = "Short Term"
                End If
            ElseIf (chkLongTerm.Checked) Then
                strLife = "Long Term"
            End If

            strLife &= ": Coverage = $" & txtCoverage.Text

            Dim objNewCookie As New HttpCookie("Benefits")
            objNewCookie.Expires = DateTime.Now.AddDays(30)
            objNewCookie.Values.Add("doctor", strDoc)
            objNewCookie.Values.Add("life", strLife)
            Response.Cookies.Add(objNewCookie)
            Response.Redirect("default.aspx")

        End If
    End Sub

    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("default.aspx")
    End Sub
End Class
