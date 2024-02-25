using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class CtorDtorNameType : ParentNode
    {
<<<<<<< HEAD
        private readonly bool _isDestructor;
=======
        private bool _isDestructor;
>>>>>>> 1ec71635b (sync with main branch)

        public CtorDtorNameType(BaseNode name, bool isDestructor) : base(NodeType.CtorDtorNameType, name)
        {
            _isDestructor = isDestructor;
        }

        public override void PrintLeft(TextWriter writer)
        {
            if (_isDestructor)
            {
                writer.Write("~");
            }

            writer.Write(Child.GetName());
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
