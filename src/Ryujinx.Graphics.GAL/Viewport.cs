namespace Ryujinx.Graphics.GAL
{
    public readonly struct Viewport
    {
        public Rectangle<float> Region { get; }

        public ViewportSwizzle SwizzleX { get; }
        public ViewportSwizzle SwizzleY { get; }
        public ViewportSwizzle SwizzleZ { get; }
        public ViewportSwizzle SwizzleW { get; }

        public float DepthNear { get; }
<<<<<<< HEAD
        public float DepthFar { get; }

        public Viewport(
            Rectangle<float> region,
            ViewportSwizzle swizzleX,
            ViewportSwizzle swizzleY,
            ViewportSwizzle swizzleZ,
            ViewportSwizzle swizzleW,
            float depthNear,
            float depthFar)
        {
            Region = region;
            SwizzleX = swizzleX;
            SwizzleY = swizzleY;
            SwizzleZ = swizzleZ;
            SwizzleW = swizzleW;
            DepthNear = depthNear;
            DepthFar = depthFar;
=======
        public float DepthFar  { get; }

        public Viewport(
            Rectangle<float> region,
            ViewportSwizzle  swizzleX,
            ViewportSwizzle  swizzleY,
            ViewportSwizzle  swizzleZ,
            ViewportSwizzle  swizzleW,
            float            depthNear,
            float            depthFar)
        {
            Region    = region;
            SwizzleX  = swizzleX;
            SwizzleY  = swizzleY;
            SwizzleZ  = swizzleZ;
            SwizzleW  = swizzleW;
            DepthNear = depthNear;
            DepthFar  = depthFar;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
