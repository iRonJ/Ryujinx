using ARMeilleure.Decoders;
using ARMeilleure.IntermediateRepresentation;
using ARMeilleure.Translation;
<<<<<<< HEAD
=======

>>>>>>> 1ec71635b (sync with main branch)
using static ARMeilleure.Instructions.InstEmitHelper;
using static ARMeilleure.IntermediateRepresentation.Operand.Factory;

namespace ARMeilleure.Instructions
{
    static partial class InstEmit
    {
        public static void Sdiv(ArmEmitterContext context) => EmitDiv(context, unsigned: false);
        public static void Udiv(ArmEmitterContext context) => EmitDiv(context, unsigned: true);

        private static void EmitDiv(ArmEmitterContext context, bool unsigned)
        {
            OpCodeAluBinary op = (OpCodeAluBinary)context.CurrOp;

            // If Rm == 0, Rd = 0 (division by zero).
            Operand n = GetIntOrZR(context, op.Rn);
            Operand m = GetIntOrZR(context, op.Rm);

            Operand divisorIsZero = context.ICompareEqual(m, Const(m.Type, 0));

            Operand lblBadDiv = Label();
<<<<<<< HEAD
            Operand lblEnd = Label();
=======
            Operand lblEnd    = Label();
>>>>>>> 1ec71635b (sync with main branch)

            context.BranchIfTrue(lblBadDiv, divisorIsZero);

            if (!unsigned)
            {
                // If Rn == INT_MIN && Rm == -1, Rd = INT_MIN (overflow).
                bool is32Bits = op.RegisterSize == RegisterSize.Int32;

                Operand intMin = is32Bits ? Const(int.MinValue) : Const(long.MinValue);
<<<<<<< HEAD
                Operand minus1 = is32Bits ? Const(-1) : Const(-1L);
=======
                Operand minus1 = is32Bits ? Const(-1)           : Const(-1L);
>>>>>>> 1ec71635b (sync with main branch)

                Operand nIsIntMin = context.ICompareEqual(n, intMin);
                Operand mIsMinus1 = context.ICompareEqual(m, minus1);

                Operand lblGoodDiv = Label();

                context.BranchIfFalse(lblGoodDiv, context.BitwiseAnd(nIsIntMin, mIsMinus1));

                SetAluDOrZR(context, intMin);

                context.Branch(lblEnd);

                context.MarkLabel(lblGoodDiv);
            }

            Operand d = unsigned
                ? context.DivideUI(n, m)
<<<<<<< HEAD
                : context.Divide(n, m);
=======
                : context.Divide  (n, m);
>>>>>>> 1ec71635b (sync with main branch)

            SetAluDOrZR(context, d);

            context.Branch(lblEnd);

            context.MarkLabel(lblBadDiv);

            SetAluDOrZR(context, Const(op.GetOperandType(), 0));

            context.MarkLabel(lblEnd);
        }
    }
}
