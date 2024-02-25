namespace Ryujinx.Graphics.Shader
{
<<<<<<< HEAD
    public readonly struct BufferDescriptor
=======
    public struct BufferDescriptor
>>>>>>> 1ec71635b (sync with main branch)
    {
        // New fields should be added to the end of the struct to keep disk shader cache compatibility.

        public readonly int Binding;
        public readonly byte Slot;
        public readonly byte SbCbSlot;
        public readonly ushort SbCbOffset;
<<<<<<< HEAD
        public readonly BufferUsageFlags Flags;
=======
        public BufferUsageFlags Flags;
>>>>>>> 1ec71635b (sync with main branch)

        public BufferDescriptor(int binding, int slot)
        {
            Binding = binding;
            Slot = (byte)slot;
            SbCbSlot = 0;
            SbCbOffset = 0;
<<<<<<< HEAD
            Flags = BufferUsageFlags.None;
        }

        public BufferDescriptor(int binding, int slot, int sbCbSlot, int sbCbOffset, BufferUsageFlags flags)
=======

            Flags = BufferUsageFlags.None;
        }

        public BufferDescriptor(int binding, int slot, int sbCbSlot, int sbCbOffset)
>>>>>>> 1ec71635b (sync with main branch)
        {
            Binding = binding;
            Slot = (byte)slot;
            SbCbSlot = (byte)sbCbSlot;
            SbCbOffset = (ushort)sbCbOffset;
<<<<<<< HEAD
            Flags = flags;
        }
    }
}
=======

            Flags = BufferUsageFlags.None;
        }

        public BufferDescriptor SetFlag(BufferUsageFlags flag)
        {
            Flags |= flag;

            return this;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
