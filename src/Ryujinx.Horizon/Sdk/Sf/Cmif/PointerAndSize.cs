namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
<<<<<<< HEAD
    readonly struct PointerAndSize
=======
    struct PointerAndSize
>>>>>>> 1ec71635b (sync with main branch)
    {
        public static PointerAndSize Empty => new(0UL, 0UL);

        public ulong Address { get; }
        public ulong Size { get; }
        public bool IsEmpty => Size == 0UL;

        public PointerAndSize(ulong address, ulong size)
        {
            Address = address;
<<<<<<< HEAD
            Size = size;
=======
            Size    = size;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
