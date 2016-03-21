Public Class OpenNewConnection
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

    Friend WithEvents btnOpenSQL As System.Windows.Forms.Button
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblSQLDatabase As System.Windows.Forms.Label
    Friend WithEvents cboDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents chkEnablePooling As System.Windows.Forms.CheckBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents cboUsername As System.Windows.Forms.ComboBox
    Friend WithEvents grpPooling As System.Windows.Forms.GroupBox
            Friend WithEvents chkResetConnection As System.Windows.Forms.CheckBox
        Friend WithEvents txtMinPoolSize As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxPoolSize As System.Windows.Forms.TextBox
    Friend WithEvents txtLifetime As System.Windows.Forms.TextBox
    Friend WithEvents cboPassword As System.Windows.Forms.ComboBox
    Friend WithEvents lblConnStr As System.Windows.Forms.Label
        Friend WithEvents btnCloseSQL As System.Windows.Forms.Button
    Friend WithEvents btnRelease As System.Windows.Forms.Button
    Friend WithEvents lblConStr As System.Windows.Forms.Label
    Friend WithEvents lblLifetime As System.Windows.Forms.Label
    Friend WithEvents lblMinPoolSize As System.Windows.Forms.Label
    Friend WithEvents lblMaxPoolSize As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblConStr = New System.Windows.Forms.Label()
        Me.grpPooling = New System.Windows.Forms.GroupBox()
        Me.lblLifetime = New System.Windows.Forms.Label()
        Me.lblMinPoolSize = New System.Windows.Forms.Label()
        Me.chkResetConnection = New System.Windows.Forms.CheckBox()
        Me.lblMaxPoolSize = New System.Windows.Forms.Label()
        Me.txtMinPoolSize = New System.Windows.Forms.TextBox()
        Me.txtMaxPoolSize = New System.Windows.Forms.TextBox()
        Me.txtLifetime = New System.Windows.Forms.TextBox()
        Me.cboPassword = New System.Windows.Forms.ComboBox()
        Me.lblConnStr = New System.Windows.Forms.Label()
        Me.chkEnablePooling = New System.Windows.Forms.CheckBox()
        Me.cboUsername = New System.Windows.Forms.ComboBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.btnOpenSQL = New System.Windows.Forms.Button()
        Me.btnRelease = New System.Windows.Forms.Button()
        Me.lblSQLDatabase = New System.Windows.Forms.Label()
        Me.btnCloseSQL = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.cboDatabase = New System.Windows.Forms.ComboBox()
        Me.grpPooling.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblConStr
        '
        Me.lblConStr.AutoSize = True
        Me.lblConStr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConStr.Location = New System.Drawing.Point(8, 112)
        Me.lblConStr.Name = "lblConStr"
        Me.lblConStr.Size = New System.Drawing.Size(98, 13)
        Me.lblConStr.TabIndex = 11
        Me.lblConStr.Text = "Connection String"
        '
        'grpPooling
        '
        Me.grpPooling.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLifetime, Me.lblMinPoolSize, Me.chkResetConnection, Me.lblMaxPoolSize, Me.txtMinPoolSize, Me.txtMaxPoolSize, Me.txtLifetime})
        Me.grpPooling.Enabled = False
        Me.grpPooling.Location = New System.Drawing.Point(200, 8)
        Me.grpPooling.Name = "grpPooling"
        Me.grpPooling.Size = New System.Drawing.Size(136, 144)
        Me.grpPooling.TabIndex = 7
        Me.grpPooling.TabStop = False
        '
        'lblLifetime
        '
        Me.lblLifetime.Location = New System.Drawing.Point(8, 112)
        Me.lblLifetime.Name = "lblLifetime"
        Me.lblLifetime.Size = New System.Drawing.Size(56, 16)
        Me.lblLifetime.TabIndex = 5
        Me.lblLifetime.Text = "Lifetime"
        '
        'lblMinPoolSize
        '
        Me.lblMinPoolSize.AutoSize = True
        Me.lblMinPoolSize.Location = New System.Drawing.Point(8, 24)
        Me.lblMinPoolSize.Name = "lblMinPoolSize"
        Me.lblMinPoolSize.Size = New System.Drawing.Size(73, 13)
        Me.lblMinPoolSize.TabIndex = 0
        Me.lblMinPoolSize.Text = "Min Pool Size"
        '
        'chkResetConnection
        '
        Me.chkResetConnection.Location = New System.Drawing.Point(8, 88)
        Me.chkResetConnection.Name = "chkResetConnection"
        Me.chkResetConnection.Size = New System.Drawing.Size(120, 16)
        Me.chkResetConnection.TabIndex = 4
        Me.chkResetConnection.Text = "Connection Reset"
        '
        'lblMaxPoolSize
        '
        Me.lblMaxPoolSize.AutoSize = True
        Me.lblMaxPoolSize.Location = New System.Drawing.Point(8, 48)
        Me.lblMaxPoolSize.Name = "lblMaxPoolSize"
        Me.lblMaxPoolSize.Size = New System.Drawing.Size(76, 13)
        Me.lblMaxPoolSize.TabIndex = 2
        Me.lblMaxPoolSize.Text = "Max Pool Size"
        '
        'txtMinPoolSize
        '
        Me.txtMinPoolSize.Location = New System.Drawing.Point(88, 24)
        Me.txtMinPoolSize.Name = "txtMinPoolSize"
        Me.txtMinPoolSize.Size = New System.Drawing.Size(40, 20)
        Me.txtMinPoolSize.TabIndex = 1
        Me.txtMinPoolSize.Text = "0"
        '
        'txtMaxPoolSize
        '
        Me.txtMaxPoolSize.Location = New System.Drawing.Point(88, 48)
        Me.txtMaxPoolSize.Name = "txtMaxPoolSize"
        Me.txtMaxPoolSize.Size = New System.Drawing.Size(40, 20)
        Me.txtMaxPoolSize.TabIndex = 3
        Me.txtMaxPoolSize.Text = "100"
        '
        'txtLifetime
        '
        Me.txtLifetime.Location = New System.Drawing.Point(88, 112)
        Me.txtLifetime.Name = "txtLifetime"
        Me.txtLifetime.Size = New System.Drawing.Size(40, 20)
        Me.txtLifetime.TabIndex = 6
        Me.txtLifetime.Text = "0"
        '
        'cboPassword
        '
        Me.cboPassword.DropDownWidth = 120
        Me.cboPassword.Items.AddRange(New Object() {"AmyJ", "JohnK"})
        Me.cboPassword.Location = New System.Drawing.Point(72, 64)
        Me.cboPassword.Name = "cboPassword"
        Me.cboPassword.Size = New System.Drawing.Size(120, 21)
        Me.cboPassword.TabIndex = 5
        '
        'lblConnStr
        '
        Me.lblConnStr.Location = New System.Drawing.Point(8, 128)
        Me.lblConnStr.Name = "lblConnStr"
        Me.lblConnStr.Size = New System.Drawing.Size(184, 120)
        Me.lblConnStr.TabIndex = 12
        '
        'chkEnablePooling
        '
        Me.chkEnablePooling.Location = New System.Drawing.Point(208, 8)
        Me.chkEnablePooling.Name = "chkEnablePooling"
        Me.chkEnablePooling.Size = New System.Drawing.Size(104, 16)
        Me.chkEnablePooling.TabIndex = 6
        Me.chkEnablePooling.Text = "Enable Pooling"
        '
        'cboUsername
        '
        Me.cboUsername.DropDownWidth = 120
        Me.cboUsername.Items.AddRange(New Object() {"AmyJ", "JohnK"})
        Me.cboUsername.Location = New System.Drawing.Point(72, 40)
        Me.cboUsername.Name = "cboUsername"
        Me.cboUsername.Size = New System.Drawing.Size(120, 21)
        Me.cboUsername.TabIndex = 3
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(8, 40)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(61, 13)
        Me.lblUserName.TabIndex = 2
        Me.lblUserName.Text = "User Name"
        '
        'btnOpenSQL
        '
        Me.btnOpenSQL.Location = New System.Drawing.Point(200, 160)
        Me.btnOpenSQL.Name = "btnOpenSQL"
        Me.btnOpenSQL.Size = New System.Drawing.Size(136, 24)
        Me.btnOpenSQL.TabIndex = 8
        Me.btnOpenSQL.Text = "Open"
        '
        'btnRelease
        '
        Me.btnRelease.Enabled = False
        Me.btnRelease.Location = New System.Drawing.Point(200, 224)
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(136, 24)
        Me.btnRelease.TabIndex = 10
        Me.btnRelease.Text = "Release Resources"
        '
        'lblSQLDatabase
        '
        Me.lblSQLDatabase.AutoSize = True
        Me.lblSQLDatabase.Location = New System.Drawing.Point(8, 16)
        Me.lblSQLDatabase.Name = "lblSQLDatabase"
        Me.lblSQLDatabase.Size = New System.Drawing.Size(53, 13)
        Me.lblSQLDatabase.TabIndex = 0
        Me.lblSQLDatabase.Text = "Database"
        '
        'btnCloseSQL
        '
        Me.btnCloseSQL.Enabled = False
        Me.btnCloseSQL.Location = New System.Drawing.Point(200, 192)
        Me.btnCloseSQL.Name = "btnCloseSQL"
        Me.btnCloseSQL.Size = New System.Drawing.Size(136, 24)
        Me.btnCloseSQL.TabIndex = 9
        Me.btnCloseSQL.Text = "Close"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(8, 64)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(54, 13)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password"
        '
        'cboDatabase
        '
        Me.cboDatabase.DropDownWidth = 120
        Me.cboDatabase.Items.AddRange(New Object() {"Northwind", "pubs"})
        Me.cboDatabase.Location = New System.Drawing.Point(72, 16)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Size = New System.Drawing.Size(120, 21)
        Me.cboDatabase.TabIndex = 1
        '
        'OpenNewConnection
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 261)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseSQL, Me.btnRelease, Me.lblConStr, Me.lblConnStr, Me.btnOpenSQL, Me.lblUserName, Me.lblSQLDatabase, Me.cboDatabase, Me.chkEnablePooling, Me.lblPassword, Me.cboUsername, Me.grpPooling, Me.cboPassword})
        Me.Name = "OpenNewConnection"
        Me.Text = "OpenNewConnection"
        Me.grpPooling.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents cnSQLNorthwind As System.Data.SQLClient.SqlConnection

    Private Sub btnOpenSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenSQL.Click
        Dim sConnStr As String

        sConnStr = "Data Source=localhost;" & _
            "Initial Catalog=" & cboDatabase.Text & ";" & _
            "User ID=" & cboUsername.Text & ";" & _
            "Password=" & cboPassword.Text & ";" & _
            "Pooling=" & (chkEnablePooling.Checked).ToString & ";" & _
            "Min Pool Size=" & txtMinPoolSize.Text & ";" & _
            "Max Pool Size=" & txtMaxPoolSize.Text & ";" & _
            "Connection Reset=" & (chkResetConnection.Checked).ToString & ";" & _
            "Connection Lifetime=" & txtLifetime.Text & ";"

        cnSQLNorthwind = New System.Data.SQLClient.SqlConnection(sConnStr)

        Try
            cnSQLNorthwind.Open()

        Catch XcpSQL As SqlClient.SqlException

            Select Case XcpSQL.Number
                Case 17
                    MessageBox.Show("Incorrect or missing server!")
                Case 4060
                    MessageBox.Show("Wrong or missing database!")
                Case 18456
                    MessageBox.Show("Incorrect or missing user name or password!")
                Case Else
                    MessageBox.Show(XcpSQL.Message, "SQL Server Error " & XcpSQL.Number)
            End Select

        Catch XcpNullRef As System.NullReferenceException

            MessageBox.Show(XcpNullRef.Message)

        Catch Xcp As System.Exception ' unexpected exception

            ' generic exception handler

            MessageBox.Show(Xcp.Message, "Unexpected Exception", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

        btnOpenSQL.Enabled = False
        btnCloseSQL.Enabled = True
        btnRelease.Enabled = True

    End Sub

    Private Sub btnCloseSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseSQL.Click

        ' Close the connection to data source; exception occurs if object doesn't exist

        cnSQLNorthwind.Close()

        btnCloseSQL.Enabled = False
        btnOpenSQL.Enabled = True

    End Sub

    Private Sub btnRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelease.Click

        ' Call Dispose method to release resources used by object

        cnSQLNorthwind.Dispose()

        ' Mark object as available to be released from memory; GC will remove
        ' on next garbage collection cycle

        cnSQLNorthwind = Nothing

        'Close the current window

        Me.Close()

    End Sub

    Private Sub chkEnablePooling_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnablePooling.CheckedChanged

        ' Only enable the Pooling group box if the check box is checked

        grpPooling.Enabled = chkEnablePooling.Checked

    End Sub

    Private Sub UpdateConnStrLabel(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cboDatabase.TextChanged, cboUsername.TextChanged, _
        cboPassword.TextChanged, chkEnablePooling.CheckedChanged, _
        chkResetConnection.CheckedChanged, txtMaxPoolSize.TextChanged, _
        txtMinPoolSize.TextChanged, txtLifetime.TextChanged

        lblConnStr.Text = "Data Source=localhost;" & vbCrLf & _
            "Initial Catalog=" & cboDatabase.Text & ";" & vbCrLf & _
            "User ID=" & cboUsername.Text & ";" & vbCrLf & _
            "Password=" & cboPassword.Text & ";" & vbCrLf & _
            "Pooling=" & (chkEnablePooling.Checked).ToString & ";" & vbCrLf & _
            "Min Pool Size=" & txtMinPoolSize.Text & ";" & vbCrLf & _
            "Max Pool Size=" & txtMaxPoolSize.Text & ";" & vbCrLf & _
            "Connection Reset=" & (chkResetConnection.Checked).ToString & ";" & vbCrLf & _
            "Connection Lifetime=" & txtLifetime.Text & ";"

    End Sub

    Private Sub OpenNewConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cboDatabase.Text = "Northwind"
        Me.cboUsername.Text = "JohnK"
        Me.cboPassword.Text = "JohnK"

    End Sub
End Class
