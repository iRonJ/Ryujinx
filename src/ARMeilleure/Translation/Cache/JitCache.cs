using ARMeilleure.CodeGen;
using ARMeilleure.CodeGen.Unwinding;
using ARMeilleure.Memory;
using ARMeilleure.Native;
<<<<<<< HEAD
using Ryujinx.Memory;
=======
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
<<<<<<< HEAD
using System.Runtime.Versioning;

namespace ARMeilleure.Translation.Cache
{
    static partial class JitCache
    {
        private static readonly int _pageSize = (int)MemoryBlock.GetPageSize();
        private static readonly int _pageMask = _pageSize - 1;
=======

namespace ARMeilleure.Translation.Cache
{
    static class JitCache
    {
        private const int PageSize = 4 * 1024;
        private const int PageMask = PageSize - 1;
>>>>>>> 1ec71635b (sync with main branch)

        private const int CodeAlignment = 4; // Bytes.
        private const int CacheSize = 2047 * 1024 * 1024;

        private static ReservedRegion _jitRegion;
        private static JitCacheInvalidation _jitCacheInvalidator;

        private static CacheMemoryAllocator _cacheAllocator;

<<<<<<< HEAD
        private static readonly List<CacheEntry> _cacheEntries = new();

        private static readonly object _lock = new();
        private static bool _initialized;

        [SupportedOSPlatform("windows")]
        [LibraryImport("kernel32.dll", SetLastError = true)]
        public static partial IntPtr FlushInstructionCache(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize);

        public static void Initialize(IJitMemoryAllocator allocator)
        {
            if (_initialized)
            {
                return;
            }

            lock (_lock)
            {
                if (_initialized)
                {
                    return;
                }

                _jitRegion = new ReservedRegion(allocator, CacheSize);

                if (!OperatingSystem.IsWindows() && !OperatingSystem.IsMacOS())
                {
                    _jitCacheInvalidator = new JitCacheInvalidation(allocator);
                }
=======
        private static readonly List<CacheEntry> _cacheEntries = new List<CacheEntry>();

        private static readonly object _lock = new object();
        private static bool _initialized;

        public static void Initialize(IJitMemoryAllocator allocator)
        {
            if (_initialized) return;

            lock (_lock)
            {
                if (_initialized) return;

                _jitRegion = new ReservedRegion(allocator, CacheSize);
                _jitCacheInvalidator = new JitCacheInvalidation(allocator);
>>>>>>> 1ec71635b (sync with main branch)

                _cacheAllocator = new CacheMemoryAllocator(CacheSize);

                if (OperatingSystem.IsWindows())
                {
<<<<<<< HEAD
                    JitUnwindWindows.InstallFunctionTableHandler(_jitRegion.Pointer, CacheSize, _jitRegion.Pointer + Allocate(_pageSize));
=======
                    JitUnwindWindows.InstallFunctionTableHandler(_jitRegion.Pointer, CacheSize, _jitRegion.Pointer + Allocate(PageSize));
>>>>>>> 1ec71635b (sync with main branch)
                }

                _initialized = true;
            }
        }

        public static IntPtr Map(CompiledFunction func)
        {
            byte[] code = func.Code;

            lock (_lock)
            {
                Debug.Assert(_initialized);

                int funcOffset = Allocate(code.Length);

                IntPtr funcPtr = _jitRegion.Pointer + funcOffset;

                if (OperatingSystem.IsMacOS() && RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
                {
                    unsafe
                    {
<<<<<<< HEAD
                        fixed (byte* codePtr = code)
=======
                        fixed (byte *codePtr = code)
>>>>>>> 1ec71635b (sync with main branch)
                        {
                            JitSupportDarwin.Copy(funcPtr, (IntPtr)codePtr, (ulong)code.Length);
                        }
                    }
                }
                else
                {
                    ReprotectAsWritable(funcOffset, code.Length);
                    Marshal.Copy(code, 0, funcPtr, code.Length);
                    ReprotectAsExecutable(funcOffset, code.Length);

<<<<<<< HEAD
                    if (OperatingSystem.IsWindows() && RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
                    {
                        FlushInstructionCache(Process.GetCurrentProcess().Handle, funcPtr, (UIntPtr)code.Length);
                    }
                    else
                    {
                        _jitCacheInvalidator?.Invalidate(funcPtr, (ulong)code.Length);
                    }
=======
                    _jitCacheInvalidator.Invalidate(funcPtr, (ulong)code.Length);
>>>>>>> 1ec71635b (sync with main branch)
                }

                Add(funcOffset, code.Length, func.UnwindInfo);

                return funcPtr;
            }
        }

        public static void Unmap(IntPtr pointer)
        {
            lock (_lock)
            {
                Debug.Assert(_initialized);

                int funcOffset = (int)(pointer.ToInt64() - _jitRegion.Pointer.ToInt64());

<<<<<<< HEAD
                if (TryFind(funcOffset, out CacheEntry entry, out int entryIndex) && entry.Offset == funcOffset)
                {
                    _cacheAllocator.Free(funcOffset, AlignCodeSize(entry.Size));
                    _cacheEntries.RemoveAt(entryIndex);
                }
=======
                bool result = TryFind(funcOffset, out CacheEntry entry);
                Debug.Assert(result);

                _cacheAllocator.Free(funcOffset, AlignCodeSize(entry.Size));

                Remove(funcOffset);
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private static void ReprotectAsWritable(int offset, int size)
        {
            int endOffs = offset + size;

<<<<<<< HEAD
            int regionStart = offset & ~_pageMask;
            int regionEnd = (endOffs + _pageMask) & ~_pageMask;
=======
            int regionStart = offset & ~PageMask;
            int regionEnd = (endOffs + PageMask) & ~PageMask;
>>>>>>> 1ec71635b (sync with main branch)

            _jitRegion.Block.MapAsRwx((ulong)regionStart, (ulong)(regionEnd - regionStart));
        }

        private static void ReprotectAsExecutable(int offset, int size)
        {
            int endOffs = offset + size;

<<<<<<< HEAD
            int regionStart = offset & ~_pageMask;
            int regionEnd = (endOffs + _pageMask) & ~_pageMask;
=======
            int regionStart = offset & ~PageMask;
            int regionEnd = (endOffs + PageMask) & ~PageMask;
>>>>>>> 1ec71635b (sync with main branch)

            _jitRegion.Block.MapAsRx((ulong)regionStart, (ulong)(regionEnd - regionStart));
        }

        private static int Allocate(int codeSize)
        {
            codeSize = AlignCodeSize(codeSize);

            int allocOffset = _cacheAllocator.Allocate(codeSize);

            if (allocOffset < 0)
            {
                throw new OutOfMemoryException("JIT Cache exhausted.");
            }

            _jitRegion.ExpandIfNeeded((ulong)allocOffset + (ulong)codeSize);

            return allocOffset;
        }

        private static int AlignCodeSize(int codeSize)
        {
            return checked(codeSize + (CodeAlignment - 1)) & ~(CodeAlignment - 1);
        }

        private static void Add(int offset, int size, UnwindInfo unwindInfo)
        {
<<<<<<< HEAD
            CacheEntry entry = new(offset, size, unwindInfo);
=======
            CacheEntry entry = new CacheEntry(offset, size, unwindInfo);
>>>>>>> 1ec71635b (sync with main branch)

            int index = _cacheEntries.BinarySearch(entry);

            if (index < 0)
            {
                index = ~index;
            }

            _cacheEntries.Insert(index, entry);
        }

<<<<<<< HEAD
        public static bool TryFind(int offset, out CacheEntry entry, out int entryIndex)
=======
        private static void Remove(int offset)
        {
            int index = _cacheEntries.BinarySearch(new CacheEntry(offset, 0, default));

            if (index < 0)
            {
                index = ~index - 1;
            }

            if (index >= 0)
            {
                _cacheEntries.RemoveAt(index);
            }
        }

        public static bool TryFind(int offset, out CacheEntry entry)
>>>>>>> 1ec71635b (sync with main branch)
        {
            lock (_lock)
            {
                int index = _cacheEntries.BinarySearch(new CacheEntry(offset, 0, default));

                if (index < 0)
                {
                    index = ~index - 1;
                }

                if (index >= 0)
                {
                    entry = _cacheEntries[index];
<<<<<<< HEAD
                    entryIndex = index;
=======
>>>>>>> 1ec71635b (sync with main branch)
                    return true;
                }
            }

            entry = default;
<<<<<<< HEAD
            entryIndex = 0;
            return false;
        }
    }
}
=======
            return false;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
