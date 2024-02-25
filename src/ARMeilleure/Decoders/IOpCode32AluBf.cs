<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IOpCode32AluBf
    {
        int Rd { get; }
        int Rn { get; }

        int Msb { get; }
        int Lsb { get; }

        int SourceMask => (int)(0xFFFFFFFF >> (31 - Msb));
        int DestMask => SourceMask & (int)(0xFFFFFFFF << Lsb);
    }
}
