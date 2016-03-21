Public Class Class1
    Function hello() As String
        Return "Hi from Visual Basic .NET component"
    End Function

    Function ComputeShipping(ByVal sngPrice As Single) As Single

        Dim sngShipping As Single

        If sngPrice > 15 Then
            sngShipping = sngPrice * 0.1
        Else
            sngShipping = sngPrice * 0.05
        End If

        Return (sngShipping)

    End Function
End Class

