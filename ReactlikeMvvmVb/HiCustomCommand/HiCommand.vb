Imports System
Imports System.Threading.Tasks
Imports System.Windows.Input

Public Class HiCommand
    Implements ICommand
    Private Property _fnCommand As Action
    Private Property _fnCommandAsync As Func(Of Task)

    Public ReadOnly Property EAsync As Boolean
        Get
            Return _fnCommand Is Nothing
        End Get
    End Property

    Public Sub New(fnCommand As Action)
        _fnCommand = fnCommand
    End Sub

    Public Sub New(fnCommandAsync As Func(Of Task))
        _fnCommandAsync = fnCommandAsync
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If Not EAsync Then
            _fnCommand?.Invoke()
        Else
            _fnCommandAsync?.Invoke().Wait()
        End If
    End Sub
End Class