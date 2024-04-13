' thanks jamesplotts - well done ---> http://www.xtremevbtalk.com/showthread.php?t=323743  post number 8
Imports System.Data
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Threading


Public Class Perlin
    Private ReadOnly bytes As Byte()
    Private dweight1 As Double
    Private dweight2 As Double
    Private dweight4 As Double
    Private dweight8 As Double
    Private dweight16 As Double
    Private dweight32 As Double
    Private dweight64 As Double
    Private pvtExpo As Double = 1, pvtFactor As Double = 1
    Private ReadOnly stat As Integer(,)
    Private ReadOnly pvtWidth As Int32 = 250
    Private ReadOnly pvtHeight As Int32 = 250
    Private pvtFinalImage As Bitmap
    Private RecalcRunning As Boolean
    Private Resetting As Boolean

    Dim pvtWeight1Value As Int32 = Terrain_Sim.NumericUpDown1.Value
    Dim pvtWeight2Value As Int32 = Terrain_Sim.NumericUpDown2.Value
    Dim pvtWeight4Value As Int32 = Terrain_Sim.NumericUpDown3.Value
    Dim pvtWeight8Value As Int32 = Terrain_Sim.NumericUpDown4.Value
    Dim pvtWeight16Value As Int32 = Terrain_Sim.NumericUpDown5.Value
    Dim pvtWeight32Value As Int32 = Terrain_Sim.NumericUpDown6.Value
    Dim pvtWeight64Value As Int32 = Terrain_Sim.NumericUpDown7.Value

    Public Sub New(ByVal Width As Int32, ByVal Height As Int32)
        If Width < 0 OrElse Height < 0 Then Throw New Exception("Parameter out of bounds - cannot be negative value.")
        pvtWidth = Width
        pvtHeight = Height
        RecalcRunning = False
        stat = New Integer(pvtWidth - 1, pvtHeight - 1) {}
        bytes = New Byte(pvtWidth * pvtHeight * 4 - 1) {}
        RedrawStaticMap()
    End Sub

    Public Sub RestoreDefaults()
        Resetting = True
        While RecalcRunning
            Thread.Sleep(0)
        End While
        pvtWeight1Value = 1
        pvtWeight2Value = 2
        pvtWeight4Value = 10
        pvtWeight8Value = 25
        pvtWeight16Value = 40
        pvtWeight32Value = 48
        pvtWeight64Value = 50
        pvtExpo = 1
        pvtFactor = 1
        Resetting = False
        RedrawStaticMap()
    End Sub


    Public Sub RedrawStaticMap()
        Dim rndNum As Random = New Random
        Dim c As Integer

        For y As Integer = 0 To pvtHeight - 1
            For x As Integer = 0 To pvtWidth - 1
                c = rndNum.Next(255)
                stat(x, y) = c
            Next
        Next
        Recalc()
    End Sub


    Public Sub Recalc()
        If Resetting Then Exit Sub
        RecalcRunning = True
        Dim sum As Double = 0
        sum += pvtWeight1Value
        sum += pvtWeight2Value
        sum += pvtWeight4Value
        sum += pvtWeight8Value
        sum += pvtWeight16Value
        sum += pvtWeight32Value
        sum += pvtWeight64Value
        If sum = 0 Then
            Return
        End If
        dweight1 = pvtWeight1Value / sum
        dweight2 = pvtWeight2Value / sum
        dweight4 = pvtWeight4Value / sum
        dweight8 = pvtWeight8Value / sum
        dweight16 = pvtWeight16Value / sum
        dweight32 = pvtWeight32Value / sum
        dweight64 = pvtWeight64Value / sum

        Dim bmp As New Bitmap(pvtWidth, pvtHeight)
        '  Execute parallel threads for all the row calculations of the heightfield.
        'old line - i created a new one without the -1
        'System.Threading.Tasks.Parallel.[For](0, pvtHeight - 1, New Action(Of Integer)(AddressOf CalcRow))
        System.Threading.Tasks.Parallel.[For](0, pvtHeight, New Action(Of Integer)(AddressOf CalcRow))
        Dim data As BitmapData = bmp.LockBits(New Rectangle(0, 0, pvtWidth, pvtHeight),
             System.Drawing.Imaging.ImageLockMode.[WriteOnly], System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        System.Runtime.InteropServices.Marshal.Copy(bytes, 0, data.Scan0, data.Stride * data.Height)
        bmp.UnlockBits(data)
        pvtFinalImage = bmp
        RecalcRunning = False
    End Sub

    Private Sub CalcRow(ByVal y As Integer)
        For x As Integer = 0 To pvtWidth - 1
            Dim c As Double = 0
            c += GetPixel(x / 64.0, y / 64.0) * dweight64
            c += GetPixel(x / 32.0, y / 32.0) * dweight32
            c += GetPixel(x / 16.0, y / 16.0) * dweight16
            c += GetPixel(x / 8.0, y / 8.0) * dweight8
            c += GetPixel(x / 4.0, y / 4.0) * dweight4
            c += GetPixel(x / 2.0, y / 2.0) * dweight2
            c += GetPixel(x, y) * dweight1
            bytes(4 * (x + pvtWidth * y) + 3) = 255
            bytes(4 * (x + pvtWidth * y) + 0) = CByte(Math.Truncate(Math.Min(255, Math.Max(0, (255 * pvtFactor * Math.Pow(c / 255, pvtExpo))))))
            bytes(4 * (x + pvtWidth * y) + 1) = CByte(Math.Truncate(Math.Min(255, Math.Max(0, (255 * pvtFactor * Math.Pow(c / 255, pvtExpo))))))
            bytes(4 * (x + pvtWidth * y) + 2) = CByte(Math.Truncate(Math.Min(255, Math.Max(0, (255 * pvtFactor * Math.Pow(c / 255, pvtExpo))))))
        Next
    End Sub

    Private Function GetPixel(ByVal x As Double, ByVal y As Double) As Double
        Dim ix As Double = Math.Floor(x)
        Dim iy As Double = Math.Floor(y)
        Dim fx As Double = x - ix
        Dim fy As Double = y - iy
        Dim ol As Double = 0, [or] As Double = 0, ul As Double = 0, ur As Double = 0
        ol = stat(CInt(Math.Truncate(ix)), CInt(Math.Truncate(iy)))
        If fx <> 0 Then
            [or] = stat(CInt(Math.Truncate(ix)) + 1, CInt(Math.Truncate(iy)))
        End If
        If fy <> 0 Then
            ul = stat(CInt(Math.Truncate(ix)), CInt(Math.Truncate(iy)) + 1)
        End If
        If fx <> 0 AndAlso fy <> 0 Then
            ur = stat(CInt(Math.Truncate(ix)) + 1, CInt(Math.Truncate(iy)) + 1)
        End If
        Return (1 - fy) * ((1 - fx) * ol + fx * [or]) + fy * (((1 - fx) * ul + fx * ur))
    End Function

    Public ReadOnly Property HeightValue(ByVal X As Int32, ByVal Y As Int32) As Int32
        Get
            If X < 0 OrElse X > pvtWidth - 1 OrElse Y < 0 OrElse Y > pvtHeight - 1 Then Throw New IndexOutOfRangeException()
            If pvtFinalImage Is Nothing Then RestoreDefaults()
            Return CInt(pvtFinalImage.GetPixel(X, Y).GetBrightness * 256)
        End Get
    End Property

    Public ReadOnly Property FinalImage() As Image
        Get
            If pvtFinalImage Is Nothing Then RestoreDefaults()
            Return pvtFinalImage
        End Get
    End Property

    Public ReadOnly Property Width() As Int32
        Get
            Return pvtWidth
        End Get
    End Property

    Public ReadOnly Property Height() As Int32
        Get
            Return pvtHeight
        End Get
    End Property

    Public Property Weight1() As Int32
        Get
            Return pvtWeight1Value
        End Get
        Set(ByVal value As Int32)
            If value < 1 OrElse value > 100 Then Throw New Exception("Value not in a range of 1-100.")
            pvtWeight1Value = value
            Recalc()
        End Set
    End Property

    Public Property Weight2() As Int32
        Get
            Return pvtWeight2Value
        End Get
        Set(ByVal value As Int32)
            If value < 1 OrElse value > 100 Then Throw New Exception("Value not in a range of 1-100.")
            pvtWeight2Value = value
            Recalc()
        End Set
    End Property

    Public Property Weight4() As Int32
        Get
            Return pvtWeight4Value
        End Get
        Set(ByVal value As Int32)
            If value < 1 OrElse value > 100 Then Throw New Exception("Value not in a range of 1-100.")
            pvtWeight4Value = value
            Recalc()
        End Set
    End Property

    Public Property Weight8() As Int32
        Get
            Return pvtWeight8Value
        End Get
        Set(ByVal value As Int32)
            If value < 1 OrElse value > 100 Then Throw New Exception("Value not in a range of 1-100.")
            pvtWeight8Value = value
            Recalc()
        End Set
    End Property

    Public Property Weight16() As Int32
        Get
            Return pvtWeight16Value
        End Get
        Set(ByVal value As Int32)
            If value < 1 OrElse value > 100 Then Throw New Exception("Value not in a range of 1-100.")
            pvtWeight16Value = value
            Recalc()
        End Set
    End Property

    Public Property Weight32() As Int32
        Get
            Return pvtWeight32Value
        End Get
        Set(ByVal value As Int32)
            If value < 1 OrElse value > 100 Then Throw New Exception("Value not in a range of 1-100.")
            pvtWeight32Value = value
            Recalc()
        End Set
    End Property

    Public Property Weight64() As Int32
        Get
            Return pvtWeight64Value
        End Get
        Set(ByVal value As Int32)
            If value < 1 OrElse value > 100 Then Throw New Exception("Value not in a range of 1-100.")
            pvtWeight64Value = value
            Recalc()
        End Set
    End Property

End Class

