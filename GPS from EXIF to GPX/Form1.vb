Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class Form1

    Private Sub DataGridView1_DragEnter(sender As Object, e As DragEventArgs) Handles DataGridView1.DragEnter
        'SET THE PROPER ACTION FOR FILE DROP....BY USING THE FILEDROP METHOD TO COPY
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub DataGridView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DataGridView1.DragDrop

        'zpravujeme vložené soubory
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each filePath As String In filePaths

                'vložíme soubory
                Dim obj_openfile As New OpenFileDialog With {
                    .FileName = filePath
                }
                With obj_openfile
                    .Filter = "Image Files (*.jpg)|*.jpg|All Files (*.*)|*.*"
                    .FilterIndex = 1
                    .Title = "Open Image File"
                    .Multiselect = True
                End With

                'získáme souřadnice
                Dim Lat As Double = 0, Lng As Double = 0
                GetGPSCoordinates(obj_openfile.FileName, Lat, Lng)

                'zapíšeme do DataGridView
                Dim rowId As Integer = DataGridView1.Rows.Add()
                Dim row As DataGridViewRow = DataGridView1.Rows(rowId)
                row.Cells("Filename").Value = filePath
                row.Cells("Latitude").Value = Format(Lat, "#.######")
                row.Cells("Longitude").Value = Format(Lng, "#.######")

            Next filePath
        End If
    End Sub

    Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        'vypočítáme poměr velikostí stran
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If

        'vytvoříme prázdnou bitmapu
        Dim newImage As Image = New Bitmap(newWidth, newHeight)

        'vykreslíme nový obrázek
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage


    End Function

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If Not IsNothing(DataGridView1.CurrentRow.Cells("Filename").Value) Then
            Dim original As Image = Image.FromFile(DataGridView1.CurrentRow.Cells(0).Value)
            Dim resized As Image = ResizeImage(original, New Size(400, 400))
            Dim memStream As MemoryStream = New MemoryStream()
            resized.Save(memStream, ImageFormat.Jpeg)

            PictureBox1.Image = New Bitmap(resized)

        End If
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If (DataGridView1.SelectedRows.Count > 0) Then
            DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        End If

    End Sub

    Private Sub Export_Click(sender As Object, e As EventArgs) Handles Export.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then

            Dim fPath = FolderBrowserDialog1.SelectedPath & "\OSM_waypoints.gpx"
            Dim GPXfile As New IO.StreamWriter(fPath, True)
            GPXfile.WriteLine("<?xml version=""1.0"" standalone=""yes""?>")
            GPXfile.WriteLine("<gpx creator = ""EXIF Info reader"" version=""1.0"">")

            Dim colcount As Integer = DataGridView1.Columns.Count - 1
            Dim Lat As String
            Dim Lon As String

            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                Lat = DataGridView1.Rows.Item(i).Cells("Latitude").Value
                Lon = DataGridView1.Rows.Item(i).Cells("Longitude").Value

                GPXfile.WriteLine("<wpt lat = """ & Lat.Replace(",", ".") & """ lon = """ & Lon.Replace(",", ".") & """><name>" & DataGridView1.Rows.Item(i).Cells("WaypointName").Value & "</name></wpt>")
            Next

            GPXfile.Close()

        End If


    End Sub

End Class