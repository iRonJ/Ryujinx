<<<<<<< HEAD
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.Gpu.Image;
using Ryujinx.Graphics.Shader;
using Ryujinx.Memory.Range;
=======
﻿using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.Gpu.Image;
using Ryujinx.Graphics.Shader;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Gpu.Memory
{
    /// <summary>
    /// A buffer binding to apply to a buffer texture.
    /// </summary>
    readonly struct BufferTextureBinding
    {
        /// <summary>
        /// Shader stage accessing the texture.
        /// </summary>
        public ShaderStage Stage { get; }

        /// <summary>
        /// The buffer texture.
        /// </summary>
        public ITexture Texture { get; }

        /// <summary>
<<<<<<< HEAD
        /// Physical ranges of memory where the buffer texture data is located.
        /// </summary>
        public MultiRange Range { get; }
=======
        /// The base address of the buffer binding.
        /// </summary>
        public ulong Address { get; }

        /// <summary>
        /// The size of the buffer binding in bytes.
        /// </summary>
        public ulong Size { get; }
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// The image or sampler binding info for the buffer texture.
        /// </summary>
        public TextureBindingInfo BindingInfo { get; }

        /// <summary>
        /// The image format for the binding.
        /// </summary>
        public Format Format { get; }

        /// <summary>
        /// Whether the binding is for an image or a sampler.
        /// </summary>
        public bool IsImage { get; }

        /// <summary>
        /// Create a new buffer texture binding.
        /// </summary>
        /// <param name="stage">Shader stage accessing the texture</param>
        /// <param name="texture">Buffer texture</param>
<<<<<<< HEAD
        /// <param name="range">Physical ranges of memory where the buffer texture data is located</param>
=======
        /// <param name="address">Base address</param>
        /// <param name="size">Size in bytes</param>
>>>>>>> 1ec71635b (sync with main branch)
        /// <param name="bindingInfo">Binding info</param>
        /// <param name="format">Binding format</param>
        /// <param name="isImage">Whether the binding is for an image or a sampler</param>
        public BufferTextureBinding(
            ShaderStage stage,
            ITexture texture,
<<<<<<< HEAD
            MultiRange range,
=======
            ulong address,
            ulong size,
>>>>>>> 1ec71635b (sync with main branch)
            TextureBindingInfo bindingInfo,
            Format format,
            bool isImage)
        {
            Stage = stage;
            Texture = texture;
<<<<<<< HEAD
            Range = range;
=======
            Address = address;
            Size = size;
>>>>>>> 1ec71635b (sync with main branch)
            BindingInfo = bindingInfo;
            Format = format;
            IsImage = isImage;
        }
    }
}
