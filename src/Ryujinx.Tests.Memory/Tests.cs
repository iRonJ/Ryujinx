using NUnit.Framework;
using Ryujinx.Memory;
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.Tests.Memory
{
    public class Tests
    {
<<<<<<< HEAD
        private static readonly ulong _memorySize = MemoryBlock.GetPageSize() * 8;
=======
        private const ulong MemorySize = 0x8000;
>>>>>>> 1ec71635b (sync with main branch)

        private MemoryBlock _memoryBlock;

        [SetUp]
        public void Setup()
        {
<<<<<<< HEAD
            _memoryBlock = new MemoryBlock(_memorySize);
=======
            _memoryBlock = new MemoryBlock(MemorySize);
>>>>>>> 1ec71635b (sync with main branch)
        }

        [TearDown]
        public void Teardown()
        {
            _memoryBlock.Dispose();
        }

        [Test]
        public void Test_Read()
        {
            Marshal.WriteInt32(_memoryBlock.Pointer, 0x2020, 0x1234abcd);

            Assert.AreEqual(_memoryBlock.Read<int>(0x2020), 0x1234abcd);
        }

        [Test]
        public void Test_Write()
        {
            _memoryBlock.Write(0x2040, 0xbadc0de);

            Assert.AreEqual(Marshal.ReadInt32(_memoryBlock.Pointer, 0x2040), 0xbadc0de);
        }

        [Test]
        // Memory aliasing tests fail on CI at the moment.
        [Platform(Exclude = "MacOsX")]
        public void Test_Alias()
        {
<<<<<<< HEAD
            ulong pageSize = MemoryBlock.GetPageSize();
            ulong blockSize = MemoryBlock.GetPageSize() * 16;

            using MemoryBlock backing = new(blockSize, MemoryAllocationFlags.Mirrorable);
            using MemoryBlock toAlias = new(blockSize, MemoryAllocationFlags.Reserve | MemoryAllocationFlags.ViewCompatible);

            toAlias.MapView(backing, pageSize, 0, pageSize * 4);
            toAlias.UnmapView(backing, pageSize * 3, pageSize);

            toAlias.Write(0, 0xbadc0de);
            Assert.AreEqual(Marshal.ReadInt32(backing.Pointer, (int)pageSize), 0xbadc0de);
=======
            using MemoryBlock backing = new MemoryBlock(0x10000, MemoryAllocationFlags.Mirrorable);
            using MemoryBlock toAlias = new MemoryBlock(0x10000, MemoryAllocationFlags.Reserve | MemoryAllocationFlags.ViewCompatible);

            toAlias.MapView(backing, 0x1000, 0, 0x4000);
            toAlias.UnmapView(backing, 0x3000, 0x1000);

            toAlias.Write(0, 0xbadc0de);
            Assert.AreEqual(Marshal.ReadInt32(backing.Pointer, 0x1000), 0xbadc0de);
>>>>>>> 1ec71635b (sync with main branch)
        }

        [Test]
        // Memory aliasing tests fail on CI at the moment.
        [Platform(Exclude = "MacOsX")]
        public void Test_AliasRandom()
        {
<<<<<<< HEAD
            ulong pageSize = MemoryBlock.GetPageSize();
            int pageBits = (int)ulong.Log2(pageSize);
            ulong blockSize = MemoryBlock.GetPageSize() * 128;

            using MemoryBlock backing = new(blockSize, MemoryAllocationFlags.Mirrorable);
            using MemoryBlock toAlias = new(blockSize, MemoryAllocationFlags.Reserve | MemoryAllocationFlags.ViewCompatible);

            Random rng = new(123);
=======
            using MemoryBlock backing = new MemoryBlock(0x80000, MemoryAllocationFlags.Mirrorable);
            using MemoryBlock toAlias = new MemoryBlock(0x80000, MemoryAllocationFlags.Reserve | MemoryAllocationFlags.ViewCompatible);

            Random rng = new Random(123);
>>>>>>> 1ec71635b (sync with main branch)

            for (int i = 0; i < 20000; i++)
            {
                int srcPage = rng.Next(0, 64);
                int dstPage = rng.Next(0, 64);
                int pages = rng.Next(1, 65);

                if ((rng.Next() & 1) != 0)
                {
<<<<<<< HEAD
                    toAlias.MapView(backing, (ulong)srcPage << pageBits, (ulong)dstPage << pageBits, (ulong)pages << pageBits);

                    int offset = rng.Next(0, (int)pageSize - sizeof(int));

                    toAlias.Write((ulong)((dstPage << pageBits) + offset), 0xbadc0de);
                    Assert.AreEqual(Marshal.ReadInt32(backing.Pointer, (srcPage << pageBits) + offset), 0xbadc0de);
                }
                else
                {
                    toAlias.UnmapView(backing, (ulong)dstPage << pageBits, (ulong)pages << pageBits);
=======
                    toAlias.MapView(backing, (ulong)srcPage << 12, (ulong)dstPage << 12, (ulong)pages << 12);

                    int offset = rng.Next(0, 0x1000 - sizeof(int));

                    toAlias.Write((ulong)((dstPage << 12) + offset), 0xbadc0de);
                    Assert.AreEqual(Marshal.ReadInt32(backing.Pointer, (srcPage << 12) + offset), 0xbadc0de);
                }
                else
                {
                    toAlias.UnmapView(backing, (ulong)dstPage << 12, (ulong)pages << 12);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

        [Test]
        // Memory aliasing tests fail on CI at the moment.
        [Platform(Exclude = "MacOsX")]
        public void Test_AliasMapLeak()
        {
<<<<<<< HEAD
            ulong pageSize = MemoryBlock.GetPageSize();
            ulong size = 100000 * pageSize; // The mappings limit on Linux is usually around 65K, so let's make sure we are above that.

            using MemoryBlock backing = new(pageSize, MemoryAllocationFlags.Mirrorable);
            using MemoryBlock toAlias = new(size, MemoryAllocationFlags.Reserve | MemoryAllocationFlags.ViewCompatible);
=======
            ulong pageSize = 4096;
            ulong size = 100000 * pageSize; // The mappings limit on Linux is usually around 65K, so let's make sure we are above that.

            using MemoryBlock backing = new MemoryBlock(pageSize, MemoryAllocationFlags.Mirrorable);
            using MemoryBlock toAlias = new MemoryBlock(size, MemoryAllocationFlags.Reserve | MemoryAllocationFlags.ViewCompatible);
>>>>>>> 1ec71635b (sync with main branch)

            for (ulong offset = 0; offset < size; offset += pageSize)
            {
                toAlias.MapView(backing, 0, offset, pageSize);

                toAlias.Write(offset, 0xbadc0de);
                Assert.AreEqual(0xbadc0de, backing.Read<int>(0));

                toAlias.UnmapView(backing, offset, pageSize);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
