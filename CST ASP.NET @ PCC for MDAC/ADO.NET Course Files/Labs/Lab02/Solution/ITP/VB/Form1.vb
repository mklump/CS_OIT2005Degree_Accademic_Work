Public Class Form1
    Inherits System.Windows.Forms.Form

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

    Friend WithEvents grpOleDb As System.Windows.Forms.GroupBox
    Friend WithEvents grpSQLClient As System.Windows.Forms.GroupBox
    Friend WithEvents lblProvider As System.Windows.Forms.Label
    Friend WithEvents txtProvider As System.Windows.Forms.TextBox
    Friend WithEvents lblOleDbDatabase As System.Windows.Forms.Label
    Friend WithEvents txtOleDbDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents lblSQLDatabase As System.Windows.Forms.Label
    Friend WithEvents txtSQLDatabase As System.Windows.Forms.TextBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenSQL As System.Windows.Forms.Button
    Friend WithEvents btnCloseSQL As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnOpenOleDb As System.Windows.Forms.Button
    Friend WithEvents btnCloseOleDb As System.Windows.Forms.Button
    Friend WithEvents chkIntegratedSecurity As System.Windows.Forms.CheckBox
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblTimeout As System.Windows.Forms.Label
    Friend WithEvents txtTimeout As System.Windows.Forms.TextBox
    Friend WithEvents cnOleDbNorthwind As System.Data.OleDb.OleDbConnection

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtProvider = New System.Windows.Forms.TextBox()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.btnCloseOleDb = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblOleDbDatabase = New System.Windows.Forms.Label()
        Me.lblTimeout = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtSQLDatabase = New System.Windows.Forms.TextBox()
        Me.cnOleDbNorthwind = New System.Data.OleDb.OleDbConnection()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.btnOpenSQL = New System.Windows.Forms.Button()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.chkIntegratedSecurity = New System.Windows.Forms.CheckBox()
        Me.lblSQLDatabase = New System.Windows.Forms.Label()
        Me.grpSQLClient = New System.Windows.Forms.GroupBox()
        Me.btnCloseSQL = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblProvider = New System.Windows.Forms.Label()
        Me.txtOleDbDatabase = New System.Windows.Forms.TextBox()
        Me.btnOpenOleDb = New System.Windows.Forms.Button()
        Me.grpOleDb = New System.Windows.Forms.GroupBox()
        Me.grpSQLClient.SuspendLayout()
        Me.grpOleDb.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtProvider
        '
        Me.txtProvider.Location = New System.Drawing.Point(64, 24)
        Me.txtProvider.Name = "txtProvider"
        Me.txtProvider.Size = New System.Drawing.Size(320, 20)
        Me.txtProvider.TabIndex = 1
        Me.txtProvider.Text = "Microsoft.Jet.OLEDB.4.0"
        '
        'txtTimeout
        '
        Me.txtTimeout.Location = New System.Drawing.Point(64, 72)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(120, 20)
        Me.txtTimeout.TabIndex = 10
        Me.txtTimeout.Text = "15"
        '
        'btnCloseOleDb
        '
        Me.btnCloseOleDb.Location = New System.Drawing.Point(304, 80)
        Me.btnCloseOleDb.Name = "btnCloseOleDb"
        Me.btnCloseOleDb.TabIndex = 1
        Me.btnCloseOleDb.Text = "Close"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(264, 48)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(120, 20)
        Me.txtUsername.TabIndex = 5
        Me.txtUsername.Text = "sa"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(312, 280)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        '
        'lblOleDbDatabase
        '
        Me.lblOleDbDatabase.Location = New System.Drawing.Point(8, 48)
        Me.lblOleDbDatabase.Name = "lblOleDbDatabase"
        Me.lblOleDbDatabase.Size = New System.Drawing.Size(56, 16)
        Me.lblOleDbDatabase.TabIndex = 2
        Me.lblOleDbDatabase.Text = "Database"
        '
        'lblTimeout
        '
        Me.lblTimeout.AutoSize = True
        Me.lblTimeout.Location = New System.Drawing.Point(8, 72)
        Me.lblTimeout.Name = "lblTimeout"
        Me.lblTimeout.Size = New System.Drawing.Size(45, 13)
        Me.lblTimeout.TabIndex = 9
        Me.lblTimeout.Text = "Timeout"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(264, 72)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtPassword.TabIndex = 7
        Me.txtPassword.Text = ""
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(64, 24)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(120, 20)
        Me.txtServer.TabIndex = 1
        Me.txtServer.Text = "localhost"
        '
        'txtSQLDatabase
        '
        Me.txtSQLDatabase.Location = New System.Drawing.Point(64, 48)
        Me.txtSQLDatabase.Name = "txtSQLDatabase"
        Me.txtSQLDatabase.Size = New System.Drawing.Size(120, 20)
        Me.txtSQLDatabase.TabIndex = 3
        Me.txtSQLDatabase.Text = "Northwind"
        '
        'cnOleDbNorthwind
        '
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(200, 48)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(61, 13)
        Me.lblUserName.TabIndex = 4
        Me.lblUserName.Text = "User Name"
        '
        'btnOpenSQL
        '
        Me.btnOpenSQL.Location = New System.Drawing.Point(224, 104)
        Me.btnOpenSQL.Name = "btnOpenSQL"
        Me.btnOpenSQL.TabIndex = 2
        Me.btnOpenSQL.Text = "Open"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(8, 24)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(38, 13)
        Me.lblServer.TabIndex = 0
        Me.lblServer.Text = "Server"
        '
        'chkIntegratedSecurity
        '
        Me.chkIntegratedSecurity.Location = New System.Drawing.Point(200, 24)
        Me.chkIntegratedSecurity.Name = "chkIntegratedSecurity"
        Me.chkIntegratedSecurity.Size = New System.Drawing.Size(128, 16)
        Me.chkIntegratedSecurity.TabIndex = 8
        Me.chkIntegratedSecurity.Text = "Integrated Security"
        '
        'lblSQLDatabase
        '
        Me.lblSQLDatabase.AutoSize = True
        Me.lblSQLDatabase.Location = New System.Drawing.Point(8, 48)
        Me.lblSQLDatabase.Name = "lblSQLDatabase"
        Me.lblSQLDatabase.Size = New System.Drawing.Size(53, 13)
        Me.lblSQLDatabase.TabIndex = 2
        Me.lblSQLDatabase.Text = "Database"
        '
        'grpSQLClient
        '
        Me.grpSQLClient.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTimeout, Me.lblTimeout, Me.chkIntegratedSecurity, Me.btnCloseSQL, Me.btnOpenSQL, Me.txtPassword, Me.lblPassword, Me.txtUsername, Me.lblUserName, Me.txtSQLDatabase, Me.lblSQLDatabase, Me.txtServer, Me.lblServer})
        Me.grpSQLClient.Location = New System.Drawing.Point(8, 8)
        Me.grpSQLClient.Name = "grpSQLClient"
        Me.grpSQLClient.Size = New System.Drawing.Size(392, 136)
        Me.grpSQLClient.TabIndex = 5
        Me.grpSQLClient.TabStop = False
        Me.grpSQLClient.Text = "Exercises 1 and 2: Connecting to a SQL Server data source"
        '
        'btnCloseSQL
        '
        Me.btnCloseSQL.Location = New System.Drawing.Point(304, 104)
        Me.btnCloseSQL.Name = "btnCloseSQL"
        Me.btnCloseSQL.TabIndex = 3
        Me.btnCloseSQL.Text = "Close"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(200, 72)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(54, 13)
        Me.lblPassword.TabIndex = 6
        Me.lblPassword.Text = "Password"
        '
        'lblProvider
        '
        Me.lblProvider.Location = New System.Drawing.Point(8, 24)
        Me.lblProvider.Name = "lblProvider"
        Me.lblProvider.Size = New System.Drawing.Size(64, 16)
        Me.lblProvider.TabIndex = 0
        Me.lblProvider.Text = "Provider"
        '
        'txtOleDbDatabase
        '
        Me.txtOleDbDatabase.Location = New System.Drawing.Point(64, 48)
        Me.txtOleDbDatabase.Name = "txtOleDbDatabase"
        Me.txtOleDbDatabase.Size = New System.Drawing.Size(320, 20)
        Me.txtOleDbDatabase.TabIndex = 3
        Me.txtOleDbDatabase.Text = "\Program Files\Microsoft Office\Office10\Samples\Northwind.mdb"
        '
        'btnOpenOleDb
        '
        Me.btnOpenOleDb.Location = New System.Drawing.Point(224, 80)
        Me.btnOpenOleDb.Name = "btnOpenOleDb"
        Me.btnOpenOleDb.TabIndex = 0
        Me.btnOpenOleDb.Text = "Open"
        '
        'grpOleDb
        '
        Me.grpOleDb.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseOleDb, Me.btnOpenOleDb, Me.txtOleDbDatabase, Me.lblOleDbDatabase, Me.txtProvider, Me.lblProvider})
        Me.grpOleDb.Location = New System.Drawing.Point(8, 152)
        Me.grpOleDb.Name = "grpOleDb"
        Me.grpOleDb.Size = New System.Drawing.Size(392, 112)
        Me.grpOleDb.TabIndex = 4
        Me.grpOleDb.TabStop = False
        Me.grpOleDb.Text = "Exercise 4: Connecting to an OLE DB data source"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 317)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExit, Me.grpSQLClient, Me.grpOleDb})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.grpSQLClient.ResumeLayout(False)
        Me.grpOleDb.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOpenOleDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenOleDb.Click

        Try
            ' Instantiate connection using string built from contents of two
            ' text boxes in Exercise 4 group box

            Me.cnOleDbNorthwind.ConnectionString = _
                "Provider=" & Me.txtProvider.Text & ";" & _
                "Data Source=" & Me.txtOleDbDatabase.Text & ";"

            ' Open the connection

            Me.cnOleDbNorthwind.Open()

        Catch Xcp As System.Exception ' unexpected exception

            ' generic exception handler

            MessageBox.Show(Xcp.Message, "Unexpected Exception", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    Private Sub btnCloseOleDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOleDb.Click

        Try

            ' Close the connection to data source

            Me.cnOleDbNorthwind.Close()

            ' Call Dispose method to release resources used by object

            Me.cnOleDbNorthwind.Dispose()

        Catch Xcp As System.Exception ' unexpected exception

            ' generic exception handler

            MessageBox.Show(Xcp.Message, "Unexpected Exception", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    Private Sub cnOleDbNorthwind_StateChange(ByVal sender As System.Object, ByVal e As System.Data.StateChangeEventArgs) Handles cnOleDbNorthwind.StateChange

        ' Display current and orginial state in a message box whenever 
        ' the connection state changes

        MessageBox.Show( _
            "CurrentState: " & e.CurrentState.ToString() & ", " & _
            "OriginalState: " & e.OriginalState.ToString(), _
            "cnOleDbNorthwind.State", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)

    End Sub

    Private Sub chkIntegratedSecurity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIntegratedSecurity.CheckedChanged

        ' disable the username and password text boxes when 
        ' integrated security is checked

        Me.txtUsername.Enabled = Not Me.chkIntegratedSecurity.Checked
        Me.txtPassword.Enabled = Not Me.chkIntegratedSecurity.Checked

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        ' dispose and close the form

        Me.Dispose()
        Me.Close()

    End Sub

End Class
