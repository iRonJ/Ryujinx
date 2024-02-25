using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class NameType : BaseNode
    {
<<<<<<< HEAD
        private readonly string _nameValue;
=======
        private string _nameValue;
>>>>>>> 1ec71635b (sync with main branch)

        public NameType(string nameValue, NodeType type) : base(type)
        {
            _nameValue = nameValue;
        }

        public NameType(string nameValue) : base(NodeType.NameType)
        {
            _nameValue = nameValue;
        }

        public override string GetName()
        {
            return _nameValue;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write(_nameValue);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
