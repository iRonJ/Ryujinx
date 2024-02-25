<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;

namespace ARMeilleure.Decoders.Optimizations
{
    static class TailCallRemover
    {
        public static Block[] RunPass(ulong entryAddress, List<Block> blocks)
        {
            // Detect tail calls:
            // - Assume this function spans the space covered by contiguous code blocks surrounding the entry address.
            // - A jump to an area outside this contiguous region will be treated as an exit block.
            // - Include a small allowance for jumps outside the contiguous range.

            if (!Decoder.BinarySearch(blocks, entryAddress, out int entryBlockId))
            {
                throw new InvalidOperationException("Function entry point is not contained in a block.");
            }

<<<<<<< HEAD
            const ulong Allowance = 4;
=======
            const ulong allowance = 4;
>>>>>>> 1ec71635b (sync with main branch)

            Block entryBlock = blocks[entryBlockId];

            Block startBlock = entryBlock;
<<<<<<< HEAD
            Block endBlock = entryBlock;

            int startBlockIndex = entryBlockId;
            int endBlockIndex = entryBlockId;
=======
            Block endBlock   = entryBlock;

            int startBlockIndex = entryBlockId;
            int endBlockIndex   = entryBlockId;
>>>>>>> 1ec71635b (sync with main branch)

            for (int i = entryBlockId + 1; i < blocks.Count; i++) // Search forwards.
            {
                Block block = blocks[i];

<<<<<<< HEAD
                if (endBlock.EndAddress < block.Address - Allowance)
=======
                if (endBlock.EndAddress < block.Address - allowance)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    break; // End of contiguous function.
                }

<<<<<<< HEAD
                endBlock = block;
=======
                endBlock      = block;
>>>>>>> 1ec71635b (sync with main branch)
                endBlockIndex = i;
            }

            for (int i = entryBlockId - 1; i >= 0; i--) // Search backwards.
            {
                Block block = blocks[i];

<<<<<<< HEAD
                if (startBlock.Address > block.EndAddress + Allowance)
=======
                if (startBlock.Address > block.EndAddress + allowance)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    break; // End of contiguous function.
                }

<<<<<<< HEAD
                startBlock = block;
=======
                startBlock      = block;
>>>>>>> 1ec71635b (sync with main branch)
                startBlockIndex = i;
            }

            if (startBlockIndex == 0 && endBlockIndex == blocks.Count - 1)
            {
                return blocks.ToArray(); // Nothing to do here.
            }
<<<<<<< HEAD

=======
            
>>>>>>> 1ec71635b (sync with main branch)
            // Mark branches whose target is outside of the contiguous region as an exit block.
            for (int i = startBlockIndex; i <= endBlockIndex; i++)
            {
                Block block = blocks[i];

                if (block.Branch != null && (block.Branch.Address > endBlock.EndAddress || block.Branch.EndAddress < startBlock.Address))
                {
                    block.Branch.Exit = true;
                }
            }

<<<<<<< HEAD
            var newBlocks = new List<Block>(blocks.Count);
=======
           var newBlocks = new List<Block>(blocks.Count);
>>>>>>> 1ec71635b (sync with main branch)

            // Finally, rebuild decoded block list, ignoring blocks outside the contiguous range.
            for (int i = 0; i < blocks.Count; i++)
            {
                Block block = blocks[i];

                if (block.Exit || (i >= startBlockIndex && i <= endBlockIndex))
                {
                    newBlocks.Add(block);
                }
            }

            return newBlocks.ToArray();
        }
    }
}
