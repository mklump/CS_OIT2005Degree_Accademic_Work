Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Added in Lab 4.1 Exercise 2

    Public Filename As System.String

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
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuNew = New System.Windows.Forms.MenuItem()
        Me.dcCost = New System.Data.DataColumn()
        Me.dcAddress = New System.Data.DataColumn()
        Me.s2 = New System.Windows.Forms.MenuItem()
        Me.mnuCustomer = New System.Windows.Forms.MenuItem()
        Me.dcProductID = New System.Data.DataColumn()
        Me.mnuOpen = New System.Windows.Forms.MenuItem()
        Me.mnuSave = New System.Windows.Forms.MenuItem()
        Me.mnuProducts = New System.Windows.Forms.MenuItem()
        Me.grd = New System.Windows.Forms.DataGrid()
        Me.mnuCartItems = New System.Windows.Forms.MenuItem()
        Me.dcCity = New System.Data.DataColumn()
        Me.dtCustomer = New System.Data.DataTable()
        Me.dcCustomerID = New System.Data.DataColumn()
        Me.dcCompanyName = New System.Data.DataColumn()
        Me.mnuSaveAs = New System.Windows.Forms.MenuItem()
        Me.dsShoppingCart = New System.Data.DataSet()
        Me.dtCartItems = New System.Data.DataTable()
        Me.dcCustomerID2 = New System.Data.DataColumn()
        Me.dcUnitPrice = New System.Data.DataColumn()
        Me.dcQuantity = New System.Data.DataColumn()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.s1 = New System.Windows.Forms.MenuItem()
        Me.mnuSubtotal = New System.Windows.Forms.MenuItem()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuView = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsShoppingCart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCartItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuExit
        '
        Me.mnuExit.Index = 6
        Me.mnuExit.Text = "E&xit"
        '
        'mnuNew
        '
        Me.mnuNew.Index = 0
        Me.mnuNew.Text = "&New"
        '
        'dcCost
        '
        Me.dcCost.ColumnName = "Cost"
        Me.dcCost.DataType = GetType(System.Decimal)
        Me.dcCost.Expression = "UnitPrice * Quantity"
        Me.dcCost.ReadOnly = True
        '
        'dcAddress
        '
        Me.dcAddress.ColumnName = "Address"
        Me.dcAddress.MaxLength = 60
        '
        's2
        '
        Me.s2.Index = 5
        Me.s2.Text = "-"
        '
        'mnuCustomer
        '
        Me.mnuCustomer.Index = 0
        Me.mnuCustomer.Shortcut = System.Windows.Forms.Shortcut.F7
        Me.mnuCustomer.Text = "&Customer"
        '
        'dcProductID
        '
        Me.dcProductID.AllowDBNull = False
        Me.dcProductID.ColumnName = "ProductID"
        Me.dcProductID.DataType = GetType(System.Int32)
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 1
        Me.mnuOpen.Text = "&Open..."
        '
        'mnuSave
        '
        Me.mnuSave.Index = 3
        Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSave.Text = "&Save"
        '
        'mnuProducts
        '
        Me.mnuProducts.Index = 2
        Me.mnuProducts.Shortcut = System.Windows.Forms.Shortcut.CtrlF7
        Me.mnuProducts.Text = "&Products"
        '
        'grd
        '
        Me.grd.DataMember = ""
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(368, 289)
        Me.grd.TabIndex = 0
        '
        'mnuCartItems
        '
        Me.mnuCartItems.Index = 1
        Me.mnuCartItems.Shortcut = System.Windows.Forms.Shortcut.ShiftF7
        Me.mnuCartItems.Text = "Cart &Items"
        '
        'dcCity
        '
        Me.dcCity.ColumnName = "City"
        Me.dcCity.MaxLength = 15
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
        'mnuSaveAs
        '
        Me.mnuSaveAs.Index = 4
        Me.mnuSaveAs.Text = "Save &As..."
        '
        'dsShoppingCart
        '
        Me.dsShoppingCart.DataSetName = "NewDataSet"
        Me.dsShoppingCart.Locale = New System.Globalization.CultureInfo("en-US")
        Me.dsShoppingCart.Tables.AddRange(New System.Data.DataTable() {Me.dtCustomer, Me.dtCartItems})
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
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "ds"
        Me.dlgSave.Filter = "DataSet files (*.ds)|*.ds"
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuOpen, Me.s1, Me.mnuSave, Me.mnuSaveAs, Me.s2, Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        's1
        '
        Me.s1.Index = 2
        Me.s1.Text = "-"
        '
        'mnuSubtotal
        '
        Me.mnuSubtotal.Index = 4
        Me.mnuSubtotal.Shortcut = System.Windows.Forms.Shortcut.F9
        Me.mnuSubtotal.Text = "Cart &Subtotal"
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "DataSet files (*.ds)|*.ds|All files (*.*)|*.*"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuView})
        '
        'mnuView
        '
        Me.mnuView.Index = 1
        Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCustomer, Me.mnuCartItems, Me.mnuProducts, Me.MenuItem2, Me.mnuSubtotal})
        Me.mnuView.Text = "&View"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.Text = "-"
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
        CType(Me.dtCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsShoppingCart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCartItems, System.ComponentModel.ISupportInitialize).EndInit()
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

    End Sub

    Private Sub mnuCartItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCartItems.Click

        ' Added in Lab 4.1 Exercise 3

        Me.grd.DataSource = New DataView(Me.dsShoppingCart.Tables("CartItems"))

        Me.mnuCustomer.Checked = False
        Me.mnuCartItems.Checked = True

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

End Class
