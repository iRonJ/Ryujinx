<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IOpCode32AluUx : IOpCode32AluReg
    {
        int RotateBits { get; }
        bool Add { get; }
    }
}
