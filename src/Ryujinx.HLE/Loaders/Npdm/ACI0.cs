using Ryujinx.HLE.Exceptions;
using System.IO;

namespace Ryujinx.HLE.Loaders.Npdm
{
    public class Aci0
    {
        private const int Aci0Magic = 'A' << 0 | 'C' << 8 | 'I' << 16 | '0' << 24;

        public ulong TitleId { get; set; }

<<<<<<< HEAD
        public int FsVersion { get; private set; }
        public ulong FsPermissionsBitmask { get; private set; }

        public ServiceAccessControl ServiceAccessControl { get; private set; }
        public KernelAccessControl KernelAccessControl { get; private set; }
=======
        public int   FsVersion            { get; private set; }
        public ulong FsPermissionsBitmask { get; private set; }

        public ServiceAccessControl ServiceAccessControl { get; private set; }
        public KernelAccessControl  KernelAccessControl  { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public Aci0(Stream stream, int offset)
        {
            stream.Seek(offset, SeekOrigin.Begin);

<<<<<<< HEAD
            BinaryReader reader = new(stream);
=======
            BinaryReader reader = new BinaryReader(stream);
>>>>>>> 1ec71635b (sync with main branch)

            if (reader.ReadInt32() != Aci0Magic)
            {
                throw new InvalidNpdmException("ACI0 Stream doesn't contain ACI0 section!");
            }

            stream.Seek(0xc, SeekOrigin.Current);

            TitleId = reader.ReadUInt64();

            // Reserved.
            stream.Seek(8, SeekOrigin.Current);

<<<<<<< HEAD
            int fsAccessHeaderOffset = reader.ReadInt32();
            int fsAccessHeaderSize = reader.ReadInt32();
            int serviceAccessControlOffset = reader.ReadInt32();
            int serviceAccessControlSize = reader.ReadInt32();
            int kernelAccessControlOffset = reader.ReadInt32();
            int kernelAccessControlSize = reader.ReadInt32();

            FsAccessHeader fsAccessHeader = new(stream, offset + fsAccessHeaderOffset, fsAccessHeaderSize);

            FsVersion = fsAccessHeader.Version;
=======
            int fsAccessHeaderOffset       = reader.ReadInt32();
            int fsAccessHeaderSize         = reader.ReadInt32();
            int serviceAccessControlOffset = reader.ReadInt32();
            int serviceAccessControlSize   = reader.ReadInt32();
            int kernelAccessControlOffset  = reader.ReadInt32();
            int kernelAccessControlSize    = reader.ReadInt32();

            FsAccessHeader fsAccessHeader = new FsAccessHeader(stream, offset + fsAccessHeaderOffset, fsAccessHeaderSize);

            FsVersion            = fsAccessHeader.Version;
>>>>>>> 1ec71635b (sync with main branch)
            FsPermissionsBitmask = fsAccessHeader.PermissionsBitmask;

            ServiceAccessControl = new ServiceAccessControl(stream, offset + serviceAccessControlOffset, serviceAccessControlSize);

            KernelAccessControl = new KernelAccessControl(stream, offset + kernelAccessControlOffset, kernelAccessControlSize);
        }
    }
}
