<<<<<<< HEAD
using NUnit.Framework;
=======
﻿using NUnit.Framework;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Audio.Renderer.Parameter.Sink;
using System.Runtime.CompilerServices;

namespace Ryujinx.Tests.Audio.Renderer.Parameter.Sink
{
    class DeviceParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x11C, Unsafe.SizeOf<DeviceParameter>());
        }
    }
}
