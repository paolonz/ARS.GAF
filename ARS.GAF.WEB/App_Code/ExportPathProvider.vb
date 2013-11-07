Imports Microsoft.VisualBasic
Imports System.Web.Hosting

Public Class ExportPathProvider
    Inherits VirtualPathProvider

    Private Function AssemblyPathExists(ByVal path As String) As Boolean
        Dim relativePath = VirtualPathUtility.ToAppRelative(path)
        Return relativePath.StartsWith("~/absolute")
    End Function

    Public Overrides Function FileExists(ByVal virtualPath As String) As Boolean
        If (AssemblyPathExists(virtualPath)) Then
            Return True
        Else
            Return MyBase.FileExists(virtualPath)
        End If
    End Function

    Public Overrides Function GetFile(ByVal virtualPath As String) As System.Web.Hosting.VirtualFile
        If (AssemblyPathExists(virtualPath)) Then
            Return New ExportFile(virtualPath)
        Else
            Return MyBase.GetFile(virtualPath)
        End If
    End Function


    Public Overrides Function GetCacheDependency(ByVal virtualPath As String, ByVal virtualPathDependencies As System.Collections.IEnumerable, ByVal utcStart As Date) As System.Web.Caching.CacheDependency
        If (AssemblyPathExists(virtualPath)) Then
            Return Nothing
        Else
            Return MyBase.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart)
        End If
    End Function

End Class
