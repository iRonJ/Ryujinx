<<<<<<< HEAD
using System;
using System.Diagnostics.CodeAnalysis;

namespace Ryujinx.Graphics.Shader.Translation
{
    [Flags]
    [SuppressMessage("Design", "CA1069: Enums values should not be duplicated")]
=======
﻿namespace Ryujinx.Graphics.Shader.Translation
{
>>>>>>> 1ec71635b (sync with main branch)
    enum AggregateType
    {
        Invalid,
        Void,
        Bool,
        FP32,
        FP64,
        S32,
        U32,

        ElementTypeMask = 0xff,

        ElementCountShift = 8,
        ElementCountMask = 3 << ElementCountShift,

        Scalar = 0 << ElementCountShift,
        Vector2 = 1 << ElementCountShift,
        Vector3 = 2 << ElementCountShift,
        Vector4 = 3 << ElementCountShift,

<<<<<<< HEAD
        Array = 1 << 10,
=======
        Array  = 1 << 10
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class AggregateTypeExtensions
    {
        public static int GetSizeInBytes(this AggregateType type)
        {
            int elementSize = (type & AggregateType.ElementTypeMask) switch
            {
                AggregateType.Bool or
                AggregateType.FP32 or
                AggregateType.S32 or
                AggregateType.U32 => 4,
                AggregateType.FP64 => 8,
<<<<<<< HEAD
                _ => 0,
=======
                _ => 0
>>>>>>> 1ec71635b (sync with main branch)
            };

            switch (type & AggregateType.ElementCountMask)
            {
                case AggregateType.Vector2:
                    elementSize *= 2;
                    break;
                case AggregateType.Vector3:
                    elementSize *= 3;
                    break;
                case AggregateType.Vector4:
                    elementSize *= 4;
                    break;
            }

            return elementSize;
        }
    }
}
