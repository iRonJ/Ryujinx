<<<<<<< HEAD
using NUnit.Framework;
=======
﻿using NUnit.Framework;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Audio.Renderer.Parameter.Effect;
using System.Runtime.CompilerServices;

namespace Ryujinx.Tests.Audio.Renderer.Parameter.Effect
{
    class CompressorParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x38, Unsafe.SizeOf<CompressorParameter>());
        }
    }
}
<<<<<<< HEAD
=======

>>>>>>> 1ec71635b (sync with main branch)
