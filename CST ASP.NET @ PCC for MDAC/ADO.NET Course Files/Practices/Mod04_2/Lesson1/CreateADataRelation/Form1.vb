Public Class Form1
    Inherits System.Windows.Forms.Form

    Private dsCatProd As New DataSet()

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(292, 273)
        Me.DataGrid1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' load an existing data set from a file

        dsCatProd.ReadXml("\Program Files\MSDNTrain\2389\Practices\Mod04_1\catprodnone.ds", XmlReadMode.ReadSchema)

        ' define some primary keys

        With dsCatProd.Tables("Categories")
            .Constraints.Add("PK_Categories", .Columns("CategoryID"), True)
        End With

        With dsCatProd.Tables("Products")
            .Constraints.Add("PK_Products", .Columns("ProductID"), True)
        End With

        ' Practice: write code to add a DataRelation object here

        dsCatProd.Relations.Add("FK_CategoriesProducts", _
            dsCatProd.Tables("Categories").Columns("CategoryID"), _
            dsCatProd.Tables("Products").Columns("CategoryID"), _
            True)

        ' bind to the data grid

        DataGrid1.DataSource = New DataView(dsCatProd.Tables("Categories"))

    End Sub

End Class
