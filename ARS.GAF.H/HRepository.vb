Imports ARS.GAF.Core

Public Class HRepository
    Inherits BaseFlussoRepository

    Sub New(ByVal dbConfig As Core.DBConfig, ByVal starterConfig As Core.StarterConfig)
        MyBase.New(dbConfig, starterConfig)
    End Sub

End Class
