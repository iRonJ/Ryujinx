<<<<<<< HEAD
using Ryujinx.Graphics.Nvdec.FFmpeg.Native;
=======
﻿using Ryujinx.Graphics.Nvdec.FFmpeg.Native;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Video;
using System;

namespace Ryujinx.Graphics.Nvdec.FFmpeg
{
    unsafe class Surface : ISurface
    {
        public AVFrame* Frame { get; }

        public int RequestedWidth { get; }
        public int RequestedHeight { get; }

<<<<<<< HEAD
        public Plane YPlane => new((IntPtr)Frame->Data[0], Stride * Height);
        public Plane UPlane => new((IntPtr)Frame->Data[1], UvStride * UvHeight);
        public Plane VPlane => new((IntPtr)Frame->Data[2], UvStride * UvHeight);
=======
        public Plane YPlane => new Plane((IntPtr)Frame->Data[0], Stride * Height);
        public Plane UPlane => new Plane((IntPtr)Frame->Data[1], UvStride * UvHeight);
        public Plane VPlane => new Plane((IntPtr)Frame->Data[2], UvStride * UvHeight);
>>>>>>> 1ec71635b (sync with main branch)

        public FrameField Field => Frame->InterlacedFrame != 0 ? FrameField.Interlaced : FrameField.Progressive;

        public int Width => Frame->Width;
        public int Height => Frame->Height;
        public int Stride => Frame->LineSize[0];
        public int UvWidth => (Width + 1) >> 1;
        public int UvHeight => (Height + 1) >> 1;
        public int UvStride => Frame->LineSize[1];

        public Surface(int width, int height)
        {
            RequestedWidth = width;
            RequestedHeight = height;

            Frame = FFmpegApi.av_frame_alloc();
        }

        public void Dispose()
        {
            FFmpegApi.av_frame_unref(Frame);
            FFmpegApi.av_free(Frame);
        }
    }
}
