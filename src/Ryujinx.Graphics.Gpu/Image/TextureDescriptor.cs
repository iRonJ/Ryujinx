using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Ryujinx.Graphics.Gpu.Image
{
    /// <summary>
    /// Maxwell texture descriptor, as stored on the GPU texture pool memory region.
    /// </summary>
    struct TextureDescriptor : ITextureDescriptor, IEquatable<TextureDescriptor>
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public uint Word0;
        public uint Word1;
        public uint Word2;
        public uint Word3;
        public uint Word4;
        public uint Word5;
        public uint Word6;
        public uint Word7;
#pragma warning restore CS0649

        /// <summary>
        /// Unpacks Maxwell texture format integer.
        /// </summary>
        /// <returns>The texture format integer</returns>
<<<<<<< HEAD
        public readonly uint UnpackFormat()
=======
        public uint UnpackFormat()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Word0 & 0x8007ffff;
        }

        /// <summary>
        /// Unpacks the swizzle component for the texture red color channel.
        /// </summary>
        /// <returns>The swizzle component</returns>
<<<<<<< HEAD
        public readonly TextureComponent UnpackSwizzleR()
        {
            return (TextureComponent)((Word0 >> 19) & 7);
=======
        public TextureComponent UnpackSwizzleR()
        {
            return(TextureComponent)((Word0 >> 19) & 7);
>>>>>>> 1ec71635b (sync with main branch)
        }

        /// <summary>
        /// Unpacks the swizzle component for the texture green color channel.
        /// </summary>
        /// <returns>The swizzle component</returns>
<<<<<<< HEAD
        public readonly TextureComponent UnpackSwizzleG()
        {
            return (TextureComponent)((Word0 >> 22) & 7);
=======
        public TextureComponent UnpackSwizzleG()
        {
            return(TextureComponent)((Word0 >> 22) & 7);
>>>>>>> 1ec71635b (sync with main branch)
        }

        /// <summary>
        /// Unpacks the swizzle component for the texture blue color channel.
        /// </summary>
        /// <returns>The swizzle component</returns>
<<<<<<< HEAD
        public readonly TextureComponent UnpackSwizzleB()
        {
            return (TextureComponent)((Word0 >> 25) & 7);
=======
        public TextureComponent UnpackSwizzleB()
        {
            return(TextureComponent)((Word0 >> 25) & 7);
>>>>>>> 1ec71635b (sync with main branch)
        }

        /// <summary>
        /// Unpacks the swizzle component for the texture alpha color channel.
        /// </summary>
        /// <returns>The swizzle component</returns>
<<<<<<< HEAD
        public readonly TextureComponent UnpackSwizzleA()
        {
            return (TextureComponent)((Word0 >> 28) & 7);
=======
        public TextureComponent UnpackSwizzleA()
        {
            return(TextureComponent)((Word0 >> 28) & 7);
>>>>>>> 1ec71635b (sync with main branch)
        }

        /// <summary>
        /// Unpacks the 40-bits texture GPU virtual address.
        /// </summary>
        /// <returns>The GPU virtual address</returns>
<<<<<<< HEAD
        public readonly ulong UnpackAddress()
=======
        public ulong UnpackAddress()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Word1 | ((ulong)(Word2 & 0xffff) << 32);
        }

        /// <summary>
        /// Unpacks texture descriptor type for this texture descriptor.
        /// This defines the texture layout, among other things.
        /// </summary>
        /// <returns>The texture descriptor type</returns>
<<<<<<< HEAD
        public readonly TextureDescriptorType UnpackTextureDescriptorType()
=======
        public TextureDescriptorType UnpackTextureDescriptorType()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (TextureDescriptorType)((Word2 >> 21) & 7);
        }

        /// <summary>
        /// Unpacks the texture stride (bytes per line) for linear textures only.
        /// Always 32-bytes aligned.
        /// </summary>
        /// <returns>The linear texture stride</returns>
<<<<<<< HEAD
        public readonly int UnpackStride()
=======
        public int UnpackStride()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)(Word3 & 0xffff) << 5;
        }

        /// <summary>
        /// Unpacks the GOB block size in X (width) for block linear textures.
        /// Must be always 1, ignored by the GPU.
        /// </summary>
        /// <returns>THe GOB block X size</returns>
<<<<<<< HEAD
        public readonly int UnpackGobBlocksInX()
=======
        public int UnpackGobBlocksInX()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 1 << (int)(Word3 & 7);
        }

        /// <summary>
        /// Unpacks the GOB block size in Y (height) for block linear textures.
        /// Must be always a power of 2, with a maximum value of 32.
        /// </summary>
        /// <returns>THe GOB block Y size</returns>
<<<<<<< HEAD
        public readonly int UnpackGobBlocksInY()
=======
        public int UnpackGobBlocksInY()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 1 << (int)((Word3 >> 3) & 7);
        }

        /// <summary>
        /// Unpacks the GOB block size in Z (depth) for block linear textures.
        /// Must be always a power of 2, with a maximum value of 32.
        /// Must be 1 for any texture target other than 3D textures.
        /// </summary>
        /// <returns>The GOB block Z size</returns>
<<<<<<< HEAD
        public readonly int UnpackGobBlocksInZ()
=======
        public int UnpackGobBlocksInZ()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 1 << (int)((Word3 >> 6) & 7);
        }

        /// <summary>
        /// Number of GOB blocks per tile in the X direction.
        /// This is only used for sparse textures, should be 1 otherwise.
        /// </summary>
        /// <returns>The number of GOB blocks per tile</returns>
<<<<<<< HEAD
        public readonly int UnpackGobBlocksInTileX()
=======
        public int UnpackGobBlocksInTileX()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 1 << (int)((Word3 >> 10) & 7);
        }

        /// <summary>
        /// Unpacks the number of mipmap levels of the texture.
        /// </summary>
        /// <returns>The number of mipmap levels</returns>
<<<<<<< HEAD
        public readonly int UnpackLevels()
=======
        public int UnpackLevels()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)(Word3 >> 28) + 1;
        }

        /// <summary>
        /// Unpack the base level texture width size.
        /// </summary>
        /// <returns>The texture width</returns>
<<<<<<< HEAD
        public readonly int UnpackWidth()
=======
        public int UnpackWidth()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)(Word4 & 0xffff) + 1;
        }

        /// <summary>
        /// Unpack the width of a buffer texture.
        /// </summary>
        /// <returns>The texture width</returns>
<<<<<<< HEAD
        public readonly int UnpackBufferTextureWidth()
=======
        public int UnpackBufferTextureWidth()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)((Word4 & 0xffff) | (Word3 << 16)) + 1;
        }

        /// <summary>
        /// Unpacks the texture sRGB format flag.
        /// </summary>
        /// <returns>True if the texture is sRGB, false otherwise</returns>
<<<<<<< HEAD
        public readonly bool UnpackSrgb()
=======
        public bool UnpackSrgb()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (Word4 & (1 << 22)) != 0;
        }

        /// <summary>
        /// Unpacks the texture target.
        /// </summary>
        /// <returns>The texture target</returns>
<<<<<<< HEAD
        public readonly TextureTarget UnpackTextureTarget()
=======
        public TextureTarget UnpackTextureTarget()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (TextureTarget)((Word4 >> 23) & 0xf);
        }

        /// <summary>
        /// Unpack the base level texture height size, or array layers for 1D array textures.
        /// Should be ignored for 1D or buffer textures.
        /// </summary>
        /// <returns>The texture height or layers count</returns>
<<<<<<< HEAD
        public readonly int UnpackHeight()
=======
        public int UnpackHeight()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)(Word5 & 0xffff) + 1;
        }

        /// <summary>
        /// Unpack the base level texture depth size, number of array layers or cubemap faces.
        /// The meaning of this value depends on the texture target.
        /// </summary>
        /// <returns>The texture depth, layer or faces count</returns>
<<<<<<< HEAD
        public readonly int UnpackDepth()
=======
        public int UnpackDepth()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)((Word5 >> 16) & 0x3fff) + 1;
        }

        /// <summary>
        /// Unpacks the texture coordinates normalized flag.
        /// When this is true, texture coordinates are expected to be in the [0, 1] range on the shader.
        /// When this is false, texture coordinates are expected to be in the [0, W], [0, H] and [0, D] range.
        /// It must be set to false (by the guest driver) for rectangle textures.
        /// </summary>
        /// <returns>The texture coordinates normalized flag</returns>
<<<<<<< HEAD
        public readonly bool UnpackTextureCoordNormalized()
=======
        public bool UnpackTextureCoordNormalized()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (Word5 & (1 << 31)) != 0;
        }

        /// <summary>
        /// Unpacks the base mipmap level of the texture.
        /// </summary>
        /// <returns>The base mipmap level of the texture</returns>
<<<<<<< HEAD
        public readonly int UnpackBaseLevel()
=======
        public int UnpackBaseLevel()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)(Word7 & 0xf);
        }

        /// <summary>
        /// Unpacks the maximum mipmap level (inclusive) of the texture.
        /// Usually equal to Levels minus 1.
        /// </summary>
        /// <returns>The maximum mipmap level (inclusive) of the texture</returns>
<<<<<<< HEAD
        public readonly int UnpackMaxLevelInclusive()
=======
        public int UnpackMaxLevelInclusive()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)((Word7 >> 4) & 0xf);
        }

        /// <summary>
        /// Unpacks the multisampled texture samples count in each direction.
        /// Must be ignored for non-multisample textures.
        /// </summary>
        /// <returns>The multisample counts enum</returns>
<<<<<<< HEAD
        public readonly TextureMsaaMode UnpackTextureMsaaMode()
=======
        public TextureMsaaMode UnpackTextureMsaaMode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (TextureMsaaMode)((Word7 >> 8) & 0xf);
        }

        /// <summary>
        /// Check if two descriptors are equal.
        /// </summary>
        /// <param name="other">The descriptor to compare against</param>
        /// <returns>True if they are equal, false otherwise</returns>
        public bool Equals(ref TextureDescriptor other)
        {
            return Unsafe.As<TextureDescriptor, Vector256<byte>>(ref this).Equals(Unsafe.As<TextureDescriptor, Vector256<byte>>(ref other));
        }

        /// <summary>
        /// Check if two descriptors are equal.
        /// </summary>
        /// <param name="other">The descriptor to compare against</param>
        /// <returns>True if they are equal, false otherwise</returns>
        public bool Equals(TextureDescriptor other)
        {
            return Equals(ref other);
        }

        /// <summary>
        /// Gets a hash code for this descriptor.
        /// </summary>
        /// <returns>The hash code for this descriptor.</returns>
        public override int GetHashCode()
        {
            return Unsafe.As<TextureDescriptor, Vector256<byte>>(ref this).GetHashCode();
        }
<<<<<<< HEAD

        public override bool Equals(object obj)
        {
            return obj is TextureDescriptor descriptor && Equals(descriptor);
        }
=======
>>>>>>> 1ec71635b (sync with main branch)
    }
}
