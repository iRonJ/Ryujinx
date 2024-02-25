<<<<<<< HEAD
namespace Ryujinx.Graphics.Vulkan
=======
﻿namespace Ryujinx.Graphics.Vulkan
>>>>>>> 1ec71635b (sync with main branch)
{
    static class Constants
    {
        public const int MaxVertexAttributes = 32;
        public const int MaxVertexBuffers = 32;
        public const int MaxTransformFeedbackBuffers = 4;
        public const int MaxRenderTargets = 8;
        public const int MaxViewports = 16;
        public const int MaxShaderStages = 5;
        public const int MaxUniformBuffersPerStage = 18;
        public const int MaxStorageBuffersPerStage = 16;
        public const int MaxTexturesPerStage = 64;
        public const int MaxImagesPerStage = 16;
        public const int MaxUniformBufferBindings = MaxUniformBuffersPerStage * MaxShaderStages;
        public const int MaxStorageBufferBindings = MaxStorageBuffersPerStage * MaxShaderStages;
        public const int MaxTextureBindings = MaxTexturesPerStage * MaxShaderStages;
        public const int MaxImageBindings = MaxImagesPerStage * MaxShaderStages;
<<<<<<< HEAD
        public const int MaxPushDescriptorBinding = 64;

        public const ulong SparseBufferAlignment = 0x10000;
=======
>>>>>>> 1ec71635b (sync with main branch)
    }
}
