<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BiomeFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BiomeManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FleetManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GDPCalculatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CouncilSimulatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShipDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResourceOccuranceSimulatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerrainSimulatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FactionSimulatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangelogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiscToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextToMorseConverterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(585, 153)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(120, 20)
        Me.LinkLabel5.TabIndex = 3
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "@DatabaseDevil"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Stencil", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(249, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(497, 142)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "TRITON"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(-9, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(236, 167)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Interval = 1
        '
        'Timer4
        '
        Me.Timer4.Interval = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ProgramsToolStripMenuItem, Me.ChangelogToolStripMenuItem, Me.HelpToolStripMenuItem, Me.CreditsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(719, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BiomeFileToolStripMenuItem})
        Me.OpenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.OpenToolStripMenuItem.Text = "File"
        '
        'BiomeFileToolStripMenuItem
        '
        Me.BiomeFileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.BiomeFileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BiomeFileToolStripMenuItem.Name = "BiomeFileToolStripMenuItem"
        Me.BiomeFileToolStripMenuItem.Size = New System.Drawing.Size(128, 26)
        Me.BiomeFileToolStripMenuItem.Text = "Close"
        '
        'ProgramsToolStripMenuItem
        '
        Me.ProgramsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BiomeManagerToolStripMenuItem, Me.FleetManagerToolStripMenuItem, Me.GDPCalculatorToolStripMenuItem, Me.CouncilSimulatorToolStripMenuItem, Me.TestToolStripMenuItem, Me.ToolStripMenuItem1, Me.ShipDatabaseToolStripMenuItem, Me.ResourceOccuranceSimulatorToolStripMenuItem, Me.TerrainSimulatorToolStripMenuItem, Me.FactionSimulatorToolStripMenuItem, Me.MiscToolStripMenuItem})
        Me.ProgramsToolStripMenuItem.Name = "ProgramsToolStripMenuItem"
        Me.ProgramsToolStripMenuItem.Size = New System.Drawing.Size(86, 24)
        Me.ProgramsToolStripMenuItem.Text = "Programs"
        '
        'BiomeManagerToolStripMenuItem
        '
        Me.BiomeManagerToolStripMenuItem.Name = "BiomeManagerToolStripMenuItem"
        Me.BiomeManagerToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.BiomeManagerToolStripMenuItem.Text = "Biome Manager"
        '
        'FleetManagerToolStripMenuItem
        '
        Me.FleetManagerToolStripMenuItem.Name = "FleetManagerToolStripMenuItem"
        Me.FleetManagerToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.FleetManagerToolStripMenuItem.Text = "Fleet Manager"
        '
        'GDPCalculatorToolStripMenuItem
        '
        Me.GDPCalculatorToolStripMenuItem.Name = "GDPCalculatorToolStripMenuItem"
        Me.GDPCalculatorToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.GDPCalculatorToolStripMenuItem.Text = "GDP Calculator"
        '
        'CouncilSimulatorToolStripMenuItem
        '
        Me.CouncilSimulatorToolStripMenuItem.Name = "CouncilSimulatorToolStripMenuItem"
        Me.CouncilSimulatorToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.CouncilSimulatorToolStripMenuItem.Text = "Council Simulator"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.TestToolStripMenuItem.Text = "Map Generator"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(293, 26)
        Me.ToolStripMenuItem1.Text = "Resource Manager"
        '
        'ShipDatabaseToolStripMenuItem
        '
        Me.ShipDatabaseToolStripMenuItem.Name = "ShipDatabaseToolStripMenuItem"
        Me.ShipDatabaseToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.ShipDatabaseToolStripMenuItem.Text = "Ship Part Database"
        '
        'ResourceOccuranceSimulatorToolStripMenuItem
        '
        Me.ResourceOccuranceSimulatorToolStripMenuItem.Name = "ResourceOccuranceSimulatorToolStripMenuItem"
        Me.ResourceOccuranceSimulatorToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.ResourceOccuranceSimulatorToolStripMenuItem.Text = "Resource Occurance Simulator"
        '
        'TerrainSimulatorToolStripMenuItem
        '
        Me.TerrainSimulatorToolStripMenuItem.Name = "TerrainSimulatorToolStripMenuItem"
        Me.TerrainSimulatorToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.TerrainSimulatorToolStripMenuItem.Text = "Terrain Simulator"
        '
        'FactionSimulatorToolStripMenuItem
        '
        Me.FactionSimulatorToolStripMenuItem.Name = "FactionSimulatorToolStripMenuItem"
        Me.FactionSimulatorToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.FactionSimulatorToolStripMenuItem.Text = "Faction Simulator"
        '
        'ChangelogToolStripMenuItem
        '
        Me.ChangelogToolStripMenuItem.Name = "ChangelogToolStripMenuItem"
        Me.ChangelogToolStripMenuItem.Size = New System.Drawing.Size(95, 24)
        Me.ChangelogToolStripMenuItem.Text = "Changelog"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'CreditsToolStripMenuItem
        '
        Me.CreditsToolStripMenuItem.Name = "CreditsToolStripMenuItem"
        Me.CreditsToolStripMenuItem.Size = New System.Drawing.Size(69, 24)
        Me.CreditsToolStripMenuItem.Text = "Credits"
        '
        'MiscToolStripMenuItem
        '
        Me.MiscToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TextToMorseConverterToolStripMenuItem})
        Me.MiscToolStripMenuItem.Name = "MiscToolStripMenuItem"
        Me.MiscToolStripMenuItem.Size = New System.Drawing.Size(293, 26)
        Me.MiscToolStripMenuItem.Text = "Misc"
        '
        'TextToMorseConverterToolStripMenuItem
        '
        Me.TextToMorseConverterToolStripMenuItem.Name = "TextToMorseConverterToolStripMenuItem"
        Me.TextToMorseConverterToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.TextToMorseConverterToolStripMenuItem.Text = "Text-To-Morse Converter"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(719, 208)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRITON - Home"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Timer4 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BiomeFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgramsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BiomeManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FleetManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GDPCalculatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CouncilSimulatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangelogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ShipDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResourceOccuranceSimulatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreditsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TerrainSimulatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FactionSimulatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MiscToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextToMorseConverterToolStripMenuItem As ToolStripMenuItem
End Class
