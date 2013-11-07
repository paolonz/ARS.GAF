Imports ARS.GAF.Core
Imports System.Configuration
Imports System.Text
Imports System.Reflection

Public Class SDOExport
    Implements IExport

    Private _service As SDOExportService
    Private _repo As SDOExportRepository

    Public Function LoadUC(ByVal page As Web.UI.Page) As Web.UI.UserControl Implements Core.IExport.LoadUC
        'Return page.LoadControl(GetType(SDOExportUserControl), Nothing)
        Return page.LoadControl("~/absolute/C/Progetti/ARS.GAF/Deploy/ARS.GAF.SDO.dll/" + UserControlFullName)
    End Function

    Public Function Export(ByVal params As List(Of ExportParameter)) As Boolean Implements Core.IExport.Export
        _service = New SDOExportService()
        _repo = New SDOExportRepository("")
        Return False
    End Function

    Private _configType As Type
    Public ReadOnly Property ConfigType() As Type Implements Core.IExport.ConfigType
        Get
            Return GetType(SDOExportConfig)
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements Core.IExport.Name
        Get
            Return "SDO"
        End Get
    End Property

    Public ReadOnly Property UserControlFullName() As String Implements Core.IExport.UserControlFullName
        Get
            Return "ARS.GAF.SDO.SDOExportUserControl.ascx"
        End Get
    End Property

    Private _flussoKey As String
    Public Property FlussoKey() As String Implements Core.IExport.FlussoKey
        Get
            Return _flussoKey
        End Get
        Set(ByVal value As String)
            _flussoKey = value
        End Set
    End Property

    Private _id As String
    Public Property ID() As Integer Implements Core.IExport.ID
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private Function ParseParams(ByVal params As List(Of ExportParameter)) As SDOExportConfig
        Dim r As New SDOExportConfig

        For Each param As ExportParameter In params
            Dim prop As PropertyInfo = r.GetType().GetProperty(param.PropertyName, BindingFlags.Instance Or BindingFlags.Public)
            'prop.SetValue(mObjectInstance, newValue, BindingFlags.Instance Or BindingFlags.Public, Nothing, Nothing, Globalization.CultureInfo.CurrentUICulture)
            prop.SetValue(r, param.Value, Nothing)
            'r.GetType().InvokeMember(param.PropertyName, Reflection.BindingFlags.SetProperty, Nothing, r, param.Value)
        Next

        Return r
    End Function

End Class
