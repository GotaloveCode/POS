Imports System.Data.SqlClient
Imports System.IO
Public Class EditProducts
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


    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        command = New SqlCommand("select * from category", Conn)
        dr = command.ExecuteReader
        Dim dt As New DataTable
        dt.Load(dr)
        cmbcategory.DisplayMember = "category"
        cmbcategory.ValueMember = "id"
        cmbcategory.DataSource = dt
        ' FormatContentGridView()
        dr.Close()
        Conn.Close()
        '   lbluser.Text = user
        cmbcategory.SelectedIndex = 0
        cmbNoOfRecords.SelectedIndex = 0
        btnLoad_Click(Nothing, Nothing)
        FormatContentGridView() 'If I wana format datagrid

    End Sub

    Private Sub FormatContentGridView()
        With DataGridView1
            ''Hide columns
            '.Columns("type_priority").Visible = False
            .Columns("id").Visible = False

            ''Header text
            '.Columns("feetype_id").HeaderText = "#ID"
            '.Columns("type").HeaderText = "Fee Name"
            '.Columns("payable_amount").HeaderText = "Amount"


            ''Widths
            '.Columns("type").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.Columns("type").MinimumWidth = 150

            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible And c.AutoSizeMode <> DataGridViewAutoSizeColumnMode.Fill Then
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next

            ''Display Index
            '.Columns("feetype_id").DisplayIndex = 0
            '.Columns("type").DisplayIndex = 1
            '.Columns("payable_amount").DisplayIndex = 2
        End With
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

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        Try
            btnLoad_Click(Nothing, Nothing)
            'If Not cmbcategory.SelectedIndex = -1 Then
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CreateTempTable(startRecord As Integer, noOfRecords As Integer)
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            DataGridView1.ReadOnly = False
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub 'add

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Conn()
            adapter.Update(userTable)
            DataGridView1.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            btnAdd.Enabled = True
            btnLoad.Enabled = True
            Conn.Close()
        End Try
    End Sub 'update 

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Do you really want to delete selected record(s)?", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, _
        False) = DialogResult.Yes Then
            Try
                Conn()
                Dim cnt As Integer = DataGridView1.SelectedRows.Count
                For i As Integer = 0 To cnt - 1
                    If Me.DataGridView1.SelectedRows.Count > 0 AndAlso Me.DataGridView1.SelectedRows(0).Index <> Me.DataGridView1.Rows.Count - 1 Then
                        Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(0).Index)
                    End If
                Next
                adapter.Update(userTable)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                Conn.Close()
                btnLoad.Enabled = True
            End Try
        End If
    End Sub 'delete

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        btnLoad.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(userTable) Then
                userTable.Clear()
            End If
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Refresh()
            sqlQuery = "SELECT * FROM products where CategoryID=" & Integer.Parse(cmbcategory.SelectedValue)
            SetDataObjects()
            adapter.Fill(tempDataSet)
            totalRecords = tempDataSet.Tables(0).Rows.Count
            tempDataSet.Clear()
            tempDataSet.Dispose()
            adapter.Fill(ds, 0, 5, "products")
            userTable = ds.Tables("products")
            lblrecords.Text = "Total Records :" & totalRecords.ToString

            If cmbNoOfRecords.Text.Trim() <> "" Then
                CreateTempTable(0, Integer.Parse(cmbNoOfRecords.Text.Trim()))
            End If
            btnPrevious.Enabled = True
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
            btnAdd.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            cmbNoOfRecords.Enabled = True
        Catch ex As Exception
            MsgBox("Error:" + ex.ToString())
        Finally
            Conn.Close()
            btnLoad.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub 'reload data

    Private Sub btnNoOfPages_Click(sender As Object, e As EventArgs) Handles btnNoOfPages.Click
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
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        CreateTempTable(0, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = False
        btnNext.Enabled = True
        btnLast.Enabled = True
        isLastPage = False
    End Sub 'go to 1st page

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
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

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        CreateTempTable(currentIndex, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = True
    End Sub 'go to next page

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
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
End Class