using System;

namespace ARMeilleure.IntermediateRepresentation
{
    readonly struct Register : IEquatable<Register>
    {
        public int Index { get; }

        public RegisterType Type { get; }

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
            return (ushort)Index | ((int)Type << 16);
        }

        public static bool operator ==(Register x, Register y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Register x, Register y)
        {
            return !x.Equals(y);
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
