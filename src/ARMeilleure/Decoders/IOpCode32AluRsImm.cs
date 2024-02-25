<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IOpCode32AluRsImm : IOpCode32Alu
    {
        int Rm { get; }
        int Immediate { get; }

        ShiftType ShiftType { get; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
