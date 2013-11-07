Imports ARS.GAF.Core
Public Class SDOExportConfig
    Inherits BaseExportConfig

    Private _dateStart As DateTime
    <ExportFormParamAttribute()>
    Public Property DateStart() As DateTime
        Get
            Return _dateStart
        End Get
        Set(ByVal value As DateTime)
            _dateStart = value
        End Set
    End Property

    Private _dateEnd As DateTime
    <ExportFormParamAttribute()>
    Public Property DateEnd() As DateTime
        Get
            Return _dateEnd
        End Get
        Set(ByVal value As DateTime)
            _dateEnd = value
        End Set
    End Property



End Class
