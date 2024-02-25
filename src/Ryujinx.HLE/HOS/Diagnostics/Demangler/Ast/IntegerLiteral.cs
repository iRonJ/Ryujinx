using System;
using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class IntegerLiteral : BaseNode
    {
<<<<<<< HEAD
        private readonly string _literalName;
        private readonly string _literalValue;
=======
        private string _literalName;
        private string _literalValue;
>>>>>>> 1ec71635b (sync with main branch)

        public IntegerLiteral(string literalName, string literalValue) : base(NodeType.IntegerLiteral)
        {
            _literalValue = literalValue;
<<<<<<< HEAD
            _literalName = literalName;
=======
            _literalName  = literalName;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override void PrintLeft(TextWriter writer)
        {
            if (_literalName.Length > 3)
            {
                writer.Write("(");
                writer.Write(_literalName);
                writer.Write(")");
            }

            if (_literalValue[0] == 'n')
            {
                writer.Write("-");
                writer.Write(_literalValue.AsSpan(1));
            }
            else
            {
                writer.Write(_literalValue);
            }

            if (_literalName.Length <= 3)
            {
                writer.Write(_literalName);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
