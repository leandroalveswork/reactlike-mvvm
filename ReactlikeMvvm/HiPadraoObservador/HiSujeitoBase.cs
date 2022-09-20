using System.Collections.Generic;

namespace ReactlikeMvvm.HiPadraoObservador
{
    public class HiSujeitoBase<TArg>
    {
        private List<IHiObservador<TArg>> _observadores = new List<IHiObservador<TArg>>();
        public void Inscrever(IHiObservador<TArg> observador)
        {
            _observadores.Add(observador);
        }
        public void Desinscrever(IHiObservador<TArg> observador)
        {
            _observadores.Remove(observador);
        }
        public void NotificarTodos(TArg arg)
        {
            foreach (var iObservador in _observadores)
            {
                iObservador.Atualizar(arg);
            }
        }
    }
}