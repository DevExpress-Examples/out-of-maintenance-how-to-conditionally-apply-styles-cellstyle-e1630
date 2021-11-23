Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.Windows.Media

Namespace DXGrid_ConditionalFormatting

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = Products.GetData()
        End Sub
    End Class

    Public Class IntoToColorConverter
        Inherits MarkupExtension
        Implements IValueConverter

#Region "IValueConverter Members"
        Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            If CInt(value) < 20 Then
                Return New LinearGradientBrush(Color.FromArgb(100, 255, 0, 0), Color.FromArgb(0, 255, 0, 0), 0)
            Else
                Return Brushes.White
            End If
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New System.NotImplementedException()
        End Function

#End Region
        Public Overrides Function ProvideValue(ByVal serviceProvider As System.IServiceProvider) As Object
            Return Me
        End Function
    End Class

    Public Class Products

        Public Shared Function GetData() As List(Of Product)
            Dim data As List(Of Product) = New List(Of Product)()
            data.Add(New Product() With {.ProductName = "Chai", .UnitPrice = 18, .UnitsOnOrder = 10})
            data.Add(New Product() With {.ProductName = "Ipoh Coffee", .UnitPrice = 36.8, .UnitsOnOrder = 12})
            data.Add(New Product() With {.ProductName = "Outback Lager", .UnitPrice = 12, .UnitsOnOrder = 25})
            data.Add(New Product() With {.ProductName = "Boston Crab Meat", .UnitPrice = 18.4, .UnitsOnOrder = 18})
            data.Add(New Product() With {.ProductName = "Konbu", .UnitPrice = 6, .UnitsOnOrder = 24})
            Return data
        End Function
    End Class

    Public Class Product

        Public Property ProductName As String

        Public Property UnitPrice As Double

        Public Property UnitsOnOrder As Integer
    End Class
End Namespace
