Imports System.Data.SqlClient
Imports System.IO


Public Class Products
    Private _affectedrows As Integer
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim modified As Integer
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            If txtproduct.Text.Trim = "" Then
                MessageBox.Show("Please enter Product", "Missing Product", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtproduct.Focus()
            ElseIf txtmodel.Text.Trim = "" Then
                MessageBox.Show("Please enter Model", "Missing Model", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtmodel.Focus()
            ElseIf txtbp.Text.Trim = "" Then
                MessageBox.Show("Please enter Product buying Price", "Missing buying Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtbp.Focus()
            ElseIf txtsp.Text.Trim = "" Then
                MessageBox.Show("Please enter Product selling Price", "Missing selling Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtsp.Focus()
            Else
                cmd = New SqlCommand("select count(id) from products where product like @prod + '%' and Model like @model + '%'", Conn)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@prod", SqlDbType.VarChar).Value = txtproduct.Text.Trim
                cmd.Parameters.Add("@model", SqlDbType.VarChar).Value = txtmodel.Text.Trim
                _affectedrows = cmd.ExecuteScalar
                If _affectedrows > 0 Then
                    dr.Close()
                    Conn.Close()
                    If MessageBox.Show("Product " & txtproduct.Text & "  with model " & txtmodel.Text & " already exists" & Environment.NewLine & "Do you still want to add this product", "Possible product match", _
     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, False) = Windows.Forms.DialogResult.Yes Then
                        cmd = New SqlCommand("insert into products(Product,Model,CategoryID,Description,BP,SP) values (@prod1,@Model2,@cat,@desc,@bp,@sp)", Conn)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.Add("@prod", SqlDbType.VarChar).Value = txtproduct.Text.Trim
                        cmd.Parameters.Add("@Model2", SqlDbType.VarChar).Value = txtmodel.Text.Trim
                        cmd.Parameters.Add("@cat", SqlDbType.Int).Value = cmbcategory.SelectedValue
                        cmd.Parameters.Add("@desc", SqlDbType.VarChar).Value = cmbDescription.Text.Trim
                        cmd.Parameters.Add("@bp", SqlDbType.Float).Value = txtbp.Text.Trim
                        cmd.Parameters.Add("@sp", SqlDbType.Float).Value = txtsp.Text.Trim
                        _affectedrows = cmd.ExecuteNonQuery()
                        If _affectedrows > 0 Then
                            MessageBox.Show("Products added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Products records failed to update", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        dr.Close()
                        Conn.Close()
                       
                    Else
                        cleartext()
                        Exit Sub
                    End If
                Else
                    dr.Close()
                    Conn.Close()
                    cmd = New SqlCommand("insert into  products(product,Model,CategoryID,Description,BP,SP) values (@prod2,@Model3,@cat2,@desc2,@bp2,@sp2)", Conn)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.Add("@prod2", SqlDbType.VarChar).Value = txtproduct.Text.Trim
                    cmd.Parameters.Add("@Model3", SqlDbType.VarChar).Value = txtmodel.Text.Trim
                    cmd.Parameters.Add("@cat2", SqlDbType.Int).Value = cmbcategory.SelectedValue
                    cmd.Parameters.Add("@desc2", SqlDbType.VarChar).Value = cmbDescription.Text.Trim
                    cmd.Parameters.Add("@bp2", SqlDbType.Float).Value = txtbp.Text.Trim
                    cmd.Parameters.Add("@sp2", SqlDbType.Float).Value = txtsp.Text.Trim
                    _affectedrows = cmd.ExecuteNonQuery()
                    If _affectedrows > 0 Then
                        MessageBox.Show("Products records added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        studentParents_Load(Nothing, Nothing)
                    Else
                        MessageBox.Show("Products records failed to update", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    dr.Close()
                    Conn.Close()
                End If
                cleartext()
            End If
        Catch ex As SqlException
            MsgBox("An SQL error occured:" & ex.ToString, MsgBoxStyle.Exclamation, Title:="SQL Error")
        Catch ex As Exception
            MsgBox("An error occured:" & ex.ToString, MsgBoxStyle.Exclamation, Title:="Error")
        End Try

    End Sub
    Private Sub cleartext()
        txtproduct.Clear()
        txtmodel.Clear()
    End Sub

    Private Sub studentParents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd = New SqlCommand("select ROW_NUMBER() OVER(order by p.id) as ID,p.product,p.model,p.description,c.category,p.bp,p.sp from products p inner join category c on p.categoryID =c.id order by p.categoryID", Conn)
        dr = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(dr)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = dt
        FormatContentGridView()
        dr.Close()
        Conn.Close()
        cmd = New SqlCommand("select * from category", Conn)
        dr = cmd.ExecuteReader
        Dim dt2 As New DataTable
        dt2.Load(dr)
        cmbcategory.DataSource = Nothing
        cmbcategory.DisplayMember = "category"
        cmbcategory.ValueMember = "id"
        cmbcategory.DataSource = dt2
        dr.Close()
        Conn.Close()
        cmbDescription.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbDescription.AutoCompleteSource = AutoCompleteSource.ListItems

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

    Private Sub BtnAddCategory_Click(sender As Object, e As EventArgs) Handles BtnAddCategory.Click
        If txtcategory.Text.Trim = "" Or IsNumeric(txtcategory.Text) Then
            MessageBox.Show("Please enter Category", "Missing Category", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcategory.Focus()
        Else
            cmd = New SqlCommand("insert into category(category) values (@cat)", Conn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@cat", SqlDbType.VarChar).Value = txtcategory.Text.Trim
            _affectedrows = cmd.ExecuteNonQuery()
            If _affectedrows > 0 Then
                MessageBox.Show("Category record added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                studentParents_Load(Nothing, Nothing)
            Else
                MessageBox.Show("Category records failed to update", "Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            dr.Close()
            Conn.Close()

        End If
        txtcategory.Clear()
    End Sub
    Private Sub FormatContentGridView()
        With DataGridView1
            'Hide columns
            '.Columns("type_priority").Visible = False
            '.Columns("period_id").Visible = False

            'Header text

            .Columns("bp").HeaderText = "B.Price"
            .Columns("sp").HeaderText = "S.Price"


            ''Widths
            '.Columns("Product").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.Columns("Product").MinimumWidth = 100

            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible And c.AutoSizeMode <> DataGridViewAutoSizeColumnMode.Fill Then
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next

            'Display Index
            '.Columns("id").DisplayIndex = 0
            '.Columns("Product").DisplayIndex = 1
            '.Columns("Model").DisplayIndex = 2
        End With
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        'ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
   
        '  PrintDocument1.Print()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(bm, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub
   
End Class