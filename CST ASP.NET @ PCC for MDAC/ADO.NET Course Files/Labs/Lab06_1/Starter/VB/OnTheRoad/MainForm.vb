Public Class MainForm
    Inherits System.Windows.Forms.Form

    ' TODO: declare fields for EmployeeID and ServerName


    Friend WithEvents mnuFill As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUpdate As System.Windows.Forms.MenuItem
    Friend WithEvents s2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuOptions As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents mnu As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents grd As System.Windows.Forms.DataGrid

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuFill = New System.Windows.Forms.MenuItem()
        Me.mnuUpdate = New System.Windows.Forms.MenuItem()
        Me.s2 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuTools = New System.Windows.Forms.MenuItem()
        Me.mnuOptions = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.grd = New System.Windows.Forms.DataGrid()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFill, Me.mnuUpdate, Me.s2, Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuFill
        '
        Me.mnuFill.Index = 0
        Me.mnuFill.Text = "&Get from central database..."
        '
        'mnuUpdate
        '
        Me.mnuUpdate.Index = 1
        Me.mnuUpdate.Text = "&Update to central database"
        '
        's2
        '
        Me.s2.Index = 2
        Me.s2.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 3
        Me.mnuExit.Text = "E&xit"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuTools, Me.mnuHelp})
        '
        'mnuTools
        '
        Me.mnuTools.Index = 1
        Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOptions})
        Me.mnuTools.Text = "&Tools"
        '
        'mnuOptions
        '
        Me.mnuOptions.Index = 0
        Me.mnuOptions.Text = "&Options..."
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 2
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "&About..."
        '
        'grd
        '
        Me.grd.DataMember = ""
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(292, 273)
        Me.grd.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grd})
        Me.Menu = Me.mnuMain
        Me.Name = "MainForm"
        Me.Text = "On The Road"
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click

        Dim frmAbout As New About()
        frmAbout.ShowDialog(Me)

    End Sub


    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click

        Me.Close()
        Me.Dispose()

    End Sub


    Private Sub mnuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptions.Click

        ' TODO: create instance of Options form

        ' TODO: display last selected server

        ' TODO: show dialog box, and test if user selects OK...

            ' TODO: retrieve server name entered in the text box

            ' TODO: set connection string using new server name

    End Sub


    Private Sub RefreshUI()

        ' TODO: bind grid to customers table in the data set

        ' TODO: refresh the title bar of the form to show the current employee

    End Sub


    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' TODO: try to read data set from local disk

        ' TODO: retrieve default values for EmployeeID and ServerName if found

        ' TODO: if local file not found try to connect to central database and retrieve latest data set

    End Sub


    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ' TODO: store default values in AppSettings table

        ' TODO: save data set to disk

    End Sub


    Private Sub mnuFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFill.Click

        ' TODO: instantiate the data set

        ' TODO: create instance of Logon form

        ' TODO: set the data properties to link the list box to the Employees table

        ' TODO: display the last selected employee

        ' TODO: show dialog box, and test if user selects OK...

            ' TODO: change employee and load related data

        ' TODO: close datebase connection

    End Sub


    Private Sub mnuUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdate.Click

        ' TODO: update the central database

    End Sub


End Class
