Imports System.Text
Public Class CharUserControl1
    Private ObjComponent1 As New dbConnComponent
    Private intStartAt As Integer
    Private intConsecutiveNumber As Integer
    Private intSerialNumber As Integer
    Private chrstr1 As String
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Public Sub CharDatashowInLabel()
        Dim strnumb As String


        Dim query2 As String = "Select [Serialno ] from D1000 where [serialno ] = '" & intSerialNumber & "'"
        ObjComponent1.checkdata(query2)

        If ObjComponent1.count1 <> 0 Then
            Dim query1 As String = "select [D] from D1000 where [serialno] = '" & intSerialNumber & "'"

            ObjComponent1.ConnectSqlServer1(query1)
            Dim i As Integer

            chrstr1 = Nothing
            For i = 0 To intConsecutiveNumber - 1

                strnumb = ObjComponent1.Ddata(intStartAt + i)
                convertNumbtochar(strnumb)

            Next i


        End If
        Label1.Text = chrstr1

    End Sub
    Public Sub convertNumbtochar(strnumb As String)

        Dim unsignedvalue As Integer
        Dim hexValue As String
        Dim firstChar, secondChar As Char



        unsignedvalue = Val(Trim(strnumb))
        hexValue = unsignedvalue.ToString("X")
        'If hexValue < 4 Then
        '    hexValue.PadLeft(4, "0")
        'End If
        Console.WriteLine($"strarrnumb {strnumb}")
        Console.WriteLine($"hex: {hexValue}")

        If hexValue.Length Mod 2 = 0 Then
            For j = 0 To hexValue.Length - 1 Step 2

                firstChar = ChrW(CInt("&H" & hexValue.Substring(j, 2)))
                chrstr1 = chrstr1 & firstChar

                Console.WriteLine("First character: " & firstChar)
                Console.WriteLine($"strchar = {chrstr1}")
            Next

        Else
            Dim j As Integer
            For j = 0 To hexValue.Length - 2 Step 2

                firstChar = ChrW(CInt("&H" & hexValue.Substring(j, 2)))
                'secondChar = ChrW(CInt("&H" & hexValue.Substring(2, 2)))
                chrstr1 = chrstr1 & firstChar

                Console.WriteLine("First character: " & firstChar)
            Next

            If j = hexValue.Length - 1 Then
                firstChar = ChrW(CInt("&H" & hexValue.Substring(j, 1)))
                chrstr1 = chrstr1 & firstChar
                Console.WriteLine("firstCharcter: " & firstChar)
            End If

        End If



    End Sub

    Public Property M() As Integer
        Get
            Return intStartAt
        End Get
        Set(value As Integer)
            intStartAt = value
        End Set
    End Property

    Public Property N() As Integer
        Get
            Return intConsecutiveNumber
        End Get
        Set(value As Integer)
            intconsecutiveNumber = value
        End Set
    End Property
    Public Property SerialNumber() As Integer
        Get
            Return intSerialNumber
        End Get
        Set(value As Integer)
            intSerialNumber = value
        End Set
    End Property



End Class
