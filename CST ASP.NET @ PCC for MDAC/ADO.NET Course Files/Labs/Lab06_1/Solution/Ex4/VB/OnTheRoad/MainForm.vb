Public Class MainForm
    Inherits System.Windows.Forms.Form

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

        ' instantiate form
        Dim frmOptions As New Options()

        ' display last selected server
        frmOptions.txtServer.Text = Me.ServerName


        ' if user selects OK, change employee and load related data
        If frmOptions.ShowDialog(Me) = DialogResult.OK Then

            ' retrieve server name entered in the text box
            Me.ServerName = frmOptions.txtServer.Text

            ' set connection string using new server name
            Me.cnNorthwind.ConnectionString = _
                "data source=" & Me.ServerName & ";" & _
                "initial catalog=Northwind;" & _
                "integrated security=SSPI;" & _
                "persist security info=False;"

        End If

    End Sub


    Private Sub RefreshUI()

        ' TODO: bind grid to customers table in the data set

        ' refresh the title bar of the form to show the current employee

        Me.Text = dsNorthwind.Employees.Select( _
         "EmployeeID=" & Me.EmployeeID)(0)( _
         "FullName").ToString() _
         & " - " & Application.ProductName

    End Sub


    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' try to open existing local cached DataSet

        Try

            Me.dsNorthwind.ReadXml("OnTheRoad.xml", XmlReadMode.DiffGram)

            ' retrieve default values for EmployeeID and ServerName if found
            Me.EmployeeID = CInt(Me.dsNorthwind.AppSettings.Rows(0)("EmployeeID"))

            Me.ServerName = Me.dsNorthwind.AppSettings.Rows(0)("ServerName").ToString()

            Me.RefreshUI()

        Catch

            ' if local file not found, try to connect to central database and retrieve latest data set
            If MessageBox.Show("An existing data set was not found or was corrupt. Do you want to connect to the central database to retrieve a new copy?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                Try

                    Me.cnNorthwind.Open()
                    mnuFill_Click(sender, e)

                Catch Xcp As System.Exception

                    MessageBox.Show("Failed to connect because:" & vbCrLf & Xcp.ToString() & vbCrLf & vbCrLf & "Use Tools, Options to change the name of the SQL Server you are trying to connect to.", "Connect to central database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try

            End If

        End Try

    End Sub


    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

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

        ' instantiate the data set
        Dim tempNW As New OnTheRoad.NWDataSet()

        If Me.cnNorthwind.State <> ConnectionState.Open Then

            Try

                Me.cnNorthwind.Open()

            Catch Xcp As System.Exception

                MessageBox.Show("Failed to connect because:" & vbCrLf & Xcp.ToString() & vbCrLf & vbCrLf & "Try a different server name.", "Get from central database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try

        End If

        Try

            ' fill the Employees DataTable
            Me.daEmployees.Fill(tempNW.Employees)

        Catch Xcp As System.Exception

            MessageBox.Show("Failed to retrieve employee list because: " & vbCrLf & Xcp.ToString(), "Get from central database", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        ' create instance of logon form
        Dim frmLogon As New Logon()

        ' set the data properties to link the list box to the Employees table
        frmLogon.lstEmployees.DataSource = tempNW.Employees
        frmLogon.lstEmployees.DisplayMember = "FullName"
        frmLogon.lstEmployees.ValueMember = "EmployeeID"

        ' display the last selected employee
        frmLogon.lstEmployees.SelectedValue = Me.EmployeeID

        ' if user selects OK...
        If frmLogon.ShowDialog(Me) = DialogResult.OK Then

            ' change employee and load related data
            Me.EmployeeID = CInt(frmLogon.lstEmployees.SelectedValue)

            Me.dsNorthwind = tempNW

            Me.RefreshUI()

        End If

        Me.cnNorthwind.Close()

    End Sub


    Private Sub mnuUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdate.Click

        ' TODO: update the central database

    End Sub


End Class
