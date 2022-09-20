Public Class HiEstado(Of T)
    Inherits HiSujeitoBase(Of String)
    
    Private Property _valor As T
    Public Property Valor As T
        Get
            Return _valor
        End Get
        Private Set(value As T)
            _valor = value
        End Set
    End Property
    Private Property _nomePropd As String

    Public Sub New(valorInicial As T, nomePropd As String)
        Valor = valorInicial
        _nomePropd = nomePropd
    End Sub

    Public Sub Alterar(proximoValor As T)
        Valor = proximoValor
        NotificarTodos(_nomePropd)
    End Sub
End Class
