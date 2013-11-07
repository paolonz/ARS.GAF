Imports System.Configuration
Imports System.IO
Public Class ModuleLoader

    Public ReadOnly Section As FlussoModulesConfiguration


    Sub New()
        Section = DirectCast(ConfigurationManager.GetSection("flussoModuleConfiguration"), FlussoModulesConfiguration)
    End Sub


    Function GetModules() As FlussoModuleConfigurationCollection
        Return Section.Modules
    End Function

    Function GetModule(ByVal id As Integer) As FlussoModule
        Return Section.Modules.GetByID(id)
    End Function

    Function GetDeclaredModuleKeys() As String()
        If (Section Is Nothing) Then
            Return New String(1) {}
        Else
            Return Section.Modules.AllKeys
        End If
    End Function

    Function LoadStreamResource(ByVal moduleKey As String, ByVal name As String) As Stream
        Dim path As String = GetLibraryPathForModule(moduleKey)

        Dim a As System.Reflection.Assembly
        Try
            a = System.Reflection.Assembly.LoadFrom(path)
        Catch ex As Exception
            Return Nothing
        End Try
        Return a.GetManifestResourceStream(String.Format("{0}.{1}", a.GetName(), name))
    End Function

    Function GetLibraryPathForModule(ByVal moduleKey As String) As String
        Dim r As FlussoModule = Section.Modules.GetByKey(moduleKey)
        If (r Is Nothing) Then
            Return String.Empty
        End If
        Return r.Path
    End Function

    Function LoadExport(ByVal moduleKey As String, ByRef fullName As String, ByRef fullPath As String, ByRef name As String
) As IExport
        Dim path As String = GetLibraryPathForModule(moduleKey)

        Dim a As System.Reflection.Assembly

        Try
            a = System.Reflection.Assembly.LoadFrom(path)
        Catch ex As Exception
            fullName = "Not found"
            name = ""
            fullPath = ""
            Return Nothing
        End Try

        fullName = a.FullName
        name = a.ManifestModule.Name
        fullPath = a.Location

        Dim iType As Type = GetType(IExport)
        Dim clsType As Type = a.GetTypes().FirstOrDefault(Function(p) iType.IsAssignableFrom(p))

        If (clsType Is Nothing) Then
            Return Nothing
        End If

        Dim clsInstance As IExport = DirectCast(Activator.CreateInstance(clsType), IExport)

        If (clsInstance Is Nothing) Then
            Throw New Exception(String.Format("Impossibile caricare {0} da {1}", moduleKey, path))
        End If

        Dim currentFlusso As FlussoModule = Section.Modules.GetByKey(moduleKey)

        clsInstance.FlussoKey = moduleKey
        clsInstance.ID = currentFlusso.ID

        Return clsInstance


    End Function

    


    Function LoadFlusso(ByVal moduleKey As String, ByRef fullName As String) As IFlusso
        Dim path As String = GetLibraryPathForModule(moduleKey)

        Dim a As System.Reflection.Assembly

        Try
            a = System.Reflection.Assembly.LoadFrom(path)
        Catch ex As Exception
            fullName = "Not found"
            Return Nothing
        End Try

        fullName = a.FullName

        Dim iType As Type = GetType(IFlusso)
        Dim clsType As Type = a.GetTypes().FirstOrDefault(Function(p) iType.IsAssignableFrom(p))

        If (clsType Is Nothing) Then
            Return Nothing
        End If

        Dim clsInstance As IFlusso = DirectCast(Activator.CreateInstance(clsType), IFlusso)

        If (clsInstance Is Nothing) Then
            Throw New Exception(String.Format("Impossibile caricare {0} da {1}", moduleKey, path))
        End If

        Dim currentFlusso As FlussoModule = Section.Modules.GetByKey(moduleKey)

        clsInstance.FlussoKey = moduleKey
        clsInstance.ID = currentFlusso.ID

        Return clsInstance


    End Function

    Function LoadExportUC(ByVal moduleKey As String, ByVal fullName As String) As IExportUserControl

        Dim path As String = GetLibraryPathForModule(moduleKey)

        Dim a As System.Reflection.Assembly

        Try
            a = System.Reflection.Assembly.LoadFrom(path)
        Catch ex As Exception
            fullName = "Not found"
            Return Nothing
        End Try

        fullName = a.FullName

        'Dim objTemp As Object = objAsm.CreateInstance("WebGUIControlLibrary.UserControl1")
        'Dim objUserControl As Gizmox.WebGUI.Forms.UserControl = TryCast(objTemp, Gizmox.WebGUI.Forms.UserControl)

        'If objUserControl IsNot Nothing Then
        'Me.Controls.Add(objUserControl)
        'End If

        Dim iType As Type = GetType(IExportUserControl)
        Dim clsType As Type = a.GetTypes().FirstOrDefault(Function(p) iType.IsAssignableFrom(p))

        If (clsType Is Nothing) Then
            Return Nothing
        End If

        Dim clsInstance As IExportUserControl = DirectCast(Activator.CreateInstance(clsType), IExportUserControl)

        If (clsInstance Is Nothing) Then
            Throw New Exception(String.Format("Impossibile caricare {0} da {1}", moduleKey, path))
        End If


        Return clsInstance



    End Function

End Class
