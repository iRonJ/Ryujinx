using Ryujinx.Graphics.Shader.IntermediateRepresentation;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    class AstTextureOperation : AstOperation
    {
        public SamplerType Type { get; }
        public TextureFormat Format { get; }
        public TextureFlags Flags { get; }

<<<<<<< HEAD
        public int Binding { get; }
=======
        public int CbufSlot { get; }
        public int Handle { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public AstTextureOperation(
            Instruction inst,
            SamplerType type,
            TextureFormat format,
            TextureFlags flags,
<<<<<<< HEAD
            int binding,
=======
            int cbufSlot,
            int handle,
>>>>>>> 1ec71635b (sync with main branch)
            int index,
            params IAstNode[] sources) : base(inst, StorageKind.None, false, index, sources, sources.Length)
        {
            Type = type;
            Format = format;
            Flags = flags;
<<<<<<< HEAD
            Binding = binding;
        }
    }
}
=======
            CbufSlot = cbufSlot;
            Handle = handle;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
