Imports System.IO
Imports VB = Microsoft.VisualBasic
' YAMLDotNet Imports
Imports YamlDotNet.Serialization
Imports YamlDotNet.Serialization.NodeDeserializers
Imports YamlDotNet.Serialization.NodeTypeResolvers
Imports YamlDotNet.Serialization.ObjectFactories
Imports YamlDotNet.Serialization.ObjectGraphVisitors
Imports YamlDotNet.Serialization.TypeInspectors
Imports YamlDotNet.Serialization.TypeResolvers
Imports YamlDotNet.Serialization.Utilities
Imports YamlDotNet.Serialization.NamingConventions
Imports YamlDotNet.Serialization.Converters
Imports YamlDotNet.RepresentationModel
Public Class biome_manager
    ' Create Dataset "ds" for Biomes and make it Public
    Public ds As New DataSet

    Public Sub saveBiomes()
        ' Refresh the DataGridView
        DataGridView1.Refresh()
        DataGridView1.Update()
        ' Write 'ds' dataset to XML File
        ds.WriteXml("C:\TRITON\XML\Biomes.XML")
        ' Update ToolStrip to indicate time of save
        ToolStripStatusLabel3.Text = "Last saved: " + Now
        Form1.WriteData("Biomes XML WRITE", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Public Sub loadBiomes()
        ' Read from XML and write to dataset 'ds' 
        ds.ReadXml("C:\TRITON\XML\Biomes.XML")
        Form1.WriteData("Biomes XML READ", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
        ' set DataGridView DataSource to "biome" tag from XML file 
        DataGridView1.DataSource = ds.Tables("biome")

        ' Convert all periods in XML naming schemes to white space in datagridview column headers
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.HeaderText = column.HeaderText.Replace(".", " ")
        Next
    End Sub

    ' Sleep Function
    Public Sub wait(ByVal seconds As Single)
        Static start As Single
        start = VB.Timer()
        Do While VB.Timer() < start + seconds
            System.Windows.Forms.Application.DoEvents()
        Loop
    End Sub



    Private Sub biome_manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Call Load Biomes
        loadBiomes()
        ' Set Indexes for DataGridView columns so they display in proper order
        DataGridView1.Columns("Biome.Name").DisplayIndex = 0
        DataGridView1.Columns("Level").DisplayIndex = 1
        DataGridView1.Columns("Animals").DisplayIndex = 2
    End Sub

    ' REFRESH DATAGRIDVIEW
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        ' Clear Dataset and Call loadBiomes (Repopulates Dataset)
        ds.Clear()
        loadBiomes()
    End Sub

    ' EDITING OF CELLS + SAVES IT TO BIOMES.XML
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ' This if statement checks the index of the clicked cell, ensuring the user cannot edit header data for columns or rows
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' set 'cellValue' to current index of clicked cell
            Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            ' Edits toolstrip 
            ToolStripStatusLabel1.Text = "Editing an entry..."
            ' Inputbox collecting user input for new value
            Dim newValue As String = InputBox("Enter the new value:", "Edit Cell", cellValue.ToString())
            ' Edits toolstrip
            ToolStripStatusLabel1.Text = "Idle"
            ' ensures empty string is not taken 
            If Not String.IsNullOrEmpty(newValue) Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = newValue
                ' Call saveBiomes
                saveBiomes()
            End If
        End If
    End Sub

    ' ADDS A NEW ENTRY TO DATAGRIDVIEW + SAVES IT TO BIOMES.XML
    Private Sub NewEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEntryToolStripMenuItem.Click
        ' empty variable preparing to append to "ds" 
        Dim newRow As DataRow = ds.Tables(0).NewRow()
        ' Fills in each of the built in categories to ensure no blank space (sometimes it wigs out)
        newRow("Biome.Name") = "Biome"
        newRow("Level") = "1"
        newRow("Fauna") = "Yes"
        newRow("Flora") = "Yes"
        newRow("Metals") = "Yes"
        newRow("Woods") = "Yes"
        newRow("Fruits") = "Yes"
        ' append the row to "ds" 
        ds.Tables(0).Rows.Add(newRow)
        ' Call saveBiomes
        saveBiomes()
    End Sub

    ' ADDS A NEW CATEGORY TO DATASET AND SAVES IT TO XML WHEN A CHANGE IS MADE
    Private Sub CategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoryToolStripMenuItem.Click
        ToolStripStatusLabel1.Text = "Adding a new category..."
        Dim colInfo As String = InputBox("Enter new category: ", "Add Category")
        Dim newColumn As DataColumn = ds.Tables(0).Columns.Add(colInfo)

        saveBiomes()
        ToolStripStatusLabel1.Text = "Done."
        wait(2)
        ToolStripStatusLabel1.Text = "Idle"
    End Sub

    Private Sub XMLYAMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLYAMLToolStripMenuItem.Click
        Dim psi = New ProcessStartInfo("C:\Users\dracc\AppData\Local\Programs\Python\Python310\Python.exe", "C:\TRITON\Scripts\xty.py")
        Dim proc = Process.Start(psi)
        proc.WaitForExit()
        ToolStripStatusLabel1.Text = "Converted XML to YAML."
        saveBiomes()
        wait(2)
        ToolStripStatusLabel1.Text = "Idle"
        If proc.ExitCode <> 0 Then Throw New Exception(" Script Failed")


    End Sub

    Private Sub YAMLXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YAMLXMLToolStripMenuItem.Click
        Dim psi = New ProcessStartInfo("C:\Users\dracc\AppData\Local\Programs\Python\Python310\Python.exe", "C:\TRITON\Scripts\ytx.py")
        Dim proc = Process.Start(psi)
        proc.WaitForExit()
        ToolStripStatusLabel1.Text = "Converted YAML to XML."
        saveBiomes()
        wait(2)
        ToolStripStatusLabel1.Text = "Idle"
        If proc.ExitCode <> 0 Then Throw New Exception(" Script Failed")


    End Sub

    Private Sub QuickAddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickAddToolStripMenuItem.Click
        res_man.softLoad()
        Res_QA.Show()
    End Sub

    Private Sub DarkModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkModeToolStripMenuItem.Click
        DataGridView1.BackgroundColor = Color.Black
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gray
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.DefaultCellStyle.BackColor = Color.Black
        DataGridView1.DefaultCellStyle.ForeColor = Color.White
    End Sub

    Private Sub TriaxxarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TriaxxarToolStripMenuItem.Click
        DataGridView1.BackgroundColor = Color.Black
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red
        DataGridView1.DefaultCellStyle.BackColor = Color.Black
        DataGridView1.DefaultCellStyle.ForeColor = Color.Red
    End Sub
End Class