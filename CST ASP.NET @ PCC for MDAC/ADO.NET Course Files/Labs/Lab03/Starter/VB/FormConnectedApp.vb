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
                Friend WithEvents lstInStock As System.Windows.Forms.ListBox
    Friend WithEvents lblInStock As System.Windows.Forms.Label
    Friend WithEvents lstOrderSummary As System.Windows.Forms.ListBox
    Friend WithEvents btnSummarizeOrders As System.Windows.Forms.Button
    Friend WithEvents lblOrderSummary As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lstOutOfStock = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDisplayProducts = New System.Windows.Forms.Button()
        Me.lstInStock = New System.Windows.Forms.ListBox()
        Me.lblInStock = New System.Windows.Forms.Label()
        Me.btnCountProducts = New System.Windows.Forms.Button()
        Me.txtMaximumPrice = New System.Windows.Forms.TextBox()
        Me.txtMinimumPrice = New System.Windows.Forms.TextBox()
        Me.lblMaximumPrice = New System.Windows.Forms.Label()
        Me.lblMinimumPrice = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstOrderSummary = New System.Windows.Forms.ListBox()
        Me.btnSummarizeOrders = New System.Windows.Forms.Button()
        Me.lblOrderSummary = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
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
        'btnCountProducts
        '
        Me.btnCountProducts.Location = New System.Drawing.Point(280, 32)
        Me.btnCountProducts.Name = "btnCountProducts"
        Me.btnCountProducts.Size = New System.Drawing.Size(104, 24)
        Me.btnCountProducts.TabIndex = 4
        Me.btnCountProducts.Text = "Count Products"
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
        'frmConnectedApp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 301)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmConnectedApp"
        Me.Text = "Connected ADO.NET Application"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
