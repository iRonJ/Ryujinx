namespace Ryujinx.Graphics.GAL
{
    public readonly struct SamplerCreateInfo
    {
        public MinFilter MinFilter { get; }
        public MagFilter MagFilter { get; }

        public bool SeamlessCubemap { get; }

        public AddressMode AddressU { get; }
        public AddressMode AddressV { get; }
        public AddressMode AddressP { get; }

        public CompareMode CompareMode { get; }
<<<<<<< HEAD
        public CompareOp CompareOp { get; }

        public ColorF BorderColor { get; }

        public float MinLod { get; }
        public float MaxLod { get; }
        public float MipLodBias { get; }
        public float MaxAnisotropy { get; }

        public SamplerCreateInfo(
            MinFilter minFilter,
            MagFilter magFilter,
            bool seamlessCubemap,
=======
        public CompareOp   CompareOp   { get; }

        public ColorF BorderColor { get; }

        public float MinLod        { get; }
        public float MaxLod        { get; }
        public float MipLodBias    { get; }
        public float MaxAnisotropy { get; }

        public SamplerCreateInfo(
            MinFilter   minFilter,
            MagFilter   magFilter,
            bool        seamlessCubemap,
>>>>>>> 1ec71635b (sync with main branch)
            AddressMode addressU,
            AddressMode addressV,
            AddressMode addressP,
            CompareMode compareMode,
<<<<<<< HEAD
            CompareOp compareOp,
            ColorF borderColor,
            float minLod,
            float maxLod,
            float mipLodBias,
            float maxAnisotropy)
        {
            MinFilter = minFilter;
            MagFilter = magFilter;
            SeamlessCubemap = seamlessCubemap;
            AddressU = addressU;
            AddressV = addressV;
            AddressP = addressP;
            CompareMode = compareMode;
            CompareOp = compareOp;
            BorderColor = borderColor;
            MinLod = minLod;
            MaxLod = maxLod;
            MipLodBias = mipLodBias;
            MaxAnisotropy = maxAnisotropy;
=======
            CompareOp   compareOp,
            ColorF      borderColor,
            float       minLod,
            float       maxLod,
            float       mipLodBias,
            float       maxAnisotropy)
        {
            MinFilter       = minFilter;
            MagFilter       = magFilter;
            SeamlessCubemap = seamlessCubemap;
            AddressU        = addressU;
            AddressV        = addressV;
            AddressP        = addressP;
            CompareMode     = compareMode;
            CompareOp       = compareOp;
            BorderColor     = borderColor;
            MinLod          = minLod;
            MaxLod          = maxLod;
            MipLodBias      = mipLodBias;
            MaxAnisotropy   = maxAnisotropy;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static SamplerCreateInfo Create(MinFilter minFilter, MagFilter magFilter)
        {
            return new SamplerCreateInfo(
                minFilter,
                magFilter,
                false,
                AddressMode.ClampToEdge,
                AddressMode.ClampToEdge,
                AddressMode.ClampToEdge,
                CompareMode.None,
                CompareOp.Always,
                new ColorF(0f, 0f, 0f, 0f),
                0f,
                0f,
                0f,
                1f);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
