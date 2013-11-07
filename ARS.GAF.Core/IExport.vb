Imports System.Web.UI

Public Interface IExport
    Property ID As Integer
    Property FlussoKey As String
    Function LoadUC(ByVal page As Page) As UserControl
    ReadOnly Property Name As String
    ReadOnly Property UserControlFullName As String
    Function Export(ByVal params As List(Of ExportParameter)) As Boolean
    ReadOnly Property ConfigType As Type
End Interface
