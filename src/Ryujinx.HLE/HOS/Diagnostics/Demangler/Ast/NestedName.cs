using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class NestedName : ParentNode
    {
<<<<<<< HEAD
        private readonly BaseNode _name;
=======
        private BaseNode _name;
>>>>>>> 1ec71635b (sync with main branch)

        public NestedName(BaseNode name, BaseNode type) : base(NodeType.NestedName, type)
        {
            _name = name;
        }

        public override string GetName()
        {
            return _name.GetName();
        }

        public override void PrintLeft(TextWriter writer)
        {
            Child.Print(writer);
            writer.Write("::");
            _name.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
