using Ryujinx.Graphics.Shader.Decoders;
using Ryujinx.Graphics.Shader.Translation;

namespace Ryujinx.Graphics.Shader.Instructions
{
    static partial class InstEmit
    {
        public static void Bar(EmitterContext context)
        {
            InstBar op = context.GetOp<InstBar>();

            // TODO: Support other modes.
            if (op.BarOp == BarOp.Sync)
            {
                context.Barrier();
            }
            else
            {
<<<<<<< HEAD
                context.TranslatorContext.GpuAccessor.Log($"Invalid barrier mode: {op.BarOp}.");
=======
                context.Config.GpuAccessor.Log($"Invalid barrier mode: {op.BarOp}.");
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public static void Depbar(EmitterContext context)
        {
<<<<<<< HEAD
#pragma warning disable IDE0059 // Remove unnecessary value assignment
            InstDepbar op = context.GetOp<InstDepbar>();
#pragma warning restore IDE0059
=======
            InstDepbar op = context.GetOp<InstDepbar>();
>>>>>>> 1ec71635b (sync with main branch)

            // No operation.
        }

        public static void Membar(EmitterContext context)
        {
            InstMembar op = context.GetOp<InstMembar>();

            if (op.Membar == Decoders.Membar.Cta)
            {
                context.GroupMemoryBarrier();
            }
            else
            {
                context.MemoryBarrier();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
