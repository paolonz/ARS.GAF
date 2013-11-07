Imports ARS.GAF.Core
Imports System.Data.SqlClient

Public Class SDORepository
    Inherits BaseFlussoRepository

    Sub New(ByVal dbConfig As Core.DBConfig, ByVal starterConfig As Core.StarterConfig)
        MyBase.New(dbConfig, starterConfig)
    End Sub


    Function ValorizzazioneBDR() As Boolean

        Dim result As Boolean = True

        Dim conn As New SqlConnection(Me.ConnectionString)

        Try
            conn.Open()
            Dim cmd As New SqlCommand("Esec_valore_SDO", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result

    End Function

    Function PreparaGrouper() As Boolean
        Dim result As Boolean = True
        Dim conn As New SqlConnection(Me.ConnectionString)
        Try
            conn.Open()
            Dim cmd As New SqlCommand("Esec_Crea_per_grouper", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Function ControlloFormale() As Boolean
        Dim result As Boolean = True
        Dim conn As New SqlConnection(Me.ConnectionString)
        Try
            conn.Open()
            Dim cmd As New SqlCommand("Esec_controlli_formali", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 400

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Function CreaDimesso() As Boolean
        Dim result As Boolean = True
        Dim conn As New SqlConnection(Me.ConnectionString)
        Try
            conn.Open()
            Dim cmd As New SqlCommand("Esec_Crea_Dimesso", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Function ControlloIntegrita() As Boolean
        Dim result As Boolean = True
        Dim conn As New SqlConnection(Me.ConnectionString)
        Try
            conn.Open()
            Dim cmd As New SqlCommand("Esec_controlli_integr_archivi", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Function ControlloProcedura() As Boolean
        Dim result As Boolean = True
        Try

        Dim conn As New SqlConnection(Me.ConnectionString)
        Dim cmd As New SqlCommand("select * from T_Dtsok", conn)

        conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Function ControlliFormaliPostValidazione() As Boolean
        Dim result As Boolean = True

        Dim conn As New SqlConnection(Me.ConnectionString)

        Try
            conn.Open()
            Dim cmd As New SqlCommand("Esec_controlli_formali_dopo_val", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 400

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        Finally
            conn.Close()
        End Try

        Return result
    End Function

End Class
