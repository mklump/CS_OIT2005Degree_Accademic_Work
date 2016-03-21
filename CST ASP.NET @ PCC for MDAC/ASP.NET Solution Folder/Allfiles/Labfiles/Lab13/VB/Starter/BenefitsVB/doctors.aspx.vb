Imports System.Data.SqlClient
Imports System.Text

Public Class doctors1
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblSpecialties As System.Web.UI.WebControls.Label
    Protected WithEvents lstSpecialties As System.Web.UI.WebControls.ListBox
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Protected WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents DsDoctors1 As BenefitsVB.dsDoctors
    Protected WithEvents dgDoctors As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lstCities As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdSubmit As System.Web.UI.WebControls.Button

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
        Me.DsDoctors1 = New BenefitsVB.dsDoctors()
        CType(Me.DsDoctors1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=doctors;integrated security=SSPI;persist securi" & _
        "ty info=True"
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO doctors(dr_id, dr_lname, dr_fname, phone, address, city, state, zip) " & _
        "VALUES (@dr_id, @dr_lname, @dr_fname, @phone, @address, @city, @state, @zip); SE" & _
        "LECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors WH" & _
        "ERE (dr_id = @dr_id)"
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_lname", System.Data.SqlDbType.VarChar, 20, "dr_lname"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_fname", System.Data.SqlDbType.VarChar, 20, "dr_fname"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 10, "zip"))
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE doctors SET dr_id = @dr_id, dr_lname = @dr_lname, dr_fname = @dr_fname, ph" & _
        "one = @phone, address = @address, city = @city, state = @state, zip = @zip WHERE" & _
        " (dr_id = @Original_dr_id) AND (address = @Original_address OR @Original_address" & _
        " IS NULL AND address IS NULL) AND (city = @Original_city OR @Original_city IS NU" & _
        "LL AND city IS NULL) AND (dr_fname = @Original_dr_fname) AND (dr_lname = @Origin" & _
        "al_dr_lname) AND (phone = @Original_phone OR @Original_phone IS NULL AND phone I" & _
        "S NULL) AND (state = @Original_state OR @Original_state IS NULL AND state IS NUL" & _
        "L) AND (zip = @Original_zip OR @Original_zip IS NULL AND zip IS NULL); SELECT dr" & _
        "_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors WHERE (dr" & _
        "_id = @dr_id)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_lname", System.Data.SqlDbType.VarChar, 20, "dr_lname"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_fname", System.Data.SqlDbType.VarChar, 20, "dr_fname"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 10, "zip"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_fname", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_lname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_lname", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "phone", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM doctors WHERE (dr_id = @Original_dr_id) AND (address = @Original_addr" & _
        "ess OR @Original_address IS NULL AND address IS NULL) AND (city = @Original_city" & _
        " OR @Original_city IS NULL AND city IS NULL) AND (dr_fname = @Original_dr_fname)" & _
        " AND (dr_lname = @Original_dr_lname) AND (phone = @Original_phone OR @Original_p" & _
        "hone IS NULL AND phone IS NULL) AND (state = @Original_state OR @Original_state " & _
        "IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip IS NULL AND" & _
        " zip IS NULL)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "address", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "city", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_fname", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_lname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_lname", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "phone", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "state", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "zip", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "doctors", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("dr_id", "dr_id"), New System.Data.Common.DataColumnMapping("dr_lname", "dr_lname"), New System.Data.Common.DataColumnMapping("dr_fname", "dr_fname"), New System.Data.Common.DataColumnMapping("phone", "phone"), New System.Data.Common.DataColumnMapping("address", "address"), New System.Data.Common.DataColumnMapping("city", "city"), New System.Data.Common.DataColumnMapping("state", "state"), New System.Data.Common.DataColumnMapping("zip", "zip")})})
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            'TODO Lab 9: bind the datagrid to the doctors table
            dgDoctors.DataSource = DsDoctors1
            SqlDataAdapter1.Fill(DsDoctors1)
            dgDoctors.DataBind()

            'TODO Lab10: bind the listbox to city field in the doctors table
            'Dim cmdCities As New SqlCommand("SELECT city from doctors", SqlConnection1)
            'Dim drCities As SqlDataReader
            'SqlConnection1.Open()
            'drCities = cmdCities.ExecuteReader()
            'lstCities.DataSource = drCities
            'lstCities.DataTextField = "City"
            'lstCities.DataBind()
            'drCities.Close()
            'SqlConnection1.Close()

            'TODO Lab11: bind the listbox to the getUniqueCities stored procedure

            Dim cmdCities As SqlCommand = New SqlCommand("getUniqueCities", SqlConnection1)
            cmdCities.CommandType = CommandType.StoredProcedure
            SqlConnection1.Open()
            Dim drCities As SqlDataReader
            drCities = cmdCities.ExecuteReader()
            lstCities.DataSource = drCities
            lstCities.DataTextField = "City"
            lstCities.DataBind()
            drCities.Close()
            SqlConnection1.Close()


            'TODO Lab10: add the "All" item to the list and select it
            lstCities.Items.Add("[All]")
            lstCities.SelectedIndex = lstCities.Items.Count - 1

            'hide the specialties listbox
            lstSpecialties.Visible = False
            lblSpecialties.Visible = False

        End If
    End Sub

    Private Sub reset()
        'reset page index to 0
        dgDoctors.CurrentPageIndex = 0

        'remove the selection from the datagrid
        dgDoctors.SelectedIndex = -1

        'hide the specialites listbox
        lstSpecialties.Visible = False
        lblSpecialties.Visible = False
    End Sub

    Private Sub dgDoctors_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDoctors.PageIndexChanged
        Dim strCity As String = Trim(lstCities.SelectedItem.Text)
        dgDoctors.CurrentPageIndex = e.NewPageIndex
        SqlDataAdapter1.Fill(DsDoctors1)

        If strCity = "[All]" Then
            dgDoctors.DataSource = DsDoctors1
        Else
            Dim dvDocs As New DataView(DsDoctors1.Tables(0))
            dvDocs.RowFilter = "city = '" & strCity & "'"
            dgDoctors.DataSource = dvDocs
        End If
        dgDoctors.DataBind()


    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        Dim strName As String
        strName = Trim(dgDoctors.Items(dgDoctors.SelectedIndex).Cells(3).Text) & " " & _
            Trim(dgDoctors.Items(dgDoctors.SelectedIndex).Cells(2).Text)
        Response.Redirect("medical.aspx?pcp=" & strName)
    End Sub

    Private Sub lstCities_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCities.SelectedIndexChanged
        Dim strCity As String = Trim(lstCities.SelectedItem.Text)
        SqlDataAdapter1.Fill(DsDoctors1)
        If strCity = "[All]" Then
            dgDoctors.DataSource = DsDoctors1
        Else
            Dim dvDocs As New DataView(DsDoctors1.Tables(0))
            dvDocs.RowFilter = "city = '" & strCity & "'"
            dgDoctors.DataSource = dvDocs
        End If
        reset()
        dgDoctors.DataBind()
    End Sub

    Private Sub dgDoctors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDoctors.SelectedIndexChanged

        Dim strDrID As String
        strDrID = dgDoctors.SelectedItem.Cells.Item(1).Text

        Dim cmdSpecialty As New _
            SqlCommand("getDrSpecialty", SqlConnection1)
        cmdSpecialty.CommandType = CommandType.StoredProcedure

        Dim paramSpecialty As New SqlParameter _
            ("@dr_id", SqlDbType.Char, 4)
        paramSpecialty.Direction = ParameterDirection.Input
        paramSpecialty.Value = strDrID
        cmdSpecialty.Parameters.Add(paramSpecialty)

        SqlConnection1.Open()
        Dim drSpecialty As SqlDataReader
        drSpecialty = cmdSpecialty.ExecuteReader()

        lstSpecialties.DataSource = drSpecialty
        lstSpecialties.DataTextField = "Specialty"
        lstSpecialties.DataBind()
        drSpecialty.Close()
        SqlConnection1.Close()

        If Not IsDBNull(drSpecialty) Then
            lstSpecialties.Visible = True
            lblSpecialties.Visible = True
        End If


    End Sub
End Class
