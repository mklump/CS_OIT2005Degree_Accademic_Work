Imports System.Data.SqlClient
Imports System.Text

Public Class doctors1
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblSpecialties As System.Web.UI.WebControls.Label
    Protected WithEvents lstSpecialties As System.Web.UI.WebControls.ListBox
    Protected WithEvents cmdSubmit As System.Web.UI.WebControls.Button

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
        If Not Page.IsPostBack Then
            'TODO Lab 9: bind the datagrid to the doctors table


            'TODO Lab10: bind the listbox to city field in the doctors table


            'TODO Lab11: bind the listbox to the getUniqueCities stored procedure


            'TODO Lab10: add the "All" item to the list and select it


            'hide the specialties listbox
            lstSpecialties.Visible = False
            lblSpecialties.Visible = False

        End If
    End Sub

    Private Sub reset()
        'reset page index to 0
        dgDoctors.CurrentPageIndex = 0

        'remove the selection from the datagrid
        dgDoctors.SelectedIndex = -1

        'hide the specialites listbox
        lstSpecialties.Visible = False
        lblSpecialties.Visible = False
    End Sub

End Class
