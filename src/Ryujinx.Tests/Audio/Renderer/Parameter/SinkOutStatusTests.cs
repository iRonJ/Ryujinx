<<<<<<< HEAD
using NUnit.Framework;
=======
﻿using NUnit.Framework;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Ryujinx.Tests.Audio.Renderer.Parameter
{
    class SinkOutStatusTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x20, Unsafe.SizeOf<SinkOutStatus>());
        }
    }
}
