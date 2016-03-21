Public Class ListboundControls
    Inherits System.Web.UI.Page
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents CheckBoxList1 As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents RadioButtonList1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataSet3 As Mod09VB.DataSet3
    Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.DataSet3 = New Mod09VB.DataSet3()
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "stores", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("stor_id", "stor_id"), New System.Data.Common.DataColumnMapping("stor_name", "stor_name"), New System.Data.Common.DataColumnMapping("stor_address", "stor_address"), New System.Data.Common.DataColumnMapping("city", "city"), New System.Data.Common.DataColumnMapping("state", "state"), New System.Data.Common.DataColumnMapping("zip", "zip")})})
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM stores WHERE (stor_id = @stor_id) AND (city = @city OR @city1 IS NULL" & _
        " AND city IS NULL) AND (state = @state OR @state1 IS NULL AND state IS NULL) AND" & _
        " (stor_address = @stor_address OR @stor_address1 IS NULL AND stor_address IS NUL" & _
        "L) AND (stor_name = @stor_name OR @stor_name1 IS NULL AND stor_name IS NULL) AND" & _
        " (zip = @zip OR @zip1 IS NULL AND zip IS NULL)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "stor_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@city1", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@state1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_address1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_name", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_name1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_name", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@zip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=pubs;integrated security=SSPI;persist secur" & _
        "ity info=True;packet size=4096"
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO stores(stor_id, stor_name, stor_address, city, state, zip) VALUES (@s" & _
        "tor_id, @stor_name, @stor_address, @city, @state, @zip); SELECT stor_id, stor_na" & _
        "me, stor_address, city, state, zip FROM stores WHERE (stor_id = @Select_stor_id)" & _
        ""
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "stor_id", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_name", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_address", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Select_stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "stor_id", System.Data.DataRowVersion.Current, Nothing))
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE stores SET stor_id = @stor_id, stor_name = @stor_name, stor_address = @sto" & _
        "r_address, city = @city, state = @state, zip = @zip WHERE (stor_id = @Original_s" & _
        "tor_id) AND (city = @Original_city OR @Original_city1 IS NULL AND city IS NULL) " & _
        "AND (state = @Original_state OR @Original_state1 IS NULL AND state IS NULL) AND " & _
        "(stor_address = @Original_stor_address OR @Original_stor_address1 IS NULL AND st" & _
        "or_address IS NULL) AND (stor_name = @Original_stor_name OR @Original_stor_name1" & _
        " IS NULL AND stor_name IS NULL) AND (zip = @Original_zip OR @Original_zip1 IS NU" & _
        "LL AND zip IS NULL); SELECT stor_id, stor_name, stor_address, city, state, zip F" & _
        "ROM stores WHERE (stor_id = @Select_stor_id)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "stor_id", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_name", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_address", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "stor_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_city1", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_state1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_stor_address1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_name", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_stor_name1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "stor_name", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_zip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Select_stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "stor_id", System.Data.DataRowVersion.Current, Nothing))
        '
        'DataSet3
        '
        Me.DataSet3.DataSetName = "DataSet3"
        Me.DataSet3.Locale = New System.Globalization.CultureInfo("en-US")
        Me.DataSet3.Namespace = "http://www.tempuri.org/DataSet3.xsd"
        CType(Me.DataSet3, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            SqlDataAdapter1.Fill(DataSet3)

            'dropdownlist
            DropDownList1.DataBind()
            'listbox
            ListBox1.DataBind()
            'checkbox list
            CheckBoxList1.DataBind()
            'radiobutton list
            RadioButtonList1.DataBind()
        End If
    End Sub

End Class
