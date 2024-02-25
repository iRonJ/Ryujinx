<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.Common.Memory
{
    /// <summary>
    /// Represents an array of unmanaged resources.
    /// </summary>
    /// <typeparam name="T">Array element type</typeparam>
    public unsafe struct ArrayPtr<T> : IEquatable<ArrayPtr<T>>, IArray<T> where T : unmanaged
    {
        private IntPtr _ptr;

        /// <summary>
        /// Null pointer.
        /// </summary>
<<<<<<< HEAD
        public static ArrayPtr<T> Null => new() { _ptr = IntPtr.Zero };
=======
        public static ArrayPtr<T> Null => new ArrayPtr<T>() { _ptr = IntPtr.Zero };
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
        /// Number of elements on the array.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Gets a reference to the item at the given index.
        /// </summary>
        /// <remarks>
        /// No bounds checks are performed, this allows negative indexing,
        /// but care must be taken if the index may be out of bounds.
        /// </remarks>
        /// <param name="index">Index of the element</param>
        /// <returns>Reference to the element at the given index</returns>
<<<<<<< HEAD
        public readonly ref T this[int index] => ref Unsafe.AsRef<T>((T*)_ptr + index);
=======
        public ref T this[int index] => ref Unsafe.AsRef<T>((T*)_ptr + index);
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Creates a new array from a given reference.
        /// </summary>
        /// <remarks>
        /// For data on the heap, proper pinning is necessary during
        /// use. Failure to do so will result in memory corruption and crashes.
        /// </remarks>
        /// <param name="value">Reference of the first array element</param>
        /// <param name="length">Number of elements on the array</param>
        public ArrayPtr(ref T value, int length)
        {
            _ptr = (IntPtr)Unsafe.AsPointer(ref value);
            Length = length;
        }

        /// <summary>
        /// Creates a new array from a given pointer.
        /// </summary>
        /// <param name="ptr">Array base pointer</param>
        /// <param name="length">Number of elements on the array</param>
        public ArrayPtr(T* ptr, int length)
        {
            _ptr = (IntPtr)ptr;
            Length = length;
        }

        /// <summary>
        /// Creates a new array from a given pointer.
        /// </summary>
        /// <param name="ptr">Array base pointer</param>
        /// <param name="length">Number of elements on the array</param>
        public ArrayPtr(IntPtr ptr, int length)
        {
            _ptr = ptr;
            Length = length;
        }

        /// <summary>
        /// Splits the array starting at the specified position.
        /// </summary>
        /// <param name="start">Index where the new array should start</param>
        /// <returns>New array starting at the specified position</returns>
<<<<<<< HEAD
        public ArrayPtr<T> Slice(int start) => new(ref this[start], Length - start);
=======
        public ArrayPtr<T> Slice(int start) => new ArrayPtr<T>(ref this[start], Length - start);
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Gets a span from the array.
        /// </summary>
        /// <returns>Span of the array</returns>
        public Span<T> AsSpan() => Length == 0 ? Span<T>.Empty : MemoryMarshal.CreateSpan(ref this[0], Length);

        /// <summary>
        /// Gets the array base pointer.
        /// </summary>
        /// <returns>Base pointer</returns>
<<<<<<< HEAD
        public readonly T* ToPointer() => (T*)_ptr;

        public readonly override bool Equals(object obj)
=======
        public T* ToPointer() => (T*)_ptr;

        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is ArrayPtr<T> other && Equals(other);
        }

<<<<<<< HEAD
        public readonly bool Equals([AllowNull] ArrayPtr<T> other)
=======
        public bool Equals([AllowNull] ArrayPtr<T> other)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _ptr == other._ptr && Length == other.Length;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return HashCode.Combine(_ptr, Length);
        }

        public static bool operator ==(ArrayPtr<T> left, ArrayPtr<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ArrayPtr<T> left, ArrayPtr<T> right)
        {
            return !(left == right);
        }
    }
}
