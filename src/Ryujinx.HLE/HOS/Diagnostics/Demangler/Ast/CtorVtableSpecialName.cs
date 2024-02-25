using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class CtorVtableSpecialName : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _firstType;
        private readonly BaseNode _secondType;

        public CtorVtableSpecialName(BaseNode firstType, BaseNode secondType) : base(NodeType.CtorVtableSpecialName)
        {
            _firstType = firstType;
=======
        private BaseNode _firstType;
        private BaseNode _secondType;

        public CtorVtableSpecialName(BaseNode firstType, BaseNode secondType) : base(NodeType.CtorVtableSpecialName)
        {
            _firstType  = firstType;
>>>>>>> 1ec71635b (sync with main branch)
            _secondType = secondType;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("construction vtable for ");
            _firstType.Print(writer);
            writer.Write("-in-");
            _secondType.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
