Imports System
Imports System.Data
Imports System.Xml

Public Class Form1
    Inherits System.Windows.Forms.Form



    'Declare the input file as a constant
    Private Const document As String = "C:\Program Files\MSDNTrain\2389\Labs\LabG\CustData.xml"
    Private myDataSet As DataSet = New DataSet()

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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
    
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btnQueryByProduct = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(32, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(288, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "Enter a Product ID"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(336, 80)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 40)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search for"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Results"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(32, 96)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(288, 225)
        Me.ListBox1.TabIndex = 5
        '
        'btnQueryByProduct
        '
        Me.btnQueryByProduct.Location = New System.Drawing.Point(336, 32)
        Me.btnQueryByProduct.Name = "btnQueryByProduct"
        Me.btnQueryByProduct.Size = New System.Drawing.Size(120, 40)
        Me.btnQueryByProduct.TabIndex = 0
        Me.btnQueryByProduct.Text = "Search by Product"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 341)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.ListBox1, Me.Label1, Me.TextBox1, Me.btnClose, Me.btnQueryByProduct})
        Me.Name = "Form1"
        Me.Text = "Common Queries"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub



    Private Sub btnQueryByProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryByProduct.Click


        'load the DataSet
        myDataSet.ReadXml(document, XmlReadMode.InferSchema)

        'Create an XMLDataDocument and synchronize the DataSet with a DataDocument
        Dim myXmlDataDoc As XmlDataDocument = New XmlDataDocument(myDataSet)



        'get the productid to search for
        Dim CurrentProduct As String
        CurrentProduct = TextBox1.Text

        'Build the query
        Dim QueryString As String
        'QueryString = "descendant::Customers[*/OrderDetails/ProductID=" & CurrentProduct.ToString() & "]"
        QueryString = "//Customers[*/OrderDetails/ProductID=" & CurrentProduct.ToString() & "]"
        'QueryString = "//Customers"

        'Execute the XPath query using the Select nodes method
        'Capture the results to a nodelist object
        Dim nodeList As XmlNodeList = myXmlDataDoc.DocumentElement.SelectNodes(QueryString)

        'Process the results
        Dim myRow As DataRow
        Dim myNode As XmlNode

        For Each myNode In nodeList
            myRow = myXmlDataDoc.GetRowFromElement(CType(myNode, XmlElement))

            If Not myRow Is Nothing Then
                'The index for myRow determines the element to be output
                ListBox1.Items.Add(myRow(2).ToString())
            End If

        Next

    End Sub




    Friend WithEvents btnQueryByProduct As System.Windows.Forms.Button
End Class
