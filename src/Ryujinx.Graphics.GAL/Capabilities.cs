using Ryujinx.Graphics.Shader.Translation;

namespace Ryujinx.Graphics.GAL
{
    public readonly struct Capabilities
    {
        public readonly TargetApi Api;
        public readonly string VendorName;

        public readonly bool HasFrontFacingBug;
        public readonly bool HasVectorIndexingBug;
        public readonly bool NeedsFragmentOutputSpecialization;
        public readonly bool ReduceShaderPrecision;

        public readonly bool SupportsAstcCompression;
        public readonly bool SupportsBc123Compression;
        public readonly bool SupportsBc45Compression;
        public readonly bool SupportsBc67Compression;
        public readonly bool SupportsEtc2Compression;
        public readonly bool Supports3DTextureCompression;
        public readonly bool SupportsBgraFormat;
        public readonly bool SupportsR4G4Format;
        public readonly bool SupportsR4G4B4A4Format;
<<<<<<< HEAD
        public readonly bool SupportsScaledVertexFormats;
        public readonly bool SupportsSnormBufferTextureFormat;
        public readonly bool SupportsSparseBuffer;
=======
        public readonly bool SupportsSnormBufferTextureFormat;
>>>>>>> 1ec71635b (sync with main branch)
        public readonly bool Supports5BitComponentFormat;
        public readonly bool SupportsBlendEquationAdvanced;
        public readonly bool SupportsFragmentShaderInterlock;
        public readonly bool SupportsFragmentShaderOrderingIntel;
        public readonly bool SupportsGeometryShader;
        public readonly bool SupportsGeometryShaderPassthrough;
<<<<<<< HEAD
        public readonly bool SupportsTransformFeedback;
=======
>>>>>>> 1ec71635b (sync with main branch)
        public readonly bool SupportsImageLoadFormatted;
        public readonly bool SupportsLayerVertexTessellation;
        public readonly bool SupportsMismatchingViewFormat;
        public readonly bool SupportsCubemapView;
        public readonly bool SupportsNonConstantTextureOffset;
        public readonly bool SupportsShaderBallot;
<<<<<<< HEAD
        public readonly bool SupportsShaderBarrierDivergence;
        public readonly bool SupportsShaderFloat64;
        public readonly bool SupportsTextureGatherOffsets;
        public readonly bool SupportsTextureShadowLod;
        public readonly bool SupportsVertexStoreAndAtomics;
=======
        public readonly bool SupportsTextureShadowLod;
>>>>>>> 1ec71635b (sync with main branch)
        public readonly bool SupportsViewportIndexVertexTessellation;
        public readonly bool SupportsViewportMask;
        public readonly bool SupportsViewportSwizzle;
        public readonly bool SupportsIndirectParameters;
<<<<<<< HEAD
        public readonly bool SupportsDepthClipControl;
=======
>>>>>>> 1ec71635b (sync with main branch)

        public readonly uint MaximumUniformBuffersPerStage;
        public readonly uint MaximumStorageBuffersPerStage;
        public readonly uint MaximumTexturesPerStage;
        public readonly uint MaximumImagesPerStage;

        public readonly int MaximumComputeSharedMemorySize;
        public readonly float MaximumSupportedAnisotropy;
<<<<<<< HEAD
        public readonly int ShaderSubgroupSize;
        public readonly int StorageBufferOffsetAlignment;
        public readonly int TextureBufferOffsetAlignment;
=======
        public readonly int StorageBufferOffsetAlignment;
>>>>>>> 1ec71635b (sync with main branch)

        public readonly int GatherBiasPrecision;

        public Capabilities(
            TargetApi api,
            string vendorName,
            bool hasFrontFacingBug,
            bool hasVectorIndexingBug,
            bool needsFragmentOutputSpecialization,
            bool reduceShaderPrecision,
            bool supportsAstcCompression,
            bool supportsBc123Compression,
            bool supportsBc45Compression,
            bool supportsBc67Compression,
            bool supportsEtc2Compression,
            bool supports3DTextureCompression,
            bool supportsBgraFormat,
            bool supportsR4G4Format,
            bool supportsR4G4B4A4Format,
<<<<<<< HEAD
            bool supportsScaledVertexFormats,
            bool supportsSnormBufferTextureFormat,
            bool supports5BitComponentFormat,
            bool supportsSparseBuffer,
=======
            bool supportsSnormBufferTextureFormat,
            bool supports5BitComponentFormat,
>>>>>>> 1ec71635b (sync with main branch)
            bool supportsBlendEquationAdvanced,
            bool supportsFragmentShaderInterlock,
            bool supportsFragmentShaderOrderingIntel,
            bool supportsGeometryShader,
            bool supportsGeometryShaderPassthrough,
<<<<<<< HEAD
            bool supportsTransformFeedback,
=======
>>>>>>> 1ec71635b (sync with main branch)
            bool supportsImageLoadFormatted,
            bool supportsLayerVertexTessellation,
            bool supportsMismatchingViewFormat,
            bool supportsCubemapView,
            bool supportsNonConstantTextureOffset,
            bool supportsShaderBallot,
<<<<<<< HEAD
            bool supportsShaderBarrierDivergence,
            bool supportsShaderFloat64,
            bool supportsTextureGatherOffsets,
            bool supportsTextureShadowLod,
            bool supportsVertexStoreAndAtomics,
=======
            bool supportsTextureShadowLod,
>>>>>>> 1ec71635b (sync with main branch)
            bool supportsViewportIndexVertexTessellation,
            bool supportsViewportMask,
            bool supportsViewportSwizzle,
            bool supportsIndirectParameters,
<<<<<<< HEAD
            bool supportsDepthClipControl,
=======
>>>>>>> 1ec71635b (sync with main branch)
            uint maximumUniformBuffersPerStage,
            uint maximumStorageBuffersPerStage,
            uint maximumTexturesPerStage,
            uint maximumImagesPerStage,
            int maximumComputeSharedMemorySize,
            float maximumSupportedAnisotropy,
<<<<<<< HEAD
            int shaderSubgroupSize,
            int storageBufferOffsetAlignment,
            int textureBufferOffsetAlignment,
=======
            int storageBufferOffsetAlignment,
>>>>>>> 1ec71635b (sync with main branch)
            int gatherBiasPrecision)
        {
            Api = api;
            VendorName = vendorName;
            HasFrontFacingBug = hasFrontFacingBug;
            HasVectorIndexingBug = hasVectorIndexingBug;
            NeedsFragmentOutputSpecialization = needsFragmentOutputSpecialization;
            ReduceShaderPrecision = reduceShaderPrecision;
            SupportsAstcCompression = supportsAstcCompression;
            SupportsBc123Compression = supportsBc123Compression;
            SupportsBc45Compression = supportsBc45Compression;
            SupportsBc67Compression = supportsBc67Compression;
            SupportsEtc2Compression = supportsEtc2Compression;
            Supports3DTextureCompression = supports3DTextureCompression;
            SupportsBgraFormat = supportsBgraFormat;
            SupportsR4G4Format = supportsR4G4Format;
            SupportsR4G4B4A4Format = supportsR4G4B4A4Format;
<<<<<<< HEAD
            SupportsScaledVertexFormats = supportsScaledVertexFormats;
            SupportsSnormBufferTextureFormat = supportsSnormBufferTextureFormat;
            Supports5BitComponentFormat = supports5BitComponentFormat;
            SupportsSparseBuffer = supportsSparseBuffer;
=======
            SupportsSnormBufferTextureFormat = supportsSnormBufferTextureFormat;
            Supports5BitComponentFormat = supports5BitComponentFormat;
>>>>>>> 1ec71635b (sync with main branch)
            SupportsBlendEquationAdvanced = supportsBlendEquationAdvanced;
            SupportsFragmentShaderInterlock = supportsFragmentShaderInterlock;
            SupportsFragmentShaderOrderingIntel = supportsFragmentShaderOrderingIntel;
            SupportsGeometryShader = supportsGeometryShader;
            SupportsGeometryShaderPassthrough = supportsGeometryShaderPassthrough;
<<<<<<< HEAD
            SupportsTransformFeedback = supportsTransformFeedback;
=======
>>>>>>> 1ec71635b (sync with main branch)
            SupportsImageLoadFormatted = supportsImageLoadFormatted;
            SupportsLayerVertexTessellation = supportsLayerVertexTessellation;
            SupportsMismatchingViewFormat = supportsMismatchingViewFormat;
            SupportsCubemapView = supportsCubemapView;
            SupportsNonConstantTextureOffset = supportsNonConstantTextureOffset;
            SupportsShaderBallot = supportsShaderBallot;
<<<<<<< HEAD
            SupportsShaderBarrierDivergence = supportsShaderBarrierDivergence;
            SupportsShaderFloat64 = supportsShaderFloat64;
            SupportsTextureGatherOffsets = supportsTextureGatherOffsets;
            SupportsTextureShadowLod = supportsTextureShadowLod;
            SupportsVertexStoreAndAtomics = supportsVertexStoreAndAtomics;
=======
            SupportsTextureShadowLod = supportsTextureShadowLod;
>>>>>>> 1ec71635b (sync with main branch)
            SupportsViewportIndexVertexTessellation = supportsViewportIndexVertexTessellation;
            SupportsViewportMask = supportsViewportMask;
            SupportsViewportSwizzle = supportsViewportSwizzle;
            SupportsIndirectParameters = supportsIndirectParameters;
<<<<<<< HEAD
            SupportsDepthClipControl = supportsDepthClipControl;
=======
>>>>>>> 1ec71635b (sync with main branch)
            MaximumUniformBuffersPerStage = maximumUniformBuffersPerStage;
            MaximumStorageBuffersPerStage = maximumStorageBuffersPerStage;
            MaximumTexturesPerStage = maximumTexturesPerStage;
            MaximumImagesPerStage = maximumImagesPerStage;
            MaximumComputeSharedMemorySize = maximumComputeSharedMemorySize;
            MaximumSupportedAnisotropy = maximumSupportedAnisotropy;
<<<<<<< HEAD
            ShaderSubgroupSize = shaderSubgroupSize;
            StorageBufferOffsetAlignment = storageBufferOffsetAlignment;
            TextureBufferOffsetAlignment = textureBufferOffsetAlignment;
            GatherBiasPrecision = gatherBiasPrecision;
        }
    }
}
=======
            StorageBufferOffsetAlignment = storageBufferOffsetAlignment;
            GatherBiasPrecision = gatherBiasPrecision;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
