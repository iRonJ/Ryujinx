<<<<<<< HEAD
using ARMeilleure.Instructions;
=======
﻿using ARMeilleure.Instructions;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace ARMeilleure.Decoders
{
    class OpCodeT16MemImm5 : OpCodeT16, IOpCode32Mem
    {
        public int Rt { get; }
        public int Rn { get; }

        public bool WBack => false;
        public bool IsLoad { get; }
        public bool Index => true;
        public bool Add => true;

        public int Immediate { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeT16MemImm5(inst, address, opCode);

        public OpCodeT16MemImm5(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rt = (opCode >> 0) & 7;
            Rn = (opCode >> 3) & 7;

            switch (inst.Name)
            {
                case InstName.Ldr:
                case InstName.Ldrb:
                case InstName.Ldrh:
                    IsLoad = true;
                    break;
                case InstName.Str:
                case InstName.Strb:
                case InstName.Strh:
                    IsLoad = false;
                    break;
            }

<<<<<<< HEAD
            Immediate = inst.Name switch
            {
                InstName.Str or InstName.Ldr => ((opCode >> 6) & 0x1f) << 2,
                InstName.Strb or InstName.Ldrb => ((opCode >> 6) & 0x1f),
                InstName.Strh or InstName.Ldrh => ((opCode >> 6) & 0x1f) << 1,
                _ => throw new InvalidOperationException(),
            };
=======
            switch (inst.Name)
            {
                case InstName.Str:
                case InstName.Ldr:
                    Immediate = ((opCode >> 6) & 0x1f) << 2;
                    break;
                case InstName.Strb:
                case InstName.Ldrb:
                    Immediate = ((opCode >> 6) & 0x1f);
                    break;
                case InstName.Strh:
                case InstName.Ldrh:
                    Immediate = ((opCode >> 6) & 0x1f) << 1;
                    break;
                default:
                    throw new InvalidOperationException();
            }
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
