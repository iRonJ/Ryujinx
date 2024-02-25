namespace Ryujinx.HLE.HOS.Tamper.Operations
{
    class OpMov<T> : IOperation where T : unmanaged
    {
<<<<<<< HEAD
        readonly IOperand _destination;
        readonly IOperand _source;
=======
        IOperand _destination;
        IOperand _source;
>>>>>>> 1ec71635b (sync with main branch)

        public OpMov(IOperand destination, IOperand source)
        {
            _destination = destination;
            _source = source;
        }

        public void Execute()
        {
            _destination.Set(_source.Get<T>());
        }
    }
}
