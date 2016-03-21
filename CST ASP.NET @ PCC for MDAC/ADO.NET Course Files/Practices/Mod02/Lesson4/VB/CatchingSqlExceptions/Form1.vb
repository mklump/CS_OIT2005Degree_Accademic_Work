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
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cnNorthwind As System.Data.SqlClient.SqlConnection
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cnNorthwind = New System.Data.SqlClient.SqlConnection()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(192, 24)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "Open"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(192, 64)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        '
        'cnNorthwind
        '
        Me.cnNorthwind.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" & _
        "curity info=False;workstation id=MARKPRI-SVR-01;packet size=4096"
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(40, 24)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.TabIndex = 2
        Me.txtServerName.Text = "(local)"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtServerName, Me.btnClose, Me.btnOpen})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

        Try

            cnNorthwind.ConnectionString = _
                "Data Source=" & txtServerName.Text & ";Connect Timeout=5;" & _
                "Initial Catalog=Northwind;Integrated Security=SSPI;"

            cnNorthwind.Open()

        Catch XcpSQL As System.Data.SqlClient.SqlException

            Dim se As SqlClient.SqlError

            For Each se In XcpSQL.Errors

                MessageBox.Show(se.Message, "SQL Error Level " & se.Class, _
                    MessageBoxButtons.OK, MessageBoxIcon.Information)

            Next

        Catch Xcp As System.Exception ' generic exception handler

            MessageBox.Show(Xcp.Message, "Unexpected Exception", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        cnNorthwind.Close()
        cnNorthwind.Dispose()

    End Sub

End Class
