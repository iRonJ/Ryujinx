using Ryujinx.Common;
<<<<<<< HEAD
using Ryujinx.Graphics.Shader.IntermediateRepresentation;
=======
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.Shader.StructuredIr;
using Ryujinx.Graphics.Shader.Translation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Ryujinx.Graphics.Shader.CodeGen.Glsl
{
    static class Declarations
    {
        public static void Declare(CodeGenContext context, StructuredProgramInfo info)
        {
<<<<<<< HEAD
            context.AppendLine(context.TargetApi == TargetApi.Vulkan ? "#version 460 core" : "#version 450 core");
            context.AppendLine("#extension GL_ARB_gpu_shader_int64 : enable");

            if (context.HostCapabilities.SupportsShaderBallot)
=======
            context.AppendLine(context.Config.Options.TargetApi == TargetApi.Vulkan ? "#version 460 core" : "#version 450 core");
            context.AppendLine("#extension GL_ARB_gpu_shader_int64 : enable");

            if (context.Config.GpuAccessor.QueryHostSupportsShaderBallot())
>>>>>>> 1ec71635b (sync with main branch)
            {
                context.AppendLine("#extension GL_ARB_shader_ballot : enable");
            }
            else
            {
                context.AppendLine("#extension GL_KHR_shader_subgroup_basic : enable");
                context.AppendLine("#extension GL_KHR_shader_subgroup_ballot : enable");
<<<<<<< HEAD
                context.AppendLine("#extension GL_KHR_shader_subgroup_shuffle : enable");
=======
>>>>>>> 1ec71635b (sync with main branch)
            }

            context.AppendLine("#extension GL_ARB_shader_group_vote : enable");
            context.AppendLine("#extension GL_EXT_shader_image_load_formatted : enable");
            context.AppendLine("#extension GL_EXT_texture_shadow_lod : enable");

<<<<<<< HEAD
            if (context.Definitions.Stage == ShaderStage.Compute)
            {
                context.AppendLine("#extension GL_ARB_compute_shader : enable");
            }
            else if (context.Definitions.Stage == ShaderStage.Fragment)
            {
                if (context.HostCapabilities.SupportsFragmentShaderInterlock)
                {
                    context.AppendLine("#extension GL_ARB_fragment_shader_interlock : enable");
                }
                else if (context.HostCapabilities.SupportsFragmentShaderOrderingIntel)
=======
            if (context.Config.Stage == ShaderStage.Compute)
            {
                context.AppendLine("#extension GL_ARB_compute_shader : enable");
            }
            else if (context.Config.Stage == ShaderStage.Fragment)
            {
                if (context.Config.GpuAccessor.QueryHostSupportsFragmentShaderInterlock())
                {
                    context.AppendLine("#extension GL_ARB_fragment_shader_interlock : enable");
                }
                else if (context.Config.GpuAccessor.QueryHostSupportsFragmentShaderOrderingIntel())
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.AppendLine("#extension GL_INTEL_fragment_shader_ordering : enable");
                }
            }
            else
            {
<<<<<<< HEAD
                if (context.Definitions.Stage == ShaderStage.Vertex)
=======
                if (context.Config.Stage == ShaderStage.Vertex)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    context.AppendLine("#extension GL_ARB_shader_draw_parameters : enable");
                }

                context.AppendLine("#extension GL_ARB_shader_viewport_layer_array : enable");
            }

<<<<<<< HEAD
            if (context.Definitions.GpPassthrough && context.HostCapabilities.SupportsGeometryShaderPassthrough)
=======
            if (context.Config.GpPassthrough && context.Config.GpuAccessor.QueryHostSupportsGeometryShaderPassthrough())
>>>>>>> 1ec71635b (sync with main branch)
            {
                context.AppendLine("#extension GL_NV_geometry_shader_passthrough : enable");
            }

<<<<<<< HEAD
            if (context.HostCapabilities.SupportsViewportMask)
=======
            if (context.Config.GpuAccessor.QueryHostSupportsViewportMask())
>>>>>>> 1ec71635b (sync with main branch)
            {
                context.AppendLine("#extension GL_NV_viewport_array2 : enable");
            }

            context.AppendLine("#pragma optionNV(fastmath off)");
            context.AppendLine();

            context.AppendLine($"const int {DefaultNames.UndefinedName} = 0;");
            context.AppendLine();

<<<<<<< HEAD
            DeclareConstantBuffers(context, context.Properties.ConstantBuffers.Values);
            DeclareStorageBuffers(context, context.Properties.StorageBuffers.Values);
            DeclareMemories(context, context.Properties.LocalMemories.Values, isShared: false);
            DeclareMemories(context, context.Properties.SharedMemories.Values, isShared: true);
            DeclareSamplers(context, context.Properties.Textures.Values);
            DeclareImages(context, context.Properties.Images.Values);

            if (context.Definitions.Stage != ShaderStage.Compute)
            {
                if (context.Definitions.Stage == ShaderStage.Geometry)
                {
                    string inPrimitive = context.Definitions.InputTopology.ToGlslString();

                    context.AppendLine($"layout (invocations = {context.Definitions.ThreadsPerInputPrimitive}, {inPrimitive}) in;");

                    if (context.Definitions.GpPassthrough && context.HostCapabilities.SupportsGeometryShaderPassthrough)
=======
            if (context.Config.Stage == ShaderStage.Compute)
            {
                int localMemorySize = BitUtils.DivRoundUp(context.Config.GpuAccessor.QueryComputeLocalMemorySize(), 4);

                if (localMemorySize != 0)
                {
                    string localMemorySizeStr = NumberFormatter.FormatInt(localMemorySize);

                    context.AppendLine($"uint {DefaultNames.LocalMemoryName}[{localMemorySizeStr}];");
                    context.AppendLine();
                }

                int sharedMemorySize = BitUtils.DivRoundUp(context.Config.GpuAccessor.QueryComputeSharedMemorySize(), 4);

                if (sharedMemorySize != 0)
                {
                    string sharedMemorySizeStr = NumberFormatter.FormatInt(sharedMemorySize);

                    context.AppendLine($"shared uint {DefaultNames.SharedMemoryName}[{sharedMemorySizeStr}];");
                    context.AppendLine();
                }
            }
            else if (context.Config.LocalMemorySize != 0)
            {
                int localMemorySize = BitUtils.DivRoundUp(context.Config.LocalMemorySize, 4);

                string localMemorySizeStr = NumberFormatter.FormatInt(localMemorySize);

                context.AppendLine($"uint {DefaultNames.LocalMemoryName}[{localMemorySizeStr}];");
                context.AppendLine();
            }

            DeclareConstantBuffers(context, context.Config.Properties.ConstantBuffers.Values);

            var sBufferDescriptors = context.Config.GetStorageBufferDescriptors();
            if (sBufferDescriptors.Length != 0)
            {
                DeclareStorages(context, sBufferDescriptors);

                context.AppendLine();
            }

            var textureDescriptors = context.Config.GetTextureDescriptors();
            if (textureDescriptors.Length != 0)
            {
                DeclareSamplers(context, textureDescriptors);

                context.AppendLine();
            }

            var imageDescriptors = context.Config.GetImageDescriptors();
            if (imageDescriptors.Length != 0)
            {
                DeclareImages(context, imageDescriptors);

                context.AppendLine();
            }

            if (context.Config.Stage != ShaderStage.Compute)
            {
                if (context.Config.Stage == ShaderStage.Geometry)
                {
                    InputTopology inputTopology = context.Config.GpuAccessor.QueryPrimitiveTopology();
                    string inPrimitive = inputTopology.ToGlslString();

                    context.AppendLine($"layout (invocations = {context.Config.ThreadsPerInputPrimitive}, {inPrimitive}) in;");

                    if (context.Config.GpPassthrough && context.Config.GpuAccessor.QueryHostSupportsGeometryShaderPassthrough())
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        context.AppendLine($"layout (passthrough) in gl_PerVertex");
                        context.EnterScope();
                        context.AppendLine("vec4 gl_Position;");
                        context.AppendLine("float gl_PointSize;");
                        context.AppendLine("float gl_ClipDistance[];");
                        context.LeaveScope(";");
                    }
                    else
                    {
<<<<<<< HEAD
                        string outPrimitive = context.Definitions.OutputTopology.ToGlslString();
                        int maxOutputVertices = context.Definitions.MaxOutputVertices;
=======
                        string outPrimitive = context.Config.OutputTopology.ToGlslString();

                        int maxOutputVertices = context.Config.GpPassthrough
                            ? inputTopology.ToInputVertices()
                            : context.Config.MaxOutputVertices;
>>>>>>> 1ec71635b (sync with main branch)

                        context.AppendLine($"layout ({outPrimitive}, max_vertices = {maxOutputVertices}) out;");
                    }

                    context.AppendLine();
                }
<<<<<<< HEAD
                else if (context.Definitions.Stage == ShaderStage.TessellationControl)
                {
                    int threadsPerInputPrimitive = context.Definitions.ThreadsPerInputPrimitive;
=======
                else if (context.Config.Stage == ShaderStage.TessellationControl)
                {
                    int threadsPerInputPrimitive = context.Config.ThreadsPerInputPrimitive;
>>>>>>> 1ec71635b (sync with main branch)

                    context.AppendLine($"layout (vertices = {threadsPerInputPrimitive}) out;");
                    context.AppendLine();
                }
<<<<<<< HEAD
                else if (context.Definitions.Stage == ShaderStage.TessellationEvaluation)
                {
                    bool tessCw = context.Definitions.TessCw;

                    if (context.TargetApi == TargetApi.Vulkan)
=======
                else if (context.Config.Stage == ShaderStage.TessellationEvaluation)
                {
                    bool tessCw = context.Config.GpuAccessor.QueryTessCw();

                    if (context.Config.Options.TargetApi == TargetApi.Vulkan)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        // We invert the front face on Vulkan backend, so we need to do that here aswell.
                        tessCw = !tessCw;
                    }

<<<<<<< HEAD
                    string patchType = context.Definitions.TessPatchType.ToGlsl();
                    string spacing = context.Definitions.TessSpacing.ToGlsl();
=======
                    string patchType = context.Config.GpuAccessor.QueryTessPatchType().ToGlsl();
                    string spacing = context.Config.GpuAccessor.QueryTessSpacing().ToGlsl();
>>>>>>> 1ec71635b (sync with main branch)
                    string windingOrder = tessCw ? "cw" : "ccw";

                    context.AppendLine($"layout ({patchType}, {spacing}, {windingOrder}) in;");
                    context.AppendLine();
                }

<<<<<<< HEAD
                static bool IsUserDefined(IoDefinition ioDefinition, StorageKind storageKind)
                {
                    return ioDefinition.StorageKind == storageKind && ioDefinition.IoVariable == IoVariable.UserDefined;
                }

                static bool IsUserDefinedOutput(ShaderStage stage, IoDefinition ioDefinition)
                {
                    IoVariable ioVariable = stage == ShaderStage.Fragment ? IoVariable.FragmentOutputColor : IoVariable.UserDefined;
                    return ioDefinition.StorageKind == StorageKind.Output && ioDefinition.IoVariable == ioVariable;
                }

                DeclareInputAttributes(context, info.IoDefinitions.Where(x => IsUserDefined(x, StorageKind.Input)));
                DeclareOutputAttributes(context, info.IoDefinitions.Where(x => IsUserDefinedOutput(context.Definitions.Stage, x)));
                DeclareInputAttributesPerPatch(context, info.IoDefinitions.Where(x => IsUserDefined(x, StorageKind.InputPerPatch)));
                DeclareOutputAttributesPerPatch(context, info.IoDefinitions.Where(x => IsUserDefined(x, StorageKind.OutputPerPatch)));

                if (context.Definitions.TransformFeedbackEnabled && context.Definitions.LastInVertexPipeline)
                {
                    var tfOutput = context.Definitions.GetTransformFeedbackOutput(AttributeConsts.PositionX);
=======
                if (context.Config.UsedInputAttributes != 0 || context.Config.GpPassthrough)
                {
                    DeclareInputAttributes(context, info);

                    context.AppendLine();
                }

                if (context.Config.UsedOutputAttributes != 0 || context.Config.Stage != ShaderStage.Fragment)
                {
                    DeclareOutputAttributes(context, info);

                    context.AppendLine();
                }

                if (context.Config.UsedInputAttributesPerPatch.Count != 0)
                {
                    DeclareInputAttributesPerPatch(context, context.Config.UsedInputAttributesPerPatch);

                    context.AppendLine();
                }

                if (context.Config.UsedOutputAttributesPerPatch.Count != 0)
                {
                    DeclareUsedOutputAttributesPerPatch(context, context.Config.UsedOutputAttributesPerPatch);

                    context.AppendLine();
                }

                if (context.Config.TransformFeedbackEnabled && context.Config.LastInVertexPipeline)
                {
                    var tfOutput = context.Config.GetTransformFeedbackOutput(AttributeConsts.PositionX);
>>>>>>> 1ec71635b (sync with main branch)
                    if (tfOutput.Valid)
                    {
                        context.AppendLine($"layout (xfb_buffer = {tfOutput.Buffer}, xfb_offset = {tfOutput.Offset}, xfb_stride = {tfOutput.Stride}) out gl_PerVertex");
                        context.EnterScope();
                        context.AppendLine("vec4 gl_Position;");
<<<<<<< HEAD
                        context.LeaveScope(context.Definitions.Stage == ShaderStage.TessellationControl ? " gl_out[];" : ";");
=======
                        context.LeaveScope(context.Config.Stage == ShaderStage.TessellationControl ? " gl_out[];" : ";");
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }
            }
            else
            {
<<<<<<< HEAD
                string localSizeX = NumberFormatter.FormatInt(context.Definitions.ComputeLocalSizeX);
                string localSizeY = NumberFormatter.FormatInt(context.Definitions.ComputeLocalSizeY);
                string localSizeZ = NumberFormatter.FormatInt(context.Definitions.ComputeLocalSizeZ);
=======
                string localSizeX = NumberFormatter.FormatInt(context.Config.GpuAccessor.QueryComputeLocalSizeX());
                string localSizeY = NumberFormatter.FormatInt(context.Config.GpuAccessor.QueryComputeLocalSizeY());
                string localSizeZ = NumberFormatter.FormatInt(context.Config.GpuAccessor.QueryComputeLocalSizeZ());
>>>>>>> 1ec71635b (sync with main branch)

                context.AppendLine(
                    "layout (" +
                    $"local_size_x = {localSizeX}, " +
                    $"local_size_y = {localSizeY}, " +
                    $"local_size_z = {localSizeZ}) in;");
                context.AppendLine();
            }

<<<<<<< HEAD
            if (context.Definitions.Stage == ShaderStage.Fragment)
            {
                if (context.Definitions.EarlyZForce)
                {
                    context.AppendLine("layout (early_fragment_tests) in;");
                    context.AppendLine();
                }

                if (context.Definitions.OriginUpperLeft)
                {
                    context.AppendLine("layout (origin_upper_left) in vec4 gl_FragCoord;");
                    context.AppendLine();
                }
=======
            if (context.Config.Stage == ShaderStage.Fragment && context.Config.GpuAccessor.QueryEarlyZForce())
            {
                context.AppendLine("layout(early_fragment_tests) in;");
                context.AppendLine();
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.AtomicMinMaxS32Shared) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/AtomicMinMaxS32Shared.glsl");
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.AtomicMinMaxS32Storage) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/AtomicMinMaxS32Storage.glsl");
>>>>>>> 1ec71635b (sync with main branch)
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.MultiplyHighS32) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/MultiplyHighS32.glsl");
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.MultiplyHighU32) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/MultiplyHighU32.glsl");
            }

<<<<<<< HEAD
=======
            if ((info.HelperFunctionsMask & HelperFunctionsMask.Shuffle) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/Shuffle.glsl");
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.ShuffleDown) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/ShuffleDown.glsl");
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.ShuffleUp) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/ShuffleUp.glsl");
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.ShuffleXor) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/ShuffleXor.glsl");
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.StoreSharedSmallInt) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/StoreSharedSmallInt.glsl");
            }

            if ((info.HelperFunctionsMask & HelperFunctionsMask.StoreStorageSmallInt) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/StoreStorageSmallInt.glsl");
            }

>>>>>>> 1ec71635b (sync with main branch)
            if ((info.HelperFunctionsMask & HelperFunctionsMask.SwizzleAdd) != 0)
            {
                AppendHelperFunction(context, "Ryujinx.Graphics.Shader/CodeGen/Glsl/HelperFunctions/SwizzleAdd.glsl");
            }
        }

<<<<<<< HEAD
=======
        private static string GetTfLayout(TransformFeedbackOutput tfOutput)
        {
            if (tfOutput.Valid)
            {
                return $"layout (xfb_buffer = {tfOutput.Buffer}, xfb_offset = {tfOutput.Offset}, xfb_stride = {tfOutput.Stride}) ";
            }

            return string.Empty;
        }

>>>>>>> 1ec71635b (sync with main branch)
        public static void DeclareLocals(CodeGenContext context, StructuredFunction function)
        {
            foreach (AstOperand decl in function.Locals)
            {
                string name = context.OperandManager.DeclareLocal(decl);

                context.AppendLine(GetVarTypeName(context, decl.VarType) + " " + name + ";");
            }
        }

        public static string GetVarTypeName(CodeGenContext context, AggregateType type, bool precise = true)
        {
<<<<<<< HEAD
            if (context.HostCapabilities.ReducedPrecision)
=======
            if (context.Config.GpuAccessor.QueryHostReducedPrecision())
>>>>>>> 1ec71635b (sync with main branch)
            {
                precise = false;
            }

            return type switch
            {
                AggregateType.Void => "void",
                AggregateType.Bool => "bool",
                AggregateType.FP32 => precise ? "precise float" : "float",
                AggregateType.FP64 => "double",
                AggregateType.S32 => "int",
                AggregateType.U32 => "uint",
                AggregateType.Vector2 | AggregateType.Bool => "bvec2",
                AggregateType.Vector2 | AggregateType.FP32 => precise ? "precise vec2" : "vec2",
                AggregateType.Vector2 | AggregateType.FP64 => "dvec2",
                AggregateType.Vector2 | AggregateType.S32 => "ivec2",
                AggregateType.Vector2 | AggregateType.U32 => "uvec2",
                AggregateType.Vector3 | AggregateType.Bool => "bvec3",
                AggregateType.Vector3 | AggregateType.FP32 => precise ? "precise vec3" : "vec3",
                AggregateType.Vector3 | AggregateType.FP64 => "dvec3",
                AggregateType.Vector3 | AggregateType.S32 => "ivec3",
                AggregateType.Vector3 | AggregateType.U32 => "uvec3",
                AggregateType.Vector4 | AggregateType.Bool => "bvec4",
                AggregateType.Vector4 | AggregateType.FP32 => precise ? "precise vec4" : "vec4",
                AggregateType.Vector4 | AggregateType.FP64 => "dvec4",
                AggregateType.Vector4 | AggregateType.S32 => "ivec4",
                AggregateType.Vector4 | AggregateType.U32 => "uvec4",
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid variable type \"{type}\"."),
=======
                _ => throw new ArgumentException($"Invalid variable type \"{type}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static void DeclareConstantBuffers(CodeGenContext context, IEnumerable<BufferDefinition> buffers)
        {
<<<<<<< HEAD
            DeclareBuffers(context, buffers, "uniform");
        }

        private static void DeclareStorageBuffers(CodeGenContext context, IEnumerable<BufferDefinition> buffers)
        {
            DeclareBuffers(context, buffers, "buffer");
        }

        private static void DeclareBuffers(CodeGenContext context, IEnumerable<BufferDefinition> buffers, string declType)
        {
=======
>>>>>>> 1ec71635b (sync with main branch)
            foreach (BufferDefinition buffer in buffers)
            {
                string layout = buffer.Layout switch
                {
                    BufferLayout.Std140 => "std140",
<<<<<<< HEAD
                    _ => "std430",
                };

                string set = string.Empty;

                if (context.TargetApi == TargetApi.Vulkan)
                {
                    set = $"set = {buffer.Set}, ";
                }

                context.AppendLine($"layout ({set}binding = {buffer.Binding}, {layout}) {declType} _{buffer.Name}");
=======
                    _ => "std430"
                };

                context.AppendLine($"layout (binding = {buffer.Binding}, {layout}) uniform _{buffer.Name}");
>>>>>>> 1ec71635b (sync with main branch)
                context.EnterScope();

                foreach (StructureField field in buffer.Type.Fields)
                {
                    if (field.Type.HasFlag(AggregateType.Array))
                    {
                        string typeName = GetVarTypeName(context, field.Type & ~AggregateType.Array);
<<<<<<< HEAD

                        if (field.ArrayLength > 0)
                        {
                            string arraySize = field.ArrayLength.ToString(CultureInfo.InvariantCulture);

                            context.AppendLine($"{typeName} {field.Name}[{arraySize}];");
                        }
                        else
                        {
                            context.AppendLine($"{typeName} {field.Name}[];");
                        }
=======
                        string arraySize = field.ArrayLength.ToString(CultureInfo.InvariantCulture);

                        context.AppendLine($"{typeName} {field.Name}[{arraySize}];");
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    else
                    {
                        string typeName = GetVarTypeName(context, field.Type);

                        context.AppendLine($"{typeName} {field.Name};");
                    }
                }

                context.LeaveScope($" {buffer.Name};");
                context.AppendLine();
            }
        }

<<<<<<< HEAD
        private static void DeclareMemories(CodeGenContext context, IEnumerable<MemoryDefinition> memories, bool isShared)
        {
            string prefix = isShared ? "shared " : string.Empty;

            foreach (MemoryDefinition memory in memories)
            {
                string typeName = GetVarTypeName(context, memory.Type & ~AggregateType.Array);

                if (memory.Type.HasFlag(AggregateType.Array))
                {
                    if (memory.ArrayLength > 0)
                    {
                        string arraySize = memory.ArrayLength.ToString(CultureInfo.InvariantCulture);

                        context.AppendLine($"{prefix}{typeName} {memory.Name}[{arraySize}];");
                    }
                    else
                    {
                        context.AppendLine($"{prefix}{typeName} {memory.Name}[];");
                    }
                }
                else
                {
                    context.AppendLine($"{prefix}{typeName} {memory.Name};");
                }
            }
        }

        private static void DeclareSamplers(CodeGenContext context, IEnumerable<TextureDefinition> definitions)
        {
            int arraySize = 0;

            foreach (var definition in definitions)
            {
                string indexExpr = string.Empty;

                if (definition.Type.HasFlag(SamplerType.Indexed))
                {
                    if (arraySize == 0)
                    {
                        arraySize = ResourceManager.SamplerArraySize;
=======
        private static void DeclareStorages(CodeGenContext context, BufferDescriptor[] descriptors)
        {
            string sbName = OperandManager.GetShaderStagePrefix(context.Config.Stage);

            sbName += "_" + DefaultNames.StorageNamePrefix;

            string blockName = $"{sbName}_{DefaultNames.BlockSuffix}";

            string layout = context.Config.Options.TargetApi == TargetApi.Vulkan ? ", set = 1" : string.Empty;

            context.AppendLine($"layout (binding = {context.Config.FirstStorageBufferBinding}{layout}, std430) buffer {blockName}");
            context.EnterScope();
            context.AppendLine("uint " + DefaultNames.DataName + "[];");
            context.LeaveScope($" {sbName}[{NumberFormatter.FormatInt(descriptors.Max(x => x.Slot) + 1)}];");
        }

        private static void DeclareSamplers(CodeGenContext context, TextureDescriptor[] descriptors)
        {
            int arraySize = 0;
            foreach (var descriptor in descriptors)
            {
                if (descriptor.Type.HasFlag(SamplerType.Indexed))
                {
                    if (arraySize == 0)
                    {
                        arraySize = ShaderConfig.SamplerArraySize;
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    else if (--arraySize != 0)
                    {
                        continue;
                    }
<<<<<<< HEAD

                    indexExpr = $"[{NumberFormatter.FormatInt(arraySize)}]";
                }

                string samplerTypeName = definition.Type.ToGlslSamplerType();

                string layout = string.Empty;

                if (context.TargetApi == TargetApi.Vulkan)
                {
                    layout = $", set = {definition.Set}";
                }

                context.AppendLine($"layout (binding = {definition.Binding}{layout}) uniform {samplerTypeName} {definition.Name}{indexExpr};");
            }
        }

        private static void DeclareImages(CodeGenContext context, IEnumerable<TextureDefinition> definitions)
        {
            int arraySize = 0;

            foreach (var definition in definitions)
            {
                string indexExpr = string.Empty;

                if (definition.Type.HasFlag(SamplerType.Indexed))
                {
                    if (arraySize == 0)
                    {
                        arraySize = ResourceManager.SamplerArraySize;
=======
                }

                string indexExpr = NumberFormatter.FormatInt(arraySize);

                string samplerName = OperandManager.GetSamplerName(
                    context.Config.Stage,
                    descriptor.CbufSlot,
                    descriptor.HandleIndex,
                    descriptor.Type.HasFlag(SamplerType.Indexed),
                    indexExpr);

                string samplerTypeName = descriptor.Type.ToGlslSamplerType();

                string layout = string.Empty;

                if (context.Config.Options.TargetApi == TargetApi.Vulkan)
                {
                    layout = ", set = 2";
                }

                context.AppendLine($"layout (binding = {descriptor.Binding}{layout}) uniform {samplerTypeName} {samplerName};");
            }
        }

        private static void DeclareImages(CodeGenContext context, TextureDescriptor[] descriptors)
        {
            int arraySize = 0;
            foreach (var descriptor in descriptors)
            {
                if (descriptor.Type.HasFlag(SamplerType.Indexed))
                {
                    if (arraySize == 0)
                    {
                        arraySize = ShaderConfig.SamplerArraySize;
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    else if (--arraySize != 0)
                    {
                        continue;
                    }
<<<<<<< HEAD

                    indexExpr = $"[{NumberFormatter.FormatInt(arraySize)}]";
                }

                string imageTypeName = definition.Type.ToGlslImageType(definition.Format.GetComponentType());

                if (definition.Flags.HasFlag(TextureUsageFlags.ImageCoherent))
=======
                }

                string indexExpr = NumberFormatter.FormatInt(arraySize);

                string imageName = OperandManager.GetImageName(
                    context.Config.Stage,
                    descriptor.CbufSlot,
                    descriptor.HandleIndex,
                    descriptor.Format,
                    descriptor.Type.HasFlag(SamplerType.Indexed),
                    indexExpr);

                string imageTypeName = descriptor.Type.ToGlslImageType(descriptor.Format.GetComponentType());

                if (descriptor.Flags.HasFlag(TextureUsageFlags.ImageCoherent))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    imageTypeName = "coherent " + imageTypeName;
                }

<<<<<<< HEAD
                string layout = definition.Format.ToGlslFormat();
=======
                string layout = descriptor.Format.ToGlslFormat();
>>>>>>> 1ec71635b (sync with main branch)

                if (!string.IsNullOrEmpty(layout))
                {
                    layout = ", " + layout;
                }

<<<<<<< HEAD
                if (context.TargetApi == TargetApi.Vulkan)
                {
                    layout = $", set = {definition.Set}{layout}";
                }

                context.AppendLine($"layout (binding = {definition.Binding}{layout}) uniform {imageTypeName} {definition.Name}{indexExpr};");
            }
        }

        private static void DeclareInputAttributes(CodeGenContext context, IEnumerable<IoDefinition> inputs)
        {
            if (context.Definitions.IaIndexing)
            {
                string suffix = context.Definitions.Stage == ShaderStage.Geometry ? "[]" : string.Empty;

                context.AppendLine($"layout (location = 0) in vec4 {DefaultNames.IAttributePrefix}{suffix}[{Constants.MaxAttributes}];");
                context.AppendLine();
            }
            else
            {
                foreach (var ioDefinition in inputs.OrderBy(x => x.Location))
                {
                    DeclareInputAttribute(context, ioDefinition.Location, ioDefinition.Component);
                }

                if (inputs.Any())
                {
                    context.AppendLine();
=======
                if (context.Config.Options.TargetApi == TargetApi.Vulkan)
                {
                    layout = $", set = 3{layout}";
                }

                context.AppendLine($"layout (binding = {descriptor.Binding}{layout}) uniform {imageTypeName} {imageName};");
            }
        }

        private static void DeclareInputAttributes(CodeGenContext context, StructuredProgramInfo info)
        {
            if (context.Config.UsedFeatures.HasFlag(FeatureFlags.IaIndexing))
            {
                string suffix = context.Config.Stage == ShaderStage.Geometry ? "[]" : string.Empty;

                context.AppendLine($"layout (location = 0) in vec4 {DefaultNames.IAttributePrefix}{suffix}[{Constants.MaxAttributes}];");
            }
            else
            {
                int usedAttributes = context.Config.UsedInputAttributes | context.Config.PassthroughAttributes;
                while (usedAttributes != 0)
                {
                    int index = BitOperations.TrailingZeroCount(usedAttributes);
                    DeclareInputAttribute(context, info, index);
                    usedAttributes &= ~(1 << index);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

<<<<<<< HEAD
        private static void DeclareInputAttributesPerPatch(CodeGenContext context, IEnumerable<IoDefinition> inputs)
        {
            foreach (var ioDefinition in inputs.OrderBy(x => x.Location))
            {
                DeclareInputAttributePerPatch(context, ioDefinition.Location);
            }

            if (inputs.Any())
            {
                context.AppendLine();
            }
        }

        private static void DeclareInputAttribute(CodeGenContext context, int location, int component)
        {
            string suffix = IsArrayAttributeGlsl(context.Definitions.Stage, isOutAttr: false) ? "[]" : string.Empty;
            string iq = string.Empty;

            if (context.Definitions.Stage == ShaderStage.Fragment)
            {
                iq = context.Definitions.ImapTypes[location].GetFirstUsedType() switch
                {
                    PixelImap.Constant => "flat ",
                    PixelImap.ScreenLinear => "noperspective ",
                    _ => string.Empty,
                };
            }

            string name = $"{DefaultNames.IAttributePrefix}{location}";

            if (context.Definitions.TransformFeedbackEnabled && context.Definitions.Stage == ShaderStage.Fragment)
            {
                bool hasComponent = context.Definitions.HasPerLocationInputOrOutputComponent(IoVariable.UserDefined, location, component, isOutput: false);

                if (hasComponent)
                {
                    char swzMask = "xyzw"[component];

                    context.AppendLine($"layout (location = {location}, component = {component}) {iq}in float {name}_{swzMask}{suffix};");
                }
                else
                {
                    int components = context.Definitions.GetTransformFeedbackOutputComponents(location, 0);

=======
        private static void DeclareInputAttributesPerPatch(CodeGenContext context, HashSet<int> attrs)
        {
            foreach (int attr in attrs.Order())
            {
                DeclareInputAttributePerPatch(context, attr);
            }
        }

        private static void DeclareInputAttribute(CodeGenContext context, StructuredProgramInfo info, int attr)
        {
            string suffix = IsArrayAttributeGlsl(context.Config.Stage, isOutAttr: false) ? "[]" : string.Empty;
            string iq = string.Empty;

            if (context.Config.Stage == ShaderStage.Fragment)
            {
                iq = context.Config.ImapTypes[attr].GetFirstUsedType() switch
                {
                    PixelImap.Constant => "flat ",
                    PixelImap.ScreenLinear => "noperspective ",
                    _ => string.Empty
                };
            }

            string name = $"{DefaultNames.IAttributePrefix}{attr}";

            if (context.Config.TransformFeedbackEnabled && context.Config.Stage == ShaderStage.Fragment)
            {
                int components = context.Config.GetTransformFeedbackOutputComponents(attr, 0);

                if (components > 1)
                {
>>>>>>> 1ec71635b (sync with main branch)
                    string type = components switch
                    {
                        2 => "vec2",
                        3 => "vec3",
                        4 => "vec4",
<<<<<<< HEAD
                        _ => "float",
                    };

                    context.AppendLine($"layout (location = {location}) in {type} {name};");
=======
                        _ => "float"
                    };

                    context.AppendLine($"layout (location = {attr}) in {type} {name};");
                }

                for (int c = components > 1 ? components : 0; c < 4; c++)
                {
                    char swzMask = "xyzw"[c];

                    context.AppendLine($"layout (location = {attr}, component = {c}) {iq}in float {name}_{swzMask}{suffix};");
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
            else
            {
<<<<<<< HEAD
                bool passthrough = (context.AttributeUsage.PassthroughAttributes & (1 << location)) != 0;
                string pass = passthrough && context.HostCapabilities.SupportsGeometryShaderPassthrough ? "passthrough, " : string.Empty;
                string type = GetVarTypeName(context, context.Definitions.GetUserDefinedType(location, isOutput: false), false);

                context.AppendLine($"layout ({pass}location = {location}) {iq}in {type} {name}{suffix};");
            }
        }

        private static void DeclareInputAttributePerPatch(CodeGenContext context, int patchLocation)
        {
            int location = context.AttributeUsage.GetPerPatchAttributeLocation(patchLocation);
            string name = $"{DefaultNames.PerPatchAttributePrefix}{patchLocation}";
=======
                bool passthrough = (context.Config.PassthroughAttributes & (1 << attr)) != 0;
                string pass = passthrough && context.Config.GpuAccessor.QueryHostSupportsGeometryShaderPassthrough() ? "passthrough, " : string.Empty;
                string type;

                if (context.Config.Stage == ShaderStage.Vertex)
                {
                    type = context.Config.GpuAccessor.QueryAttributeType(attr).ToVec4Type();
                }
                else
                {
                    type = AttributeType.Float.ToVec4Type();
                }

                context.AppendLine($"layout ({pass}location = {attr}) {iq}in {type} {name}{suffix};");
            }
        }

        private static void DeclareInputAttributePerPatch(CodeGenContext context, int attr)
        {
            int location = context.Config.GetPerPatchAttributeLocation(attr);
            string name = $"{DefaultNames.PerPatchAttributePrefix}{attr}";
>>>>>>> 1ec71635b (sync with main branch)

            context.AppendLine($"layout (location = {location}) patch in vec4 {name};");
        }

<<<<<<< HEAD
        private static void DeclareOutputAttributes(CodeGenContext context, IEnumerable<IoDefinition> outputs)
        {
            if (context.Definitions.OaIndexing)
            {
                context.AppendLine($"layout (location = 0) out vec4 {DefaultNames.OAttributePrefix}[{Constants.MaxAttributes}];");
                context.AppendLine();
            }
            else
            {
                outputs = outputs.OrderBy(x => x.Location);

                if (context.Definitions.Stage == ShaderStage.Fragment && context.Definitions.DualSourceBlend)
                {
                    IoDefinition firstOutput = outputs.ElementAtOrDefault(0);
                    IoDefinition secondOutput = outputs.ElementAtOrDefault(1);

                    if (firstOutput.Location + 1 == secondOutput.Location)
                    {
                        DeclareOutputDualSourceBlendAttribute(context, firstOutput.Location);
                        outputs = outputs.Skip(2);
                    }
                }

                foreach (var ioDefinition in outputs)
                {
                    DeclareOutputAttribute(context, ioDefinition.Location, ioDefinition.Component);
                }

                if (outputs.Any())
                {
                    context.AppendLine();
=======
        private static void DeclareOutputAttributes(CodeGenContext context, StructuredProgramInfo info)
        {
            if (context.Config.UsedFeatures.HasFlag(FeatureFlags.OaIndexing))
            {
                context.AppendLine($"layout (location = 0) out vec4 {DefaultNames.OAttributePrefix}[{Constants.MaxAttributes}];");
            }
            else
            {
                int usedAttributes = context.Config.UsedOutputAttributes;

                if (context.Config.Stage == ShaderStage.Fragment && context.Config.GpuAccessor.QueryDualSourceBlendEnable())
                {
                    int firstOutput = BitOperations.TrailingZeroCount(usedAttributes);
                    int mask = 3 << firstOutput;

                    if ((usedAttributes & mask) == mask)
                    {
                        usedAttributes &= ~mask;
                        DeclareOutputDualSourceBlendAttribute(context, firstOutput);
                    }
                }

                while (usedAttributes != 0)
                {
                    int index = BitOperations.TrailingZeroCount(usedAttributes);
                    DeclareOutputAttribute(context, index);
                    usedAttributes &= ~(1 << index);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

<<<<<<< HEAD
        private static void DeclareOutputAttribute(CodeGenContext context, int location, int component)
        {
            string suffix = IsArrayAttributeGlsl(context.Definitions.Stage, isOutAttr: true) ? "[]" : string.Empty;
            string name = $"{DefaultNames.OAttributePrefix}{location}{suffix}";

            if (context.Definitions.TransformFeedbackEnabled && context.Definitions.LastInVertexPipeline)
            {
                bool hasComponent = context.Definitions.HasPerLocationInputOrOutputComponent(IoVariable.UserDefined, location, component, isOutput: true);

                if (hasComponent)
                {
                    char swzMask = "xyzw"[component];

                    string xfb = string.Empty;

                    var tfOutput = context.Definitions.GetTransformFeedbackOutput(location, component);
                    if (tfOutput.Valid)
                    {
                        xfb = $", xfb_buffer = {tfOutput.Buffer}, xfb_offset = {tfOutput.Offset}, xfb_stride = {tfOutput.Stride}";
                    }

                    context.AppendLine($"layout (location = {location}, component = {component}{xfb}) out float {name}_{swzMask};");
                }
                else
                {
                    int components = context.Definitions.GetTransformFeedbackOutputComponents(location, 0);

=======
        private static void DeclareOutputAttribute(CodeGenContext context, int attr)
        {
            string suffix = IsArrayAttributeGlsl(context.Config.Stage, isOutAttr: true) ? "[]" : string.Empty;
            string name = $"{DefaultNames.OAttributePrefix}{attr}{suffix}";

            if (context.Config.TransformFeedbackEnabled && context.Config.LastInVertexPipeline)
            {
                int components = context.Config.GetTransformFeedbackOutputComponents(attr, 0);

                if (components > 1)
                {
>>>>>>> 1ec71635b (sync with main branch)
                    string type = components switch
                    {
                        2 => "vec2",
                        3 => "vec3",
                        4 => "vec4",
<<<<<<< HEAD
                        _ => "float",
=======
                        _ => "float"
>>>>>>> 1ec71635b (sync with main branch)
                    };

                    string xfb = string.Empty;

<<<<<<< HEAD
                    var tfOutput = context.Definitions.GetTransformFeedbackOutput(location, 0);
=======
                    var tfOutput = context.Config.GetTransformFeedbackOutput(attr, 0);
>>>>>>> 1ec71635b (sync with main branch)
                    if (tfOutput.Valid)
                    {
                        xfb = $", xfb_buffer = {tfOutput.Buffer}, xfb_offset = {tfOutput.Offset}, xfb_stride = {tfOutput.Stride}";
                    }

<<<<<<< HEAD
                    context.AppendLine($"layout (location = {location}{xfb}) out {type} {name};");
=======
                    context.AppendLine($"layout (location = {attr}{xfb}) out {type} {name};");
                }

                for (int c = components > 1 ? components : 0; c < 4; c++)
                {
                    char swzMask = "xyzw"[c];

                    string xfb = string.Empty;

                    var tfOutput = context.Config.GetTransformFeedbackOutput(attr, c);
                    if (tfOutput.Valid)
                    {
                        xfb = $", xfb_buffer = {tfOutput.Buffer}, xfb_offset = {tfOutput.Offset}, xfb_stride = {tfOutput.Stride}";
                    }

                    context.AppendLine($"layout (location = {attr}, component = {c}{xfb}) out float {name}_{swzMask};");
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
            else
            {
<<<<<<< HEAD
                string type = context.Definitions.Stage != ShaderStage.Fragment ? "vec4" :
                    GetVarTypeName(context, context.Definitions.GetFragmentOutputColorType(location), false);

                if (context.HostCapabilities.ReducedPrecision && context.Definitions.Stage == ShaderStage.Vertex && location == 0)
                {
                    context.AppendLine($"layout (location = {location}) invariant out {type} {name};");
                }
                else
                {
                    context.AppendLine($"layout (location = {location}) out {type} {name};");
=======
                string type = context.Config.Stage != ShaderStage.Fragment ? "vec4" :
                    context.Config.GpuAccessor.QueryFragmentOutputType(attr) switch
                    {
                        AttributeType.Sint => "ivec4",
                        AttributeType.Uint => "uvec4",
                        _ => "vec4"
                    };

                if (context.Config.GpuAccessor.QueryHostReducedPrecision() && context.Config.Stage == ShaderStage.Vertex && attr == 0)
                {
                    context.AppendLine($"layout (location = {attr}) invariant out {type} {name};");
                }
                else
                {
                    context.AppendLine($"layout (location = {attr}) out {type} {name};");
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

<<<<<<< HEAD
        private static void DeclareOutputDualSourceBlendAttribute(CodeGenContext context, int location)
        {
            string name = $"{DefaultNames.OAttributePrefix}{location}";
            string name2 = $"{DefaultNames.OAttributePrefix}{(location + 1)}";

            context.AppendLine($"layout (location = {location}, index = 0) out vec4 {name};");
            context.AppendLine($"layout (location = {location}, index = 1) out vec4 {name2};");
        }

        private static void DeclareOutputAttributesPerPatch(CodeGenContext context, IEnumerable<IoDefinition> outputs)
        {
            foreach (var ioDefinition in outputs)
            {
                DeclareOutputAttributePerPatch(context, ioDefinition.Location);
            }

            if (outputs.Any())
            {
                context.AppendLine();
            }
        }

        private static void DeclareOutputAttributePerPatch(CodeGenContext context, int patchLocation)
        {
            int location = context.AttributeUsage.GetPerPatchAttributeLocation(patchLocation);
            string name = $"{DefaultNames.PerPatchAttributePrefix}{patchLocation}";

            context.AppendLine($"layout (location = {location}) patch out vec4 {name};");
=======
        private static void DeclareOutputDualSourceBlendAttribute(CodeGenContext context, int attr)
        {
            string name = $"{DefaultNames.OAttributePrefix}{attr}";
            string name2 = $"{DefaultNames.OAttributePrefix}{(attr + 1)}";

            context.AppendLine($"layout (location = {attr}, index = 0) out vec4 {name};");
            context.AppendLine($"layout (location = {attr}, index = 1) out vec4 {name2};");
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static bool IsArrayAttributeGlsl(ShaderStage stage, bool isOutAttr)
        {
            if (isOutAttr)
            {
                return stage == ShaderStage.TessellationControl;
            }
            else
            {
                return stage == ShaderStage.TessellationControl ||
                       stage == ShaderStage.TessellationEvaluation ||
                       stage == ShaderStage.Geometry;
            }
        }

<<<<<<< HEAD
=======
        private static void DeclareUsedOutputAttributesPerPatch(CodeGenContext context, HashSet<int> attrs)
        {
            foreach (int attr in attrs.Order())
            {
                DeclareOutputAttributePerPatch(context, attr);
            }
        }

        private static void DeclareOutputAttributePerPatch(CodeGenContext context, int attr)
        {
            int location = context.Config.GetPerPatchAttributeLocation(attr);
            string name = $"{DefaultNames.PerPatchAttributePrefix}{attr}";

            context.AppendLine($"layout (location = {location}) patch out vec4 {name};");
        }

>>>>>>> 1ec71635b (sync with main branch)
        private static void AppendHelperFunction(CodeGenContext context, string filename)
        {
            string code = EmbeddedResources.ReadAllText(filename);

            code = code.Replace("\t", CodeGenContext.Tab);
<<<<<<< HEAD

            if (context.HostCapabilities.SupportsShaderBallot)
=======
            code = code.Replace("$SHARED_MEM$", DefaultNames.SharedMemoryName);
            code = code.Replace("$STORAGE_MEM$", OperandManager.GetShaderStagePrefix(context.Config.Stage) + "_" + DefaultNames.StorageNamePrefix);

            if (context.Config.GpuAccessor.QueryHostSupportsShaderBallot())
>>>>>>> 1ec71635b (sync with main branch)
            {
                code = code.Replace("$SUBGROUP_INVOCATION$", "gl_SubGroupInvocationARB");
                code = code.Replace("$SUBGROUP_BROADCAST$", "readInvocationARB");
            }
            else
            {
                code = code.Replace("$SUBGROUP_INVOCATION$", "gl_SubgroupInvocationID");
                code = code.Replace("$SUBGROUP_BROADCAST$", "subgroupBroadcast");
            }

            context.AppendLine(code);
            context.AppendLine();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
