<<<<<<< HEAD
using Ryujinx.Common.Memory;
using Silk.NET.Vulkan;
using System;
using System.Numerics;
=======
﻿using Ryujinx.Common.Memory;
using Silk.NET.Vulkan;
using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    struct PipelineState : IDisposable
    {
        private const int RequiredSubgroupSize = 32;

        public PipelineUid Internal;

        public float LineWidth
        {
<<<<<<< HEAD
            readonly get => BitConverter.Int32BitsToSingle((int)((Internal.Id0 >> 0) & 0xFFFFFFFF));
=======
            get => BitConverter.Int32BitsToSingle((int)((Internal.Id0 >> 0) & 0xFFFFFFFF));
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id0 = (Internal.Id0 & 0xFFFFFFFF00000000) | ((ulong)(uint)BitConverter.SingleToInt32Bits(value) << 0);
        }

        public float DepthBiasClamp
        {
<<<<<<< HEAD
            readonly get => BitConverter.Int32BitsToSingle((int)((Internal.Id0 >> 32) & 0xFFFFFFFF));
=======
            get => BitConverter.Int32BitsToSingle((int)((Internal.Id0 >> 32) & 0xFFFFFFFF));
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id0 = (Internal.Id0 & 0xFFFFFFFF) | ((ulong)(uint)BitConverter.SingleToInt32Bits(value) << 32);
        }

        public float DepthBiasConstantFactor
        {
<<<<<<< HEAD
            readonly get => BitConverter.Int32BitsToSingle((int)((Internal.Id1 >> 0) & 0xFFFFFFFF));
=======
            get => BitConverter.Int32BitsToSingle((int)((Internal.Id1 >> 0) & 0xFFFFFFFF));
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id1 = (Internal.Id1 & 0xFFFFFFFF00000000) | ((ulong)(uint)BitConverter.SingleToInt32Bits(value) << 0);
        }

        public float DepthBiasSlopeFactor
        {
<<<<<<< HEAD
            readonly get => BitConverter.Int32BitsToSingle((int)((Internal.Id1 >> 32) & 0xFFFFFFFF));
=======
            get => BitConverter.Int32BitsToSingle((int)((Internal.Id1 >> 32) & 0xFFFFFFFF));
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id1 = (Internal.Id1 & 0xFFFFFFFF) | ((ulong)(uint)BitConverter.SingleToInt32Bits(value) << 32);
        }

        public uint StencilFrontCompareMask
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id2 >> 0) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id2 >> 0) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id2 = (Internal.Id2 & 0xFFFFFFFF00000000) | ((ulong)value << 0);
        }

        public uint StencilFrontWriteMask
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id2 >> 32) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id2 >> 32) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id2 = (Internal.Id2 & 0xFFFFFFFF) | ((ulong)value << 32);
        }

        public uint StencilFrontReference
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id3 >> 0) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id3 >> 0) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id3 = (Internal.Id3 & 0xFFFFFFFF00000000) | ((ulong)value << 0);
        }

        public uint StencilBackCompareMask
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id3 >> 32) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id3 >> 32) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id3 = (Internal.Id3 & 0xFFFFFFFF) | ((ulong)value << 32);
        }

        public uint StencilBackWriteMask
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id4 >> 0) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id4 >> 0) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id4 = (Internal.Id4 & 0xFFFFFFFF00000000) | ((ulong)value << 0);
        }

        public uint StencilBackReference
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id4 >> 32) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id4 >> 32) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id4 = (Internal.Id4 & 0xFFFFFFFF) | ((ulong)value << 32);
        }

        public float MinDepthBounds
        {
<<<<<<< HEAD
            readonly get => BitConverter.Int32BitsToSingle((int)((Internal.Id5 >> 0) & 0xFFFFFFFF));
=======
            get => BitConverter.Int32BitsToSingle((int)((Internal.Id5 >> 0) & 0xFFFFFFFF));
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id5 = (Internal.Id5 & 0xFFFFFFFF00000000) | ((ulong)(uint)BitConverter.SingleToInt32Bits(value) << 0);
        }

        public float MaxDepthBounds
        {
<<<<<<< HEAD
            readonly get => BitConverter.Int32BitsToSingle((int)((Internal.Id5 >> 32) & 0xFFFFFFFF));
=======
            get => BitConverter.Int32BitsToSingle((int)((Internal.Id5 >> 32) & 0xFFFFFFFF));
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id5 = (Internal.Id5 & 0xFFFFFFFF) | ((ulong)(uint)BitConverter.SingleToInt32Bits(value) << 32);
        }

        public PolygonMode PolygonMode
        {
<<<<<<< HEAD
            readonly get => (PolygonMode)((Internal.Id6 >> 0) & 0x3FFFFFFF);
=======
            get => (PolygonMode)((Internal.Id6 >> 0) & 0x3FFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id6 = (Internal.Id6 & 0xFFFFFFFFC0000000) | ((ulong)value << 0);
        }

        public uint StagesCount
        {
<<<<<<< HEAD
            readonly get => (byte)((Internal.Id6 >> 30) & 0xFF);
=======
            get => (byte)((Internal.Id6 >> 30) & 0xFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id6 = (Internal.Id6 & 0xFFFFFFC03FFFFFFF) | ((ulong)value << 30);
        }

        public uint VertexAttributeDescriptionsCount
        {
<<<<<<< HEAD
            readonly get => (byte)((Internal.Id6 >> 38) & 0xFF);
=======
            get => (byte)((Internal.Id6 >> 38) & 0xFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id6 = (Internal.Id6 & 0xFFFFC03FFFFFFFFF) | ((ulong)value << 38);
        }

        public uint VertexBindingDescriptionsCount
        {
<<<<<<< HEAD
            readonly get => (byte)((Internal.Id6 >> 46) & 0xFF);
=======
            get => (byte)((Internal.Id6 >> 46) & 0xFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id6 = (Internal.Id6 & 0xFFC03FFFFFFFFFFF) | ((ulong)value << 46);
        }

        public uint ViewportsCount
        {
<<<<<<< HEAD
            readonly get => (byte)((Internal.Id6 >> 54) & 0xFF);
=======
            get => (byte)((Internal.Id6 >> 54) & 0xFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id6 = (Internal.Id6 & 0xC03FFFFFFFFFFFFF) | ((ulong)value << 54);
        }

        public uint ScissorsCount
        {
<<<<<<< HEAD
            readonly get => (byte)((Internal.Id7 >> 0) & 0xFF);
=======
            get => (byte)((Internal.Id7 >> 0) & 0xFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFFFFFFFFF00) | ((ulong)value << 0);
        }

        public uint ColorBlendAttachmentStateCount
        {
<<<<<<< HEAD
            readonly get => (byte)((Internal.Id7 >> 8) & 0xFF);
=======
            get => (byte)((Internal.Id7 >> 8) & 0xFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFFFFFFF00FF) | ((ulong)value << 8);
        }

        public PrimitiveTopology Topology
        {
<<<<<<< HEAD
            readonly get => (PrimitiveTopology)((Internal.Id7 >> 16) & 0xF);
=======
            get => (PrimitiveTopology)((Internal.Id7 >> 16) & 0xF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFFFFFF0FFFF) | ((ulong)value << 16);
        }

        public LogicOp LogicOp
        {
<<<<<<< HEAD
            readonly get => (LogicOp)((Internal.Id7 >> 20) & 0xF);
=======
            get => (LogicOp)((Internal.Id7 >> 20) & 0xF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFFFFF0FFFFF) | ((ulong)value << 20);
        }

        public CompareOp DepthCompareOp
        {
<<<<<<< HEAD
            readonly get => (CompareOp)((Internal.Id7 >> 24) & 0x7);
=======
            get => (CompareOp)((Internal.Id7 >> 24) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFFFF8FFFFFF) | ((ulong)value << 24);
        }

        public StencilOp StencilFrontFailOp
        {
<<<<<<< HEAD
            readonly get => (StencilOp)((Internal.Id7 >> 27) & 0x7);
=======
            get => (StencilOp)((Internal.Id7 >> 27) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFFFC7FFFFFF) | ((ulong)value << 27);
        }

        public StencilOp StencilFrontPassOp
        {
<<<<<<< HEAD
            readonly get => (StencilOp)((Internal.Id7 >> 30) & 0x7);
=======
            get => (StencilOp)((Internal.Id7 >> 30) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFFE3FFFFFFF) | ((ulong)value << 30);
        }

        public StencilOp StencilFrontDepthFailOp
        {
<<<<<<< HEAD
            readonly get => (StencilOp)((Internal.Id7 >> 33) & 0x7);
=======
            get => (StencilOp)((Internal.Id7 >> 33) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFFF1FFFFFFFF) | ((ulong)value << 33);
        }

        public CompareOp StencilFrontCompareOp
        {
<<<<<<< HEAD
            readonly get => (CompareOp)((Internal.Id7 >> 36) & 0x7);
=======
            get => (CompareOp)((Internal.Id7 >> 36) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFF8FFFFFFFFF) | ((ulong)value << 36);
        }

        public StencilOp StencilBackFailOp
        {
<<<<<<< HEAD
            readonly get => (StencilOp)((Internal.Id7 >> 39) & 0x7);
=======
            get => (StencilOp)((Internal.Id7 >> 39) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFFC7FFFFFFFFF) | ((ulong)value << 39);
        }

        public StencilOp StencilBackPassOp
        {
<<<<<<< HEAD
            readonly get => (StencilOp)((Internal.Id7 >> 42) & 0x7);
=======
            get => (StencilOp)((Internal.Id7 >> 42) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFFE3FFFFFFFFFF) | ((ulong)value << 42);
        }

        public StencilOp StencilBackDepthFailOp
        {
<<<<<<< HEAD
            readonly get => (StencilOp)((Internal.Id7 >> 45) & 0x7);
=======
            get => (StencilOp)((Internal.Id7 >> 45) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFFF1FFFFFFFFFFF) | ((ulong)value << 45);
        }

        public CompareOp StencilBackCompareOp
        {
<<<<<<< HEAD
            readonly get => (CompareOp)((Internal.Id7 >> 48) & 0x7);
=======
            get => (CompareOp)((Internal.Id7 >> 48) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFF8FFFFFFFFFFFF) | ((ulong)value << 48);
        }

        public CullModeFlags CullMode
        {
<<<<<<< HEAD
            readonly get => (CullModeFlags)((Internal.Id7 >> 51) & 0x3);
=======
            get => (CullModeFlags)((Internal.Id7 >> 51) & 0x3);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFE7FFFFFFFFFFFF) | ((ulong)value << 51);
        }

        public bool PrimitiveRestartEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 53) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 53) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFDFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 53);
        }

        public bool DepthClampEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 54) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 54) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFFBFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 54);
        }

        public bool RasterizerDiscardEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 55) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 55) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFF7FFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 55);
        }

        public FrontFace FrontFace
        {
<<<<<<< HEAD
            readonly get => (FrontFace)((Internal.Id7 >> 56) & 0x1);
=======
            get => (FrontFace)((Internal.Id7 >> 56) & 0x1);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFEFFFFFFFFFFFFFF) | ((ulong)value << 56);
        }

        public bool DepthBiasEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 57) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 57) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFDFFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 57);
        }

        public bool DepthTestEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 58) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 58) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xFBFFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 58);
        }

        public bool DepthWriteEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 59) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 59) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xF7FFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 59);
        }

        public bool DepthBoundsTestEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 60) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 60) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xEFFFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 60);
        }

        public bool StencilTestEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 61) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 61) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xDFFFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 61);
        }

        public bool LogicOpEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 62) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 62) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0xBFFFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 62);
        }

        public bool HasDepthStencil
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id7 >> 63) & 0x1) != 0UL;
=======
            get => ((Internal.Id7 >> 63) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id7 = (Internal.Id7 & 0x7FFFFFFFFFFFFFFF) | ((value ? 1UL : 0UL) << 63);
        }

        public uint PatchControlPoints
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id8 >> 0) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id8 >> 0) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id8 = (Internal.Id8 & 0xFFFFFFFF00000000) | ((ulong)value << 0);
        }

        public uint SamplesCount
        {
<<<<<<< HEAD
            readonly get => (uint)((Internal.Id8 >> 32) & 0xFFFFFFFF);
=======
            get => (uint)((Internal.Id8 >> 32) & 0xFFFFFFFF);
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id8 = (Internal.Id8 & 0xFFFFFFFF) | ((ulong)value << 32);
        }

        public bool AlphaToCoverageEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id9 >> 0) & 0x1) != 0UL;
=======
            get => ((Internal.Id9 >> 0) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id9 = (Internal.Id9 & 0xFFFFFFFFFFFFFFFE) | ((value ? 1UL : 0UL) << 0);
        }

        public bool AlphaToOneEnable
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id9 >> 1) & 0x1) != 0UL;
=======
            get => ((Internal.Id9 >> 1) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id9 = (Internal.Id9 & 0xFFFFFFFFFFFFFFFD) | ((value ? 1UL : 0UL) << 1);
        }

        public bool AdvancedBlendSrcPreMultiplied
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id9 >> 2) & 0x1) != 0UL;
=======
            get => ((Internal.Id9 >> 2) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id9 = (Internal.Id9 & 0xFFFFFFFFFFFFFFFB) | ((value ? 1UL : 0UL) << 2);
        }

        public bool AdvancedBlendDstPreMultiplied
        {
<<<<<<< HEAD
            readonly get => ((Internal.Id9 >> 3) & 0x1) != 0UL;
=======
            get => ((Internal.Id9 >> 3) & 0x1) != 0UL;
>>>>>>> 1ec71635b (sync with main branch)
            set => Internal.Id9 = (Internal.Id9 & 0xFFFFFFFFFFFFFFF7) | ((value ? 1UL : 0UL) << 3);
        }

        public BlendOverlapEXT AdvancedBlendOverlap
        {
<<<<<<< HEAD
            readonly get => (BlendOverlapEXT)((Internal.Id9 >> 4) & 0x3);
            set => Internal.Id9 = (Internal.Id9 & 0xFFFFFFFFFFFFFFCF) | ((ulong)value << 4);
        }

        public bool DepthMode
        {
            readonly get => ((Internal.Id9 >> 6) & 0x1) != 0UL;
            set => Internal.Id9 = (Internal.Id9 & 0xFFFFFFFFFFFFFFBF) | ((value ? 1UL : 0UL) << 6);
        }

        public NativeArray<PipelineShaderStageCreateInfo> Stages;
=======
            get => (BlendOverlapEXT)((Internal.Id9 >> 4) & 0x3);
            set => Internal.Id9 = (Internal.Id9 & 0xFFFFFFFFFFFFFFCF) | ((ulong)value << 4);
        }

        public NativeArray<PipelineShaderStageCreateInfo> Stages;
        public NativeArray<PipelineShaderStageRequiredSubgroupSizeCreateInfoEXT> StageRequiredSubgroupSizes;
>>>>>>> 1ec71635b (sync with main branch)
        public PipelineLayout PipelineLayout;
        public SpecData SpecializationData;

        private Array32<VertexInputAttributeDescription> _vertexAttributeDescriptions2;

        public void Initialize()
        {
            Stages = new NativeArray<PipelineShaderStageCreateInfo>(Constants.MaxShaderStages);
<<<<<<< HEAD
=======
            StageRequiredSubgroupSizes = new NativeArray<PipelineShaderStageRequiredSubgroupSizeCreateInfoEXT>(Constants.MaxShaderStages);

            for (int index = 0; index < Constants.MaxShaderStages; index++)
            {
                StageRequiredSubgroupSizes[index] = new PipelineShaderStageRequiredSubgroupSizeCreateInfoEXT()
                {
                    SType = StructureType.PipelineShaderStageRequiredSubgroupSizeCreateInfoExt,
                    RequiredSubgroupSize = RequiredSubgroupSize
                };
            }
>>>>>>> 1ec71635b (sync with main branch)

            AdvancedBlendSrcPreMultiplied = true;
            AdvancedBlendDstPreMultiplied = true;
            AdvancedBlendOverlap = BlendOverlapEXT.UncorrelatedExt;

            LineWidth = 1f;
            SamplesCount = 1;
<<<<<<< HEAD
            DepthMode = true;
=======
>>>>>>> 1ec71635b (sync with main branch)
        }

        public unsafe Auto<DisposablePipeline> CreateComputePipeline(
            VulkanRenderer gd,
            Device device,
            ShaderCollection program,
            PipelineCache cache)
        {
            if (program.TryGetComputePipeline(ref SpecializationData, out var pipeline))
            {
                return pipeline;
            }

<<<<<<< HEAD
            var pipelineCreateInfo = new ComputePipelineCreateInfo
=======
            if (gd.Capabilities.SupportsSubgroupSizeControl)
            {
                UpdateStageRequiredSubgroupSizes(gd, 1);
            }

            var pipelineCreateInfo = new ComputePipelineCreateInfo()
>>>>>>> 1ec71635b (sync with main branch)
            {
                SType = StructureType.ComputePipelineCreateInfo,
                Stage = Stages[0],
                BasePipelineIndex = -1,
<<<<<<< HEAD
                Layout = PipelineLayout,
=======
                Layout = PipelineLayout
>>>>>>> 1ec71635b (sync with main branch)
            };

            Pipeline pipelineHandle = default;

            bool hasSpec = program.SpecDescriptions != null;

            var desc = hasSpec ? program.SpecDescriptions[0] : SpecDescription.Empty;

            if (hasSpec && SpecializationData.Length < (int)desc.Info.DataSize)
            {
                throw new InvalidOperationException("Specialization data size does not match description");
            }

            fixed (SpecializationInfo* info = &desc.Info)
            fixed (SpecializationMapEntry* map = desc.Map)
            fixed (byte* data = SpecializationData.Span)
            {
                if (hasSpec)
                {
                    info->PMapEntries = map;
                    info->PData = data;
                    pipelineCreateInfo.Stage.PSpecializationInfo = info;
                }

                gd.Api.CreateComputePipelines(device, cache, 1, &pipelineCreateInfo, null, &pipelineHandle).ThrowOnError();
            }

            pipeline = new Auto<DisposablePipeline>(new DisposablePipeline(gd.Api, device, pipelineHandle));

            program.AddComputePipeline(ref SpecializationData, pipeline);

            return pipeline;
        }

        public unsafe Auto<DisposablePipeline> CreateGraphicsPipeline(
            VulkanRenderer gd,
            Device device,
            ShaderCollection program,
            PipelineCache cache,
<<<<<<< HEAD
            RenderPass renderPass,
            bool throwOnError = false)
=======
            RenderPass renderPass)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (program.TryGetGraphicsPipeline(ref Internal, out var pipeline))
            {
                return pipeline;
            }

            Pipeline pipelineHandle = default;

            bool isMoltenVk = gd.IsMoltenVk;

            if (isMoltenVk)
            {
<<<<<<< HEAD
                UpdateVertexAttributeDescriptions(gd);
=======
                UpdateVertexAttributeDescriptions();
>>>>>>> 1ec71635b (sync with main branch)
            }

            fixed (VertexInputAttributeDescription* pVertexAttributeDescriptions = &Internal.VertexAttributeDescriptions[0])
            fixed (VertexInputAttributeDescription* pVertexAttributeDescriptions2 = &_vertexAttributeDescriptions2[0])
            fixed (VertexInputBindingDescription* pVertexBindingDescriptions = &Internal.VertexBindingDescriptions[0])
            fixed (Viewport* pViewports = &Internal.Viewports[0])
            fixed (Rect2D* pScissors = &Internal.Scissors[0])
            fixed (PipelineColorBlendAttachmentState* pColorBlendAttachmentState = &Internal.ColorBlendAttachmentState[0])
            {
                var vertexInputState = new PipelineVertexInputStateCreateInfo
                {
                    SType = StructureType.PipelineVertexInputStateCreateInfo,
                    VertexAttributeDescriptionCount = VertexAttributeDescriptionsCount,
                    PVertexAttributeDescriptions = isMoltenVk ? pVertexAttributeDescriptions2 : pVertexAttributeDescriptions,
                    VertexBindingDescriptionCount = VertexBindingDescriptionsCount,
<<<<<<< HEAD
                    PVertexBindingDescriptions = pVertexBindingDescriptions,
=======
                    PVertexBindingDescriptions = pVertexBindingDescriptions
>>>>>>> 1ec71635b (sync with main branch)
                };

                bool primitiveRestartEnable = PrimitiveRestartEnable;

                bool topologySupportsRestart;

                if (gd.Capabilities.SupportsPrimitiveTopologyListRestart)
                {
                    topologySupportsRestart = gd.Capabilities.SupportsPrimitiveTopologyPatchListRestart || Topology != PrimitiveTopology.PatchList;
                }
                else
                {
                    topologySupportsRestart = Topology == PrimitiveTopology.LineStrip ||
                                              Topology == PrimitiveTopology.TriangleStrip ||
                                              Topology == PrimitiveTopology.TriangleFan ||
                                              Topology == PrimitiveTopology.LineStripWithAdjacency ||
                                              Topology == PrimitiveTopology.TriangleStripWithAdjacency;
                }

                primitiveRestartEnable &= topologySupportsRestart;

<<<<<<< HEAD
                var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo
                {
                    SType = StructureType.PipelineInputAssemblyStateCreateInfo,
                    PrimitiveRestartEnable = primitiveRestartEnable,
                    Topology = Topology,
                };

                var tessellationState = new PipelineTessellationStateCreateInfo
                {
                    SType = StructureType.PipelineTessellationStateCreateInfo,
                    PatchControlPoints = PatchControlPoints,
                };

                var rasterizationState = new PipelineRasterizationStateCreateInfo
=======
                var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo()
                {
                    SType = StructureType.PipelineInputAssemblyStateCreateInfo,
                    PrimitiveRestartEnable = primitiveRestartEnable,
                    Topology = Topology
                };

                var tessellationState = new PipelineTessellationStateCreateInfo()
                {
                    SType = StructureType.PipelineTessellationStateCreateInfo,
                    PatchControlPoints = PatchControlPoints
                };

                var rasterizationState = new PipelineRasterizationStateCreateInfo()
>>>>>>> 1ec71635b (sync with main branch)
                {
                    SType = StructureType.PipelineRasterizationStateCreateInfo,
                    DepthClampEnable = DepthClampEnable,
                    RasterizerDiscardEnable = RasterizerDiscardEnable,
                    PolygonMode = PolygonMode,
                    LineWidth = LineWidth,
                    CullMode = CullMode,
                    FrontFace = FrontFace,
                    DepthBiasEnable = DepthBiasEnable,
                    DepthBiasClamp = DepthBiasClamp,
                    DepthBiasConstantFactor = DepthBiasConstantFactor,
<<<<<<< HEAD
                    DepthBiasSlopeFactor = DepthBiasSlopeFactor,
                };

                var viewportState = new PipelineViewportStateCreateInfo
=======
                    DepthBiasSlopeFactor = DepthBiasSlopeFactor
                };

                var viewportState = new PipelineViewportStateCreateInfo()
>>>>>>> 1ec71635b (sync with main branch)
                {
                    SType = StructureType.PipelineViewportStateCreateInfo,
                    ViewportCount = ViewportsCount,
                    PViewports = pViewports,
                    ScissorCount = ScissorsCount,
<<<<<<< HEAD
                    PScissors = pScissors,
                };

                if (gd.Capabilities.SupportsDepthClipControl)
                {
                    var viewportDepthClipControlState = new PipelineViewportDepthClipControlCreateInfoEXT
                    {
                        SType = StructureType.PipelineViewportDepthClipControlCreateInfoExt,
                        NegativeOneToOne = DepthMode,
                    };

                    viewportState.PNext = &viewportDepthClipControlState;
                }

=======
                    PScissors = pScissors
                };

>>>>>>> 1ec71635b (sync with main branch)
                var multisampleState = new PipelineMultisampleStateCreateInfo
                {
                    SType = StructureType.PipelineMultisampleStateCreateInfo,
                    SampleShadingEnable = false,
                    RasterizationSamples = TextureStorage.ConvertToSampleCountFlags(gd.Capabilities.SupportedSampleCounts, SamplesCount),
                    MinSampleShading = 1,
                    AlphaToCoverageEnable = AlphaToCoverageEnable,
<<<<<<< HEAD
                    AlphaToOneEnable = AlphaToOneEnable,
=======
                    AlphaToOneEnable = AlphaToOneEnable
>>>>>>> 1ec71635b (sync with main branch)
                };

                var stencilFront = new StencilOpState(
                    StencilFrontFailOp,
                    StencilFrontPassOp,
                    StencilFrontDepthFailOp,
                    StencilFrontCompareOp,
                    StencilFrontCompareMask,
                    StencilFrontWriteMask,
                    StencilFrontReference);

                var stencilBack = new StencilOpState(
                    StencilBackFailOp,
                    StencilBackPassOp,
                    StencilBackDepthFailOp,
                    StencilBackCompareOp,
                    StencilBackCompareMask,
                    StencilBackWriteMask,
                    StencilBackReference);

<<<<<<< HEAD
                var depthStencilState = new PipelineDepthStencilStateCreateInfo
=======
                var depthStencilState = new PipelineDepthStencilStateCreateInfo()
>>>>>>> 1ec71635b (sync with main branch)
                {
                    SType = StructureType.PipelineDepthStencilStateCreateInfo,
                    DepthTestEnable = DepthTestEnable,
                    DepthWriteEnable = DepthWriteEnable,
                    DepthCompareOp = DepthCompareOp,
                    DepthBoundsTestEnable = DepthBoundsTestEnable,
                    StencilTestEnable = StencilTestEnable,
                    Front = stencilFront,
                    Back = stencilBack,
                    MinDepthBounds = MinDepthBounds,
<<<<<<< HEAD
                    MaxDepthBounds = MaxDepthBounds,
                };

                uint blendEnables = 0;

                if (gd.IsMoltenVk && Internal.AttachmentIntegerFormatMask != 0)
                {
                    // Blend can't be enabled for integer formats, so let's make sure it is disabled.
                    uint attachmentIntegerFormatMask = Internal.AttachmentIntegerFormatMask;

                    while (attachmentIntegerFormatMask != 0)
                    {
                        int i = BitOperations.TrailingZeroCount(attachmentIntegerFormatMask);

                        if (Internal.ColorBlendAttachmentState[i].BlendEnable)
                        {
                            blendEnables |= 1u << i;
                        }

                        Internal.ColorBlendAttachmentState[i].BlendEnable = false;
                        attachmentIntegerFormatMask &= ~(1u << i);
                    }
                }

                var colorBlendState = new PipelineColorBlendStateCreateInfo
=======
                    MaxDepthBounds = MaxDepthBounds
                };

                var colorBlendState = new PipelineColorBlendStateCreateInfo()
>>>>>>> 1ec71635b (sync with main branch)
                {
                    SType = StructureType.PipelineColorBlendStateCreateInfo,
                    LogicOpEnable = LogicOpEnable,
                    LogicOp = LogicOp,
                    AttachmentCount = ColorBlendAttachmentStateCount,
<<<<<<< HEAD
                    PAttachments = pColorBlendAttachmentState,
=======
                    PAttachments = pColorBlendAttachmentState
>>>>>>> 1ec71635b (sync with main branch)
                };

                PipelineColorBlendAdvancedStateCreateInfoEXT colorBlendAdvancedState;

                if (!AdvancedBlendSrcPreMultiplied ||
                    !AdvancedBlendDstPreMultiplied ||
                    AdvancedBlendOverlap != BlendOverlapEXT.UncorrelatedExt)
                {
<<<<<<< HEAD
                    colorBlendAdvancedState = new PipelineColorBlendAdvancedStateCreateInfoEXT
=======
                    colorBlendAdvancedState = new PipelineColorBlendAdvancedStateCreateInfoEXT()
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        SType = StructureType.PipelineColorBlendAdvancedStateCreateInfoExt,
                        SrcPremultiplied = AdvancedBlendSrcPreMultiplied,
                        DstPremultiplied = AdvancedBlendDstPreMultiplied,
<<<<<<< HEAD
                        BlendOverlap = AdvancedBlendOverlap,
=======
                        BlendOverlap = AdvancedBlendOverlap
>>>>>>> 1ec71635b (sync with main branch)
                    };

                    colorBlendState.PNext = &colorBlendAdvancedState;
                }

                bool supportsExtDynamicState = gd.Capabilities.SupportsExtendedDynamicState;
                int dynamicStatesCount = supportsExtDynamicState ? 9 : 8;

                DynamicState* dynamicStates = stackalloc DynamicState[dynamicStatesCount];

                dynamicStates[0] = DynamicState.Viewport;
                dynamicStates[1] = DynamicState.Scissor;
                dynamicStates[2] = DynamicState.DepthBias;
                dynamicStates[3] = DynamicState.DepthBounds;
                dynamicStates[4] = DynamicState.StencilCompareMask;
                dynamicStates[5] = DynamicState.StencilWriteMask;
                dynamicStates[6] = DynamicState.StencilReference;
                dynamicStates[7] = DynamicState.BlendConstants;

                if (supportsExtDynamicState)
                {
                    dynamicStates[8] = DynamicState.VertexInputBindingStrideExt;
                }

<<<<<<< HEAD
                var pipelineDynamicStateCreateInfo = new PipelineDynamicStateCreateInfo
                {
                    SType = StructureType.PipelineDynamicStateCreateInfo,
                    DynamicStateCount = (uint)dynamicStatesCount,
                    PDynamicStates = dynamicStates,
                };

                var pipelineCreateInfo = new GraphicsPipelineCreateInfo
=======
                var pipelineDynamicStateCreateInfo = new PipelineDynamicStateCreateInfo()
                {
                    SType = StructureType.PipelineDynamicStateCreateInfo,
                    DynamicStateCount = (uint)dynamicStatesCount,
                    PDynamicStates = dynamicStates
                };

                if (gd.Capabilities.SupportsSubgroupSizeControl)
                {
                    UpdateStageRequiredSubgroupSizes(gd, (int)StagesCount);
                }

                var pipelineCreateInfo = new GraphicsPipelineCreateInfo()
>>>>>>> 1ec71635b (sync with main branch)
                {
                    SType = StructureType.GraphicsPipelineCreateInfo,
                    StageCount = StagesCount,
                    PStages = Stages.Pointer,
                    PVertexInputState = &vertexInputState,
                    PInputAssemblyState = &inputAssemblyState,
                    PTessellationState = &tessellationState,
                    PViewportState = &viewportState,
                    PRasterizationState = &rasterizationState,
                    PMultisampleState = &multisampleState,
                    PDepthStencilState = &depthStencilState,
                    PColorBlendState = &colorBlendState,
                    PDynamicState = &pipelineDynamicStateCreateInfo,
                    Layout = PipelineLayout,
                    RenderPass = renderPass,
<<<<<<< HEAD
                    BasePipelineIndex = -1,
                };

                Result result = gd.Api.CreateGraphicsPipelines(device, cache, 1, &pipelineCreateInfo, null, &pipelineHandle);

                if (throwOnError)
                {
                    result.ThrowOnError();
                }
                else if (result.IsError())
                {
                    program.AddGraphicsPipeline(ref Internal, null);

                    return null;
                }

                // Restore previous blend enable values if we changed it.
                while (blendEnables != 0)
                {
                    int i = BitOperations.TrailingZeroCount(blendEnables);

                    Internal.ColorBlendAttachmentState[i].BlendEnable = true;
                    blendEnables &= ~(1u << i);
                }
=======
                    BasePipelineIndex = -1
                };

                gd.Api.CreateGraphicsPipelines(device, cache, 1, &pipelineCreateInfo, null, &pipelineHandle).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }

            pipeline = new Auto<DisposablePipeline>(new DisposablePipeline(gd.Api, device, pipelineHandle));

            program.AddGraphicsPipeline(ref Internal, pipeline);

            return pipeline;
        }

<<<<<<< HEAD
        private void UpdateVertexAttributeDescriptions(VulkanRenderer gd)
=======
        private unsafe void UpdateStageRequiredSubgroupSizes(VulkanRenderer gd, int count)
        {
            for (int index = 0; index < count; index++)
            {
                bool canUseExplicitSubgroupSize =
                    (gd.Capabilities.RequiredSubgroupSizeStages & Stages[index].Stage) != 0 &&
                    gd.Capabilities.MinSubgroupSize <= RequiredSubgroupSize &&
                    gd.Capabilities.MaxSubgroupSize >= RequiredSubgroupSize;

                Stages[index].PNext = canUseExplicitSubgroupSize ? StageRequiredSubgroupSizes.Pointer + index : null;
            }
        }

        private void UpdateVertexAttributeDescriptions()
>>>>>>> 1ec71635b (sync with main branch)
        {
            // Vertex attributes exceeding the stride are invalid.
            // In metal, they cause glitches with the vertex shader fetching incorrect values.
            // To work around this, we reduce the format to something that doesn't exceed the stride if possible.
            // The assumption is that the exceeding components are not actually accessed on the shader.

            for (int index = 0; index < VertexAttributeDescriptionsCount; index++)
            {
                var attribute = Internal.VertexAttributeDescriptions[index];
<<<<<<< HEAD
                int vbIndex = GetVertexBufferIndex(attribute.Binding);

                if (vbIndex >= 0)
                {
                    ref var vb = ref Internal.VertexBindingDescriptions[vbIndex];

                    Format format = attribute.Format;

                    while (vb.Stride != 0 && attribute.Offset + FormatTable.GetAttributeFormatSize(format) > vb.Stride)
                    {
                        Format newFormat = FormatTable.DropLastComponent(format);

                        if (newFormat == format)
                        {
                            // That case means we failed to find a format that fits within the stride,
                            // so just restore the original format and give up.
                            format = attribute.Format;
                            break;
                        }

                        format = newFormat;
                    }

                    if (attribute.Format != format && gd.FormatCapabilities.BufferFormatSupports(FormatFeatureFlags.VertexBufferBit, format))
                    {
                        attribute.Format = format;
                    }
                }

=======
                ref var vb = ref Internal.VertexBindingDescriptions[(int)attribute.Binding];

                Format format = attribute.Format;

                while (vb.Stride != 0 && attribute.Offset + FormatTable.GetAttributeFormatSize(format) > vb.Stride)
                {
                    Format newFormat = FormatTable.DropLastComponent(format);

                    if (newFormat == format)
                    {
                        // That case means we failed to find a format that fits within the stride,
                        // so just restore the original format and give up.
                        format = attribute.Format;
                        break;
                    }

                    format = newFormat;
                }

                attribute.Format = format;
>>>>>>> 1ec71635b (sync with main branch)
                _vertexAttributeDescriptions2[index] = attribute;
            }
        }

<<<<<<< HEAD
        private int GetVertexBufferIndex(uint binding)
        {
            for (int index = 0; index < VertexBindingDescriptionsCount; index++)
            {
                if (Internal.VertexBindingDescriptions[index].Binding == binding)
                {
                    return index;
                }
            }

            return -1;
        }

        public readonly void Dispose()
        {
            Stages.Dispose();
=======
        public void Dispose()
        {
            Stages.Dispose();
            StageRequiredSubgroupSizes.Dispose();
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
