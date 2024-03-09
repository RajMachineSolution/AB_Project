Public Class DUserControl1

    Private intStartAt As Integer
    Private intConsecutiveNumber As Integer
    Private intSerialNumber As Integer
    Private intdecimalPlace As Integer
    Private ObjComponent1 As New dbConnComponent
    Private UConnectCompo As String
    Private decimalNumber As String


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Public Sub ShowDataInLabel()
        Dim value1 As String
        Dim intdecimalNumber1 As Decimal
        Dim strdecimalNumber As String
        Dim query2 As String = "Select [Serialno ] from D1000 where [serialno ] = '" & intSerialNumber & "'"
        ObjComponent1.checkdata(query2)

        If ObjComponent1.count1 <> 0 Then
            Dim query1 As String = "select [D] from D1000 where [serialno] = '" & intSerialNumber & "'"

            ObjComponent1.ConnectSqlServer1(query1)
            Dim i As Integer

            value1 = Nothing
            value1 = ObjComponent1.Ddata(StartAt)
            'Do While i < intConsecutiveNumber
            '    value1 = value1 & vbTab & ObjComponent1.Ddata(StartAt + i) & ",  "
            '    i = i + 1
            'Loop

        End If
        intdecimalNumber1 = Decimal.Parse(value1)
        If intdecimalPlace = 0 Then
            strdecimalNumber = intdecimalNumber1.ToString("#####.0")
            Label1.Text = strdecimalNumber
            Debug.WriteLine(strdecimalNumber)

        Else
            convertNumbertoDecimal(intdecimalNumber1)
        End If

    End Sub
    Public Sub convertNumbertoDecimal(intdecimalNumber1 As Decimal)
        Dim intdecimalNumber2 As Decimal
        Dim strdecimalNumber As String
        Dim strvalue1 As String = intdecimalPlace.ToString()
        Select Case strvalue1

            Case "1"
                intdecimalNumber2 = intdecimalNumber1 / 10
                strdecimalNumber = intdecimalNumber2.ToString()
            Case "2"
                intdecimalNumber2 = intdecimalNumber1 / 100
                strdecimalNumber = intdecimalNumber2.ToString()
            Case "3"
                intdecimalNumber2 = intdecimalNumber1 / 1000
                strdecimalNumber = intdecimalNumber2.ToString()
            Case "4"  ' Or "thousandth"
                intdecimalNumber2 = intdecimalNumber1 / 10000
                strdecimalNumber = intdecimalNumber2.ToString()
            Case "5" ' Or "ten thousandth"
                intdecimalNumber2 = intdecimalNumber1 / 100000
                strdecimalNumber = intdecimalNumber2.ToString()
            Case Else
                MessageBox.Show("4 place valid ")
        End Select
        Label1.Text = strdecimalNumber
    End Sub

    Public Property StartAt() As Integer

        Get
            StartAt = intStartAt
        End Get
        Set(value As Integer)
            intStartAt = value

        End Set

    End Property

    'Public Property ConsecutiveNumber() As Integer

    '    Get
    '        Return intConsecutiveNumber
    '    End Get
    '    Set(value As Integer)
    '        intConsecutiveNumber = value
    '    End Set
    'End Property


    Public Property SerialNumber() As Integer

        Get
            Return intSerialNumber
        End Get
        Set(value As Integer)
            intSerialNumber = value
        End Set

    End Property
    Public Property decimalPlace() As Integer

        Get
            Return intdecimalPlace
        End Get
        Set(value As Integer)
            intdecimalPlace = value
        End Set

    End Property
End Class
