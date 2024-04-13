Public Class Faction_Sim

    Public Player_Money As Integer = 0
    Public Player_Money_Multiplier As Integer = 2
    Public Player_Ore As Integer = 0
    Public Player_Ore_Modifier As Integer = 1

    Public Sub mineore()
        Player_Ore = (Player_Ore + 1)
        Label2.Text = Player_Ore & " Ore"
    End Sub

    Public Sub sellore()
        Player_Money = Player_Money + (Player_Ore * Player_Money_Multiplier)
        Label1.Text = "$" & Player_Money
        Player_Ore = 0
    End Sub
    Private Sub Faction_Sim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' label 1 is money
        Label1.Text = "$" & Player_Money

        ' Label 2 is ore
        Label2.Text = Player_Ore & " Ore"
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        mineore()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        sellore()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Player_Money >= 100 Then
            Button1.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
        Else
            Button1.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
        End If

        If Player_Money >= 200 Then
            ' 2 7 8
            Button2.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
        Else
            Button2.Enabled = False
            Button7.Enabled = False
            Button8.Enabled = False

        End If

        If Player_Money >= 500 Then
            ' 3 9 10 
            Button3.Enabled = True
            Button9.Enabled = True
            Button10.Enabled = True

        Else
            Button3.Enabled = False
            Button9.Enabled = False
            Button10.Enabled = False

        End If

        If Player_Money >= 1000 Then
            Button4.Enabled = True
            Button11.Enabled = True
        Else
            Button4.Enabled = False
            Button11.Enabled = False

        End If

        If Player_Money >= 100000 Then
            Button12.Enabled = True
        Else
            Button12.Enabled = False

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Player_Money = Player_Money - 100
        Timer2.Enabled = True
        Button1.Visible = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        mineore()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer2.Interval = 750
        Button2.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer2.Interval = 450
        Button3.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer2.Interval = 10
        Button4.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer3.Enabled = True
        Button5.Visible = False
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        sellore()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Player_Ore_Modifier = 5
        Button6.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Timer3.Interval = 750
        Button7.Visible = False
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Player_Ore += 50
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Player_Ore_Modifier = 10
        Button8.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Player_Ore_Modifier = 15
        Button9.Visible = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Timer3.Interval = 500
        Button10.Visible = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Timer3.Interval = 10
        Button11.Visible = False
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Player_Ore_Modifier = 50
        Button9.Visible = False
    End Sub
End Class