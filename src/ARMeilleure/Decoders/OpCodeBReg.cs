namespace ARMeilleure.Decoders
{
    class OpCodeBReg : OpCode
    {
        public int Rn { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeBReg(inst, address, opCode);

        public OpCodeBReg(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            int op4 = (opCode >> 0) & 0x1f;
=======
            int op4 = (opCode >>  0) & 0x1f;
>>>>>>> 1ec71635b (sync with main branch)
            int op2 = (opCode >> 16) & 0x1f;

            if (op2 != 0b11111 || op4 != 0b00000)
            {
                Instruction = InstDescriptor.Undefined;

                return;
            }

            Rn = (opCode >> 5) & 0x1f;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
