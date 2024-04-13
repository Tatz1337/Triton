Public Class TTMC
    Private Declare Function NtBeep Lib "kernel32.dll" Alias "Beep" (ByVal FreqHz As Integer, ByVal DurationMs As Integer) As Integer

    Dim translation As New Dictionary(Of String, String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Heathkit version
        translation.Add("A", "*-")
        translation.Add("B", "-***")
        translation.Add("C", "-*-*")
        translation.Add("D", "-**")
        translation.Add("E", "*")
        translation.Add("F", "**-*")
        translation.Add("G", "--*")
        translation.Add("H", "****")
        translation.Add("I", "**")
        translation.Add("J", "*---")
        translation.Add("K", "-*-")
        translation.Add("L", "*-**")
        translation.Add("M", "--")
        translation.Add("N", "-*")
        translation.Add("O", "---")
        translation.Add("P", "*--*")
        translation.Add("Q", "--*-")
        translation.Add("R", "*-*")
        translation.Add("S", "***")
        translation.Add("T", "-")
        translation.Add("U", "**-")
        translation.Add("V", "***-")
        translation.Add("W", "*--")
        translation.Add("X", "-**-")
        translation.Add("Y", "-*--")
        translation.Add("Z", "--**")
        translation.Add("1", "*----")
        translation.Add("2", "**---")
        translation.Add("3", "***--")
        translation.Add("4", "****-")
        translation.Add("5", "*****")
        translation.Add("6", "-****")
        translation.Add("7", "--***")
        translation.Add("8", "---**")
        translation.Add("9", "----*")
        translation.Add("0", "-----")
        translation.Add(".", "*-*-*-")
        translation.Add(",", "--**--")
        translation.Add("?", "**--**")
        translation.Add("'", "*----*")
        translation.Add("!", "-*-*--")
        translation.Add("/", "-**-*")
        translation.Add("(", "-*--*")
        translation.Add(")", "-*--*-")
        translation.Add("&", "*-***")
        translation.Add(":", "---***")
        translation.Add(";", "-*-*-*")
        translation.Add("=", "-***-")
        translation.Add("+", "*-*-*")
        translation.Add("-", "-****-")
        translation.Add("_", "**--*-")
        translation.Add("""", "*-**-*")
        translation.Add("$", "***-**-")
        translation.Add("@", "*--*-*")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox2.Text = String.Join("/", Array.ConvertAll(RichTextBox1.Text.ToArray, Function(c) If(translation.Keys.Contains(c.ToString.ToUpper), translation(c.ToString.ToUpper), c.ToString)))
        RichTextBox2.Refresh()
        '523.25
        '125,375
        If CheckBox1.Checked = True Then
            For Each c As Char In RichTextBox2.Text
                If c = "*"c Then
                    NtBeep(523, 100)
                ElseIf c = "-"c Then
                    NtBeep(523, 300)
                ElseIf c <> "/" Then
                    Threading.Thread.Sleep(300)
                End If
            Next
        Else
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Text = String.Concat(Array.ConvertAll(RichTextBox2.Text.Split("/"c), Function(s) If(translation.Values.Contains(s), translation.First(Function(kvp) kvp.Value = s).Key, s)))
    End Sub
End Class