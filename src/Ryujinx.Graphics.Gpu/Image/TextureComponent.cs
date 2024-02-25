using Ryujinx.Graphics.GAL;

namespace Ryujinx.Graphics.Gpu.Image
{
    /// <summary>
    /// Texture swizzle color component.
    /// </summary>
    enum TextureComponent
    {
<<<<<<< HEAD
        Zero = 0,
        Red = 2,
        Green = 3,
        Blue = 4,
        Alpha = 5,
        OneSI = 6,
        OneF = 7,
=======
        Zero  = 0,
        Red   = 2,
        Green = 3,
        Blue  = 4,
        Alpha = 5,
        OneSI = 6,
        OneF  = 7
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class TextureComponentConverter
    {
        /// <summary>
        /// Converts the texture swizzle color component enum to the respective Graphics Abstraction Layer enum.
        /// </summary>
        /// <param name="component">Texture swizzle color component</param>
        /// <returns>Converted enum</returns>
        public static SwizzleComponent Convert(this TextureComponent component)
        {
<<<<<<< HEAD
            return component switch
            {
                TextureComponent.Zero => SwizzleComponent.Zero,
                TextureComponent.Red => SwizzleComponent.Red,
                TextureComponent.Green => SwizzleComponent.Green,
                TextureComponent.Blue => SwizzleComponent.Blue,
                TextureComponent.Alpha => SwizzleComponent.Alpha,
                TextureComponent.OneSI or TextureComponent.OneF => SwizzleComponent.One,
                _ => SwizzleComponent.Zero,
            };
        }
    }
}
=======
            switch (component)
            {
                case TextureComponent.Zero:  return SwizzleComponent.Zero;
                case TextureComponent.Red:   return SwizzleComponent.Red;
                case TextureComponent.Green: return SwizzleComponent.Green;
                case TextureComponent.Blue:  return SwizzleComponent.Blue;
                case TextureComponent.Alpha: return SwizzleComponent.Alpha;
                case TextureComponent.OneSI:
                case TextureComponent.OneF:
                    return SwizzleComponent.One;
            }

            return SwizzleComponent.Zero;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
