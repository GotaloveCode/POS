Imports System.Data.SqlClient
Imports System.IO
Public Class Salesrpt
    Dim adapter As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim command As SqlCommand
    Dim builder As SqlCommandBuilder
    Dim ds As DataSet
    Dim tempDataSet As DataSet
    Dim userTable As DataTable
    Private currentIndex As Integer
    Private currentPageStartRecord As Integer
    Private currentPageEndRecord As Integer
    Private totalRecords As Integer
    Private isLastPage As Boolean
    Private sqlQuery As String
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

    Private Sub Salesrpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            command = New SqlCommand("select * from users where ID=" & _userid & "", Conn)
            dr = command.ExecuteReader()
            If dr.HasRows = True Then
                dr.Read()
                If Not dr.Item("roleID") > 2 And dr.Item("roleID") < 5 Then 'admin=3,superadmin=4
                    Me.Hide()
                    MsgBox("Only admin accounts can access this page", MsgBoxStyle.Exclamation)
                    dr.Close()
                    Conn.Close()
                    Me.Close()
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
        cmbNoOfRecords.SelectedIndex = 0
        DateTimePicker1.Value = DateTime.Now.AddDays(-1)
        DateTimePicker2.Value = DateTime.Now.AddDays(1)
        btnLoad_Click(Nothing, Nothing)
    End Sub

    Private Sub CreateTempTable(ByVal startRecord As Integer, ByVal noOfRecords As Integer)
        If startRecord = 0 OrElse startRecord < 0 Then
            btnPrevious.Enabled = False
            startRecord = 0
        End If
        Dim endRecord As Integer = startRecord + noOfRecords
        If endRecord >= totalRecords Then
            btnNext.Enabled = False
            isLastPage = True
            endRecord = totalRecords
        End If
        currentPageStartRecord = startRecord
        currentPageEndRecord = endRecord
        lblPageNums.Text = "Records from " + startRecord.ToString() + " to " + endRecord.ToString() + " of " + totalRecords.ToString()
        currentIndex = endRecord

        Try
            userTable.Rows.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            adapter.Fill(ds, startRecord, noOfRecords, "products")
            userTable = ds.Tables("products")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            Conn.Close()
        End Try

        DataGridView1.DataSource = userTable.DefaultView
        DataGridView1.AllowUserToResizeColumns = True

    End Sub
    Private Sub SetDataObjects()
        Command = New SqlCommand(sqlQuery, Conn)
        adapter = New SqlDataAdapter(command)
        builder = New SqlCommandBuilder(adapter)
        ds = New DataSet("MainDataSet")
        tempDataSet = New DataSet("TempDataSet")
    End Sub

    Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
        btnLoad.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(userTable) Then
                userTable.Clear()
            End If
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Refresh()
            sqlQuery = "Select (p.Product + ' ' + p.Model)as Items,s.quantity,s.sellingprice,r.total,r.date,u.fullnames as ServedBy from sales s inner join products p on s.productid = p.id inner join receipt r on s.receiptid = r.id left join users u on r.userid= u.id WHERE r.date BETWEEN '" + DateTimePicker1.Value.Date + "' AND '" + DateTimePicker2.Value.Date + "' ORDER BY r.id"
            SetDataObjects()
            adapter.Fill(tempDataSet)
            totalRecords = tempDataSet.Tables(0).Rows.Count
            tempDataSet.Clear()
            tempDataSet.Dispose()
            adapter.Fill(ds, 0, 5, "products")
            userTable = ds.Tables("products")
            lblrecords.Text = "Total Records :" & totalRecords.ToString

            If DateTimePicker1.Value <> Nothing And DateTimePicker2.Value <> Nothing Then
                CreateTempTable(0, Integer.Parse(cmbNoOfRecords.Text.Trim()))
            End If
            btnPrevious.Enabled = True
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
            cmbNoOfRecords.Enabled = True
        Catch ex As Exception
            MsgBox("Error:" + ex.ToString())
        Finally
            Conn.Close()
            btnLoad.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub 'reload data

    Private Sub btnNoOfPages_Click(ByVal sender As Object, ByVal e As EventArgs)
        CreateTempTable(0, Integer.Parse(cmbNoOfRecords.Text.Trim()))
        If Integer.Parse(cmbNoOfRecords.Text.Trim()) >= totalRecords Then
            btnFirst.Enabled = False
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnLast.Enabled = False
        Else
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
        End If
    End Sub '
    Private Sub btnFirst_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFirst.Click
        CreateTempTable(0, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = False
        btnNext.Enabled = True
        btnLast.Enabled = True
        isLastPage = False
    End Sub 'go to 1st page

    Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrevious.Click
        If isLastPage Then
            Dim noc As Integer = FindLastPageRecords()
            CreateTempTable((totalRecords - noc - Integer.Parse(cmbNoOfRecords.Text)), Integer.Parse(cmbNoOfRecords.Text))
        Else
            CreateTempTable((currentIndex - 2 * (Integer.Parse(cmbNoOfRecords.Text))), Integer.Parse(cmbNoOfRecords.Text))
        End If
        btnNext.Enabled = True
        btnLast.Enabled = True
        isLastPage = False
    End Sub 'go to previous page

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click
        CreateTempTable(currentIndex, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = True
    End Sub 'go to next page

    Private Sub btnLast_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLast.Click
        Dim totPages As Integer = totalRecords / Integer.Parse(cmbNoOfRecords.Text)
        Dim remainingRecs As Integer = FindLastPageRecords()

        CreateTempTable(totalRecords - remainingRecs, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = True
        btnNext.Enabled = False
        isLastPage = True
    End Sub 'go to last page
    Private Function FindLastPageRecords() As Integer
        Return (totalRecords Mod Integer.Parse(cmbNoOfRecords.Text))
    End Function
#Region "Print"

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()

        '  PrintDocument1.Print()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(bm, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub
#End Region 'Printsection

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
End Class