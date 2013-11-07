Imports Microsoft.VisualBasic

Public Class PeriodoFlussi

    Private _PeriodoID As Integer
    Public Property PeriodoID As Integer
        Get
            Return _PeriodoID
        End Get
        Set(ByVal value As Integer)
            _PeriodoID = value
        End Set
    End Property

    Private _FlussoID As Integer
    Public Property FlussoID As Integer
        Get
            Return _FlussoID
        End Get
        Set(ByVal value As Integer)
            _FlussoID = value
        End Set
    End Property

    Private _PeriodoDesc As String
    Public Property PeriodoDesc As String
        Get
            Return _PeriodoDesc
        End Get
        Set(ByVal value As String)
            _PeriodoDesc = value
        End Set
    End Property

    Private _AnnoPeriodo As String
    Public Property AnnoPeriodo As String
        Get
            Return _AnnoPeriodo
        End Get
        Set(ByVal value As String)
            _AnnoPeriodo = value
        End Set
    End Property

End Class
