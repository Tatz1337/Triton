Imports System.IO


Public Class Form1

    Public Sub WriteData(ByVal strData As String, ByVal dir As String, ByVal path As String, ByVal append As Boolean)
        ' check dir
        If Not (System.IO.Directory.Exists(dir)) Then
            System.IO.Directory.CreateDirectory(dir)
        End If

        Dim objReader As System.IO.StreamWriter
        Try
            objReader = New System.IO.StreamWriter(path, append)
            objReader.Write("Time: " & Now() & " LOG: " & strData & vbCrLf)
            objReader.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WriteData("TRITON Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub BiomeManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiomeManagerToolStripMenuItem.Click
        biome_manager.Show()
        WriteData("Biome Manager Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub FleetManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FleetManagerToolStripMenuItem.Click
        fleet_manager.Show()
        WriteData("Fleet Manager Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub GDPCalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GDPCalculatorToolStripMenuItem.Click
        gdp_calc.Show()
        WriteData("GDP Calculator Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub BiomeFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiomeFileToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub ChangelogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangelogToolStripMenuItem.Click
        changelog.Show()
        WriteData("Changelog Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub CouncilSimulatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CouncilSimulatorToolStripMenuItem.Click
        council_sim.Show()
        WriteData("Council Simulator Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        mapBeta.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        res_man.Show()
        WriteData("Resource Manager Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub ShipDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShipDatabaseToolStripMenuItem.Click
        Ship_DB.Show()
        WriteData("Ship Parts Manager Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditsToolStripMenuItem.Click
        WriteData("Credits Shown", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
        MessageBox.Show("VBForums User: boops boops - For their Map Code!" & Environment.NewLine & "VBForums User: deuce1 for sharing their Terrain Generator!")
    End Sub

    Private Sub TerrainSimulatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerrainSimulatorToolStripMenuItem.Click
        Terrain_Sim.Show()
        WriteData("Terrain Simulator Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub FactionSimulatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FactionSimulatorToolStripMenuItem.Click
        WriteData("Faction Simulator Started", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
        Faction_Sim.Show()
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        WriteData("Triton Exiting Properly", "C:\TRITON\Logs", "C:\TRITON\LOGS\Log.txt", True)
    End Sub

    Private Sub TextToMorseConverterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextToMorseConverterToolStripMenuItem.Click
        TTMC.Show()
    End Sub
End Class
