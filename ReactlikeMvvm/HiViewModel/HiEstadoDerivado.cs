using System;
using System.Collections.Generic;
using ReactlikeMvvm.HiPadraoObservador;

namespace ReactlikeMvvm.HiViewModel
{
    public class HiEstadoDerivado<T> : HiSujeitoBase<string>, IHiObservador<string>
    {
        private Func<T> _fnCalcularValor;
        private string _nomePropd;
        public T ValorCalculado { get; private set; }
        public HiEstadoDerivado(Func<T> fnCalcularValor, IEnumerable<HiSujeitoBase<string>> deps, string nomePropd)
        {
            _fnCalcularValor = fnCalcularValor;
            _nomePropd = nomePropd;
            ValorCalculado = fnCalcularValor();
            foreach (var iDep in deps)
            {
                iDep.Inscrever(this);
            }
        }
        public void Atualizar(string arg)
        {
            ValorCalculado = _fnCalcularValor();
            NotificarTodos(_nomePropd);
        }
    }
}