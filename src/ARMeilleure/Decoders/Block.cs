using System;
using System.Collections.Generic;

namespace ARMeilleure.Decoders
{
    class Block
    {
<<<<<<< HEAD
        public ulong Address { get; set; }
        public ulong EndAddress { get; set; }

        public Block Next { get; set; }
=======
        public ulong Address    { get; set; }
        public ulong EndAddress { get; set; }

        public Block Next   { get; set; }
>>>>>>> 1ec71635b (sync with main branch)
        public Block Branch { get; set; }

        public bool Exit { get; set; }

        public List<OpCode> OpCodes { get; }

        public Block()
        {
            OpCodes = new List<OpCode>();
        }

        public Block(ulong address) : this()
        {
            Address = address;
        }

        public void Split(Block rightBlock)
        {
            int splitIndex = BinarySearch(OpCodes, rightBlock.Address);

            if (OpCodes[splitIndex].Address < rightBlock.Address)
            {
                splitIndex++;
            }

            int splitCount = OpCodes.Count - splitIndex;

            if (splitCount <= 0)
            {
                throw new ArgumentException("Can't split at right block address.");
            }

            rightBlock.EndAddress = EndAddress;

<<<<<<< HEAD
            rightBlock.Next = Next;
=======
            rightBlock.Next   = Next;
>>>>>>> 1ec71635b (sync with main branch)
            rightBlock.Branch = Branch;

            rightBlock.OpCodes.AddRange(OpCodes.GetRange(splitIndex, splitCount));

            EndAddress = rightBlock.Address;

<<<<<<< HEAD
            Next = rightBlock;
=======
            Next   = rightBlock;
>>>>>>> 1ec71635b (sync with main branch)
            Branch = null;

            OpCodes.RemoveRange(splitIndex, splitCount);
        }

        private static int BinarySearch(List<OpCode> opCodes, ulong address)
        {
<<<<<<< HEAD
            int left = 0;
            int middle = 0;
            int right = opCodes.Count - 1;
=======
            int left   = 0;
            int middle = 0;
            int right  = opCodes.Count - 1;
>>>>>>> 1ec71635b (sync with main branch)

            while (left <= right)
            {
                int size = right - left;

                middle = left + (size >> 1);

                OpCode opCode = opCodes[middle];

                if (address == (ulong)opCode.Address)
                {
                    break;
                }

                if (address < (ulong)opCode.Address)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return middle;
        }

        public OpCode GetLastOp()
        {
            if (OpCodes.Count > 0)
            {
<<<<<<< HEAD
                return OpCodes[^1];
=======
                return OpCodes[OpCodes.Count - 1];
>>>>>>> 1ec71635b (sync with main branch)
            }

            return null;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
