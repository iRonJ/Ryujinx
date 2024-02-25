using System;

namespace Ryujinx.Graphics.Shader.Decoders
{
    readonly struct Register : IEquatable<Register>
    {
        public int Index { get; }

        public RegisterType Type { get; }

<<<<<<< HEAD
        public bool IsRZ => Type == RegisterType.Gpr && Index == RegisterConsts.RegisterZeroIndex;
=======
        public bool IsRZ => Type == RegisterType.Gpr       && Index == RegisterConsts.RegisterZeroIndex;
>>>>>>> 1ec71635b (sync with main branch)
        public bool IsPT => Type == RegisterType.Predicate && Index == RegisterConsts.PredicateTrueIndex;

        public Register(int index, RegisterType type)
        {
            Index = index;
<<<<<<< HEAD
            Type = type;
=======
            Type  = type;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override int GetHashCode()
        {
            return (ushort)Index | ((ushort)Type << 16);
        }

        public override bool Equals(object obj)
        {
            return obj is Register reg && Equals(reg);
        }

        public bool Equals(Register other)
        {
            return other.Index == Index &&
<<<<<<< HEAD
                   other.Type == Type;
        }
    }
}
=======
                   other.Type  == Type;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
