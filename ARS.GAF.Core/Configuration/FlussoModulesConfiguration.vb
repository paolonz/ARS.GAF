Imports System.Configuration
Public Class FlussoModulesConfiguration
    Inherits ConfigurationSection

    <ConfigurationProperty("modules")> _
    Public ReadOnly Property Modules() As FlussoModuleConfigurationCollection
        Get
            Return DirectCast(Me("modules"), FlussoModuleConfigurationCollection)
        End Get
    End Property


End Class
