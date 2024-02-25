<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
    [Flags]
    enum PortabilitySubsetFlags
    {
        None = 0,

        NoTriangleFans = 1,
        NoPointMode = 1 << 1,
        No3DImageView = 1 << 2,
<<<<<<< HEAD
        NoLodBias = 1 << 3,
=======
        NoLodBias = 1 << 3
>>>>>>> 1ec71635b (sync with main branch)
    }

    readonly struct HardwareCapabilities
    {
        public readonly bool SupportsIndexTypeUint8;
        public readonly bool SupportsCustomBorderColor;
        public readonly bool SupportsBlendEquationAdvanced;
        public readonly bool SupportsBlendEquationAdvancedCorrelatedOverlap;
        public readonly bool SupportsBlendEquationAdvancedNonPreMultipliedSrcColor;
        public readonly bool SupportsBlendEquationAdvancedNonPreMultipliedDstColor;
        public readonly bool SupportsIndirectParameters;
        public readonly bool SupportsFragmentShaderInterlock;
        public readonly bool SupportsGeometryShaderPassthrough;
<<<<<<< HEAD
        public readonly bool SupportsShaderFloat64;
=======
        public readonly bool SupportsSubgroupSizeControl;
>>>>>>> 1ec71635b (sync with main branch)
        public readonly bool SupportsShaderInt8;
        public readonly bool SupportsShaderStencilExport;
        public readonly bool SupportsShaderStorageImageMultisample;
        public readonly bool SupportsConditionalRendering;
        public readonly bool SupportsExtendedDynamicState;
        public readonly bool SupportsMultiView;
        public readonly bool SupportsNullDescriptors;
        public readonly bool SupportsPushDescriptors;
<<<<<<< HEAD
        public readonly uint MaxPushDescriptors;
=======
>>>>>>> 1ec71635b (sync with main branch)
        public readonly bool SupportsPrimitiveTopologyListRestart;
        public readonly bool SupportsPrimitiveTopologyPatchListRestart;
        public readonly bool SupportsTransformFeedback;
        public readonly bool SupportsTransformFeedbackQueries;
        public readonly bool SupportsPreciseOcclusionQueries;
        public readonly bool SupportsPipelineStatisticsQuery;
        public readonly bool SupportsGeometryShader;
<<<<<<< HEAD
        public readonly bool SupportsTessellationShader;
        public readonly bool SupportsViewportArray2;
        public readonly bool SupportsHostImportedMemory;
        public readonly bool SupportsDepthClipControl;
        public readonly uint SubgroupSize;
=======
        public readonly bool SupportsViewportArray2;
        public readonly bool SupportsHostImportedMemory;
        public readonly uint MinSubgroupSize;
        public readonly uint MaxSubgroupSize;
        public readonly ShaderStageFlags RequiredSubgroupSizeStages;
>>>>>>> 1ec71635b (sync with main branch)
        public readonly SampleCountFlags SupportedSampleCounts;
        public readonly PortabilitySubsetFlags PortabilitySubset;
        public readonly uint VertexBufferAlignment;
        public readonly uint SubTexelPrecisionBits;
<<<<<<< HEAD
        public readonly ulong MinResourceAlignment;
=======
>>>>>>> 1ec71635b (sync with main branch)

        public HardwareCapabilities(
            bool supportsIndexTypeUint8,
            bool supportsCustomBorderColor,
            bool supportsBlendEquationAdvanced,
            bool supportsBlendEquationAdvancedCorrelatedOverlap,
            bool supportsBlendEquationAdvancedNonPreMultipliedSrcColor,
            bool supportsBlendEquationAdvancedNonPreMultipliedDstColor,
            bool supportsIndirectParameters,
            bool supportsFragmentShaderInterlock,
            bool supportsGeometryShaderPassthrough,
<<<<<<< HEAD
            bool supportsShaderFloat64,
=======
            bool supportsSubgroupSizeControl,
>>>>>>> 1ec71635b (sync with main branch)
            bool supportsShaderInt8,
            bool supportsShaderStencilExport,
            bool supportsShaderStorageImageMultisample,
            bool supportsConditionalRendering,
            bool supportsExtendedDynamicState,
            bool supportsMultiView,
            bool supportsNullDescriptors,
            bool supportsPushDescriptors,
<<<<<<< HEAD
            uint maxPushDescriptors,
=======
>>>>>>> 1ec71635b (sync with main branch)
            bool supportsPrimitiveTopologyListRestart,
            bool supportsPrimitiveTopologyPatchListRestart,
            bool supportsTransformFeedback,
            bool supportsTransformFeedbackQueries,
            bool supportsPreciseOcclusionQueries,
            bool supportsPipelineStatisticsQuery,
            bool supportsGeometryShader,
<<<<<<< HEAD
            bool supportsTessellationShader,
            bool supportsViewportArray2,
            bool supportsHostImportedMemory,
            bool supportsDepthClipControl,
            uint subgroupSize,
            SampleCountFlags supportedSampleCounts,
            PortabilitySubsetFlags portabilitySubset,
            uint vertexBufferAlignment,
            uint subTexelPrecisionBits,
            ulong minResourceAlignment)
=======
            bool supportsViewportArray2,
            bool supportsHostImportedMemory,
            uint minSubgroupSize,
            uint maxSubgroupSize,
            ShaderStageFlags requiredSubgroupSizeStages,
            SampleCountFlags supportedSampleCounts,
            PortabilitySubsetFlags portabilitySubset,
            uint vertexBufferAlignment,
            uint subTexelPrecisionBits)
>>>>>>> 1ec71635b (sync with main branch)
        {
            SupportsIndexTypeUint8 = supportsIndexTypeUint8;
            SupportsCustomBorderColor = supportsCustomBorderColor;
            SupportsBlendEquationAdvanced = supportsBlendEquationAdvanced;
            SupportsBlendEquationAdvancedCorrelatedOverlap = supportsBlendEquationAdvancedCorrelatedOverlap;
            SupportsBlendEquationAdvancedNonPreMultipliedSrcColor = supportsBlendEquationAdvancedNonPreMultipliedSrcColor;
            SupportsBlendEquationAdvancedNonPreMultipliedDstColor = supportsBlendEquationAdvancedNonPreMultipliedDstColor;
            SupportsIndirectParameters = supportsIndirectParameters;
            SupportsFragmentShaderInterlock = supportsFragmentShaderInterlock;
            SupportsGeometryShaderPassthrough = supportsGeometryShaderPassthrough;
<<<<<<< HEAD
            SupportsShaderFloat64 = supportsShaderFloat64;
=======
            SupportsSubgroupSizeControl = supportsSubgroupSizeControl;
>>>>>>> 1ec71635b (sync with main branch)
            SupportsShaderInt8 = supportsShaderInt8;
            SupportsShaderStencilExport = supportsShaderStencilExport;
            SupportsShaderStorageImageMultisample = supportsShaderStorageImageMultisample;
            SupportsConditionalRendering = supportsConditionalRendering;
            SupportsExtendedDynamicState = supportsExtendedDynamicState;
            SupportsMultiView = supportsMultiView;
            SupportsNullDescriptors = supportsNullDescriptors;
            SupportsPushDescriptors = supportsPushDescriptors;
<<<<<<< HEAD
            MaxPushDescriptors = maxPushDescriptors;
=======
>>>>>>> 1ec71635b (sync with main branch)
            SupportsPrimitiveTopologyListRestart = supportsPrimitiveTopologyListRestart;
            SupportsPrimitiveTopologyPatchListRestart = supportsPrimitiveTopologyPatchListRestart;
            SupportsTransformFeedback = supportsTransformFeedback;
            SupportsTransformFeedbackQueries = supportsTransformFeedbackQueries;
            SupportsPreciseOcclusionQueries = supportsPreciseOcclusionQueries;
            SupportsPipelineStatisticsQuery = supportsPipelineStatisticsQuery;
            SupportsGeometryShader = supportsGeometryShader;
<<<<<<< HEAD
            SupportsTessellationShader = supportsTessellationShader;
            SupportsViewportArray2 = supportsViewportArray2;
            SupportsHostImportedMemory = supportsHostImportedMemory;
            SupportsDepthClipControl = supportsDepthClipControl;
            SubgroupSize = subgroupSize;
=======
            SupportsViewportArray2 = supportsViewportArray2;
            SupportsHostImportedMemory = supportsHostImportedMemory;
            MinSubgroupSize = minSubgroupSize;
            MaxSubgroupSize = maxSubgroupSize;
            RequiredSubgroupSizeStages = requiredSubgroupSizeStages;
>>>>>>> 1ec71635b (sync with main branch)
            SupportedSampleCounts = supportedSampleCounts;
            PortabilitySubset = portabilitySubset;
            VertexBufferAlignment = vertexBufferAlignment;
            SubTexelPrecisionBits = subTexelPrecisionBits;
<<<<<<< HEAD
            MinResourceAlignment = minResourceAlignment;
=======
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
