using Ryujinx.Graphics.Shader.Decoders;
using Ryujinx.Graphics.Shader.Translation;

namespace Ryujinx.Graphics.Shader.Instructions
{
    static partial class InstEmit
    {
        public static void Nop(EmitterContext context)
        {
<<<<<<< HEAD
            context.GetOp<InstNop>();
=======
            InstNop op = context.GetOp<InstNop>();
>>>>>>> 1ec71635b (sync with main branch)

            // No operation.
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
