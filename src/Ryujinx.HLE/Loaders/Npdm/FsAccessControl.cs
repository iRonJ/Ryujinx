<<<<<<< HEAD
using System.IO;
=======
﻿using System.IO;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.Loaders.Npdm
{
    public class FsAccessControl
    {
<<<<<<< HEAD
        public int Version { get; private set; }
        public ulong PermissionsBitmask { get; private set; }
        public int Unknown1 { get; private set; }
        public int Unknown2 { get; private set; }
        public int Unknown3 { get; private set; }
        public int Unknown4 { get; private set; }
=======
        public int   Version            { get; private set; }
        public ulong PermissionsBitmask { get; private set; }
        public int   Unknown1           { get; private set; }
        public int   Unknown2           { get; private set; }
        public int   Unknown3           { get; private set; }
        public int   Unknown4           { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public FsAccessControl(Stream stream, int offset, int size)
        {
            stream.Seek(offset, SeekOrigin.Begin);

<<<<<<< HEAD
            BinaryReader reader = new(stream);

            Version = reader.ReadInt32();
            PermissionsBitmask = reader.ReadUInt64();
            Unknown1 = reader.ReadInt32();
            Unknown2 = reader.ReadInt32();
            Unknown3 = reader.ReadInt32();
            Unknown4 = reader.ReadInt32();
=======
            BinaryReader reader = new BinaryReader(stream);

            Version            = reader.ReadInt32();
            PermissionsBitmask = reader.ReadUInt64();
            Unknown1           = reader.ReadInt32();
            Unknown2           = reader.ReadInt32();
            Unknown3           = reader.ReadInt32();
            Unknown4           = reader.ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
