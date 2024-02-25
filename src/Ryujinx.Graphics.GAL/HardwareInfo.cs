<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL
=======
﻿namespace Ryujinx.Graphics.GAL
>>>>>>> 1ec71635b (sync with main branch)
{
    public readonly struct HardwareInfo
    {
        public string GpuVendor { get; }
        public string GpuModel { get; }
<<<<<<< HEAD
        public string GpuDriver { get; }

        public HardwareInfo(string gpuVendor, string gpuModel, string gpuDriver)
        {
            GpuVendor = gpuVendor;
            GpuModel = gpuModel;
            GpuDriver = gpuDriver;
=======

        public HardwareInfo(string gpuVendor, string gpuModel)
        {
            GpuVendor = gpuVendor;
            GpuModel = gpuModel;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
