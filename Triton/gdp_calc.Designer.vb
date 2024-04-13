<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gdp_calc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gdp_calc))
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox28
        '
        Me.TextBox28.Enabled = False
        Me.TextBox28.Location = New System.Drawing.Point(58, 194)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(290, 27)
        Me.TextBox28.TabIndex = 25
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(11, 201)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(41, 20)
        Me.Label41.TabIndex = 24
        Me.Label41.Text = "GDP:"
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(107, 116)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(150, 27)
        Me.NumericUpDown4.TabIndex = 23
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(12, 118)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(89, 20)
        Me.Label39.TabIndex = 22
        Me.Label39.Text = "Net Exports:"
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(145, 78)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.NumericUpDown3.Minimum = New Decimal(New Integer() {250000, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(150, 27)
        Me.NumericUpDown3.TabIndex = 21
        Me.NumericUpDown3.Value = New Decimal(New Integer() {250000, 0, 0, 0})
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(12, 80)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(127, 20)
        Me.Label38.TabIndex = 20
        Me.Label38.Text = "Total Investments:"
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.SystemColors.Control
        Me.Button22.Location = New System.Drawing.Point(12, 159)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(336, 29)
        Me.Button22.TabIndex = 19
        Me.Button22.Text = "Calculate"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(198, 40)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(150, 27)
        Me.NumericUpDown2.TabIndex = 18
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(161, 7)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(150, 27)
        Me.NumericUpDown1.TabIndex = 17
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(12, 47)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(180, 20)
        Me.Label36.TabIndex = 16
        Me.Label36.Text = "Government Expendature:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(12, 9)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(149, 20)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Citizen Consumption:"
        '
        'gdp_calc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 231)
        Me.Controls.Add(Me.TextBox28)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.NumericUpDown4)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.NumericUpDown3)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Button22)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gdp_calc"
        Me.Text = "TRITON - GDP Calculator"
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents Label39 As Label
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents Label38 As Label
    Friend WithEvents Button22 As Button
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
End Class
