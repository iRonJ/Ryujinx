using Ryujinx.HLE.HOS.Kernel.Memory;
using Ryujinx.Horizon.Common;
using System;

namespace Ryujinx.HLE.HOS.Kernel.Common
{
    static class KernelInit
    {
        private readonly struct MemoryRegion
        {
            public ulong Address { get; }
<<<<<<< HEAD
            public ulong Size { get; }
=======
            public ulong Size    { get; }
>>>>>>> 1ec71635b (sync with main branch)

            public ulong EndAddress => Address + Size;

            public MemoryRegion(ulong address, ulong size)
            {
                Address = address;
<<<<<<< HEAD
                Size = size;
=======
                Size    = size;
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public static void InitializeResourceLimit(KResourceLimit resourceLimit, MemorySize size)
        {
<<<<<<< HEAD
            static void EnsureSuccess(Result result)
=======
            void EnsureSuccess(Result result)
>>>>>>> 1ec71635b (sync with main branch)
            {
                if (result != Result.Success)
                {
                    throw new InvalidOperationException($"Unexpected result \"{result}\".");
                }
            }

            ulong ramSize = KSystemControl.GetDramSize(size);

<<<<<<< HEAD
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Memory, (long)ramSize));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Thread, 800));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Event, 700));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.TransferMemory, 200));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Session, 900));
=======
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Memory,         (long)ramSize));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Thread,         800));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Event,          700));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.TransferMemory, 200));
            EnsureSuccess(resourceLimit.SetLimitValue(LimitableResource.Session,        900));
>>>>>>> 1ec71635b (sync with main branch)

            if (!resourceLimit.Reserve(LimitableResource.Memory, 0) ||
                !resourceLimit.Reserve(LimitableResource.Memory, 0x60000))
            {
                throw new InvalidOperationException("Unexpected failure reserving memory on resource limit.");
            }
        }

        public static KMemoryRegionManager[] GetMemoryRegions(MemorySize size, MemoryArrange arrange)
        {
<<<<<<< HEAD
            ulong poolEnd = KSystemControl.GetDramEndAddress(size);
            ulong applicationPoolSize = KSystemControl.GetApplicationPoolSize(arrange);
            ulong appletPoolSize = KSystemControl.GetAppletPoolSize(arrange);
=======
            ulong poolEnd             = KSystemControl.GetDramEndAddress(size);
            ulong applicationPoolSize = KSystemControl.GetApplicationPoolSize(arrange);
            ulong appletPoolSize      = KSystemControl.GetAppletPoolSize(arrange);
>>>>>>> 1ec71635b (sync with main branch)

            MemoryRegion servicePool;
            MemoryRegion nvServicesPool;
            MemoryRegion appletPool;
            MemoryRegion applicationPool;

            ulong nvServicesPoolSize = KSystemControl.GetMinimumNonSecureSystemPoolSize();

            applicationPool = new MemoryRegion(poolEnd - applicationPoolSize, applicationPoolSize);

            ulong nvServicesPoolEnd = applicationPool.Address - appletPoolSize;

            nvServicesPool = new MemoryRegion(nvServicesPoolEnd - nvServicesPoolSize, nvServicesPoolSize);
<<<<<<< HEAD
            appletPool = new MemoryRegion(nvServicesPoolEnd, appletPoolSize);
=======
            appletPool     = new MemoryRegion(nvServicesPoolEnd, appletPoolSize);
>>>>>>> 1ec71635b (sync with main branch)

            // Note: There is an extra region used by the kernel, however
            // since we are doing HLE we are not going to use that memory, so give all
            // the remaining memory space to services.
            ulong servicePoolSize = nvServicesPool.Address - DramMemoryMap.SlabHeapEnd;

            servicePool = new MemoryRegion(DramMemoryMap.SlabHeapEnd, servicePoolSize);

<<<<<<< HEAD
            return new[]
=======
            return new KMemoryRegionManager[]
>>>>>>> 1ec71635b (sync with main branch)
            {
                GetMemoryRegion(applicationPool),
                GetMemoryRegion(appletPool),
                GetMemoryRegion(servicePool),
<<<<<<< HEAD
                GetMemoryRegion(nvServicesPool),
=======
                GetMemoryRegion(nvServicesPool)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static KMemoryRegionManager GetMemoryRegion(MemoryRegion region)
        {
            return new KMemoryRegionManager(region.Address, region.Size, region.EndAddress);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
