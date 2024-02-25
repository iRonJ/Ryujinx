using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class LocalName : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _encoding;
        private readonly BaseNode _entity;
=======
        private BaseNode _encoding;
        private BaseNode _entity;
>>>>>>> 1ec71635b (sync with main branch)

        public LocalName(BaseNode encoding, BaseNode entity) : base(NodeType.LocalName)
        {
            _encoding = encoding;
<<<<<<< HEAD
            _entity = entity;
=======
            _entity   = entity;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override void PrintLeft(TextWriter writer)
        {
            _encoding.Print(writer);
            writer.Write("::");
            _entity.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
