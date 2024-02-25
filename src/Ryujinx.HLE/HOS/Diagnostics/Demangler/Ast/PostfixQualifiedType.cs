using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class PostfixQualifiedType : ParentNode
    {
<<<<<<< HEAD
        private readonly string _postfixQualifier;
=======
        private string _postfixQualifier;
>>>>>>> 1ec71635b (sync with main branch)

        public PostfixQualifiedType(string postfixQualifier, BaseNode type) : base(NodeType.PostfixQualifiedType, type)
        {
            _postfixQualifier = postfixQualifier;
        }

        public override void PrintLeft(TextWriter writer)
        {
            Child.Print(writer);
            writer.Write(_postfixQualifier);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
