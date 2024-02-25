using LibHac.Fs;
using LibHac.Tools.Ro;
using System;

namespace Ryujinx.HLE.Loaders.Executables
{
    class NroExecutable : Nro, IExecutable
    {
        public byte[] Program { get; }
        public Span<byte> Text => Program.AsSpan((int)TextOffset, (int)Header.NroSegments[0].Size);
<<<<<<< HEAD
        public Span<byte> Ro => Program.AsSpan((int)RoOffset, (int)Header.NroSegments[1].Size);
        public Span<byte> Data => Program.AsSpan((int)DataOffset, (int)Header.NroSegments[2].Size);

        public uint TextOffset => Header.NroSegments[0].FileOffset;
        public uint RoOffset => Header.NroSegments[1].FileOffset;
        public uint DataOffset => Header.NroSegments[2].FileOffset;
        public uint BssOffset => DataOffset + (uint)Data.Length;
        public uint BssSize => Header.BssSize;

        public uint Mod0Offset => (uint)Start.Mod0Offset;
        public uint FileSize => Header.Size;

        public ulong SourceAddress { get; private set; }
        public ulong BssAddress { get; private set; }
=======
        public Span<byte> Ro   => Program.AsSpan((int)RoOffset,   (int)Header.NroSegments[1].Size);
        public Span<byte> Data => Program.AsSpan((int)DataOffset, (int)Header.NroSegments[2].Size);

        public uint TextOffset => Header.NroSegments[0].FileOffset;
        public uint RoOffset   => Header.NroSegments[1].FileOffset;
        public uint DataOffset => Header.NroSegments[2].FileOffset;
        public uint BssOffset  => DataOffset + (uint)Data.Length;
        public uint BssSize    => Header.BssSize;

        public uint Mod0Offset => (uint)Start.Mod0Offset;
        public uint FileSize   => Header.Size;

        public ulong SourceAddress { get; private set; }
        public ulong BssAddress    { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public NroExecutable(IStorage inStorage, ulong sourceAddress = 0, ulong bssAddress = 0) : base(inStorage)
        {
            Program = new byte[FileSize];

            SourceAddress = sourceAddress;
<<<<<<< HEAD
            BssAddress = bssAddress;

            OpenNroSegment(NroSegmentType.Text, false).Read(0, Text);
            OpenNroSegment(NroSegmentType.Ro, false).Read(0, Ro);
            OpenNroSegment(NroSegmentType.Data, false).Read(0, Data);
        }
    }
}
=======
            BssAddress    = bssAddress;

            OpenNroSegment(NroSegmentType.Text, false).Read(0, Text);
            OpenNroSegment(NroSegmentType.Ro  , false).Read(0, Ro);
            OpenNroSegment(NroSegmentType.Data, false).Read(0, Data);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
