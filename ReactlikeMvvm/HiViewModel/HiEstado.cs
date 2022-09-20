using ReactlikeMvvm.HiPadraoObservador;

namespace ReactlikeMvvm.HiViewModel
{
    public class HiEstado<T> : HiSujeitoBase<string>
    {
        public T Valor { get; private set; }
        private string _nomePropd;
        public HiEstado(T valorInicial, string nomePropd)
        {
            Valor = valorInicial;
            _nomePropd = nomePropd;
        }
        public void Alterar(T proximoValor)
        {
            Valor = proximoValor;
            NotificarTodos(_nomePropd);
        }
    }
}