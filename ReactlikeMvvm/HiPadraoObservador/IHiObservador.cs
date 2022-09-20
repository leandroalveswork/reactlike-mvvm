namespace ReactlikeMvvm.HiPadraoObservador
{
    public interface IHiObservador<TArg>
    {
        void Atualizar(TArg arg);
    }
}