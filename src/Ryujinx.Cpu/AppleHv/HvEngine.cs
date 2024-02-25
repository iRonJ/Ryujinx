using ARMeilleure.Memory;
<<<<<<< HEAD
using System.Runtime.Versioning;

namespace Ryujinx.Cpu.AppleHv
{
    [SupportedOSPlatform("macos")]
=======

namespace Ryujinx.Cpu.AppleHv
{
>>>>>>> 1ec71635b (sync with main branch)
    public class HvEngine : ICpuEngine
    {
        private readonly ITickSource _tickSource;

        public HvEngine(ITickSource tickSource)
        {
            _tickSource = tickSource;
        }

        /// <inheritdoc/>
        public ICpuContext CreateCpuContext(IMemoryManager memoryManager, bool for64Bit)
        {
            return new HvCpuContext(_tickSource, memoryManager, for64Bit);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
