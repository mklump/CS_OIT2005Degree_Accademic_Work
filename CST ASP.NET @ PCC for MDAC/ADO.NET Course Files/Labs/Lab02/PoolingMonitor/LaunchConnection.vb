Public Class LaunchConnection
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

    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtConName As System.Windows.Forms.TextBox
    Friend WithEvents lblConnection As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtConName = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.lblConnection = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtConName
        '
        Me.txtConName.Location = New System.Drawing.Point(8, 24)
        Me.txtConName.Name = "txtConName"
        Me.txtConName.Size = New System.Drawing.Size(240, 20)
        Me.txtConName.TabIndex = 1
        Me.txtConName.Text = "Enter a Connection Name"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(176, 56)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(56, 56)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(112, 24)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New Connection"
        '
        'lblConnection
        '
        Me.lblConnection.AutoSize = True
        Me.lblConnection.Location = New System.Drawing.Point(8, 8)
        Me.lblConnection.Name = "lblConnection"
        Me.lblConnection.Size = New System.Drawing.Size(95, 13)
        Me.lblConnection.TabIndex = 0
        Me.lblConnection.Text = "Connection Name"
        '
        'LaunchConnection
        '
        Me.AcceptButton = Me.btnNew
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(264, 93)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExit, Me.btnNew, Me.txtConName, Me.lblConnection})
        Me.Name = "LaunchConnection"
        Me.Text = "Launch Connection"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim mycon As New OpenNewConnection()

        mycon.Text = txtConName.Text

        mycon.Show()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub txtConName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConName.Enter

        txtConName.SelectAll()

    End Sub

End Class
