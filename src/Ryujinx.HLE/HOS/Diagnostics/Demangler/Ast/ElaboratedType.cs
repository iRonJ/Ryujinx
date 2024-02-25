using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class ElaboratedType : ParentNode
    {
<<<<<<< HEAD
        private readonly string _elaborated;
=======
        private string _elaborated;
>>>>>>> 1ec71635b (sync with main branch)

        public ElaboratedType(string elaborated, BaseNode type) : base(NodeType.ElaboratedType, type)
        {
            _elaborated = elaborated;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write(_elaborated);
            writer.Write(" ");
            Child.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
