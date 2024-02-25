using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class FunctionParameter : BaseNode
    {
<<<<<<< HEAD
        private readonly string _number;
=======
        private string _number;
>>>>>>> 1ec71635b (sync with main branch)

        public FunctionParameter(string number) : base(NodeType.FunctionParameter)
        {
            _number = number;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("fp ");

            if (_number != null)
            {
                writer.Write(_number);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
