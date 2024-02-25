<<<<<<< HEAD
=======
﻿using System;

>>>>>>> 1ec71635b (sync with main branch)
using AVBufferRef = System.IntPtr;

namespace Ryujinx.Graphics.Nvdec.FFmpeg.Native
{
    struct AVPacket
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
        public unsafe AVBufferRef* Buf;
=======
#pragma warning disable CS0649
        public unsafe AVBufferRef *Buf;
>>>>>>> 1ec71635b (sync with main branch)
        public long Pts;
        public long Dts;
        public unsafe byte* Data;
        public int Size;
        public int StreamIndex;
        public int Flags;
<<<<<<< HEAD
        public AVBufferRef SizeData;
        public int SizeDataElems;
        public long Duration;
        public long Position;
        public AVBufferRef Opaque;
        public unsafe AVBufferRef* OpaqueRef;
        public AVRational TimeBase;
#pragma warning restore CS0649
    }
}
=======
        public IntPtr SizeData;
        public int SizeDataElems;
        public long Duration;
        public long Position;
        public IntPtr Opaque;
        public unsafe AVBufferRef *OpaqueRef;
        public AVRational TimeBase;
#pragma warning restore CS0649
    }
}
>>>>>>> 1ec71635b (sync with main branch)
