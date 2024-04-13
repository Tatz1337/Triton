Module map_algorithms

    ' tvstatic will create a random effect similar to a channel with no signal
    Sub Tvstatic(ByVal hx As Integer, ByVal vy As Integer)

        Dim newmap As Bitmap
        Dim newcol As Color
        Dim bwcol As Integer
        Dim flip As Boolean = False
        Static rand As New Random

        newmap = New Bitmap(hx, vy)
        Terrain_Sim.ProgressBar1.Maximum = hx * vy

        For x = 0 To newmap.Width - 1
            For y = 0 To newmap.Height - 1
                bwcol = rand.Next(255)
                newcol = Color.FromArgb(bwcol, bwcol, bwcol)
                newmap.SetPixel(x, y, newcol)

                Terrain_Sim.ProgressBar1.PerformStep()
            Next
        Next
        Terrain_Sim.PictureBox2.Image = newmap
        Terrain_Sim.Button3.Enabled = True

    End Sub
    '=============================================================================================
    '=============================================================================================
    '
    ' basrand will create a random effect
    Sub Basrand(ByVal hx As Integer, ByVal vy As Integer)

        Dim newmap As Bitmap
        Dim newcol As Color
        Dim bwcol As Integer
        Dim flip As Boolean = False
        Static rand As New Random

        newmap = New Bitmap(hx, vy)
        Terrain_Sim.ProgressBar1.Maximum = hx * vy
        Terrain_Sim.ProgressBar1.Value = 0
        bwcol = rand.Next(255)

        For x = 0 To newmap.Width - 1
            For y = 0 To newmap.Height - 1

                If x = 0 And y = 0 Then bwcol = 0
                If x = hx And y = 0 Then bwcol = 64
                If x = 0 And y = vy Then bwcol = 128
                If x = hx And y = vy Then bwcol = 255

                newcol = Color.FromArgb(bwcol, bwcol, bwcol)
                newmap.SetPixel(x, y, newcol)

                bwcol = bwcol + rand.Next(10)
                If bwcol > 255 Then bwcol = 255
                Terrain_Sim.ProgressBar1.PerformStep()
            Next
            newmap.RotateFlip(RotateFlipType.Rotate90FlipNone)
            bwcol = rand.Next(255)
        Next
        Terrain_Sim.PictureBox2.Image = newmap
        Terrain_Sim.Button3.Enabled = True

    End Sub


End Module
