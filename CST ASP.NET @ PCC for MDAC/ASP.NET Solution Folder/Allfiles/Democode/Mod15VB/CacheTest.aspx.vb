Public Class CacheTest
    Inherits System.Web.UI.Page
    Protected WithEvents dgXML As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dsXML As System.Data.DataSet

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsXML = New System.Data.DataSet()
        CType(Me.dsXML, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsXML
        '
        Me.dsXML.DataSetName = "NewDataSet"
        Me.dsXML.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsXML, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dsXML.ReadXml(Server.MapPath("pubs.xml"))

        dgXML.DataSource = dsXML 'comment this line for caching
        dgXML.DataBind() 'comment this line for caching

        'If Not Page.IsPostBack Then
        '    Cache.Insert("dsCache", dsXML, Nothing, DateTime.Now.AddMinutes(2), Nothing)
        '    dgXML.DataSource = Cache("dsCache")
        '    dgXML.DataBind()
        'End If

    End Sub

    Private Sub dgXML_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgXML.PageIndexChanged
        dgXML.CurrentPageIndex = e.NewPageIndex

        dgXML.DataSource = dsXML 'comment this line for caching
        dgXML.DataBind() 'comment this line for caching

        'If (Cache("dsCache") Is Nothing) Then
        '    Cache.Insert("dsCache", dsXML, Nothing, DateTime.Now.AddMinutes(2), Nothing)
        'End If
        'dgXML.DataSource = Cache("dsCache")
        'dgXML.DataBind()

    End Sub
End Class
