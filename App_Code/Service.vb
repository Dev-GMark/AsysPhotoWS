Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
     Inherits System.Web.Services.WebService
    Private resp As New Response
    <WebMethod()> _
    Public Function ReceiveFile(ByVal _file As String, ByVal _filename As String) As Response
        '

        Try
            Dim path As String = ConfigurationManager.AppSettings("targetfolder").ToString

            
            ConvertToFile(_file, path & _filename)

            resp.respCode = 0
            resp.message = "Successfully send photo"

        Catch ex As Exception
            resp.respCode = 1
            resp.message = ex.Message
        End Try
        Return resp
    End Function
    Private Sub ConvertToFile(ByVal _file As String, ByVal _filename As String)
        'Try
        Dim data As String = _file
        Dim filename As String = _filename

        ConvertBytesToImageFile(StringToByte(data), _filename)


        'Catch ex As Exception
        '    resp.respCode = 1
        '    resp.message = ex.Message
        'End Try
    End Sub
    Private Sub ConvertBytesToImageFile(ByVal ImageData As Byte(), ByVal FilePath As String)
        If IsNothing(ImageData) = True Then
           End If
        'Try
        Dim fs As IO.FileStream = New IO.FileStream(FilePath, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
        Dim bw As IO.BinaryWriter = New IO.BinaryWriter(fs)
        bw.Write(ImageData)
        bw.Flush()
        bw.Close()
        fs.Close()
        bw = Nothing
        fs.Dispose()
        'Return Result.Success
        'Catch ex As Exception
        '    'Return Result.Failure
        'End Try
    End Sub
    Public Shared Function StringToByte(ByVal str As String) As Byte()
        Dim mb() As Byte = Convert.FromBase64String(str)
        Return mb
    End Function 'StrToByteArray
End Class
