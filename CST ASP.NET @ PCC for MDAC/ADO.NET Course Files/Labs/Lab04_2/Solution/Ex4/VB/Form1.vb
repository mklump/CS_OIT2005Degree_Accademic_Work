Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Added in Lab 4.1 Exercise 2

    Public Filename As System.String

    ' Added in Lab 4.2 Exercise 3

    Private dsCatProd As DataSet

    ' Windows Form Designer generated variables

    Friend WithEvents grd As System.Windows.Forms.DataGrid
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog


    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents s1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents s2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem

    Friend WithEvents mnuView As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCustomer As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProducts As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents dsShoppingCart As System.Data.DataSet
    Friend WithEvents dtCustomer As System.Data.DataTable
    Friend WithEvents dtCartItems As System.Data.DataTable
    Friend WithEvents dcCustomerID As System.Data.DataColumn
    Friend WithEvents dcCompanyName As System.Data.DataColumn
    Friend WithEvents dcAddress As System.Data.DataColumn
    Friend WithEvents dcCity As System.Data.DataColumn
    Friend WithEvents dcCustomerID2 As System.Data.DataColumn
    Friend WithEvents dcProductID As System.Data.DataColumn
    Friend WithEvents dcUnitPrice As System.Data.DataColumn
    Friend WithEvents dcQuantity As System.Data.DataColumn
    Friend WithEvents dcCost As System.Data.DataColumn
    Friend WithEvents mnuSubtotal As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddToCart As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDiscontinued As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOutOfStock As System.Windows.Forms.MenuItem
        Friend WithEvents mnuCartItems As System.Windows.Forms.MenuItem

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
        Me.dcCost = New System.Data.DataColumn()
        Me.grd = New System.Windows.Forms.DataGrid()
        Me.dtCartItems = New System.Data.DataTable()
        Me.dcCustomerID2 = New System.Data.DataColumn()
        Me.dcProductID = New System.Data.DataColumn()
        Me.dcUnitPrice = New System.Data.DataColumn()
        Me.dcQuantity = New System.Data.DataColumn()
        Me.dtCustomer = New System.Data.DataTable()
        Me.dcCustomerID = New System.Data.DataColumn()
        Me.dcCompanyName = New System.Data.DataColumn()
        Me.dcAddress = New System.Data.DataColumn()
        Me.dcCity = New System.Data.DataColumn()
        Me.mnuCartItems = New System.Windows.Forms.MenuItem()
        Me.mnuSave = New System.Windows.Forms.MenuItem()
        Me.mnuEdit = New System.Windows.Forms.MenuItem()
        Me.mnuAddToCart = New System.Windows.Forms.MenuItem()
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuNew = New System.Windows.Forms.MenuItem()
        Me.mnuOpen = New System.Windows.Forms.MenuItem()
        Me.s1 = New System.Windows.Forms.MenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem()
        Me.s2 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuView = New System.Windows.Forms.MenuItem()
        Me.mnuCustomer = New System.Windows.Forms.MenuItem()
        Me.mnuProducts = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuSubtotal = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.dsShoppingCart = New System.Data.DataSet()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.mnuDiscontinued = New System.Windows.Forms.MenuItem()
        Me.mnuOutOfStock = New System.Windows.Forms.MenuItem()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCartItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsShoppingCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dcCost
        '
        Me.dcCost.ColumnName = "Cost"
        Me.dcCost.DataType = GetType(System.Decimal)
        Me.dcCost.Expression = "UnitPrice * Quantity"
        Me.dcCost.ReadOnly = True
        '
        'grd
        '
        Me.grd.DataMember = ""
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(368, 289)
        Me.grd.TabIndex = 0
        '
        'dtCartItems
        '
        Me.dtCartItems.Columns.AddRange(New System.Data.DataColumn() {Me.dcCustomerID2, Me.dcProductID, Me.dcUnitPrice, Me.dcQuantity, Me.dcCost})
        Me.dtCartItems.TableName = "CartItems"
        '
        'dcCustomerID2
        '
        Me.dcCustomerID2.AllowDBNull = False
        Me.dcCustomerID2.ColumnName = "CustomerID"
        Me.dcCustomerID2.MaxLength = 5
        '
        'dcProductID
        '
        Me.dcProductID.AllowDBNull = False
        Me.dcProductID.ColumnName = "ProductID"
        Me.dcProductID.DataType = GetType(System.Int32)
        '
        'dcUnitPrice
        '
        Me.dcUnitPrice.AllowDBNull = False
        Me.dcUnitPrice.ColumnName = "UnitPrice"
        Me.dcUnitPrice.DataType = GetType(System.Decimal)
        '
        'dcQuantity
        '
        Me.dcQuantity.AllowDBNull = False
        Me.dcQuantity.ColumnName = "Quantity"
        Me.dcQuantity.DataType = GetType(System.Int32)
        '
        'dtCustomer
        '
        Me.dtCustomer.Columns.AddRange(New System.Data.DataColumn() {Me.dcCustomerID, Me.dcCompanyName, Me.dcAddress, Me.dcCity})
        Me.dtCustomer.TableName = "Customer"
        '
        'dcCustomerID
        '
        Me.dcCustomerID.AllowDBNull = False
        Me.dcCustomerID.ColumnName = "CustomerID"
        Me.dcCustomerID.MaxLength = 5
        '
        'dcCompanyName
        '
        Me.dcCompanyName.AllowDBNull = False
        Me.dcCompanyName.ColumnName = "CompanyName"
        Me.dcCompanyName.MaxLength = 40
        '
        'dcAddress
        '
        Me.dcAddress.ColumnName = "Address"
        Me.dcAddress.MaxLength = 60
        '
        'dcCity
        '
        Me.dcCity.ColumnName = "City"
        Me.dcCity.MaxLength = 15
        '
        'mnuCartItems
        '
        Me.mnuCartItems.Index = 1
        Me.mnuCartItems.Shortcut = System.Windows.Forms.Shortcut.ShiftF7
        Me.mnuCartItems.Text = "Cart &Items"
        '
        'mnuSave
        '
        Me.mnuSave.Index = 3
        Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSave.Text = "&Save"
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddToCart})
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuAddToCart
        '
        Me.mnuAddToCart.Index = 0
        Me.mnuAddToCart.Shortcut = System.Windows.Forms.Shortcut.Ins
        Me.mnuAddToCart.Text = "&Add To Cart"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuOpen, Me.s1, Me.mnuSave, Me.mnuSaveAs, Me.s2, Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuNew
        '
        Me.mnuNew.Index = 0
        Me.mnuNew.Text = "&New"
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 1
        Me.mnuOpen.Text = "&Open..."
        '
        's1
        '
        Me.s1.Index = 2
        Me.s1.Text = "-"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Index = 4
        Me.mnuSaveAs.Text = "Save &As..."
        '
        's2
        '
        Me.s2.Index = 5
        Me.s2.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 6
        Me.mnuExit.Text = "E&xit"
        '
        'mnuView
        '
        Me.mnuView.Index = 2
        Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCustomer, Me.mnuCartItems, Me.mnuProducts, Me.MenuItem2, Me.mnuSubtotal, Me.MenuItem1, Me.mnuDiscontinued, Me.mnuOutOfStock})
        Me.mnuView.Text = "&View"
        '
        'mnuCustomer
        '
        Me.mnuCustomer.Index = 0
        Me.mnuCustomer.Shortcut = System.Windows.Forms.Shortcut.F7
        Me.mnuCustomer.Text = "&Customer"
        '
        'mnuProducts
        '
        Me.mnuProducts.Index = 2
        Me.mnuProducts.Shortcut = System.Windows.Forms.Shortcut.CtrlF7
        Me.mnuProducts.Text = "&Products"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.Text = "-"
        '
        'mnuSubtotal
        '
        Me.mnuSubtotal.Index = 4
        Me.mnuSubtotal.Shortcut = System.Windows.Forms.Shortcut.F9
        Me.mnuSubtotal.Text = "Cart &Subtotal"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 5
        Me.MenuItem1.Text = "-"
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "ds"
        Me.dlgSave.Filter = "DataSet files (*.ds)|*.ds"
        '
        'dsShoppingCart
        '
        Me.dsShoppingCart.DataSetName = "NewDataSet"
        Me.dsShoppingCart.Locale = New System.Globalization.CultureInfo("en-US")
        Me.dsShoppingCart.Tables.AddRange(New System.Data.DataTable() {Me.dtCustomer, Me.dtCartItems})
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "DataSet files (*.ds)|*.ds|All files (*.*)|*.*"
        '
        'mnuDiscontinued
        '
        Me.mnuDiscontinued.Checked = True
        Me.mnuDiscontinued.Index = 6
        Me.mnuDiscontinued.Text = "&Discontinued"
        '
        'mnuOutOfStock
        '
        Me.mnuOutOfStock.Checked = True
        Me.mnuOutOfStock.Index = 7
        Me.mnuOutOfStock.Text = "&Out Of Stock"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 289)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grd})
        Me.Menu = Me.mnuMain
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCartItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsShoppingCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Added in Lab 4.1 Exercise 2

    Public Sub OpenFromFile()

        Try

            ' clear any existing data
            Me.dsShoppingCart.Tables("CartItems").Clear()
            Me.dsShoppingCart.Tables("Customer").Clear()

            ' open the file
            Me.dsShoppingCart.ReadXml(Me.Filename)

        Catch Xcp As System.Exception

            MessageBox.Show(Xcp.ToString(), _
                "Failed to open: " & Me.Filename, _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    ' Added in Lab 4.1 Exercise 2

    Public Sub SaveToFile()

        Try

            ' save the file
            Me.dsShoppingCart.WriteXml(Me.Filename)

        Catch Xcp As System.Exception

            MessageBox.Show(Xcp.ToString(), _
                "Failed to save: " & Me.Filename, _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    ' Added in Lab 4.1 Exercise 3

    Private Sub SetFormCaption()

        Me.Text = Me.Filename & " - Shopping Cart : Test WinApp"

    End Sub

    Private Sub mnuCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCustomer.Click

        ' Added in Lab 4.1 Exercise 3

        Me.grd.DataSource = New DataView(Me.dsShoppingCart.Tables("Customer"))

        Me.mnuCustomer.Checked = True
        Me.mnuCartItems.Checked = False
        ' Added in Lab 4.2 Exercise 3
        mnuProducts.Checked = False

    End Sub

    Private Sub mnuCartItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCartItems.Click

        ' Added in Lab 4.1 Exercise 3

        Me.grd.DataSource = New DataView(Me.dsShoppingCart.Tables("CartItems"))

        Me.mnuCustomer.Checked = False
        Me.mnuCartItems.Checked = True
        ' Added in Lab 4.2 Exercise 3
        mnuProducts.Checked = False

    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click

        With Me
            .Dispose()
            .Close()
        End With

    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click

        ' clear any existing data
        Me.dsShoppingCart.Tables("CartItems").Clear()
        Me.dsShoppingCart.Tables("Customer").Clear()

        Me.Filename = "ShoppingCart1.ds"

        Me.SetFormCaption()

        Me.mnuCustomer_Click(sender, e)

    End Sub

    Private Sub mnuOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOpen.Click

        If Me.dlgOpen.ShowDialog() = DialogResult.OK Then

            Me.Filename = Me.dlgOpen.FileName

            Me.OpenFromFile()

            Me.SetFormCaption()

            Me.mnuCustomer_Click(sender, e)

        End If

    End Sub

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click

        Me.SaveToFile()

    End Sub

    Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click

        If Me.dlgSave.ShowDialog() = DialogResult.OK Then

            Me.Filename = Me.dlgSave.FileName

            Me.SaveToFile()

            Me.SetFormCaption()

        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.mnuNew_Click(sender, e)

        ' add primary key

        Me.dtCustomer.Constraints.Add("PK_Customer", _
            Me.dtCustomer.Columns("CustomerID"), True)

        ' add relation

        Me.dsShoppingCart.Relations.Add("FK_Customer_CartItems", _
            Me.dtCustomer.Columns("CustomerID"), _
            Me.dtCartItems.Columns("CustomerID"), True)

        ' add subtotal column

        Me.dtCustomer.Columns.Add(New DataColumn( _
            "CartSubtotal", GetType(System.Decimal), _
            "Sum(Child.Cost)"))

        ' Added in Lab 4.2 Exercise 3

        Me.dsCatProd = New DataSet()

        Me.dsCatProd.ReadXml("\Program Files\MSDNTrain\2389\Labs\Lab04_2\catprod.ds", XmlReadMode.ReadSchema)

    End Sub

    Private Sub mnuSubtotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSubtotal.Click

        Dim sCustomerID As System.String
        Dim drCustomer As System.Data.DataRow
        Dim drCartItem As System.Data.DataRow
        Dim dSubtotal As System.Decimal = 0

        Try

            sCustomerID = Me.grd(Me.grd.CurrentRowIndex, 0)

            drCustomer = Me.dsShoppingCart.Tables("Customer").Select( _
                "CustomerID='" & sCustomerID & "'")(0)

            For Each drCartItem In drCustomer.GetChildRows("FK_Customer_CartItems")

                dSubtotal += drCartItem.Item("Cost")

            Next

            MessageBox.Show(drCustomer("CompanyName") & " owes " & dSubtotal.ToString("$0.00"), "Cart Subtotal")

        Catch Xcp As System.Exception

            MessageBox.Show(Xcp.ToString, "Unexpected exception", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    Private Sub mnuProducts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuProducts.Click

        ' Added in Lab 4.2 Exercise 3

        Me.mnuCustomer.Checked = False
        Me.mnuCartItems.Checked = False
        Me.mnuProducts.Checked = True

    End Sub

    ' Added in Lab 4.2 Exercise 3

    Private Sub mnuEdit_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.Select

        mnuAddToCart.Enabled = mnuProducts.Checked

    End Sub

    Private Sub mnuAddToCart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddToCart.Click

        Dim CustomerID As System.Object
        Dim ProductID As System.Object
        Dim UnitPrice As System.Object
        Dim Quantity As System.Object

        CustomerID = Me.dtCustomer.Rows(0).Item(0)
        ProductID = Me.grd(Me.grd.CurrentRowIndex, 0)
        UnitPrice = Me.grd(Me.grd.CurrentRowIndex, 5)
        Quantity = InputBox("How many " & Me.grd(Me.grd.CurrentRowIndex, 1) & " do you want?", "Add To Cart")

        Try

            ' Passing an array of object values is a shorthand way of adding a new row

            Me.dsShoppingCart.Tables("CartItems").Rows.Add _
                ( _
                    New Object() _
                    { _
                        CustomerID, _
                        ProductID, _
                        UnitPrice, _
                        Quantity _
                    } _
                )

        Catch Xcp As System.Exception

            MessageBox.Show(Xcp.ToString, "Unexpected exception", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    ' Added in Lab 4.2 Exercise 4

    Private Sub FilterMenus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDiscontinued.Click, mnuOutOfStock.Click, mnuProducts.Click

        ' toggle the check mark next to the menu item that sent the event message

        If Not sender Is mnuProducts Then
            sender.Checked = Not sender.Checked
        End If

        ' declare and instantiate a new DataView

        Dim dvProducts As New DataView(Me.dsCatProd.Tables("Products"))

        ' depending on the Checked property of the two menu items,
        ' set the RowFilter appropriately

        If Not mnuOutOfStock.Checked And Not mnuDiscontinued.Checked Then

            dvProducts.RowFilter = "Discontinued=False And UnitsInStock>0"

        ElseIf Not mnuOutOfStock.Checked Then

            dvProducts.RowFilter = "UnitsInStock>0"

        ElseIf Not mnuDiscontinued.Checked Then

            dvProducts.RowFilter = "Discontinued=False"

        End If

        ' set the DataGrid to use the DataView to show the products

        Me.grd.DataSource = dvProducts

    End Sub

    Private Sub mnuView_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView.Select

        mnuDiscontinued.Enabled = mnuProducts.Checked
        mnuOutOfStock.Enabled = mnuProducts.Checked

    End Sub

End Class
