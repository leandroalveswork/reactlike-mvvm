using System.Windows;
using System.Windows.Input;
using ReactlikeMvvm.HiCustomCommand;
using ReactlikeMvvm.HiViewModel;

namespace ReactlikeMvvm.ViewModel
{
    public class MainWindowViewModel : HiViewModelBase
    {
        private HiEstado<bool> _eVisivelBlocoWpfIntro;
        private HiEstadoDerivado<Visibility> _visibilityBlocoWpfIntro;
        public Visibility VisibilityBlocoWpfIntro => _visibilityBlocoWpfIntro.ValorCalculado;
        private HiEstadoDerivado<string> _textoMostrarEsconderWpfIntro;
        public string TextoMostrarEsconderWpfIntro => _textoMostrarEsconderWpfIntro.ValorCalculado;
        public ICommand MostrarEsconderWpfIntroCommand { get; set; }
        private HiEstado<bool> _eVisivelBlocoReact;
        private HiEstadoDerivado<Visibility> _visibilityBlocoReact;
        public Visibility VisibilityBlocoReact => _visibilityBlocoReact.ValorCalculado;
        private HiEstadoDerivado<string> _textoMostrarEsconderReact;
        public string TextoMostrarEsconderReact => _textoMostrarEsconderReact.ValorCalculado;
        public ICommand MostrarEsconderReactCommand { get; set; }
        private HiEstado<int> _vezesClicadas { get; set; }
        public ICommand IncrementarCommand { get; set; }
        private HiEstadoDerivado<Visibility> _visibilityTextoXVezes;
        public Visibility VisibilityTextoXVezes => _visibilityTextoXVezes.ValorCalculado;
        private HiEstadoDerivado<string> _textoXVezes;
        public string TextoXVezes
        {
            get
            {
                return _textoXVezes.ValorCalculado;
            }
            set
            {
            }
        }
        public MainWindowViewModel()
        {
            _eVisivelBlocoWpfIntro = UseState(false, nameof(_eVisivelBlocoWpfIntro));
            _visibilityBlocoWpfIntro = UseEffect(() =>
                _eVisivelBlocoWpfIntro.Valor ? Visibility.Visible : Visibility.Collapsed
            , new [] { _eVisivelBlocoWpfIntro }, nameof(VisibilityBlocoWpfIntro));
            _textoMostrarEsconderWpfIntro = UseEffect(() =>
                _eVisivelBlocoWpfIntro.Valor ? "Esconder Intro WPF" : "Mostrar Intro WPF"
            , new [] { _eVisivelBlocoWpfIntro }, nameof(TextoMostrarEsconderWpfIntro));
            MostrarEsconderWpfIntroCommand = new HiCommand(() => {
                _eVisivelBlocoWpfIntro.Alterar(!_eVisivelBlocoWpfIntro.Valor);
            });

            _eVisivelBlocoReact = UseState(false, nameof(_eVisivelBlocoReact));
            _visibilityBlocoReact = UseEffect(() =>
                _eVisivelBlocoReact.Valor ? Visibility.Visible : Visibility.Collapsed
            , new [] { _eVisivelBlocoReact }, nameof(VisibilityBlocoReact));
            _textoMostrarEsconderReact = UseEffect(() =>
                _eVisivelBlocoReact.Valor ? "Esconder React" : "Mostrar React"
            , new [] { _eVisivelBlocoReact }, nameof(TextoMostrarEsconderReact));
            MostrarEsconderReactCommand = new HiCommand(() => {
                _eVisivelBlocoReact.Alterar(!_eVisivelBlocoReact.Valor);
            });

            _vezesClicadas = UseState(0, nameof(_vezesClicadas));
            IncrementarCommand = new HiCommand(() => {
                _vezesClicadas.Alterar(_vezesClicadas.Valor + 1); 
            });
            _visibilityTextoXVezes = UseEffect(() => 
                _vezesClicadas.Valor > 0 ? Visibility.Visible : Visibility.Collapsed
            , new [] { _vezesClicadas }, nameof(VisibilityTextoXVezes));
            _textoXVezes = UseEffect(() => {
                if (_vezesClicadas.Valor == 0)
                {
                    return "";
                }
                return _vezesClicadas.Valor == 1 ? "1 vez." : (_vezesClicadas.Valor.ToString() + " vezes.");
            }, new [] { _vezesClicadas }, nameof(TextoXVezes));
            
            Main();
        }
        public void Main()
        {
            _eVisivelBlocoReact.Alterar(true);
        }
    }
}