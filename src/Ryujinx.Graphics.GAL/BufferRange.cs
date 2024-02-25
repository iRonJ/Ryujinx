namespace Ryujinx.Graphics.GAL
{
    public readonly struct BufferRange
    {
<<<<<<< HEAD
        private static readonly BufferRange _empty = new(BufferHandle.Null, 0, 0);
=======
        private static readonly BufferRange _empty = new BufferRange(BufferHandle.Null, 0, 0);
>>>>>>> 1ec71635b (sync with main branch)

        public static BufferRange Empty => _empty;

        public BufferHandle Handle { get; }

        public int Offset { get; }
<<<<<<< HEAD
        public int Size { get; }
        public bool Write { get; }

        public BufferRange(BufferHandle handle, int offset, int size, bool write = false)
        {
            Handle = handle;
            Offset = offset;
            Size = size;
            Write = write;
        }
    }
}
=======
        public int Size   { get; }

        public BufferRange(BufferHandle handle, int offset, int size)
        {
            Handle = handle;
            Offset = offset;
            Size   = size;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
