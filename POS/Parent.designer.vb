<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Parent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Parent))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFeesStructure = New System.Windows.Forms.ToolStripMenuItem
        Me.AddProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSales = New System.Windows.Forms.ToolStripMenuItem
        Me.MAKESALEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VIEWSALESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserAccounts = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuWindows = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuCascade = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTileHorizontal = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTileVertical = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuArrangeIcons = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbluser = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.timestrip = New System.Windows.Forms.ToolStripStatusLabel
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.MnuFeesStructure, Me.MnuSales, Me.MnuUserAccounts, Me.MnuWindows})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1280, 24)
        Me.MenuStrip1.TabIndex = 106
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.FileToolStripMenuItem.Text = "FILE"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Image = CType(resources.GetObject("LogoutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'MnuFeesStructure
        '
        Me.MnuFeesStructure.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddProductsToolStripMenuItem, Me.EditViewToolStripMenuItem})
        Me.MnuFeesStructure.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuFeesStructure.Name = "MnuFeesStructure"
        Me.MnuFeesStructure.Size = New System.Drawing.Size(79, 20)
        Me.MnuFeesStructure.Text = "PRODUCTS"
        '
        'AddProductsToolStripMenuItem
        '
        Me.AddProductsToolStripMenuItem.Image = CType(resources.GetObject("AddProductsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddProductsToolStripMenuItem.Name = "AddProductsToolStripMenuItem"
        Me.AddProductsToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.AddProductsToolStripMenuItem.Text = "&Add Products"
        '
        'EditViewToolStripMenuItem
        '
        Me.EditViewToolStripMenuItem.Image = CType(resources.GetObject("EditViewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditViewToolStripMenuItem.Name = "EditViewToolStripMenuItem"
        Me.EditViewToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.EditViewToolStripMenuItem.Text = "&Edit/View Products"
        '
        'MnuSales
        '
        Me.MnuSales.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MAKESALEToolStripMenuItem, Me.VIEWSALESToolStripMenuItem, Me.InventoryToolStripMenuItem})
        Me.MnuSales.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuSales.Name = "MnuSales"
        Me.MnuSales.Size = New System.Drawing.Size(51, 20)
        Me.MnuSales.Text = "SALES"
        '
        'MAKESALEToolStripMenuItem
        '
        Me.MAKESALEToolStripMenuItem.Image = CType(resources.GetObject("MAKESALEToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MAKESALEToolStripMenuItem.Name = "MAKESALEToolStripMenuItem"
        Me.MAKESALEToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MAKESALEToolStripMenuItem.Text = "Make Sale"
        '
        'VIEWSALESToolStripMenuItem
        '
        Me.VIEWSALESToolStripMenuItem.Name = "VIEWSALESToolStripMenuItem"
        Me.VIEWSALESToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.VIEWSALESToolStripMenuItem.Text = "View Sales"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'MnuUserAccounts
        '
        Me.MnuUserAccounts.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuUserAccounts.Name = "MnuUserAccounts"
        Me.MnuUserAccounts.Size = New System.Drawing.Size(112, 20)
        Me.MnuUserAccounts.Text = "USER ACCOUNTS"
        '
        'MnuWindows
        '
        Me.MnuWindows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCascade, Me.MnuTileHorizontal, Me.MnuTileVertical, Me.MnuArrangeIcons, Me.CloseAllToolStripMenuItem})
        Me.MnuWindows.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuWindows.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.MnuWindows.Name = "MnuWindows"
        Me.MnuWindows.Size = New System.Drawing.Size(70, 20)
        Me.MnuWindows.Text = "WINDOW"
        '
        'MnuCascade
        '
        Me.MnuCascade.Image = CType(resources.GetObject("MnuCascade.Image"), System.Drawing.Image)
        Me.MnuCascade.Name = "MnuCascade"
        Me.MnuCascade.Size = New System.Drawing.Size(152, 22)
        Me.MnuCascade.Text = "Cascade"
        '
        'MnuTileHorizontal
        '
        Me.MnuTileHorizontal.Image = CType(resources.GetObject("MnuTileHorizontal.Image"), System.Drawing.Image)
        Me.MnuTileHorizontal.Name = "MnuTileHorizontal"
        Me.MnuTileHorizontal.Size = New System.Drawing.Size(152, 22)
        Me.MnuTileHorizontal.Text = "Tile Horizontal"
        '
        'MnuTileVertical
        '
        Me.MnuTileVertical.Image = CType(resources.GetObject("MnuTileVertical.Image"), System.Drawing.Image)
        Me.MnuTileVertical.Name = "MnuTileVertical"
        Me.MnuTileVertical.Size = New System.Drawing.Size(152, 22)
        Me.MnuTileVertical.Text = "Tile Vertical"
        '
        'MnuArrangeIcons
        '
        Me.MnuArrangeIcons.Name = "MnuArrangeIcons"
        Me.MnuArrangeIcons.Size = New System.Drawing.Size(152, 22)
        Me.MnuArrangeIcons.Text = "Arrange Icons"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1074, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Welcome :"
        '
        'lbluser
        '
        Me.lbluser.AutoSize = True
        Me.lbluser.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluser.Location = New System.Drawing.Point(1155, 1)
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Size = New System.Drawing.Size(30, 15)
        Me.lbluser.TabIndex = 111
        Me.lbluser.Text = "User"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.timestrip})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 602)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1280, 25)
        Me.StatusStrip1.TabIndex = 114
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(105, 20)
        Me.ToolStripStatusLabel1.Text = "Copyright Skulsys 2014"
        '
        'timestrip
        '
        Me.timestrip.Name = "timestrip"
        Me.timestrip.Size = New System.Drawing.Size(0, 20)
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Image = CType(resources.GetObject("CloseAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseAllToolStripMenuItem.Text = "Close All"
        '
        'Parent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 627)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbluser)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Parent"
        Me.Text = "MULTIVISION PRODUCTS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuFeesStructure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUserAccounts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbluser As System.Windows.Forms.Label
    Friend WithEvents MnuWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCascade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTileHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTileVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuArrangeIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents timestrip As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AddProductsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MAKESALEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIEWSALESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
