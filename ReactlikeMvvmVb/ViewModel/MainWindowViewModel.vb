Imports System.Windows
Imports System.Windows.Input

Public Class MainWindowViewModel
    Inherits HiViewModelBase
    
    Private Property _eVisivelBlocoWpfIntro As HiEstado(Of Boolean)
    Private Property _visibilityBlocoWpfIntro As HiEstadoDerivado(Of Visibility)
    Public ReadOnly Property VisibilityBlocoWpfIntro As Visibility
        Get
            Return _visibilityBlocoWpfIntro.ValorCalculado
        End Get
    End Property
    Private Property _textoMostrarEsconderWpfIntro As HiEstadoDerivado(Of String)
    Public ReadOnly Property TextoMostrarEsconderWpfIntro As String
        Get
            Return _textoMostrarEsconderWpfIntro.ValorCalculado
        End Get
    End Property
    Public Property MostrarEsconderWpfIntroCommand As ICommand
    
    Private Property _eVisivelBlocoReact As HiEstado(Of Boolean)
    Private Property _visibilityBlocoReact As HiEstadoDerivado(Of Visibility)
    Public ReadOnly Property VisibilityBlocoReact As Visibility
        Get
            Return _visibilityBlocoReact.ValorCalculado
        End Get
    End Property
    Private Property _textoMostrarEsconderReact As HiEstadoDerivado(Of String)
    Public ReadOnly Property TextoMostrarEsconderReact As String
        Get
            Return _textoMostrarEsconderReact.ValorCalculado
        End Get
    End Property
    Public Property MostrarEsconderReactCommand As ICommand

    Private Property _vezesClicadas As HiEstado(Of Integer)
    Public Property IncrementarCommand As ICommand
    Private Property _textoXVezes As HiEstadoDerivado(Of String)
    Public Property TextoXVezes As String
        Get
            Return _textoXVezes.ValorCalculado
        End Get
        Set(value As String)
        End Set
    End Property

    Public Sub New()
        _eVisivelBlocoWpfIntro = UseState(False, NameOf(_eVisivelBlocoWpfIntro))
        _visibilityBlocoWpfIntro = UseEffect(Function()
            Return If(_eVisivelBlocoWpfIntro.Valor, Visibility.Visible, Visibility.Collapsed)
        End Function, { _eVisivelBlocoWpfIntro }, NameOf(VisibilityBlocoWpfIntro) )
        _textoMostrarEsconderWpfIntro = UseEffect(Function()
            Return If(_eVisivelBlocoWpfIntro.Valor, "Esconder Intro WPF", "Mostrar Info WPF")
        End Function, { _eVisivelBlocoWpfIntro }, NameOf(TextoMostrarEsconderWpfIntro))
        MostrarEsconderWpfIntroCommand = New HiCommand(Sub()
            _eVisivelBlocoWpfIntro.Alterar(Not (_eVisivelBlocoWpfIntro.Valor))
        End Sub)
        
        _eVisivelBlocoReact = UseState(False, NameOf(_eVisivelBlocoReact))
        _visibilityBlocoReact = UseEffect(Function()
            Return If(_eVisivelBlocoReact.Valor, Visibility.Visible, Visibility.Collapsed)
        End Function, { _eVisivelBlocoReact }, NameOf(VisibilityBlocoReact) )
        _textoMostrarEsconderReact = UseEffect(Function()
            Return If(_eVisivelBlocoReact.Valor, "Esconder React", "Mostrar React")
        End Function, { _eVisivelBlocoReact }, NameOf(TextoMostrarEsconderReact))
        MostrarEsconderReactCommand = New HiCommand(Sub()
            _eVisivelBlocoReact.Alterar(Not (_eVisivelBlocoReact.Valor))
        End Sub)

        _vezesClicadas = UseState(0, NameOf(_vezesClicadas))
        IncrementarCommand = New HiCommand(Sub()
            _vezesClicadas.Alterar(_vezesClicadas.Valor + 1)
        End Sub)
        _textoXVezes = UseEffect(Function()
            If (_vezesClicadas.Valor.Equals(0)) Then
                Return " nenhuma vez."
            End If
            Return If(_vezesClicadas.Valor.Equals(1), " 1 vez.", " " + _vezesClicadas.Valor.ToString() + " vezes.")
        End Function, { _vezesClicadas }, NameOf(TextoXVezes))
        Main()
    End Sub

    Public Sub Main()

    End Sub
End Class
