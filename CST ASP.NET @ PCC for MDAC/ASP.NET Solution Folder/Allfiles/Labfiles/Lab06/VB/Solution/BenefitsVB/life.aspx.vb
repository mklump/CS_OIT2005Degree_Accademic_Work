Public Class life
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBirth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCoverage As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkShortTerm As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkLongTerm As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBeneficiaryName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button

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
        'Trace.Warn("2310", "Beginning of Page_Load of life.aspx")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
            
            'TODO Lab 14: Set Session Variables

            'TODO Lab 14: Build the string
            'If (chkShortTerm.Checked) Then
            '    If (chkLongTerm.Checked) Then
            '        strLife = "Short Term and Long Term"
            '    Else
            '        strLife = "Short Term"
            '    End If
            'ElseIf (chkLongTerm.Checked) Then
            '    strLife = "Long Term"
            'End If
            'strLife &= ": Coverage = $" & txtCoverage.Text
    End Sub
End Class
