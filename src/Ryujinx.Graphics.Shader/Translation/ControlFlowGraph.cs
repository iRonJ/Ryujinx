using Ryujinx.Graphics.Shader.IntermediateRepresentation;
using System.Collections.Generic;

namespace Ryujinx.Graphics.Shader.Translation
{
    class ControlFlowGraph
    {
        public BasicBlock[] Blocks { get; }
        public BasicBlock[] PostOrderBlocks { get; }
        public int[] PostOrderMap { get; }

        public ControlFlowGraph(BasicBlock[] blocks)
        {
            Blocks = blocks;

<<<<<<< HEAD
            HashSet<BasicBlock> visited = new();

            Stack<BasicBlock> blockStack = new();

            List<BasicBlock> postOrderBlocks = new(blocks.Length);
=======
            HashSet<BasicBlock> visited = new HashSet<BasicBlock>();

            Stack<BasicBlock> blockStack = new Stack<BasicBlock>();

            List<BasicBlock> postOrderBlocks = new List<BasicBlock>(blocks.Length);
>>>>>>> 1ec71635b (sync with main branch)

            PostOrderMap = new int[blocks.Length];

            visited.Add(blocks[0]);

            blockStack.Push(blocks[0]);

            while (blockStack.TryPop(out BasicBlock block))
            {
                if (block.Next != null && visited.Add(block.Next))
                {
                    blockStack.Push(block);
                    blockStack.Push(block.Next);
                }
                else if (block.Branch != null && visited.Add(block.Branch))
                {
                    blockStack.Push(block);
                    blockStack.Push(block.Branch);
                }
                else
                {
                    PostOrderMap[block.Index] = postOrderBlocks.Count;

                    postOrderBlocks.Add(block);
                }
            }

            PostOrderBlocks = postOrderBlocks.ToArray();
        }

        public static ControlFlowGraph Create(Operation[] operations)
        {
<<<<<<< HEAD
            Dictionary<Operand, BasicBlock> labels = new();

            List<BasicBlock> blocks = new();
=======
            Dictionary<Operand, BasicBlock> labels = new Dictionary<Operand, BasicBlock>();

            List<BasicBlock> blocks = new List<BasicBlock>();
>>>>>>> 1ec71635b (sync with main branch)

            BasicBlock currentBlock = null;

            void NextBlock(BasicBlock nextBlock)
            {
                if (currentBlock != null && !EndsWithUnconditionalInst(currentBlock.GetLastOp()))
                {
                    currentBlock.Next = nextBlock;
                }

                currentBlock = nextBlock;
            }

            void NewNextBlock()
            {
<<<<<<< HEAD
                BasicBlock block = new(blocks.Count);
=======
                BasicBlock block = new BasicBlock(blocks.Count);
>>>>>>> 1ec71635b (sync with main branch)

                blocks.Add(block);

                NextBlock(block);
            }

            bool needsNewBlock = true;

            for (int index = 0; index < operations.Length; index++)
            {
                Operation operation = operations[index];

                if (operation.Inst == Instruction.MarkLabel)
                {
                    Operand label = operation.Dest;

                    if (labels.TryGetValue(label, out BasicBlock nextBlock))
                    {
                        nextBlock.Index = blocks.Count;

                        blocks.Add(nextBlock);

                        NextBlock(nextBlock);
                    }
                    else
                    {
                        NewNextBlock();

                        labels.Add(label, currentBlock);
                    }
                }
                else
                {
                    if (needsNewBlock)
                    {
                        NewNextBlock();
                    }

                    currentBlock.Operations.AddLast(operation);
                }

<<<<<<< HEAD
                needsNewBlock = operation.Inst == Instruction.Branch ||
=======
                needsNewBlock = operation.Inst == Instruction.Branch       ||
>>>>>>> 1ec71635b (sync with main branch)
                                operation.Inst == Instruction.BranchIfTrue ||
                                operation.Inst == Instruction.BranchIfFalse;

                if (needsNewBlock)
                {
                    Operand label = operation.Dest;

                    if (!labels.TryGetValue(label, out BasicBlock branchBlock))
                    {
                        branchBlock = new BasicBlock();

                        labels.Add(label, branchBlock);
                    }

                    currentBlock.Branch = branchBlock;
                }
            }

            // Remove unreachable blocks.
            bool hasUnreachable;

            do
            {
                hasUnreachable = false;

                for (int blkIndex = 1; blkIndex < blocks.Count; blkIndex++)
                {
                    BasicBlock block = blocks[blkIndex];

                    if (block.Predecessors.Count == 0)
                    {
                        block.Next = null;
                        block.Branch = null;
                        blocks.RemoveAt(blkIndex--);
                        hasUnreachable = true;
                    }
                    else
                    {
                        block.Index = blkIndex;
                    }
                }
            } while (hasUnreachable);

            return new ControlFlowGraph(blocks.ToArray());
        }

        private static bool EndsWithUnconditionalInst(INode node)
        {
            if (node is Operation operation)
            {
                switch (operation.Inst)
                {
                    case Instruction.Branch:
                    case Instruction.Discard:
                    case Instruction.Return:
                        return true;
                }
            }

            return false;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
