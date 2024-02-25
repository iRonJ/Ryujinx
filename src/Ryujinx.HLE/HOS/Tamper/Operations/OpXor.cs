namespace Ryujinx.HLE.HOS.Tamper.Operations
{
    class OpXor<T> : IOperation where T : unmanaged
    {
<<<<<<< HEAD
        readonly IOperand _destination;
        readonly IOperand _lhs;
        readonly IOperand _rhs;
=======
        IOperand _destination;
        IOperand _lhs;
        IOperand _rhs;
>>>>>>> 1ec71635b (sync with main branch)

        public OpXor(IOperand destination, IOperand lhs, IOperand rhs)
        {
            _destination = destination;
            _lhs = lhs;
            _rhs = rhs;
        }

        public void Execute()
        {
            _destination.Set((T)((dynamic)_lhs.Get<T>() ^ (dynamic)_rhs.Get<T>()));
        }
    }
}
