using Ryujinx.Graphics.Shader.Translation;
using System;

namespace Ryujinx.Graphics.Shader
{
    public enum AttributeType : byte
    {
        // Generic types.
        Float,
        Sint,
<<<<<<< HEAD
        Uint,
        Sscaled,
        Uscaled,

        Packed = 1 << 6,
        PackedRgb10A2Signed = 1 << 7,
        AnyPacked = Packed | PackedRgb10A2Signed,
=======
        Uint
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class AttributeTypeExtensions
    {
<<<<<<< HEAD
        public static AggregateType ToAggregateType(this AttributeType type)
        {
            return (type & ~AttributeType.AnyPacked) switch
            {
                AttributeType.Float => AggregateType.FP32,
                AttributeType.Sint => AggregateType.S32,
                AttributeType.Uint => AggregateType.U32,
                _ => throw new ArgumentException($"Invalid attribute type \"{type}\"."),
            };
        }

        public static AggregateType ToAggregateType(this AttributeType type, bool supportsScaledFormats)
        {
            return (type & ~AttributeType.AnyPacked) switch
=======
        public static string ToVec4Type(this AttributeType type)
        {
            return type switch
            {
                AttributeType.Float => "vec4",
                AttributeType.Sint => "ivec4",
                AttributeType.Uint => "uvec4",
                _ => throw new ArgumentException($"Invalid attribute type \"{type}\".")
            };
        }

        public static AggregateType ToAggregateType(this AttributeType type)
        {
            return type switch
>>>>>>> 1ec71635b (sync with main branch)
            {
                AttributeType.Float => AggregateType.FP32,
                AttributeType.Sint => AggregateType.S32,
                AttributeType.Uint => AggregateType.U32,
<<<<<<< HEAD
                AttributeType.Sscaled => supportsScaledFormats ? AggregateType.FP32 : AggregateType.S32,
                AttributeType.Uscaled => supportsScaledFormats ? AggregateType.FP32 : AggregateType.U32,
                _ => throw new ArgumentException($"Invalid attribute type \"{type}\"."),
            };
        }
    }
}
=======
                _ => throw new ArgumentException($"Invalid attribute type \"{type}\".")
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
