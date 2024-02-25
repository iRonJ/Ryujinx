<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Video;
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    internal struct Surface : ISurface
    {
        public ArrayPtr<byte> YBuffer;
        public ArrayPtr<byte> UBuffer;
        public ArrayPtr<byte> VBuffer;

<<<<<<< HEAD
        public readonly unsafe Plane YPlane => new((IntPtr)YBuffer.ToPointer(), YBuffer.Length);
        public readonly unsafe Plane UPlane => new((IntPtr)UBuffer.ToPointer(), UBuffer.Length);
        public readonly unsafe Plane VPlane => new((IntPtr)VBuffer.ToPointer(), VBuffer.Length);

        public readonly FrameField Field => FrameField.Progressive;
=======
        public unsafe Plane YPlane => new Plane((IntPtr)YBuffer.ToPointer(), YBuffer.Length);
        public unsafe Plane UPlane => new Plane((IntPtr)UBuffer.ToPointer(), UBuffer.Length);
        public unsafe Plane VPlane => new Plane((IntPtr)VBuffer.ToPointer(), VBuffer.Length);

        public FrameField Field => FrameField.Progressive;
>>>>>>> 1ec71635b (sync with main branch)

        public int Width { get; }
        public int Height { get; }
        public int AlignedWidth { get; }
        public int AlignedHeight { get; }
        public int Stride { get; }
        public int UvWidth { get; }
        public int UvHeight { get; }
        public int UvAlignedWidth { get; }
        public int UvAlignedHeight { get; }
        public int UvStride { get; }
<<<<<<< HEAD

        public bool HighBd { get; }
=======
        public bool HighBd => false;
>>>>>>> 1ec71635b (sync with main branch)

        private readonly IntPtr _pointer;

        public Surface(int width, int height)
        {
<<<<<<< HEAD
            HighBd = false;

            const int Border = 32;
            const int SsX = 1;
            const int SsY = 1;

            int alignedWidth = (width + 7) & ~7;
            int alignedHeight = (height + 7) & ~7;
            int yStride = ((alignedWidth + 2 * Border) + 31) & ~31;
            int yplaneSize = (alignedHeight + 2 * Border) * yStride;
            int uvWidth = alignedWidth >> SsX;
            int uvHeight = alignedHeight >> SsY;
            int uvStride = yStride >> SsX;
            int uvBorderW = Border >> SsX;
            int uvBorderH = Border >> SsY;
            int uvplaneSize = (uvHeight + 2 * uvBorderH) * uvStride;

            int frameSize = (HighBd ? 2 : 1) * (yplaneSize + 2 * uvplaneSize);
=======
            const int border = 32;
            const int ssX = 1;
            const int ssY = 1;
            const bool highbd = false;

            int alignedWidth = (width + 7) & ~7;
            int alignedHeight = (height + 7) & ~7;
            int yStride = ((alignedWidth + 2 * border) + 31) & ~31;
            int yplaneSize = (alignedHeight + 2 * border) * yStride;
            int uvWidth = alignedWidth >> ssX;
            int uvHeight = alignedHeight >> ssY;
            int uvStride = yStride >> ssX;
            int uvBorderW = border >> ssX;
            int uvBorderH = border >> ssY;
            int uvplaneSize = (uvHeight + 2 * uvBorderH) * uvStride;

            int frameSize = (highbd ? 2 : 1) * (yplaneSize + 2 * uvplaneSize);
>>>>>>> 1ec71635b (sync with main branch)

            IntPtr pointer = Marshal.AllocHGlobal(frameSize);
            _pointer = pointer;
            Width = width;
            Height = height;
            AlignedWidth = alignedWidth;
            AlignedHeight = alignedHeight;
            Stride = yStride;
<<<<<<< HEAD
            UvWidth = (width + SsX) >> SsX;
            UvHeight = (height + SsY) >> SsY;
=======
            UvWidth = (width + ssX) >> ssX;
            UvHeight = (height + ssY) >> ssY;
>>>>>>> 1ec71635b (sync with main branch)
            UvAlignedWidth = uvWidth;
            UvAlignedHeight = uvHeight;
            UvStride = uvStride;

<<<<<<< HEAD
            ArrayPtr<byte> NewPlane(int start, int size, int planeBorder)
            {
                return new ArrayPtr<byte>(pointer + start + planeBorder, size - planeBorder);
            }

            YBuffer = NewPlane(0, yplaneSize, (Border * yStride) + Border);
=======
            ArrayPtr<byte> NewPlane(int start, int size, int border)
            {
                return new ArrayPtr<byte>(pointer + start + border, size - border);
            }

            YBuffer = NewPlane(0, yplaneSize, (border * yStride) + border);
>>>>>>> 1ec71635b (sync with main branch)
            UBuffer = NewPlane(yplaneSize, uvplaneSize, (uvBorderH * uvStride) + uvBorderW);
            VBuffer = NewPlane(yplaneSize + uvplaneSize, uvplaneSize, (uvBorderH * uvStride) + uvBorderW);
        }

<<<<<<< HEAD
        public readonly void Dispose()
=======
        public void Dispose()
>>>>>>> 1ec71635b (sync with main branch)
        {
            Marshal.FreeHGlobal(_pointer);
        }
    }
}
