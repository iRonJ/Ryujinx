<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Ryujinx.Common.Memory
{
    /// <summary>
    /// Represents a pointer to an unmanaged resource.
    /// </summary>
    /// <typeparam name="T">Type of the unmanaged resource</typeparam>
    public unsafe struct Ptr<T> : IEquatable<Ptr<T>> where T : unmanaged
    {
        private IntPtr _ptr;

        /// <summary>
        /// Null pointer.
        /// </summary>
<<<<<<< HEAD
        public static Ptr<T> Null => new() { _ptr = IntPtr.Zero };
=======
        public static Ptr<T> Null => new Ptr<T>() { _ptr = IntPtr.Zero };
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// True if the pointer is null, false otherwise.
        /// </summary>
<<<<<<< HEAD
        public readonly bool IsNull => _ptr == IntPtr.Zero;
=======
        public bool IsNull => _ptr == IntPtr.Zero;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Gets a reference to the value.
        /// </summary>
<<<<<<< HEAD
        public readonly ref T Value => ref Unsafe.AsRef<T>((void*)_ptr);
=======
        public ref T Value => ref Unsafe.AsRef<T>((void*)_ptr);
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Creates a new pointer to an unmanaged resource.
        /// </summary>
        /// <remarks>
        /// For data on the heap, proper pinning is necessary during
        /// use. Failure to do so will result in memory corruption and crashes.
        /// </remarks>
        /// <param name="value">Reference to the unmanaged resource</param>
        public Ptr(ref T value)
        {
            _ptr = (IntPtr)Unsafe.AsPointer(ref value);
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is Ptr<T> other && Equals(other);
        }

<<<<<<< HEAD
        public readonly bool Equals([AllowNull] Ptr<T> other)
=======
        public bool Equals([AllowNull] Ptr<T> other)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _ptr == other._ptr;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _ptr.GetHashCode();
        }

        public static bool operator ==(Ptr<T> left, Ptr<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Ptr<T> left, Ptr<T> right)
        {
            return !(left == right);
        }
    }
}
