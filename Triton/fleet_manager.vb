Imports System.ComponentModel

Public Class fleet_manager

    Public ds_ships As New DataSet

    Private Sub fleet_manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds_ships.ReadXml("C:\TRITON\XML\Fleets.XML")
        DataGridView1.DataSource = ds_ships.Tables("ships")

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.HeaderText = column.HeaderText.Replace(".", " ")
        Next
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        ds_ships.Clear()
        ds_ships.ReadXml("C:\TRITON\XML\Fleets.XML")
        DataGridView1.DataSource = ds_ships.Tables("ships")
        DataGridView1.Update()
        DataGridView1.Refresh()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim newValue As String = InputBox("Enter the new value:", "Edit Cell", cellValue.ToString())

            If Not String.IsNullOrEmpty(newValue) Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = newValue
                ds_ships.WriteXml("C:\TRITON\XML\Fleets.XML")
            End If
        End If
    End Sub

    Private Sub NewEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEntryToolStripMenuItem.Click
        Dim newRow As DataRow = ds_ships.Tables(0).NewRow()
        '      
        newRow("Ship.Name") = "USS Crackhouse"
        newRow("Hull.Number") = "666"
        newRow("Ship.Class") = "Floating Crackhouse"
        newRow("Ship.Length") = "3.50"
        newRow("Ship.Width") = "69"
        newRow("Ship.Crew.Size") = "9001"
        newRow("Ship.Captain.Name") = "Capt. Sudan"
        newRow("Ship.Fleet") = "The Avengers"
        newRow("Ship.Squadron") = "Full Metal Jacket"
        newRow("Ship.Guns") = "1x Glock 17"


        ds_ships.Tables(0).Rows.Add(newRow)
        DataGridView1.Refresh()
        DataGridView1.Update()
        ds_ships.WriteXml("C:\TRITON\XML\Fleets.XML")
    End Sub

    Private Sub NewCategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCategoryToolStripMenuItem.Click
        Dim colInfo As String = InputBox("Enter new category: ", "Add Category")
        Dim newColumn As DataColumn = ds_ships.Tables(0).Columns.Add(colInfo)

        DataGridView1.Refresh()
        DataGridView1.Update()
        ds_ships.WriteXml("C:\TRITON\XML\Fleets.XML")
    End Sub

End Class