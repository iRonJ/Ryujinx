using Ryujinx.Horizon.Common;
using System.Collections;
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Kernel.Memory
{
    class KPageList : IEnumerable<KPageNode>
    {
        public LinkedList<KPageNode> Nodes { get; }

        public KPageList()
        {
            Nodes = new LinkedList<KPageNode>();
        }

        public Result AddRange(ulong address, ulong pagesCount)
        {
            if (pagesCount != 0)
            {
                if (Nodes.Last != null)
                {
                    KPageNode lastNode = Nodes.Last.Value;

                    if (lastNode.Address + lastNode.PagesCount * KPageTableBase.PageSize == address)
                    {
<<<<<<< HEAD
                        address = lastNode.Address;
=======
                        address     = lastNode.Address;
>>>>>>> 1ec71635b (sync with main branch)
                        pagesCount += lastNode.PagesCount;

                        Nodes.RemoveLast();
                    }
                }

                Nodes.AddLast(new KPageNode(address, pagesCount));
            }

            return Result.Success;
        }

        public ulong GetPagesCount()
        {
            ulong sum = 0;

            foreach (KPageNode node in Nodes)
            {
                sum += node.PagesCount;
            }

            return sum;
        }

        public bool IsEqual(KPageList other)
        {
<<<<<<< HEAD
            LinkedListNode<KPageNode> thisNode = Nodes.First;
=======
            LinkedListNode<KPageNode> thisNode  = Nodes.First;
>>>>>>> 1ec71635b (sync with main branch)
            LinkedListNode<KPageNode> otherNode = other.Nodes.First;

            while (thisNode != null && otherNode != null)
            {
<<<<<<< HEAD
                if (thisNode.Value.Address != otherNode.Value.Address ||
=======
                if (thisNode.Value.Address    != otherNode.Value.Address ||
>>>>>>> 1ec71635b (sync with main branch)
                    thisNode.Value.PagesCount != otherNode.Value.PagesCount)
                {
                    return false;
                }

<<<<<<< HEAD
                thisNode = thisNode.Next;
=======
                thisNode  = thisNode.Next;
>>>>>>> 1ec71635b (sync with main branch)
                otherNode = otherNode.Next;
            }

            return thisNode == null && otherNode == null;
        }

        public void IncrementPagesReferenceCount(KMemoryManager manager)
        {
            foreach (var node in this)
            {
                manager.IncrementPagesReferenceCount(node.Address, node.PagesCount);
            }
        }

        public void DecrementPagesReferenceCount(KMemoryManager manager)
        {
            foreach (var node in this)
            {
                manager.DecrementPagesReferenceCount(node.Address, node.PagesCount);
            }
        }

        public IEnumerator<KPageNode> GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
