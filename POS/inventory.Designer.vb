<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inventory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(inventory))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnadd = New System.Windows.Forms.Button
        Me.txtquantity = New System.Windows.Forms.TextBox
        Me.cmbproducts = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.lblPageNums = New System.Windows.Forms.Label
        Me.lblNoOfPages = New System.Windows.Forms.Label
        Me.cmbNoOfRecords = New System.Windows.Forms.ComboBox
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.lblrecords = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnLoad)
        Me.GroupBox1.Controls.Add(Me.lblPageNums)
        Me.GroupBox1.Controls.Add(Me.lblNoOfPages)
        Me.GroupBox1.Controls.Add(Me.cmbNoOfRecords)
        Me.GroupBox1.Controls.Add(Me.btnLast)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Controls.Add(Me.btnPrevious)
        Me.GroupBox1.Controls.Add(Me.btnFirst)
        Me.GroupBox1.Controls.Add(Me.lblrecords)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(639, 493)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnadd)
        Me.GroupBox2.Controls.Add(Me.txtquantity)
        Me.GroupBox2.Controls.Add(Me.cmbproducts)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(371, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(263, 145)
        Me.GroupBox2.TabIndex = 127
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add Stock"
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(102, 103)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(75, 20)
        Me.btnadd.TabIndex = 157
        Me.btnadd.Text = "Add Stock"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'txtquantity
        '
        Me.txtquantity.Location = New System.Drawing.Point(68, 66)
        Me.txtquantity.Name = "txtquantity"
        Me.txtquantity.Size = New System.Drawing.Size(181, 22)
        Me.txtquantity.TabIndex = 156
        '
        'cmbproducts
        '
        Me.cmbproducts.FormattingEnabled = True
        Me.cmbproducts.Items.AddRange(New Object() {"Black", "Cyan", "Magenta"})
        Me.cmbproducts.Location = New System.Drawing.Point(68, 31)
        Me.cmbproducts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbproducts.Name = "cmbproducts"
        Me.cmbproducts.Size = New System.Drawing.Size(181, 21)
        Me.cmbproducts.TabIndex = 155
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 26)
        Me.Label6.TabIndex = 153
        Me.Label6.Text = "Quantity"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 26)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Item"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(319, 19)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(86, 28)
        Me.btnPrint.TabIndex = 126
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.Location = New System.Drawing.Point(16, 19)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(86, 28)
        Me.btnLoad.TabIndex = 125
        Me.btnLoad.Text = "&Reload "
        Me.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'lblPageNums
        '
        Me.lblPageNums.AutoSize = True
        Me.lblPageNums.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageNums.Location = New System.Drawing.Point(19, 447)
        Me.lblPageNums.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPageNums.Name = "lblPageNums"
        Me.lblPageNums.Size = New System.Drawing.Size(54, 13)
        Me.lblPageNums.TabIndex = 123
        Me.lblPageNums.Text = "Records"
        '
        'lblNoOfPages
        '
        Me.lblNoOfPages.AutoSize = True
        Me.lblNoOfPages.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoOfPages.Location = New System.Drawing.Point(114, 19)
        Me.lblNoOfPages.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNoOfPages.Name = "lblNoOfPages"
        Me.lblNoOfPages.Size = New System.Drawing.Size(146, 13)
        Me.lblNoOfPages.TabIndex = 121
        Me.lblNoOfPages.Text = "No. of records per page:"
        '
        'cmbNoOfRecords
        '
        Me.cmbNoOfRecords.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbNoOfRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNoOfRecords.FormatString = "N2"
        Me.cmbNoOfRecords.FormattingEnabled = True
        Me.cmbNoOfRecords.Items.AddRange(New Object() {"15", "25", "35", "45", "55"})
        Me.cmbNoOfRecords.Location = New System.Drawing.Point(264, 19)
        Me.cmbNoOfRecords.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbNoOfRecords.Name = "cmbNoOfRecords"
        Me.cmbNoOfRecords.Size = New System.Drawing.Size(51, 21)
        Me.cmbNoOfRecords.TabIndex = 122
        '
        'btnLast
        '
        Me.btnLast.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLast.Location = New System.Drawing.Point(319, 52)
        Me.btnLast.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(57, 28)
        Me.btnLast.TabIndex = 120
        Me.btnLast.Text = "L&ast"
        Me.btnLast.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnNext.Location = New System.Drawing.Point(282, 51)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(33, 28)
        Me.btnNext.TabIndex = 119
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnPrevious.Location = New System.Drawing.Point(77, 52)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(37, 28)
        Me.btnPrevious.TabIndex = 118
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'btnFirst
        '
        Me.btnFirst.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnFirst.Location = New System.Drawing.Point(16, 52)
        Me.btnFirst.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(57, 28)
        Me.btnFirst.TabIndex = 117
        Me.btnFirst.Text = "&First"
        Me.btnFirst.UseVisualStyleBackColor = False
        '
        'lblrecords
        '
        Me.lblrecords.AutoSize = True
        Me.lblrecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrecords.Location = New System.Drawing.Point(140, 60)
        Me.lblrecords.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblrecords.Name = "lblrecords"
        Me.lblrecords.Size = New System.Drawing.Size(91, 13)
        Me.lblrecords.TabIndex = 116
        Me.lblrecords.Text = "Total Records:"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(16, 84)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(356, 352)
        Me.DataGridView1.TabIndex = 110
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(668, 503)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "inventory"
        Me.Text = "Inventory"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnPrint As System.Windows.Forms.Button
    Private WithEvents btnLoad As System.Windows.Forms.Button
    Private WithEvents lblPageNums As System.Windows.Forms.Label
    Private WithEvents lblNoOfPages As System.Windows.Forms.Label
    Private WithEvents cmbNoOfRecords As System.Windows.Forms.ComboBox
    Private WithEvents btnLast As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnPrevious As System.Windows.Forms.Button
    Private WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents lblrecords As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents txtquantity As System.Windows.Forms.TextBox
    Friend WithEvents cmbproducts As System.Windows.Forms.ComboBox
End Class
