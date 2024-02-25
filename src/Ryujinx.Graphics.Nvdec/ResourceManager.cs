<<<<<<< HEAD
using Ryujinx.Graphics.Device;
=======
﻿using Ryujinx.Graphics.Gpu.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Nvdec.Image;

namespace Ryujinx.Graphics.Nvdec
{
    readonly struct ResourceManager
    {
<<<<<<< HEAD
        public DeviceMemoryManager MemoryManager { get; }
        public SurfaceCache Cache { get; }

        public ResourceManager(DeviceMemoryManager mm, SurfaceCache cache)
        {
            MemoryManager = mm;
=======
        public MemoryManager Gmm { get; }
        public SurfaceCache Cache { get; }

        public ResourceManager(MemoryManager gmm, SurfaceCache cache)
        {
            Gmm = gmm;
>>>>>>> 1ec71635b (sync with main branch)
            Cache = cache;
        }
    }
}
