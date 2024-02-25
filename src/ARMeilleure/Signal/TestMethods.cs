<<<<<<< HEAD
using ARMeilleure.IntermediateRepresentation;
=======
﻿using ARMeilleure.IntermediateRepresentation;
>>>>>>> 1ec71635b (sync with main branch)
using ARMeilleure.Translation;
using System;
using System.Runtime.InteropServices;
using static ARMeilleure.IntermediateRepresentation.Operand.Factory;

namespace ARMeilleure.Signal
{
    public struct NativeWriteLoopState
    {
        public int Running;
        public int Error;
    }

    public static class TestMethods
    {
        public delegate bool DebugPartialUnmap();
        public delegate int DebugThreadLocalMapGetOrReserve(int threadId, int initialState);
        public delegate void DebugNativeWriteLoop(IntPtr nativeWriteLoopPtr, IntPtr writePtr);

        public static DebugPartialUnmap GenerateDebugPartialUnmap()
        {
<<<<<<< HEAD
            EmitterContext context = new();
=======
            EmitterContext context = new EmitterContext();
>>>>>>> 1ec71635b (sync with main branch)

            var result = WindowsPartialUnmapHandler.EmitRetryFromAccessViolation(context);

            context.Return(result);

            // Compile and return the function.

            ControlFlowGraph cfg = context.GetControlFlowGraph();

            OperandType[] argTypes = new OperandType[] { OperandType.I64 };

            return Compiler.Compile(cfg, argTypes, OperandType.I32, CompilerOptions.HighCq, RuntimeInformation.ProcessArchitecture).Map<DebugPartialUnmap>();
        }

        public static DebugThreadLocalMapGetOrReserve GenerateDebugThreadLocalMapGetOrReserve(IntPtr structPtr)
        {
<<<<<<< HEAD
            EmitterContext context = new();
=======
            EmitterContext context = new EmitterContext();
>>>>>>> 1ec71635b (sync with main branch)

            var result = WindowsPartialUnmapHandler.EmitThreadLocalMapIntGetOrReserve(context, structPtr, context.LoadArgument(OperandType.I32, 0), context.LoadArgument(OperandType.I32, 1));

            context.Return(result);

            // Compile and return the function.

            ControlFlowGraph cfg = context.GetControlFlowGraph();

            OperandType[] argTypes = new OperandType[] { OperandType.I64 };

            return Compiler.Compile(cfg, argTypes, OperandType.I32, CompilerOptions.HighCq, RuntimeInformation.ProcessArchitecture).Map<DebugThreadLocalMapGetOrReserve>();
        }

        public static DebugNativeWriteLoop GenerateDebugNativeWriteLoop()
        {
<<<<<<< HEAD
            EmitterContext context = new();
=======
            EmitterContext context = new EmitterContext();
>>>>>>> 1ec71635b (sync with main branch)

            // Loop a write to the target address until "running" is false.

            Operand structPtr = context.Copy(context.LoadArgument(OperandType.I64, 0));
            Operand writePtr = context.Copy(context.LoadArgument(OperandType.I64, 1));

            Operand loopLabel = Label();
            context.MarkLabel(loopLabel);

            context.Store(writePtr, Const(12345));

            Operand running = context.Load(OperandType.I32, structPtr);

            context.BranchIfTrue(loopLabel, running);

            context.Return();

            // Compile and return the function.

            ControlFlowGraph cfg = context.GetControlFlowGraph();

            OperandType[] argTypes = new OperandType[] { OperandType.I64 };

            return Compiler.Compile(cfg, argTypes, OperandType.None, CompilerOptions.HighCq, RuntimeInformation.ProcessArchitecture).Map<DebugNativeWriteLoop>();
        }
    }
}
