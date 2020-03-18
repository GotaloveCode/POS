Imports System.Data.SqlClient
Public Class Parent
    Private _userid As Integer
    Private _user As String
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

    Private Sub samplefrm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        lbluser.Text = _user
    End Sub

    Private Sub MnuCascade_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuCascade.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub MnuTileHorizontal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuTileHorizontal.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub MnuTileVertical_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuTileVertical.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub MnuArrangeIcons_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuArrangeIcons.Click
        LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub MnuUserAccounts_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuUserAccounts.Click
        Dim f As New CreateUser
        f.userid = _userid
        f.user = _user
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


    Private Sub MnuAddStudents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New Sales
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub AddProductsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AddProductsToolStripMenuItem.Click
        Dim f As New Products
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub EditViewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EditViewToolStripMenuItem.Click
        Dim f As New EditProducts
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MAKESALEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MAKESALEToolStripMenuItem.Click
        Dim f As New Sales
        f.userid = _userid
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub VIEWSALESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWSALESToolStripMenuItem.Click
        Try
            Dim Command As New SqlCommand("select * from users where ID=" & _userid & "", Conn)
            Dim dr As SqlDataReader = Command.ExecuteReader()
            If dr.HasRows = True Then
                dr.Read()
                If Not dr.Item("roleID") > 2 And dr.Item("roleID") < 5 Then 'admin=3,superadmin=4
                    MsgBox("Only admin accounts can access this page", MsgBoxStyle.Exclamation)
                Else
                    Dim f As New Salesrpt
                    f.userid = _userid
                    f.MdiParent = Me
                    f.Show()
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
        
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryToolStripMenuItem.Click
        Dim f As New inventory
        f.userid = _userid
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim f As New LoginForm1
        f.Show()
        Me.Close()
    End Sub
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

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
    End Sub
End Class