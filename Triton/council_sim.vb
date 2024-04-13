Public Class council_sim

    Dim votesFor As Integer
    Dim votesAbstain As Integer
    Dim votesAgainst As Integer

    Dim motionsPassed As Integer
    Dim motionsFailed As Integer
    ' 600 
    Dim yay As Integer
    Dim nay As Integer
    ' START Random Number Generator Function
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Public Function stateVoteGen()
        Dim genNum = GetRandom(1, 10)
        Return genNum
    End Function

    Public Function nameValidate()
        Label44.Text = Label16.Text
        Label45.Text = Label17.Text
        Label46.Text = Label18.Text
        Label47.Text = Label19.Text
        Label48.Text = Label20.Text
        Label49.Text = Label21.Text
        Label50.Text = Label22.Text
        Label51.Text = Label23.Text
        Label52.Text = Label24.Text
        Label53.Text = Label25.Text
    End Function

    Public Function changeName()
        Dim ghostName As String = InputBox("New name for Nation")
        If ghostName Is Nothing Then
            MsgBox("No name entered, keeping original")
        Else
            ghostName = ghostName + ":"
            Return ghostName

        End If
    End Function

    Public Function stateVote(ByVal agreeance As Integer, ByVal modifier As Integer, panelName As Panel)

        If agreeance >= modifier Then
            panelName.BackColor = Color.Green
            votesFor += 1
            Label28.Text = "For: " & votesFor
        ElseIf agreeance > 3 AndAlso agreeance <= 6 Then
            panelName.BackColor = Color.Yellow
            votesAbstain += 1
            Label29.Text = "Abstained: " & votesAbstain
        ElseIf agreeance <= 5 Then
            panelName.BackColor = Color.Red
            votesAgainst += 1
            Label30.Text = "Against: " & votesAgainst
        ElseIf modifier = 10 Or modifier = 9 Then
            panelName.BackColor = Color.Red
            votesAgainst += 1
        End If

    End Function

    Public Function checkResults(state1 As Panel, state2 As Panel, state3 As Panel, state4 As Panel, state5 As Panel, state6 As Panel, state7 As Panel, state8 As Panel, state9 As Panel, state10 As Panel)
        Dim panelArray() As Panel = {state1, state2, state3, state4, state5, state6, state7, state8, state9, state10}

        For Each pizzle In panelArray
            If pizzle.BackColor = Color.Green Then
                yay += 1
            ElseIf pizzle.BackColor = Color.Red Then
                nay += 1
            End If
        Next

        If yay > nay Then
            Label31.ForeColor = Color.Green
            Label31.Text = "Motion Passed"
            motionsPassed += 1
            yay = 0
            nay = 0
            Label42.Text = "Total Passed: " & motionsPassed
            Label55.Text = "Total Attempted: " & (motionsFailed + motionsPassed)
            ' Label54.Text = "%" & (motionsPassed / motionsFailed) * 100 & " Success Rate"
        Else
            Label31.ForeColor = Color.Red
            Label31.Text = "Motion Failed"
            motionsFailed += 1
            yay = 0
            nay = 0
            Label37.Text = "Total Failed: " & motionsFailed
            Label55.Text = "Total Attempted: " & (motionsFailed + motionsPassed)
            ' Label54.Text = (motionsPassed / motionsFailed) & "% Success Rate"
        End If

    End Function

    ' END Random Number Generator Function

    Private Sub council_sim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nameValidate()

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
        CheckBox5.Checked = True
        CheckBox6.Checked = True
        CheckBox7.Checked = True
        CheckBox8.Checked = True
        CheckBox9.Checked = True
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim chaos(1000) As Integer
        For i As Integer = 0 To chaos.Length - 1
            chaos(i) = GetRandom(1, 100)
        Next

        TextBox16.Text = stateVoteGen()
        TextBox17.Text = stateVoteGen()
        TextBox18.Text = stateVoteGen()
        TextBox19.Text = stateVoteGen()
        TextBox20.Text = stateVoteGen()
        TextBox21.Text = stateVoteGen()
        TextBox22.Text = stateVoteGen()
        TextBox23.Text = stateVoteGen()
        TextBox24.Text = stateVoteGen()
        TextBox25.Text = stateVoteGen()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Label16.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Label17.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Label18.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Label19.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Label20.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        Label21.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        Label22.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Label23.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        Label24.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Label25.Text = changeName()
        nameValidate()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If CheckBox10.Checked = False Then
            Timer4.Interval = Int(TextBox26.Text) * 1000
            Button14.PerformClick()
            Button13.PerformClick()
        Else
            Timer4.Interval = 1
            Button14.PerformClick()
            Button13.PerformClick()

        End If
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Timer4.Enabled = True
        Button24.Enabled = True
        Button23.Enabled = False
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Timer4.Enabled = False
        Button23.Enabled = True
        Button24.Enabled = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim brainwash As Integer = NumericUpDown15.Value
        NumericUpDown5.Value = brainwash
        NumericUpDown6.Value = brainwash
        NumericUpDown7.Value = brainwash
        NumericUpDown8.Value = brainwash
        NumericUpDown9.Value = brainwash
        NumericUpDown10.Value = brainwash
        NumericUpDown11.Value = brainwash
        NumericUpDown12.Value = brainwash
        NumericUpDown13.Value = brainwash
        NumericUpDown14.Value = brainwash
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ' reset all colors for panels back to gray in case of checked nation later on 
        Panel1.BackColor = Color.Transparent
        Panel2.BackColor = Color.Transparent
        Panel3.BackColor = Color.Transparent
        Panel4.BackColor = Color.Transparent
        Panel5.BackColor = Color.Transparent
        Panel6.BackColor = Color.Transparent
        Panel7.BackColor = Color.Transparent
        Panel8.BackColor = Color.Transparent
        Panel9.BackColor = Color.Transparent
        Panel10.BackColor = Color.Transparent



        stateVote(TextBox16.Text, NumericUpDown5.Value, Panel1)
        stateVote(TextBox17.Text, NumericUpDown6.Value, Panel2)


        ' nation 3
        If CheckBox2.Checked = False Then
            stateVote(TextBox18.Text, NumericUpDown7.Value, Panel3)
        End If

        ' nation 4
        If CheckBox3.Checked = False Then
            stateVote(TextBox19.Text, NumericUpDown8.Value, Panel4)
        End If

        ' nation 5
        If CheckBox4.Checked = False Then
            stateVote(TextBox20.Text, NumericUpDown9.Value, Panel5)
        End If

        ' nation 6
        If CheckBox5.Checked = False Then
            stateVote(TextBox21.Text, NumericUpDown10.Value, Panel6)
        End If

        'nation 7
        If CheckBox6.Checked = False Then
            stateVote(TextBox22.Text, NumericUpDown11.Value, Panel7)
        End If

        ' nation 8 
        If CheckBox7.Checked = False Then
            stateVote(TextBox23.Text, NumericUpDown12.Value, Panel8)
        End If

        ' nation 9
        If CheckBox8.Checked = False Then
            stateVote(TextBox24.Text, NumericUpDown13.Value, Panel9)
        End If

        'nation 10
        If CheckBox9.Checked = False Then
            stateVote(TextBox25.Text, NumericUpDown14.Value, Panel10)
        End If
        'Dim panelArray() As Panel = {Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8, Panel9, Panel10}
        checkResults(Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8, Panel9, Panel10)
    End Sub
End Class