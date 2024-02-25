using Ryujinx.Graphics.Shader.Translation;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
<<<<<<< HEAD
    readonly struct StructureField
=======
    struct StructureField
>>>>>>> 1ec71635b (sync with main branch)
    {
        public AggregateType Type { get; }
        public string Name { get; }
        public int ArrayLength { get; }

        public StructureField(AggregateType type, string name, int arrayLength = 1)
        {
            Type = type;
            Name = name;
            ArrayLength = arrayLength;
        }
    }

    class StructureType
    {
        public StructureField[] Fields { get; }

        public StructureType(StructureField[] fields)
        {
            Fields = fields;
        }
    }
}
