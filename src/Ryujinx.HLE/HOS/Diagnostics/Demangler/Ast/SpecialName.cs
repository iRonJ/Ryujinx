using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class SpecialName : ParentNode
    {
<<<<<<< HEAD
        private readonly string _specialValue;
=======
        private string _specialValue;
>>>>>>> 1ec71635b (sync with main branch)

        public SpecialName(string specialValue, BaseNode type) : base(NodeType.SpecialName, type)
        {
            _specialValue = specialValue;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write(_specialValue);
            Child.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
