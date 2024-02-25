using Ryujinx.HLE.HOS.Tamper.Operations;

namespace Ryujinx.HLE.HOS.Tamper.Conditions
{
    class CondNE<T> : ICondition where T : unmanaged
    {
<<<<<<< HEAD
        private readonly IOperand _lhs;
        private readonly IOperand _rhs;
=======
        private IOperand _lhs;
        private IOperand _rhs;
>>>>>>> 1ec71635b (sync with main branch)

        public CondNE(IOperand lhs, IOperand rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public bool Evaluate()
        {
            return (dynamic)_lhs.Get<T>() != (dynamic)_rhs.Get<T>();
        }
    }
}
