Imports System
Imports System.Collections.Generic

Public Class HiEstadoDerivado(Of T)
    Inherits HiSujeitoBase(Of String)
    Implements IHiObservador(Of String)
    Private Property _fnCalcularValor As Func(Of T)
    Private Property _nomePropd As String
    Private Property _valorCalculado As T
    Public Property ValorCalculado As T
        Get
            Return _valorCalculado
        End Get
        Private Set(value As T)
            _valorCalculado = value
        End Set
    End Property

    Public Sub New(fnCalcularValor As Func(Of T), deps As IEnumerable(Of HiSujeitoBase(Of String)), nomePropd As String)
        _fnCalcularValor = fnCalcularValor
        _nomePropd = nomePropd
        ValorCalculado = fnCalcularValor.Invoke()
        For Each iDep As HiSujeitoBase(Of String) In deps
            iDep.Inscrever(Me)
        Next
    End Sub

    Public Sub Atualizar(arg As String) Implements IHiObservador(Of String).Atualizar
        ValorCalculado = _fnCalcularValor.Invoke()
        NotificarTodos(_nomePropd)
    End Sub
End Class
