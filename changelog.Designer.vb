<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changelog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(changelog))
        Me.ListBox6 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBox6
        '
        Me.ListBox6.FormattingEnabled = True
        Me.ListBox6.ItemHeight = 20
        Me.ListBox6.Items.AddRange(New Object() {"3/26/24 - Added Council Simulator, Ability to change nation names, disable nation" &
                "s", "3/26/24 - Added skeleton for Fleet Manager", "3/26/24 - Added Basic GDP Calculation (Expenditure Approach)", "3/26/24 - Improved Randomization of Council + Modified Rates", "3/26/24 - Added Disagreeability Modifiers to Councils and Added Success Rate and " &
                "Total Attempts to Council", "3/26/24 - Added Debug Memory Watchdog", "3/27/24 - Removed Binary Serialization and Added XML Serialization", "4/7/24 - Incorporated XML Loading + Saving", "4/7/24 - NOTE: Biome Addition is currently not working", "4/7/24 - Release 1.0 ", "4/7/24 - Added Refresh Button to Inputs & Fleet Manager", "4/7/24 - Cosmetic Update to Data Presentation, Added Individual Cell Editing"})
        Me.ListBox6.Location = New System.Drawing.Point(0, -2)
        Me.ListBox6.Name = "ListBox6"
        Me.ListBox6.Size = New System.Drawing.Size(882, 564)
        Me.ListBox6.TabIndex = 1
        '
        'changelog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 561)
        Me.Controls.Add(Me.ListBox6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "changelog"
        Me.Text = "Changelog"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox6 As ListBox
End Class
