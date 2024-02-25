using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvMap;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct GraphicBuffer : IFlattenable
    {
        public GraphicBufferHeader Header;
<<<<<<< HEAD
        public NvGraphicBuffer Buffer;

        public readonly int Width => Header.Width;
        public readonly int Height => Header.Height;
        public readonly PixelFormat Format => Header.Format;
        public readonly int Usage => Header.Usage;

        public readonly Rect ToRect()
=======
        public NvGraphicBuffer     Buffer;

        public int Width => Header.Width;
        public int Height => Header.Height;
        public PixelFormat Format => Header.Format;
        public int Usage => Header.Usage;

        public Rect ToRect()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return new Rect(Width, Height);
        }

        public void Flatten(Parcel parcel)
        {
            parcel.WriteUnmanagedType(ref Header);
            parcel.WriteUnmanagedType(ref Buffer);
        }

        public void Unflatten(Parcel parcel)
        {
            Header = parcel.ReadUnmanagedType<GraphicBufferHeader>();

            int expectedSize = Unsafe.SizeOf<NvGraphicBuffer>() / 4;

            if (Header.IntsCount != expectedSize)
            {
                throw new NotImplementedException($"Unexpected Graphic Buffer ints count (expected 0x{expectedSize:x}, found 0x{Header.IntsCount:x})");
            }

            Buffer = parcel.ReadUnmanagedType<NvGraphicBuffer>();
        }

<<<<<<< HEAD
        public readonly void IncrementNvMapHandleRefCount(ulong pid)
        {
            NvMapDeviceFile.IncrementMapRefCount(pid, Buffer.NvMapId);

            for (int i = 0; i < NvGraphicBufferSurfaceArray.Length; i++)
=======
        public void IncrementNvMapHandleRefCount(ulong pid)
        {
            NvMapDeviceFile.IncrementMapRefCount(pid, Buffer.NvMapId);

            for (int i = 0; i < Buffer.Surfaces.Length; i++)
>>>>>>> 1ec71635b (sync with main branch)
            {
                NvMapDeviceFile.IncrementMapRefCount(pid, Buffer.Surfaces[i].NvMapHandle);
            }
        }

<<<<<<< HEAD
        public readonly void DecrementNvMapHandleRefCount(ulong pid)
        {
            NvMapDeviceFile.DecrementMapRefCount(pid, Buffer.NvMapId);

            for (int i = 0; i < NvGraphicBufferSurfaceArray.Length; i++)
=======
        public void DecrementNvMapHandleRefCount(ulong pid)
        {
            NvMapDeviceFile.DecrementMapRefCount(pid, Buffer.NvMapId);

            for (int i = 0; i < Buffer.Surfaces.Length; i++)
>>>>>>> 1ec71635b (sync with main branch)
            {
                NvMapDeviceFile.DecrementMapRefCount(pid, Buffer.Surfaces[i].NvMapHandle);
            }
        }

<<<<<<< HEAD
        public readonly uint GetFlattenedSize()
=======
        public uint GetFlattenedSize()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (uint)Unsafe.SizeOf<GraphicBuffer>();
        }

<<<<<<< HEAD
        public readonly uint GetFdCount()
=======
        public uint GetFdCount()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 0;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
