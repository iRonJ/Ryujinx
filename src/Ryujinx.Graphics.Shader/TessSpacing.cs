namespace Ryujinx.Graphics.Shader
{
    public enum TessSpacing
    {
        EqualSpacing = 0,
        FractionalEventSpacing = 1,
<<<<<<< HEAD
        FractionalOddSpacing = 2,
=======
        FractionalOddSpacing = 2
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class TessSpacingExtensions
    {
        public static string ToGlsl(this TessSpacing spacing)
        {
            return spacing switch
            {
                TessSpacing.FractionalEventSpacing => "fractional_even_spacing",
                TessSpacing.FractionalOddSpacing => "fractional_odd_spacing",
<<<<<<< HEAD
                _ => "equal_spacing",
            };
        }
    }
}
=======
                _ => "equal_spacing"
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
