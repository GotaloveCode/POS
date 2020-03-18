<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateUser))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbuser = New System.Windows.Forms.ComboBox
        Me.txtNewPas = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnclearchanges = New System.Windows.Forms.Button
        Me.cmbRole2 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtOldPas = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtConfirmNewPas = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtuser2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnsave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtfullname = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnclear = New System.Windows.Forms.Button
        Me.CmbRole = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtpas = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtpas2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtuser = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCreate = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbuser)
        Me.GroupBox2.Controls.Add(Me.txtNewPas)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnclearchanges)
        Me.GroupBox2.Controls.Add(Me.cmbRole2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtOldPas)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtConfirmNewPas)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtuser2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.btnsave)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(378, 297)
        Me.GroupBox2.TabIndex = 115
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MANAGE USER ACCOUNTS"
        '
        'cmbuser
        '
        Me.cmbuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbuser.FormattingEnabled = True
        Me.cmbuser.Location = New System.Drawing.Point(175, 33)
        Me.cmbuser.Name = "cmbuser"
        Me.cmbuser.Size = New System.Drawing.Size(164, 23)
        Me.cmbuser.TabIndex = 20
        '
        'txtNewPas
        '
        Me.txtNewPas.Location = New System.Drawing.Point(175, 111)
        Me.txtNewPas.MaxLength = 50
        Me.txtNewPas.Name = "txtNewPas"
        Me.txtNewPas.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPas.Size = New System.Drawing.Size(164, 23)
        Me.txtNewPas.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "New Password"
        '
        'btnclearchanges
        '
        Me.btnclearchanges.Location = New System.Drawing.Point(204, 241)
        Me.btnclearchanges.Name = "btnclearchanges"
        Me.btnclearchanges.Size = New System.Drawing.Size(87, 27)
        Me.btnclearchanges.TabIndex = 17
        Me.btnclearchanges.Text = "&Clear"
        Me.btnclearchanges.UseVisualStyleBackColor = True
        '
        'cmbRole2
        '
        Me.cmbRole2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRole2.Enabled = False
        Me.cmbRole2.FormattingEnabled = True
        Me.cmbRole2.Location = New System.Drawing.Point(175, 182)
        Me.cmbRole2.Name = "cmbRole2"
        Me.cmbRole2.Size = New System.Drawing.Size(164, 23)
        Me.cmbRole2.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Role"
        '
        'txtOldPas
        '
        Me.txtOldPas.Location = New System.Drawing.Point(175, 74)
        Me.txtOldPas.MaxLength = 50
        Me.txtOldPas.Name = "txtOldPas"
        Me.txtOldPas.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPas.Size = New System.Drawing.Size(164, 23)
        Me.txtOldPas.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Old Password"
        '
        'txtConfirmNewPas
        '
        Me.txtConfirmNewPas.Location = New System.Drawing.Point(175, 149)
        Me.txtConfirmNewPas.MaxLength = 50
        Me.txtConfirmNewPas.Name = "txtConfirmNewPas"
        Me.txtConfirmNewPas.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmNewPas.Size = New System.Drawing.Size(164, 23)
        Me.txtConfirmNewPas.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Confirm Password"
        '
        'txtuser2
        '
        Me.txtuser2.Location = New System.Drawing.Point(175, 36)
        Me.txtuser2.Name = "txtuser2"
        Me.txtuser2.ReadOnly = True
        Me.txtuser2.Size = New System.Drawing.Size(164, 23)
        Me.txtuser2.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Username"
        '
        'btnsave
        '
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.Location = New System.Drawing.Point(62, 241)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(100, 27)
        Me.btnsave.TabIndex = 3
        Me.btnsave.Text = "&Save"
        Me.btnsave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtfullname)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.btnclear)
        Me.GroupBox1.Controls.Add(Me.CmbRole)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtpas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtpas2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtuser)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnCreate)
        Me.GroupBox1.Location = New System.Drawing.Point(418, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 314)
        Me.GroupBox1.TabIndex = 114
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CREATE USER ACCOUNTS"
        '
        'txtfullname
        '
        Me.txtfullname.Location = New System.Drawing.Point(161, 157)
        Me.txtfullname.MaxLength = 80
        Me.txtfullname.Name = "txtfullname"
        Me.txtfullname.Size = New System.Drawing.Size(193, 23)
        Me.txtfullname.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 15)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Full Names"
        '
        'btnclear
        '
        Me.btnclear.Location = New System.Drawing.Point(267, 241)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(87, 27)
        Me.btnclear.TabIndex = 18
        Me.btnclear.Text = "&Clear"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'CmbRole
        '
        Me.CmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRole.FormattingEnabled = True
        Me.CmbRole.Location = New System.Drawing.Point(161, 198)
        Me.CmbRole.Name = "CmbRole"
        Me.CmbRole.Size = New System.Drawing.Size(193, 23)
        Me.CmbRole.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Role"
        '
        'txtpas
        '
        Me.txtpas.Location = New System.Drawing.Point(161, 83)
        Me.txtpas.MaxLength = 50
        Me.txtpas.Name = "txtpas"
        Me.txtpas.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpas.Size = New System.Drawing.Size(193, 23)
        Me.txtpas.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Password"
        '
        'txtpas2
        '
        Me.txtpas2.Location = New System.Drawing.Point(161, 126)
        Me.txtpas2.MaxLength = 50
        Me.txtpas2.Name = "txtpas2"
        Me.txtpas2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpas2.Size = New System.Drawing.Size(193, 23)
        Me.txtpas2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Confirm Password"
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(161, 39)
        Me.txtuser.MaxLength = 20
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(193, 23)
        Me.txtuser.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username"
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(48, 241)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(87, 27)
        Me.btnCreate.TabIndex = 0
        Me.btnCreate.Text = "&Create User"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'CreateUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(829, 350)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CreateUser"
        Me.Text = "User Accounts"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbuser As System.Windows.Forms.ComboBox
    Friend WithEvents txtNewPas As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnclearchanges As System.Windows.Forms.Button
    Friend WithEvents cmbRole2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOldPas As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmNewPas As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtuser2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtfullname As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents CmbRole As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtpas2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtuser As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
End Class
