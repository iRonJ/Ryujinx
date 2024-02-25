using System.Collections.Generic;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    class AstNode : IAstNode
    {
        public AstBlock Parent { get; set; }

        public LinkedListNode<IAstNode> LLNode { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
