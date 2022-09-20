Imports System.Collections.Generic

Public Class HiSujeitoBase(Of TArg)
    Private Property _observadores As List(Of IHiObservador(Of TArg))
    Public Sub New()
        _observadores = New List(Of IHiObservador(Of TArg))()
    End Sub

    Public Sub Inscrever(observador As IHiObservador(Of TArg))
        _observadores.Add(observador)
    End Sub

    Public Sub Desinscrever(observador As IHiObservador(Of TArg))
        _observadores.Remove(observador)
    End Sub

    Public Sub NotificarTodos(arg As TArg)
        For Each iObservador As IHiObservador(Of TArg) In _observadores
            iObservador.Atualizar(arg)
        Next
    End Sub
End Class