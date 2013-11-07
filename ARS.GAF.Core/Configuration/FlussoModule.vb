Imports System.Configuration
Public Class FlussoModule
    Inherits ConfigurationElement

    <ConfigurationProperty("key", IsRequired:=True)> _
    Public ReadOnly Property Key() As String
        Get
            Return DirectCast(Me("key"), String)
        End Get

    End Property

    <ConfigurationProperty("path", IsRequired:=True)> _
    Public ReadOnly Property Path() As String
        Get
            Return DirectCast(Me("path"), String)
        End Get
    End Property

    <ConfigurationProperty("id", IsRequired:=True)> _
    Public ReadOnly Property ID() As Integer
        Get
            Return DirectCast(Me("id"), Integer)
        End Get
    End Property

End Class
