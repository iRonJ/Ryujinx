<<<<<<< HEAD
using Ryujinx.Graphics.GAL;
=======
﻿using Ryujinx.Graphics.GAL;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.OpenGL.Image;
using System;
using System.Collections.Generic;

namespace Ryujinx.Graphics.OpenGL
{
    class DisposedTexture
    {
        public TextureCreateInfo Info;
        public TextureView View;
<<<<<<< HEAD
=======
        public float ScaleFactor;
>>>>>>> 1ec71635b (sync with main branch)
        public int RemainingFrames;
    }

    /// <summary>
    /// A structure for pooling resources that can be reused without recreation, such as textures.
    /// </summary>
    class ResourcePool : IDisposable
    {
        private const int DisposedLiveFrames = 2;

<<<<<<< HEAD
        private readonly object _lock = new();
        private readonly Dictionary<TextureCreateInfo, List<DisposedTexture>> _textures = new();
=======
        private readonly object _lock = new object();
        private readonly Dictionary<TextureCreateInfo, List<DisposedTexture>> _textures = new Dictionary<TextureCreateInfo, List<DisposedTexture>>();
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Add a texture that is not being used anymore to the resource pool to be used later.
        /// Both the texture's view and storage should be completely unused.
        /// </summary>
        /// <param name="view">The texture's view</param>
        public void AddTexture(TextureView view)
        {
            lock (_lock)
            {
<<<<<<< HEAD
                if (!_textures.TryGetValue(view.Info, out List<DisposedTexture> list))
=======
                List<DisposedTexture> list;
                if (!_textures.TryGetValue(view.Info, out list))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    list = new List<DisposedTexture>();
                    _textures.Add(view.Info, list);
                }

                list.Add(new DisposedTexture()
                {
                    Info = view.Info,
                    View = view,
<<<<<<< HEAD
                    RemainingFrames = DisposedLiveFrames,
=======
                    ScaleFactor = view.ScaleFactor,
                    RemainingFrames = DisposedLiveFrames
>>>>>>> 1ec71635b (sync with main branch)
                });
            }
        }

        /// <summary>
        /// Attempt to obtain a texture from the resource cache with the desired parameters.
        /// </summary>
        /// <param name="info">The creation info for the desired texture</param>
<<<<<<< HEAD
        /// <returns>A TextureView with the description specified, or null if one was not found.</returns>
        public TextureView GetTextureOrNull(TextureCreateInfo info)
        {
            lock (_lock)
            {
                if (!_textures.TryGetValue(info, out List<DisposedTexture> list))
=======
        /// <param name="scaleFactor">The scale factor for the desired texture</param>
        /// <returns>A TextureView with the description specified, or null if one was not found.</returns>
        public TextureView GetTextureOrNull(TextureCreateInfo info, float scaleFactor)
        {
            lock (_lock)
            {
                List<DisposedTexture> list;
                if (!_textures.TryGetValue(info, out list))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    return null;
                }

                foreach (DisposedTexture texture in list)
                {
<<<<<<< HEAD
                    list.Remove(texture);
                    return texture.View;
=======
                    if (scaleFactor == texture.ScaleFactor)
                    {
                        list.Remove(texture);
                        return texture.View;
                    }
>>>>>>> 1ec71635b (sync with main branch)
                }

                return null;
            }
        }

        /// <summary>
        /// Update the pool, removing any resources that have expired.
        /// </summary>
        public void Tick()
        {
            lock (_lock)
            {
                foreach (List<DisposedTexture> list in _textures.Values)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        DisposedTexture tex = list[i];

                        if (--tex.RemainingFrames < 0)
                        {
                            tex.View.Dispose();
                            list.RemoveAt(i--);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Disposes the resource pool.
        /// </summary>
        public void Dispose()
        {
            lock (_lock)
            {
                foreach (List<DisposedTexture> list in _textures.Values)
                {
                    foreach (DisposedTexture texture in list)
                    {
                        texture.View.Dispose();
                    }
                }
                _textures.Clear();
            }
        }
    }
}
