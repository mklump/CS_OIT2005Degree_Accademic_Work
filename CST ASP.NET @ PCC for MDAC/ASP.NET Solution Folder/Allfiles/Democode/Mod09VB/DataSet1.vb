﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.2914.16
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code")>  _
Public Class DataSet1
    Inherits System.Data.DataSet
    
    Private tableauthors As authorsDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
    End Sub
    
    Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Me.InitClass
        Me.GetSerializationData(info, context)
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property authors As authorsDataTable
        Get
            Return Me.tableauthors
        End Get
    End Property
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.ReadXml(reader, XmlReadMode.IgnoreSchema)
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Private Sub InitClass()
        Me.DataSetName = "DataSet1"
        Me.Namespace = "http://www.tempuri.org/DataSet1.xsd"
        Me.tableauthors = New authorsDataTable
        Me.Tables.Add(Me.tableauthors)
    End Sub
    
    Private Function ShouldSerializeauthors() As Boolean
        Return false
    End Function
    
    Public Delegate Sub authorsRowChangeEventHandler(ByVal sender As Object, ByVal e As authorsRowChangeEvent)
    
    Public Class authorsDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnau_id As DataColumn
        
        Private columnau_lname As DataColumn
        
        Private columnau_fname As DataColumn
        
        Private columnphone As DataColumn
        
        Private columnaddress As DataColumn
        
        Private columncity As DataColumn
        
        Private columnstate As DataColumn
        
        Private columnzip As DataColumn
        
        Private columncontract As DataColumn
        
        Friend Sub New()
            MyBase.New("authors")
            Me.InitClass
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property au_idColumn As DataColumn
            Get
                Return Me.columnau_id
            End Get
        End Property
        
        Friend ReadOnly Property au_lnameColumn As DataColumn
            Get
                Return Me.columnau_lname
            End Get
        End Property
        
        Friend ReadOnly Property au_fnameColumn As DataColumn
            Get
                Return Me.columnau_fname
            End Get
        End Property
        
        Friend ReadOnly Property phoneColumn As DataColumn
            Get
                Return Me.columnphone
            End Get
        End Property
        
        Friend ReadOnly Property addressColumn As DataColumn
            Get
                Return Me.columnaddress
            End Get
        End Property
        
        Friend ReadOnly Property cityColumn As DataColumn
            Get
                Return Me.columncity
            End Get
        End Property
        
        Friend ReadOnly Property stateColumn As DataColumn
            Get
                Return Me.columnstate
            End Get
        End Property
        
        Friend ReadOnly Property zipColumn As DataColumn
            Get
                Return Me.columnzip
            End Get
        End Property
        
        Friend ReadOnly Property contractColumn As DataColumn
            Get
                Return Me.columncontract
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As authorsRow
            Get
                Return CType(Me.Rows(index),authorsRow)
            End Get
        End Property
        
        Public Event authorsRowChanged As authorsRowChangeEventHandler
        
        Public Event authorsRowChanging As authorsRowChangeEventHandler
        
        Public Event authorsRowDeleted As authorsRowChangeEventHandler
        
        Public Event authorsRowDeleting As authorsRowChangeEventHandler
        
        Public Overloads Sub AddauthorsRow(ByVal row As authorsRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddauthorsRow(ByVal au_id As String, ByVal au_lname As String, ByVal au_fname As String, ByVal phone As String, ByVal address As String, ByVal city As String, ByVal state As String, ByVal zip As String, ByVal contract As Boolean) As authorsRow
            Dim rowauthorsRow As authorsRow = CType(Me.NewRow,authorsRow)
            rowauthorsRow.ItemArray = New Object() {au_id, au_lname, au_fname, phone, address, city, state, zip, contract}
            Me.Rows.Add(rowauthorsRow)
            Return rowauthorsRow
        End Function
        
        Public Function FindByau_id(ByVal au_id As String) As authorsRow
            Return CType(Me.Rows.Find(New Object() {au_id}),authorsRow)
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Private Sub InitClass()
            Me.columnau_id = New DataColumn("au_id", GetType(System.String), "", System.Data.MappingType.Element)
            Me.columnau_id.AllowDBNull = false
            Me.columnau_id.Unique = true
            Me.Columns.Add(Me.columnau_id)
            Me.columnau_lname = New DataColumn("au_lname", GetType(System.String), "", System.Data.MappingType.Element)
            Me.columnau_lname.AllowDBNull = false
            Me.Columns.Add(Me.columnau_lname)
            Me.columnau_fname = New DataColumn("au_fname", GetType(System.String), "", System.Data.MappingType.Element)
            Me.columnau_fname.AllowDBNull = false
            Me.Columns.Add(Me.columnau_fname)
            Me.columnphone = New DataColumn("phone", GetType(System.String), "", System.Data.MappingType.Element)
            Me.columnphone.AllowDBNull = false
            Me.Columns.Add(Me.columnphone)
            Me.columnaddress = New DataColumn("address", GetType(System.String), "", System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnaddress)
            Me.columncity = New DataColumn("city", GetType(System.String), "", System.Data.MappingType.Element)
            Me.Columns.Add(Me.columncity)
            Me.columnstate = New DataColumn("state", GetType(System.String), "", System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnstate)
            Me.columnzip = New DataColumn("zip", GetType(System.String), "", System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnzip)
            Me.columncontract = New DataColumn("contract", GetType(System.Boolean), "", System.Data.MappingType.Element)
            Me.columncontract.AllowDBNull = false
            Me.Columns.Add(Me.columncontract)
            Me.PrimaryKey = New DataColumn() {Me.columnau_id}
        End Sub
        
        Public Function NewauthorsRow() As authorsRow
            Return CType(Me.NewRow,authorsRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            'We need to ensure that all Rows in the tabled are typed rows.
            'Table calls newRow whenever it needs to create a row.
            'So the following conditions are covered by Row newRow(Record record)
            '* Cursor calls table.addRecord(record) 
            '* table.addRow(object[] values) calls newRow(record)    
            Return New authorsRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(authorsRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.authorsRowChangedEvent) Is Nothing) Then
                RaiseEvent authorsRowChanged(Me, New authorsRowChangeEvent(CType(e.Row,authorsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.authorsRowChangingEvent) Is Nothing) Then
                RaiseEvent authorsRowChanging(Me, New authorsRowChangeEvent(CType(e.Row,authorsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.authorsRowDeletedEvent) Is Nothing) Then
                RaiseEvent authorsRowDeleted(Me, New authorsRowChangeEvent(CType(e.Row,authorsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.authorsRowDeletingEvent) Is Nothing) Then
                RaiseEvent authorsRowDeleting(Me, New authorsRowChangeEvent(CType(e.Row,authorsRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveauthorsRow(ByVal row As authorsRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    Public Class authorsRow
        Inherits DataRow
        
        Private tableauthors As authorsDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableauthors = CType(Me.Table,authorsDataTable)
        End Sub
        
        Public Property au_id As String
            Get
                Return CType(Me(Me.tableauthors.au_idColumn),String)
            End Get
            Set
                Me(Me.tableauthors.au_idColumn) = value
            End Set
        End Property
        
        Public Property au_lname As String
            Get
                Return CType(Me(Me.tableauthors.au_lnameColumn),String)
            End Get
            Set
                Me(Me.tableauthors.au_lnameColumn) = value
            End Set
        End Property
        
        Public Property au_fname As String
            Get
                Return CType(Me(Me.tableauthors.au_fnameColumn),String)
            End Get
            Set
                Me(Me.tableauthors.au_fnameColumn) = value
            End Set
        End Property
        
        Public Property phone As String
            Get
                Return CType(Me(Me.tableauthors.phoneColumn),String)
            End Get
            Set
                Me(Me.tableauthors.phoneColumn) = value
            End Set
        End Property
        
        Public Property address As String
            Get
                Try 
                    Return CType(Me(Me.tableauthors.addressColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableauthors.addressColumn) = value
            End Set
        End Property
        
        Public Property city As String
            Get
                Try 
                    Return CType(Me(Me.tableauthors.cityColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableauthors.cityColumn) = value
            End Set
        End Property
        
        Public Property state As String
            Get
                Try 
                    Return CType(Me(Me.tableauthors.stateColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableauthors.stateColumn) = value
            End Set
        End Property
        
        Public Property zip As String
            Get
                Try 
                    Return CType(Me(Me.tableauthors.zipColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableauthors.zipColumn) = value
            End Set
        End Property
        
        Public Property contract As Boolean
            Get
                Return CType(Me(Me.tableauthors.contractColumn),Boolean)
            End Get
            Set
                Me(Me.tableauthors.contractColumn) = value
            End Set
        End Property
        
        Public Function IsaddressNull() As Boolean
            Return Me.IsNull(Me.tableauthors.addressColumn)
        End Function
        
        Public Sub SetaddressNull()
            Me(Me.tableauthors.addressColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IscityNull() As Boolean
            Return Me.IsNull(Me.tableauthors.cityColumn)
        End Function
        
        Public Sub SetcityNull()
            Me(Me.tableauthors.cityColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsstateNull() As Boolean
            Return Me.IsNull(Me.tableauthors.stateColumn)
        End Function
        
        Public Sub SetstateNull()
            Me(Me.tableauthors.stateColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IszipNull() As Boolean
            Return Me.IsNull(Me.tableauthors.zipColumn)
        End Function
        
        Public Sub SetzipNull()
            Me(Me.tableauthors.zipColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    Public Class authorsRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As authorsRow
        
        Private eventAction As System.Data.DataRowAction
        
        Public Sub New(ByVal row As authorsRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As authorsRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action As DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class