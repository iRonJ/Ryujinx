<<<<<<< HEAD
using System;
using System.Diagnostics.CodeAnalysis;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Ryujinx.Graphics.Texture.Utils
{
    struct RgbaColor32 : IEquatable<RgbaColor32>
    {
        private Vector128<int> _color;

        public int R
        {
<<<<<<< HEAD
            readonly get => _color.GetElement(0);
=======
            get => _color.GetElement(0);
>>>>>>> 1ec71635b (sync with main branch)
            set => _color = _color.WithElement(0, value);
        }

        public int G
        {
<<<<<<< HEAD
            readonly get => _color.GetElement(1);
=======
            get => _color.GetElement(1);
>>>>>>> 1ec71635b (sync with main branch)
            set => _color = _color.WithElement(1, value);
        }

        public int B
        {
<<<<<<< HEAD
            readonly get => _color.GetElement(2);
=======
            get => _color.GetElement(2);
>>>>>>> 1ec71635b (sync with main branch)
            set => _color = _color.WithElement(2, value);
        }

        public int A
        {
<<<<<<< HEAD
            readonly get => _color.GetElement(3);
=======
            get => _color.GetElement(3);
>>>>>>> 1ec71635b (sync with main branch)
            set => _color = _color.WithElement(3, value);
        }

        public RgbaColor32(Vector128<int> color)
        {
            _color = color;
        }

        public RgbaColor32(int r, int g, int b, int a)
        {
            _color = Vector128.Create(r, g, b, a);
        }

        public RgbaColor32(int scalar)
        {
            _color = Vector128.Create(scalar);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RgbaColor32 operator +(RgbaColor32 x, RgbaColor32 y)
        {
            if (Sse2.IsSupported)
            {
                return new RgbaColor32(Sse2.Add(x._color, y._color));
            }
            else
            {
                return new RgbaColor32(x.R + y.R, x.G + y.G, x.B + y.B, x.A + y.A);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RgbaColor32 operator -(RgbaColor32 x, RgbaColor32 y)
        {
            if (Sse2.IsSupported)
            {
                return new RgbaColor32(Sse2.Subtract(x._color, y._color));
            }
            else
            {
                return new RgbaColor32(x.R - y.R, x.G - y.G, x.B - y.B, x.A - y.A);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RgbaColor32 operator *(RgbaColor32 x, RgbaColor32 y)
        {
            if (Sse41.IsSupported)
            {
                return new RgbaColor32(Sse41.MultiplyLow(x._color, y._color));
            }
            else
            {
                return new RgbaColor32(x.R * y.R, x.G * y.G, x.B * y.B, x.A * y.A);
            }
        }

        public static RgbaColor32 operator /(RgbaColor32 x, RgbaColor32 y)
        {
            return new RgbaColor32(x.R / y.R, x.G / y.G, x.B / y.B, x.A / y.A);
        }

        public static RgbaColor32 DivideGuarded(RgbaColor32 x, RgbaColor32 y, int resultIfZero)
        {
            return new RgbaColor32(
                DivideGuarded(x.R, y.R, resultIfZero),
                DivideGuarded(x.G, y.G, resultIfZero),
                DivideGuarded(x.B, y.B, resultIfZero),
                DivideGuarded(x.A, y.A, resultIfZero));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        public static RgbaColor32 operator <<(RgbaColor32 x, [ConstantExpected] byte shift)
        {
            if (Sse2.IsSupported)
            {
                return new RgbaColor32(Sse2.ShiftLeftLogical(x._color, shift));
=======
        public static RgbaColor32 operator <<(RgbaColor32 x, int shift)
        {
            if (Sse2.IsSupported)
            {
                return new RgbaColor32(Sse2.ShiftLeftLogical(x._color, (byte)shift));
>>>>>>> 1ec71635b (sync with main branch)
            }
            else
            {
                return new RgbaColor32(x.R << shift, x.G << shift, x.B << shift, x.A << shift);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        public static RgbaColor32 operator >>(RgbaColor32 x, [ConstantExpected] byte shift)
        {
            if (Sse2.IsSupported)
            {
                return new RgbaColor32(Sse2.ShiftRightLogical(x._color, shift));
=======
        public static RgbaColor32 operator >>(RgbaColor32 x, int shift)
        {
            if (Sse2.IsSupported)
            {
                return new RgbaColor32(Sse2.ShiftRightLogical(x._color, (byte)shift));
>>>>>>> 1ec71635b (sync with main branch)
            }
            else
            {
                return new RgbaColor32(x.R >> shift, x.G >> shift, x.B >> shift, x.A >> shift);
            }
        }

        public static bool operator ==(RgbaColor32 x, RgbaColor32 y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(RgbaColor32 x, RgbaColor32 y)
        {
            return !x.Equals(y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Dot(RgbaColor32 x, RgbaColor32 y)
        {
            if (Sse41.IsSupported)
            {
                Vector128<int> product = Sse41.MultiplyLow(x._color, y._color);
                Vector128<int> sum = Ssse3.HorizontalAdd(product, product);
                sum = Ssse3.HorizontalAdd(sum, sum);
                return sum.GetElement(0);
            }
            else
            {
                return x.R * y.R + x.G * y.G + x.B * y.B + x.A * y.A;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RgbaColor32 Max(RgbaColor32 x, RgbaColor32 y)
        {
            if (Sse41.IsSupported)
            {
                return new RgbaColor32(Sse41.Max(x._color, y._color));
            }
            else
            {
                return new RgbaColor32(Math.Max(x.R, y.R), Math.Max(x.G, y.G), Math.Max(x.B, y.B), Math.Max(x.A, y.A));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RgbaColor32 Min(RgbaColor32 x, RgbaColor32 y)
        {
            if (Sse41.IsSupported)
            {
                return new RgbaColor32(Sse41.Min(x._color, y._color));
            }
            else
            {
                return new RgbaColor32(Math.Min(x.R, y.R), Math.Min(x.G, y.G), Math.Min(x.B, y.B), Math.Min(x.A, y.A));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        public readonly RgbaColor8 GetColor8()
=======
        public RgbaColor8 GetColor8()
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (Sse41.IsSupported)
            {
                Vector128<int> temp = _color;
                Vector128<ushort> color16 = Sse41.PackUnsignedSaturate(temp, temp);
                Vector128<byte> color8 = Sse2.PackUnsignedSaturate(color16.AsInt16(), color16.AsInt16());
                uint color = color8.AsUInt32().GetElement(0);
                return Unsafe.As<uint, RgbaColor8>(ref color);
            }
            else
            {
                return new RgbaColor8(ClampByte(R), ClampByte(G), ClampByte(B), ClampByte(A));
            }
        }

        private static int DivideGuarded(int dividend, int divisor, int resultIfZero)
        {
            if (divisor == 0)
            {
                return resultIfZero;
            }

            return dividend / divisor;
        }

        private static byte ClampByte(int value)
        {
            return (byte)Math.Clamp(value, 0, 255);
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return HashCode.Combine(R, G, B, A);
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is RgbaColor32 other && Equals(other);
        }

<<<<<<< HEAD
        public readonly bool Equals(RgbaColor32 other)
=======
        public bool Equals(RgbaColor32 other)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _color.Equals(other._color);
        }
    }
}
