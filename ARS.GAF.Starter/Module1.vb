Imports ARS.GAF.Core
Imports System.Configuration

Module Module1

    Sub Main()

        Dim cs As String = ConfigurationManager.ConnectionStrings("CS").ConnectionString
        Dim config = GetStarterConfig()
        Dim DataRepo As New DataRepository(cs, config)

        Dim loader As ModuleLoader = New ModuleLoader()

        Dim lstAttivita As List(Of Attivita) = DataRepo.GetAttivitaDaValidare()

        For Each Attivita As Attivita In lstAttivita
            Dim configFlusso As FlussoModule = loader.GetModule(Attivita.Flusso.ID)
            Dim fullNameDll As String = String.Empty
            Dim currentFlusso As IFlusso = loader.LoadFlusso(configFlusso.Key, fullNameDll)
            currentFlusso.StarterConfig = config
            Dim controllo As Controllo = DataRepo.GetControllo(currentFlusso.ID, Attivita.Periodo.ID)

            If (Not controllo Is Nothing) Then
                currentFlusso.Controllo = controllo

                currentFlusso.Init()

                If (currentFlusso.Controlla(Attivita)) Then
                    DataRepo.AggiornaAgenda(Attivita)
                End If
            Else

            End If
        Next
        Console.ReadLine()

    End Sub

    Function GetStarterConfig() As StarterConfig
        Dim starter As New StarterConfig()
        starter.SevenZipDllPath = ConfigurationManager.AppSettings("7ZipLocation")
        starter.FtpFolderPath = ConfigurationManager.AppSettings("FtpFolderPath")
        starter.XsdFolderPath = ConfigurationManager.AppSettings("XsdFolderPath")
        starter.ResocontoPath = ConfigurationManager.AppSettings("ResocontoPath")
        Return starter
    End Function



End Module
