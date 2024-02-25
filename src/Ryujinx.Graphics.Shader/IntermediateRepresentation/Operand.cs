using Ryujinx.Graphics.Shader.Decoders;
using System;
using System.Collections.Generic;

namespace Ryujinx.Graphics.Shader.IntermediateRepresentation
{
    class Operand
    {
        private const int CbufSlotBits = 5;
<<<<<<< HEAD
        private const int CbufSlotLsb = 32 - CbufSlotBits;
=======
        private const int CbufSlotLsb  = 32 - CbufSlotBits;
>>>>>>> 1ec71635b (sync with main branch)
        private const int CbufSlotMask = (1 << CbufSlotBits) - 1;

        public OperandType Type { get; }

        public int Value { get; }

        public INode AsgOp { get; set; }

        public HashSet<INode> UseOps { get; }

        private Operand()
        {
            UseOps = new HashSet<INode>();
        }

        public Operand(OperandType type) : this()
        {
            Type = type;
        }

        public Operand(OperandType type, int value) : this()
        {
<<<<<<< HEAD
            Type = type;
=======
            Type  = type;
>>>>>>> 1ec71635b (sync with main branch)
            Value = value;
        }

        public Operand(Register reg) : this()
        {
<<<<<<< HEAD
            Type = OperandType.Register;
=======
            Type  = OperandType.Register;
>>>>>>> 1ec71635b (sync with main branch)
            Value = PackRegInfo(reg.Index, reg.Type);
        }

        public Operand(int slot, int offset) : this()
        {
<<<<<<< HEAD
            Type = OperandType.ConstantBuffer;
=======
            Type  = OperandType.ConstantBuffer;
>>>>>>> 1ec71635b (sync with main branch)
            Value = PackCbufInfo(slot, offset);
        }

        private static int PackCbufInfo(int slot, int offset)
        {
            return (slot << CbufSlotLsb) | offset;
        }

        private static int PackRegInfo(int index, RegisterType type)
        {
            return ((int)type << 24) | index;
        }

        public int GetCbufSlot()
        {
            return (Value >> CbufSlotLsb) & CbufSlotMask;
        }

        public int GetCbufOffset()
        {
            return Value & ~(CbufSlotMask << CbufSlotLsb);
        }

        public Register GetRegister()
        {
            return new Register(Value & 0xffffff, (RegisterType)(Value >> 24));
        }

        public float AsFloat()
        {
            return BitConverter.Int32BitsToSingle(Value);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
