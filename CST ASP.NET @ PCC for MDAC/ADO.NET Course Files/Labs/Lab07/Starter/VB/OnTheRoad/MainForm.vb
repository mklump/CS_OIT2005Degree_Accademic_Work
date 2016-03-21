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
    Friend WithEvents dsNorthwind As OnTheRoad.localhost.NWDataSet
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
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuOptions = New System.Windows.Forms.MenuItem()
        Me.s2 = New System.Windows.Forms.MenuItem()
        Me.mnuTools = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.grd = New System.Windows.Forms.DataGrid()
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuFill = New System.Windows.Forms.MenuItem()
        Me.mnuUpdate = New System.Windows.Forms.MenuItem()
        Me.dsNorthwind = New localhost.NWDataSet()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsNorthwind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuExit
        '
        Me.mnuExit.Index = 3
        Me.mnuExit.Text = "E&xit"
        '
        'mnuOptions
        '
        Me.mnuOptions.Index = 0
        Me.mnuOptions.Text = "&Options..."
        '
        's2
        '
        Me.s2.Index = 2
        Me.s2.Text = "-"
        '
        'mnuTools
        '
        Me.mnuTools.Index = 1
        Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOptions})
        Me.mnuTools.Text = "&Tools"
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
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuTools, Me.mnuHelp})
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

        Dim frmOptions As New Options()

        ' TODO: display last selected server

        frmOptions.txtServer.Text = Me.ServerName

        ' if user selects OK, change employee and load related data
        If frmOptions.ShowDialog(Me) = DialogResult.OK Then

            ' TODO: retrieve server name entered in the text box

            Me.ServerName = frmOptions.txtServer.Text

        End If

    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' TODO: try to read data set from local disk

        Try ' to open existing local cached DataSet

            Me.dsNorthwind.ReadXml("OnTheRoad.xml", XmlReadMode.DiffGram)

            ' TODO: retrieve default values for app settings if found

            Me.EmployeeID = _
                CInt(Me.dsNorthwind.AppSettings.Rows(0)("EmployeeID"))

            Me.ServerName = _
                Me.dsNorthwind.AppSettings.Rows(0)("ServerName").ToString()

            Me.RefreshUI()

        Catch

            ' TODO: if local file not found try to connect to web service and retrieve latest data set

            If MessageBox.Show("An existing data set was not found or was corrupt. Do you want to connect to the central database to retrieve a new copy?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                Try

                    ' TODO: connect to the web service

                    Dim wsSalesMgr As New OnTheRoad.localhost.SalesManager()

                Catch Xcp As System.Exception

                    MessageBox.Show("Failed to connect because:" & vbCrLf & Xcp.ToString & vbCrLf & vbCrLf & "Use Tools, Options to change the name of the web service you are trying to connect to.", "Connect to central database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try

                mnuFill_Click(sender, e)

            End If

        End Try

    End Sub

    Private Sub ResetAppSettings()

        ' TODO: store default values in AppSettings table

        ' clear any existing rows
        Me.dsNorthwind.AppSettings.Clear()

        ' insert a new blank row
        Me.dsNorthwind.AppSettings.AddAppSettingsRow(Me.EmployeeID, Me.ServerName)

        ' accept the changes to the table (we do not need to track)
        Me.dsNorthwind.AppSettings.AcceptChanges()

    End Sub

    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ResetAppSettings()

        ' save as local cache
        Me.dsNorthwind.WriteXml("OnTheRoad.xml", XmlWriteMode.DiffGram)

    End Sub

    Private Sub mnuFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFill.Click

        ' TODO: instantiate the data set

        Dim tempNW As New OnTheRoad.localhost.NWDataSet()

        ' TODO: instantiate the web service

        Dim wsSalesMgr As New OnTheRoad.localhost.SalesManager()

        wsSalesMgr.Credentials = System.Net.CredentialCache.DefaultCredentials

        ' TODO: connect to web service

        tempNW = wsSalesMgr.GetDataSet(Me.EmployeeID, Me.ServerName)

        ' create instance of logon form
        Dim frmLogon As New Logon()

        ' TODO: set the data properties to link the list box to the Employees table

        frmLogon.lstEmployees.DataSource = tempNW.Employees
        frmLogon.lstEmployees.DisplayMember = "FullName"
        frmLogon.lstEmployees.ValueMember = "EmployeeID"

        ' TODO: display the last selected employee

        frmLogon.lstEmployees.SelectedValue = Me.EmployeeID

        ' if user selects OK...
        If frmLogon.ShowDialog(Me) = DialogResult.OK Then

            ' TODO: change employee and load related data

            Me.EmployeeID = CInt(frmLogon.lstEmployees.SelectedValue)

            Try

                tempNW = wsSalesMgr.GetDataSet(Me.EmployeeID, Me.ServerName)

                Me.dsNorthwind = tempNW

                Me.RefreshUI()

            Catch Xcp As System.Exception

                MessageBox.Show("Failed to retrieve data because: " & vbCrLf & Xcp.ToString & vbCrLf & vbCrLf & "Try a different server name.", "Get from central database", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub

    Private Sub RefreshUI()

        ' TODO: refresh the title bar of the form to show the current employee

        Me.Text = Me.dsNorthwind.Employees.Select( _
            "EmployeeID=" & Me.EmployeeID)(0)("FullName").ToString() _
            & " - " & Application.ProductName

        ' TODO: bind grid to customers table in the data set

        Me.grd.SetDataBinding(Me.dsNorthwind, "Orders")

    End Sub

    Private Sub mnuUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdate.Click

        ' TODO: update the central database

        Dim wsSalesMgr As New OnTheRoad.localhost.SalesManager()

        wsSalesMgr.Credentials = System.Net.CredentialCache.DefaultCredentials

        Try ' to send the changes to the web service

            dsNorthwind.AcceptChanges()

            ' get the changes

            Dim dsChanges As System.Data.DataSet _
                = Me.dsNorthwind.GetChanges()

            If dsChanges Is Nothing Then

                MessageBox.Show("There are no changes to update!", "Update to central database", _
                    MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                ' add the app settings to the data set to pass the server name

                ResetAppSettings()

                dsChanges = Me.dsNorthwind.AppSettings

                ' call the web services update method

                wsSalesMgr.UpdateDatabase(CType(dsChanges, _
                    OnTheRoad.localhost.NWDataSet))

                ' mark the changes as having been made

                Me.dsNorthwind.AcceptChanges()

                If MessageBox.Show("Do you want to refresh your local copy of data?", _
                    "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                    DialogResult.Yes Then

                    ' simulate clicking the Fill menu item
                    mnuFill_Click(sender, e)

                End If

            End If

        Catch Xcp As System.Exception

            MessageBox.Show(Xcp.ToString())
            Exit Sub

        End Try

    End Sub

End Class
