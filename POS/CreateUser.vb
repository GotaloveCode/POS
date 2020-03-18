Imports System.Data.SqlClient
Imports System.IO
Public Class CreateUser
    Private _affectedrows As Integer
    Dim command As SqlCommand
    Dim dr As SqlDataReader
    Dim adapter As SqlDataAdapter
    Dim builder As SqlCommandBuilder
    Dim ds As DataSet
    Dim tempDataSet As DataSet
    Dim dt As DataTable
    Private _user As String
    Private _userid As Integer
    Public Property userid() As Integer
        Get 'grabing the userid
            Return _userid
        End Get
        Set(ByVal Value As Integer)
            _userid = Value
        End Set
    End Property
    Public Property user() As String
        Get 'grabing the username
            Return _user
        End Get
        Set(ByVal Value As String)
            _user = Value
        End Set
    End Property
    Public Function Conn() As SqlConnection
        Dim settingsDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\POS"
        Dim fileName As String = "dbcon.xml"
        Dim settingsPath As String = System.IO.Path.Combine(settingsDirectory, fileName)
        Dim con As New SqlConnection
        Try
            Dim Xdoc As XDocument = XDocument.Load(settingsPath)
            Dim title = From t In Xdoc.Descendants("ServerName") Select t.Value
            Dim Servername1 As String = title.First
            Dim title2 = From t In Xdoc.Descendants("DatabaseName") Select t.Value
            Dim DatabaseName1 = title2.First()
            Dim title3 = From t In Xdoc.Descendants("UserID") Select t.Value
            Dim UserID1 = title3.First()
            Dim title4 = From t In Xdoc.Descendants("Password") Select t.Value
            Dim password1 = title4.First()
            con = New SqlConnection("Server=" & Servername1 & ";Database=" & DatabaseName1 & ";User ID=" & UserID1 & ";Password=" & password1 & ";")
            con.Open()
            Return con
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return con

    End Function
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim amuser As String = txtuser2.Text.Trim
        Dim Oldpas As String = txtOldPas.Text.Trim
        Dim NewPas As String = txtNewPas.Text.Trim
        Dim ConfirmNewPas As String = txtConfirmNewPas.Text.Trim
        Dim salt As String = "iriga"
        Dim rawSalted As String = salt & Oldpas
        Dim saltedPwBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(rawSalted)
        Dim sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider()
        Dim hashedPwBytes() As Byte = sha1.ComputeHash(saltedPwBytes)
        Dim hashedPw As String = Convert.ToBase64String(hashedPwBytes)
        Dim rawSalted2 As String = salt & NewPas
        Dim saltedPwBytes2() As Byte = System.Text.Encoding.Unicode.GetBytes(rawSalted2)
        Dim sha2 As New System.Security.Cryptography.SHA1CryptoServiceProvider()
        Dim hashedPwBytes2() As Byte = sha1.ComputeHash(saltedPwBytes2)
        Dim hashedPw2 As String = Convert.ToBase64String(hashedPwBytes2)
        If amuser.Length = 0 AndAlso Oldpas.Length < 8 Then
            MessageBox.Show("Please enter Username and valid password", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf NewPas <> ConfirmNewPas Then
            MessageBox.Show("Password mismatch", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                If cmbRole2.Enabled = False Then 'normal user qry
                    command = New SqlCommand("select * from users where username =@user and Password = @pass and active=1", Conn)
                    command.CommandType = CommandType.Text
                    command.Parameters.Add("@user", SqlDbType.VarChar).Value = amuser
                    command.Parameters.Add("@pass", SqlDbType.VarChar).Value = hashedPw
                    dr = command.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Close()
                        Conn.Close()
                        Dim cmd2 As New SqlCommand("update users set Password =@pasd where username=@user and Password= @pass", Conn)
                        cmd2.CommandType = CommandType.Text
                        cmd2.Parameters.Add("@pasd", SqlDbType.VarChar).Value = hashedPw2
                        cmd2.Parameters.Add("@user", SqlDbType.VarChar).Value = amuser
                        cmd2.Parameters.Add("@pass", SqlDbType.VarChar).Value = hashedPw
                        _affectedrows = cmd2.ExecuteNonQuery()

                        If _affectedrows > 0 Then
                            MessageBox.Show("User:" & amuser & " account updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("User account failed to update", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("Invalid user account information.No update made", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        txtuser2.Focus()
                    End If
                Else 'admin update query
                    command = New SqlCommand("update users set Password =@pasd,roleID=@roleid where ID=@usrid", Conn)
                    command.CommandType = CommandType.Text
                    command.Parameters.Add("@pasd", SqlDbType.VarChar).Value = hashedPw2
                    command.Parameters.Add("@roleid", SqlDbType.Int).Value = cmbRole2.SelectedValue
                    command.Parameters.Add("@usrid", SqlDbType.Int).Value = cmbuser.SelectedValue
                    _affectedrows = command.ExecuteNonQuery()
                    If _affectedrows > 0 Then
                        MessageBox.Show("User:" & cmbuser.Text & " account updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("User account failed to update", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("An error occured" & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub 'update account

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtuser.Clear()
        txtpas.Clear()
        txtpas2.Clear()
        CmbRole.SelectedIndex = -1
        txtfullname.Clear()
    End Sub 'clear create form

    Private Sub CreateUser_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            command = New SqlCommand("select * from users order by id asc", Conn)
            dr = command.ExecuteReader()
            Dim usertable As New DataTable
            usertable.Load(dr)
            dr.Close()
            Conn.Close()
            cmbuser.ValueMember = usertable.Columns(0).ColumnName 'id
            cmbuser.DisplayMember = usertable.Columns(1).ColumnName 'username
            cmbuser.DataSource = usertable

            command = New SqlCommand("select * from users where ID=" & _userid & "", Conn)
            dr = command.ExecuteReader()
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item("roleID") > 2 And dr.Item("roleID") < 5 Then 'admin=3,superadmin=4
                    GroupBox1.Visible = True 'show create user panel as is admin
                    cmbRole2.Enabled = True 'enable as is admin can change role
                    cmbuser.Visible = True 'is admin view user & update
                    txtuser2.Visible = False 'is admin no need for txtbox
                Else
                    GroupBox1.Visible = False
                    cmbuser.Visible = False
                    cmbRole2.Enabled = False
                    txtuser2.Visible = True
                    txtuser2.Text = dr.Item("username")
                End If
                dr.Close()
            End If
        Catch ex As SqlException
            MessageBox.Show("An SQL error occured:" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occured:" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Conn.Close()
        End Try
        Try
            command = New SqlCommand("select * from roles order by ID asc", Conn)
            dr = command.ExecuteReader()
            dt = New DataTable
            For j As Integer = 0 To dt.Rows.Count - 1
                dr.Read()
            Next
            dt.Load(dr)
            Dim dt2 As New DataTable
            dt2 = dt.Copy
            CmbRole.ValueMember = dt.Columns(0).ColumnName
            CmbRole.DisplayMember = dt.Columns(1).ColumnName
            CmbRole.DataSource = dt
            cmbRole2.ValueMember = dt2.Columns(0).ColumnName
            cmbRole2.DisplayMember = dt2.Columns(1).ColumnName
            cmbRole2.DataSource = dt2
        Catch ex As SqlException
            MessageBox.Show("An SQL error occured:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occured:" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dr.Close()
            Conn.Close()
        End Try
    End Sub 'load

    Private Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreate.Click
        Dim usr As String = txtuser.Text.Trim
        Dim pas As String = txtpas.Text.Trim
        Dim pas2 As String = txtpas2.Text.Trim
        Dim fullname As String = txtfullname.Text.Trim
        Dim salt As String = "iriga"
        Dim rawSalted As String = salt & pas
        Dim saltedPwBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(rawSalted)
        Dim sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider()
        Dim hashedPwBytes() As Byte = sha1.ComputeHash(saltedPwBytes)
        Dim hashedPw As String = Convert.ToBase64String(hashedPwBytes)
        If usr.Length = 0 AndAlso pas.Length < 8 Then
            MessageBox.Show("Please enter Username and valid password of at least 8 characters", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf pas <> pas2 Then
            MessageBox.Show("Password mismatch", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                command = New SqlCommand("select ID from users where username=@user or Fullnames=@fname", Conn)
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@user", usr)
                command.Parameters.AddWithValue("@fname", fullname)
                dr = command.ExecuteReader()
                If dr.HasRows = False Then 'if username not used create user account
                    dr.Close()
                    Conn.Close()
                    Try
                        command = New SqlCommand("insert into users(username,password,Fullnames,roleID,Createdby,Createdon,active) values (@usr,@hashedpw,@flname,@role,@creator,@date,1)", Conn)
                        command.CommandType = CommandType.Text
                        command.Parameters.AddWithValue("@usr", usr)
                        command.Parameters.AddWithValue("@hashedpw", hashedPw)
                        command.Parameters.AddWithValue("@flname", fullname)
                        command.Parameters.AddWithValue("@role", CmbRole.SelectedValue)
                        command.Parameters.AddWithValue("@creator", _user)
                        command.Parameters.AddWithValue("@date", System.DateTime.Now)
                        _affectedrows = command.ExecuteNonQuery()
                        If _affectedrows < 0 Then
                            MsgBox("Create user account failed", MsgBoxStyle.Exclamation, Title:="Create User Failed")
                        Else
                            MsgBox("User: " & usr & " has been added to records", MsgBoxStyle.Information, Title:="Success")
                        End If
                        btnclearchanges_Click(Nothing, Nothing)
                    Catch ex As SqlException
                        MsgBox("An SQL Error occured:" & ex.Message, MsgBoxStyle.Exclamation, Title:="Error Message")
                    Finally
                        Conn.Close()
                    End Try
                Else
                    dr.Close()
                    Conn.Close()
                    MsgBox("A User Account with either username " & usr & " or fullname " & fullname & " already exists" & Environment.NewLine & "Please try another username or fullname", MsgBoxStyle.Exclamation, Title:="Duplicate User Account")
                    txtuser.Focus()
                End If
            Catch ex As Exception
                MsgBox("An unexpected Error occured " & Environment.NewLine & _
                       "Please contact admin to resolve:" & ex.Message, MsgBoxStyle.Exclamation, Title:="Error Message")
            End Try
            btnclear_Click(Nothing, Nothing)
        End If
    End Sub 'create account

    Private Sub btnclearchanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclearchanges.Click
        txtOldPas.Clear()
        txtNewPas.Clear()
        txtConfirmNewPas.Clear()
        cmbuser.SelectedIndex = -1
        cmbRole2.SelectedIndex = -1
    End Sub 'clear update form

    Private Sub txtfullname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfullname.KeyPress
        Dim str As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz .'" & ChrW(8)
        If Not str.Contains(Convert.ToChar(e.KeyChar)) Or (Asc(e.KeyChar) = 22) Then
            e.Handled = True
        End If
    End Sub
End Class