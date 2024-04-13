Public Class mapBeta

    Private FieldsX As Integer
    Private FieldsY As Integer
    Private Continent As New List(Of Country)
    Private RNG As New Random
    Private SW As New Stopwatch

    Private Class Country
        Public Name As String
        Public Frontier As New Drawing2D.GraphicsPath
        Public Territory As Region
        Public Neighbours As New List(Of Country)
        Public Power As Integer = 0
        Public MapColour As Color
    End Class

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FieldsX = CInt(Math.Sqrt(NumericUpDown1.Value / 2))
        FieldsY = FieldsX
        Continent.Clear()
        ColonizeContinent()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AttackNeighbour()
        TextBox1.Text = "Remaining countries = " & Continent.Count.ToString
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SW = Stopwatch.StartNew()
        WageContinentalWar()
        TextBox1.Text &= Environment.NewLine & "War duration = " & (SW.ElapsedMilliseconds / 1000).ToString("0.0") & " secs."
    End Sub

    Private Sub ColonizeContinent()

        'Each fiefdom occupies a triangle of land:

        Dim w As Single = CSng(PictureBox1.Width / FieldsX)
        Dim h As Single = CSng(PictureBox1.Height / FieldsY)

        For Y As Integer = 0 To FieldsY - 1
            Dim westCountry As Country = Nothing
            For X As Integer = 0 To FieldsX - 1

                'Grab land triangle (point down):
                Dim fiefdomA As New Country
                Dim pfA(2) As PointF
                'pfA(0) = New PointF(X * w, Y * h)
                'pfA(1) = New PointF((X + 1) * w, Y * h)
                'pfA(2) = New PointF(X * w, (Y + 1) * h)
                pfA(0) = New PointF(X * w, Y * h)
                pfA(1) = New PointF((X + 5) * w, Y * h)
                pfA(2) = New PointF(X * w, (Y + 5) * h)
                EstablishFiefdom(fiefdomA, pfA)

                'Befriend neighbour to West
                If westCountry IsNot Nothing Then BefriendNeighbour(westCountry, fiefdomA)

                'Befriend neighbour to North:
                If Y > 0 Then
                    Dim northCountry As Country = Continent((Y - 1) * 2 * FieldsX + X * 2 + 1)
                    BefriendNeighbour(northCountry, fiefdomA)
                End If

                'Grab land triangle (point up):
                Dim fiefdomB As New Country
                westCountry = fiefdomB
                Dim pfB(2) As PointF
                pfB(0) = pfA(1)
                pfB(1) = New PointF((X + 1) * w, (Y + 1) * h)
                pfB(2) = pfA(2)
                EstablishFiefdom(fiefdomB, pfB)

                'Befriend neighbour to East:
                BefriendNeighbour(fiefdomA, fiefdomB)

            Next
        Next

        PictureBox1.Refresh()

    End Sub

    Private Sub EstablishFiefdom(ByVal newCountry As Country, ByVal LandTriangle As PointF())

        Continent.Add(newCountry)
        With newCountry
            .Frontier.AddPolygon(LandTriangle)
            .Territory = New Region(.Frontier)
            .MapColour = RandomColour()
            .Name = "Country No. " & Continent.Count.ToString
        End With

    End Sub

    Private Sub BefriendNeighbour(ByVal Country1 As Country, ByVal Country2 As Country)

        If Country1 Is Country2 Then Exit Sub
        If Not Country1.Neighbours.Contains(Country2) Then Country1.Neighbours.Add(Country2)
        If Not Country2.Neighbours.Contains(Country1) Then Country2.Neighbours.Add(Country1)

    End Sub

    Private Sub AttackNeighbour()

        If Continent.Count < 1 Then Exit Sub 'hack to prevent unexpected out of range error.

        Dim Aggressor As Country = Continent(RNG.Next(0, Continent.Count - 1))
        Dim Victim As Country = Aggressor.Neighbours.Item(RNG.Next(0, Aggressor.Neighbours.Count - 1))

        Dim Winner As Country = DecideBattle(Aggressor, Victim)
        If Winner Is Aggressor Then
            AssimilateLoser(Aggressor, Victim)
        Else
            AssimilateLoser(Victim, Aggressor)
        End If

    End Sub

    Private Function DecideBattle(ByVal Aggressor As Country, ByVal Victim As Country) As Country

        'The aggressor has the advantage of surprise:
        Dim ArmyA As Integer = Aggressor.Power + RNG.Next(0, Continent.Count) \ 3
        Dim ArmyV As Integer = Victim.Power + RNG.Next(0, Continent.Count) \ 4
        If ArmyA > ArmyV Then Return Aggressor Else Return Victim

    End Function

    Private Sub AssimilateLoser(ByVal Winner As Country, ByVal Loser As Country)

        'Merge territories
        Winner.Territory.Union(Loser.Territory)

        'Form new neighbour relations
        Loser.Neighbours.Remove(Winner)
        Winner.Neighbours.Remove(Loser)
        For Each neighbour As Country In Loser.Neighbours
            neighbour.Neighbours.Remove(Loser)
            BefriendNeighbour(Winner, neighbour)
        Next

        Continent.Remove(Loser)
        Winner.Power += 1



    End Sub

    Private Sub WageContinentalWar()

        Do Until Continent.Count = CInt(NumericUpDown2.Value)
            AttackNeighbour()

        Loop
        PictureBox1.Refresh()
    End Sub

    Private Function RandomColour() As Color
        Dim rgb(3) As Integer
        Dim bias As Integer = RNG.Next(0, 2)
        rgb(bias) = 99 + RNG.Next(0, 155)
        rgb(bias + 1 Mod 3) = 55 + RNG.Next(0, 199)
        rgb(bias + 2 Mod 3) = 55 + RNG.Next(0, 199)
        Return Color.FromArgb(rgb(0), rgb(1), rgb(2))
    End Function

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        For Each country In Continent
            Using sbr As New SolidBrush(country.MapColour)
                e.Graphics.Clip = country.Territory
                e.Graphics.FillRectangle(sbr, PictureBox1.ClientRectangle)
            End Using
        Next
    End Sub

    Private Sub PictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        For Each land As Country In Continent
            If land.Territory.IsVisible(e.Location) Then
                Dim sb As New System.Text.StringBuilder
                sb.AppendLine(land.Name)
                sb.AppendLine("No. of neighbours = " & land.Neighbours.Count.ToString)
                sb.AppendLine("Power = " & land.Power.ToString)
                ToolTip1.SetToolTip(PictureBox1, sb.ToString)
            End If
        Next
    End Sub


End Class
