<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using Ryujinx.Graphics.Shader.StructuredIr;
using Ryujinx.Graphics.Shader.Translation;
using System;
using System.Collections.Generic;
using static Spv.Specification;

namespace Ryujinx.Graphics.Shader.CodeGen.Spirv
{
    using SpvInstruction = Spv.Generator.Instruction;
    using SpvInstructionPool = Spv.Generator.GeneratorPool<Spv.Generator.Instruction>;
    using SpvLiteralInteger = Spv.Generator.LiteralInteger;
    using SpvLiteralIntegerPool = Spv.Generator.GeneratorPool<Spv.Generator.LiteralInteger>;

    static class SpirvGenerator
    {
        // Resource pools for Spirv generation. Note: Increase count when more threads are being used.
        private const int GeneratorPoolCount = 1;
<<<<<<< HEAD
        private static readonly ObjectPool<SpvInstructionPool> _instructionPool;
        private static readonly ObjectPool<SpvLiteralIntegerPool> _integerPool;
        private static readonly object _poolLock;

        static SpirvGenerator()
        {
            _instructionPool = new(() => new SpvInstructionPool(), GeneratorPoolCount);
            _integerPool = new(() => new SpvLiteralIntegerPool(), GeneratorPoolCount);
            _poolLock = new object();
        }

        private const HelperFunctionsMask NeedsInvocationIdMask = HelperFunctionsMask.SwizzleAdd;

        public static byte[] Generate(StructuredProgramInfo info, CodeGenParameters parameters)
=======
        private static ObjectPool<SpvInstructionPool> InstructionPool;
        private static ObjectPool<SpvLiteralIntegerPool> IntegerPool;
        private static object PoolLock;

        static SpirvGenerator()
        {
            InstructionPool = new (() => new SpvInstructionPool(), GeneratorPoolCount);
            IntegerPool = new (() => new SpvLiteralIntegerPool(), GeneratorPoolCount);
            PoolLock = new object();
        }

        private const HelperFunctionsMask NeedsInvocationIdMask =
            HelperFunctionsMask.Shuffle |
            HelperFunctionsMask.ShuffleDown |
            HelperFunctionsMask.ShuffleUp |
            HelperFunctionsMask.ShuffleXor |
            HelperFunctionsMask.SwizzleAdd;

        public static byte[] Generate(StructuredProgramInfo info, ShaderConfig config)
>>>>>>> 1ec71635b (sync with main branch)
        {
            SpvInstructionPool instPool;
            SpvLiteralIntegerPool integerPool;

<<<<<<< HEAD
            lock (_poolLock)
            {
                instPool = _instructionPool.Allocate();
                integerPool = _integerPool.Allocate();
            }

            CodeGenContext context = new(info, parameters, instPool, integerPool);
=======
            lock (PoolLock)
            {
                instPool = InstructionPool.Allocate();
                integerPool = IntegerPool.Allocate();
            }

            CodeGenContext context = new CodeGenContext(info, config, instPool, integerPool);
>>>>>>> 1ec71635b (sync with main branch)

            context.AddCapability(Capability.GroupNonUniformBallot);
            context.AddCapability(Capability.GroupNonUniformShuffle);
            context.AddCapability(Capability.GroupNonUniformVote);
            context.AddCapability(Capability.ImageBuffer);
            context.AddCapability(Capability.ImageGatherExtended);
            context.AddCapability(Capability.ImageQuery);
            context.AddCapability(Capability.SampledBuffer);

<<<<<<< HEAD
            if (parameters.Definitions.TransformFeedbackEnabled && parameters.Definitions.LastInVertexPipeline)
=======
            if (config.TransformFeedbackEnabled && config.LastInVertexPipeline)
>>>>>>> 1ec71635b (sync with main branch)
            {
                context.AddCapability(Capability.TransformFeedback);
            }

<<<<<<< HEAD
            if (parameters.Definitions.Stage == ShaderStage.Fragment)
=======
            if (config.Stage == ShaderStage.Fragment)
>>>>>>> 1ec71635b (sync with main branch)
            {
                if (context.Info.IoDefinitions.Contains(new IoDefinition(StorageKind.Input, IoVariable.Layer)))
                {
                    context.AddCapability(Capability.Geometry);
                }

<<<<<<< HEAD
                if (context.HostCapabilities.SupportsFragmentShaderInterlock)
=======
                if (context.Config.GpuAccessor.QueryHostSupportsFragmentShaderInterlock())
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.AddCapability(Capability.FragmentShaderPixelInterlockEXT);
                    context.AddExtension("SPV_EXT_fragment_shader_interlock");
                }
            }
<<<<<<< HEAD
            else if (parameters.Definitions.Stage == ShaderStage.Geometry)
            {
                context.AddCapability(Capability.Geometry);

                if (parameters.Definitions.GpPassthrough && context.HostCapabilities.SupportsGeometryShaderPassthrough)
=======
            else if (config.Stage == ShaderStage.Geometry)
            {
                context.AddCapability(Capability.Geometry);

                if (config.GpPassthrough && context.Config.GpuAccessor.QueryHostSupportsGeometryShaderPassthrough())
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.AddExtension("SPV_NV_geometry_shader_passthrough");
                    context.AddCapability(Capability.GeometryShaderPassthroughNV);
                }
            }
<<<<<<< HEAD
            else if (parameters.Definitions.Stage == ShaderStage.TessellationControl ||
                     parameters.Definitions.Stage == ShaderStage.TessellationEvaluation)
            {
                context.AddCapability(Capability.Tessellation);
            }
            else if (parameters.Definitions.Stage == ShaderStage.Vertex)
=======
            else if (config.Stage == ShaderStage.TessellationControl || config.Stage == ShaderStage.TessellationEvaluation)
            {
                context.AddCapability(Capability.Tessellation);
            }
            else if (config.Stage == ShaderStage.Vertex)
>>>>>>> 1ec71635b (sync with main branch)
            {
                context.AddCapability(Capability.DrawParameters);
            }

<<<<<<< HEAD
            if (context.Definitions.Stage != ShaderStage.Fragment &&
                context.Definitions.Stage != ShaderStage.Geometry &&
                context.Definitions.Stage != ShaderStage.Compute &&
                (context.Info.IoDefinitions.Contains(new IoDefinition(StorageKind.Output, IoVariable.Layer)) ||
                context.Info.IoDefinitions.Contains(new IoDefinition(StorageKind.Output, IoVariable.ViewportIndex))))
            {
                context.AddExtension("SPV_EXT_shader_viewport_index_layer");
                context.AddCapability(Capability.ShaderViewportIndexLayerEXT);
            }

=======
>>>>>>> 1ec71635b (sync with main branch)
            if (context.Info.IoDefinitions.Contains(new IoDefinition(StorageKind.Output, IoVariable.ViewportMask)))
            {
                context.AddExtension("SPV_NV_viewport_array2");
                context.AddCapability(Capability.ShaderViewportMaskNV);
            }

            if ((info.HelperFunctionsMask & NeedsInvocationIdMask) != 0)
            {
                info.IoDefinitions.Add(new IoDefinition(StorageKind.Input, IoVariable.SubgroupLaneId));
            }

            Declarations.DeclareAll(context, info);

            for (int funcIndex = 0; funcIndex < info.Functions.Count; funcIndex++)
            {
                var function = info.Functions[funcIndex];
                var retType = context.GetType(function.ReturnType);

                var funcArgs = new SpvInstruction[function.InArguments.Length + function.OutArguments.Length];

                for (int argIndex = 0; argIndex < funcArgs.Length; argIndex++)
                {
                    var argType = context.GetType(function.GetArgumentType(argIndex));
                    var argPointerType = context.TypePointer(StorageClass.Function, argType);
                    funcArgs[argIndex] = argPointerType;
                }

                var funcType = context.TypeFunction(retType, false, funcArgs);
                var spvFunc = context.Function(retType, FunctionControlMask.MaskNone, funcType);

                context.DeclareFunction(funcIndex, function, spvFunc);
            }

            for (int funcIndex = 0; funcIndex < info.Functions.Count; funcIndex++)
            {
                Generate(context, info, funcIndex);
            }

            byte[] result = context.Generate();

<<<<<<< HEAD
            lock (_poolLock)
            {
                _instructionPool.Release(instPool);
                _integerPool.Release(integerPool);
=======
            lock (PoolLock)
            {
                InstructionPool.Release(instPool);
                IntegerPool.Release(integerPool);
>>>>>>> 1ec71635b (sync with main branch)
            }

            return result;
        }

        private static void Generate(CodeGenContext context, StructuredProgramInfo info, int funcIndex)
        {
<<<<<<< HEAD
            var (function, spvFunc) = context.GetFunction(funcIndex);

            context.CurrentFunction = function;
            context.AddFunction(spvFunc);
            context.StartFunction(isMainFunction: funcIndex == 0);
=======
            (var function, var spvFunc) = context.GetFunction(funcIndex);

            context.CurrentFunction = function;
            context.AddFunction(spvFunc);
            context.StartFunction();
>>>>>>> 1ec71635b (sync with main branch)

            Declarations.DeclareParameters(context, function);

            context.EnterBlock(function.MainBlock);

            Declarations.DeclareLocals(context, function);
<<<<<<< HEAD
=======
            Declarations.DeclareLocalForArgs(context, info.Functions);
>>>>>>> 1ec71635b (sync with main branch)

            Generate(context, function.MainBlock);

            // Functions must always end with a return.
<<<<<<< HEAD
            if (function.MainBlock.Last is not AstOperation operation ||
=======
            if (!(function.MainBlock.Last is AstOperation operation) ||
>>>>>>> 1ec71635b (sync with main branch)
                (operation.Inst != Instruction.Return && operation.Inst != Instruction.Discard))
            {
                context.Return();
            }

            context.FunctionEnd();

            if (funcIndex == 0)
            {
<<<<<<< HEAD
                context.AddEntryPoint(context.Definitions.Stage.Convert(), spvFunc, "main", context.GetMainInterface());

                if (context.Definitions.Stage == ShaderStage.TessellationControl)
                {
                    context.AddExecutionMode(spvFunc, ExecutionMode.OutputVertices, (SpvLiteralInteger)context.Definitions.ThreadsPerInputPrimitive);
                }
                else if (context.Definitions.Stage == ShaderStage.TessellationEvaluation)
                {
                    switch (context.Definitions.TessPatchType)
=======
                context.AddEntryPoint(context.Config.Stage.Convert(), spvFunc, "main", context.GetMainInterface());

                if (context.Config.Stage == ShaderStage.TessellationControl)
                {
                    context.AddExecutionMode(spvFunc, ExecutionMode.OutputVertices, (SpvLiteralInteger)context.Config.ThreadsPerInputPrimitive);
                }
                else if (context.Config.Stage == ShaderStage.TessellationEvaluation)
                {
                    switch (context.Config.GpuAccessor.QueryTessPatchType())
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        case TessPatchType.Isolines:
                            context.AddExecutionMode(spvFunc, ExecutionMode.Isolines);
                            break;
                        case TessPatchType.Triangles:
                            context.AddExecutionMode(spvFunc, ExecutionMode.Triangles);
                            break;
                        case TessPatchType.Quads:
                            context.AddExecutionMode(spvFunc, ExecutionMode.Quads);
                            break;
                    }

<<<<<<< HEAD
                    switch (context.Definitions.TessSpacing)
=======
                    switch (context.Config.GpuAccessor.QueryTessSpacing())
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        case TessSpacing.EqualSpacing:
                            context.AddExecutionMode(spvFunc, ExecutionMode.SpacingEqual);
                            break;
                        case TessSpacing.FractionalEventSpacing:
                            context.AddExecutionMode(spvFunc, ExecutionMode.SpacingFractionalEven);
                            break;
                        case TessSpacing.FractionalOddSpacing:
                            context.AddExecutionMode(spvFunc, ExecutionMode.SpacingFractionalOdd);
                            break;
                    }

<<<<<<< HEAD
                    bool tessCw = context.Definitions.TessCw;

                    if (context.TargetApi == TargetApi.Vulkan)
=======
                    bool tessCw = context.Config.GpuAccessor.QueryTessCw();

                    if (context.Config.Options.TargetApi == TargetApi.Vulkan)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        // We invert the front face on Vulkan backend, so we need to do that here as well.
                        tessCw = !tessCw;
                    }

                    if (tessCw)
                    {
                        context.AddExecutionMode(spvFunc, ExecutionMode.VertexOrderCw);
                    }
                    else
                    {
                        context.AddExecutionMode(spvFunc, ExecutionMode.VertexOrderCcw);
                    }
                }
<<<<<<< HEAD
                else if (context.Definitions.Stage == ShaderStage.Geometry)
                {
                    context.AddExecutionMode(spvFunc, context.Definitions.InputTopology switch
=======
                else if (context.Config.Stage == ShaderStage.Geometry)
                {
                    InputTopology inputTopology = context.Config.GpuAccessor.QueryPrimitiveTopology();

                    context.AddExecutionMode(spvFunc, inputTopology switch
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        InputTopology.Points => ExecutionMode.InputPoints,
                        InputTopology.Lines => ExecutionMode.InputLines,
                        InputTopology.LinesAdjacency => ExecutionMode.InputLinesAdjacency,
                        InputTopology.Triangles => ExecutionMode.Triangles,
                        InputTopology.TrianglesAdjacency => ExecutionMode.InputTrianglesAdjacency,
<<<<<<< HEAD
                        _ => throw new InvalidOperationException($"Invalid input topology \"{context.Definitions.InputTopology}\"."),
                    });

                    context.AddExecutionMode(spvFunc, ExecutionMode.Invocations, (SpvLiteralInteger)context.Definitions.ThreadsPerInputPrimitive);

                    context.AddExecutionMode(spvFunc, context.Definitions.OutputTopology switch
=======
                        _ => throw new InvalidOperationException($"Invalid input topology \"{inputTopology}\".")
                    });

                    context.AddExecutionMode(spvFunc, ExecutionMode.Invocations, (SpvLiteralInteger)context.Config.ThreadsPerInputPrimitive);

                    context.AddExecutionMode(spvFunc, context.Config.OutputTopology switch
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        OutputTopology.PointList => ExecutionMode.OutputPoints,
                        OutputTopology.LineStrip => ExecutionMode.OutputLineStrip,
                        OutputTopology.TriangleStrip => ExecutionMode.OutputTriangleStrip,
<<<<<<< HEAD
                        _ => throw new InvalidOperationException($"Invalid output topology \"{context.Definitions.OutputTopology}\"."),
                    });

                    context.AddExecutionMode(spvFunc, ExecutionMode.OutputVertices, (SpvLiteralInteger)context.Definitions.MaxOutputVertices);
                }
                else if (context.Definitions.Stage == ShaderStage.Fragment)
                {
                    context.AddExecutionMode(spvFunc, context.Definitions.OriginUpperLeft
=======
                        _ => throw new InvalidOperationException($"Invalid output topology \"{context.Config.OutputTopology}\".")
                    });

                    int maxOutputVertices = context.Config.GpPassthrough ? context.InputVertices : context.Config.MaxOutputVertices;

                    context.AddExecutionMode(spvFunc, ExecutionMode.OutputVertices, (SpvLiteralInteger)maxOutputVertices);
                }
                else if (context.Config.Stage == ShaderStage.Fragment)
                {
                    context.AddExecutionMode(spvFunc, context.Config.Options.TargetApi == TargetApi.Vulkan
>>>>>>> 1ec71635b (sync with main branch)
                        ? ExecutionMode.OriginUpperLeft
                        : ExecutionMode.OriginLowerLeft);

                    if (context.Info.IoDefinitions.Contains(new IoDefinition(StorageKind.Output, IoVariable.FragmentOutputDepth)))
                    {
                        context.AddExecutionMode(spvFunc, ExecutionMode.DepthReplacing);
                    }

<<<<<<< HEAD
                    if (context.Definitions.EarlyZForce)
=======
                    if (context.Config.GpuAccessor.QueryEarlyZForce())
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        context.AddExecutionMode(spvFunc, ExecutionMode.EarlyFragmentTests);
                    }

                    if ((info.HelperFunctionsMask & HelperFunctionsMask.FSI) != 0 &&
<<<<<<< HEAD
                        context.HostCapabilities.SupportsFragmentShaderInterlock)
=======
                        context.Config.GpuAccessor.QueryHostSupportsFragmentShaderInterlock())
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        context.AddExecutionMode(spvFunc, ExecutionMode.PixelInterlockOrderedEXT);
                    }
                }
<<<<<<< HEAD
                else if (context.Definitions.Stage == ShaderStage.Compute)
                {
                    var localSizeX = (SpvLiteralInteger)context.Definitions.ComputeLocalSizeX;
                    var localSizeY = (SpvLiteralInteger)context.Definitions.ComputeLocalSizeY;
                    var localSizeZ = (SpvLiteralInteger)context.Definitions.ComputeLocalSizeZ;
=======
                else if (context.Config.Stage == ShaderStage.Compute)
                {
                    var localSizeX = (SpvLiteralInteger)context.Config.GpuAccessor.QueryComputeLocalSizeX();
                    var localSizeY = (SpvLiteralInteger)context.Config.GpuAccessor.QueryComputeLocalSizeY();
                    var localSizeZ = (SpvLiteralInteger)context.Config.GpuAccessor.QueryComputeLocalSizeZ();
>>>>>>> 1ec71635b (sync with main branch)

                    context.AddExecutionMode(
                        spvFunc,
                        ExecutionMode.LocalSize,
                        localSizeX,
                        localSizeY,
                        localSizeZ);
                }

<<<<<<< HEAD
                if (context.Definitions.TransformFeedbackEnabled && context.Definitions.LastInVertexPipeline)
=======
                if (context.Config.TransformFeedbackEnabled && context.Config.LastInVertexPipeline)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.AddExecutionMode(spvFunc, ExecutionMode.Xfb);
                }
            }
        }

        private static void Generate(CodeGenContext context, AstBlock block)
        {
<<<<<<< HEAD
            AstBlockVisitor visitor = new(block);
=======
            AstBlockVisitor visitor = new AstBlockVisitor(block);
>>>>>>> 1ec71635b (sync with main branch)

            var loopTargets = new Dictionary<AstBlock, (SpvInstruction, SpvInstruction)>();

            context.LoopTargets = loopTargets;

            visitor.BlockEntered += (sender, e) =>
            {
                AstBlock mergeBlock = e.Block.Parent;

                if (e.Block.Type == AstBlockType.If)
                {
                    AstBlock ifTrueBlock = e.Block;
                    AstBlock ifFalseBlock;

                    if (AstHelper.Next(e.Block) is AstBlock nextBlock && nextBlock.Type == AstBlockType.Else)
                    {
                        ifFalseBlock = nextBlock;
                    }
                    else
                    {
                        ifFalseBlock = mergeBlock;
                    }

                    var condition = context.Get(AggregateType.Bool, e.Block.Condition);

                    context.SelectionMerge(context.GetNextLabel(mergeBlock), SelectionControlMask.MaskNone);
                    context.BranchConditional(condition, context.GetNextLabel(ifTrueBlock), context.GetNextLabel(ifFalseBlock));
                }
                else if (e.Block.Type == AstBlockType.DoWhile)
                {
                    var continueTarget = context.Label();

                    loopTargets.Add(e.Block, (context.NewBlock(), continueTarget));

                    context.LoopMerge(context.GetNextLabel(mergeBlock), continueTarget, LoopControlMask.MaskNone);
                    context.Branch(context.GetFirstLabel(e.Block));
                }

                context.EnterBlock(e.Block);
            };

            visitor.BlockLeft += (sender, e) =>
            {
                if (e.Block.Parent != null)
                {
                    if (e.Block.Type == AstBlockType.DoWhile)
                    {
                        // This is a loop, we need to jump back to the loop header
                        // if the condition is true.
                        AstBlock mergeBlock = e.Block.Parent;

<<<<<<< HEAD
                        var (loopTarget, continueTarget) = loopTargets[e.Block];
=======
                        (var loopTarget, var continueTarget) = loopTargets[e.Block];
>>>>>>> 1ec71635b (sync with main branch)

                        context.Branch(continueTarget);
                        context.AddLabel(continueTarget);

                        var condition = context.Get(AggregateType.Bool, e.Block.Condition);

                        context.BranchConditional(condition, loopTarget, context.GetNextLabel(mergeBlock));
                    }
                    else
                    {
                        // We only need a branch if the last instruction didn't
                        // already cause the program to exit or jump elsewhere.
                        bool lastIsCf = e.Block.Last is AstOperation lastOp &&
                            (lastOp.Inst == Instruction.Discard ||
                             lastOp.Inst == Instruction.LoopBreak ||
                             lastOp.Inst == Instruction.LoopContinue ||
                             lastOp.Inst == Instruction.Return);

                        if (!lastIsCf)
                        {
                            context.Branch(context.GetNextLabel(e.Block.Parent));
                        }
                    }

                    bool hasElse = AstHelper.Next(e.Block) is AstBlock nextBlock &&
                        (nextBlock.Type == AstBlockType.Else ||
                         nextBlock.Type == AstBlockType.ElseIf);

                    // Re-enter the parent block.
                    if (e.Block.Parent != null && !hasElse)
                    {
                        context.EnterBlock(e.Block.Parent);
                    }
                }
            };

            foreach (IAstNode node in visitor.Visit())
            {
                if (node is AstAssignment assignment)
                {
                    var dest = (AstOperand)assignment.Destination;

                    if (dest.Type == OperandType.LocalVariable)
                    {
                        var source = context.Get(dest.VarType, assignment.Source);
                        context.Store(context.GetLocalPointer(dest), source);
                    }
                    else if (dest.Type == OperandType.Argument)
                    {
                        var source = context.Get(dest.VarType, assignment.Source);
                        context.Store(context.GetArgumentPointer(dest), source);
                    }
                    else
                    {
                        throw new NotImplementedException(dest.Type.ToString());
                    }
                }
                else if (node is AstOperation operation)
                {
                    Instructions.Generate(context, operation);
                }
            }
        }
    }
}
