Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Text


Namespace arsflussi

'La classe Security cripta e decripta la stringa che viene passata dal programma
Public Class Security
    'Costante da utilizzare per la chiave privata
    Const sKey As String = "FlussiKey"
    Public Shared Function Encrypt(ByVal cleanString As String) As String
        'Servizio di criptografia
        Dim DES As New TripleDESCryptoServiceProvider
        'Tipo di criptografia
        Dim hashMD5 As New MD5CryptoServiceProvider

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the encryptor.
        Dim DESEncrypt As ICryptoTransform = DES.CreateEncryptor()
        ' Get a byte array of the string.
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(cleanString)
        ' Transform and return the string.
        Return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    Public Shared Function Decrypt(ByVal hashedText As String) As String
        'Servizio di decriptografia
        Dim DES As New TripleDESCryptoServiceProvider
        'Tipo di criptografia
        Dim hashMD5 As New MD5CryptoServiceProvider

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the decryptor.
        Dim DESDecrypt As ICryptoTransform = DES.CreateDecryptor()
        Dim Buffer As Byte() = Convert.FromBase64String(hashedText)
        ' Transform and return the string.
        Return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
End Class

End Namespace
