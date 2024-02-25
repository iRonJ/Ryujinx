namespace Ryujinx.Graphics.Shader
{
<<<<<<< HEAD
    public readonly struct TextureDescriptor
=======
    public struct TextureDescriptor
>>>>>>> 1ec71635b (sync with main branch)
    {
        // New fields should be added to the end of the struct to keep disk shader cache compatibility.

        public readonly int Binding;

        public readonly SamplerType Type;
        public readonly TextureFormat Format;

        public readonly int CbufSlot;
        public readonly int HandleIndex;

<<<<<<< HEAD
        public readonly TextureUsageFlags Flags;

        public TextureDescriptor(int binding, SamplerType type, TextureFormat format, int cbufSlot, int handleIndex, TextureUsageFlags flags)
        {
            Binding = binding;
            Type = type;
            Format = format;
            CbufSlot = cbufSlot;
            HandleIndex = handleIndex;
            Flags = flags;
        }
    }
}
=======
        public TextureUsageFlags Flags;

        public TextureDescriptor(int binding, SamplerType type, TextureFormat format, int cbufSlot, int handleIndex)
        {
            Binding     = binding;
            Type        = type;
            Format      = format;
            CbufSlot    = cbufSlot;
            HandleIndex = handleIndex;
            Flags       = TextureUsageFlags.None;
        }

        public TextureDescriptor SetFlag(TextureUsageFlags flag)
        {
            Flags |= flag;

            return this;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
