using Ryujinx.Graphics.OpenGL.Image;
using System;

namespace Ryujinx.Graphics.OpenGL.Effects
{
<<<<<<< HEAD
    internal interface IPostProcessingEffect : IDisposable
=======
    internal interface IPostProcessingEffect :  IDisposable
>>>>>>> 1ec71635b (sync with main branch)
    {
        const int LocalGroupSize = 64;
        TextureView Run(TextureView view, int width, int height);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
