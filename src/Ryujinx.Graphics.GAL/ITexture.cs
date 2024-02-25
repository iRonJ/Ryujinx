using Ryujinx.Common.Memory;
<<<<<<< HEAD
=======
using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.GAL
{
    public interface ITexture
    {
        int Width { get; }
        int Height { get; }
<<<<<<< HEAD
=======
        float ScaleFactor { get; }
>>>>>>> 1ec71635b (sync with main branch)

        void CopyTo(ITexture destination, int firstLayer, int firstLevel);
        void CopyTo(ITexture destination, int srcLayer, int dstLayer, int srcLevel, int dstLevel);
        void CopyTo(ITexture destination, Extents2D srcRegion, Extents2D dstRegion, bool linearFilter);
        void CopyTo(BufferRange range, int layer, int level, int stride);

        ITexture CreateView(TextureCreateInfo info, int firstLayer, int firstLevel);

        PinnedSpan<byte> GetData();
        PinnedSpan<byte> GetData(int layer, int level);

        void SetData(SpanOrArray<byte> data);
        void SetData(SpanOrArray<byte> data, int layer, int level);
        void SetData(SpanOrArray<byte> data, int layer, int level, Rectangle<int> region);
        void SetStorage(BufferRange buffer);
        void Release();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
