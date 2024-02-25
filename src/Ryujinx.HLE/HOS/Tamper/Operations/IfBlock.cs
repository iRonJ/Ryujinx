using Ryujinx.HLE.HOS.Tamper.Conditions;
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Tamper.Operations
{
    class IfBlock : IOperation
    {
<<<<<<< HEAD
        private readonly ICondition _condition;
        private readonly IEnumerable<IOperation> _operationsThen;
        private readonly IEnumerable<IOperation> _operationsElse;
=======
        private ICondition _condition;
        private IEnumerable<IOperation> _operationsThen;
        private IEnumerable<IOperation> _operationsElse;
>>>>>>> 1ec71635b (sync with main branch)

        public IfBlock(ICondition condition, IEnumerable<IOperation> operationsThen, IEnumerable<IOperation> operationsElse)
        {
            _condition = condition;
            _operationsThen = operationsThen;
            _operationsElse = operationsElse;
        }

        public void Execute()
        {
            IEnumerable<IOperation> operations = _condition.Evaluate() ? _operationsThen : _operationsElse;

            if (operations == null)
            {
                return;
            }

            foreach (IOperation op in operations)
            {
                op.Execute();
            }
        }
    }
}
