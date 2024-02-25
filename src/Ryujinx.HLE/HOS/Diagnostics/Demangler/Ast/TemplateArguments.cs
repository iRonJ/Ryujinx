using System.Collections.Generic;
using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class TemplateArguments : NodeArray
    {
        public TemplateArguments(List<BaseNode> nodes) : base(nodes, NodeType.TemplateArguments) { }

        public override void PrintLeft(TextWriter writer)
        {
<<<<<<< HEAD
            string paramsString = string.Join<BaseNode>(", ", Nodes.ToArray());

            writer.Write("<");

            writer.Write(paramsString);

            if (paramsString.EndsWith('>'))
=======
            string Params = string.Join<BaseNode>(", ", Nodes.ToArray());

            writer.Write("<");

            writer.Write(Params);

            if (Params.EndsWith(">"))
>>>>>>> 1ec71635b (sync with main branch)
            {
                writer.Write(" ");
            }

            writer.Write(">");
        }
    }
}
