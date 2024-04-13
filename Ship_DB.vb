Public Class Ship_DB
    Public shipdb As New DataSet

    Private Sub Ship_DB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        shipdb.ReadXml("C:\TRITON\XML\ShipDB.XML")
        DataGridView1.DataSource = shipdb.Tables("part")

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.HeaderText = column.HeaderText.Replace(".", " ")
        Next
    End Sub
End Class
