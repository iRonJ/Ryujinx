<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Caps.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x20)]
    struct ApplicationAlbumEntry
    {
<<<<<<< HEAD
        public ulong Size;
        public ulong TitleId;
        public AlbumFileDateTime AlbumFileDateTime;
        public AlbumStorage AlbumStorage;
        public ContentType ContentType;
        public Array5<byte> Padding;
        public byte Unknown0x1f; // Always 1
    }
}
=======
        public ulong             Size;
        public ulong             TitleId;
        public AlbumFileDateTime AlbumFileDateTime;
        public AlbumStorage      AlbumStorage;
        public ContentType       ContentType;
        public Array5<byte>      Padding;
        public byte              Unknown0x1f; // Always 1
    }
}
>>>>>>> 1ec71635b (sync with main branch)
