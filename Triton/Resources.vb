Imports System.IO
Imports System.Text

Module Resources

    Dim cDialog As New ColorDialog()

    Sub Colorlabels256()
        Dim x, y, z As Integer
        Dim lnum As Integer = 1
        Dim collbl As Label

        Dim FontName As String = "Arial"
        Dim FontSize As Integer = 11
        Dim FS As New Font(FontName, FontSize, FontStyle.Regular)

        x = 5
        y = 5

        For z = 0 To 255
            collbl = New Label
            If z < 125 Then collbl.ForeColor = Color.White
            With collbl
                .Parent = Terrain_Sim.Panel5
                .Name = "col" & lnum.ToString
                .Location = New Drawing.Point(x, y)
                .BackColor = Color.FromArgb(z, z, z)
                .Font = FS
                .AutoSize = True
                .Text = z.ToString
            End With

            x = x + collbl.PreferredWidth + 5
            If z = 24 Or z = 49 Or z = 74 Or z = 99 Or z = 124 Or z = 149 Or z = 174 Or z = 199 Or z = 224 Or z = 249 Then
                y = y + collbl.PreferredHeight + 10
                x = 5
            End If
            AddHandler collbl.Click, AddressOf Collbl_click
            lnum += 1
        Next
    End Sub

    Private Sub Collbl_click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles collbl.Click

        cDialog.Color = sender.BackColor ' initial selection is current color.
        cDialog.AnyColor = True
        cDialog.AllowFullOpen = True
        cDialog.SolidColorOnly = True

        If (cDialog.ShowDialog() = DialogResult.OK) Then

            sender.BackColor = cDialog.Color ' update with user selected color.

        End If
    End Sub

    Public Sub Lastread()
        ' Store the line in this String.
        Dim line As String
        ' splits the line into "label, red-color, green-color, blue-color"
        Dim nline As String()
        Dim lline As String
        Dim rline As Integer
        Dim gline As Integer
        Dim bline As Integer

        Dim curFile As String = "C:\TRITON\Configs\color_scheme.txt"

        If File.Exists(curFile) Then
            ' Create new StreamReader instance with Using block.
            Using reader As StreamReader = New StreamReader("C:\TRITON\Configs\color_scheme.txt")
                For Each item As Label In Terrain_Sim.Panel5.Controls
                    ' Read one line from file
                    line = reader.ReadLine
                    nline = line.Split("/")
                    lline = nline(0)
                    rline = nline(1)
                    gline = nline(2)
                    bline = nline(3)
                    item.BackColor = Color.FromArgb(rline, gline, bline)
                Next
            End Using
        End If

    End Sub

    Public Sub Lastwrite()

        Using outfile As New StreamWriter("C:\TRITON\Configs\color_scheme.txt")

            For Each item As Label In Terrain_Sim.Panel5.Controls
                outfile.WriteLine(item.Name & "/" & item.BackColor.R & "/" & item.BackColor.G & "/" & item.BackColor.B)
            Next

        End Using

    End Sub

End Module
