Imports System.xml
Imports System.IO


Public Class Form1


    Inherits System.Windows.Forms.Form


    Private Const myLoadSchema As String = "..\..\personpet.xsd"

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
        Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(436, 216)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 58)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Close"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(41, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(176, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(240, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "# of Tables"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(41, 81)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(341, 186)
        Me.ListBox1.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(436, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 58)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Get Schema"
        '
        'Form1
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(557, 298)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.Label1, Me.TextBox1, Me.Button2, Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, j As Integer

        Try
            myDS = New DataSet()
            Console.WriteLine("Creating an XmlDataDocument ...")
            ParseSchema(myLoadSchema)

            DisplayTableStructure()
            TextBox1.Text = myDS.Tables.Count.ToString()

            For i = 0 To (myDS.Tables.Count - 1)
                ListBox1.Items.Add(myDS.Tables(i).TableName)
                ListBox1.Items.Add("Columns count=" & myDS.Tables(i).Columns.Count.ToString())

                For j = 0 To (myDS.Tables(i).Columns.Count - 1)
                    ListBox1.Items.Add("ColumnName='" & myDS.Tables(i).Columns(j).ColumnName & "', type = " & myDS.Tables(i).Columns(j).DataType.ToString())
                Next
            Next




        Catch x As Exception
            Console.WriteLine("Exception: " & x.ToString())
        End Try


    End Sub


    ' Loads a specified schema into the DataSet
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

    ' Displays the DataSet tables structure
    Private Sub DisplayTableStructure()
        Console.WriteLine()
        Console.WriteLine("Table structure")
        Console.WriteLine()
        Console.WriteLine("Tables count=" & myDS.Tables.Count.ToString())

        Dim i, j As Integer

        For i = 0 To (myDS.Tables.Count - 1)
            Console.WriteLine("TableName='" & myDS.Tables(i).TableName & "'.")
            Console.WriteLine("Columns count=" & myDS.Tables(i).Columns.Count.ToString())

            For j = 0 To (myDS.Tables(i).Columns.Count - 1)
                Console.WriteLine(Strings.Chr(9) & "ColumnName='" & myDS.Tables(i).Columns(j).ColumnName & "', type = " & myDS.Tables(i).Columns(j).DataType.ToString())
            Next
            Console.WriteLine()
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class





