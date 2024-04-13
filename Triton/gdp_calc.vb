Public Class gdp_calc
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim cc As Integer = NumericUpDown1.Value
        Dim ge As Integer = NumericUpDown2.Value
        Dim ti As Integer = NumericUpDown3.Value
        Dim ne As Integer = NumericUpDown4.Value

        Dim GDP As Integer = cc + ge + ti + ne
        TextBox28.Text = "$" & GDP.ToString("N0")
    End Sub
End Class