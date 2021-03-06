Public Class Benefits
    Structure BenefitInfo
        Dim strName As String
        Dim strPage As String
    End Structure

    Public Function GetBenefitsList() As BenefitInfo()
        'return a 2-dimensional array of the available benefits and the names of the 
        'pages that implement the benefit
        Dim arBenefits(3) As BenefitInfo

        arBenefits(0).strName = "Dental"
        arBenefits(0).strPage = "dental.aspx"
        arBenefits(1).strName = "Medical"
        arBenefits(1).strPage = "medical.aspx"
        arBenefits(2).strName = "Life Insurance"
        arBenefits(2).strPage = "life.aspx"
        arBenefits(3).strName = "Retirement Account"
        arBenefits(3).strPage = "retirement.aspx"

        Return arBenefits

    End Function

End Class
