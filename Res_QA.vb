Public Class Res_QA

    Public Sub filter()
        Dim selectedValue As String = ComboBox1.SelectedItem.ToString()

        ListBox1.Items.Clear()

        For Each row As DataGridViewRow In res_man.DataGridView1.Rows
            If row.Cells.Count > 2 AndAlso row.Cells(2).Value IsNot Nothing AndAlso row.Cells(2).Value.ToString() = selectedValue Then
                ListBox1.Items.Add(row.Cells(0).Value.ToString())
                Label1.Text = ListBox1.Items.Count().ToString & " Items Loaded"
            End If
        Next

    End Sub

    Public Sub CompareValues(columnValue As String)
        Dim selectedHeader As String = biome_manager.DataGridView1.Columns(biome_manager.DataGridView1.SelectedCells(0).ColumnIndex).HeaderText

        Dim selectedCell As DataGridViewCell = biome_manager.DataGridView1.SelectedCells(0)
        Dim selectedItem As String = ListBox1.SelectedItem.ToString

        If columnValue = selectedHeader Then
            selectedCell.Value = selectedCell.Value & ", " & selectedItem
            biome_manager.saveBiomes()
        Else
            MessageBox.Show("Invalid Category for type of resource. See Resource Manager for more info on types.")
        End If
    End Sub
    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Dim selectedText As String = ListBox1.SelectedItem.ToString()

        For Each row As DataGridViewRow In res_man.DataGridView1.Rows
            If row.Cells(0).Value.ToString = selectedText Then
                Dim columnValue As String = row.Cells(2).Value.ToString
                CompareValues(columnValue)
            End If
        Next

    End Sub

    Private Sub Res_QA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        res_man.softLoad()

        For Each item In res_man.columnList
            If Not ListBox1.Items.Contains(item) Then
                ListBox1.Items.Add(item)
            End If
            Label1.Text = ListBox1.Items.Count().ToString & " Items Loaded"

        Next

        For Each cat In res_man.resType
            If Not ComboBox1.Items.Contains(cat) Then
                ComboBox1.Items.Add(cat)
            End If
        Next
        Label1.Text = ListBox1.Items.Count().ToString & " Items Loaded"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        filter()
    End Sub

End Class