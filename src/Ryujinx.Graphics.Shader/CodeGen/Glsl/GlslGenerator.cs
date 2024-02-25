using Ryujinx.Graphics.Shader.CodeGen.Glsl.Instructions;
using Ryujinx.Graphics.Shader.StructuredIr;
using Ryujinx.Graphics.Shader.Translation;
using System;

using static Ryujinx.Graphics.Shader.CodeGen.Glsl.TypeConversion;

namespace Ryujinx.Graphics.Shader.CodeGen.Glsl
{
    static class GlslGenerator
    {
        private const string MainFunctionName = "main";

<<<<<<< HEAD
        public static string Generate(StructuredProgramInfo info, CodeGenParameters parameters)
        {
            CodeGenContext context = new(info, parameters);
=======
        public static string Generate(StructuredProgramInfo info, ShaderConfig config)
        {
            CodeGenContext context = new CodeGenContext(info, config);
>>>>>>> 1ec71635b (sync with main branch)

            Declarations.Declare(context, info);

            if (info.Functions.Count != 0)
            {
                for (int i = 1; i < info.Functions.Count; i++)
                {
                    context.AppendLine($"{GetFunctionSignature(context, info.Functions[i])};");
                }

                context.AppendLine();

                for (int i = 1; i < info.Functions.Count; i++)
                {
<<<<<<< HEAD
                    PrintFunction(context, info.Functions[i]);
=======
                    PrintFunction(context, info, info.Functions[i]);
>>>>>>> 1ec71635b (sync with main branch)

                    context.AppendLine();
                }
            }

<<<<<<< HEAD
            PrintFunction(context, info.Functions[0], MainFunctionName);
=======
            PrintFunction(context, info, info.Functions[0], MainFunctionName);
>>>>>>> 1ec71635b (sync with main branch)

            return context.GetCode();
        }

<<<<<<< HEAD
        private static void PrintFunction(CodeGenContext context, StructuredFunction function, string funcName = null)
=======
        private static void PrintFunction(CodeGenContext context, StructuredProgramInfo info, StructuredFunction function, string funcName = null)
>>>>>>> 1ec71635b (sync with main branch)
        {
            context.CurrentFunction = function;

            context.AppendLine(GetFunctionSignature(context, function, funcName));
            context.EnterScope();

            Declarations.DeclareLocals(context, function);

<<<<<<< HEAD
            PrintBlock(context, function.MainBlock, funcName == MainFunctionName);
=======
            PrintBlock(context, function.MainBlock);
>>>>>>> 1ec71635b (sync with main branch)

            context.LeaveScope();
        }

        private static string GetFunctionSignature(CodeGenContext context, StructuredFunction function, string funcName = null)
        {
            string[] args = new string[function.InArguments.Length + function.OutArguments.Length];

            for (int i = 0; i < function.InArguments.Length; i++)
            {
                args[i] = $"{Declarations.GetVarTypeName(context, function.InArguments[i])} {OperandManager.GetArgumentName(i)}";
            }

            for (int i = 0; i < function.OutArguments.Length; i++)
            {
                int j = i + function.InArguments.Length;

                args[j] = $"out {Declarations.GetVarTypeName(context, function.OutArguments[i])} {OperandManager.GetArgumentName(j)}";
            }

            return $"{Declarations.GetVarTypeName(context, function.ReturnType)} {funcName ?? function.Name}({string.Join(", ", args)})";
        }

<<<<<<< HEAD
        private static void PrintBlock(CodeGenContext context, AstBlock block, bool isMainFunction)
        {
            AstBlockVisitor visitor = new(block);
=======
        private static void PrintBlock(CodeGenContext context, AstBlock block)
        {
            AstBlockVisitor visitor = new AstBlockVisitor(block);
>>>>>>> 1ec71635b (sync with main branch)

            visitor.BlockEntered += (sender, e) =>
            {
                switch (e.Block.Type)
                {
                    case AstBlockType.DoWhile:
                        context.AppendLine("do");
                        break;

                    case AstBlockType.Else:
                        context.AppendLine("else");
                        break;

                    case AstBlockType.ElseIf:
                        context.AppendLine($"else if ({GetCondExpr(context, e.Block.Condition)})");
                        break;

                    case AstBlockType.If:
                        context.AppendLine($"if ({GetCondExpr(context, e.Block.Condition)})");
                        break;

<<<<<<< HEAD
                    default:
                        throw new InvalidOperationException($"Found unexpected block type \"{e.Block.Type}\".");
=======
                    default: throw new InvalidOperationException($"Found unexpected block type \"{e.Block.Type}\".");
>>>>>>> 1ec71635b (sync with main branch)
                }

                context.EnterScope();
            };

            visitor.BlockLeft += (sender, e) =>
            {
                context.LeaveScope();

                if (e.Block.Type == AstBlockType.DoWhile)
                {
                    context.AppendLine($"while ({GetCondExpr(context, e.Block.Condition)});");
                }
            };

<<<<<<< HEAD
            bool supportsBarrierDivergence = context.HostCapabilities.SupportsShaderBarrierDivergence;
            bool mayHaveReturned = false;

=======
>>>>>>> 1ec71635b (sync with main branch)
            foreach (IAstNode node in visitor.Visit())
            {
                if (node is AstOperation operation)
                {
<<<<<<< HEAD
                    if (!supportsBarrierDivergence)
                    {
                        if (operation.Inst == IntermediateRepresentation.Instruction.Barrier)
                        {
                            // Barrier on divergent control flow paths may cause the GPU to hang,
                            // so skip emitting the barrier for those cases.
                            if (visitor.Block.Type != AstBlockType.Main || mayHaveReturned || !isMainFunction)
                            {
                                context.Logger.Log("Shader has barrier on potentially divergent block, the barrier will be removed.");

                                continue;
                            }
                        }
                        else if (operation.Inst == IntermediateRepresentation.Instruction.Return)
                        {
                            mayHaveReturned = true;
                        }
                    }

=======
>>>>>>> 1ec71635b (sync with main branch)
                    string expr = InstGen.GetExpression(context, operation);

                    if (expr != null)
                    {
                        context.AppendLine(expr + ";");
                    }
                }
                else if (node is AstAssignment assignment)
                {
                    AggregateType dstType = OperandManager.GetNodeDestType(context, assignment.Destination);
                    AggregateType srcType = OperandManager.GetNodeDestType(context, assignment.Source);

                    string dest = InstGen.GetExpression(context, assignment.Destination);
                    string src = ReinterpretCast(context, assignment.Source, srcType, dstType);

                    context.AppendLine(dest + " = " + src + ";");
                }
                else if (node is AstComment comment)
                {
                    context.AppendLine("// " + comment.Comment);
                }
                else
                {
                    throw new InvalidOperationException($"Found unexpected node type \"{node?.GetType().Name ?? "null"}\".");
                }
            }
        }

        private static string GetCondExpr(CodeGenContext context, IAstNode cond)
        {
            AggregateType srcType = OperandManager.GetNodeDestType(context, cond);

            return ReinterpretCast(context, cond, srcType, AggregateType.Bool);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
