Imports System.IO
Imports System.Data
Imports System.Xml
Imports System.Xml.Xsl

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private Const m_XmlFile As String = "..\..\PersonPet1.xml"
    Private Const m_SchemaFile As String = "..\..\PersonPet1.xsd"

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
            
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCreateSchema = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCreateSchema
        '
        Me.btnCreateSchema.Location = New System.Drawing.Point(56, 24)
        Me.btnCreateSchema.Name = "btnCreateSchema"
        Me.btnCreateSchema.Size = New System.Drawing.Size(120, 56)
        Me.btnCreateSchema.TabIndex = 0
        Me.btnCreateSchema.Text = "Create Schema"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(56, 96)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 56)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(224, 189)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.btnCreateSchema})
        Me.Name = "Form1"
        Me.Text = "Create and Save Schema"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCreateSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateSchema.Click
        Try
            'Load the DataSet with relation data
            Dim myDataSet As DataSet = New DataSet()
            LoadDataSet(myDataSet)

            'Write out schema representation
            myDataSet.WriteXmlSchema(m_SchemaFile)

            'Write out XML data form relational data
            myDataSet.WriteXml(m_XmlFile, XmlWriteMode.IgnoreSchema)
            'myDataSet.WriteXml(m_XmlFile, XmlWriteMode.WriteSchema)

        Catch x As Exception
            Console.WriteLine("Exception: " & x.ToString())
        End Try
    End Sub
    Private Sub LoadDataSet(ByVal myDataSet As DataSet)

        Try
            Console.WriteLine("Loading the DataSet ...")

            ' Set DataSet name
            myDataSet.DataSetName = "PersonPet"

            ' Create tables for people and pets
            Dim people As DataTable = New DataTable("Person")
            Dim pets As DataTable = New DataTable("Pet")

            ' Set up the columns in the Tables
            Dim personname As DataColumn = New DataColumn("Name", GetType(System.String))
            Dim personAge As DataColumn = New DataColumn("Age", GetType(System.Int32))

            Dim petname As DataColumn = New DataColumn("Name", GetType(System.String))
            Dim pettype As DataColumn = New DataColumn("Type", GetType(System.String))

            ' Add columns to person table
            Dim id As DataColumn = people.Columns.Add("ID", GetType(System.Int32))
            id.AutoIncrement = True
            Dim primarykey As DataColumn() = New DataColumn() {id}
            people.PrimaryKey = primarykey
            people.Columns.Add(personname)
            people.Columns.Add(personAge)

            ' Add columns to pet table
            id = pets.Columns.Add("ID", GetType(System.Int32))
            id.AutoIncrement = True
            pets.PrimaryKey = New DataColumn() {id}
            id.AutoIncrement = True
            Dim ownerid As DataColumn = pets.Columns.Add("OwnerID", GetType(System.Int32))
            Dim foreignkey As DataColumn() = New DataColumn() {ownerid}
            pets.Columns.Add(petname)
            pets.Columns.Add(pettype)

            ' Add tables to the DataSet
            myDataSet.Tables.Add(people)
            myDataSet.Tables.Add(pets)

            ' Add people
            Dim mark As DataRow = people.NewRow()
            mark(personname) = "Mark"
            mark(personAge) = 18
            people.Rows.Add(mark)

            Dim william As DataRow = people.NewRow()
            william(personname) = "William"
            william(personAge) = 12
            people.Rows.Add(william)

            Dim james As DataRow = people.NewRow()
            james(personname) = "James"
            james(personAge) = 7
            people.Rows.Add(james)

            Dim levi As DataRow = people.NewRow()
            levi(personname) = "Levi"
            levi(personAge) = 4
            people.Rows.Add(levi)

            ' Add relationships
            Console.WriteLine("Creating relationships between people and pets ...")
            Dim personpetrel As DataRelation = New DataRelation("PersonPet", primarykey, foreignkey, False)
            myDataSet.Relations.Add(personpetrel)

            ' Add pets
            Dim row As DataRow = pets.NewRow()
            row("OwnerID") = mark("ID")
            row(petname) = "Frank"
            row(pettype) = "cat"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = william("ID")
            row(petname) = "Rex"
            row(pettype) = "dog"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = james("ID")
            row(petname) = "Cottontail"
            row(pettype) = "rabbit"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = levi("ID")
            row(petname) = "Sid"
            row(pettype) = "snake"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = levi("ID")
            row(petname) = "Tickles"
            row(pettype) = "spider"
            pets.Rows.Add(row)

            row = pets.NewRow()
            row("OwnerID") = william("ID")
            row(petname) = "Tweetie"
            row(pettype) = "canary"
            pets.Rows.Add(row)

            ' commit changes
            myDataSet.AcceptChanges()

        Catch e As Exception
            Console.WriteLine("Exception: " & e.ToString())
        End Try
    End Sub



    Friend WithEvents btnCreateSchema As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
