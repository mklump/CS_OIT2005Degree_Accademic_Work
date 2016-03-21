Imports System.IO
Imports System.Data
Imports System.Xml

Public Class form1

    Inherits System.Windows.Forms.Form


    Private Const myDocument As String = "C:\Program Files\MSDNTrain\2389\Labs\Lab05\customers.xml"
    Private Const myLoadSchema As String = "C:\Program Files\MSDNTrain\2389\Labs\Lab05\customerschema.xsd"
    Private myDS As DataSet

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
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnLoadData = New System.Windows.Forms.Button()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(472, 429)
        Me.DataGrid1.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(496, 344)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 48)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(496, 280)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(88, 56)
        Me.btnLoadData.TabIndex = 1
        Me.btnLoadData.Text = "Display Customer Information"
        '
        'form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 429)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.btnLoadData, Me.DataGrid1})
        Me.Name = "form1"
        Me.Text = "Sales Information"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
        Try
            myDS = New DataSet()
            ParseSchema(myLoadSchema)
            myDS.ReadXml(myDocument, XmlReadMode.IgnoreSchema)

            ' Use the followingto impliment a solution using inferred schema:
            ' Do not call ParseSchema.
            ' Substitute the call to readxml with the follwoing code -
            '
            'myDS.ReadXml(myDocument, XmlReadMode.InferSchema)

            DataGrid1.DataSource = myDS.Tables("customers")
        Catch x As Exception
            Console.WriteLine("Exception: " & e.ToString())
        End Try
    End Sub

    Public Sub ParseSchema(ByVal schema As String)

        Dim myStreamReader As StreamReader = Nothing
        Try
            myStreamReader = New StreamReader(schema)
            Console.WriteLine("Reading Schema file ...")
            myDS.ReadXmlSchema(myStreamReader)

        Catch e As Exception
            Console.WriteLine("Exception: " & e.ToString())

        Finally
            If Not myStreamReader Is Nothing Then
                myStreamReader.Close()
            End If

        End Try
    End Sub


End Class
