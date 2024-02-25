using static Ryujinx.Graphics.Shader.StructuredIr.AstHelper;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    class AstAssignment : AstNode
    {
        public IAstNode Destination { get; }

        private IAstNode _source;

        public IAstNode Source
        {
            get
            {
                return _source;
            }
            set
            {
                RemoveUse(_source, this);

                AddUse(value, this);

                _source = value;
            }
        }

        public AstAssignment(IAstNode destination, IAstNode source)
        {
            Destination = destination;
<<<<<<< HEAD
            Source = source;
=======
            Source      = source;
>>>>>>> 1ec71635b (sync with main branch)

            AddDef(destination, this);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
