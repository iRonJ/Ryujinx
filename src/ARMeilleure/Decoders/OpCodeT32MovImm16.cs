namespace ARMeilleure.Decoders
{
    class OpCodeT32MovImm16 : OpCodeT32Alu, IOpCode32AluImm16
    {
        public int Immediate { get; }

<<<<<<< HEAD
=======
        public bool IsRotated => false;

>>>>>>> 1ec71635b (sync with main branch)
        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeT32MovImm16(inst, address, opCode);

        public OpCodeT32MovImm16(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Immediate = (opCode & 0xff) | ((opCode >> 4) & 0x700) | ((opCode >> 15) & 0x800) | ((opCode >> 4) & 0xf000);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
