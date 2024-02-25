<<<<<<< HEAD
using Ryujinx.Graphics.Shader.Translation;
=======
﻿using Ryujinx.Graphics.Shader.Translation;
>>>>>>> 1ec71635b (sync with main branch)
using Spv.Generator;

namespace Ryujinx.Graphics.Shader.CodeGen.Spirv
{
    readonly struct OperationResult
    {
<<<<<<< HEAD
        public static OperationResult Invalid => new(AggregateType.Invalid, null);
=======
        public static OperationResult Invalid => new OperationResult(AggregateType.Invalid, null);
>>>>>>> 1ec71635b (sync with main branch)

        public AggregateType Type { get; }
        public Instruction Value { get; }

        public OperationResult(AggregateType type, Instruction value)
        {
            Type = type;
            Value = value;
        }
    }
}
