using Silk.NET.Vulkan;
using System;
<<<<<<< HEAD
=======
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    public enum SpecConstType
    {
        Bool32,
        Int16,
        Int32,
        Int64,
        Float16,
        Float32,
<<<<<<< HEAD
        Float64,
=======
        Float64
>>>>>>> 1ec71635b (sync with main branch)
    }

    sealed class SpecDescription
    {
        public readonly SpecializationInfo Info;
        public readonly SpecializationMapEntry[] Map;

        // For mapping a simple packed struct or single entry
        public SpecDescription(params (uint Id, SpecConstType Type)[] description)
        {
            int count = description.Length;
            Map = new SpecializationMapEntry[count];

            uint structSize = 0;

            for (int i = 0; i < Map.Length; ++i)
            {
                var typeSize = SizeOf(description[i].Type);
                Map[i] = new SpecializationMapEntry(description[i].Id, structSize, typeSize);
                structSize += typeSize;
            }

<<<<<<< HEAD
            Info = new SpecializationInfo
            {
                DataSize = structSize,
                MapEntryCount = (uint)count,
=======
            Info = new SpecializationInfo()
            {
                DataSize = structSize,
                MapEntryCount = (uint)count
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        // For advanced mapping with overlapping or staggered fields
        public SpecDescription(SpecializationMapEntry[] map)
        {
            Map = map;

            uint structSize = 0;
            for (int i = 0; i < map.Length; ++i)
            {
                structSize = Math.Max(structSize, map[i].Offset + (uint)map[i].Size);
            }

<<<<<<< HEAD
            Info = new SpecializationInfo
            {
                DataSize = structSize,
                MapEntryCount = (uint)map.Length,
=======
            Info = new SpecializationInfo()
            {
                DataSize = structSize,
                MapEntryCount = (uint)map.Length
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static uint SizeOf(SpecConstType type) => type switch
        {
            SpecConstType.Int16 or SpecConstType.Float16 => 2,
            SpecConstType.Bool32 or SpecConstType.Int32 or SpecConstType.Float32 => 4,
            SpecConstType.Int64 or SpecConstType.Float64 => 8,
<<<<<<< HEAD
            _ => throw new ArgumentOutOfRangeException(nameof(type)),
=======
            _ => throw new ArgumentOutOfRangeException(nameof(type))
>>>>>>> 1ec71635b (sync with main branch)
        };

        private SpecDescription()
        {
            Info = new();
        }

        public static readonly SpecDescription Empty = new();
    }

    readonly struct SpecData : IRefEquatable<SpecData>
    {
        private readonly byte[] _data;
        private readonly int _hash;

        public int Length => _data.Length;
        public ReadOnlySpan<byte> Span => _data.AsSpan();
        public override int GetHashCode() => _hash;

        public SpecData(ReadOnlySpan<byte> data)
        {
            _data = new byte[data.Length];
            data.CopyTo(_data);

            var hc = new HashCode();
            hc.AddBytes(data);
            _hash = hc.ToHashCode();
        }

        public override bool Equals(object obj) => obj is SpecData other && Equals(other);
        public bool Equals(ref SpecData other) => _data.AsSpan().SequenceEqual(other._data);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
