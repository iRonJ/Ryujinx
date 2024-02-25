<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    struct Rect : IEquatable<Rect>
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

<<<<<<< HEAD
        public readonly int Width => Right - Left;
        public readonly int Height => Bottom - Top;

        public Rect(int width, int height)
        {
            Left = 0;
            Top = 0;
            Right = width;
            Bottom = height;
        }

        public readonly bool IsEmpty()
=======
        public int Width => Right - Left;
        public int Height => Bottom - Top;

        public Rect(int width, int height)
        {
            Left   = 0;
            Top    = 0;
            Right  = width;
            Bottom = height;
        }

        public bool IsEmpty()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Width <= 0 || Height <= 0;
        }

        public bool Intersect(Rect other, out Rect result)
        {
            result = new Rect
            {
<<<<<<< HEAD
                Left = Math.Max(Left, other.Left),
                Top = Math.Max(Top, other.Top),
                Right = Math.Min(Right, other.Right),
                Bottom = Math.Min(Bottom, other.Bottom),
=======
                Left   = Math.Max(Left, other.Left),
                Top    = Math.Max(Top, other.Top),
                Right  = Math.Min(Right, other.Right),
                Bottom = Math.Min(Bottom, other.Bottom)
>>>>>>> 1ec71635b (sync with main branch)
            };

            return !result.IsEmpty();
        }

        public void MakeInvalid()
        {
<<<<<<< HEAD
            Right = -1;
=======
            Right  = -1;
>>>>>>> 1ec71635b (sync with main branch)
            Bottom = -1;
        }

        public static bool operator ==(Rect x, Rect y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Rect x, Rect y)
        {
            return !x.Equals(y);
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is Rect rect && Equals(rect);
        }

<<<<<<< HEAD
        public readonly bool Equals(Rect cmpObj)
=======
        public bool Equals(Rect cmpObj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Left == cmpObj.Left && Top == cmpObj.Top && Right == cmpObj.Right && Bottom == cmpObj.Bottom;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode() => HashCode.Combine(Left, Top, Right, Bottom);
    }
}
=======
        public override int GetHashCode() => HashCode.Combine(Left, Top, Right, Bottom);
    }
}
>>>>>>> 1ec71635b (sync with main branch)
