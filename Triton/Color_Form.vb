Imports System.Windows.Forms
Public Class Color_Form
    Inherits Form

    Public npic As New PictureBox
    Dim nmenu As New MenuStrip()
    Dim mitem As New ToolStripMenuItem("Image")
    Dim WithEvents Smitem As New ToolStripMenuItem("Save")

    Public Sub New(ByVal wx As Integer, ByVal vy As Integer)
        Me.Text = "Color_Map"
        Me.Width = wx + 30
        Me.Height = vy + 70

        npic.Width = wx
        npic.Height = vy
        npic.Location = New Point(5, 30)

        mitem.DropDownItems.Add(Smitem)
        nmenu.Items.Add(mitem)
        Me.Controls.Add(nmenu)
        Me.Controls.Add(npic)
        Me.Show()
    End Sub

    Private Sub Saveimage_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Smitem.Click
        Dim ndial As New SaveFileDialog
        Dim nresult As DialogResult
        ndial.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg|*.jpg|Png|*.png|Bmp|*.bmp|Gif|*.gif|Ico|*.ico"

        nresult = ndial.ShowDialog
        If nresult = DialogResult.OK Then
            npic.Image.Save(ndial.FileName, System.Drawing.Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub Color_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        '
        'Color_Form
        '
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.Name = "Color_Form"
        Me.Text = " "
        Me.ResumeLayout(False)
    End Sub
End Class
