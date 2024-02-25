namespace Ryujinx.Graphics.GAL
{
    public readonly struct VertexBufferDescriptor
    {
        public BufferRange Buffer { get; }

<<<<<<< HEAD
        public int Stride { get; }
=======
        public int Stride  { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public int Divisor { get; }

        public VertexBufferDescriptor(BufferRange buffer, int stride, int divisor)
        {
<<<<<<< HEAD
            Buffer = buffer;
            Stride = stride;
=======
            Buffer  = buffer;
            Stride  = stride;
>>>>>>> 1ec71635b (sync with main branch)
            Divisor = divisor;
        }
    }
}
