using Ryujinx.Common.Logging;
using Ryujinx.Graphics.GAL;
using Silk.NET.Vulkan;
using System;
<<<<<<< HEAD
using Format = Ryujinx.Graphics.GAL.Format;
=======
>>>>>>> 1ec71635b (sync with main branch)
using VkFormat = Silk.NET.Vulkan.Format;

namespace Ryujinx.Graphics.Vulkan
{
    class FormatCapabilities
    {
<<<<<<< HEAD
        private static readonly GAL.Format[] _scaledFormats = {
            GAL.Format.R8Uscaled,
            GAL.Format.R8Sscaled,
            GAL.Format.R16Uscaled,
            GAL.Format.R16Sscaled,
            GAL.Format.R8G8Uscaled,
            GAL.Format.R8G8Sscaled,
            GAL.Format.R16G16Uscaled,
            GAL.Format.R16G16Sscaled,
            GAL.Format.R8G8B8Uscaled,
            GAL.Format.R8G8B8Sscaled,
            GAL.Format.R16G16B16Uscaled,
            GAL.Format.R16G16B16Sscaled,
            GAL.Format.R8G8B8A8Uscaled,
            GAL.Format.R8G8B8A8Sscaled,
            GAL.Format.R16G16B16A16Uscaled,
            GAL.Format.R16G16B16A16Sscaled,
            GAL.Format.R10G10B10A2Uscaled,
            GAL.Format.R10G10B10A2Sscaled,
        };

        private static readonly GAL.Format[] _intFormats = {
            GAL.Format.R8Uint,
            GAL.Format.R8Sint,
            GAL.Format.R16Uint,
            GAL.Format.R16Sint,
            GAL.Format.R8G8Uint,
            GAL.Format.R8G8Sint,
            GAL.Format.R16G16Uint,
            GAL.Format.R16G16Sint,
            GAL.Format.R8G8B8Uint,
            GAL.Format.R8G8B8Sint,
            GAL.Format.R16G16B16Uint,
            GAL.Format.R16G16B16Sint,
            GAL.Format.R8G8B8A8Uint,
            GAL.Format.R8G8B8A8Sint,
            GAL.Format.R16G16B16A16Uint,
            GAL.Format.R16G16B16A16Sint,
            GAL.Format.R10G10B10A2Uint,
            GAL.Format.R10G10B10A2Sint,
        };

=======
>>>>>>> 1ec71635b (sync with main branch)
        private readonly FormatFeatureFlags[] _bufferTable;
        private readonly FormatFeatureFlags[] _optimalTable;

        private readonly Vk _api;
        private readonly PhysicalDevice _physicalDevice;

        public FormatCapabilities(Vk api, PhysicalDevice physicalDevice)
        {
            _api = api;
            _physicalDevice = physicalDevice;

<<<<<<< HEAD
            int totalFormats = Enum.GetNames(typeof(Format)).Length;
=======
            int totalFormats = Enum.GetNames(typeof(GAL.Format)).Length;
>>>>>>> 1ec71635b (sync with main branch)

            _bufferTable = new FormatFeatureFlags[totalFormats];
            _optimalTable = new FormatFeatureFlags[totalFormats];
        }

<<<<<<< HEAD
        public bool BufferFormatsSupport(FormatFeatureFlags flags, params Format[] formats)
        {
            foreach (Format format in formats)
=======
        public bool BufferFormatsSupport(FormatFeatureFlags flags, params GAL.Format[] formats)
        {
            foreach (GAL.Format format in formats)
>>>>>>> 1ec71635b (sync with main branch)
            {
                if (!BufferFormatSupports(flags, format))
                {
                    return false;
                }
            }

            return true;
        }

<<<<<<< HEAD
        public bool OptimalFormatsSupport(FormatFeatureFlags flags, params Format[] formats)
        {
            foreach (Format format in formats)
=======
        public bool OptimalFormatsSupport(FormatFeatureFlags flags, params GAL.Format[] formats)
        {
            foreach (GAL.Format format in formats)
>>>>>>> 1ec71635b (sync with main branch)
            {
                if (!OptimalFormatSupports(flags, format))
                {
                    return false;
                }
            }

            return true;
        }

<<<<<<< HEAD
        public bool BufferFormatSupports(FormatFeatureFlags flags, Format format)
=======
        public bool BufferFormatSupports(FormatFeatureFlags flags, GAL.Format format)
>>>>>>> 1ec71635b (sync with main branch)
        {
            var formatFeatureFlags = _bufferTable[(int)format];

            if (formatFeatureFlags == 0)
            {
                _api.GetPhysicalDeviceFormatProperties(_physicalDevice, FormatTable.GetFormat(format), out var fp);
                formatFeatureFlags = fp.BufferFeatures;
                _bufferTable[(int)format] = formatFeatureFlags;
            }

            return (formatFeatureFlags & flags) == flags;
        }

<<<<<<< HEAD
        public bool SupportsScaledVertexFormats()
        {
            // We want to check is all scaled formats are supported,
            // but if the integer variant is not supported either,
            // then the format is likely not supported at all,
            // we ignore formats that are entirely unsupported here.

            for (int i = 0; i < _scaledFormats.Length; i++)
            {
                if (!BufferFormatSupports(FormatFeatureFlags.VertexBufferBit, _scaledFormats[i]) &&
                    BufferFormatSupports(FormatFeatureFlags.VertexBufferBit, _intFormats[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool BufferFormatSupports(FormatFeatureFlags flags, VkFormat format)
        {
            _api.GetPhysicalDeviceFormatProperties(_physicalDevice, format, out var fp);

            return (fp.BufferFeatures & flags) == flags;
        }

        public bool OptimalFormatSupports(FormatFeatureFlags flags, Format format)
=======
        public bool OptimalFormatSupports(FormatFeatureFlags flags, GAL.Format format)
>>>>>>> 1ec71635b (sync with main branch)
        {
            var formatFeatureFlags = _optimalTable[(int)format];

            if (formatFeatureFlags == 0)
            {
                _api.GetPhysicalDeviceFormatProperties(_physicalDevice, FormatTable.GetFormat(format), out var fp);
                formatFeatureFlags = fp.OptimalTilingFeatures;
                _optimalTable[(int)format] = formatFeatureFlags;
            }

            return (formatFeatureFlags & flags) == flags;
        }

<<<<<<< HEAD
        public VkFormat ConvertToVkFormat(Format srcFormat)
=======
        public VkFormat ConvertToVkFormat(GAL.Format srcFormat)
>>>>>>> 1ec71635b (sync with main branch)
        {
            var format = FormatTable.GetFormat(srcFormat);

            var requiredFeatures = FormatFeatureFlags.SampledImageBit |
                                   FormatFeatureFlags.TransferSrcBit |
                                   FormatFeatureFlags.TransferDstBit;

            if (srcFormat.IsDepthOrStencil())
            {
                requiredFeatures |= FormatFeatureFlags.DepthStencilAttachmentBit;
            }
            else if (srcFormat.IsRtColorCompatible())
            {
                requiredFeatures |= FormatFeatureFlags.ColorAttachmentBit;
            }

            if (srcFormat.IsImageCompatible())
            {
                requiredFeatures |= FormatFeatureFlags.StorageImageBit;
            }

            if (!OptimalFormatSupports(requiredFeatures, srcFormat) || (IsD24S8(srcFormat) && VulkanConfiguration.ForceD24S8Unsupported))
            {
                // The format is not supported. Can we convert it to a higher precision format?
                if (IsD24S8(srcFormat))
                {
                    format = VkFormat.D32SfloatS8Uint;
                }
<<<<<<< HEAD
                else if (srcFormat == Format.R4G4B4A4Unorm)
=======
                else if (srcFormat == GAL.Format.R4G4B4A4Unorm)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    format = VkFormat.R4G4B4A4UnormPack16;
                }
                else
                {
                    Logger.Error?.Print(LogClass.Gpu, $"Format {srcFormat} is not supported by the host.");
                }
            }

            return format;
        }

<<<<<<< HEAD
        public VkFormat ConvertToVertexVkFormat(Format srcFormat)
=======
        public VkFormat ConvertToVertexVkFormat(GAL.Format srcFormat)
>>>>>>> 1ec71635b (sync with main branch)
        {
            var format = FormatTable.GetFormat(srcFormat);

            if (!BufferFormatSupports(FormatFeatureFlags.VertexBufferBit, srcFormat) ||
                (IsRGB16IntFloat(srcFormat) && VulkanConfiguration.ForceRGB16IntFloatUnsupported))
            {
                // The format is not supported. Can we convert it to an alternative format?
                switch (srcFormat)
                {
<<<<<<< HEAD
                    case Format.R16G16B16Float:
                        format = VkFormat.R16G16B16A16Sfloat;
                        break;
                    case Format.R16G16B16Sint:
                        format = VkFormat.R16G16B16A16Sint;
                        break;
                    case Format.R16G16B16Uint:
=======
                    case GAL.Format.R16G16B16Float:
                        format = VkFormat.R16G16B16A16Sfloat;
                        break;
                    case GAL.Format.R16G16B16Sint:
                        format = VkFormat.R16G16B16A16Sint;
                        break;
                    case GAL.Format.R16G16B16Uint:
>>>>>>> 1ec71635b (sync with main branch)
                        format = VkFormat.R16G16B16A16Uint;
                        break;
                    default:
                        Logger.Error?.Print(LogClass.Gpu, $"Format {srcFormat} is not supported by the host.");
                        break;
                }
            }

            return format;
        }

<<<<<<< HEAD
        public static bool IsD24S8(Format format)
        {
            return format == Format.D24UnormS8Uint || format == Format.S8UintD24Unorm || format == Format.X8UintD24Unorm;
        }

        private static bool IsRGB16IntFloat(Format format)
        {
            return format == Format.R16G16B16Float ||
                   format == Format.R16G16B16Sint ||
                   format == Format.R16G16B16Uint;
=======
        public static bool IsD24S8(GAL.Format format)
        {
            return format == GAL.Format.D24UnormS8Uint || format == GAL.Format.S8UintD24Unorm;
        }

        private static bool IsRGB16IntFloat(GAL.Format format)
        {
            return format == GAL.Format.R16G16B16Float ||
                   format == GAL.Format.R16G16B16Sint ||
                   format == GAL.Format.R16G16B16Uint;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
