namespace Ryujinx.Graphics.GAL
{
    public readonly struct BlendDescriptor
    {
        public bool Enable { get; }

<<<<<<< HEAD
        public ColorF BlendConstant { get; }
        public BlendOp ColorOp { get; }
        public BlendFactor ColorSrcFactor { get; }
        public BlendFactor ColorDstFactor { get; }
        public BlendOp AlphaOp { get; }
=======
        public ColorF      BlendConstant  { get; }
        public BlendOp     ColorOp        { get; }
        public BlendFactor ColorSrcFactor { get; }
        public BlendFactor ColorDstFactor { get; }
        public BlendOp     AlphaOp        { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public BlendFactor AlphaSrcFactor { get; }
        public BlendFactor AlphaDstFactor { get; }

        public BlendDescriptor(
<<<<<<< HEAD
            bool enable,
            ColorF blendConstant,
            BlendOp colorOp,
            BlendFactor colorSrcFactor,
            BlendFactor colorDstFactor,
            BlendOp alphaOp,
            BlendFactor alphaSrcFactor,
            BlendFactor alphaDstFactor)
        {
            Enable = enable;
            BlendConstant = blendConstant;
            ColorOp = colorOp;
            ColorSrcFactor = colorSrcFactor;
            ColorDstFactor = colorDstFactor;
            AlphaOp = alphaOp;
=======
            bool        enable,
            ColorF      blendConstant,
            BlendOp     colorOp,
            BlendFactor colorSrcFactor,
            BlendFactor colorDstFactor,
            BlendOp     alphaOp,
            BlendFactor alphaSrcFactor,
            BlendFactor alphaDstFactor)
        {
            Enable         = enable;
            BlendConstant  = blendConstant;
            ColorOp        = colorOp;
            ColorSrcFactor = colorSrcFactor;
            ColorDstFactor = colorDstFactor;
            AlphaOp        = alphaOp;
>>>>>>> 1ec71635b (sync with main branch)
            AlphaSrcFactor = alphaSrcFactor;
            AlphaDstFactor = alphaDstFactor;
        }
    }
}
