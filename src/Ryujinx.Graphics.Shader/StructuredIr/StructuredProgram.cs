using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using Ryujinx.Graphics.Shader.Translation;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Diagnostics;
=======
>>>>>>> 1ec71635b (sync with main branch)
using System.Numerics;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    static class StructuredProgram
    {
<<<<<<< HEAD
        // TODO: Eventually it should be possible to specify the parameter types for the function instead of using S32 for everything.
        private const AggregateType FuncParameterType = AggregateType.S32;

        public static StructuredProgramInfo MakeStructuredProgram(
            IReadOnlyList<Function> functions,
            AttributeUsage attributeUsage,
            ShaderDefinitions definitions,
            ResourceManager resourceManager,
            TargetLanguage targetLanguage,
            bool debugMode)
        {
            StructuredProgramContext context = new(attributeUsage, definitions, resourceManager, debugMode);
=======
        public static StructuredProgramInfo MakeStructuredProgram(IReadOnlyList<Function> functions, ShaderConfig config)
        {
            StructuredProgramContext context = new StructuredProgramContext(config);
>>>>>>> 1ec71635b (sync with main branch)

            for (int funcIndex = 0; funcIndex < functions.Count; funcIndex++)
            {
                Function function = functions[funcIndex];

                BasicBlock[] blocks = function.Blocks;

<<<<<<< HEAD
                AggregateType returnType = function.ReturnsValue ? FuncParameterType : AggregateType.Void;

                AggregateType[] inArguments = new AggregateType[function.InArgumentsCount];
=======
                AggregateType returnType = function.ReturnsValue ? AggregateType.S32 : AggregateType.Void;

                AggregateType[] inArguments  = new AggregateType[function.InArgumentsCount];
>>>>>>> 1ec71635b (sync with main branch)
                AggregateType[] outArguments = new AggregateType[function.OutArgumentsCount];

                for (int i = 0; i < inArguments.Length; i++)
                {
<<<<<<< HEAD
                    inArguments[i] = FuncParameterType;
=======
                    inArguments[i] = AggregateType.S32;
>>>>>>> 1ec71635b (sync with main branch)
                }

                for (int i = 0; i < outArguments.Length; i++)
                {
<<<<<<< HEAD
                    outArguments[i] = FuncParameterType;
=======
                    outArguments[i] = AggregateType.S32;
>>>>>>> 1ec71635b (sync with main branch)
                }

                context.EnterFunction(blocks.Length, function.Name, returnType, inArguments, outArguments);

                PhiFunctions.Remove(blocks);

                for (int blkIndex = 0; blkIndex < blocks.Length; blkIndex++)
                {
                    BasicBlock block = blocks[blkIndex];

                    context.EnterBlock(block);

                    for (LinkedListNode<INode> opNode = block.Operations.First; opNode != null; opNode = opNode.Next)
                    {
                        Operation operation = (Operation)opNode.Value;

                        if (IsBranchInst(operation.Inst))
                        {
                            context.LeaveBlock(block, operation);
                        }
                        else
                        {
<<<<<<< HEAD
                            AddOperation(context, operation, targetLanguage, functions);
=======
                            AddOperation(context, operation);
>>>>>>> 1ec71635b (sync with main branch)
                        }
                    }
                }

                GotoElimination.Eliminate(context.GetGotos());

                AstOptimizer.Optimize(context);

                context.LeaveFunction();
            }

            return context.Info;
        }

<<<<<<< HEAD
        private static void AddOperation(StructuredProgramContext context, Operation operation, TargetLanguage targetLanguage, IReadOnlyList<Function> functions)
=======
        private static void AddOperation(StructuredProgramContext context, Operation operation)
>>>>>>> 1ec71635b (sync with main branch)
        {
            Instruction inst = operation.Inst;
            StorageKind storageKind = operation.StorageKind;

            if (inst == Instruction.Load || inst == Instruction.Store)
            {
                if (storageKind.IsInputOrOutput())
                {
                    IoVariable ioVariable = (IoVariable)operation.GetSource(0).Value;
                    bool isOutput = storageKind.IsOutput();
<<<<<<< HEAD
                    int location = 0;
                    int component = 0;

                    if (context.Definitions.HasPerLocationInputOrOutput(ioVariable, isOutput))
=======
                    bool perPatch = storageKind.IsPerPatch();
                    int location = 0;
                    int component = 0;

                    if (context.Config.HasPerLocationInputOrOutput(ioVariable, isOutput))
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        location = operation.GetSource(1).Value;

                        if (operation.SourcesCount > 2 &&
                            operation.GetSource(2).Type == OperandType.Constant &&
<<<<<<< HEAD
                            context.Definitions.HasPerLocationInputOrOutputComponent(ioVariable, location, operation.GetSource(2).Value, isOutput))
=======
                            context.Config.HasPerLocationInputOrOutputComponent(ioVariable, location, operation.GetSource(2).Value, isOutput))
>>>>>>> 1ec71635b (sync with main branch)
                        {
                            component = operation.GetSource(2).Value;
                        }
                    }

                    context.Info.IoDefinitions.Add(new IoDefinition(storageKind, ioVariable, location, component));
                }
                else if (storageKind == StorageKind.ConstantBuffer && operation.GetSource(0).Type == OperandType.Constant)
                {
<<<<<<< HEAD
                    context.ResourceManager.SetUsedConstantBufferBinding(operation.GetSource(0).Value);
=======
                    context.Config.ResourceManager.SetUsedConstantBufferBinding(operation.GetSource(0).Value);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            bool vectorDest = IsVectorDestInst(inst);

            int sourcesCount = operation.SourcesCount;
            int outDestsCount = operation.DestsCount != 0 && !vectorDest ? operation.DestsCount - 1 : 0;

            IAstNode[] sources = new IAstNode[sourcesCount + outDestsCount];

<<<<<<< HEAD
            if (inst == Instruction.Call && targetLanguage == TargetLanguage.Spirv)
            {
                // SPIR-V requires that all function parameters are copied to a local variable before the call
                // (or at least that's what the Khronos compiler does).

                // First one is the function index.
                Operand funcIndexOperand = operation.GetSource(0);
                Debug.Assert(funcIndexOperand.Type == OperandType.Constant);
                int funcIndex = funcIndexOperand.Value;

                sources[0] = new AstOperand(OperandType.Constant, funcIndex);

                int inArgsCount = functions[funcIndex].InArgumentsCount;

                // Remaining ones are parameters, copy them to a temp local variable.
                for (int index = 1; index < operation.SourcesCount; index++)
                {
                    IAstNode source = context.GetOperandOrCbLoad(operation.GetSource(index));

                    if (index - 1 < inArgsCount)
                    {
                        AstOperand argTemp = context.NewTemp(FuncParameterType);
                        context.AddNode(new AstAssignment(argTemp, source));
                        sources[index] = argTemp;
                    }
                    else
                    {
                        sources[index] = source;
                    }
                }
            }
            else
            {
                for (int index = 0; index < operation.SourcesCount; index++)
                {
                    sources[index] = context.GetOperandOrCbLoad(operation.GetSource(index));
                }
=======
            for (int index = 0; index < operation.SourcesCount; index++)
            {
                sources[index] = context.GetOperandOrCbLoad(operation.GetSource(index));
>>>>>>> 1ec71635b (sync with main branch)
            }

            for (int index = 0; index < outDestsCount; index++)
            {
                AstOperand oper = context.GetOperand(operation.GetDest(1 + index));

                oper.VarType = InstructionInfo.GetSrcVarType(inst, sourcesCount + index);

                sources[sourcesCount + index] = oper;
            }

            AstTextureOperation GetAstTextureOperation(TextureOperation texOp)
            {
<<<<<<< HEAD
                return new AstTextureOperation(inst, texOp.Type, texOp.Format, texOp.Flags, texOp.Binding, texOp.Index, sources);
=======
                return new AstTextureOperation(
                    inst,
                    texOp.Type,
                    texOp.Format,
                    texOp.Flags,
                    texOp.CbufSlot,
                    texOp.Handle,
                    texOp.Index,
                    sources);
>>>>>>> 1ec71635b (sync with main branch)
            }

            int componentsCount = BitOperations.PopCount((uint)operation.Index);

            if (vectorDest && componentsCount > 1)
            {
                AggregateType destType = InstructionInfo.GetDestVarType(inst);

                IAstNode source;

                if (operation is TextureOperation texOp)
                {
                    if (texOp.Inst == Instruction.ImageLoad)
                    {
                        destType = texOp.Format.GetComponentType();
                    }

                    source = GetAstTextureOperation(texOp);
                }
                else
                {
                    source = new AstOperation(
                        inst,
                        operation.StorageKind,
                        operation.ForcePrecise,
                        operation.Index,
                        sources,
                        operation.SourcesCount);
                }

                AggregateType destElemType = destType;

                switch (componentsCount)
                {
<<<<<<< HEAD
                    case 2:
                        destType |= AggregateType.Vector2;
                        break;
                    case 3:
                        destType |= AggregateType.Vector3;
                        break;
                    case 4:
                        destType |= AggregateType.Vector4;
                        break;
=======
                    case 2: destType |= AggregateType.Vector2; break;
                    case 3: destType |= AggregateType.Vector3; break;
                    case 4: destType |= AggregateType.Vector4; break;
>>>>>>> 1ec71635b (sync with main branch)
                }

                AstOperand destVec = context.NewTemp(destType);

                context.AddNode(new AstAssignment(destVec, source));

                for (int i = 0; i < operation.DestsCount; i++)
                {
                    AstOperand dest = context.GetOperand(operation.GetDest(i));
<<<<<<< HEAD
                    AstOperand index = new(OperandType.Constant, i);
=======
                    AstOperand index = new AstOperand(OperandType.Constant, i);
>>>>>>> 1ec71635b (sync with main branch)

                    dest.VarType = destElemType;

                    context.AddNode(new AstAssignment(dest, new AstOperation(Instruction.VectorExtract, StorageKind.None, false, new[] { destVec, index }, 2)));
                }
            }
            else if (operation.Dest != null)
            {
                AstOperand dest = context.GetOperand(operation.Dest);

                // If all the sources are bool, it's better to use short-circuiting
                // logical operations, rather than forcing a cast to int and doing
                // a bitwise operation with the value, as it is likely to be used as
                // a bool in the end.
                if (IsBitwiseInst(inst) && AreAllSourceTypesEqual(sources, AggregateType.Bool))
                {
                    inst = GetLogicalFromBitwiseInst(inst);
                }

                bool isCondSel = inst == Instruction.ConditionalSelect;
<<<<<<< HEAD
                bool isCopy = inst == Instruction.Copy;
=======
                bool isCopy    = inst == Instruction.Copy;
>>>>>>> 1ec71635b (sync with main branch)

                if (isCondSel || isCopy)
                {
                    AggregateType type = GetVarTypeFromUses(operation.Dest);

                    if (isCondSel && type == AggregateType.FP32)
                    {
                        inst |= Instruction.FP32;
                    }

                    dest.VarType = type;
                }
                else
                {
                    dest.VarType = InstructionInfo.GetDestVarType(inst);
                }

                IAstNode source;

                if (operation is TextureOperation texOp)
                {
                    if (texOp.Inst == Instruction.ImageLoad)
                    {
                        dest.VarType = texOp.Format.GetComponentType();
                    }

                    source = GetAstTextureOperation(texOp);
                }
                else if (!isCopy)
                {
                    source = new AstOperation(
                        inst,
                        operation.StorageKind,
                        operation.ForcePrecise,
                        operation.Index,
                        sources,
                        operation.SourcesCount);
                }
                else
                {
                    source = sources[0];
                }

                context.AddNode(new AstAssignment(dest, source));
            }
            else if (operation.Inst == Instruction.Comment)
            {
                context.AddNode(new AstComment(((CommentNode)operation).Comment));
            }
            else if (operation is TextureOperation texOp)
            {
                AstTextureOperation astTexOp = GetAstTextureOperation(texOp);

                context.AddNode(astTexOp);
            }
            else
            {
                context.AddNode(new AstOperation(
                    inst,
                    operation.StorageKind,
                    operation.ForcePrecise,
                    operation.Index,
                    sources,
                    operation.SourcesCount));
            }

            // Those instructions needs to be emulated by using helper functions,
            // because they are NVIDIA specific. Those flags helps the backend to
            // decide which helper functions are needed on the final generated code.
            switch (operation.Inst)
            {
<<<<<<< HEAD
=======
                case Instruction.AtomicMaxS32:
                case Instruction.AtomicMinS32:
                    if (operation.StorageKind == StorageKind.SharedMemory)
                    {
                        context.Info.HelperFunctionsMask |= HelperFunctionsMask.AtomicMinMaxS32Shared;
                    }
                    else if (operation.StorageKind == StorageKind.StorageBuffer)
                    {
                        context.Info.HelperFunctionsMask |= HelperFunctionsMask.AtomicMinMaxS32Storage;
                    }
                    break;
>>>>>>> 1ec71635b (sync with main branch)
                case Instruction.MultiplyHighS32:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.MultiplyHighS32;
                    break;
                case Instruction.MultiplyHighU32:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.MultiplyHighU32;
                    break;
<<<<<<< HEAD
=======
                case Instruction.Shuffle:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.Shuffle;
                    break;
                case Instruction.ShuffleDown:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.ShuffleDown;
                    break;
                case Instruction.ShuffleUp:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.ShuffleUp;
                    break;
                case Instruction.ShuffleXor:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.ShuffleXor;
                    break;
                case Instruction.StoreShared16:
                case Instruction.StoreShared8:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.StoreSharedSmallInt;
                    break;
                case Instruction.StoreStorage16:
                case Instruction.StoreStorage8:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.StoreStorageSmallInt;
                    break;
>>>>>>> 1ec71635b (sync with main branch)
                case Instruction.SwizzleAdd:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.SwizzleAdd;
                    break;
                case Instruction.FSIBegin:
                case Instruction.FSIEnd:
                    context.Info.HelperFunctionsMask |= HelperFunctionsMask.FSI;
                    break;
            }
        }

        private static AggregateType GetVarTypeFromUses(Operand dest)
        {
<<<<<<< HEAD
            HashSet<Operand> visited = new();

            Queue<Operand> pending = new();
=======
            HashSet<Operand> visited = new HashSet<Operand>();

            Queue<Operand> pending = new Queue<Operand>();
>>>>>>> 1ec71635b (sync with main branch)

            bool Enqueue(Operand operand)
            {
                if (visited.Add(operand))
                {
                    pending.Enqueue(operand);

                    return true;
                }

                return false;
            }

            Enqueue(dest);

            while (pending.TryDequeue(out Operand operand))
            {
                foreach (INode useNode in operand.UseOps)
                {
                    if (useNode is not Operation operation)
                    {
                        continue;
                    }

                    if (operation.Inst == Instruction.Copy)
                    {
                        if (operation.Dest.Type == OperandType.LocalVariable)
                        {
                            if (Enqueue(operation.Dest))
                            {
                                break;
                            }
                        }
                        else
                        {
                            return OperandInfo.GetVarType(operation.Dest.Type);
                        }
                    }
                    else
                    {
                        for (int index = 0; index < operation.SourcesCount; index++)
                        {
                            if (operation.GetSource(index) == operand)
                            {
                                return InstructionInfo.GetSrcVarType(operation.Inst, index);
                            }
                        }
                    }
                }
            }

            return AggregateType.S32;
        }

        private static bool AreAllSourceTypesEqual(IAstNode[] sources, AggregateType type)
        {
            foreach (IAstNode node in sources)
            {
                if (node is not AstOperand operand)
                {
                    return false;
                }

                if (operand.VarType != type)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsVectorDestInst(Instruction inst)
        {
            return inst switch
            {
                Instruction.ImageLoad or
                Instruction.TextureSample => true,
<<<<<<< HEAD
                _ => false,
=======
                _ => false
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static bool IsBranchInst(Instruction inst)
        {
            return inst switch
            {
                Instruction.Branch or
                Instruction.BranchIfFalse or
                Instruction.BranchIfTrue => true,
<<<<<<< HEAD
                _ => false,
=======
                _ => false
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static bool IsBitwiseInst(Instruction inst)
        {
            return inst switch
            {
                Instruction.BitwiseAnd or
                Instruction.BitwiseExclusiveOr or
                Instruction.BitwiseNot or
                Instruction.BitwiseOr => true,
<<<<<<< HEAD
                _ => false,
=======
                _ => false
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static Instruction GetLogicalFromBitwiseInst(Instruction inst)
        {
            return inst switch
            {
                Instruction.BitwiseAnd => Instruction.LogicalAnd,
                Instruction.BitwiseExclusiveOr => Instruction.LogicalExclusiveOr,
                Instruction.BitwiseNot => Instruction.LogicalNot,
                Instruction.BitwiseOr => Instruction.LogicalOr,
<<<<<<< HEAD
                _ => throw new ArgumentException($"Unexpected instruction \"{inst}\"."),
            };
        }
    }
}
=======
                _ => throw new ArgumentException($"Unexpected instruction \"{inst}\".")
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
