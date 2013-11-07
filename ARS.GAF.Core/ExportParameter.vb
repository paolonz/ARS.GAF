Public Class ExportParameter


    Private _propertyName As String
    Public Property PropertyName() As String
        Get
            Return _propertyName
        End Get
        Set(ByVal value As String)
            _propertyName = value
        End Set
    End Property


    Private _value As Object
    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal value As Object)
            _value = value
        End Set
    End Property


    Private _type As Type
    Public Property Type() As Type
        Get
            Return _type
        End Get
        Set(ByVal value As Type)
            _type = value
        End Set
    End Property



End Class
