Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class Sales
    Dim ReciptImage As Bitmap
    Dim dr As SqlDataReader
    Dim command As SqlCommand
    Dim dt As DataTable
    Dim dt2 As New DataTable
    Dim dt3 As New DataTable
    Private _rowsafected As Integer
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

    End Function 'sqlcon
    Private Sub sales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            command = New SqlCommand("select top 1* from printer", Conn)
            dr = command.ExecuteReader
            dt3 = New DataTable
            dt3.Load(dr)
            txtwidth.Text = dt3.Rows(0).Item(1).ToString
            txtheight.Text = dt3.Rows(0).Item(2).ToString
            txtfont.Text = dt3.Rows(0).Item(3).ToString
            dr.Close()
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            command = New SqlCommand("select * from products", Conn)
            dr = command.ExecuteReader
            dt = New DataTable
            dt.Load(dr)
            cmbproducts.DisplayMember = "product"
            cmbproducts.ValueMember = "id"
            cmbproducts.DataSource = dt
            cmbproducts.SelectedIndex = 0
            txtmodel.DataBindings.Add("Text", dt, "Model")
            txtprice.DataBindings.Add("Text", dt, "sp")
            dr.Close()
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        dt2.Columns.Add("item", GetType(String))
        dt2.Columns.Add("Model", GetType(String))
        dt2.Columns.Add("Price", GetType(Double))
        dt2.Columns.Add("Quantity", GetType(Integer))
        dt2.Columns.Add("Total", GetType(Double))
        dt2.Columns.Add("productid", GetType(Int32))
        txtquantity.Text = 1
        txtPrinterName.Text = My.Settings.printer
        PictureBox1.Image = DrawRecipt(DataGridView3.Rows, 737, DateString, 123, Integer.Parse(txtwidth.Text), Integer.Parse(txtheight.Text), Integer.Parse(txtfont.Text))
    End Sub 'loaad

    Private Sub txtphone_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim str As String = "1234567890 " & ChrW(8)
        If Not str.Contains(Convert.ToChar(e.KeyChar)) Or (Asc(e.KeyChar) = 22) Then
            e.Handled = True
        End If
    End Sub 'phoneno key handle

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        GetTable()
        DataGridView2.DataSource = dt2
        FormatContentGridView()
        txttotal.Text = dt2.Compute("SUM(total)", String.Empty)
    End Sub 'add items to grid
    Private Sub FormatContentGridView()
        With DataGridView2
            .Columns("productid").Visible = False
            ' .Columns("id").c = 0
            For Each c As DataGridViewColumn In DataGridView2.Columns
                If c.Visible And c.AutoSizeMode <> DataGridViewAutoSizeColumnMode.Fill Then
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next


        End With
    End Sub 'format datagrid

    Private Function GetTable() As DataTable
        Dim total As Double
        total = Integer.Parse(txtprice.Text.Trim) * Integer.Parse(txtquantity.Text.Trim)
        dt2.Rows.Add(cmbproducts.Text.Trim, txtmodel.Text.Trim, Integer.Parse(txtprice.Text.Trim), Integer.Parse(txtquantity.Text.Trim), total, cmbproducts.SelectedValue)
        Return dt2
    End Function 'datatable filling grid for items bought

    Private Sub btnremove_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If DataGridView2.Rows.Count = 0 AndAlso DataGridView2.SelectedCells.Count = 0 AndAlso DataGridView2.SelectedRows.Count = 0 Then
                MsgBox("Please select an item to remove", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim var As Double = DataGridView2.SelectedRows(0).Cells(4).Value
            txttotal.Text = txttotal.Text - var
            DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
            cmbproducts.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub 'remove items from grid

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If DataGridView2.Rows.Count = 0 Then
                MsgBox("No items to remove", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            dt2.Clear()
            cmbproducts.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub 'clear all

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Try
            If DataGridView2.Rows.Count <= 0 Then
                MsgBox("Please add some items to sell", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            command = New SqlCommand("Insert into receipt (total,date,userid) Values(@total,@date,@userid)", Conn)
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", Date.Now)
            command.Parameters.AddWithValue("@total", txttotal.Text.Trim)
            command.Parameters.AddWithValue("@userid", _userid)
            command.ExecuteNonQuery()
            Conn.Close()
            command.Dispose()
            command = New SqlCommand
            Dim str As String = "Select max(id) as MAXID from receipt"
            With command
                .CommandText = str
                .Connection = Conn()
            End With
            Dim ReciptID As Long = command.ExecuteScalar
            command.Dispose()
            Dim i As Integer
            For i = 0 To DataGridView2.Rows.Count - 1
                Dim SellPrice As String = DataGridView2.Rows(i).Cells(2).Value
                Dim ItemCount As Integer = DataGridView2.Rows(i).Cells(3).Value
                Dim productid As Integer = DataGridView2.Rows(i).Cells(5).Value
                command = New SqlCommand("insert into sales (sellingprice,quantity,productid,receiptid) values (@sellingprice,@quantity,@productid,@receiptid) ", Conn)
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@sellingprice", SellPrice)
                command.Parameters.AddWithValue("@quantity", ItemCount)
                command.Parameters.AddWithValue("@productid", productid)
                command.Parameters.AddWithValue("@receiptid", ReciptID)
                _rowsafected = command.ExecuteNonQuery()
                command.Dispose()
            Next
            If _rowsafected < 0 Then
                MsgBox("Sale not recorded", MsgBoxStyle.Exclamation)
            End If
            Conn.Close()
            Conn.Dispose()
            If Not IsNothing(txtPrinterName.Text) Then
                ReciptImage = DrawRecipt(DataGridView2.Rows, ReciptID, Format(Now.Date, "dd-mm-yyyy"), txttotal.Text, txtwidth.Text, txtheight.Text, txtfont.Text) 'width height font
                If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    PrintDoc.PrinterSettings = PrintDialog1.PrinterSettings
                    PrintDoc.Print()
                    dt2.Clear()
                    'DataGridView2.Rows.Clear()
                    'TextBox4.Clear()
                End If
            ElseIf PictureBox1.Image Is Nothing Then
                MsgBox("Can't Print receipt please check the settings", MsgBoxStyle.Critical)
            Else
                MsgBox("You did not setup the printer", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub 'save to db sale & print
    Public Function DrawRecipt(ByVal Rows As DataGridViewRowCollection, ByVal ReciptNo As String, ByVal ReciptDate As String, ByVal ReciptTotal As Decimal, ByVal UnitWidth As Integer, ByVal UnitHeight As Integer, ByVal Fontize As Integer) As Bitmap

        Dim ReciptWidth As Integer = 13 * UnitWidth
        Dim ReciptDetailsHeight As Integer = Rows.Count * UnitHeight
        Dim ReciptHeight As Integer = 6 * UnitWidth + ReciptDetailsHeight
        Dim BMP As New Bitmap(ReciptWidth + 1, ReciptHeight)
        Dim GR As Graphics = Graphics.FromImage(BMP)
        ' GR.FillRectangle(Brushes.White, 0, 0, ReciptWidth, ReciptHeight)
        GR.Clear(Color.White)
        Dim LNHeaderYStart = 3 * UnitHeight
        Dim LNDetailsStart = LNHeaderYStart + UnitHeight
        GR.DrawRectangle(Pens.Black, UnitWidth * 0, LNHeaderYStart, UnitWidth, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 1, LNHeaderYStart, UnitWidth * 5, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 6, LNHeaderYStart, UnitWidth * 2, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 8, LNHeaderYStart, UnitWidth * 2, UnitHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 10, LNHeaderYStart, UnitWidth * 3, UnitHeight)

        GR.DrawRectangle(Pens.Black, UnitWidth * 0, LNDetailsStart, UnitWidth * 1, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 1, LNDetailsStart, UnitWidth * 5, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 6, LNDetailsStart, UnitWidth * 2, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 8, LNDetailsStart, UnitWidth * 2, ReciptDetailsHeight)
        GR.DrawRectangle(Pens.Black, UnitWidth * 10, LNDetailsStart, UnitWidth * 3, ReciptDetailsHeight)

        Dim FNT As New Font("Times", Fontize, FontStyle.Bold)

        GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart)
        GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart)
        GR.DrawString("", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart)
        GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart)
        GR.DrawString("Qty", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart)

        Dim I As Integer
        For I = 0 To Rows.Count - 1
            Dim YLOC = UnitHeight * I + LNDetailsStart
            GR.DrawString(I, FNT, Brushes.Black, UnitWidth * 0, YLOC)

            GR.DrawString(Rows(I).Cells(1).Value, FNT, Brushes.Black, UnitWidth * 1, YLOC)
            GR.DrawString(Rows(I).Cells(0).Value, FNT, Brushes.Black, UnitWidth * 6, YLOC)
            GR.DrawString(Rows(I).Cells(2).Value, FNT, Brushes.Black, UnitWidth * 8, YLOC)
            GR.DrawString(Rows(I).Cells(3).Value, FNT, Brushes.Black, UnitWidth * 10, YLOC)

        Next
        GR.DrawString("Total:" & ReciptTotal, FNT, Brushes.Black, 0, LNDetailsStart + ReciptDetailsHeight)

        GR.DrawString("Receipt No:" & ReciptNo, FNT, Brushes.Black, 0, 0)
        GR.DrawString("Receipt Date:" & ReciptDate, FNT, Brushes.Black, 0, UnitHeight)

        Return BMP
    End Function


    Private Sub PrintDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        e.Graphics.DrawImage(ReciptImage, 0, 0, ReciptImage.Width, ReciptImage.Height)
        e.HasMorePages = False
    End Sub

    Private Sub txtwidth_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtwidth.TextChanged
        DrawPreview()
        Try
            If PictureBox1.Image IsNot Nothing Then
                Conn.Open()
                command.CommandText = "Update Printer Set UnitWidth='" & txtwidth.Text & "',UnitHeight='" & txtheight.Text & "' ,FontSize='" & txtfont.Text & "' Where Sr=1 "
                command.ExecuteNonQuery()
                Conn.Close()
            End If
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Private Sub txtheight_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtheight.TextChanged
        DrawPreview()
        Try
            If PictureBox1.Image IsNot Nothing Then
                Conn.Open()
                command.CommandText = "Update Printer Set UnitWidth='" & txtwidth.Text & "',UnitHeight='" & txtheight.Text & "' ,FontSize='" & txtfont.Text & "'Where Sr=1 "
                command.ExecuteNonQuery()
                Conn.Close()
            End If
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Private Sub txtfont_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtfont.TextChanged
        DrawPreview()
        Try
            If PictureBox1.Image IsNot Nothing Then
                Conn.Open()
                command.CommandText = "Update Printer Set UnitWidth='" & txtwidth.Text & "',UnitHeight='" & txtheight.Text & "' ,FontSize='" & txtfont.Text & "' Where Sr=1"
                command.ExecuteNonQuery()
                Conn.Close()
            End If
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Public Sub DrawPreview()
        If Not IsNumeric(txtwidth.Text) Then
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        Dim L As Double = Long.Parse(txtwidth.Text)
        If Math.Truncate(L) <> L Then
            MsgBox("You Should Enter an Integer Value", MsgBoxStyle.Critical)
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        If L <= 0 Then
            MsgBox("You Should Enter an Positive Value", MsgBoxStyle.Critical)
            PictureBox1.Image = Nothing
            Exit Sub
        End If

        If Not IsNumeric(txtheight.Text) Then
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        L = Long.Parse(txtheight.Text)
        If Math.Truncate(L) <> L Then
            MsgBox("You Should Enter an Integer Value", MsgBoxStyle.Critical)
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        If L <= 0 Then
            MsgBox("You Should Enter an Positive Value", MsgBoxStyle.Critical)
            PictureBox1.Image = Nothing
            Exit Sub
        End If

        If Not IsNumeric(txtfont.Text) Then
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        L = Long.Parse(txtfont.Text)
        If Math.Truncate(L) <> L Then
            MsgBox("You Should Enter an Integer Value", MsgBoxStyle.Critical)
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        If L <= 0 Then
            MsgBox("You Should Enter an Positive Value", MsgBoxStyle.Critical)
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        Try
            PictureBox1.Image = DrawRecipt(DataGridView3.Rows, 737, DateString, 123, txtwidth.Text, txtheight.Text, txtfont.Text)
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Private Sub btnSelectPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPrinter.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtPrinterName.Text = PrintDialog1.PrinterSettings.PrinterName
            My.Settings.printer = txtPrinterName.Text
            My.Settings.Save()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnRestoreDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestoreDefaults.Click
        Try
            command = New SqlCommand("Update Printer Set UnitWidth=16,UnitHeight=14 ,FontSize=8 Where id=1", Conn)
            command.ExecuteNonQuery()
            Conn.Close()
            command = New SqlCommand("select top 1* from printer", Conn)
            dr = command.ExecuteReader
            dt3 = New DataTable
            dt3.Load(dr)
            txtwidth.Text = dt3.Rows(0).Item(1).ToString
            txtheight.Text = dt3.Rows(0).Item(2).ToString
            txtfont.Text = dt3.Rows(0).Item(3).ToString
            dr.Close()
            Conn.Close()
            PictureBox1.Image = DrawRecipt(DataGridView3.Rows, 737, DateString, 123, Integer.Parse(txtwidth.Text), Integer.Parse(txtheight.Text), Integer.Parse(txtfont.Text))
            MsgBox("Restored", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class