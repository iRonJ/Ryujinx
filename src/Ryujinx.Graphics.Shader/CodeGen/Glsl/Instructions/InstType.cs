using System;
<<<<<<< HEAD
using System.Diagnostics.CodeAnalysis;
=======
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Shader.CodeGen.Glsl.Instructions
{
    [Flags]
<<<<<<< HEAD
    [SuppressMessage("Design", "CA1069: Enums values should not be duplicated")]
    enum InstType
    {
        OpNullary = Op | 0,
        OpUnary = Op | 1,
        OpBinary = Op | 2,
        OpBinaryCom = Op | 2 | Commutative,
        OpTernary = Op | 3,

        CallNullary = Call | 0,
        CallUnary = Call | 1,
        CallBinary = Call | 2,
        CallTernary = Call | 3,
=======
    enum InstType
    {
        OpNullary   = Op | 0,
        OpUnary     = Op | 1,
        OpBinary    = Op | 2,
        OpBinaryCom = Op | 2 | Commutative,
        OpTernary   = Op | 3,

        CallNullary    = Call | 0,
        CallUnary      = Call | 1,
        CallBinary     = Call | 2,
        CallTernary    = Call | 3,
>>>>>>> 1ec71635b (sync with main branch)
        CallQuaternary = Call | 4,

        // The atomic instructions have one extra operand,
        // for the storage slot and offset pair.
<<<<<<< HEAD
        AtomicBinary = Call | Atomic | 3,
        AtomicTernary = Call | Atomic | 4,

        Commutative = 1 << 8,
        Op = 1 << 9,
        Call = 1 << 10,
        Atomic = 1 << 11,
        Special = 1 << 12,

        ArityMask = 0xff,
    }
}
=======
        AtomicBinary  = Call | Atomic | 3,
        AtomicTernary = Call | Atomic | 4,

        Commutative = 1 << 8,
        Op          = 1 << 9,
        Call        = 1 << 10,
        Atomic      = 1 << 11,
        Special     = 1 << 12,

        ArityMask = 0xff
    }
}
>>>>>>> 1ec71635b (sync with main branch)
