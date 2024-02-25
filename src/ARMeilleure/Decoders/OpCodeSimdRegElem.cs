namespace ARMeilleure.Decoders
{
    class OpCodeSimdRegElem : OpCodeSimdReg
    {
        public int Index { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeSimdRegElem(inst, address, opCode);

        public OpCodeSimdRegElem(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            switch (Size)
            {
                case 1:
                    Index = (opCode >> 20) & 3 |
<<<<<<< HEAD
                            (opCode >> 9) & 4;
=======
                            (opCode >>  9) & 4;
>>>>>>> 1ec71635b (sync with main branch)

                    Rm &= 0xf;

                    break;

                case 2:
                    Index = (opCode >> 21) & 1 |
                            (opCode >> 10) & 2;

                    break;

<<<<<<< HEAD
                default:
                    Instruction = InstDescriptor.Undefined;
                    break;
            }
        }
    }
}
=======
                default: Instruction = InstDescriptor.Undefined; break;
            }
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
