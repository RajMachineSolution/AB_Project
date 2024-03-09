Imports System.Data.SqlClient
Public Class dbConnComponent
    Private myConn As New SqlConnection("Data Source=Desktop-Asus;Initial Catalog=admin1;Integrated Security=SSPI;")
    Private myCmd As New SqlCommand
    Private myReader As SqlDataReader
    Private ds As New DataSet
    Private da As SqlDataAdapter
    Private dt As New DataTable()
    Private results As String
    Public count1 As Integer
    Private results1 As String()
    Public Ddata(500) As Int16

    Public Sub checkdata(query As String)
        myCmd = myConn.CreateCommand()
        da = New SqlDataAdapter(myCmd)
        myCmd.CommandText = query

        myConn.Open()
        count1 = myCmd.ExecuteScalar()
        myConn.Close()
    End Sub


    Public Sub ConnectSqlServer1(query As String)

        myCmd = myConn.CreateCommand
        da = New SqlDataAdapter(myCmd)
        myCmd.CommandText = query
        myConn.Open()
        da.Fill(ds)
        myReader = myCmd.ExecuteReader()
        Do While myReader.Read()
            results = myReader.GetString(0) & vbLf

        Loop
        myReader.Close()
        myConn.Close()

        results1 = Split(results, ",")
        Dim i As Integer

        Do While i < results1.Length()
            Ddata(i) = Val(results1(i))
            i = i + 1
        Loop


    End Sub
End Class
