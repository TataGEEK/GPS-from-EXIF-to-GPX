Option Explicit On
Option Strict On

Module modGPSCoordinate
    Public Function GetGPSCoordinates(ByVal inPathFileName As String, ByRef outLatitude As Double, ByRef outLongitude As Double) As Boolean
        'Credits:
        'Source: http://www.vbforums.com/showthread.php?607979-Read-EXIF-Lat-Long
        'Coder: http://www.vbforums.com/member.php?108182-sustainblue

        Dim byte_property_id As Byte()
        Dim ascii_string_property_id As String
        Dim prop_type As String
        Dim selected_image As System.Drawing.Bitmap
        Dim property_ids() As Integer
        Dim scan_property As Integer
        Dim counter As Integer
        Dim degrees As Double
        Dim minutes As Double
        Dim seconds As Double
        Dim lat_dd As Double
        Dim long_dd As Double

        selected_image = New System.Drawing.Bitmap(inPathFileName)
        property_ids = selected_image.PropertyIdList
        For Each scan_property In property_ids
            counter = counter + 1
            byte_property_id = selected_image.GetPropertyItem(scan_property).Value
            prop_type = selected_image.GetPropertyItem(scan_property).Type.ToString
            If scan_property = 1 Then
                'Latitude North or South
                ascii_string_property_id = System.Text.Encoding.ASCII.GetString(byte_property_id)

            ElseIf scan_property = 2 Then
                'Latitude degrees minutes and seconds (rational)
                degrees = System.BitConverter.ToInt32(byte_property_id, 0) / System.BitConverter.ToInt32(byte_property_id, 4)
                minutes = System.BitConverter.ToInt32(byte_property_id, 8) / System.BitConverter.ToInt32(byte_property_id, 12)
                seconds = System.BitConverter.ToInt32(byte_property_id, 16) / System.BitConverter.ToInt32(byte_property_id, 20)

                lat_dd = degrees + (minutes / 60) + (seconds / 3600)

            ElseIf scan_property = 3 Then
                'Longitude East or West
                ascii_string_property_id = System.Text.Encoding.ASCII.GetString(byte_property_id)

            ElseIf scan_property = 4 Then
                'Longitude degrees minutes and seconds (rational)
                degrees = System.BitConverter.ToInt32(byte_property_id, 0) / System.BitConverter.ToInt32(byte_property_id, 4)
                minutes = System.BitConverter.ToInt32(byte_property_id, 8) / System.BitConverter.ToInt32(byte_property_id, 12)
                seconds = System.BitConverter.ToInt32(byte_property_id, 16) / System.BitConverter.ToInt32(byte_property_id, 20)
                long_dd = degrees + (minutes / 60) + (seconds / 3600)

            ElseIf scan_property = 18 Then
                'Datum used at GPS acquisition (ascii)
                ascii_string_property_id = System.Text.Encoding.ASCII.GetString(byte_property_id)

            ElseIf scan_property = 24 Then
                'Magnetic bearing of subject to photographer (rational)
            End If

        Next scan_property

        outLatitude = lat_dd
        outLongitude = long_dd
        Return True
    End Function
End Module
