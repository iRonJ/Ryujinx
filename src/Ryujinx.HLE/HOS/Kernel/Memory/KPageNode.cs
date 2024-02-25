namespace Ryujinx.HLE.HOS.Kernel.Memory
{
    struct KPageNode
    {
        public ulong Address;
        public ulong PagesCount;

        public KPageNode(ulong address, ulong pagesCount)
        {
<<<<<<< HEAD
            Address = address;
            PagesCount = pagesCount;
        }
    }
}
=======
            Address    = address;
            PagesCount = pagesCount;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
