Imports System.Configuration
Public Class FlussoModuleConfigurationCollection
    Inherits ConfigurationElementCollection

    Public ReadOnly Property AllKeys() As String()
        Get
            Return BaseGetAllKeys().Select(Function(k) DirectCast(k, String)).ToArray()
        End Get
    End Property

    Public Overloads Property Item(ByVal index As Integer) As FlussoModule
        Get
            Return DirectCast(Me.BaseGet(index), FlussoModule)
        End Get
        Set(ByVal value As FlussoModule)
            If (Not Me.BaseGet(index) Is Nothing) Then
                Me.BaseRemoveAt(index)
            End If
            Me.BaseAdd(index, value)
        End Set
    End Property


    Public ReadOnly Property GetByID(ByVal id As Integer) As FlussoModule
        Get
            For Each item As FlussoModule In Me
                If (item.ID.Equals(id)) Then
                    Return item
                End If
            Next
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property GetByKey(ByVal key As String) As FlussoModule
        Get
            Return DirectCast(Me.BaseGet(key), FlussoModule)
        End Get
    End Property



    Protected Overloads Overrides Function CreateNewElement() As System.Configuration.ConfigurationElement
        Return New FlussoModule()
    End Function

    Protected Overrides Function GetElementKey(ByVal element As System.Configuration.ConfigurationElement) As Object
        Return DirectCast(element, FlussoModule).Key
    End Function
End Class
