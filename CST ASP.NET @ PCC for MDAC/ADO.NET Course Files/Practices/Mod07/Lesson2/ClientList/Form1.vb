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
    Friend WithEvents btnGetClients As System.Windows.Forms.Button
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents dgrCustGrid As System.Windows.Forms.DataGrid
    Friend WithEvents CustDS1 As ClientList.localhost.CustDS

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgrCustGrid = New System.Windows.Forms.DataGrid()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.btnGetClients = New System.Windows.Forms.Button()
        Me.CustDS1 = New ClientList.localhost.CustDS()
        CType(Me.dgrCustGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgrCustGrid
        '
        Me.dgrCustGrid.DataMember = ""
        Me.dgrCustGrid.DataSource = Me.CustDS1.Customers
        Me.dgrCustGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrCustGrid.Location = New System.Drawing.Point(0, 20)
        Me.dgrCustGrid.Name = "dgrCustGrid"
        Me.dgrCustGrid.Size = New System.Drawing.Size(472, 221)
        Me.dgrCustGrid.TabIndex = 2
        '
        'txtCity
        '
        Me.txtCity.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(472, 20)
        Me.txtCity.TabIndex = 1
        Me.txtCity.Text = "Enter A City"
        '
        'btnGetClients
        '
        Me.btnGetClients.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnGetClients.Location = New System.Drawing.Point(0, 241)
        Me.btnGetClients.Name = "btnGetClients"
        Me.btnGetClients.Size = New System.Drawing.Size(472, 32)
        Me.btnGetClients.TabIndex = 0
        Me.btnGetClients.Text = "List Customers"
        '
        'CustDS1
        '
        Me.CustDS1.DataSetName = "CustDS"
        Me.CustDS1.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CustDS1.Namespace = "http://www.tempuri.org/CustDS.xsd"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgrCustGrid, Me.txtCity, Me.btnGetClients})
        Me.Name = "Form1"
        Me.Text = "Create A Customer List"
        CType(Me.dgrCustGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustDS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnGetClients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetClients.Click
        Dim ws As New ClientList.localhost.Service1()
        ws.Credentials = System.Net.CredentialCache.DefaultCredentials
        CustDS1.Merge(ws.GetCustomers(txtCity.Text))
    End Sub


    Private Sub dgrCustGrid_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dgrCustGrid.Navigate

    End Sub
End Class
