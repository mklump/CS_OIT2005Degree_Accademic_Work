Imports System.Web.Services

<WebService(Namespace:="http://microsoft.com/webservices/", _
            Description:="This XML Web service gives the weather forcast for the next day")> _
Public Class WeatherService
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    'The WeatherByCity() service takes the city as parameter and returns the weather in this city.
    <WebMethod(Description:="This XML Web service method gives the weather forcast for a given city")> Public Function WeatherByCity(ByVal City As String) As String
        If (LCase(City) = "seattle") Then
            'If the city is Seattle we know the answer
            Return "sun"
        Else
            'Else we apply the best forcast algorithm
            Dim intRandomNb As Integer
            'Generate random value between 1 and 3.
            intRandomNb = CInt(Int((3 * Rnd()) + 1))
            Select Case intRandomNb
                Case 1
                    Return "sun"
                Case 2
                    Return "cloudy"
                Case Else
                    Return "rain"
            End Select
        End If
    End Function

    'The TemperatureByCity() service takes the city as parameter and returns the temperature in this city.
    <WebMethod(Description:="This XML Web service method gives the temperature forcast for a given city in Fahrenheit")> Public Function TemperatureByCity(ByVal City As String) As Integer
        Dim intTemperature As Integer
        'Generate random value between 31 and 60.
        intTemperature = CInt(Int((30 * Rnd()) + 31))
        Return intTemperature
    End Function

    'The TravelAdviceByCity() service takes the city as parameter and returns an advise in this city.
    <WebMethod(Description:="This XML Web service method gives advises for travellers")> Public Function TravelAdviceByCity(ByVal City As String) As String
        If (LCase(City) = "seattle") Then
            'If the city is Seattle we know what to say
            Return "Don't forget your sunglasses"
        Else
            Return "Nothing special"
        End If
    End Function

End Class
