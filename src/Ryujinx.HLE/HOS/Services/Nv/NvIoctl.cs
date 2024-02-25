<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv
{
    [StructLayout(LayoutKind.Sequential)]
    struct NvIoctl
    {
        public const int NvHostCustomMagic = 0x00;
<<<<<<< HEAD
        public const int NvMapCustomMagic = 0x01;
        public const int NvGpuAsMagic = 0x41;
        public const int NvGpuMagic = 0x47;
        public const int NvHostMagic = 0x48;

        private const int NumberBits = 8;
        private const int TypeBits = 8;
        private const int SizeBits = 14;
        private const int DirectionBits = 2;

        private const int NumberShift = 0;
        private const int TypeShift = NumberShift + NumberBits;
        private const int SizeShift = TypeShift + TypeBits;
        private const int DirectionShift = SizeShift + SizeBits;

        private const int NumberMask = (1 << NumberBits) - 1;
        private const int TypeMask = (1 << TypeBits) - 1;
        private const int SizeMask = (1 << SizeBits) - 1;
=======
        public const int NvMapCustomMagic  = 0x01;
        public const int NvGpuAsMagic      = 0x41;
        public const int NvGpuMagic        = 0x47;
        public const int NvHostMagic       = 0x48;

        private const int NumberBits    = 8;
        private const int TypeBits      = 8;
        private const int SizeBits      = 14;
        private const int DirectionBits = 2;

        private const int NumberShift    = 0;
        private const int TypeShift      = NumberShift + NumberBits;
        private const int SizeShift      = TypeShift + TypeBits; 
        private const int DirectionShift = SizeShift + SizeBits;

        private const int NumberMask    = (1 << NumberBits) - 1;
        private const int TypeMask      = (1 << TypeBits) - 1;
        private const int SizeMask      = (1 << SizeBits) - 1;
>>>>>>> 1ec71635b (sync with main branch)
        private const int DirectionMask = (1 << DirectionBits) - 1;

        [Flags]
        public enum Direction : uint
        {
<<<<<<< HEAD
            None = 0,
            Read = 1,
=======
            None  = 0,
            Read  = 1,
>>>>>>> 1ec71635b (sync with main branch)
            Write = 2,
        }

        public uint RawValue;

<<<<<<< HEAD
        public readonly uint Number => (RawValue >> NumberShift) & NumberMask;
        public readonly uint Type => (RawValue >> TypeShift) & TypeMask;
        public readonly uint Size => (RawValue >> SizeShift) & SizeMask;
        public readonly Direction DirectionValue => (Direction)((RawValue >> DirectionShift) & DirectionMask);
=======
        public uint      Number         => (RawValue >> NumberShift) & NumberMask;
        public uint      Type           => (RawValue >> TypeShift) & TypeMask;
        public uint      Size           => (RawValue >> SizeShift) & SizeMask;
        public Direction DirectionValue => (Direction)((RawValue >> DirectionShift) & DirectionMask);
>>>>>>> 1ec71635b (sync with main branch)
    }
}
