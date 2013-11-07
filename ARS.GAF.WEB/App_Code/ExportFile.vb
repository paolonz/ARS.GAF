Imports Microsoft.VisualBasic
Imports System.Web.Hosting
Imports System.IO

Public Class ExportFile
    Inherits VirtualFile

    Sub New(ByVal virtualPath As String)
        MyBase.New(virtualPath)
        Path = VirtualPathUtility.ToAppRelative(virtualPath)
        If (Path.StartsWith("~/absoluteresource")) Then

        Else
            Path = Path.Substring(11)
            Type = "FILE"
        End If
    End Sub

    Private _path As String
    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property


    Private _type As String
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property


    Public Overrides Function Open() As System.IO.Stream
        'If (Type = "FILE") Then
        'Return LoadFile()
        'End If
        Return LoadResource()


    End Function

    Function LoadFile() As System.IO.Stream
        Dim strs As String() = Path.Split("/")
        Dim dllPath As String = ""
        Dim i As Integer = 0
        For Each value As String In strs
            i = i + 1
                If (i = 1) Then
                    dllPath = value + ":"
                Else
                    dllPath = dllPath + "/" + value
                End If
        Next
        Return System.IO.File.OpenRead(dllPath)
    End Function

    Function LoadResource() As System.IO.Stream
        Dim strs As String() = Path.Split("/")
        Dim dllPath As String = ""
        Dim resourceName As String = ""
        Dim i As Integer = 0
        For Each value As String In strs
            i = i + 1
            If (i = strs.Length) Then
                resourceName = value
            Else
                If (i = 1) Then
                    dllPath = value + ":"
                Else
                    dllPath = dllPath + "/" + value
                End If
            End If
        Next

        Dim assembly As Reflection.Assembly = Reflection.Assembly.Load(File.ReadAllBytes(dllPath))
        If (Not assembly Is Nothing) Then
            Dim a As String() = assembly.GetManifestResourceNames()

            For Each item As String In a
                Console.WriteLine(item)
            Next

            Dim typ As Type = assembly.GetType("ARS.GAF.SDO.SDOExportUserControl")

            Dim o = Activator.CreateInstance(typ)


            Dim s As Stream = assembly.GetManifestResourceStream(resourceName)
            Return s
        End If
        Return Nothing
    End Function

End Class
