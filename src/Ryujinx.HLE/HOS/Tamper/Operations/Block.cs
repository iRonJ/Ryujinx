using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Tamper.Operations
{
    class Block : IOperation
    {
<<<<<<< HEAD
        private readonly IEnumerable<IOperation> _operations;
=======
        private IEnumerable<IOperation> _operations;
>>>>>>> 1ec71635b (sync with main branch)

        public Block(IEnumerable<IOperation> operations)
        {
            _operations = operations;
        }

        public Block(params IOperation[] operations)
        {
            _operations = operations;
        }

        public void Execute()
        {
            foreach (IOperation op in _operations)
            {
                op.Execute();
            }
        }
    }
}
