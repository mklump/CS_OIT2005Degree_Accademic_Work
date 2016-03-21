Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Windows Form Designer generated variables

    Friend WithEvents grd As System.Windows.Forms.DataGrid
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog

    
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents s1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents s2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem

    Friend WithEvents mnuView As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCustomer As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProducts As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuCartItems As System.Windows.Forms.MenuItem

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mnuOpen = New System.Windows.Forms.MenuItem()
        Me.mnuSave = New System.Windows.Forms.MenuItem()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.mnuNew = New System.Windows.Forms.MenuItem()
        Me.mnuView = New System.Windows.Forms.MenuItem()
        Me.mnuCustomer = New System.Windows.Forms.MenuItem()
        Me.mnuCartItems = New System.Windows.Forms.MenuItem()
        Me.mnuProducts = New System.Windows.Forms.MenuItem()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.s1 = New System.Windows.Forms.MenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem()
        Me.s2 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.grd = New System.Windows.Forms.DataGrid()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 1
        Me.mnuOpen.Text = "&Open..."
        '
        'mnuSave
        '
        Me.mnuSave.Index = 3
        Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSave.Text = "&Save"
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "DataSet files (*.ds)|*.ds|All files (*.*)|*.*"
        '
        'mnuNew
        '
        Me.mnuNew.Index = 0
        Me.mnuNew.Text = "&New"
        '
        'mnuView
        '
        Me.mnuView.Index = 1
        Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCustomer, Me.mnuCartItems, Me.mnuProducts})
        Me.mnuView.Text = "&View"
        '
        'mnuCustomer
        '
        Me.mnuCustomer.Index = 0
        Me.mnuCustomer.Shortcut = System.Windows.Forms.Shortcut.F7
        Me.mnuCustomer.Text = "&Customer"
        '
        'mnuCartItems
        '
        Me.mnuCartItems.Index = 1
        Me.mnuCartItems.Shortcut = System.Windows.Forms.Shortcut.ShiftF7
        Me.mnuCartItems.Text = "Cart &Items"
        '
        'mnuProducts
        '
        Me.mnuProducts.Index = 2
        Me.mnuProducts.Shortcut = System.Windows.Forms.Shortcut.CtrlF7
        Me.mnuProducts.Text = "&Products"
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "ds"
        Me.dlgSave.Filter = "DataSet files (*.ds)|*.ds"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuView})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuOpen, Me.s1, Me.mnuSave, Me.mnuSaveAs, Me.s2, Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        's1
        '
        Me.s1.Index = 2
        Me.s1.Text = "-"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Index = 4
        Me.mnuSaveAs.Text = "Save &As..."
        '
        's2
        '
        Me.s2.Index = 5
        Me.s2.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 6
        Me.mnuExit.Text = "E&xit"
        '
        'grd
        '
        Me.grd.DataMember = ""
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(368, 289)
        Me.grd.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 289)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grd})
        Me.Menu = Me.mnuMain
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click

        Me.Dispose()
        Me.Close()

    End Sub

End Class
