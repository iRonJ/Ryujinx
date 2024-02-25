<<<<<<< HEAD
using ARMeilleure.Translation;
=======
﻿using ARMeilleure.Translation;
>>>>>>> 1ec71635b (sync with main branch)
using NUnit.Framework;
using Ryujinx.Cpu.Jit;
using Ryujinx.Tests.Memory;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.Tests.Cpu
{
    internal class EnvironmentTests
    {
<<<<<<< HEAD
#pragma warning disable IDE0052 // Remove unread private member
        private static Translator _translator;
#pragma warning restore IDE0052

        private static void EnsureTranslator()
=======
        private static Translator _translator;

        private void EnsureTranslator()
>>>>>>> 1ec71635b (sync with main branch)
        {
            // Create a translator, as one is needed to register the signal handler or emit methods.
            _translator ??= new Translator(new JitMemoryAllocator(), new MockMemoryManager(), true);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
<<<<<<< HEAD
        private static float GetDenormal()
=======
        private float GetDenormal()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return BitConverter.Int32BitsToSingle(1);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
<<<<<<< HEAD
        private static float GetZero()
=======
        private float GetZero()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return BitConverter.Int32BitsToSingle(0);
        }

        /// <summary>
        /// This test ensures that managed methods do not reset floating point control flags.
        /// This is used to avoid changing control flags when running methods that don't require it, such as SVC calls, software memory...
        /// </summary>
        [Test]
        public void FpFlagsPInvoke()
        {
            EnsureTranslator();

            // Subnormal results are not flushed to zero by default.
            // This operation should not be allowed to do constant propagation, hence the methods that explicitly disallow inlining.
            Assert.AreNotEqual(GetDenormal() + GetZero(), 0f);

            bool methodCalled = false;
            bool isFz = false;

<<<<<<< HEAD
            var method = TranslatorTestMethods.GenerateFpFlagsPInvokeTest();

            // This method sets flush-to-zero and then calls the managed method.
            // Before and after setting the flags, it ensures subnormal addition works as expected.
            // It returns a positive result if any tests fail, and 0 on success (or if the platform cannot change FP flags)
            int result = method(Marshal.GetFunctionPointerForDelegate(ManagedMethod));

            // Subnormal results are not flushed to zero by default, which we should have returned to exiting the method.
            Assert.AreNotEqual(GetDenormal() + GetZero(), 0f);

            Assert.True(result == 0);
            Assert.True(methodCalled);
            Assert.True(isFz);
            return;

            void ManagedMethod()
=======
            var managedMethod = () =>
>>>>>>> 1ec71635b (sync with main branch)
            {
                // Floating point math should not modify fp flags.
                float test = 2f * 3.5f;

                if (test < 4f)
                {
<<<<<<< HEAD
                    throw new Exception("Sanity check.");
=======
                    throw new System.Exception("Sanity check.");
>>>>>>> 1ec71635b (sync with main branch)
                }

                isFz = GetDenormal() + GetZero() == 0f;

                try
                {
                    if (test >= 4f)
                    {
<<<<<<< HEAD
                        throw new Exception("Always throws.");
=======
                        throw new System.Exception("Always throws.");
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }
                catch
                {
                    // Exception handling should not modify fp flags.

                    methodCalled = true;
                }
<<<<<<< HEAD
            }
=======
            };

            var method = TranslatorTestMethods.GenerateFpFlagsPInvokeTest();

            // This method sets flush-to-zero and then calls the managed method.
            // Before and after setting the flags, it ensures subnormal addition works as expected.
            // It returns a positive result if any tests fail, and 0 on success (or if the platform cannot change FP flags)
            int result = method(Marshal.GetFunctionPointerForDelegate(managedMethod));

            // Subnormal results are not flushed to zero by default, which we should have returned to exiting the method.
            Assert.AreNotEqual(GetDenormal() + GetZero(), 0f);

            Assert.True(result == 0);
            Assert.True(methodCalled);
            Assert.True(isFz);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
