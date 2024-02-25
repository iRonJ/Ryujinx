<<<<<<< HEAD
using OpenTK.Graphics.OpenGL;
=======
﻿using OpenTK.Graphics.OpenGL;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL;

namespace Ryujinx.Graphics.OpenGL.Image
{
    class TextureBase
    {
        public int Handle { get; protected set; }

        public TextureCreateInfo Info { get; }

        public int Width => Info.Width;
        public int Height => Info.Height;
<<<<<<< HEAD
=======
        public float ScaleFactor { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public Target Target => Info.Target;
        public Format Format => Info.Format;

<<<<<<< HEAD
        public TextureBase(TextureCreateInfo info)
        {
            Info = info;
=======
        public TextureBase(TextureCreateInfo info, float scaleFactor = 1f)
        {
            Info = info;
            ScaleFactor = scaleFactor;
>>>>>>> 1ec71635b (sync with main branch)

            Handle = GL.GenTexture();
        }

        public void Bind(int unit)
        {
            Bind(Target.Convert(), unit);
        }

        protected void Bind(TextureTarget target, int unit)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + unit);
            GL.BindTexture(target, Handle);
        }

        public static void ClearBinding(int unit)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + unit);
            GL.BindTextureUnit(unit, 0);
        }
    }
}
