Public Class frmConnectedApp
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblMinimumPrice As System.Windows.Forms.Label
    Friend WithEvents lblMaximumPrice As System.Windows.Forms.Label
    Friend WithEvents txtMinimumPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtMaximumPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnCountProducts As System.Windows.Forms.Button
            Friend WithEvents btnDisplayProducts As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstOutOfStock As System.Windows.Forms.ListBox
                Friend WithEvents cnNorthwind As System.Data.SqlClient.SqlConnection
    Friend WithEvents cmCountProducts As System.Data.SqlClient.SqlCommand
    Friend WithEvents lstInStock As System.Windows.Forms.ListBox
    Friend WithEvents lblInStock As System.Windows.Forms.Label
    Friend WithEvents cmGetProductsInRange As System.Data.SqlClient.SqlCommand
    Friend WithEvents lstOrderSummary As System.Windows.Forms.ListBox
    Friend WithEvents btnSummarizeOrders As System.Windows.Forms.Button
    Friend WithEvents lblOrderSummary As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCountProducts = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstOrderSummary = New System.Windows.Forms.ListBox()
        Me.btnSummarizeOrders = New System.Windows.Forms.Button()
        Me.lblOrderSummary = New System.Windows.Forms.Label()
        Me.cnNorthwind = New System.Data.SqlClient.SqlConnection()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lstOutOfStock = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDisplayProducts = New System.Windows.Forms.Button()
        Me.lstInStock = New System.Windows.Forms.ListBox()
        Me.lblInStock = New System.Windows.Forms.Label()
        Me.txtMaximumPrice = New System.Windows.Forms.TextBox()
        Me.txtMinimumPrice = New System.Windows.Forms.TextBox()
        Me.lblMaximumPrice = New System.Windows.Forms.Label()
        Me.lblMinimumPrice = New System.Windows.Forms.Label()
        Me.cmCountProducts = New System.Data.SqlClient.SqlCommand()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.cmGetProductsInRange = New System.Data.SqlClient.SqlCommand()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCountProducts
        '
        Me.btnCountProducts.Location = New System.Drawing.Point(280, 32)
        Me.btnCountProducts.Name = "btnCountProducts"
        Me.btnCountProducts.Size = New System.Drawing.Size(104, 24)
        Me.btnCountProducts.TabIndex = 4
        Me.btnCountProducts.Text = "Count Products"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstOrderSummary, Me.btnSummarizeOrders, Me.lblOrderSummary})
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(392, 262)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Product Orders"
        '
        'lstOrderSummary
        '
        Me.lstOrderSummary.Location = New System.Drawing.Point(8, 64)
        Me.lstOrderSummary.Name = "lstOrderSummary"
        Me.lstOrderSummary.Size = New System.Drawing.Size(256, 186)
        Me.lstOrderSummary.TabIndex = 2
        '
        'btnSummarizeOrders
        '
        Me.btnSummarizeOrders.Location = New System.Drawing.Point(272, 64)
        Me.btnSummarizeOrders.Name = "btnSummarizeOrders"
        Me.btnSummarizeOrders.Size = New System.Drawing.Size(112, 24)
        Me.btnSummarizeOrders.TabIndex = 0
        Me.btnSummarizeOrders.Text = "Summarize Orders"
        '
        'lblOrderSummary
        '
        Me.lblOrderSummary.Location = New System.Drawing.Point(8, 40)
        Me.lblOrderSummary.Name = "lblOrderSummary"
        Me.lblOrderSummary.Size = New System.Drawing.Size(368, 16)
        Me.lblOrderSummary.TabIndex = 1
        Me.lblOrderSummary.Text = "Obtain the total number of orders for each product."
        '
        'cnNorthwind
        '
        Me.cnNorthwind.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" & _
        "curity info=False;packet size=4096"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstOutOfStock, Me.Label1, Me.btnDisplayProducts, Me.lstInStock, Me.lblInStock, Me.btnCountProducts, Me.txtMaximumPrice, Me.txtMinimumPrice, Me.lblMaximumPrice, Me.lblMinimumPrice})
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(392, 262)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Product Prices"
        '
        'lstOutOfStock
        '
        Me.lstOutOfStock.Location = New System.Drawing.Point(8, 184)
        Me.lstOutOfStock.Name = "lstOutOfStock"
        Me.lstOutOfStock.Size = New System.Drawing.Size(256, 69)
        Me.lstOutOfStock.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Out-of-stock products in price range"
        '
        'btnDisplayProducts
        '
        Me.btnDisplayProducts.Location = New System.Drawing.Point(280, 72)
        Me.btnDisplayProducts.Name = "btnDisplayProducts"
        Me.btnDisplayProducts.Size = New System.Drawing.Size(104, 24)
        Me.btnDisplayProducts.TabIndex = 5
        Me.btnDisplayProducts.Text = "Display Products"
        '
        'lstInStock
        '
        Me.lstInStock.Location = New System.Drawing.Point(8, 88)
        Me.lstInStock.Name = "lstInStock"
        Me.lstInStock.Size = New System.Drawing.Size(256, 69)
        Me.lstInStock.TabIndex = 7
        '
        'lblInStock
        '
        Me.lblInStock.Location = New System.Drawing.Point(8, 72)
        Me.lblInStock.Name = "lblInStock"
        Me.lblInStock.Size = New System.Drawing.Size(240, 16)
        Me.lblInStock.TabIndex = 6
        Me.lblInStock.Text = "In-stock products in price range"
        '
        'txtMaximumPrice
        '
        Me.txtMaximumPrice.Location = New System.Drawing.Point(224, 32)
        Me.txtMaximumPrice.Name = "txtMaximumPrice"
        Me.txtMaximumPrice.Size = New System.Drawing.Size(40, 20)
        Me.txtMaximumPrice.TabIndex = 3
        Me.txtMaximumPrice.Text = ""
        '
        'txtMinimumPrice
        '
        Me.txtMinimumPrice.Location = New System.Drawing.Point(88, 32)
        Me.txtMinimumPrice.Name = "txtMinimumPrice"
        Me.txtMinimumPrice.Size = New System.Drawing.Size(40, 20)
        Me.txtMinimumPrice.TabIndex = 1
        Me.txtMinimumPrice.Text = ""
        '
        'lblMaximumPrice
        '
        Me.lblMaximumPrice.Location = New System.Drawing.Point(144, 32)
        Me.lblMaximumPrice.Name = "lblMaximumPrice"
        Me.lblMaximumPrice.Size = New System.Drawing.Size(88, 16)
        Me.lblMaximumPrice.TabIndex = 2
        Me.lblMaximumPrice.Text = "Maximum price:"
        '
        'lblMinimumPrice
        '
        Me.lblMinimumPrice.Location = New System.Drawing.Point(8, 32)
        Me.lblMinimumPrice.Name = "lblMinimumPrice"
        Me.lblMinimumPrice.Size = New System.Drawing.Size(88, 16)
        Me.lblMinimumPrice.TabIndex = 0
        Me.lblMinimumPrice.Text = "Minimum price:"
        '
        'cmCountProducts
        '
        Me.cmCountProducts.CommandText = "dbo.CountProducts"
        Me.cmCountProducts.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmCountProducts.Connection = Me.cnNorthwind
        Me.cmCountProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmCountProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Min", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmCountProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Max", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(400, 288)
        Me.TabControl1.TabIndex = 0
        '
        'cmGetProductsInRange
        '
        Me.cmGetProductsInRange.CommandText = "dbo.GetProductsInRange"
        Me.cmGetProductsInRange.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmGetProductsInRange.Connection = Me.cnNorthwind
        Me.cmGetProductsInRange.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmGetProductsInRange.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Min", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmGetProductsInRange.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Max", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'frmConnectedApp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 301)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmConnectedApp"
        Me.Text = "Connected ADO.NET Application"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCountProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountProducts.Click

        ' Get the text in the txtMinimumPrice and txtMaximumPrice text boxes
        Dim min, max As Double
        min = Double.Parse(txtMinimumPrice.Text)
        max = Double.Parse(txtMaximumPrice.Text)

        ' Set the @Min and @Max parameters for the cmCountProducts stored procedure
        cmCountProducts.Parameters("@Min").Value = min
        cmCountProducts.Parameters("@Max").Value = max

        ' Open a connection to the Northwind database
        cnNorthwind.Open()

        ' Execute the cmCountProducts stored procedure command
        Dim iProductsCount As Integer = cmCountProducts.ExecuteScalar()

        ' Close the database connection 
        cnNorthwind.Close()

        ' Display the return value from the cmCountProducts stored procedure command
        MessageBox.Show("There are " & iProductsCount.ToString() & " products in this price range.", _
                        "Products costing between $" & min & " and $" & max)


    End Sub

    Private Sub btnDisplayProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayProducts.Click

        ' Clear the In-Stock listbox
        lstInStock.Items.Clear()

        ' Get the text in the txtMinimumPrice and txtMaximumPrice text boxes
        Dim min, max As Double
        min = Double.Parse(txtMinimumPrice.Text)
        max = Double.Parse(txtMaximumPrice.Text)

        ' Set the @Min and @Max parameters for the cmGetProductsInRange stored procedure
        cmGetProductsInRange.Parameters("@Min").Value = min
        cmGetProductsInRange.Parameters("@Max").Value = max

        ' Open a connection to the Northwind database
        cnNorthwind.Open()

        ' Execute the cmGetProductsInRange stored procedure command
        Dim drProducts As System.Data.SqlClient.SqlDataReader
        drProducts = cmGetProductsInRange.ExecuteReader()

        ' Loop through the In-Stock records
        While drProducts.Read()

            ' Get the product ID, product name, and unit price
            Dim id As System.Int32 = drProducts.GetInt32(0)
            Dim name As String = drProducts.GetString(1)
            Dim price As Double = drProducts.GetSqlMoney(2).ToDouble()

            ' Display details in the lstInStock list box
            lstInStock.Items.Add("ID: " & id & vbTab & name & ", $" & price)
        End While

        ' Advance to the next result in the SqlDataReader
        drProducts.NextResult()

        ' Clear the Out-Of-Stock listbox
        lstOutOfStock.Items.Clear()

        ' Loop through the Out-Of-Stock records
        While drProducts.Read()

            ' Get the product ID, product name, and unit price
            Dim id As System.Int32 = drProducts.GetInt32(0)
            Dim name As String = drProducts.GetString(1)
            Dim price As Double = drProducts.GetSqlMoney(2).ToDouble()

            ' Display details in the lstOutOfStock list box
            lstOutOfStock.Items.Add("ID: " & id & vbTab & name & ", $" & price)
        End While

        ' Close the data reader
        drProducts.Close()

        ' Close the database connection 
        cnNorthwind.Close()

    End Sub
End Class
