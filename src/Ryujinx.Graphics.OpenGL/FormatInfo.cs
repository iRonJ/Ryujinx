using OpenTK.Graphics.OpenGL;

namespace Ryujinx.Graphics.OpenGL
{
    readonly struct FormatInfo
    {
<<<<<<< HEAD
        public int Components { get; }
        public bool Normalized { get; }
        public bool Scaled { get; }

        public PixelInternalFormat PixelInternalFormat { get; }
        public PixelFormat PixelFormat { get; }
        public PixelType PixelType { get; }
=======
        public int  Components { get; }
        public bool Normalized { get; }
        public bool Scaled     { get; }

        public PixelInternalFormat PixelInternalFormat { get; }
        public PixelFormat         PixelFormat         { get; }
        public PixelType           PixelType           { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public bool IsCompressed { get; }

        public FormatInfo(
<<<<<<< HEAD
            int components,
            bool normalized,
            bool scaled,
            All pixelInternalFormat,
            PixelFormat pixelFormat,
            PixelType pixelType)
        {
            Components = components;
            Normalized = normalized;
            Scaled = scaled;
            PixelInternalFormat = (PixelInternalFormat)pixelInternalFormat;
            PixelFormat = pixelFormat;
            PixelType = pixelType;
            IsCompressed = false;
=======
            int         components,
            bool        normalized,
            bool        scaled,
            All         pixelInternalFormat,
            PixelFormat pixelFormat,
            PixelType   pixelType)
        {
            Components          = components;
            Normalized          = normalized;
            Scaled              = scaled;
            PixelInternalFormat = (PixelInternalFormat)pixelInternalFormat;
            PixelFormat         = pixelFormat;
            PixelType           = pixelType;
            IsCompressed        = false;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public FormatInfo(int components, bool normalized, bool scaled, All pixelFormat)
        {
<<<<<<< HEAD
            Components = components;
            Normalized = normalized;
            Scaled = scaled;
            PixelInternalFormat = 0;
            PixelFormat = (PixelFormat)pixelFormat;
            PixelType = 0;
            IsCompressed = true;
=======
            Components          = components;
            Normalized          = normalized;
            Scaled              = scaled;
            PixelInternalFormat = 0;
            PixelFormat         = (PixelFormat)pixelFormat;
            PixelType           = 0;
            IsCompressed        = true;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
