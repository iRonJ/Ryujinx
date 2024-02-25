using Ryujinx.Graphics.Shader.CodeGen.Glsl.Instructions;
using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using Ryujinx.Graphics.Shader.StructuredIr;
using Ryujinx.Graphics.Shader.Translation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
<<<<<<< HEAD
=======

>>>>>>> 1ec71635b (sync with main branch)
using static Ryujinx.Graphics.Shader.StructuredIr.InstructionInfo;

namespace Ryujinx.Graphics.Shader.CodeGen.Glsl
{
    class OperandManager
    {
<<<<<<< HEAD
        private readonly Dictionary<AstOperand, string> _locals;
=======
        private static readonly string[] _stagePrefixes = new string[] { "cp", "vp", "tcp", "tep", "gp", "fp" };

        private Dictionary<AstOperand, string> _locals;
>>>>>>> 1ec71635b (sync with main branch)

        public OperandManager()
        {
            _locals = new Dictionary<AstOperand, string>();
        }

        public string DeclareLocal(AstOperand operand)
        {
            string name = $"{DefaultNames.LocalNamePrefix}_{_locals.Count}";

            _locals.Add(operand, name);

            return name;
        }

        public string GetExpression(CodeGenContext context, AstOperand operand)
        {
            return operand.Type switch
            {
                OperandType.Argument => GetArgumentName(operand.Value),
                OperandType.Constant => NumberFormatter.FormatInt(operand.Value),
                OperandType.LocalVariable => _locals[operand],
                OperandType.Undefined => DefaultNames.UndefinedName,
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid operand type \"{operand.Type}\"."),
            };
        }

=======
                _ => throw new ArgumentException($"Invalid operand type \"{operand.Type}\".")
            };
        }

        public static string GetSamplerName(ShaderStage stage, AstTextureOperation texOp, string indexExpr)
        {
            return GetSamplerName(stage, texOp.CbufSlot, texOp.Handle, texOp.Type.HasFlag(SamplerType.Indexed), indexExpr);
        }

        public static string GetSamplerName(ShaderStage stage, int cbufSlot, int handle, bool indexed, string indexExpr)
        {
            string suffix = cbufSlot < 0 ? $"_tcb_{handle:X}" : $"_cb{cbufSlot}_{handle:X}";

            if (indexed)
            {
                suffix += $"a[{indexExpr}]";
            }

            return GetShaderStagePrefix(stage) + "_" + DefaultNames.SamplerNamePrefix + suffix;
        }

        public static string GetImageName(ShaderStage stage, AstTextureOperation texOp, string indexExpr)
        {
            return GetImageName(stage, texOp.CbufSlot, texOp.Handle, texOp.Format, texOp.Type.HasFlag(SamplerType.Indexed), indexExpr);
        }

        public static string GetImageName(
            ShaderStage stage,
            int cbufSlot,
            int handle,
            TextureFormat format,
            bool indexed,
            string indexExpr)
        {
            string suffix = cbufSlot < 0
                ? $"_tcb_{handle:X}_{format.ToGlslFormat()}"
                : $"_cb{cbufSlot}_{handle:X}_{format.ToGlslFormat()}";

            if (indexed)
            {
                suffix += $"a[{indexExpr}]";
            }

            return GetShaderStagePrefix(stage) + "_" + DefaultNames.ImageNamePrefix + suffix;
        }

        public static string GetShaderStagePrefix(ShaderStage stage)
        {
            int index = (int)stage;

            if ((uint)index >= _stagePrefixes.Length)
            {
                return "invalid";
            }

            return _stagePrefixes[index];
        }

        private static char GetSwizzleMask(int value)
        {
            return "xyzw"[value];
        }

>>>>>>> 1ec71635b (sync with main branch)
        public static string GetArgumentName(int argIndex)
        {
            return $"{DefaultNames.ArgumentNamePrefix}{argIndex}";
        }

        public static AggregateType GetNodeDestType(CodeGenContext context, IAstNode node)
        {
            // TODO: Get rid of that function entirely and return the type from the operation generation
            // functions directly, like SPIR-V does.

            if (node is AstOperation operation)
            {
<<<<<<< HEAD
                if (operation.Inst == Instruction.Load || operation.Inst.IsAtomic())
=======
                if (operation.Inst == Instruction.Load)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    switch (operation.StorageKind)
                    {
                        case StorageKind.ConstantBuffer:
<<<<<<< HEAD
                        case StorageKind.StorageBuffer:
                            if (operation.GetSource(0) is not AstOperand bindingIndex || bindingIndex.Type != OperandType.Constant)
=======
                            if (!(operation.GetSource(0) is AstOperand bindingIndex) || bindingIndex.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                            {
                                throw new InvalidOperationException($"First input of {operation.Inst} with {operation.StorageKind} storage must be a constant operand.");
                            }

<<<<<<< HEAD
                            if (operation.GetSource(1) is not AstOperand fieldIndex || fieldIndex.Type != OperandType.Constant)
=======
                            if (!(operation.GetSource(1) is AstOperand fieldIndex) || fieldIndex.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                            {
                                throw new InvalidOperationException($"Second input of {operation.Inst} with {operation.StorageKind} storage must be a constant operand.");
                            }

<<<<<<< HEAD
                            BufferDefinition buffer = operation.StorageKind == StorageKind.ConstantBuffer
                                ? context.Properties.ConstantBuffers[bindingIndex.Value]
                                : context.Properties.StorageBuffers[bindingIndex.Value];
=======
                            BufferDefinition buffer = context.Config.Properties.ConstantBuffers[bindingIndex.Value];
>>>>>>> 1ec71635b (sync with main branch)
                            StructureField field = buffer.Type.Fields[fieldIndex.Value];

                            return field.Type & AggregateType.ElementTypeMask;

<<<<<<< HEAD
                        case StorageKind.LocalMemory:
                        case StorageKind.SharedMemory:
                            if (operation.GetSource(0) is not AstOperand { Type: OperandType.Constant } bindingId)
                            {
                                throw new InvalidOperationException($"First input of {operation.Inst} with {operation.StorageKind} storage must be a constant operand.");
                            }

                            MemoryDefinition memory = operation.StorageKind == StorageKind.LocalMemory
                                ? context.Properties.LocalMemories[bindingId.Value]
                                : context.Properties.SharedMemories[bindingId.Value];

                            return memory.Type & AggregateType.ElementTypeMask;

=======
>>>>>>> 1ec71635b (sync with main branch)
                        case StorageKind.Input:
                        case StorageKind.InputPerPatch:
                        case StorageKind.Output:
                        case StorageKind.OutputPerPatch:
<<<<<<< HEAD
                            if (operation.GetSource(0) is not AstOperand varId || varId.Type != OperandType.Constant)
=======
                            if (!(operation.GetSource(0) is AstOperand varId) || varId.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                            {
                                throw new InvalidOperationException($"First input of {operation.Inst} with {operation.StorageKind} storage must be a constant operand.");
                            }

                            IoVariable ioVariable = (IoVariable)varId.Value;
                            bool isOutput = operation.StorageKind == StorageKind.Output || operation.StorageKind == StorageKind.OutputPerPatch;
                            bool isPerPatch = operation.StorageKind == StorageKind.InputPerPatch || operation.StorageKind == StorageKind.OutputPerPatch;
                            int location = 0;
                            int component = 0;

<<<<<<< HEAD
                            if (context.Definitions.HasPerLocationInputOrOutput(ioVariable, isOutput))
                            {
                                if (operation.GetSource(1) is not AstOperand vecIndex || vecIndex.Type != OperandType.Constant)
=======
                            if (context.Config.HasPerLocationInputOrOutput(ioVariable, isOutput))
                            {
                                if (!(operation.GetSource(1) is AstOperand vecIndex) || vecIndex.Type != OperandType.Constant)
>>>>>>> 1ec71635b (sync with main branch)
                                {
                                    throw new InvalidOperationException($"Second input of {operation.Inst} with {operation.StorageKind} storage must be a constant operand.");
                                }

                                location = vecIndex.Value;

                                if (operation.SourcesCount > 2 &&
                                    operation.GetSource(2) is AstOperand elemIndex &&
                                    elemIndex.Type == OperandType.Constant &&
<<<<<<< HEAD
                                    context.Definitions.HasPerLocationInputOrOutputComponent(ioVariable, location, elemIndex.Value, isOutput))
=======
                                    context.Config.HasPerLocationInputOrOutputComponent(ioVariable, location, elemIndex.Value, isOutput))
>>>>>>> 1ec71635b (sync with main branch)
                                {
                                    component = elemIndex.Value;
                                }
                            }

<<<<<<< HEAD
                            (_, AggregateType varType) = IoMap.GetGlslVariable(
                                context.Definitions,
                                context.HostCapabilities,
                                ioVariable,
                                location,
                                component,
                                isOutput,
                                isPerPatch);
=======
                            (_, AggregateType varType) = IoMap.GetGlslVariable(context.Config, ioVariable, location, component, isOutput, isPerPatch);
>>>>>>> 1ec71635b (sync with main branch)

                            return varType & AggregateType.ElementTypeMask;
                    }
                }
                else if (operation.Inst == Instruction.Call)
                {
                    AstOperand funcId = (AstOperand)operation.GetSource(0);

                    Debug.Assert(funcId.Type == OperandType.Constant);

                    return context.GetFunction(funcId.Value).ReturnType;
                }
                else if (operation.Inst == Instruction.VectorExtract)
                {
                    return GetNodeDestType(context, operation.GetSource(0)) & ~AggregateType.ElementCountMask;
                }
                else if (operation is AstTextureOperation texOp)
                {
                    if (texOp.Inst == Instruction.ImageLoad ||
                        texOp.Inst == Instruction.ImageStore ||
                        texOp.Inst == Instruction.ImageAtomic)
                    {
                        return texOp.GetVectorType(texOp.Format.GetComponentType());
                    }
                    else if (texOp.Inst == Instruction.TextureSample)
                    {
                        return texOp.GetVectorType(GetDestVarType(operation.Inst));
                    }
                }

                return GetDestVarType(operation.Inst);
            }
            else if (node is AstOperand operand)
            {
                if (operand.Type == OperandType.Argument)
                {
                    int argIndex = operand.Value;

                    return context.CurrentFunction.GetArgumentType(argIndex);
                }

                return OperandInfo.GetVarType(operand);
            }
            else
            {
                throw new ArgumentException($"Invalid node type \"{node?.GetType().Name ?? "null"}\".");
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
