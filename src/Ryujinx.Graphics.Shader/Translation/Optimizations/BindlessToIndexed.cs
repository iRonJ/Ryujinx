using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using System.Collections.Generic;

using static Ryujinx.Graphics.Shader.IntermediateRepresentation.OperandHelper;

namespace Ryujinx.Graphics.Shader.Translation.Optimizations
{
    static class BindlessToIndexed
    {
<<<<<<< HEAD
        private const int NvnTextureBufferIndex = 2;

        public static void RunPass(BasicBlock block, ResourceManager resourceManager)
=======
        public static void RunPass(BasicBlock block, ShaderConfig config)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // We can turn a bindless texture access into a indexed access,
            // as long the following conditions are true:
            // - The handle is loaded using a LDC instruction.
            // - The handle is loaded from the constant buffer with the handles (CB2 for NVN).
            // - The load has a constant offset.
            // The base offset of the array of handles on the constant buffer is the constant offset.
            for (LinkedListNode<INode> node = block.Operations.First; node != null; node = node.Next)
            {
<<<<<<< HEAD
                if (node.Value is not TextureOperation texOp)
=======
                if (!(node.Value is TextureOperation texOp))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    continue;
                }

                if ((texOp.Flags & TextureFlags.Bindless) == 0)
                {
                    continue;
                }

<<<<<<< HEAD
                if (texOp.GetSource(0).AsgOp is not Operation handleAsgOp)
=======
                if (!(texOp.GetSource(0).AsgOp is Operation handleAsgOp))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    continue;
                }

                if (handleAsgOp.Inst != Instruction.Load ||
                    handleAsgOp.StorageKind != StorageKind.ConstantBuffer ||
                    handleAsgOp.SourcesCount != 4)
                {
                    continue;
                }

                Operand ldcSrc0 = handleAsgOp.GetSource(0);

                if (ldcSrc0.Type != OperandType.Constant ||
<<<<<<< HEAD
                    !resourceManager.TryGetConstantBufferSlot(ldcSrc0.Value, out int src0CbufSlot) ||
                    src0CbufSlot != NvnTextureBufferIndex)
=======
                    !config.ResourceManager.TryGetConstantBufferSlot(ldcSrc0.Value, out int src0CbufSlot) ||
                    src0CbufSlot != 2)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    continue;
                }

                Operand ldcSrc1 = handleAsgOp.GetSource(1);

                // We expect field index 0 to be accessed.
                if (ldcSrc1.Type != OperandType.Constant || ldcSrc1.Value != 0)
                {
                    continue;
                }

                Operand ldcSrc2 = handleAsgOp.GetSource(2);

                // FIXME: This is missing some checks, for example, a check to ensure that the shift value is 2.
                // Might be not worth fixing since if that doesn't kick in, the result will be no texture
                // to access anyway which is also wrong.
                // Plus this whole transform is fundamentally flawed as-is since we have no way to know the array size.
                // Eventually, this should be entirely removed in favor of a implementation that supports true bindless
                // texture access.
<<<<<<< HEAD
                if (ldcSrc2.AsgOp is not Operation shrOp || shrOp.Inst != Instruction.ShiftRightU32)
=======
                if (!(ldcSrc2.AsgOp is Operation shrOp) || shrOp.Inst != Instruction.ShiftRightU32)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    continue;
                }

<<<<<<< HEAD
                if (shrOp.GetSource(0).AsgOp is not Operation shrOp2 || shrOp2.Inst != Instruction.ShiftRightU32)
=======
                if (!(shrOp.GetSource(0).AsgOp is Operation shrOp2) || shrOp2.Inst != Instruction.ShiftRightU32)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    continue;
                }

<<<<<<< HEAD
                if (shrOp2.GetSource(0).AsgOp is not Operation addOp || addOp.Inst != Instruction.Add)
=======
                if (!(shrOp2.GetSource(0).AsgOp is Operation addOp) || addOp.Inst != Instruction.Add)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    continue;
                }

                Operand addSrc1 = addOp.GetSource(1);

                if (addSrc1.Type != OperandType.Constant)
                {
                    continue;
                }

<<<<<<< HEAD
                TurnIntoIndexed(resourceManager, texOp, addSrc1.Value / 4);
=======
                TurnIntoIndexed(config, texOp, addSrc1.Value / 4);
>>>>>>> 1ec71635b (sync with main branch)

                Operand index = Local();

                Operand source = addOp.GetSource(0);

<<<<<<< HEAD
                Operation shrBy3 = new(Instruction.ShiftRightU32, index, source, Const(3));
=======
                Operation shrBy3 = new Operation(Instruction.ShiftRightU32, index, source, Const(3));
>>>>>>> 1ec71635b (sync with main branch)

                block.Operations.AddBefore(node, shrBy3);

                texOp.SetSource(0, index);
            }
        }

<<<<<<< HEAD
        private static void TurnIntoIndexed(ResourceManager resourceManager, TextureOperation texOp, int handle)
        {
            int binding = resourceManager.GetTextureOrImageBinding(
                texOp.Inst,
                texOp.Type | SamplerType.Indexed,
                texOp.Format,
                texOp.Flags & ~TextureFlags.Bindless,
                NvnTextureBufferIndex,
                handle);

            texOp.TurnIntoIndexed(binding);
        }
    }
}
=======
        private static void TurnIntoIndexed(ShaderConfig config, TextureOperation texOp, int handle)
        {
            texOp.TurnIntoIndexed(handle);
            config.SetUsedTexture(texOp.Inst, texOp.Type, texOp.Format, texOp.Flags, texOp.CbufSlot, handle);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
