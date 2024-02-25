<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;

namespace Ryujinx.Audio.Renderer.Common
{
    /// <summary>
    /// Update data header used for input and output of <see cref="Server.AudioRenderSystem.Update(System.Memory{byte}, System.Memory{byte}, System.ReadOnlyMemory{byte})"/>.
    /// </summary>
    public struct UpdateDataHeader
    {
        public int Revision;
        public uint BehaviourSize;
        public uint MemoryPoolsSize;
        public uint VoicesSize;
        public uint VoiceResourcesSize;
        public uint EffectsSize;
        public uint MixesSize;
        public uint SinksSize;
        public uint PerformanceBufferSize;
        public uint Unknown24;
        public uint RenderInfoSize;

<<<<<<< HEAD
#pragma warning disable IDE0051, CS0169 // Remove unused field
        private Array4<int> _reserved;
#pragma warning restore IDE0051, CS0169
=======
        private unsafe fixed int _reserved[4];
>>>>>>> 1ec71635b (sync with main branch)

        public uint TotalSize;

        public void Initialize(int revision)
        {
            Revision = revision;

            TotalSize = (uint)Unsafe.SizeOf<UpdateDataHeader>();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
