﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.3512.0
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
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class dsDentists
    Inherits DataSet
    
    Private tableDentists As DentistsDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As DataSet = New DataSet
            ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Dentists")) Is Nothing) Then
                Me.Tables.Add(New DentistsDataTable(ds.Tables("Dentists")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.InitClass
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Dentists As DentistsDataTable
        Get
            Return Me.tableDentists
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As dsDentists = CType(MyBase.Clone,dsDentists)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.Reset
        Dim ds As DataSet = New DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("Dentists")) Is Nothing) Then
            Me.Tables.Add(New DentistsDataTable(ds.Tables("Dentists")))
        End If
        Me.DataSetName = ds.DataSetName
        Me.Prefix = ds.Prefix
        Me.Namespace = ds.Namespace
        Me.Locale = ds.Locale
        Me.CaseSensitive = ds.CaseSensitive
        Me.EnforceConstraints = ds.EnforceConstraints
        Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
        Me.InitVars
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Friend Sub InitVars()
        Me.tableDentists = CType(Me.Tables("Dentists"),DentistsDataTable)
        If (Not (Me.tableDentists) Is Nothing) Then
            Me.tableDentists.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "dsDentists"
        Me.Prefix = ""
        Me.Namespace = "http://www.tempuri.org/dsDentists.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableDentists = New DentistsDataTable
        Me.Tables.Add(Me.tableDentists)
    End Sub
    
    Private Function ShouldSerializeDentists() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub DentistsRowChangeEventHandler(ByVal sender As Object, ByVal e As DentistsRowChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class DentistsDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnFirstName As DataColumn
        
        Private columnLastName As DataColumn
        
        Private columnSpeciality As DataColumn
        
        Private columnAddress As DataColumn
        
        Private columnCity As DataColumn
        
        Private column_Region As DataColumn
        
        Private columnState As DataColumn
        
        Private columnPostalCode As DataColumn
        
        Private columnCountry As DataColumn
        
        Private columnPhone As DataColumn
        
        Private columnFax As DataColumn
        
        Private columnDentistID As DataColumn
        
        Friend Sub New()
            MyBase.New("Dentists")
            Me.InitClass
        End Sub
        
        Friend Sub New(ByVal table As DataTable)
            MyBase.New(table.TableName)
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
            Me.DisplayExpression = table.DisplayExpression
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property FirstNameColumn As DataColumn
            Get
                Return Me.columnFirstName
            End Get
        End Property
        
        Friend ReadOnly Property LastNameColumn As DataColumn
            Get
                Return Me.columnLastName
            End Get
        End Property
        
        Friend ReadOnly Property SpecialityColumn As DataColumn
            Get
                Return Me.columnSpeciality
            End Get
        End Property
        
        Friend ReadOnly Property AddressColumn As DataColumn
            Get
                Return Me.columnAddress
            End Get
        End Property
        
        Friend ReadOnly Property CityColumn As DataColumn
            Get
                Return Me.columnCity
            End Get
        End Property
        
        Friend ReadOnly Property _RegionColumn As DataColumn
            Get
                Return Me.column_Region
            End Get
        End Property
        
        Friend ReadOnly Property StateColumn As DataColumn
            Get
                Return Me.columnState
            End Get
        End Property
        
        Friend ReadOnly Property PostalCodeColumn As DataColumn
            Get
                Return Me.columnPostalCode
            End Get
        End Property
        
        Friend ReadOnly Property CountryColumn As DataColumn
            Get
                Return Me.columnCountry
            End Get
        End Property
        
        Friend ReadOnly Property PhoneColumn As DataColumn
            Get
                Return Me.columnPhone
            End Get
        End Property
        
        Friend ReadOnly Property FaxColumn As DataColumn
            Get
                Return Me.columnFax
            End Get
        End Property
        
        Friend ReadOnly Property DentistIDColumn As DataColumn
            Get
                Return Me.columnDentistID
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As DentistsRow
            Get
                Return CType(Me.Rows(index),DentistsRow)
            End Get
        End Property
        
        Public Event DentistsRowChanged As DentistsRowChangeEventHandler
        
        Public Event DentistsRowChanging As DentistsRowChangeEventHandler
        
        Public Event DentistsRowDeleted As DentistsRowChangeEventHandler
        
        Public Event DentistsRowDeleting As DentistsRowChangeEventHandler
        
        Public Overloads Sub AddDentistsRow(ByVal row As DentistsRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddDentistsRow(ByVal FirstName As String, ByVal LastName As String, ByVal Speciality As String, ByVal Address As String, ByVal City As String, ByVal _Region As String, ByVal State As String, ByVal PostalCode As String, ByVal Country As String, ByVal Phone As String, ByVal Fax As String, ByVal DentistID As String) As DentistsRow
            Dim rowDentistsRow As DentistsRow = CType(Me.NewRow,DentistsRow)
            rowDentistsRow.ItemArray = New Object() {FirstName, LastName, Speciality, Address, City, _Region, State, PostalCode, Country, Phone, Fax, DentistID}
            Me.Rows.Add(rowDentistsRow)
            Return rowDentistsRow
        End Function
        
        Public Function FindByDentistID(ByVal DentistID As String) As DentistsRow
            Return CType(Me.Rows.Find(New Object() {DentistID}),DentistsRow)
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As DentistsDataTable = CType(MyBase.Clone,DentistsDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Friend Sub InitVars()
            Me.columnFirstName = Me.Columns("FirstName")
            Me.columnLastName = Me.Columns("LastName")
            Me.columnSpeciality = Me.Columns("Speciality")
            Me.columnAddress = Me.Columns("Address")
            Me.columnCity = Me.Columns("City")
            Me.column_Region = Me.Columns("Region")
            Me.columnState = Me.Columns("State")
            Me.columnPostalCode = Me.Columns("PostalCode")
            Me.columnCountry = Me.Columns("Country")
            Me.columnPhone = Me.Columns("Phone")
            Me.columnFax = Me.Columns("Fax")
            Me.columnDentistID = Me.Columns("DentistID")
        End Sub
        
        Private Sub InitClass()
            Me.columnFirstName = New DataColumn("FirstName", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnFirstName)
            Me.columnLastName = New DataColumn("LastName", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnLastName)
            Me.columnSpeciality = New DataColumn("Speciality", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnSpeciality)
            Me.columnAddress = New DataColumn("Address", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnAddress)
            Me.columnCity = New DataColumn("City", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCity)
            Me.column_Region = New DataColumn("Region", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.column_Region)
            Me.columnState = New DataColumn("State", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnState)
            Me.columnPostalCode = New DataColumn("PostalCode", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnPostalCode)
            Me.columnCountry = New DataColumn("Country", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCountry)
            Me.columnPhone = New DataColumn("Phone", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnPhone)
            Me.columnFax = New DataColumn("Fax", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnFax)
            Me.columnDentistID = New DataColumn("DentistID", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnDentistID)
            Me.Constraints.Add(New UniqueConstraint("Constraint1", New DataColumn() {Me.columnDentistID}, true))
            Me.columnLastName.AllowDBNull = false
            Me.columnDentistID.AllowDBNull = false
            Me.columnDentistID.Unique = true
        End Sub
        
        Public Function NewDentistsRow() As DentistsRow
            Return CType(Me.NewRow,DentistsRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New DentistsRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(DentistsRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.DentistsRowChangedEvent) Is Nothing) Then
                RaiseEvent DentistsRowChanged(Me, New DentistsRowChangeEvent(CType(e.Row,DentistsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.DentistsRowChangingEvent) Is Nothing) Then
                RaiseEvent DentistsRowChanging(Me, New DentistsRowChangeEvent(CType(e.Row,DentistsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.DentistsRowDeletedEvent) Is Nothing) Then
                RaiseEvent DentistsRowDeleted(Me, New DentistsRowChangeEvent(CType(e.Row,DentistsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.DentistsRowDeletingEvent) Is Nothing) Then
                RaiseEvent DentistsRowDeleting(Me, New DentistsRowChangeEvent(CType(e.Row,DentistsRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveDentistsRow(ByVal row As DentistsRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class DentistsRow
        Inherits DataRow
        
        Private tableDentists As DentistsDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableDentists = CType(Me.Table,DentistsDataTable)
        End Sub
        
        Public Property FirstName As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.FirstNameColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.FirstNameColumn) = value
            End Set
        End Property
        
        Public Property LastName As String
            Get
                Return CType(Me(Me.tableDentists.LastNameColumn),String)
            End Get
            Set
                Me(Me.tableDentists.LastNameColumn) = value
            End Set
        End Property
        
        Public Property Speciality As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.SpecialityColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.SpecialityColumn) = value
            End Set
        End Property
        
        Public Property Address As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.AddressColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.AddressColumn) = value
            End Set
        End Property
        
        Public Property City As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.CityColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.CityColumn) = value
            End Set
        End Property
        
        Public Property _Region As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists._RegionColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists._RegionColumn) = value
            End Set
        End Property
        
        Public Property State As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.StateColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.StateColumn) = value
            End Set
        End Property
        
        Public Property PostalCode As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.PostalCodeColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.PostalCodeColumn) = value
            End Set
        End Property
        
        Public Property Country As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.CountryColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.CountryColumn) = value
            End Set
        End Property
        
        Public Property Phone As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.PhoneColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.PhoneColumn) = value
            End Set
        End Property
        
        Public Property Fax As String
            Get
                Try 
                    Return CType(Me(Me.tableDentists.FaxColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableDentists.FaxColumn) = value
            End Set
        End Property
        
        Public Property DentistID As String
            Get
                Return CType(Me(Me.tableDentists.DentistIDColumn),String)
            End Get
            Set
                Me(Me.tableDentists.DentistIDColumn) = value
            End Set
        End Property
        
        Public Function IsFirstNameNull() As Boolean
            Return Me.IsNull(Me.tableDentists.FirstNameColumn)
        End Function
        
        Public Sub SetFirstNameNull()
            Me(Me.tableDentists.FirstNameColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsSpecialityNull() As Boolean
            Return Me.IsNull(Me.tableDentists.SpecialityColumn)
        End Function
        
        Public Sub SetSpecialityNull()
            Me(Me.tableDentists.SpecialityColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsAddressNull() As Boolean
            Return Me.IsNull(Me.tableDentists.AddressColumn)
        End Function
        
        Public Sub SetAddressNull()
            Me(Me.tableDentists.AddressColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsCityNull() As Boolean
            Return Me.IsNull(Me.tableDentists.CityColumn)
        End Function
        
        Public Sub SetCityNull()
            Me(Me.tableDentists.CityColumn) = System.Convert.DBNull
        End Sub
        
        Public Function Is_RegionNull() As Boolean
            Return Me.IsNull(Me.tableDentists._RegionColumn)
        End Function
        
        Public Sub Set_RegionNull()
            Me(Me.tableDentists._RegionColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsStateNull() As Boolean
            Return Me.IsNull(Me.tableDentists.StateColumn)
        End Function
        
        Public Sub SetStateNull()
            Me(Me.tableDentists.StateColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsPostalCodeNull() As Boolean
            Return Me.IsNull(Me.tableDentists.PostalCodeColumn)
        End Function
        
        Public Sub SetPostalCodeNull()
            Me(Me.tableDentists.PostalCodeColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsCountryNull() As Boolean
            Return Me.IsNull(Me.tableDentists.CountryColumn)
        End Function
        
        Public Sub SetCountryNull()
            Me(Me.tableDentists.CountryColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsPhoneNull() As Boolean
            Return Me.IsNull(Me.tableDentists.PhoneColumn)
        End Function
        
        Public Sub SetPhoneNull()
            Me(Me.tableDentists.PhoneColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsFaxNull() As Boolean
            Return Me.IsNull(Me.tableDentists.FaxColumn)
        End Function
        
        Public Sub SetFaxNull()
            Me(Me.tableDentists.FaxColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class DentistsRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As DentistsRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As DentistsRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As DentistsRow
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
