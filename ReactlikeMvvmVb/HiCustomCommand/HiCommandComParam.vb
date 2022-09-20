Imports System
Imports System.Threading.Tasks
Imports System.Windows.Input

Public Class HiCommandComParam(Of T)
    Implements ICommand

    Private Property _fnCommand As Action(Of T)

    Private Property _fnCommandAsync As Func(Of T, Task)

    Public ReadOnly Property EAsync As Boolean
        Get
            Return _fnCommand Is Nothing
        End Get
    End Property

    Public Sub New(fnCommand As Action(Of T))
        _fnCommand = fnCommand
    End Sub

    Public Sub New(fnCommandAsync As Func(Of T, Task))
        _fnCommandAsync = fnCommandAsync
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If parameter Is Nothing Then
            Throw New ArgumentNullException()
        End If
        If Not parameter.GetType().IsAssignableTo(GetType(T)) Then
            Throw New ArgumentException("CommandParameter possui um tipo incorreto.")
        End If
        Dim parameterAsT = CType(parameter, T)
        If Not EAsync Then
            _fnCommand?.Invoke(parameterAsT)
        Else
            _fnCommandAsync?.Invoke(parameterAsT).Wait()
        End If
    End Sub
End Class