using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class NameTypeWithTemplateArguments : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _prev;
        private readonly BaseNode _templateArgument;

        public NameTypeWithTemplateArguments(BaseNode prev, BaseNode templateArgument) : base(NodeType.NameTypeWithTemplateArguments)
        {
            _prev = prev;
=======
        private BaseNode _prev;
        private BaseNode _templateArgument;

        public NameTypeWithTemplateArguments(BaseNode prev, BaseNode templateArgument) : base(NodeType.NameTypeWithTemplateArguments)
        {
            _prev             = prev;
>>>>>>> 1ec71635b (sync with main branch)
            _templateArgument = templateArgument;
        }

        public override string GetName()
        {
            return _prev.GetName();
        }
<<<<<<< HEAD

=======
        
>>>>>>> 1ec71635b (sync with main branch)
        public override void PrintLeft(TextWriter writer)
        {
            _prev.Print(writer);
            _templateArgument.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
