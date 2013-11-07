Imports System.Xml.Schema
Imports System.Xml

Public Class XML

    Private Shared schemaValidation As New ValidationEventHandler(AddressOf ValidationHandler)

    Private Shared Sub ValidationHandler(ByVal sender As Object, ByVal e As System.Xml.Schema.ValidationEventArgs)
        Throw e.Exception
    End Sub

    Public Shared Function Validate(ByVal xmlFile As String, ByVal xsdNamespace As String, ByVal xsdFile As String) As Boolean
        Dim result = False

        Dim schema As XmlSchemaSet = New XmlSchemaSet()
        Dim doc As XmlDocument = New XmlDocument()

        Try
            schema.Add(xsdNamespace, xsdFile)
            doc.Schemas = schema
            doc.Load(xmlFile)
            Try
                doc.Validate(schemaValidation)
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

End Class
