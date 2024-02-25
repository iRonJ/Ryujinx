namespace Ryujinx.Graphics.Shader.CodeGen.Glsl.Instructions
{
    static class InstGenFSI
    {
        public static string FSIBegin(CodeGenContext context)
        {
<<<<<<< HEAD
            if (context.HostCapabilities.SupportsFragmentShaderInterlock)
            {
                return "beginInvocationInterlockARB()";
            }
            else if (context.HostCapabilities.SupportsFragmentShaderOrderingIntel)
=======
            if (context.Config.GpuAccessor.QueryHostSupportsFragmentShaderInterlock())
            {
                return "beginInvocationInterlockARB()";
            }
            else if (context.Config.GpuAccessor.QueryHostSupportsFragmentShaderOrderingIntel())
>>>>>>> 1ec71635b (sync with main branch)
            {
                return "beginFragmentShaderOrderingINTEL()";
            }

            return null;
        }

        public static string FSIEnd(CodeGenContext context)
        {
<<<<<<< HEAD
            if (context.HostCapabilities.SupportsFragmentShaderInterlock)
=======
            if (context.Config.GpuAccessor.QueryHostSupportsFragmentShaderInterlock())
>>>>>>> 1ec71635b (sync with main branch)
            {
                return "endInvocationInterlockARB()";
            }

            return null;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
