using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class CastExpression : BaseNode
    {
<<<<<<< HEAD
        private readonly string _kind;
        private readonly BaseNode _to;
        private readonly BaseNode _from;
=======
        private string   _kind;
        private BaseNode _to;
        private BaseNode _from;
>>>>>>> 1ec71635b (sync with main branch)

        public CastExpression(string kind, BaseNode to, BaseNode from) : base(NodeType.CastExpression)
        {
            _kind = kind;
<<<<<<< HEAD
            _to = to;
=======
            _to   = to;
>>>>>>> 1ec71635b (sync with main branch)
            _from = from;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write(_kind);
            writer.Write("<");
            _to.PrintLeft(writer);
            writer.Write(">(");
            _from.PrintLeft(writer);
            writer.Write(")");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
