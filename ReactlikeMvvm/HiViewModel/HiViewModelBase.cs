using System;
using System.Collections.Generic;
using System.ComponentModel;
using ReactlikeMvvm.HiPadraoObservador;

namespace ReactlikeMvvm.HiViewModel
{
    public class HiViewModelBase : INotifyPropertyChanged, IHiObservador<string>
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Atualizar(string arg)
        {
            NotificarPropertyChanged(arg);
        }
        private void NotificarPropertyChanged(string arg)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(arg));
        }
        public HiEstado<T> UseState<T>(T valorInicial, string nomePropd)
        {
            var hiEstado = new HiEstado<T>(valorInicial, nomePropd);
            hiEstado.Inscrever(this);
            return hiEstado;
        }
        public HiEstadoDerivado<T> UseEffect<T>(Func<T> fnCalcularValor, IEnumerable<HiSujeitoBase<string>> deps, string nomePropd)
        {
            var hiEstadoDerivado = new HiEstadoDerivado<T>(fnCalcularValor, deps, nomePropd);
            hiEstadoDerivado.Inscrever(this);
            return hiEstadoDerivado;
        }
    }
}