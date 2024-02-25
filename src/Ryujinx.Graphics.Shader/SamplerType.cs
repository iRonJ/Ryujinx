using Ryujinx.Graphics.Shader.Translation;
using System;

namespace Ryujinx.Graphics.Shader
{
    [Flags]
    public enum SamplerType
    {
        None = 0,
        Texture1D,
        TextureBuffer,
        Texture2D,
        Texture3D,
        TextureCube,

        Mask = 0xff,

<<<<<<< HEAD
        Array = 1 << 8,
        Indexed = 1 << 9,
        Multisample = 1 << 10,
        Shadow = 1 << 11,
=======
        Array       = 1 << 8,
        Indexed     = 1 << 9,
        Multisample = 1 << 10,
        Shadow      = 1 << 11
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class SamplerTypeExtensions
    {
        public static int GetDimensions(this SamplerType type)
        {
            return (type & SamplerType.Mask) switch
            {
                SamplerType.Texture1D => 1,
                SamplerType.TextureBuffer => 1,
                SamplerType.Texture2D => 2,
                SamplerType.Texture3D => 3,
                SamplerType.TextureCube => 3,
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid sampler type \"{type}\"."),
=======
                _ => throw new ArgumentException($"Invalid sampler type \"{type}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static string ToGlslSamplerType(this SamplerType type)
        {
            string typeName = (type & SamplerType.Mask) switch
            {
                SamplerType.Texture1D => "sampler1D",
                SamplerType.TextureBuffer => "samplerBuffer",
                SamplerType.Texture2D => "sampler2D",
                SamplerType.Texture3D => "sampler3D",
                SamplerType.TextureCube => "samplerCube",
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid sampler type \"{type}\"."),
=======
                _ => throw new ArgumentException($"Invalid sampler type \"{type}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };

            if ((type & SamplerType.Multisample) != 0)
            {
                typeName += "MS";
            }

            if ((type & SamplerType.Array) != 0)
            {
                typeName += "Array";
            }

            if ((type & SamplerType.Shadow) != 0)
            {
                typeName += "Shadow";
            }

            return typeName;
        }

        public static string ToGlslImageType(this SamplerType type, AggregateType componentType)
        {
            string typeName = (type & SamplerType.Mask) switch
            {
                SamplerType.Texture1D => "image1D",
                SamplerType.TextureBuffer => "imageBuffer",
                SamplerType.Texture2D => "image2D",
                SamplerType.Texture3D => "image3D",
                SamplerType.TextureCube => "imageCube",
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid sampler type \"{type}\"."),
=======
                _ => throw new ArgumentException($"Invalid sampler type \"{type}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };

            if ((type & SamplerType.Multisample) != 0)
            {
                typeName += "MS";
            }

            if ((type & SamplerType.Array) != 0)
            {
                typeName += "Array";
            }

            switch (componentType)
            {
<<<<<<< HEAD
                case AggregateType.U32:
                    typeName = 'u' + typeName;
                    break;
                case AggregateType.S32:
                    typeName = 'i' + typeName;
                    break;
=======
                case AggregateType.U32: typeName = 'u' + typeName; break;
                case AggregateType.S32: typeName = 'i' + typeName; break;
>>>>>>> 1ec71635b (sync with main branch)
            }

            return typeName;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
