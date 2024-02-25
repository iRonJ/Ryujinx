<<<<<<< HEAD
namespace Ryujinx.Graphics.Vulkan
=======
﻿namespace Ryujinx.Graphics.Vulkan
>>>>>>> 1ec71635b (sync with main branch)
{
    static class VulkanConfiguration
    {
        public const bool UseFastBufferUpdates = true;
<<<<<<< HEAD
        public const bool UseUnsafeBlit = true;
        public const bool UsePushDescriptors = true;
=======
        public const bool UseSlowSafeBlitOnAmd = true;
        public const bool UsePushDescriptors = false;
>>>>>>> 1ec71635b (sync with main branch)

        public const bool ForceD24S8Unsupported = false;
        public const bool ForceRGB16IntFloatUnsupported = false;
    }
}
