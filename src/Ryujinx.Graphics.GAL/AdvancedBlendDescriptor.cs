namespace Ryujinx.Graphics.GAL
{
<<<<<<< HEAD
    public readonly struct AdvancedBlendDescriptor
=======
    public struct AdvancedBlendDescriptor
>>>>>>> 1ec71635b (sync with main branch)
    {
        public AdvancedBlendOp Op { get; }
        public AdvancedBlendOverlap Overlap { get; }
        public bool SrcPreMultiplied { get; }

        public AdvancedBlendDescriptor(AdvancedBlendOp op, AdvancedBlendOverlap overlap, bool srcPreMultiplied)
        {
            Op = op;
            Overlap = overlap;
            SrcPreMultiplied = srcPreMultiplied;
        }
    }
}
