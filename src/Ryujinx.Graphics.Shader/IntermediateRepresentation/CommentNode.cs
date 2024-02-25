namespace Ryujinx.Graphics.Shader.IntermediateRepresentation
{
    class CommentNode : Operation
    {
        public string Comment { get; }

        public CommentNode(string comment) : base(Instruction.Comment, null)
        {
            Comment = comment;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
