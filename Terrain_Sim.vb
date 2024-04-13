Imports System.Drawing.Bitmap
Imports System.Drawing.Graphics

Public Class Terrain_Sim
    'the form loaded to color the perlin map
    Dim nform As Color_Form
    Dim image1 As Bitmap ' i think this does nothing - just a left over - need to look into it
    'wx,vy are the image size
    Dim wx, vy As Integer

    Dim cmapcount As Integer = 1
    Public nperlin As Perlin

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Resources.Lastwrite()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'loads 256 labels whos text and backcolor is 0 to 255 "greyscale"
        Resources.Colorlabels256()
        'loads color_scheme - label background color that the labels were set to the last time the program closed
        Resources.Lastread()

    End Sub
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ' the Generate Perlin button
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Gen_per_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        ' *****it would seem the x and y need to be equal*****
        '''''
        ' this is where you need to set the size of the initial perlin image if you are not loading one
        wx = NumericUpDown8.Value
        vy = NumericUpDown9.Value

        PictureBox2.Width = wx
        PictureBox2.Height = vy

        ' calls the perlin class to generate the perlin map
        nperlin = New Perlin(wx, vy)

        ' this was just me playing with different types of generation - in the end the algorithms were too complex for me to do any more that this
        'map_algorithms.basrand(512, 512)
        'map_algorithms.tvstatic(512, 512)

        PictureBox2.Image = nperlin.FinalImage.Clone
        Button3.Enabled = True
    End Sub
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ' the Apply Color button
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim colorlabel As Label
        Dim curcol As Integer
        Dim newcol As Color
        Dim x, y As Integer
        Dim colormap As Bitmap
        Dim sizecount As Integer = 1
        Dim maxsize As Integer = wx * vy

        'creates a new form to display the color map
        nform = New Color_Form(wx, vy) With {
            .BackColor = Color.Black
        }
        ' clones the image in picturebox2 - so that changes made to colormap won't also effect picturebox2
        colormap = PictureBox2.Image.Clone
        'loops through colormap, pixel by pixel, to get its color and finds its corresponding label, then changes the pixel color to the labels background color.
        For x = 0 To wx - 1
            For y = 0 To vy - 1
                curcol = colormap.GetPixel(x, y).R
                'colorlabel = Panel5.Controls.Find("col" & curcol.ToString, True)(0)
                'changed to list look up based on controls index  HUGE speed increase  suggested by "passel" ---> https://www.vbforums.com/showthread.php?770701-VB-2010-Simple-Terrain-Generator&p=5352219#post5352219
                colorlabel = Panel5.Controls.Item(curcol)
                newcol = colorlabel.BackColor
                colormap.SetPixel(x, y, newcol)
                'nform.Text = "Color Map " & cmapcount.ToString & "   |--->   " & sizecount.ToString & "   of   " & maxsize.ToString & "  Pixels"
                sizecount += 1
            Next
            'Moved here to outer loop to speed up processing   suggested by  "passel"  ---> https://www.vbforums.com/showthread.php?770701-VB-2010-Simple-Terrain-Generator&p=5352219#post5352219
            nform.Text = "Color Map " & cmapcount.ToString & "   |--->   " & sizecount.ToString & "   of   " & maxsize.ToString & "  Pixels"
        Next
        nform.npic.Image = colormap
        ' resets the size count for the next color map
        sizecount = 1
        ' just gives the nform a unique text
        cmapcount += 1
    End Sub
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ' this just creates a copy of the map to full screen
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        nform = New Color_Form(wx, vy)
        With nform
            .WindowState = FormWindowState.Maximized
        End With
        nform.npic.Image = PictureBox2.Image
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click
        Dim ndial As New SaveFileDialog
        Dim nresult As DialogResult
        ndial.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg|*.jpg|Png|*.png|Bmp|*.bmp|Gif|*.gif|Ico|*.ico"

        nresult = ndial.ShowDialog
        If nresult = DialogResult.OK Then
            PictureBox2.Image.Save(ndial.FileName, System.Drawing.Imaging.ImageFormat.Png)
        End If

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        Dim nfile As OpenFileDialog
        nfile = New OpenFileDialog

        If nfile.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(nfile.FileName)
        End If
        wx = PictureBox2.Image.Width
        vy = PictureBox2.Image.Height
        Button3.Enabled = True
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ' Thanks Shehzad Hemani  ---> http://www.devasp.net/net/articles/display/1067.html
    ' takes the perlin image and makes it a negative image
    Private Sub Neg_img_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim img As Bitmap = New Bitmap(PictureBox2.Image)
            Dim c As Color
            Dim i As Integer = 0
            Do While (i < img.Width)
                Dim j As Integer = 0
                Do While (j < img.Height)
                    c = img.GetPixel(i, j)
                    Dim r As Integer = 0
                    r = Convert.ToInt16(c.R)
                    Dim g As Integer = 0
                    g = Convert.ToInt16(c.G)
                    Dim b As Integer = 0
                    b = Convert.ToInt16(c.B)
                    Dim newr As Integer = 0
                    newr = (255 - r)
                    Dim newg As Integer = 0
                    newg = (255 - g)
                    Dim newb As Integer = 0
                    newb = (255 - b)
                    c = Color.FromArgb(newr, newg, newb)
                    img.SetPixel(i, j, c)
                    j = (j + 1)
                Loop
                i = (i + 1)
            Loop
            PictureBox2.Image = img
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Reset_perlin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        NumericUpDown1.Value = 1
        NumericUpDown2.Value = 2
        NumericUpDown3.Value = 10
        NumericUpDown4.Value = 25
        NumericUpDown5.Value = 40
        NumericUpDown6.Value = 48
        NumericUpDown7.Value = 50
    End Sub


    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel3.Click
        Dim fhelp As String = "The first panel contains the variables for generating the perlin noise." & Environment.NewLine &
        "The second panel contains labels with 'greyscale' values - you can click on them to change their color, to create a color map." & Environment.NewLine &
        "The bottom panel is where the generated perlin image is displayed." & Environment.NewLine &
        "===========================================================================" & Environment.NewLine &
        "1. Click the blue Generate Perlin button  -  or  -  ->File ->Open" & Environment.NewLine &
        "2. Click Apply Colors button to create a new image with the corresponding greyscale replaced with the colors you specified."

        Dim hform As New Form With {
            .AutoSize = True
        }
        Dim hlabel As New Label
        With hlabel
            .Text = fhelp
            .AutoSize = True
            .BackColor = Color.DarkSlateGray
            .ForeColor = Color.White
            .BorderStyle = BorderStyle.FixedSingle
        End With

        hform.Controls.Add(hlabel)
        hform.Visible = True
    End Sub
End Class
