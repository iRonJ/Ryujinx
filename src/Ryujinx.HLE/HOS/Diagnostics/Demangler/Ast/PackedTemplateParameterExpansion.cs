using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class PackedTemplateParameterExpansion : ParentNode
    {
<<<<<<< HEAD
        public PackedTemplateParameterExpansion(BaseNode child) : base(NodeType.PackedTemplateParameterExpansion, child) { }

        public override void PrintLeft(TextWriter writer)
        {
            if (Child is PackedTemplateParameter parameter)
            {
                if (parameter.Nodes.Count != 0)
                {
                    parameter.Print(writer);
=======
        public PackedTemplateParameterExpansion(BaseNode child) : base(NodeType.PackedTemplateParameterExpansion, child) {}

        public override void PrintLeft(TextWriter writer)
        {
            if (Child is PackedTemplateParameter)
            {
                if (((PackedTemplateParameter)Child).Nodes.Count !=  0)
                {
                    Child.Print(writer);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
            else
            {
                writer.Write("...");
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
