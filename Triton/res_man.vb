Public Class res_man
    Public dsb As New DataSet
    Public columnList As New List(Of String)
    Public resType As New List(Of String)
    Dim softLoaded As Boolean = False
    ' Form1.WriteData("Biomes XML WRITE", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    ' CLEANS UP HEADERS FROM XML FILE TO REMOVE PERIODS

    Public Function saveResources()
        DataGridView1.Update()
        DataGridView1.Refresh()
        dsb.WriteXml("C:\TRITON\XML\Resources.XML")
        Form1.WriteData("Resources XML WRITE", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Function

    Public Function readResources()
        dsb.Clear()
        dsb.ReadXml("C:\TRITON\XML\Resources.XML")
        DataGridView1.DataSource = dsb.Tables("resource")
        Form1.WriteData("Resources XML READ", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Function

    Public Sub softLoad()
        If softLoaded = False Then
            readResources()

            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.HeaderText = column.HeaderText.Replace(".", " ")
            Next

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    columnList.Add(row.Cells(0).Value.ToString())
                End If
            Next

            For Each row2 As DataGridViewRow In DataGridView1.Rows
                If Not row2.IsNewRow Then
                    resType.Add(row2.Cells(2).Value.ToString())
                End If
            Next
            Form1.WriteData("Resource Manager Softloaded", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
            softLoaded = True
        Else
            ' already softloaded
        End If

    End Sub
    Private Sub res_man_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If softLoaded = False Then
            readResources()

            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.HeaderText = column.HeaderText.Replace(".", " ")
            Next

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    columnList.Add(row.Cells(0).Value.ToString())
                End If
            Next

            For Each row2 As DataGridViewRow In DataGridView1.Rows
                If Not row2.IsNewRow Then
                    resType.Add(row2.Cells(2).Value.ToString())
                End If
            Next
        Else
            ' was already softloaded
        End If

    End Sub

    ' REFRESH DATAGRIDVIEW
    Private Sub PhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhToolStripMenuItem.Click

        readResources()
    End Sub

    ' EDITING OF CELLS + SAVES IT TO RESOURCES.XML
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            'ToolStripStatusLabel1.Text = "Editing an entry..."
            Dim newValue As String = InputBox("Enter the new value:", "Edit Cell", cellValue.ToString())
            'ToolStripStatusLabel1.Text = "Idle"
            If Not String.IsNullOrEmpty(newValue) Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = newValue
                dsb.WriteXml("C:\TRITON\XML\RESOURCES.XML")
                'ToolStripStatusLabel3.Text = "Last saved: " + Now
            End If
        End If
    End Sub

    ' ADDS A NEW ENTRY TO DATAGRIDVIEW + SAVES IT TO RESOURCES.XML
    Private Sub EntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntryToolStripMenuItem.Click
        Dim newRow As DataRow = dsb.Tables(0).NewRow()
        newRow("Name") = "Blank"
        newRow("Type") = "Blank"


        dsb.Tables(0).Rows.Add(newRow)
        saveResources()
        'ToolStripStatusLabel3.Text = "Last saved: " + Now
    End Sub

    ' ADDS A NEW CATEGORY TO DATASET AND SAVES IT TO XML WHEN A CHANGE IS MADE
    Private Sub CategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoryToolStripMenuItem.Click
        ' ToolStripStatusLabel1.Text = "Adding a new category..."
        Dim colInfo As String = InputBox("Enter new category: ", "Add Category")
        Dim newColumn As DataColumn = dsb.Tables(0).Columns.Add(colInfo)

        saveResources()
        ' ToolStripStatusLabel1.Text = "Done."
        ' wait(2)
        ' ToolStripStatusLabel1.Text = "Idle"
        'ToolStripStatusLabel3.Text = "Last saved: " + Now
    End Sub

End Class