Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class HiViewModelBase
    Implements INotifyPropertyChanged, IHiObservador(Of String)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub Atualizar(arg As String) Implements IHiObservador(Of String).Atualizar
        NotificarPropertyChanged(arg)
    End Sub

    Private Sub NotificarPropertyChanged(arg As String)
        If PropertyChangedEvent IsNot Nothing Then
            PropertyChangedEvent.Invoke(Me, New PropertyChangedEventArgs(arg))
        End If
    End Sub

    Public Function UseState(Of T)(valorInicial As T, nomePropd As String) As HiEstado(Of T)
        Dim hiEstado = New HiEstado(Of T)(valorInicial, nomePropd)
        hiEstado.Inscrever(Me)
        Return hiEstado
    End Function

    Public Function UseEffect(Of T)(fnCalcularValor As Func(Of T), deps As IEnumerable(Of HiSujeitoBase(Of String)), nomePropd As String) As HiEstadoDerivado(Of T)
        Dim hiEstadoDerivado = New HiEstadoDerivado(Of T)(fnCalcularValor, deps, nomePropd)
        hiEstadoDerivado.Inscrever(Me)
        Return hiEstadoDerivado
    End Function
End Class
