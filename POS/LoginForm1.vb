Imports System.Data.SqlClient
Imports System.IO
Public Class LoginForm1

    Public Function Conn() As SqlConnection
        Dim settingsDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\POS"
        Dim fileName As String = "dbcon.xml"
        Dim settingsPath As String = System.IO.Path.Combine(settingsDirectory, fileName)
        Dim con As New SqlConnection
        If Not Directory.Exists(settingsDirectory) Then
            Directory.CreateDirectory(settingsDirectory)
        End If
        If Not File.Exists(settingsPath) Then
            Dim settingsDoc As New XDocument(New XElement("DatabaseConnection", New XElement("ServerName", ".\SQLEXPRESS"), New XElement("DatabaseName", "multi"), New XElement("UserID", "sa"), New XElement("Password", "iriga")))
            settingsDoc.Save(settingsPath)
        End If
       
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
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim user As String = txtuser.Text.Trim
        Dim pass As String = txtpass.Text.Trim
        Dim userno As Integer
        Dim salt As String = "iriga"
        'Create the salted hash.
        Dim rawSalted As String = salt & pass
        Dim sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider()
        Dim saltedPwBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(rawSalted)
        Dim hashedPwBytes() As Byte = sha1.ComputeHash(saltedPwBytes)
        Dim hashedPw As String = Convert.ToBase64String(hashedPwBytes)

        If user = "" Then
            MessageBox.Show("Please Enter Your Username !", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf pass = "" Then
            MessageBox.Show("Please Enter Your Password !", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim cmd As New SqlCommand("select ID,username,password from users where username = @user and password = @pass and active= 1", Conn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = hashedPw
            Try
                Dim dr As SqlDataReader = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If user = dr.Item("username").ToString And hashedPw = dr.Item("password").ToString Then
                        userno = dr.Item("ID")
                        dr.Close()
                        Dim par As New Parent
                        par.user = user
                        par.userid = userno
                        Me.Hide()
                        par.Show()
                        Me.Close()

                    ElseIf user.ToLower = dr.Item("username").ToString.ToLower And txtpass.Text.ToLower = dr.Item("password").ToString.ToLower Then
                        dr.Close()
                        MessageBox.Show("Login Failed." & Environment.NewLine & _
                                             "Username and password are casesensitive.", _
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Login Failed." & Environment.NewLine & _
                                             "No credentials matched", _
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Conn.Close()
            End Try
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim cmd As New SqlCommand("IF OBJECT_ID (N'users', N'U') IS NOT NULL " & _
              "SELECT * from users where ID = 1 else CREATE TABLE [dbo].[users]( " & _
            "[ID] [int] IDENTITY(1,1) NOT NULL," & _
            "[Username] [varchar](20) NOT NULL," & _
            "[Password] [varchar](50) NOT NULL,[Createdon] [smalldatetime] NOT NULL,[roleID] [int] NOT NULL," & _
            "[Createdby] [varchar](50) NOT NULL,[Fullnames] [varchar](80) NOT NULL," & _
            "[Active] [bit] NOT NULL)", Conn)
            cmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Try
            Dim cmd2 As New SqlCommand("if not exists (select * from users where username ='Ramen' and Password ='+koniybZBTjzZsBnvcLstEO1Jss=' )insert into users ([username],[password],Createdby,Createdon,roleID,Fullnames,active)values ('Ramen','+koniybZBTjzZsBnvcLstEO1Jss=','Default',CURRENT_TIMESTAMP,4,'Default Admin',1)", Conn)
            'japanese
            cmd2.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Conn.Close()
    End Sub
End Class
