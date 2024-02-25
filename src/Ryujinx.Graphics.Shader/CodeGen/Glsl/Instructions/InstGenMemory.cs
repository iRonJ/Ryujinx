using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using Ryujinx.Graphics.Shader.StructuredIr;
using Ryujinx.Graphics.Shader.Translation;
using System;
using System.Text;
<<<<<<< HEAD
=======

>>>>>>> 1ec71635b (sync with main branch)
using static Ryujinx.Graphics.Shader.CodeGen.Glsl.Instructions.InstGenHelper;
using static Ryujinx.Graphics.Shader.StructuredIr.InstructionInfo;

namespace Ryujinx.Graphics.Shader.CodeGen.Glsl.Instructions
{
    static class InstGenMemory
    {
        public static string ImageLoadOrStore(CodeGenContext context, AstOperation operation)
        {
            AstTextureOperation texOp = (AstTextureOperation)operation;

            bool isBindless = (texOp.Flags & TextureFlags.Bindless) != 0;

            // TODO: Bindless texture support. For now we just return 0/do nothing.
            if (isBindless)
            {
                switch (texOp.Inst)
                {
                    case Instruction.ImageStore:
                        return "// imageStore(bindless)";
                    case Instruction.ImageLoad:
                        AggregateType componentType = texOp.Format.GetComponentType();

                        NumberFormatter.TryFormat(0, componentType, out string imageConst);

                        AggregateType outputType = texOp.GetVectorType(componentType);

                        if ((outputType & AggregateType.ElementCountMask) != 0)
                        {
                            return $"{Declarations.GetVarTypeName(context, outputType, precise: false)}({imageConst})";
                        }

                        return imageConst;
                    default:
                        return NumberFormatter.FormatInt(0);
                }
            }

<<<<<<< HEAD
            bool isArray = (texOp.Type & SamplerType.Array) != 0;
=======
            bool isArray   = (texOp.Type & SamplerType.Array)   != 0;
>>>>>>> 1ec71635b (sync with main branch)
            bool isIndexed = (texOp.Type & SamplerType.Indexed) != 0;

            var texCallBuilder = new StringBuilder();

            if (texOp.Inst == Instruction.ImageAtomic)
            {
<<<<<<< HEAD
                texCallBuilder.Append((texOp.Flags & TextureFlags.AtomicMask) switch
                {
#pragma warning disable IDE0055 // Disable formatting
=======
                texCallBuilder.Append((texOp.Flags & TextureFlags.AtomicMask) switch {
>>>>>>> 1ec71635b (sync with main branch)
                    TextureFlags.Add        => "imageAtomicAdd",
                    TextureFlags.Minimum    => "imageAtomicMin",
                    TextureFlags.Maximum    => "imageAtomicMax",
                    TextureFlags.Increment  => "imageAtomicAdd", // TODO: Clamp value.
                    TextureFlags.Decrement  => "imageAtomicAdd", // TODO: Clamp value.
                    TextureFlags.BitwiseAnd => "imageAtomicAnd",
                    TextureFlags.BitwiseOr  => "imageAtomicOr",
                    TextureFlags.BitwiseXor => "imageAtomicXor",
                    TextureFlags.Swap       => "imageAtomicExchange",
                    TextureFlags.CAS        => "imageAtomicCompSwap",
                    _                       => "imageAtomicAdd",
<<<<<<< HEAD
#pragma warning restore IDE0055
=======
>>>>>>> 1ec71635b (sync with main branch)
                });
            }
            else
            {
                texCallBuilder.Append(texOp.Inst == Instruction.ImageLoad ? "imageLoad" : "imageStore");
            }

            int srcIndex = isBindless ? 1 : 0;

            string Src(AggregateType type)
            {
                return GetSoureExpr(context, texOp.GetSource(srcIndex++), type);
            }

            string indexExpr = null;

            if (isIndexed)
            {
                indexExpr = Src(AggregateType.S32);
            }

<<<<<<< HEAD
            string imageName = GetImageName(context.Properties, texOp, indexExpr);
=======
            string imageName = OperandManager.GetImageName(context.Config.Stage, texOp, indexExpr);
>>>>>>> 1ec71635b (sync with main branch)

            texCallBuilder.Append('(');
            texCallBuilder.Append(imageName);

            int coordsCount = texOp.Type.GetDimensions();

            int pCount = coordsCount + (isArray ? 1 : 0);

            void Append(string str)
            {
                texCallBuilder.Append(", ");
                texCallBuilder.Append(str);
            }

            if (pCount > 1)
            {
                string[] elems = new string[pCount];

                for (int index = 0; index < pCount; index++)
                {
                    elems[index] = Src(AggregateType.S32);
                }

                Append($"ivec{pCount}({string.Join(", ", elems)})");
            }
            else
            {
                Append(Src(AggregateType.S32));
            }

            if (texOp.Inst == Instruction.ImageStore)
            {
                AggregateType type = texOp.Format.GetComponentType();

                string[] cElems = new string[4];

                for (int index = 0; index < 4; index++)
                {
                    if (srcIndex < texOp.SourcesCount)
                    {
                        cElems[index] = Src(type);
                    }
                    else
                    {
                        cElems[index] = type switch
                        {
                            AggregateType.S32 => NumberFormatter.FormatInt(0),
                            AggregateType.U32 => NumberFormatter.FormatUint(0),
<<<<<<< HEAD
                            _ => NumberFormatter.FormatFloat(0),
=======
                            _                => NumberFormatter.FormatFloat(0)
>>>>>>> 1ec71635b (sync with main branch)
                        };
                    }
                }

                string prefix = type switch
                {
                    AggregateType.S32 => "i",
                    AggregateType.U32 => "u",
<<<<<<< HEAD
                    _ => string.Empty,
=======
                    _                => string.Empty
>>>>>>> 1ec71635b (sync with main branch)
                };

                Append($"{prefix}vec4({string.Join(", ", cElems)})");
            }

            if (texOp.Inst == Instruction.ImageAtomic)
            {
                AggregateType type = texOp.Format.GetComponentType();

                if ((texOp.Flags & TextureFlags.AtomicMask) == TextureFlags.CAS)
                {
                    Append(Src(type)); // Compare value.
                }

                string value = (texOp.Flags & TextureFlags.AtomicMask) switch
                {
                    TextureFlags.Increment => NumberFormatter.FormatInt(1, type), // TODO: Clamp value
                    TextureFlags.Decrement => NumberFormatter.FormatInt(-1, type), // TODO: Clamp value
<<<<<<< HEAD
                    _ => Src(type),
=======
                    _ => Src(type)
>>>>>>> 1ec71635b (sync with main branch)
                };

                Append(value);

                texCallBuilder.Append(')');

                if (type != AggregateType.S32)
                {
                    texCallBuilder
                        .Insert(0, "int(")
                        .Append(')');
                }
            }
            else
            {
                texCallBuilder.Append(')');

                if (texOp.Inst == Instruction.ImageLoad)
                {
                    texCallBuilder.Append(GetMaskMultiDest(texOp.Index));
                }
            }

            return texCallBuilder.ToString();
        }

        public static string Load(CodeGenContext context, AstOperation operation)
        {
            return GenerateLoadOrStore(context, operation, isStore: false);
        }

<<<<<<< HEAD
=======
        public static string LoadLocal(CodeGenContext context, AstOperation operation)
        {
            return LoadLocalOrShared(context, operation, DefaultNames.LocalMemoryName);
        }

        public static string LoadShared(CodeGenContext context, AstOperation operation)
        {
            return LoadLocalOrShared(context, operation, DefaultNames.SharedMemoryName);
        }

        private static string LoadLocalOrShared(CodeGenContext context, AstOperation operation, string arrayName)
        {
            IAstNode src1 = operation.GetSource(0);

            string offsetExpr = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));

            return $"{arrayName}[{offsetExpr}]";
        }

        public static string LoadStorage(CodeGenContext context, AstOperation operation)
        {
            IAstNode src1 = operation.GetSource(0);
            IAstNode src2 = operation.GetSource(1);

            string indexExpr  = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));
            string offsetExpr = GetSoureExpr(context, src2, GetSrcVarType(operation.Inst, 1));

            return GetStorageBufferAccessor(indexExpr, offsetExpr, context.Config.Stage);
        }

>>>>>>> 1ec71635b (sync with main branch)
        public static string Lod(CodeGenContext context, AstOperation operation)
        {
            AstTextureOperation texOp = (AstTextureOperation)operation;

            int coordsCount = texOp.Type.GetDimensions();

            bool isBindless = (texOp.Flags & TextureFlags.Bindless) != 0;

            // TODO: Bindless texture support. For now we just return 0.
            if (isBindless)
            {
                return NumberFormatter.FormatFloat(0);
            }

            bool isIndexed = (texOp.Type & SamplerType.Indexed) != 0;

            string indexExpr = null;

            if (isIndexed)
            {
                indexExpr = GetSoureExpr(context, texOp.GetSource(0), AggregateType.S32);
            }

<<<<<<< HEAD
            string samplerName = GetSamplerName(context.Properties, texOp, indexExpr);
=======
            string samplerName = OperandManager.GetSamplerName(context.Config.Stage, texOp, indexExpr);
>>>>>>> 1ec71635b (sync with main branch)

            int coordsIndex = isBindless || isIndexed ? 1 : 0;

            string coordsExpr;

            if (coordsCount > 1)
            {
                string[] elems = new string[coordsCount];

                for (int index = 0; index < coordsCount; index++)
                {
                    elems[index] = GetSoureExpr(context, texOp.GetSource(coordsIndex + index), AggregateType.FP32);
                }

                coordsExpr = "vec" + coordsCount + "(" + string.Join(", ", elems) + ")";
            }
            else
            {
                coordsExpr = GetSoureExpr(context, texOp.GetSource(coordsIndex), AggregateType.FP32);
            }

            return $"textureQueryLod({samplerName}, {coordsExpr}){GetMask(texOp.Index)}";
        }

        public static string Store(CodeGenContext context, AstOperation operation)
        {
            return GenerateLoadOrStore(context, operation, isStore: true);
        }

<<<<<<< HEAD
=======
        public static string StoreLocal(CodeGenContext context, AstOperation operation)
        {
            return StoreLocalOrShared(context, operation, DefaultNames.LocalMemoryName);
        }

        public static string StoreShared(CodeGenContext context, AstOperation operation)
        {
            return StoreLocalOrShared(context, operation, DefaultNames.SharedMemoryName);
        }

        private static string StoreLocalOrShared(CodeGenContext context, AstOperation operation, string arrayName)
        {
            IAstNode src1 = operation.GetSource(0);
            IAstNode src2 = operation.GetSource(1);

            string offsetExpr = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));

            AggregateType srcType = OperandManager.GetNodeDestType(context, src2);

            string src = TypeConversion.ReinterpretCast(context, src2, srcType, AggregateType.U32);

            return $"{arrayName}[{offsetExpr}] = {src}";
        }

        public static string StoreShared16(CodeGenContext context, AstOperation operation)
        {
            IAstNode src1 = operation.GetSource(0);
            IAstNode src2 = operation.GetSource(1);

            string offsetExpr = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));

            AggregateType srcType = OperandManager.GetNodeDestType(context, src2);

            string src = TypeConversion.ReinterpretCast(context, src2, srcType, AggregateType.U32);

            return $"{HelperFunctionNames.StoreShared16}({offsetExpr}, {src})";
        }

        public static string StoreShared8(CodeGenContext context, AstOperation operation)
        {
            IAstNode src1 = operation.GetSource(0);
            IAstNode src2 = operation.GetSource(1);

            string offsetExpr = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));

            AggregateType srcType = OperandManager.GetNodeDestType(context, src2);

            string src = TypeConversion.ReinterpretCast(context, src2, srcType, AggregateType.U32);

            return $"{HelperFunctionNames.StoreShared8}({offsetExpr}, {src})";
        }

        public static string StoreStorage(CodeGenContext context, AstOperation operation)
        {
            IAstNode src1 = operation.GetSource(0);
            IAstNode src2 = operation.GetSource(1);
            IAstNode src3 = operation.GetSource(2);

            string indexExpr  = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));
            string offsetExpr = GetSoureExpr(context, src2, GetSrcVarType(operation.Inst, 1));

            AggregateType srcType = OperandManager.GetNodeDestType(context, src3);

            string src = TypeConversion.ReinterpretCast(context, src3, srcType, AggregateType.U32);

            string sb = GetStorageBufferAccessor(indexExpr, offsetExpr, context.Config.Stage);

            return $"{sb} = {src}";
        }

        public static string StoreStorage16(CodeGenContext context, AstOperation operation)
        {
            IAstNode src1 = operation.GetSource(0);
            IAstNode src2 = operation.GetSource(1);
            IAstNode src3 = operation.GetSource(2);

            string indexExpr  = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));
            string offsetExpr = GetSoureExpr(context, src2, GetSrcVarType(operation.Inst, 1));

            AggregateType srcType = OperandManager.GetNodeDestType(context, src3);

            string src = TypeConversion.ReinterpretCast(context, src3, srcType, AggregateType.U32);

            string sb = GetStorageBufferAccessor(indexExpr, offsetExpr, context.Config.Stage);

            return $"{HelperFunctionNames.StoreStorage16}({indexExpr}, {offsetExpr}, {src})";
        }

        public static string StoreStorage8(CodeGenContext context, AstOperation operation)
        {
            IAstNode src1 = operation.GetSource(0);
            IAstNode src2 = operation.GetSource(1);
            IAstNode src3 = operation.GetSource(2);

            string indexExpr  = GetSoureExpr(context, src1, GetSrcVarType(operation.Inst, 0));
            string offsetExpr = GetSoureExpr(context, src2, GetSrcVarType(operation.Inst, 1));

            AggregateType srcType = OperandManager.GetNodeDestType(context, src3);

            string src = TypeConversion.ReinterpretCast(context, src3, srcType, AggregateType.U32);

            string sb = GetStorageBufferAccessor(indexExpr, offsetExpr, context.Config.Stage);

            return $"{HelperFunctionNames.StoreStorage8}({indexExpr}, {offsetExpr}, {src})";
        }

>>>>>>> 1ec71635b (sync with main branch)
        public static string TextureSample(CodeGenContext context, AstOperation operation)
        {
            AstTextureOperation texOp = (AstTextureOperation)operation;

<<<<<<< HEAD
            bool isBindless = (texOp.Flags & TextureFlags.Bindless) != 0;
            bool isGather = (texOp.Flags & TextureFlags.Gather) != 0;
            bool hasDerivatives = (texOp.Flags & TextureFlags.Derivatives) != 0;
            bool intCoords = (texOp.Flags & TextureFlags.IntCoords) != 0;
            bool hasLodBias = (texOp.Flags & TextureFlags.LodBias) != 0;
            bool hasLodLevel = (texOp.Flags & TextureFlags.LodLevel) != 0;
            bool hasOffset = (texOp.Flags & TextureFlags.Offset) != 0;
            bool hasOffsets = (texOp.Flags & TextureFlags.Offsets) != 0;

            bool isArray = (texOp.Type & SamplerType.Array) != 0;
            bool isIndexed = (texOp.Type & SamplerType.Indexed) != 0;
            bool isMultisample = (texOp.Type & SamplerType.Multisample) != 0;
            bool isShadow = (texOp.Type & SamplerType.Shadow) != 0;
=======
            bool isBindless     = (texOp.Flags & TextureFlags.Bindless)    != 0;
            bool isGather       = (texOp.Flags & TextureFlags.Gather)      != 0;
            bool hasDerivatives = (texOp.Flags & TextureFlags.Derivatives) != 0;
            bool intCoords      = (texOp.Flags & TextureFlags.IntCoords)   != 0;
            bool hasLodBias     = (texOp.Flags & TextureFlags.LodBias)     != 0;
            bool hasLodLevel    = (texOp.Flags & TextureFlags.LodLevel)    != 0;
            bool hasOffset      = (texOp.Flags & TextureFlags.Offset)      != 0;
            bool hasOffsets     = (texOp.Flags & TextureFlags.Offsets)     != 0;

            bool isArray       = (texOp.Type & SamplerType.Array)       != 0;
            bool isIndexed     = (texOp.Type & SamplerType.Indexed)     != 0;
            bool isMultisample = (texOp.Type & SamplerType.Multisample) != 0;
            bool isShadow      = (texOp.Type & SamplerType.Shadow)      != 0;
>>>>>>> 1ec71635b (sync with main branch)

            bool colorIsVector = isGather || !isShadow;

            SamplerType type = texOp.Type & SamplerType.Mask;

<<<<<<< HEAD
            bool is2D = type == SamplerType.Texture2D;
=======
            bool is2D   = type == SamplerType.Texture2D;
>>>>>>> 1ec71635b (sync with main branch)
            bool isCube = type == SamplerType.TextureCube;

            // 2D Array and Cube shadow samplers with LOD level or bias requires an extension.
            // If the extension is not supported, just remove the LOD parameter.
<<<<<<< HEAD
            if (isArray && isShadow && (is2D || isCube) && !context.HostCapabilities.SupportsTextureShadowLod)
=======
            if (isArray && isShadow && (is2D || isCube) && !context.Config.GpuAccessor.QueryHostSupportsTextureShadowLod())
>>>>>>> 1ec71635b (sync with main branch)
            {
                hasLodBias = false;
                hasLodLevel = false;
            }

            // Cube shadow samplers with LOD level requires an extension.
            // If the extension is not supported, just remove the LOD level parameter.
<<<<<<< HEAD
            if (isShadow && isCube && !context.HostCapabilities.SupportsTextureShadowLod)
=======
            if (isShadow && isCube && !context.Config.GpuAccessor.QueryHostSupportsTextureShadowLod())
>>>>>>> 1ec71635b (sync with main branch)
            {
                hasLodLevel = false;
            }

            // TODO: Bindless texture support. For now we just return 0.
            if (isBindless)
            {
                string scalarValue = NumberFormatter.FormatFloat(0);

                if (colorIsVector)
                {
                    AggregateType outputType = texOp.GetVectorType(AggregateType.FP32);

                    if ((outputType & AggregateType.ElementCountMask) != 0)
                    {
                        return $"{Declarations.GetVarTypeName(context, outputType, precise: false)}({scalarValue})";
                    }
                }

                return scalarValue;
            }

            string texCall = intCoords ? "texelFetch" : "texture";

            if (isGather)
            {
                texCall += "Gather";
            }
            else if (hasDerivatives)
            {
                texCall += "Grad";
            }
            else if (hasLodLevel && !intCoords)
            {
                texCall += "Lod";
            }

            if (hasOffset)
            {
                texCall += "Offset";
            }
            else if (hasOffsets)
            {
                texCall += "Offsets";
            }

            int srcIndex = isBindless ? 1 : 0;

            string Src(AggregateType type)
            {
                return GetSoureExpr(context, texOp.GetSource(srcIndex++), type);
            }

            string indexExpr = null;

            if (isIndexed)
            {
                indexExpr = Src(AggregateType.S32);
            }

<<<<<<< HEAD
            string samplerName = GetSamplerName(context.Properties, texOp, indexExpr);
=======
            string samplerName = OperandManager.GetSamplerName(context.Config.Stage, texOp, indexExpr);
>>>>>>> 1ec71635b (sync with main branch)

            texCall += "(" + samplerName;

            int coordsCount = texOp.Type.GetDimensions();

            int pCount = coordsCount;

            int arrayIndexElem = -1;

            if (isArray)
            {
                arrayIndexElem = pCount++;
            }

            // The sampler 1D shadow overload expects a
            // dummy value on the middle of the vector, who knows why...
            bool hasDummy1DShadowElem = texOp.Type == (SamplerType.Texture1D | SamplerType.Shadow);

            if (hasDummy1DShadowElem)
            {
                pCount++;
            }

            if (isShadow && !isGather)
            {
                pCount++;
            }

            // On textureGather*, the comparison value is
            // always specified as an extra argument.
            bool hasExtraCompareArg = isShadow && isGather;

            if (pCount == 5)
            {
                pCount = 4;

                hasExtraCompareArg = true;
            }

            void Append(string str)
            {
                texCall += ", " + str;
            }

            AggregateType coordType = intCoords ? AggregateType.S32 : AggregateType.FP32;

            string AssemblePVector(int count)
            {
                if (count > 1)
                {
                    string[] elems = new string[count];

                    for (int index = 0; index < count; index++)
                    {
                        if (arrayIndexElem == index)
                        {
                            elems[index] = Src(AggregateType.S32);

                            if (!intCoords)
                            {
                                elems[index] = "float(" + elems[index] + ")";
                            }
                        }
                        else if (index == 1 && hasDummy1DShadowElem)
                        {
                            elems[index] = NumberFormatter.FormatFloat(0);
                        }
                        else
                        {
                            elems[index] = Src(coordType);
                        }
                    }

                    string prefix = intCoords ? "i" : string.Empty;

                    return prefix + "vec" + count + "(" + string.Join(", ", elems) + ")";
                }
                else
                {
                    return Src(coordType);
                }
            }

            Append(AssemblePVector(pCount));

            string AssembleDerivativesVector(int count)
            {
                if (count > 1)
                {
                    string[] elems = new string[count];

                    for (int index = 0; index < count; index++)
                    {
                        elems[index] = Src(AggregateType.FP32);
                    }

                    return "vec" + count + "(" + string.Join(", ", elems) + ")";
                }
                else
                {
                    return Src(AggregateType.FP32);
                }
            }

            if (hasExtraCompareArg)
            {
                Append(Src(AggregateType.FP32));
            }

            if (hasDerivatives)
            {
                Append(AssembleDerivativesVector(coordsCount)); // dPdx
                Append(AssembleDerivativesVector(coordsCount)); // dPdy
            }

            if (isMultisample)
            {
                Append(Src(AggregateType.S32));
            }
            else if (hasLodLevel)
            {
                Append(Src(coordType));
            }

            string AssembleOffsetVector(int count)
            {
                if (count > 1)
                {
                    string[] elems = new string[count];

                    for (int index = 0; index < count; index++)
                    {
                        elems[index] = Src(AggregateType.S32);
                    }

                    return "ivec" + count + "(" + string.Join(", ", elems) + ")";
                }
                else
                {
                    return Src(AggregateType.S32);
                }
            }

            if (hasOffset)
            {
                Append(AssembleOffsetVector(coordsCount));
            }
            else if (hasOffsets)
            {
                texCall += $", ivec{coordsCount}[4](";

                texCall += AssembleOffsetVector(coordsCount) + ", ";
                texCall += AssembleOffsetVector(coordsCount) + ", ";
                texCall += AssembleOffsetVector(coordsCount) + ", ";
                texCall += AssembleOffsetVector(coordsCount) + ")";
            }

            if (hasLodBias)
            {
<<<<<<< HEAD
                Append(Src(AggregateType.FP32));
=======
               Append(Src(AggregateType.FP32));
>>>>>>> 1ec71635b (sync with main branch)
            }

            // textureGather* optional extra component index,
            // not needed for shadow samplers.
            if (isGather && !isShadow)
            {
<<<<<<< HEAD
                Append(Src(AggregateType.S32));
=======
               Append(Src(AggregateType.S32));
>>>>>>> 1ec71635b (sync with main branch)
            }

            texCall += ")" + (colorIsVector ? GetMaskMultiDest(texOp.Index) : "");

            return texCall;
        }

<<<<<<< HEAD
        public static string TextureQuerySamples(CodeGenContext context, AstOperation operation)
=======
        public static string TextureSize(CodeGenContext context, AstOperation operation)
>>>>>>> 1ec71635b (sync with main branch)
        {
            AstTextureOperation texOp = (AstTextureOperation)operation;

            bool isBindless = (texOp.Flags & TextureFlags.Bindless) != 0;

            // TODO: Bindless texture support. For now we just return 0.
            if (isBindless)
            {
                return NumberFormatter.FormatInt(0);
            }

            bool isIndexed = (texOp.Type & SamplerType.Indexed) != 0;

            string indexExpr = null;

            if (isIndexed)
            {
                indexExpr = GetSoureExpr(context, texOp.GetSource(0), AggregateType.S32);
            }

<<<<<<< HEAD
            string samplerName = GetSamplerName(context.Properties, texOp, indexExpr);

            return $"textureSamples({samplerName})";
        }

        public static string TextureQuerySize(CodeGenContext context, AstOperation operation)
        {
            AstTextureOperation texOp = (AstTextureOperation)operation;

            bool isBindless = (texOp.Flags & TextureFlags.Bindless) != 0;

            // TODO: Bindless texture support. For now we just return 0.
            if (isBindless)
            {
                return NumberFormatter.FormatInt(0);
            }

            bool isIndexed = (texOp.Type & SamplerType.Indexed) != 0;

            string indexExpr = null;

            if (isIndexed)
            {
                indexExpr = GetSoureExpr(context, texOp.GetSource(0), AggregateType.S32);
            }

            string samplerName = GetSamplerName(context.Properties, texOp, indexExpr);
=======
            string samplerName = OperandManager.GetSamplerName(context.Config.Stage, texOp, indexExpr);
>>>>>>> 1ec71635b (sync with main branch)

            if (texOp.Index == 3)
            {
                return $"textureQueryLevels({samplerName})";
            }
            else
            {
<<<<<<< HEAD
                context.Properties.Textures.TryGetValue(texOp.Binding, out TextureDefinition definition);
                bool hasLod = !definition.Type.HasFlag(SamplerType.Multisample) && (definition.Type & SamplerType.Mask) != SamplerType.TextureBuffer;
=======
                TextureDescriptor descriptor = context.Config.FindTextureDescriptor(texOp);
                bool hasLod = !descriptor.Type.HasFlag(SamplerType.Multisample) && descriptor.Type != SamplerType.TextureBuffer;
>>>>>>> 1ec71635b (sync with main branch)
                string texCall;

                if (hasLod)
                {
                    int lodSrcIndex = isBindless || isIndexed ? 1 : 0;
                    IAstNode lod = operation.GetSource(lodSrcIndex);
                    string lodExpr = GetSoureExpr(context, lod, GetSrcVarType(operation.Inst, lodSrcIndex));

                    texCall = $"textureSize({samplerName}, {lodExpr}){GetMask(texOp.Index)}";
                }
                else
                {
                    texCall = $"textureSize({samplerName}){GetMask(texOp.Index)}";
                }

                return texCall;
            }
        }

<<<<<<< HEAD
        public static string GenerateLoadOrStore(CodeGenContext context, AstOperation operation, bool isStore)
=======
        private static string GenerateLoadOrStore(CodeGenContext context, AstOperation operation, bool isStore)
>>>>>>> 1ec71635b (sync with main branch)
        {
            StorageKind storageKind = operation.StorageKind;

            string varName;
            AggregateType varType;
            int srcIndex = 0;
<<<<<<< HEAD
            bool isStoreOrAtomic = operation.Inst == Instruction.Store || operation.Inst.IsAtomic();
            int inputsCount = isStoreOrAtomic ? operation.SourcesCount - 1 : operation.SourcesCount;

            if (operation.Inst == Instruction.AtomicCompareAndSwap)
            {
                inputsCount--;
            }
=======
            int inputsCount = isStore ? operation.SourcesCount - 1 : operation.SourcesCount;
>>>>>>> 1ec71635b (sync with main branch)

            switch (storageKind)
            {
                case StorageKind.ConstantBuffer:
<<<<<<< HEAD
                case StorageKind.StorageBuffer:
                    if (operation.GetSource(srcIndex++) is not AstOperand bindingIndex || bindingIndex.Type != OperandType.Constant)
=======
                    if (!(operation.GetSource(srcIndex++) is AstOperand bindingIndex) || bindingIndex.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        throw new InvalidOperationException($"First input of {operation.Inst} with {storageKind} storage must be a constant operand.");
                    }

                    int binding = bindingIndex.Value;
<<<<<<< HEAD
                    BufferDefinition buffer = storageKind == StorageKind.ConstantBuffer
                        ? context.Properties.ConstantBuffers[binding]
                        : context.Properties.StorageBuffers[binding];

                    if (operation.GetSource(srcIndex++) is not AstOperand fieldIndex || fieldIndex.Type != OperandType.Constant)
=======
                    BufferDefinition buffer = context.Config.Properties.ConstantBuffers[binding];

                    if (!(operation.GetSource(srcIndex++) is AstOperand fieldIndex) || fieldIndex.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        throw new InvalidOperationException($"Second input of {operation.Inst} with {storageKind} storage must be a constant operand.");
                    }

                    StructureField field = buffer.Type.Fields[fieldIndex.Value];
                    varName = $"{buffer.Name}.{field.Name}";
                    varType = field.Type;
                    break;

<<<<<<< HEAD
                case StorageKind.LocalMemory:
                case StorageKind.SharedMemory:
                    if (operation.GetSource(srcIndex++) is not AstOperand { Type: OperandType.Constant } bindingId)
                    {
                        throw new InvalidOperationException($"First input of {operation.Inst} with {storageKind} storage must be a constant operand.");
                    }

                    MemoryDefinition memory = storageKind == StorageKind.LocalMemory
                        ? context.Properties.LocalMemories[bindingId.Value]
                        : context.Properties.SharedMemories[bindingId.Value];

                    varName = memory.Name;
                    varType = memory.Type;
                    break;

=======
>>>>>>> 1ec71635b (sync with main branch)
                case StorageKind.Input:
                case StorageKind.InputPerPatch:
                case StorageKind.Output:
                case StorageKind.OutputPerPatch:
<<<<<<< HEAD
                    if (operation.GetSource(srcIndex++) is not AstOperand varId || varId.Type != OperandType.Constant)
=======
                    if (!(operation.GetSource(srcIndex++) is AstOperand varId) || varId.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        throw new InvalidOperationException($"First input of {operation.Inst} with {storageKind} storage must be a constant operand.");
                    }

                    IoVariable ioVariable = (IoVariable)varId.Value;
                    bool isOutput = storageKind.IsOutput();
                    bool isPerPatch = storageKind.IsPerPatch();
                    int location = -1;
                    int component = 0;

<<<<<<< HEAD
                    if (context.Definitions.HasPerLocationInputOrOutput(ioVariable, isOutput))
                    {
                        if (operation.GetSource(srcIndex++) is not AstOperand vecIndex || vecIndex.Type != OperandType.Constant)
=======
                    if (context.Config.HasPerLocationInputOrOutput(ioVariable, isOutput))
                    {
                        if (!(operation.GetSource(srcIndex++) is AstOperand vecIndex) || vecIndex.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                        {
                            throw new InvalidOperationException($"Second input of {operation.Inst} with {storageKind} storage must be a constant operand.");
                        }

                        location = vecIndex.Value;

                        if (operation.SourcesCount > srcIndex &&
                            operation.GetSource(srcIndex) is AstOperand elemIndex &&
                            elemIndex.Type == OperandType.Constant &&
<<<<<<< HEAD
                            context.Definitions.HasPerLocationInputOrOutputComponent(ioVariable, location, elemIndex.Value, isOutput))
=======
                            context.Config.HasPerLocationInputOrOutputComponent(ioVariable, location, elemIndex.Value, isOutput))
>>>>>>> 1ec71635b (sync with main branch)
                        {
                            component = elemIndex.Value;
                            srcIndex++;
                        }
                    }

<<<<<<< HEAD
                    (varName, varType) = IoMap.GetGlslVariable(
                        context.Definitions,
                        context.HostCapabilities,
                        ioVariable,
                        location,
                        component,
                        isOutput,
                        isPerPatch);

                    if (IoMap.IsPerVertexBuiltIn(context.Definitions.Stage, ioVariable, isOutput))
=======
                    (varName, varType) = IoMap.GetGlslVariable(context.Config, ioVariable, location, component, isOutput, isPerPatch);

                    if (IoMap.IsPerVertexBuiltIn(context.Config.Stage, ioVariable, isOutput))
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        // Since those exist both as input and output on geometry and tessellation shaders,
                        // we need the gl_in and gl_out prefixes to disambiguate.

                        if (storageKind == StorageKind.Input)
                        {
                            string expr = GetSoureExpr(context, operation.GetSource(srcIndex++), AggregateType.S32);
                            varName = $"gl_in[{expr}].{varName}";
                        }
                        else if (storageKind == StorageKind.Output)
                        {
                            string expr = GetSoureExpr(context, operation.GetSource(srcIndex++), AggregateType.S32);
                            varName = $"gl_out[{expr}].{varName}";
                        }
                    }
                    break;

                default:
                    throw new InvalidOperationException($"Invalid storage kind {storageKind}.");
            }

            int firstSrcIndex = srcIndex;

            for (; srcIndex < inputsCount; srcIndex++)
            {
                IAstNode src = operation.GetSource(srcIndex);

                if ((varType & AggregateType.ElementCountMask) != 0 &&
                    srcIndex == inputsCount - 1 &&
                    src is AstOperand elementIndex &&
                    elementIndex.Type == OperandType.Constant)
                {
                    varName += "." + "xyzw"[elementIndex.Value & 3];
                }
<<<<<<< HEAD
                else if (srcIndex == firstSrcIndex && context.Definitions.Stage == ShaderStage.TessellationControl && storageKind == StorageKind.Output)
=======
                else if (srcIndex == firstSrcIndex && context.Config.Stage == ShaderStage.TessellationControl && storageKind == StorageKind.Output)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    // GLSL requires that for tessellation control shader outputs,
                    // that the index expression must be *exactly* "gl_InvocationID",
                    // otherwise the compilation fails.
                    // TODO: Get rid of this and use expression propagation to make sure we generate the correct code from IR.
                    varName += "[gl_InvocationID]";
                }
                else
                {
                    varName += $"[{GetSoureExpr(context, src, AggregateType.S32)}]";
                }
            }

            if (isStore)
            {
                varType &= AggregateType.ElementTypeMask;
                varName = $"{varName} = {GetSoureExpr(context, operation.GetSource(srcIndex), varType)}";
            }

            return varName;
        }

<<<<<<< HEAD
        private static string GetSamplerName(ShaderProperties resourceDefinitions, AstTextureOperation texOp, string indexExpr)
        {
            string name = resourceDefinitions.Textures[texOp.Binding].Name;

            if (texOp.Type.HasFlag(SamplerType.Indexed))
            {
                name = $"{name}[{indexExpr}]";
            }

            return name;
        }

        private static string GetImageName(ShaderProperties resourceDefinitions, AstTextureOperation texOp, string indexExpr)
        {
            string name = resourceDefinitions.Images[texOp.Binding].Name;

            if (texOp.Type.HasFlag(SamplerType.Indexed))
            {
                name = $"{name}[{indexExpr}]";
            }

            return name;
=======
        private static string GetStorageBufferAccessor(string slotExpr, string offsetExpr, ShaderStage stage)
        {
            string sbName = OperandManager.GetShaderStagePrefix(stage);

            sbName += "_" + DefaultNames.StorageNamePrefix;

            return $"{sbName}[{slotExpr}].{DefaultNames.DataName}[{offsetExpr}]";
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static string GetMask(int index)
        {
            return $".{"rgba".AsSpan(index, 1)}";
        }

        private static string GetMaskMultiDest(int mask)
        {
<<<<<<< HEAD
            StringBuilder swizzleBuilder = new();
            swizzleBuilder.Append('.');
=======
            string swizzle = ".";
>>>>>>> 1ec71635b (sync with main branch)

            for (int i = 0; i < 4; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
<<<<<<< HEAD
                    swizzleBuilder.Append("xyzw"[i]);
                }
            }

            return swizzleBuilder.ToString();
        }
    }
}
=======
                    swizzle += "xyzw"[i];
                }
            }

            return swizzle;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
