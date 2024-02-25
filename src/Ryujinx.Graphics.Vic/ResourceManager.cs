<<<<<<< HEAD
using Ryujinx.Graphics.Device;
=======
﻿using Ryujinx.Graphics.Gpu.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Vic.Image;

namespace Ryujinx.Graphics.Vic
{
    readonly struct ResourceManager
    {
<<<<<<< HEAD
        public DeviceMemoryManager MemoryManager { get; }
        public BufferPool<Pixel> SurfacePool { get; }
        public BufferPool<byte> BufferPool { get; }

        public ResourceManager(DeviceMemoryManager mm, BufferPool<Pixel> surfacePool, BufferPool<byte> bufferPool)
        {
            MemoryManager = mm;
=======
        public MemoryManager Gmm { get; }
        public BufferPool<Pixel> SurfacePool { get; }
        public BufferPool<byte> BufferPool { get; }

        public ResourceManager(MemoryManager gmm, BufferPool<Pixel> surfacePool, BufferPool<byte> bufferPool)
        {
            Gmm = gmm;
>>>>>>> 1ec71635b (sync with main branch)
            SurfacePool = surfacePool;
            BufferPool = bufferPool;
        }
    }
}
