using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using Ryujinx.Graphics.Shader.Translation;
using System.Numerics;

using static Ryujinx.Graphics.Shader.StructuredIr.AstHelper;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    class AstOperation : AstNode
    {
        public Instruction Inst { get; }
        public StorageKind StorageKind { get; }
        public bool ForcePrecise { get; }

        public int Index { get; }

<<<<<<< HEAD
        private readonly IAstNode[] _sources;
=======
        private IAstNode[] _sources;
>>>>>>> 1ec71635b (sync with main branch)

        public int SourcesCount => _sources.Length;

        public AstOperation(Instruction inst, StorageKind storageKind, bool forcePrecise, IAstNode[] sources, int sourcesCount)
        {
            Inst = inst;
            StorageKind = storageKind;
            ForcePrecise = forcePrecise;
            _sources = sources;

            for (int index = 0; index < sources.Length; index++)
            {
                if (index < sourcesCount)
                {
                    AddUse(sources[index], this);
                }
                else
                {
                    AddDef(sources[index], this);
                }
            }

            Index = 0;
        }

        public AstOperation(
            Instruction inst,
            StorageKind storageKind,
            bool forcePrecise,
            int index,
            IAstNode[] sources,
            int sourcesCount) : this(inst, storageKind, forcePrecise, sources, sourcesCount)
        {
            Index = index;
        }

        public AstOperation(Instruction inst, params IAstNode[] sources) : this(inst, StorageKind.None, false, sources, sources.Length)
        {
        }

        public IAstNode GetSource(int index)
        {
            return _sources[index];
        }

        public void SetSource(int index, IAstNode source)
        {
            RemoveUse(_sources[index], this);

            AddUse(source, this);

            _sources[index] = source;
        }

        public AggregateType GetVectorType(AggregateType scalarType)
        {
            int componentsCount = BitOperations.PopCount((uint)Index);

            AggregateType type = scalarType;

            switch (componentsCount)
            {
<<<<<<< HEAD
                case 2:
                    type |= AggregateType.Vector2;
                    break;
                case 3:
                    type |= AggregateType.Vector3;
                    break;
                case 4:
                    type |= AggregateType.Vector4;
                    break;
=======
                case 2: type |= AggregateType.Vector2; break;
                case 3: type |= AggregateType.Vector3; break;
                case 4: type |= AggregateType.Vector4; break;
>>>>>>> 1ec71635b (sync with main branch)
            }

            return type;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
