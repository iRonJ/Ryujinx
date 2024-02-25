<<<<<<< HEAD
using Ryujinx.Common.Memory;
using Ryujinx.Common.Utilities;
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = Size)]
    struct Ver3StoreData
    {
        public const int Size = 0x60;

<<<<<<< HEAD
        private Array96<byte> _storage;

        public Span<byte> Storage => _storage.AsSpan();
=======
        private byte _storage;

        public Span<byte> Storage => MemoryMarshal.CreateSpan(ref _storage, Size);
>>>>>>> 1ec71635b (sync with main branch)

        // TODO: define all getters/setters
    }
}
