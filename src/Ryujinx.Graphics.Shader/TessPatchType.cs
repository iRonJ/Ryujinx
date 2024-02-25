namespace Ryujinx.Graphics.Shader
{
    public enum TessPatchType
    {
        Isolines = 0,
        Triangles = 1,
<<<<<<< HEAD
        Quads = 2,
=======
        Quads = 2
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class TessPatchTypeExtensions
    {
        public static string ToGlsl(this TessPatchType type)
        {
            return type switch
            {
                TessPatchType.Isolines => "isolines",
                TessPatchType.Quads => "quads",
<<<<<<< HEAD
                _ => "triangles",
            };
        }
    }
}
=======
                _ => "triangles"
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
