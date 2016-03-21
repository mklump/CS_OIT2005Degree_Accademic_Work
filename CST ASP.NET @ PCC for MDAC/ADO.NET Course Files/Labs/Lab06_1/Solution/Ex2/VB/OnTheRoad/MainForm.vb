Public Class MainForm
    Inherits System.Windows.Forms.Form

    ' TODO: declare fields for EmployeeID and ServerName
    Friend EmployeeID As System.Int32 = 0
    Friend ServerName As System.String = "(local)"

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
    Friend WithEvents cnNorthwind As System.Data.SqlClient.SqlConnection
    Friend WithEvents daEmployees As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents cmSelectEmployees As System.Data.SqlClient.SqlCommand
    Friend WithEvents dsNorthwind As OnTheRoad.NWDataSet
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
        Me.daEmployees = New System.Data.SqlClient.SqlDataAdapter()
        Me.cmSelectEmployees = New System.Data.SqlClient.SqlCommand()
        Me.cnNorthwind = New System.Data.SqlClient.SqlConnection()
        Me.dsNorthwind = New OnTheRoad.NWDataSet()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsNorthwind, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grd.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(292, 273)
        Me.grd.TabIndex = 0
        '
        'daEmployees
        '
        Me.daEmployees.SelectCommand = Me.cmSelectEmployees
        Me.daEmployees.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Employees", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("FullName", "FullName")})})
        '
        'cmSelectEmployees
        '
        Me.cmSelectEmployees.CommandText = "SELECT EmployeeID, LastName + ', ' + FirstName AS FullName FROM Employees ORDER B" & _
        "Y LastName, FirstName"
        Me.cmSelectEmployees.Connection = Me.cnNorthwind
        '
        'cnNorthwind
        '
        Me.cnNorthwind.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" & _
        "curity info=False;"
        '
        'dsNorthwind
        '
        Me.dsNorthwind.DataSetName = "NWDataSet"
        Me.dsNorthwind.Locale = New System.Globalization.CultureInfo("en-US")
        Me.dsNorthwind.Namespace = "http://www.tempuri.org/NWDataSet.xsd"
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
        CType(Me.dsNorthwind, System.ComponentModel.ISupportInitialize).EndInit()
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

        ' clear any existing rows
        Me.dsNorthwind.AppSettings.Clear()

        ' insert a new blank row
        Me.dsNorthwind.AppSettings.AddAppSettingsRow(Me.EmployeeID, Me.ServerName)

        ' accept changes because we do not need to track
        Me.dsNorthwind.AppSettings.AcceptChanges()

        ' save as local cache
        Me.dsNorthwind.WriteXml("OnTheRoad.xml", XmlWriteMode.DiffGram)

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
