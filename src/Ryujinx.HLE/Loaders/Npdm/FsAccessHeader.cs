<<<<<<< HEAD
using Ryujinx.HLE.Exceptions;
=======
﻿using Ryujinx.HLE.Exceptions;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.IO;

namespace Ryujinx.HLE.Loaders.Npdm
{
    class FsAccessHeader
    {
<<<<<<< HEAD
        public int Version { get; private set; }
=======
        public int   Version            { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)
        public ulong PermissionsBitmask { get; private set; }

        public FsAccessHeader(Stream stream, int offset, int size)
        {
            stream.Seek(offset, SeekOrigin.Begin);

<<<<<<< HEAD
            BinaryReader reader = new(stream);

            Version = reader.ReadInt32();
=======
            BinaryReader reader = new BinaryReader(stream);

            Version            = reader.ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)
            PermissionsBitmask = reader.ReadUInt64();

            int dataSize = reader.ReadInt32();

            if (dataSize != 0x1c)
            {
                throw new InvalidNpdmException("FsAccessHeader is corrupted!");
            }
<<<<<<< HEAD
#pragma warning disable IDE0059 // Remove unnecessary value assignment
            int contentOwnerIdSize = reader.ReadInt32();
#pragma warning restore IDE0059
=======

            int contentOwnerIdSize        = reader.ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)
            int dataAndContentOwnerIdSize = reader.ReadInt32();

            if (dataAndContentOwnerIdSize != 0x1c)
            {
                throw new NotImplementedException("ContentOwnerId section is not implemented!");
            }
        }
    }
}
