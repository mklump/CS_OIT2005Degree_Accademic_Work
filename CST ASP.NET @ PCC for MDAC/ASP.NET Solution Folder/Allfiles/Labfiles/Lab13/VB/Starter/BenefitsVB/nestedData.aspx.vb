Public Class nestedData
    Inherits System.Web.UI.Page
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Protected WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlDeleteCommand2 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlSelectCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlInsertCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlUpdateCommand3 As System.Data.SqlClient.SqlCommand
    Protected WithEvents daDoctors As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents daDrSpecialties As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents daSpecialties As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents SqlDeleteCommand3 As System.Data.SqlClient.SqlCommand

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.daDoctors = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlInsertCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.daDrSpecialties = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlSelectCommand3 = New System.Data.SqlClient.SqlCommand()
        Me.SqlInsertCommand3 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand3 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand3 = New System.Data.SqlClient.SqlCommand()
        Me.daSpecialties = New System.Data.SqlClient.SqlDataAdapter()
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
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
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=doctors;integrated security=SSPI;persist " & _
        "security info=True;packet size=4096"
        '
        'daDoctors
        '
        Me.daDoctors.DeleteCommand = Me.SqlDeleteCommand1
        Me.daDoctors.InsertCommand = Me.SqlInsertCommand1
        Me.daDoctors.SelectCommand = Me.SqlSelectCommand1
        Me.daDoctors.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "doctors", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("dr_id", "dr_id"), New System.Data.Common.DataColumnMapping("dr_lname", "dr_lname"), New System.Data.Common.DataColumnMapping("dr_fname", "dr_fname"), New System.Data.Common.DataColumnMapping("phone", "phone"), New System.Data.Common.DataColumnMapping("address", "address"), New System.Data.Common.DataColumnMapping("city", "city"), New System.Data.Common.DataColumnMapping("state", "state"), New System.Data.Common.DataColumnMapping("zip", "zip")})})
        Me.daDoctors.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlSelectCommand2
        '
        Me.SqlSelectCommand2.CommandText = "SELECT dr_id, specialty_id FROM drspecialties"
        Me.SqlSelectCommand2.Connection = Me.SqlConnection1
        '
        'SqlInsertCommand2
        '
        Me.SqlInsertCommand2.CommandText = "INSERT INTO drspecialties(dr_id, specialty_id) VALUES (@dr_id, @specialty_id); SE" & _
        "LECT dr_id, specialty_id FROM drspecialties WHERE (dr_id = @dr_id) AND (specialt" & _
        "y_id = @specialty_id)"
        Me.SqlInsertCommand2.Connection = Me.SqlConnection1
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"))
        Me.SqlInsertCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@specialty_id", System.Data.SqlDbType.SmallInt, 2, "specialty_id"))
        '
        'SqlUpdateCommand2
        '
        Me.SqlUpdateCommand2.CommandText = "UPDATE drspecialties SET dr_id = @dr_id, specialty_id = @specialty_id WHERE (dr_i" & _
        "d = @Original_dr_id) AND (specialty_id = @Original_specialty_id); SELECT dr_id, " & _
        "specialty_id FROM drspecialties WHERE (dr_id = @dr_id) AND (specialty_id = @spec" & _
        "ialty_id)"
        Me.SqlUpdateCommand2.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@specialty_id", System.Data.SqlDbType.SmallInt, 2, "specialty_id"))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_specialty_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "specialty_id", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDeleteCommand2
        '
        Me.SqlDeleteCommand2.CommandText = "DELETE FROM drspecialties WHERE (dr_id = @Original_dr_id) AND (specialty_id = @Or" & _
        "iginal_specialty_id)"
        Me.SqlDeleteCommand2.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "dr_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_specialty_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "specialty_id", System.Data.DataRowVersion.Original, Nothing))
        '
        'daDrSpecialties
        '
        Me.daDrSpecialties.DeleteCommand = Me.SqlDeleteCommand2
        Me.daDrSpecialties.InsertCommand = Me.SqlInsertCommand2
        Me.daDrSpecialties.SelectCommand = Me.SqlSelectCommand2
        Me.daDrSpecialties.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "drspecialties", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("dr_id", "dr_id"), New System.Data.Common.DataColumnMapping("specialty_id", "specialty_id")})})
        Me.daDrSpecialties.UpdateCommand = Me.SqlUpdateCommand2
        '
        'SqlSelectCommand3
        '
        Me.SqlSelectCommand3.CommandText = "SELECT spec_id, specialty FROM specialties"
        Me.SqlSelectCommand3.Connection = Me.SqlConnection1
        '
        'SqlInsertCommand3
        '
        Me.SqlInsertCommand3.CommandText = "INSERT INTO specialties(spec_id, specialty) VALUES (@spec_id, @specialty); SELECT" & _
        " spec_id, specialty FROM specialties WHERE (spec_id = @spec_id)"
        Me.SqlInsertCommand3.Connection = Me.SqlConnection1
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@spec_id", System.Data.SqlDbType.SmallInt, 2, "spec_id"))
        Me.SqlInsertCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@specialty", System.Data.SqlDbType.VarChar, 20, "specialty"))
        '
        'SqlUpdateCommand3
        '
        Me.SqlUpdateCommand3.CommandText = "UPDATE specialties SET spec_id = @spec_id, specialty = @specialty WHERE (spec_id " & _
        "= @Original_spec_id) AND (specialty = @Original_specialty); SELECT spec_id, spec" & _
        "ialty FROM specialties WHERE (spec_id = @spec_id)"
        Me.SqlUpdateCommand3.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@spec_id", System.Data.SqlDbType.SmallInt, 2, "spec_id"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@specialty", System.Data.SqlDbType.VarChar, 20, "specialty"))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_spec_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "spec_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_specialty", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "specialty", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDeleteCommand3
        '
        Me.SqlDeleteCommand3.CommandText = "DELETE FROM specialties WHERE (spec_id = @Original_spec_id) AND (specialty = @Ori" & _
        "ginal_specialty)"
        Me.SqlDeleteCommand3.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_spec_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "spec_id", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_specialty", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "specialty", System.Data.DataRowVersion.Original, Nothing))
        '
        'daSpecialties
        '
        Me.daSpecialties.DeleteCommand = Me.SqlDeleteCommand3
        Me.daSpecialties.InsertCommand = Me.SqlInsertCommand3
        Me.daSpecialties.SelectCommand = Me.SqlSelectCommand3
        Me.daSpecialties.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "specialties", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("spec_id", "spec_id"), New System.Data.Common.DataColumnMapping("specialty", "specialty")})})
        Me.daSpecialties.UpdateCommand = Me.SqlUpdateCommand3

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsDoctorsSpecialties As New DataSet()
        daDoctors.Fill(dsDoctorsSpecialties, "doctors")
        daDrSpecialties.Fill(dsDoctorsSpecialties, "drspecialties")
        daSpecialties.Fill(dsDoctorsSpecialties, "specialties")
        Dim dr1 As DataRelation

        'Link doctors DataTable and drspecialities DataTable together
        Dim parentCol1 As DataColumn
        Dim childCol1 As DataColumn
        parentCol1 = dsDoctorsSpecialties.Tables("doctors").Columns("dr_id")
        childCol1 = dsDoctorsSpecialties.Tables("drspecialties").Columns("dr_id")
        dr1 = New DataRelation("rel1", parentCol1, childCol1)
        'TODO: Lab 12, step 1, create a nested relationship  
        'dr1.Nested = True
        dsDoctorsSpecialties.Relations.Add(dr1)

        'Link specialities DataTable and drspecialities DataTable together
        Dim dr2 As DataRelation
        Dim parentCol2 As DataColumn
        Dim childCol2 As DataColumn
        parentCol2 = dsDoctorsSpecialties.Tables("specialties").Columns("spec_id")
        childCol2 = dsDoctorsSpecialties.Tables("drspecialties").Columns("specialty_id")
        dr2 = New DataRelation("rel2", parentCol2, childCol2)
        'TODO: Lab 12, step 2, create a nested relationship  
        dr2.Nested = True
        dsDoctorsSpecialties.Relations.Add(dr2)

        'output the result in xml
        dsDoctorsSpecialties.WriteXml(Server.MapPath("Output.xml"), XmlWriteMode.IgnoreSchema)
	Response.Redirect("Output.xml")

    End Sub

End Class
