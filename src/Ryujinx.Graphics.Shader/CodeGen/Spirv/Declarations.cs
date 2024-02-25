<<<<<<< HEAD
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using Ryujinx.Graphics.Shader.StructuredIr;
using Ryujinx.Graphics.Shader.Translation;
using Spv.Generator;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Diagnostics;
=======
using System.Linq;
using System.Numerics;
>>>>>>> 1ec71635b (sync with main branch)
using static Spv.Specification;
using SpvInstruction = Spv.Generator.Instruction;

namespace Ryujinx.Graphics.Shader.CodeGen.Spirv
{
    static class Declarations
    {
<<<<<<< HEAD
=======
        private static readonly string[] StagePrefixes = new string[] { "cp", "vp", "tcp", "tep", "gp", "fp" };

>>>>>>> 1ec71635b (sync with main branch)
        public static void DeclareParameters(CodeGenContext context, StructuredFunction function)
        {
            DeclareParameters(context, function.InArguments, 0);
            DeclareParameters(context, function.OutArguments, function.InArguments.Length);
        }

        private static void DeclareParameters(CodeGenContext context, IEnumerable<AggregateType> argTypes, int argIndex)
        {
            foreach (var argType in argTypes)
            {
                var argPointerType = context.TypePointer(StorageClass.Function, context.GetType(argType));
                var spvArg = context.FunctionParameter(argPointerType);

                context.DeclareArgument(argIndex++, spvArg);
            }
        }

        public static void DeclareLocals(CodeGenContext context, StructuredFunction function)
        {
            foreach (AstOperand local in function.Locals)
            {
                var localPointerType = context.TypePointer(StorageClass.Function, context.GetType(local.VarType));
                var spvLocal = context.Variable(localPointerType, StorageClass.Function);

                context.AddLocalVariable(spvLocal);
                context.DeclareLocal(local, spvLocal);
            }
<<<<<<< HEAD
=======

            var ivector2Type = context.TypeVector(context.TypeS32(), 2);
            var coordTempPointerType = context.TypePointer(StorageClass.Function, ivector2Type);
            var coordTemp = context.Variable(coordTempPointerType, StorageClass.Function);

            context.AddLocalVariable(coordTemp);
            context.CoordTemp = coordTemp;
        }

        public static void DeclareLocalForArgs(CodeGenContext context, List<StructuredFunction> functions)
        {
            for (int funcIndex = 0; funcIndex < functions.Count; funcIndex++)
            {
                StructuredFunction function = functions[funcIndex];
                SpvInstruction[] locals = new SpvInstruction[function.InArguments.Length];

                for (int i = 0; i < function.InArguments.Length; i++)
                {
                    var type = function.GetArgumentType(i);
                    var localPointerType = context.TypePointer(StorageClass.Function, context.GetType(type));
                    var spvLocal = context.Variable(localPointerType, StorageClass.Function);

                    context.AddLocalVariable(spvLocal);

                    locals[i] = spvLocal;
                }

                context.DeclareLocalForArgs(funcIndex, locals);
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void DeclareAll(CodeGenContext context, StructuredProgramInfo info)
        {
<<<<<<< HEAD
            DeclareConstantBuffers(context, context.Properties.ConstantBuffers.Values);
            DeclareStorageBuffers(context, context.Properties.StorageBuffers.Values);
            DeclareMemories(context, context.Properties.LocalMemories, context.LocalMemories, StorageClass.Private);
            DeclareMemories(context, context.Properties.SharedMemories, context.SharedMemories, StorageClass.Workgroup);
            DeclareSamplers(context, context.Properties.Textures.Values);
            DeclareImages(context, context.Properties.Images.Values);
            DeclareInputsAndOutputs(context, info);
        }

        private static void DeclareMemories(
            CodeGenContext context,
            IReadOnlyDictionary<int, MemoryDefinition> memories,
            Dictionary<int, SpvInstruction> dict,
            StorageClass storage)
        {
            foreach ((int id, MemoryDefinition memory) in memories)
            {
                var pointerType = context.TypePointer(storage, context.GetType(memory.Type, memory.ArrayLength));
                var variable = context.Variable(pointerType, storage);

                context.AddGlobalVariable(variable);

                dict.Add(id, variable);
            }
=======
            if (context.Config.Stage == ShaderStage.Compute)
            {
                int localMemorySize = BitUtils.DivRoundUp(context.Config.GpuAccessor.QueryComputeLocalMemorySize(), 4);

                if (localMemorySize != 0)
                {
                    DeclareLocalMemory(context, localMemorySize);
                }

                int sharedMemorySize = BitUtils.DivRoundUp(context.Config.GpuAccessor.QueryComputeSharedMemorySize(), 4);

                if (sharedMemorySize != 0)
                {
                    DeclareSharedMemory(context, sharedMemorySize);
                }
            }
            else if (context.Config.LocalMemorySize != 0)
            {
                int localMemorySize = BitUtils.DivRoundUp(context.Config.LocalMemorySize, 4);
                DeclareLocalMemory(context, localMemorySize);
            }

            DeclareConstantBuffers(context, context.Config.Properties.ConstantBuffers.Values);
            DeclareStorageBuffers(context, context.Config.GetStorageBufferDescriptors());
            DeclareSamplers(context, context.Config.GetTextureDescriptors());
            DeclareImages(context, context.Config.GetImageDescriptors());
            DeclareInputsAndOutputs(context, info);
        }

        private static void DeclareLocalMemory(CodeGenContext context, int size)
        {
            context.LocalMemory = DeclareMemory(context, StorageClass.Private, size);
        }

        private static void DeclareSharedMemory(CodeGenContext context, int size)
        {
            context.SharedMemory = DeclareMemory(context, StorageClass.Workgroup, size);
        }

        private static SpvInstruction DeclareMemory(CodeGenContext context, StorageClass storage, int size)
        {
            var arrayType = context.TypeArray(context.TypeU32(), context.Constant(context.TypeU32(), size));
            var pointerType = context.TypePointer(storage, arrayType);
            var variable = context.Variable(pointerType, storage);

            context.AddGlobalVariable(variable);

            return variable;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static void DeclareConstantBuffers(CodeGenContext context, IEnumerable<BufferDefinition> buffers)
        {
<<<<<<< HEAD
            DeclareBuffers(context, buffers, isBuffer: false);
        }

        private static void DeclareStorageBuffers(CodeGenContext context, IEnumerable<BufferDefinition> buffers)
        {
            DeclareBuffers(context, buffers, isBuffer: true);
        }

        private static void DeclareBuffers(CodeGenContext context, IEnumerable<BufferDefinition> buffers, bool isBuffer)
        {
            HashSet<SpvInstruction> decoratedTypes = new();

            foreach (BufferDefinition buffer in buffers)
            {
                int setIndex = context.TargetApi == TargetApi.Vulkan ? buffer.Set : 0;
=======
            HashSet<SpvInstruction> decoratedTypes = new HashSet<SpvInstruction>();

            foreach (BufferDefinition buffer in buffers)
            {
>>>>>>> 1ec71635b (sync with main branch)
                int alignment = buffer.Layout == BufferLayout.Std140 ? 16 : 4;
                int alignmentMask = alignment - 1;
                int offset = 0;

                SpvInstruction[] structFieldTypes = new SpvInstruction[buffer.Type.Fields.Length];
                int[] structFieldOffsets = new int[buffer.Type.Fields.Length];

                for (int fieldIndex = 0; fieldIndex < buffer.Type.Fields.Length; fieldIndex++)
                {
                    StructureField field = buffer.Type.Fields[fieldIndex];
                    int fieldSize = (field.Type.GetSizeInBytes() + alignmentMask) & ~alignmentMask;

                    structFieldTypes[fieldIndex] = context.GetType(field.Type, field.ArrayLength);
                    structFieldOffsets[fieldIndex] = offset;

                    if (field.Type.HasFlag(AggregateType.Array))
                    {
                        // We can't decorate the type more than once.
                        if (decoratedTypes.Add(structFieldTypes[fieldIndex]))
                        {
                            context.Decorate(structFieldTypes[fieldIndex], Decoration.ArrayStride, (LiteralInteger)fieldSize);
                        }

<<<<<<< HEAD
                        // Zero lengths are assumed to be a "runtime array" (which does not have a explicit length
                        // specified on the shader, and instead assumes the bound buffer length).
                        // It is only valid as the last struct element.

                        Debug.Assert(field.ArrayLength > 0 || fieldIndex == buffer.Type.Fields.Length - 1);

=======
>>>>>>> 1ec71635b (sync with main branch)
                        offset += fieldSize * field.ArrayLength;
                    }
                    else
                    {
                        offset += fieldSize;
                    }
                }

<<<<<<< HEAD
                var structType = context.TypeStruct(false, structFieldTypes);

                if (decoratedTypes.Add(structType))
                {
                    context.Decorate(structType, isBuffer ? Decoration.BufferBlock : Decoration.Block);

                    for (int fieldIndex = 0; fieldIndex < structFieldOffsets.Length; fieldIndex++)
                    {
                        context.MemberDecorate(structType, fieldIndex, Decoration.Offset, (LiteralInteger)structFieldOffsets[fieldIndex]);
                    }
                }

                var pointerType = context.TypePointer(StorageClass.Uniform, structType);
                var variable = context.Variable(pointerType, StorageClass.Uniform);

                context.Name(variable, buffer.Name);
                context.Decorate(variable, Decoration.DescriptorSet, (LiteralInteger)setIndex);
                context.Decorate(variable, Decoration.Binding, (LiteralInteger)buffer.Binding);
                context.AddGlobalVariable(variable);

                if (isBuffer)
                {
                    context.StorageBuffers.Add(buffer.Binding, variable);
                }
                else
                {
                    context.ConstantBuffers.Add(buffer.Binding, variable);
                }
            }
        }

        private static void DeclareSamplers(CodeGenContext context, IEnumerable<TextureDefinition> samplers)
        {
            foreach (var sampler in samplers)
            {
                int setIndex = context.TargetApi == TargetApi.Vulkan ? sampler.Set : 0;

                var dim = (sampler.Type & SamplerType.Mask) switch
=======
                var ubStructType = context.TypeStruct(false, structFieldTypes);

                if (decoratedTypes.Add(ubStructType))
                {
                    context.Decorate(ubStructType, Decoration.Block);

                    for (int fieldIndex = 0; fieldIndex < structFieldOffsets.Length; fieldIndex++)
                    {
                        context.MemberDecorate(ubStructType, fieldIndex, Decoration.Offset, (LiteralInteger)structFieldOffsets[fieldIndex]);
                    }
                }

                var ubPointerType = context.TypePointer(StorageClass.Uniform, ubStructType);
                var ubVariable = context.Variable(ubPointerType, StorageClass.Uniform);

                context.Name(ubVariable, buffer.Name);
                context.Decorate(ubVariable, Decoration.DescriptorSet, (LiteralInteger)buffer.Set);
                context.Decorate(ubVariable, Decoration.Binding, (LiteralInteger)buffer.Binding);
                context.AddGlobalVariable(ubVariable);
                context.ConstantBuffers.Add(buffer.Binding, ubVariable);
            }
        }

        private static void DeclareStorageBuffers(CodeGenContext context, BufferDescriptor[] descriptors)
        {
            if (descriptors.Length == 0)
            {
                return;
            }

            int setIndex = context.Config.Options.TargetApi == TargetApi.Vulkan ? 1 : 0;
            int count = descriptors.Max(x => x.Slot) + 1;

            var sbArrayType = context.TypeRuntimeArray(context.TypeU32());
            context.Decorate(sbArrayType, Decoration.ArrayStride, (LiteralInteger)4);
            var sbStructType = context.TypeStruct(true, sbArrayType);
            context.Decorate(sbStructType, Decoration.BufferBlock);
            context.MemberDecorate(sbStructType, 0, Decoration.Offset, (LiteralInteger)0);
            var sbStructArrayType = context.TypeArray(sbStructType, context.Constant(context.TypeU32(), count));
            var sbPointerType = context.TypePointer(StorageClass.Uniform, sbStructArrayType);
            var sbVariable = context.Variable(sbPointerType, StorageClass.Uniform);

            context.Name(sbVariable, $"{GetStagePrefix(context.Config.Stage)}_s");
            context.Decorate(sbVariable, Decoration.DescriptorSet, (LiteralInteger)setIndex);
            context.Decorate(sbVariable, Decoration.Binding, (LiteralInteger)context.Config.FirstStorageBufferBinding);
            context.AddGlobalVariable(sbVariable);

            context.StorageBuffersArray = sbVariable;
        }

        private static void DeclareSamplers(CodeGenContext context, TextureDescriptor[] descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                var meta = new TextureMeta(descriptor.CbufSlot, descriptor.HandleIndex, descriptor.Format);

                if (context.Samplers.ContainsKey(meta))
                {
                    continue;
                }

                int setIndex = context.Config.Options.TargetApi == TargetApi.Vulkan ? 2 : 0;

                var dim = (descriptor.Type & SamplerType.Mask) switch
>>>>>>> 1ec71635b (sync with main branch)
                {
                    SamplerType.Texture1D => Dim.Dim1D,
                    SamplerType.Texture2D => Dim.Dim2D,
                    SamplerType.Texture3D => Dim.Dim3D,
                    SamplerType.TextureCube => Dim.Cube,
                    SamplerType.TextureBuffer => Dim.Buffer,
<<<<<<< HEAD
                    _ => throw new InvalidOperationException($"Invalid sampler type \"{sampler.Type & SamplerType.Mask}\"."),
=======
                    _ => throw new InvalidOperationException($"Invalid sampler type \"{descriptor.Type & SamplerType.Mask}\".")
>>>>>>> 1ec71635b (sync with main branch)
                };

                var imageType = context.TypeImage(
                    context.TypeFP32(),
                    dim,
<<<<<<< HEAD
                    sampler.Type.HasFlag(SamplerType.Shadow),
                    sampler.Type.HasFlag(SamplerType.Array),
                    sampler.Type.HasFlag(SamplerType.Multisample),
                    1,
                    ImageFormat.Unknown);

=======
                    descriptor.Type.HasFlag(SamplerType.Shadow),
                    descriptor.Type.HasFlag(SamplerType.Array),
                    descriptor.Type.HasFlag(SamplerType.Multisample),
                    1,
                    ImageFormat.Unknown);

                var nameSuffix = meta.CbufSlot < 0 ? $"_tcb_{meta.Handle:X}" : $"_cb{meta.CbufSlot}_{meta.Handle:X}";

>>>>>>> 1ec71635b (sync with main branch)
                var sampledImageType = context.TypeSampledImage(imageType);
                var sampledImagePointerType = context.TypePointer(StorageClass.UniformConstant, sampledImageType);
                var sampledImageVariable = context.Variable(sampledImagePointerType, StorageClass.UniformConstant);

<<<<<<< HEAD
                context.Samplers.Add(sampler.Binding, (imageType, sampledImageType, sampledImageVariable));
                context.SamplersTypes.Add(sampler.Binding, sampler.Type);

                context.Name(sampledImageVariable, sampler.Name);
                context.Decorate(sampledImageVariable, Decoration.DescriptorSet, (LiteralInteger)setIndex);
                context.Decorate(sampledImageVariable, Decoration.Binding, (LiteralInteger)sampler.Binding);
=======
                context.Samplers.Add(meta, (imageType, sampledImageType, sampledImageVariable));
                context.SamplersTypes.Add(meta, descriptor.Type);

                context.Name(sampledImageVariable, $"{GetStagePrefix(context.Config.Stage)}_tex{nameSuffix}");
                context.Decorate(sampledImageVariable, Decoration.DescriptorSet, (LiteralInteger)setIndex);
                context.Decorate(sampledImageVariable, Decoration.Binding, (LiteralInteger)descriptor.Binding);
>>>>>>> 1ec71635b (sync with main branch)
                context.AddGlobalVariable(sampledImageVariable);
            }
        }

<<<<<<< HEAD
        private static void DeclareImages(CodeGenContext context, IEnumerable<TextureDefinition> images)
        {
            foreach (var image in images)
            {
                int setIndex = context.TargetApi == TargetApi.Vulkan ? image.Set : 0;

                var dim = GetDim(image.Type);

                var imageType = context.TypeImage(
                    context.GetType(image.Format.GetComponentType()),
                    dim,
                    image.Type.HasFlag(SamplerType.Shadow),
                    image.Type.HasFlag(SamplerType.Array),
                    image.Type.HasFlag(SamplerType.Multisample),
                    AccessQualifier.ReadWrite,
                    GetImageFormat(image.Format));
=======
        private static void DeclareImages(CodeGenContext context, TextureDescriptor[] descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                var meta = new TextureMeta(descriptor.CbufSlot, descriptor.HandleIndex, descriptor.Format);

                if (context.Images.ContainsKey(meta))
                {
                    continue;
                }

                int setIndex = context.Config.Options.TargetApi == TargetApi.Vulkan ? 3 : 0;

                var dim = GetDim(descriptor.Type);

                var imageType = context.TypeImage(
                    context.GetType(meta.Format.GetComponentType()),
                    dim,
                    descriptor.Type.HasFlag(SamplerType.Shadow),
                    descriptor.Type.HasFlag(SamplerType.Array),
                    descriptor.Type.HasFlag(SamplerType.Multisample),
                    AccessQualifier.ReadWrite,
                    GetImageFormat(meta.Format));

                var nameSuffix = meta.CbufSlot < 0 ?
                    $"_tcb_{meta.Handle:X}_{meta.Format.ToGlslFormat()}" :
                    $"_cb{meta.CbufSlot}_{meta.Handle:X}_{meta.Format.ToGlslFormat()}";
>>>>>>> 1ec71635b (sync with main branch)

                var imagePointerType = context.TypePointer(StorageClass.UniformConstant, imageType);
                var imageVariable = context.Variable(imagePointerType, StorageClass.UniformConstant);

<<<<<<< HEAD
                context.Images.Add(image.Binding, (imageType, imageVariable));

                context.Name(imageVariable, image.Name);
                context.Decorate(imageVariable, Decoration.DescriptorSet, (LiteralInteger)setIndex);
                context.Decorate(imageVariable, Decoration.Binding, (LiteralInteger)image.Binding);

                if (image.Flags.HasFlag(TextureUsageFlags.ImageCoherent))
=======
                context.Images.Add(meta, (imageType, imageVariable));

                context.Name(imageVariable, $"{GetStagePrefix(context.Config.Stage)}_img{nameSuffix}");
                context.Decorate(imageVariable, Decoration.DescriptorSet, (LiteralInteger)setIndex);
                context.Decorate(imageVariable, Decoration.Binding, (LiteralInteger)descriptor.Binding);

                if (descriptor.Flags.HasFlag(TextureUsageFlags.ImageCoherent))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.Decorate(imageVariable, Decoration.Coherent);
                }

                context.AddGlobalVariable(imageVariable);
            }
        }

        private static Dim GetDim(SamplerType type)
        {
            return (type & SamplerType.Mask) switch
            {
                SamplerType.Texture1D => Dim.Dim1D,
                SamplerType.Texture2D => Dim.Dim2D,
                SamplerType.Texture3D => Dim.Dim3D,
                SamplerType.TextureCube => Dim.Cube,
                SamplerType.TextureBuffer => Dim.Buffer,
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid sampler type \"{type & SamplerType.Mask}\"."),
=======
                _ => throw new ArgumentException($"Invalid sampler type \"{type & SamplerType.Mask}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static ImageFormat GetImageFormat(TextureFormat format)
        {
            return format switch
            {
                TextureFormat.Unknown => ImageFormat.Unknown,
                TextureFormat.R8Unorm => ImageFormat.R8,
                TextureFormat.R8Snorm => ImageFormat.R8Snorm,
                TextureFormat.R8Uint => ImageFormat.R8ui,
                TextureFormat.R8Sint => ImageFormat.R8i,
                TextureFormat.R16Float => ImageFormat.R16f,
                TextureFormat.R16Unorm => ImageFormat.R16,
                TextureFormat.R16Snorm => ImageFormat.R16Snorm,
                TextureFormat.R16Uint => ImageFormat.R16ui,
                TextureFormat.R16Sint => ImageFormat.R16i,
                TextureFormat.R32Float => ImageFormat.R32f,
                TextureFormat.R32Uint => ImageFormat.R32ui,
                TextureFormat.R32Sint => ImageFormat.R32i,
                TextureFormat.R8G8Unorm => ImageFormat.Rg8,
                TextureFormat.R8G8Snorm => ImageFormat.Rg8Snorm,
                TextureFormat.R8G8Uint => ImageFormat.Rg8ui,
                TextureFormat.R8G8Sint => ImageFormat.Rg8i,
                TextureFormat.R16G16Float => ImageFormat.Rg16f,
                TextureFormat.R16G16Unorm => ImageFormat.Rg16,
                TextureFormat.R16G16Snorm => ImageFormat.Rg16Snorm,
                TextureFormat.R16G16Uint => ImageFormat.Rg16ui,
                TextureFormat.R16G16Sint => ImageFormat.Rg16i,
                TextureFormat.R32G32Float => ImageFormat.Rg32f,
                TextureFormat.R32G32Uint => ImageFormat.Rg32ui,
                TextureFormat.R32G32Sint => ImageFormat.Rg32i,
                TextureFormat.R8G8B8A8Unorm => ImageFormat.Rgba8,
                TextureFormat.R8G8B8A8Snorm => ImageFormat.Rgba8Snorm,
                TextureFormat.R8G8B8A8Uint => ImageFormat.Rgba8ui,
                TextureFormat.R8G8B8A8Sint => ImageFormat.Rgba8i,
                TextureFormat.R16G16B16A16Float => ImageFormat.Rgba16f,
                TextureFormat.R16G16B16A16Unorm => ImageFormat.Rgba16,
                TextureFormat.R16G16B16A16Snorm => ImageFormat.Rgba16Snorm,
                TextureFormat.R16G16B16A16Uint => ImageFormat.Rgba16ui,
                TextureFormat.R16G16B16A16Sint => ImageFormat.Rgba16i,
                TextureFormat.R32G32B32A32Float => ImageFormat.Rgba32f,
                TextureFormat.R32G32B32A32Uint => ImageFormat.Rgba32ui,
                TextureFormat.R32G32B32A32Sint => ImageFormat.Rgba32i,
                TextureFormat.R10G10B10A2Unorm => ImageFormat.Rgb10A2,
                TextureFormat.R10G10B10A2Uint => ImageFormat.Rgb10a2ui,
                TextureFormat.R11G11B10Float => ImageFormat.R11fG11fB10f,
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid texture format \"{format}\"."),
=======
                _ => throw new ArgumentException($"Invalid texture format \"{format}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static void DeclareInputsAndOutputs(CodeGenContext context, StructuredProgramInfo info)
        {
<<<<<<< HEAD
            int firstLocation = int.MaxValue;

            if (context.Definitions.Stage == ShaderStage.Fragment && context.Definitions.DualSourceBlend)
            {
                foreach (var ioDefinition in info.IoDefinitions)
                {
                    if (ioDefinition.IoVariable == IoVariable.FragmentOutputColor && ioDefinition.Location < firstLocation)
                    {
                        firstLocation = ioDefinition.Location;
                    }
                }
            }

=======
>>>>>>> 1ec71635b (sync with main branch)
            foreach (var ioDefinition in info.IoDefinitions)
            {
                PixelImap iq = PixelImap.Unused;

<<<<<<< HEAD
                if (context.Definitions.Stage == ShaderStage.Fragment)
=======
                if (context.Config.Stage == ShaderStage.Fragment)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    var ioVariable = ioDefinition.IoVariable;
                    if (ioVariable == IoVariable.UserDefined)
                    {
<<<<<<< HEAD
                        iq = context.Definitions.ImapTypes[ioDefinition.Location].GetFirstUsedType();
=======
                        iq = context.Config.ImapTypes[ioDefinition.Location].GetFirstUsedType();
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    else
                    {
                        (_, AggregateType varType) = IoMap.GetSpirvBuiltIn(ioVariable);
                        AggregateType elemType = varType & AggregateType.ElementTypeMask;

<<<<<<< HEAD
                        if (elemType is AggregateType.S32 or AggregateType.U32)
=======
                        if (elemType == AggregateType.S32 || elemType == AggregateType.U32)
>>>>>>> 1ec71635b (sync with main branch)
                        {
                            iq = PixelImap.Constant;
                        }
                    }
                }
<<<<<<< HEAD
                else if (IoMap.IsPerVertexBuiltIn(ioDefinition.IoVariable))
                {
                    continue;
                }
=======
>>>>>>> 1ec71635b (sync with main branch)

                bool isOutput = ioDefinition.StorageKind.IsOutput();
                bool isPerPatch = ioDefinition.StorageKind.IsPerPatch();

<<<<<<< HEAD
                DeclareInputOrOutput(context, ioDefinition, isOutput, isPerPatch, iq, firstLocation);
            }

            DeclarePerVertexBlock(context);
        }

        private static void DeclarePerVertexBlock(CodeGenContext context)
        {
            if (context.Definitions.Stage.IsVtg())
            {
                if (context.Definitions.Stage != ShaderStage.Vertex)
                {
                    var perVertexInputStructType = CreatePerVertexStructType(context);
                    int arraySize = context.Definitions.Stage == ShaderStage.Geometry ? context.Definitions.InputTopology.ToInputVertices() : 32;
                    var perVertexInputArrayType = context.TypeArray(perVertexInputStructType, context.Constant(context.TypeU32(), arraySize));
                    var perVertexInputPointerType = context.TypePointer(StorageClass.Input, perVertexInputArrayType);
                    var perVertexInputVariable = context.Variable(perVertexInputPointerType, StorageClass.Input);

                    context.Name(perVertexInputVariable, "gl_in");

                    context.AddGlobalVariable(perVertexInputVariable);
                    context.Inputs.Add(new IoDefinition(StorageKind.Input, IoVariable.Position), perVertexInputVariable);
                }

                var perVertexOutputStructType = CreatePerVertexStructType(context);

                void DecorateTfo(IoVariable ioVariable, int fieldIndex)
                {
                    if (context.Definitions.TryGetTransformFeedbackOutput(ioVariable, 0, 0, out var transformFeedbackOutput))
                    {
                        context.MemberDecorate(perVertexOutputStructType, fieldIndex, Decoration.XfbBuffer, (LiteralInteger)transformFeedbackOutput.Buffer);
                        context.MemberDecorate(perVertexOutputStructType, fieldIndex, Decoration.XfbStride, (LiteralInteger)transformFeedbackOutput.Stride);
                        context.MemberDecorate(perVertexOutputStructType, fieldIndex, Decoration.Offset, (LiteralInteger)transformFeedbackOutput.Offset);
                    }
                }

                DecorateTfo(IoVariable.Position, 0);
                DecorateTfo(IoVariable.PointSize, 1);
                DecorateTfo(IoVariable.ClipDistance, 2);

                SpvInstruction perVertexOutputArrayType;

                if (context.Definitions.Stage == ShaderStage.TessellationControl)
                {
                    int arraySize = context.Definitions.ThreadsPerInputPrimitive;
                    perVertexOutputArrayType = context.TypeArray(perVertexOutputStructType, context.Constant(context.TypeU32(), arraySize));
                }
                else
                {
                    perVertexOutputArrayType = perVertexOutputStructType;
                }

                var perVertexOutputPointerType = context.TypePointer(StorageClass.Output, perVertexOutputArrayType);
                var perVertexOutputVariable = context.Variable(perVertexOutputPointerType, StorageClass.Output);

                context.AddGlobalVariable(perVertexOutputVariable);
                context.Outputs.Add(new IoDefinition(StorageKind.Output, IoVariable.Position), perVertexOutputVariable);
            }
        }

        private static SpvInstruction CreatePerVertexStructType(CodeGenContext context)
        {
            var vec4FloatType = context.TypeVector(context.TypeFP32(), 4);
            var floatType = context.TypeFP32();
            var array8FloatType = context.TypeArray(context.TypeFP32(), context.Constant(context.TypeU32(), 8));
            var array1FloatType = context.TypeArray(context.TypeFP32(), context.Constant(context.TypeU32(), 1));

            var perVertexStructType = context.TypeStruct(true, vec4FloatType, floatType, array8FloatType, array1FloatType);

            context.Name(perVertexStructType, "gl_PerVertex");

            context.MemberName(perVertexStructType, 0, "gl_Position");
            context.MemberName(perVertexStructType, 1, "gl_PointSize");
            context.MemberName(perVertexStructType, 2, "gl_ClipDistance");
            context.MemberName(perVertexStructType, 3, "gl_CullDistance");

            context.Decorate(perVertexStructType, Decoration.Block);

            if (context.HostCapabilities.ReducedPrecision)
            {
                context.MemberDecorate(perVertexStructType, 0, Decoration.Invariant);
            }

            context.MemberDecorate(perVertexStructType, 0, Decoration.BuiltIn, (LiteralInteger)BuiltIn.Position);
            context.MemberDecorate(perVertexStructType, 1, Decoration.BuiltIn, (LiteralInteger)BuiltIn.PointSize);
            context.MemberDecorate(perVertexStructType, 2, Decoration.BuiltIn, (LiteralInteger)BuiltIn.ClipDistance);
            context.MemberDecorate(perVertexStructType, 3, Decoration.BuiltIn, (LiteralInteger)BuiltIn.CullDistance);

            return perVertexStructType;
        }

        private static void DeclareInputOrOutput(
            CodeGenContext context,
            IoDefinition ioDefinition,
            bool isOutput,
            bool isPerPatch,
            PixelImap iq = PixelImap.Unused,
            int firstLocation = 0)
=======
                DeclareInputOrOutput(context, ioDefinition, isOutput, isPerPatch, iq);
            }
        }

        private static void DeclareInputOrOutput(CodeGenContext context, IoDefinition ioDefinition, bool isOutput, bool isPerPatch, PixelImap iq = PixelImap.Unused)
>>>>>>> 1ec71635b (sync with main branch)
        {
            IoVariable ioVariable = ioDefinition.IoVariable;
            var storageClass = isOutput ? StorageClass.Output : StorageClass.Input;

            bool isBuiltIn;
            BuiltIn builtIn = default;
            AggregateType varType;

            if (ioVariable == IoVariable.UserDefined)
            {
<<<<<<< HEAD
                varType = context.Definitions.GetUserDefinedType(ioDefinition.Location, isOutput);
=======
                varType = context.Config.GetUserDefinedType(ioDefinition.Location, isOutput);
>>>>>>> 1ec71635b (sync with main branch)
                isBuiltIn = false;
            }
            else if (ioVariable == IoVariable.FragmentOutputColor)
            {
<<<<<<< HEAD
                varType = context.Definitions.GetFragmentOutputColorType(ioDefinition.Location);
=======
                varType = context.Config.GetFragmentOutputColorType(ioDefinition.Location);
>>>>>>> 1ec71635b (sync with main branch)
                isBuiltIn = false;
            }
            else
            {
                (builtIn, varType) = IoMap.GetSpirvBuiltIn(ioVariable);
                isBuiltIn = true;

                if (varType == AggregateType.Invalid)
                {
                    throw new InvalidOperationException($"Unknown variable {ioVariable}.");
                }
            }

<<<<<<< HEAD
            bool hasComponent = context.Definitions.HasPerLocationInputOrOutputComponent(ioVariable, ioDefinition.Location, ioDefinition.Component, isOutput);
=======
            bool hasComponent = context.Config.HasPerLocationInputOrOutputComponent(ioVariable, ioDefinition.Location, ioDefinition.Component, isOutput);
>>>>>>> 1ec71635b (sync with main branch)

            if (hasComponent)
            {
                varType &= AggregateType.ElementTypeMask;
            }
<<<<<<< HEAD
            else if (ioVariable == IoVariable.UserDefined && context.Definitions.HasTransformFeedbackOutputs(isOutput))
            {
                varType &= AggregateType.ElementTypeMask;
                varType |= context.Definitions.GetTransformFeedbackOutputComponents(ioDefinition.Location, ioDefinition.Component) switch
=======
            else if (ioVariable == IoVariable.UserDefined && context.Config.HasTransformFeedbackOutputs(isOutput))
            {
                varType &= AggregateType.ElementTypeMask;
                varType |= context.Config.GetTransformFeedbackOutputComponents(ioDefinition.Location, ioDefinition.Component) switch
>>>>>>> 1ec71635b (sync with main branch)
                {
                    2 => AggregateType.Vector2,
                    3 => AggregateType.Vector3,
                    4 => AggregateType.Vector4,
<<<<<<< HEAD
                    _ => AggregateType.Invalid,
=======
                    _ => AggregateType.Invalid
>>>>>>> 1ec71635b (sync with main branch)
                };
            }

            var spvType = context.GetType(varType, IoMap.GetSpirvBuiltInArrayLength(ioVariable));
            bool builtInPassthrough = false;

<<<<<<< HEAD
            if (!isPerPatch && IoMap.IsPerVertex(ioVariable, context.Definitions.Stage, isOutput))
            {
                int arraySize = context.Definitions.Stage == ShaderStage.Geometry ? context.Definitions.InputTopology.ToInputVertices() : 32;
                spvType = context.TypeArray(spvType, context.Constant(context.TypeU32(), arraySize));

                if (context.Definitions.GpPassthrough && context.HostCapabilities.SupportsGeometryShaderPassthrough)
=======
            if (!isPerPatch && IoMap.IsPerVertex(ioVariable, context.Config.Stage, isOutput))
            {
                int arraySize = context.Config.Stage == ShaderStage.Geometry ? context.InputVertices : 32;
                spvType = context.TypeArray(spvType, context.Constant(context.TypeU32(), (LiteralInteger)arraySize));

                if (context.Config.GpPassthrough && context.Config.GpuAccessor.QueryHostSupportsGeometryShaderPassthrough())
>>>>>>> 1ec71635b (sync with main branch)
                {
                    builtInPassthrough = true;
                }
            }

<<<<<<< HEAD
            if (context.Definitions.Stage == ShaderStage.TessellationControl && isOutput && !isPerPatch)
            {
                spvType = context.TypeArray(spvType, context.Constant(context.TypeU32(), context.Definitions.ThreadsPerInputPrimitive));
=======
            if (context.Config.Stage == ShaderStage.TessellationControl && isOutput && !isPerPatch)
            {
                spvType = context.TypeArray(spvType, context.Constant(context.TypeU32(), context.Config.ThreadsPerInputPrimitive));
>>>>>>> 1ec71635b (sync with main branch)
            }

            var spvPointerType = context.TypePointer(storageClass, spvType);
            var spvVar = context.Variable(spvPointerType, storageClass);

            if (builtInPassthrough)
            {
                context.Decorate(spvVar, Decoration.PassthroughNV);
            }

            if (isBuiltIn)
            {
                if (isPerPatch)
                {
                    context.Decorate(spvVar, Decoration.Patch);
                }

<<<<<<< HEAD
                if (context.HostCapabilities.ReducedPrecision && ioVariable == IoVariable.Position)
=======
                if (context.Config.GpuAccessor.QueryHostReducedPrecision() && ioVariable == IoVariable.Position)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.Decorate(spvVar, Decoration.Invariant);
                }

                context.Decorate(spvVar, Decoration.BuiltIn, (LiteralInteger)builtIn);
            }
            else if (isPerPatch)
            {
                context.Decorate(spvVar, Decoration.Patch);

                if (ioVariable == IoVariable.UserDefined)
                {
<<<<<<< HEAD
                    int location = context.AttributeUsage.GetPerPatchAttributeLocation(ioDefinition.Location);
=======
                    int location = context.Config.GetPerPatchAttributeLocation(ioDefinition.Location);
>>>>>>> 1ec71635b (sync with main branch)

                    context.Decorate(spvVar, Decoration.Location, (LiteralInteger)location);
                }
            }
            else if (ioVariable == IoVariable.UserDefined)
            {
                context.Decorate(spvVar, Decoration.Location, (LiteralInteger)ioDefinition.Location);

                if (hasComponent)
                {
                    context.Decorate(spvVar, Decoration.Component, (LiteralInteger)ioDefinition.Component);
                }

                if (!isOutput &&
                    !isPerPatch &&
<<<<<<< HEAD
                    (context.AttributeUsage.PassthroughAttributes & (1 << ioDefinition.Location)) != 0 &&
                    context.HostCapabilities.SupportsGeometryShaderPassthrough)
=======
                    (context.Config.PassthroughAttributes & (1 << ioDefinition.Location)) != 0 &&
                    context.Config.GpuAccessor.QueryHostSupportsGeometryShaderPassthrough())
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.Decorate(spvVar, Decoration.PassthroughNV);
                }
            }
            else if (ioVariable == IoVariable.FragmentOutputColor)
            {
                int location = ioDefinition.Location;

<<<<<<< HEAD
                if (context.Definitions.Stage == ShaderStage.Fragment && context.Definitions.DualSourceBlend)
                {
                    int index = location - firstLocation;

                    if ((uint)index < 2)
=======
                if (context.Config.Stage == ShaderStage.Fragment && context.Config.GpuAccessor.QueryDualSourceBlendEnable())
                {
                    int firstLocation = BitOperations.TrailingZeroCount(context.Config.UsedOutputAttributes);
                    int index = location - firstLocation;
                    int mask = 3 << firstLocation;

                    if ((uint)index < 2 && (context.Config.UsedOutputAttributes & mask) == mask)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        context.Decorate(spvVar, Decoration.Location, (LiteralInteger)firstLocation);
                        context.Decorate(spvVar, Decoration.Index, (LiteralInteger)index);
                    }
                    else
                    {
                        context.Decorate(spvVar, Decoration.Location, (LiteralInteger)location);
                    }
                }
                else
                {
                    context.Decorate(spvVar, Decoration.Location, (LiteralInteger)location);
                }
            }

            if (!isOutput)
            {
                switch (iq)
                {
                    case PixelImap.Constant:
                        context.Decorate(spvVar, Decoration.Flat);
                        break;
                    case PixelImap.ScreenLinear:
                        context.Decorate(spvVar, Decoration.NoPerspective);
                        break;
                }
            }
<<<<<<< HEAD
            else if (context.Definitions.TryGetTransformFeedbackOutput(
=======
            else if (context.Config.TryGetTransformFeedbackOutput(
>>>>>>> 1ec71635b (sync with main branch)
                ioVariable,
                ioDefinition.Location,
                ioDefinition.Component,
                out var transformFeedbackOutput))
            {
                context.Decorate(spvVar, Decoration.XfbBuffer, (LiteralInteger)transformFeedbackOutput.Buffer);
                context.Decorate(spvVar, Decoration.XfbStride, (LiteralInteger)transformFeedbackOutput.Stride);
                context.Decorate(spvVar, Decoration.Offset, (LiteralInteger)transformFeedbackOutput.Offset);
            }

            context.AddGlobalVariable(spvVar);

            var dict = isPerPatch
                ? (isOutput ? context.OutputsPerPatch : context.InputsPerPatch)
                : (isOutput ? context.Outputs : context.Inputs);
            dict.Add(ioDefinition, spvVar);
        }
<<<<<<< HEAD
=======

        private static string GetStagePrefix(ShaderStage stage)
        {
            return StagePrefixes[(int)stage];
        }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
