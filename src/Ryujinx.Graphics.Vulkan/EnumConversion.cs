<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.Shader;
using Silk.NET.Vulkan;
using System;
<<<<<<< HEAD
using BlendFactor = Silk.NET.Vulkan.BlendFactor;
using BlendOp = Silk.NET.Vulkan.BlendOp;
using CompareOp = Silk.NET.Vulkan.CompareOp;
using Format = Ryujinx.Graphics.GAL.Format;
using FrontFace = Silk.NET.Vulkan.FrontFace;
using IndexType = Silk.NET.Vulkan.IndexType;
using PrimitiveTopology = Silk.NET.Vulkan.PrimitiveTopology;
using StencilOp = Silk.NET.Vulkan.StencilOp;
=======
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    static class EnumConversion
    {
        public static ShaderStageFlags Convert(this ShaderStage stage)
        {
            return stage switch
            {
                ShaderStage.Vertex => ShaderStageFlags.VertexBit,
                ShaderStage.Geometry => ShaderStageFlags.GeometryBit,
                ShaderStage.TessellationControl => ShaderStageFlags.TessellationControlBit,
                ShaderStage.TessellationEvaluation => ShaderStageFlags.TessellationEvaluationBit,
                ShaderStage.Fragment => ShaderStageFlags.FragmentBit,
                ShaderStage.Compute => ShaderStageFlags.ComputeBit,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(stage, nameof(ShaderStage), (ShaderStageFlags)0),
=======
                _ => LogInvalidAndReturn(stage, nameof(ShaderStage), (ShaderStageFlags)0)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static PipelineStageFlags ConvertToPipelineStageFlags(this ShaderStage stage)
        {
            return stage switch
            {
                ShaderStage.Vertex => PipelineStageFlags.VertexShaderBit,
                ShaderStage.Geometry => PipelineStageFlags.GeometryShaderBit,
                ShaderStage.TessellationControl => PipelineStageFlags.TessellationControlShaderBit,
                ShaderStage.TessellationEvaluation => PipelineStageFlags.TessellationEvaluationShaderBit,
                ShaderStage.Fragment => PipelineStageFlags.FragmentShaderBit,
                ShaderStage.Compute => PipelineStageFlags.ComputeShaderBit,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(stage, nameof(ShaderStage), (PipelineStageFlags)0),
=======
                _ => LogInvalidAndReturn(stage, nameof(ShaderStage), (PipelineStageFlags)0)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static ShaderStageFlags Convert(this ResourceStages stages)
        {
            ShaderStageFlags stageFlags = stages.HasFlag(ResourceStages.Compute)
                ? ShaderStageFlags.ComputeBit
                : ShaderStageFlags.None;

            if (stages.HasFlag(ResourceStages.Vertex))
            {
                stageFlags |= ShaderStageFlags.VertexBit;
            }

            if (stages.HasFlag(ResourceStages.TessellationControl))
            {
                stageFlags |= ShaderStageFlags.TessellationControlBit;
            }

            if (stages.HasFlag(ResourceStages.TessellationEvaluation))
            {
                stageFlags |= ShaderStageFlags.TessellationEvaluationBit;
            }

            if (stages.HasFlag(ResourceStages.Geometry))
            {
                stageFlags |= ShaderStageFlags.GeometryBit;
            }

            if (stages.HasFlag(ResourceStages.Fragment))
            {
                stageFlags |= ShaderStageFlags.FragmentBit;
            }

            return stageFlags;
        }

        public static DescriptorType Convert(this ResourceType type)
        {
            return type switch
            {
                ResourceType.UniformBuffer => DescriptorType.UniformBuffer,
                ResourceType.StorageBuffer => DescriptorType.StorageBuffer,
                ResourceType.Texture => DescriptorType.SampledImage,
                ResourceType.Sampler => DescriptorType.Sampler,
                ResourceType.TextureAndSampler => DescriptorType.CombinedImageSampler,
                ResourceType.Image => DescriptorType.StorageImage,
                ResourceType.BufferTexture => DescriptorType.UniformTexelBuffer,
                ResourceType.BufferImage => DescriptorType.StorageTexelBuffer,
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid resource type \"{type}\"."),
=======
                _ => throw new ArgumentException($"Invalid resource type \"{type}\".")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static SamplerAddressMode Convert(this AddressMode mode)
        {
            return mode switch
            {
                AddressMode.Clamp => SamplerAddressMode.ClampToEdge, // TODO: Should be clamp.
                AddressMode.Repeat => SamplerAddressMode.Repeat,
                AddressMode.MirrorClamp => SamplerAddressMode.ClampToEdge, // TODO: Should be mirror clamp.
                AddressMode.MirrorClampToEdge => SamplerAddressMode.MirrorClampToEdgeKhr,
                AddressMode.MirrorClampToBorder => SamplerAddressMode.ClampToBorder, // TODO: Should be mirror clamp to border.
                AddressMode.ClampToBorder => SamplerAddressMode.ClampToBorder,
                AddressMode.MirroredRepeat => SamplerAddressMode.MirroredRepeat,
                AddressMode.ClampToEdge => SamplerAddressMode.ClampToEdge,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(mode, nameof(AddressMode), SamplerAddressMode.ClampToEdge), // TODO: Should be clamp.
            };
        }

        public static BlendFactor Convert(this GAL.BlendFactor factor)
        {
            return factor switch
            {
                GAL.BlendFactor.Zero or GAL.BlendFactor.ZeroGl => BlendFactor.Zero,
                GAL.BlendFactor.One or GAL.BlendFactor.OneGl => BlendFactor.One,
                GAL.BlendFactor.SrcColor or GAL.BlendFactor.SrcColorGl => BlendFactor.SrcColor,
                GAL.BlendFactor.OneMinusSrcColor or GAL.BlendFactor.OneMinusSrcColorGl => BlendFactor.OneMinusSrcColor,
                GAL.BlendFactor.SrcAlpha or GAL.BlendFactor.SrcAlphaGl => BlendFactor.SrcAlpha,
                GAL.BlendFactor.OneMinusSrcAlpha or GAL.BlendFactor.OneMinusSrcAlphaGl => BlendFactor.OneMinusSrcAlpha,
                GAL.BlendFactor.DstAlpha or GAL.BlendFactor.DstAlphaGl => BlendFactor.DstAlpha,
                GAL.BlendFactor.OneMinusDstAlpha or GAL.BlendFactor.OneMinusDstAlphaGl => BlendFactor.OneMinusDstAlpha,
                GAL.BlendFactor.DstColor or GAL.BlendFactor.DstColorGl => BlendFactor.DstColor,
                GAL.BlendFactor.OneMinusDstColor or GAL.BlendFactor.OneMinusDstColorGl => BlendFactor.OneMinusDstColor,
                GAL.BlendFactor.SrcAlphaSaturate or GAL.BlendFactor.SrcAlphaSaturateGl => BlendFactor.SrcAlphaSaturate,
                GAL.BlendFactor.Src1Color or GAL.BlendFactor.Src1ColorGl => BlendFactor.Src1Color,
                GAL.BlendFactor.OneMinusSrc1Color or GAL.BlendFactor.OneMinusSrc1ColorGl => BlendFactor.OneMinusSrc1Color,
                GAL.BlendFactor.Src1Alpha or GAL.BlendFactor.Src1AlphaGl => BlendFactor.Src1Alpha,
                GAL.BlendFactor.OneMinusSrc1Alpha or GAL.BlendFactor.OneMinusSrc1AlphaGl => BlendFactor.OneMinusSrc1Alpha,
                GAL.BlendFactor.ConstantColor => BlendFactor.ConstantColor,
                GAL.BlendFactor.OneMinusConstantColor => BlendFactor.OneMinusConstantColor,
                GAL.BlendFactor.ConstantAlpha => BlendFactor.ConstantAlpha,
                GAL.BlendFactor.OneMinusConstantAlpha => BlendFactor.OneMinusConstantAlpha,
                _ => LogInvalidAndReturn(factor, nameof(GAL.BlendFactor), BlendFactor.Zero),
            };
        }

        public static BlendOp Convert(this AdvancedBlendOp op)
        {
            return op switch
            {
                AdvancedBlendOp.Zero => BlendOp.ZeroExt,
                AdvancedBlendOp.Src => BlendOp.SrcExt,
                AdvancedBlendOp.Dst => BlendOp.DstExt,
                AdvancedBlendOp.SrcOver => BlendOp.SrcOverExt,
                AdvancedBlendOp.DstOver => BlendOp.DstOverExt,
                AdvancedBlendOp.SrcIn => BlendOp.SrcInExt,
                AdvancedBlendOp.DstIn => BlendOp.DstInExt,
                AdvancedBlendOp.SrcOut => BlendOp.SrcOutExt,
                AdvancedBlendOp.DstOut => BlendOp.DstOutExt,
                AdvancedBlendOp.SrcAtop => BlendOp.SrcAtopExt,
                AdvancedBlendOp.DstAtop => BlendOp.DstAtopExt,
                AdvancedBlendOp.Xor => BlendOp.XorExt,
                AdvancedBlendOp.Plus => BlendOp.PlusExt,
                AdvancedBlendOp.PlusClamped => BlendOp.PlusClampedExt,
                AdvancedBlendOp.PlusClampedAlpha => BlendOp.PlusClampedAlphaExt,
                AdvancedBlendOp.PlusDarker => BlendOp.PlusDarkerExt,
                AdvancedBlendOp.Multiply => BlendOp.MultiplyExt,
                AdvancedBlendOp.Screen => BlendOp.ScreenExt,
                AdvancedBlendOp.Overlay => BlendOp.OverlayExt,
                AdvancedBlendOp.Darken => BlendOp.DarkenExt,
                AdvancedBlendOp.Lighten => BlendOp.LightenExt,
                AdvancedBlendOp.ColorDodge => BlendOp.ColordodgeExt,
                AdvancedBlendOp.ColorBurn => BlendOp.ColorburnExt,
                AdvancedBlendOp.HardLight => BlendOp.HardlightExt,
                AdvancedBlendOp.SoftLight => BlendOp.SoftlightExt,
                AdvancedBlendOp.Difference => BlendOp.DifferenceExt,
                AdvancedBlendOp.Minus => BlendOp.MinusExt,
                AdvancedBlendOp.MinusClamped => BlendOp.MinusClampedExt,
                AdvancedBlendOp.Exclusion => BlendOp.ExclusionExt,
                AdvancedBlendOp.Contrast => BlendOp.ContrastExt,
                AdvancedBlendOp.Invert => BlendOp.InvertExt,
                AdvancedBlendOp.InvertRGB => BlendOp.InvertRgbExt,
                AdvancedBlendOp.InvertOvg => BlendOp.InvertOvgExt,
                AdvancedBlendOp.LinearDodge => BlendOp.LineardodgeExt,
                AdvancedBlendOp.LinearBurn => BlendOp.LinearburnExt,
                AdvancedBlendOp.VividLight => BlendOp.VividlightExt,
                AdvancedBlendOp.LinearLight => BlendOp.LinearlightExt,
                AdvancedBlendOp.PinLight => BlendOp.PinlightExt,
                AdvancedBlendOp.HardMix => BlendOp.HardmixExt,
                AdvancedBlendOp.Red => BlendOp.RedExt,
                AdvancedBlendOp.Green => BlendOp.GreenExt,
                AdvancedBlendOp.Blue => BlendOp.BlueExt,
                AdvancedBlendOp.HslHue => BlendOp.HslHueExt,
                AdvancedBlendOp.HslSaturation => BlendOp.HslSaturationExt,
                AdvancedBlendOp.HslColor => BlendOp.HslColorExt,
                AdvancedBlendOp.HslLuminosity => BlendOp.HslLuminosityExt,
                _ => LogInvalidAndReturn(op, nameof(AdvancedBlendOp), BlendOp.Add),
            };
        }

        public static BlendOp Convert(this GAL.BlendOp op)
        {
            return op switch
            {
                GAL.BlendOp.Add or GAL.BlendOp.AddGl => BlendOp.Add,
                GAL.BlendOp.Subtract or GAL.BlendOp.SubtractGl => BlendOp.Subtract,
                GAL.BlendOp.ReverseSubtract or GAL.BlendOp.ReverseSubtractGl => BlendOp.ReverseSubtract,
                GAL.BlendOp.Minimum or GAL.BlendOp.MinimumGl => BlendOp.Min,
                GAL.BlendOp.Maximum or GAL.BlendOp.MaximumGl => BlendOp.Max,
                _ => LogInvalidAndReturn(op, nameof(GAL.BlendOp), BlendOp.Add),
            };
        }

        public static BlendOverlapEXT Convert(this AdvancedBlendOverlap overlap)
        {
            return overlap switch
            {
                AdvancedBlendOverlap.Uncorrelated => BlendOverlapEXT.UncorrelatedExt,
                AdvancedBlendOverlap.Disjoint => BlendOverlapEXT.DisjointExt,
                AdvancedBlendOverlap.Conjoint => BlendOverlapEXT.ConjointExt,
                _ => LogInvalidAndReturn(overlap, nameof(AdvancedBlendOverlap), BlendOverlapEXT.UncorrelatedExt),
            };
        }

        public static CompareOp Convert(this GAL.CompareOp op)
        {
            return op switch
            {
                GAL.CompareOp.Never or GAL.CompareOp.NeverGl => CompareOp.Never,
                GAL.CompareOp.Less or GAL.CompareOp.LessGl => CompareOp.Less,
                GAL.CompareOp.Equal or GAL.CompareOp.EqualGl => CompareOp.Equal,
                GAL.CompareOp.LessOrEqual or GAL.CompareOp.LessOrEqualGl => CompareOp.LessOrEqual,
                GAL.CompareOp.Greater or GAL.CompareOp.GreaterGl => CompareOp.Greater,
                GAL.CompareOp.NotEqual or GAL.CompareOp.NotEqualGl => CompareOp.NotEqual,
                GAL.CompareOp.GreaterOrEqual or GAL.CompareOp.GreaterOrEqualGl => CompareOp.GreaterOrEqual,
                GAL.CompareOp.Always or GAL.CompareOp.AlwaysGl => CompareOp.Always,
                _ => LogInvalidAndReturn(op, nameof(GAL.CompareOp), CompareOp.Never),
=======
                _ => LogInvalidAndReturn(mode, nameof(AddressMode), SamplerAddressMode.ClampToEdge) // TODO: Should be clamp.
            };
        }

        public static Silk.NET.Vulkan.BlendFactor Convert(this GAL.BlendFactor factor)
        {
            return factor switch
            {
                GAL.BlendFactor.Zero or GAL.BlendFactor.ZeroGl => Silk.NET.Vulkan.BlendFactor.Zero,
                GAL.BlendFactor.One or GAL.BlendFactor.OneGl => Silk.NET.Vulkan.BlendFactor.One,
                GAL.BlendFactor.SrcColor or GAL.BlendFactor.SrcColorGl => Silk.NET.Vulkan.BlendFactor.SrcColor,
                GAL.BlendFactor.OneMinusSrcColor or GAL.BlendFactor.OneMinusSrcColorGl => Silk.NET.Vulkan.BlendFactor.OneMinusSrcColor,
                GAL.BlendFactor.SrcAlpha or GAL.BlendFactor.SrcAlphaGl => Silk.NET.Vulkan.BlendFactor.SrcAlpha,
                GAL.BlendFactor.OneMinusSrcAlpha or GAL.BlendFactor.OneMinusSrcAlphaGl => Silk.NET.Vulkan.BlendFactor.OneMinusSrcAlpha,
                GAL.BlendFactor.DstAlpha or GAL.BlendFactor.DstAlphaGl => Silk.NET.Vulkan.BlendFactor.DstAlpha,
                GAL.BlendFactor.OneMinusDstAlpha or GAL.BlendFactor.OneMinusDstAlphaGl => Silk.NET.Vulkan.BlendFactor.OneMinusDstAlpha,
                GAL.BlendFactor.DstColor or GAL.BlendFactor.DstColorGl => Silk.NET.Vulkan.BlendFactor.DstColor,
                GAL.BlendFactor.OneMinusDstColor or GAL.BlendFactor.OneMinusDstColorGl => Silk.NET.Vulkan.BlendFactor.OneMinusDstColor,
                GAL.BlendFactor.SrcAlphaSaturate or GAL.BlendFactor.SrcAlphaSaturateGl => Silk.NET.Vulkan.BlendFactor.SrcAlphaSaturate,
                GAL.BlendFactor.Src1Color or GAL.BlendFactor.Src1ColorGl => Silk.NET.Vulkan.BlendFactor.Src1Color,
                GAL.BlendFactor.OneMinusSrc1Color or GAL.BlendFactor.OneMinusSrc1ColorGl => Silk.NET.Vulkan.BlendFactor.OneMinusSrc1Color,
                GAL.BlendFactor.Src1Alpha or GAL.BlendFactor.Src1AlphaGl => Silk.NET.Vulkan.BlendFactor.Src1Alpha,
                GAL.BlendFactor.OneMinusSrc1Alpha or GAL.BlendFactor.OneMinusSrc1AlphaGl => Silk.NET.Vulkan.BlendFactor.OneMinusSrc1Alpha,
                GAL.BlendFactor.ConstantColor => Silk.NET.Vulkan.BlendFactor.ConstantColor,
                GAL.BlendFactor.OneMinusConstantColor => Silk.NET.Vulkan.BlendFactor.OneMinusConstantColor,
                GAL.BlendFactor.ConstantAlpha => Silk.NET.Vulkan.BlendFactor.ConstantAlpha,
                GAL.BlendFactor.OneMinusConstantAlpha => Silk.NET.Vulkan.BlendFactor.OneMinusConstantAlpha,
                _ => LogInvalidAndReturn(factor, nameof(GAL.BlendFactor), Silk.NET.Vulkan.BlendFactor.Zero)
            };
        }

        public static Silk.NET.Vulkan.BlendOp Convert(this GAL.AdvancedBlendOp op)
        {
            return op switch
            {
                GAL.AdvancedBlendOp.Zero => Silk.NET.Vulkan.BlendOp.ZeroExt,
                GAL.AdvancedBlendOp.Src => Silk.NET.Vulkan.BlendOp.SrcExt,
                GAL.AdvancedBlendOp.Dst => Silk.NET.Vulkan.BlendOp.DstExt,
                GAL.AdvancedBlendOp.SrcOver => Silk.NET.Vulkan.BlendOp.SrcOverExt,
                GAL.AdvancedBlendOp.DstOver => Silk.NET.Vulkan.BlendOp.DstOverExt,
                GAL.AdvancedBlendOp.SrcIn => Silk.NET.Vulkan.BlendOp.SrcInExt,
                GAL.AdvancedBlendOp.DstIn => Silk.NET.Vulkan.BlendOp.DstInExt,
                GAL.AdvancedBlendOp.SrcOut => Silk.NET.Vulkan.BlendOp.SrcOutExt,
                GAL.AdvancedBlendOp.DstOut => Silk.NET.Vulkan.BlendOp.DstOutExt,
                GAL.AdvancedBlendOp.SrcAtop => Silk.NET.Vulkan.BlendOp.SrcAtopExt,
                GAL.AdvancedBlendOp.DstAtop => Silk.NET.Vulkan.BlendOp.DstAtopExt,
                GAL.AdvancedBlendOp.Xor => Silk.NET.Vulkan.BlendOp.XorExt,
                GAL.AdvancedBlendOp.Plus => Silk.NET.Vulkan.BlendOp.PlusExt,
                GAL.AdvancedBlendOp.PlusClamped => Silk.NET.Vulkan.BlendOp.PlusClampedExt,
                GAL.AdvancedBlendOp.PlusClampedAlpha => Silk.NET.Vulkan.BlendOp.PlusClampedAlphaExt,
                GAL.AdvancedBlendOp.PlusDarker => Silk.NET.Vulkan.BlendOp.PlusDarkerExt,
                GAL.AdvancedBlendOp.Multiply => Silk.NET.Vulkan.BlendOp.MultiplyExt,
                GAL.AdvancedBlendOp.Screen => Silk.NET.Vulkan.BlendOp.ScreenExt,
                GAL.AdvancedBlendOp.Overlay => Silk.NET.Vulkan.BlendOp.OverlayExt,
                GAL.AdvancedBlendOp.Darken => Silk.NET.Vulkan.BlendOp.DarkenExt,
                GAL.AdvancedBlendOp.Lighten => Silk.NET.Vulkan.BlendOp.LightenExt,
                GAL.AdvancedBlendOp.ColorDodge => Silk.NET.Vulkan.BlendOp.ColordodgeExt,
                GAL.AdvancedBlendOp.ColorBurn => Silk.NET.Vulkan.BlendOp.ColorburnExt,
                GAL.AdvancedBlendOp.HardLight => Silk.NET.Vulkan.BlendOp.HardlightExt,
                GAL.AdvancedBlendOp.SoftLight => Silk.NET.Vulkan.BlendOp.SoftlightExt,
                GAL.AdvancedBlendOp.Difference => Silk.NET.Vulkan.BlendOp.DifferenceExt,
                GAL.AdvancedBlendOp.Minus => Silk.NET.Vulkan.BlendOp.MinusExt,
                GAL.AdvancedBlendOp.MinusClamped => Silk.NET.Vulkan.BlendOp.MinusClampedExt,
                GAL.AdvancedBlendOp.Exclusion => Silk.NET.Vulkan.BlendOp.ExclusionExt,
                GAL.AdvancedBlendOp.Contrast => Silk.NET.Vulkan.BlendOp.ContrastExt,
                GAL.AdvancedBlendOp.Invert => Silk.NET.Vulkan.BlendOp.InvertExt,
                GAL.AdvancedBlendOp.InvertRGB => Silk.NET.Vulkan.BlendOp.InvertRgbExt,
                GAL.AdvancedBlendOp.InvertOvg => Silk.NET.Vulkan.BlendOp.InvertOvgExt,
                GAL.AdvancedBlendOp.LinearDodge => Silk.NET.Vulkan.BlendOp.LineardodgeExt,
                GAL.AdvancedBlendOp.LinearBurn => Silk.NET.Vulkan.BlendOp.LinearburnExt,
                GAL.AdvancedBlendOp.VividLight => Silk.NET.Vulkan.BlendOp.VividlightExt,
                GAL.AdvancedBlendOp.LinearLight => Silk.NET.Vulkan.BlendOp.LinearlightExt,
                GAL.AdvancedBlendOp.PinLight => Silk.NET.Vulkan.BlendOp.PinlightExt,
                GAL.AdvancedBlendOp.HardMix => Silk.NET.Vulkan.BlendOp.HardmixExt,
                GAL.AdvancedBlendOp.Red => Silk.NET.Vulkan.BlendOp.RedExt,
                GAL.AdvancedBlendOp.Green => Silk.NET.Vulkan.BlendOp.GreenExt,
                GAL.AdvancedBlendOp.Blue => Silk.NET.Vulkan.BlendOp.BlueExt,
                GAL.AdvancedBlendOp.HslHue => Silk.NET.Vulkan.BlendOp.HslHueExt,
                GAL.AdvancedBlendOp.HslSaturation => Silk.NET.Vulkan.BlendOp.HslSaturationExt,
                GAL.AdvancedBlendOp.HslColor => Silk.NET.Vulkan.BlendOp.HslColorExt,
                GAL.AdvancedBlendOp.HslLuminosity => Silk.NET.Vulkan.BlendOp.HslLuminosityExt,
                _ => LogInvalidAndReturn(op, nameof(GAL.AdvancedBlendOp), Silk.NET.Vulkan.BlendOp.Add)
            };
        }

        public static Silk.NET.Vulkan.BlendOp Convert(this GAL.BlendOp op)
        {
            return op switch
            {
                GAL.BlendOp.Add or GAL.BlendOp.AddGl => Silk.NET.Vulkan.BlendOp.Add,
                GAL.BlendOp.Subtract or GAL.BlendOp.SubtractGl => Silk.NET.Vulkan.BlendOp.Subtract,
                GAL.BlendOp.ReverseSubtract or GAL.BlendOp.ReverseSubtractGl => Silk.NET.Vulkan.BlendOp.ReverseSubtract,
                GAL.BlendOp.Minimum or GAL.BlendOp.MinimumGl => Silk.NET.Vulkan.BlendOp.Min,
                GAL.BlendOp.Maximum or GAL.BlendOp.MaximumGl => Silk.NET.Vulkan.BlendOp.Max,
                _ => LogInvalidAndReturn(op, nameof(GAL.BlendOp), Silk.NET.Vulkan.BlendOp.Add)
            };
        }

        public static Silk.NET.Vulkan.BlendOverlapEXT Convert(this GAL.AdvancedBlendOverlap overlap)
        {
            return overlap switch
            {
                GAL.AdvancedBlendOverlap.Uncorrelated => Silk.NET.Vulkan.BlendOverlapEXT.UncorrelatedExt,
                GAL.AdvancedBlendOverlap.Disjoint => Silk.NET.Vulkan.BlendOverlapEXT.DisjointExt,
                GAL.AdvancedBlendOverlap.Conjoint => Silk.NET.Vulkan.BlendOverlapEXT.ConjointExt,
                _ => LogInvalidAndReturn(overlap, nameof(GAL.AdvancedBlendOverlap), Silk.NET.Vulkan.BlendOverlapEXT.UncorrelatedExt)
            };
        }

        public static Silk.NET.Vulkan.CompareOp Convert(this GAL.CompareOp op)
        {
            return op switch
            {
                GAL.CompareOp.Never or GAL.CompareOp.NeverGl => Silk.NET.Vulkan.CompareOp.Never,
                GAL.CompareOp.Less or GAL.CompareOp.LessGl => Silk.NET.Vulkan.CompareOp.Less,
                GAL.CompareOp.Equal or GAL.CompareOp.EqualGl => Silk.NET.Vulkan.CompareOp.Equal,
                GAL.CompareOp.LessOrEqual or GAL.CompareOp.LessOrEqualGl => Silk.NET.Vulkan.CompareOp.LessOrEqual,
                GAL.CompareOp.Greater or GAL.CompareOp.GreaterGl => Silk.NET.Vulkan.CompareOp.Greater,
                GAL.CompareOp.NotEqual or GAL.CompareOp.NotEqualGl => Silk.NET.Vulkan.CompareOp.NotEqual,
                GAL.CompareOp.GreaterOrEqual or GAL.CompareOp.GreaterOrEqualGl => Silk.NET.Vulkan.CompareOp.GreaterOrEqual,
                GAL.CompareOp.Always or GAL.CompareOp.AlwaysGl => Silk.NET.Vulkan.CompareOp.Always,
                _ => LogInvalidAndReturn(op, nameof(GAL.CompareOp), Silk.NET.Vulkan.CompareOp.Never)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static CullModeFlags Convert(this Face face)
        {
            return face switch
            {
                Face.Back => CullModeFlags.BackBit,
                Face.Front => CullModeFlags.FrontBit,
                Face.FrontAndBack => CullModeFlags.FrontAndBack,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(face, nameof(Face), CullModeFlags.BackBit),
            };
        }

        public static FrontFace Convert(this GAL.FrontFace frontFace)
=======
                _ => LogInvalidAndReturn(face, nameof(Face), CullModeFlags.BackBit)
            };
        }

        public static Silk.NET.Vulkan.FrontFace Convert(this GAL.FrontFace frontFace)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // Flipped to account for origin differences.
            return frontFace switch
            {
<<<<<<< HEAD
                GAL.FrontFace.Clockwise => FrontFace.CounterClockwise,
                GAL.FrontFace.CounterClockwise => FrontFace.Clockwise,
                _ => LogInvalidAndReturn(frontFace, nameof(GAL.FrontFace), FrontFace.Clockwise),
            };
        }

        public static IndexType Convert(this GAL.IndexType type)
        {
            return type switch
            {
                GAL.IndexType.UByte => IndexType.Uint8Ext,
                GAL.IndexType.UShort => IndexType.Uint16,
                GAL.IndexType.UInt => IndexType.Uint32,
                _ => LogInvalidAndReturn(type, nameof(GAL.IndexType), IndexType.Uint16),
=======
                GAL.FrontFace.Clockwise => Silk.NET.Vulkan.FrontFace.CounterClockwise,
                GAL.FrontFace.CounterClockwise => Silk.NET.Vulkan.FrontFace.Clockwise,
                _ => LogInvalidAndReturn(frontFace, nameof(GAL.FrontFace), Silk.NET.Vulkan.FrontFace.Clockwise)
            };
        }

        public static Silk.NET.Vulkan.IndexType Convert(this GAL.IndexType type)
        {
            return type switch
            {
                GAL.IndexType.UByte => Silk.NET.Vulkan.IndexType.Uint8Ext,
                GAL.IndexType.UShort => Silk.NET.Vulkan.IndexType.Uint16,
                GAL.IndexType.UInt => Silk.NET.Vulkan.IndexType.Uint32,
                _ => LogInvalidAndReturn(type, nameof(GAL.IndexType), Silk.NET.Vulkan.IndexType.Uint16)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static Filter Convert(this MagFilter filter)
        {
            return filter switch
            {
                MagFilter.Nearest => Filter.Nearest,
                MagFilter.Linear => Filter.Linear,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(filter, nameof(MagFilter), Filter.Nearest),
=======
                _ => LogInvalidAndReturn(filter, nameof(MagFilter), Filter.Nearest)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static (Filter, SamplerMipmapMode) Convert(this MinFilter filter)
        {
            return filter switch
            {
                MinFilter.Nearest => (Filter.Nearest, SamplerMipmapMode.Nearest),
                MinFilter.Linear => (Filter.Linear, SamplerMipmapMode.Nearest),
                MinFilter.NearestMipmapNearest => (Filter.Nearest, SamplerMipmapMode.Nearest),
                MinFilter.LinearMipmapNearest => (Filter.Linear, SamplerMipmapMode.Nearest),
                MinFilter.NearestMipmapLinear => (Filter.Nearest, SamplerMipmapMode.Linear),
                MinFilter.LinearMipmapLinear => (Filter.Linear, SamplerMipmapMode.Linear),
<<<<<<< HEAD
                _ => LogInvalidAndReturn(filter, nameof(MinFilter), (Filter.Nearest, SamplerMipmapMode.Nearest)),
            };
        }

        public static PrimitiveTopology Convert(this GAL.PrimitiveTopology topology)
        {
            return topology switch
            {
                GAL.PrimitiveTopology.Points => PrimitiveTopology.PointList,
                GAL.PrimitiveTopology.Lines => PrimitiveTopology.LineList,
                GAL.PrimitiveTopology.LineStrip => PrimitiveTopology.LineStrip,
                GAL.PrimitiveTopology.Triangles => PrimitiveTopology.TriangleList,
                GAL.PrimitiveTopology.TriangleStrip => PrimitiveTopology.TriangleStrip,
                GAL.PrimitiveTopology.TriangleFan => PrimitiveTopology.TriangleFan,
                GAL.PrimitiveTopology.LinesAdjacency => PrimitiveTopology.LineListWithAdjacency,
                GAL.PrimitiveTopology.LineStripAdjacency => PrimitiveTopology.LineStripWithAdjacency,
                GAL.PrimitiveTopology.TrianglesAdjacency => PrimitiveTopology.TriangleListWithAdjacency,
                GAL.PrimitiveTopology.TriangleStripAdjacency => PrimitiveTopology.TriangleStripWithAdjacency,
                GAL.PrimitiveTopology.Patches => PrimitiveTopology.PatchList,
                GAL.PrimitiveTopology.Polygon => PrimitiveTopology.TriangleFan,
                GAL.PrimitiveTopology.Quads => throw new NotSupportedException("Quad topology is not available in Vulkan."),
                GAL.PrimitiveTopology.QuadStrip => throw new NotSupportedException("QuadStrip topology is not available in Vulkan."),
                _ => LogInvalidAndReturn(topology, nameof(GAL.PrimitiveTopology), PrimitiveTopology.TriangleList),
            };
        }

        public static StencilOp Convert(this GAL.StencilOp op)
        {
            return op switch
            {
                GAL.StencilOp.Keep or GAL.StencilOp.KeepGl => StencilOp.Keep,
                GAL.StencilOp.Zero or GAL.StencilOp.ZeroGl => StencilOp.Zero,
                GAL.StencilOp.Replace or GAL.StencilOp.ReplaceGl => StencilOp.Replace,
                GAL.StencilOp.IncrementAndClamp or GAL.StencilOp.IncrementAndClampGl => StencilOp.IncrementAndClamp,
                GAL.StencilOp.DecrementAndClamp or GAL.StencilOp.DecrementAndClampGl => StencilOp.DecrementAndClamp,
                GAL.StencilOp.Invert or GAL.StencilOp.InvertGl => StencilOp.Invert,
                GAL.StencilOp.IncrementAndWrap or GAL.StencilOp.IncrementAndWrapGl => StencilOp.IncrementAndWrap,
                GAL.StencilOp.DecrementAndWrap or GAL.StencilOp.DecrementAndWrapGl => StencilOp.DecrementAndWrap,
                _ => LogInvalidAndReturn(op, nameof(GAL.StencilOp), StencilOp.Keep),
=======
                _ => LogInvalidAndReturn(filter, nameof(MinFilter), (Filter.Nearest, SamplerMipmapMode.Nearest))
            };
        }

        public static Silk.NET.Vulkan.PrimitiveTopology Convert(this GAL.PrimitiveTopology topology)
        {
            return topology switch
            {
                GAL.PrimitiveTopology.Points => Silk.NET.Vulkan.PrimitiveTopology.PointList,
                GAL.PrimitiveTopology.Lines => Silk.NET.Vulkan.PrimitiveTopology.LineList,
                GAL.PrimitiveTopology.LineStrip => Silk.NET.Vulkan.PrimitiveTopology.LineStrip,
                GAL.PrimitiveTopology.Triangles => Silk.NET.Vulkan.PrimitiveTopology.TriangleList,
                GAL.PrimitiveTopology.TriangleStrip => Silk.NET.Vulkan.PrimitiveTopology.TriangleStrip,
                GAL.PrimitiveTopology.TriangleFan => Silk.NET.Vulkan.PrimitiveTopology.TriangleFan,
                GAL.PrimitiveTopology.LinesAdjacency => Silk.NET.Vulkan.PrimitiveTopology.LineListWithAdjacency,
                GAL.PrimitiveTopology.LineStripAdjacency => Silk.NET.Vulkan.PrimitiveTopology.LineStripWithAdjacency,
                GAL.PrimitiveTopology.TrianglesAdjacency => Silk.NET.Vulkan.PrimitiveTopology.TriangleListWithAdjacency,
                GAL.PrimitiveTopology.TriangleStripAdjacency => Silk.NET.Vulkan.PrimitiveTopology.TriangleStripWithAdjacency,
                GAL.PrimitiveTopology.Patches => Silk.NET.Vulkan.PrimitiveTopology.PatchList,
                GAL.PrimitiveTopology.Polygon => Silk.NET.Vulkan.PrimitiveTopology.TriangleFan,
                GAL.PrimitiveTopology.Quads => throw new NotSupportedException("Quad topology is not available in Vulkan."),
                GAL.PrimitiveTopology.QuadStrip => throw new NotSupportedException("QuadStrip topology is not available in Vulkan."),
                _ => LogInvalidAndReturn(topology, nameof(GAL.PrimitiveTopology), Silk.NET.Vulkan.PrimitiveTopology.TriangleList)
            };
        }

        public static Silk.NET.Vulkan.StencilOp Convert(this GAL.StencilOp op)
        {
            return op switch
            {
                GAL.StencilOp.Keep or GAL.StencilOp.KeepGl => Silk.NET.Vulkan.StencilOp.Keep,
                GAL.StencilOp.Zero or GAL.StencilOp.ZeroGl => Silk.NET.Vulkan.StencilOp.Zero,
                GAL.StencilOp.Replace or GAL.StencilOp.ReplaceGl => Silk.NET.Vulkan.StencilOp.Replace,
                GAL.StencilOp.IncrementAndClamp or GAL.StencilOp.IncrementAndClampGl => Silk.NET.Vulkan.StencilOp.IncrementAndClamp,
                GAL.StencilOp.DecrementAndClamp or GAL.StencilOp.DecrementAndClampGl => Silk.NET.Vulkan.StencilOp.DecrementAndClamp,
                GAL.StencilOp.Invert or GAL.StencilOp.InvertGl => Silk.NET.Vulkan.StencilOp.Invert,
                GAL.StencilOp.IncrementAndWrap or GAL.StencilOp.IncrementAndWrapGl => Silk.NET.Vulkan.StencilOp.IncrementAndWrap,
                GAL.StencilOp.DecrementAndWrap or GAL.StencilOp.DecrementAndWrapGl => Silk.NET.Vulkan.StencilOp.DecrementAndWrap,
                _ => LogInvalidAndReturn(op, nameof(GAL.StencilOp), Silk.NET.Vulkan.StencilOp.Keep)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static ComponentSwizzle Convert(this SwizzleComponent swizzleComponent)
        {
            return swizzleComponent switch
            {
                SwizzleComponent.Zero => ComponentSwizzle.Zero,
                SwizzleComponent.One => ComponentSwizzle.One,
                SwizzleComponent.Red => ComponentSwizzle.R,
                SwizzleComponent.Green => ComponentSwizzle.G,
                SwizzleComponent.Blue => ComponentSwizzle.B,
                SwizzleComponent.Alpha => ComponentSwizzle.A,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(swizzleComponent, nameof(SwizzleComponent), ComponentSwizzle.Zero),
=======
                _ => LogInvalidAndReturn(swizzleComponent, nameof(SwizzleComponent), ComponentSwizzle.Zero)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static ImageType Convert(this Target target)
        {
            return target switch
            {
                Target.Texture1D or
                Target.Texture1DArray or
                Target.TextureBuffer => ImageType.Type1D,
                Target.Texture2D or
                Target.Texture2DArray or
                Target.Texture2DMultisample or
                Target.Cubemap or
                Target.CubemapArray => ImageType.Type2D,
                Target.Texture3D => ImageType.Type3D,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(target, nameof(Target), ImageType.Type2D),
=======
                _ => LogInvalidAndReturn(target, nameof(Target), ImageType.Type2D)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static ImageViewType ConvertView(this Target target)
        {
            return target switch
            {
                Target.Texture1D => ImageViewType.Type1D,
                Target.Texture2D or Target.Texture2DMultisample => ImageViewType.Type2D,
                Target.Texture3D => ImageViewType.Type3D,
                Target.Texture1DArray => ImageViewType.Type1DArray,
                Target.Texture2DArray => ImageViewType.Type2DArray,
                Target.Cubemap => ImageViewType.TypeCube,
                Target.CubemapArray => ImageViewType.TypeCubeArray,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(target, nameof(Target), ImageViewType.Type2D),
            };
        }

        public static ImageAspectFlags ConvertAspectFlags(this Format format)
        {
            return format switch
            {
                Format.D16Unorm or Format.D32Float or Format.X8UintD24Unorm => ImageAspectFlags.DepthBit,
                Format.S8Uint => ImageAspectFlags.StencilBit,
                Format.D24UnormS8Uint or
                Format.D32FloatS8Uint or
                Format.S8UintD24Unorm => ImageAspectFlags.DepthBit | ImageAspectFlags.StencilBit,
                _ => ImageAspectFlags.ColorBit,
            };
        }

        public static ImageAspectFlags ConvertAspectFlags(this Format format, DepthStencilMode depthStencilMode)
        {
            return format switch
            {
                Format.D16Unorm or Format.D32Float or Format.X8UintD24Unorm => ImageAspectFlags.DepthBit,
                Format.S8Uint => ImageAspectFlags.StencilBit,
                Format.D24UnormS8Uint or
                Format.D32FloatS8Uint or
                Format.S8UintD24Unorm => depthStencilMode == DepthStencilMode.Stencil ? ImageAspectFlags.StencilBit : ImageAspectFlags.DepthBit,
                _ => ImageAspectFlags.ColorBit,
=======
                _ => LogInvalidAndReturn(target, nameof(Target), ImageViewType.Type2D)
            };
        }

        public static ImageAspectFlags ConvertAspectFlags(this GAL.Format format)
        {
            return format switch
            {
                GAL.Format.D16Unorm or GAL.Format.D32Float => ImageAspectFlags.DepthBit,
                GAL.Format.S8Uint => ImageAspectFlags.StencilBit,
                GAL.Format.D24UnormS8Uint or
                GAL.Format.D32FloatS8Uint or
                GAL.Format.S8UintD24Unorm => ImageAspectFlags.DepthBit | ImageAspectFlags.StencilBit,
                _ => ImageAspectFlags.ColorBit
            };
        }

        public static ImageAspectFlags ConvertAspectFlags(this GAL.Format format, DepthStencilMode depthStencilMode)
        {
            return format switch
            {
                GAL.Format.D16Unorm or GAL.Format.D32Float => ImageAspectFlags.DepthBit,
                GAL.Format.S8Uint => ImageAspectFlags.StencilBit,
                GAL.Format.D24UnormS8Uint or
                GAL.Format.D32FloatS8Uint or
                GAL.Format.S8UintD24Unorm => depthStencilMode == DepthStencilMode.Stencil ? ImageAspectFlags.StencilBit : ImageAspectFlags.DepthBit,
                _ => ImageAspectFlags.ColorBit
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static LogicOp Convert(this LogicalOp op)
        {
            return op switch
            {
                LogicalOp.Clear => LogicOp.Clear,
                LogicalOp.And => LogicOp.And,
                LogicalOp.AndReverse => LogicOp.AndReverse,
                LogicalOp.Copy => LogicOp.Copy,
                LogicalOp.AndInverted => LogicOp.AndInverted,
                LogicalOp.Noop => LogicOp.NoOp,
                LogicalOp.Xor => LogicOp.Xor,
                LogicalOp.Or => LogicOp.Or,
                LogicalOp.Nor => LogicOp.Nor,
                LogicalOp.Equiv => LogicOp.Equivalent,
                LogicalOp.Invert => LogicOp.Invert,
                LogicalOp.OrReverse => LogicOp.OrReverse,
                LogicalOp.CopyInverted => LogicOp.CopyInverted,
                LogicalOp.OrInverted => LogicOp.OrInverted,
                LogicalOp.Nand => LogicOp.Nand,
                LogicalOp.Set => LogicOp.Set,
<<<<<<< HEAD
                _ => LogInvalidAndReturn(op, nameof(LogicalOp), LogicOp.Copy),
=======
                _ => LogInvalidAndReturn(op, nameof(LogicalOp), LogicOp.Copy)
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static BufferAllocationType Convert(this BufferAccess access)
        {
<<<<<<< HEAD
            if (access.HasFlag(BufferAccess.FlushPersistent) || access.HasFlag(BufferAccess.Stream))
            {
                return BufferAllocationType.HostMapped;
            }

            return BufferAllocationType.Auto;
=======
            return access switch
            {
                BufferAccess.FlushPersistent => BufferAllocationType.HostMapped,
                _ => BufferAllocationType.Auto
            };
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static T2 LogInvalidAndReturn<T1, T2>(T1 value, string name, T2 defaultValue = default)
        {
            Logger.Debug?.Print(LogClass.Gpu, $"Invalid {name} enum value: {value}.");

            return defaultValue;
        }
    }
}
