Namespace arsflussi

Public Class Docsinfo
    'La classe Docsinfo interroga il Db e rileva tutti i documenti abilitati per la lettura
    'da parte del referente collegato
    Public Function GetDocsDetails(ByVal wflusso As Integer, ByVal wtipodoc As Integer) As DataSet
        
        Dim strcomm As String = "select * from V_DocsFlussi where (progrflusso=" & wflusso & ") AND (progrtipodoc=" & wtipodoc & ")"
        Dim ds As New DataSet
        ds.DataSetName = "DSFileFlussi"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Creazione DataAdapter e relativo comando di selezione
        Dim sqlda1 As New SqlClient.SqlDataAdapter
        Dim sqlcomm1 As New SqlClient.SqlCommand

        Try
            'Mappatura(creazione colonne) dei data adapter
            sqlda1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_Docs", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("titolo", "titolo"), New System.Data.Common.DataColumnMapping("descrizione", "descrizione"), New System.Data.Common.DataColumnMapping("percorso", "percorso"), New System.Data.Common.DataColumnMapping("tipodocumento", "tipodocumento"), New System.Data.Common.DataColumnMapping("flusso", "flusso"), New System.Data.Common.DataColumnMapping("datadoc", "datadoc")})})
            sqlda1.SelectCommand = sqlcomm1
            sqlcomm1.CommandText = strcomm
            sqlcomm1.Connection = myConnection

            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            'Popolamento del Dataset
            ds.EnforceConstraints = False
            sqlda1.Fill(ds)
            ds.EnforceConstraints = True
            myConnection.Close()
            myConnection = Nothing
            Return ds
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun valore
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            sqlda1 = Nothing
            sqlcomm1 = Nothing
            Return Nothing
        End Try
    End Function
    Public Function ParamDocs() As DataSet
        'La funzione ParamDocs restituisce un dataset con memorizzati i dati per 
        'filtrare i documenti
        'Crea un nuovo dataset DSFileFlussi
        Dim ds As New DataSet
        ds.DataSetName = "DSFileFlussi"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Creazione DataAdapter e relativo comando di selezione
        Dim sqlda1 As New SqlClient.SqlDataAdapter
        Dim sqlcomm1 As New SqlClient.SqlCommand

        Try
            'Mappatura(creazione colonne) dei data adapter
            sqlda1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "T_TipiDocumento", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrtipodoc", "progrtipodoc"), New System.Data.Common.DataColumnMapping("tipodocumento", "tipodocumento")})})
            sqlda1.SelectCommand = sqlcomm1
            sqlcomm1.CommandText = "select * from T_TipiDocumento"
            sqlcomm1.Connection = myConnection

            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            'Popolamento del Dataset
            ds.EnforceConstraints = False
            sqlda1.Fill(ds)
            ds.EnforceConstraints = True
            myConnection.Close()
            myConnection = Nothing
            Return ds
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun valore
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            sqlda1 = Nothing
            sqlcomm1 = Nothing
            Return Nothing
        End Try
    End Function
    Public Function GetEventiDetails(ByVal wflusso As Integer, ByVal wtipodoc As Integer) As DataSet

        Dim strcomm As String
        strcomm = "SELECT progrevento, progrflusso, progrperiodo, evento, cartellaftp, preffile, inv" & _
        "iomail, oggettomail, testomail, dataevento, ggevento, dataini, dataend, flusso, " & _
        "periodo FROM dbo.V_EventiFlussi where (progrflusso=" & wflusso & ") AND (progrperiodo=" & wtipodoc & ") AND (dataend is null) ORDER BY dataevento DESC"

        Dim ds As New DataSet
        ds.DataSetName = "DSFileFlussi"
        'Connessione al SQL server tramite la stringa definita nel Web Config
        Dim myConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnectionString"))
        'Creazione DataAdapter e relativo comando di selezione
        Dim sqlda1 As New SqlClient.SqlDataAdapter
        Dim sqlcomm1 As New SqlClient.SqlCommand

        Try
            'Mappatura(creazione colonne) dei data adapter
            sqlda1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "V_EventiFlussi", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("progrevento", "progrevento"), New System.Data.Common.DataColumnMapping("progrflusso", "progrflusso"), New System.Data.Common.DataColumnMapping("progrperiodo", "progrperiodo"), New System.Data.Common.DataColumnMapping("evento", "evento"), New System.Data.Common.DataColumnMapping("cartellaftp", "cartellaftp"), New System.Data.Common.DataColumnMapping("preffile", "preffile"), New System.Data.Common.DataColumnMapping("inviomail", "inviomail"), New System.Data.Common.DataColumnMapping("oggettomail", "oggettomail"), New System.Data.Common.DataColumnMapping("testomail", "testomail"), New System.Data.Common.DataColumnMapping("dataevento", "dataevento"), New System.Data.Common.DataColumnMapping("ggevento", "ggevento"), New System.Data.Common.DataColumnMapping("dataini", "dataini"), New System.Data.Common.DataColumnMapping("dataend", "dataend"), New System.Data.Common.DataColumnMapping("flusso", "flusso"), New System.Data.Common.DataColumnMapping("periodo", "periodo")})})
            sqlda1.SelectCommand = sqlcomm1
            sqlcomm1.CommandText = strcomm
            sqlcomm1.Connection = myConnection

            'Apertura della connessione ed esecuzione comando
            myConnection.Open()
            'Popolamento del Dataset
            ds.EnforceConstraints = False
            sqlda1.Fill(ds)
            ds.EnforceConstraints = True
            myConnection.Close()
            myConnection = Nothing
            Return ds
        Catch ex As Exception
            'In caso di errore durante la procedura chiude la connessione e 
            'tutti gli oggetti, non viene restituito alcun valore
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            myConnection = Nothing
            sqlda1 = Nothing
            sqlcomm1 = Nothing
            Return Nothing
        End Try
    End Function
End Class

End Namespace
