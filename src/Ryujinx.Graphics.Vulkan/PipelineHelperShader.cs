<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using VkFormat = Silk.NET.Vulkan.Format;

namespace Ryujinx.Graphics.Vulkan
{
    class PipelineHelperShader : PipelineBase
    {
        public PipelineHelperShader(VulkanRenderer gd, Device device) : base(gd, device)
        {
        }

<<<<<<< HEAD
        public void SetRenderTarget(TextureView view, uint width, uint height)
        {
            CreateFramebuffer(view, width, height);
=======
        public void SetRenderTarget(Auto<DisposableImageView> view, uint width, uint height, bool isDepthStencil, VkFormat format)
        {
            SetRenderTarget(view, width, height, 1u, isDepthStencil, format);
        }

        public void SetRenderTarget(Auto<DisposableImageView> view, uint width, uint height, uint samples, bool isDepthStencil, VkFormat format)
        {
            CreateFramebuffer(view, width, height, samples, isDepthStencil, format);
>>>>>>> 1ec71635b (sync with main branch)
            CreateRenderPass();
            SignalStateChange();
        }

<<<<<<< HEAD
        private void CreateFramebuffer(TextureView view, uint width, uint height)
        {
            FramebufferParams = new FramebufferParams(Device, view, width, height);
=======
        private void CreateFramebuffer(Auto<DisposableImageView> view, uint width, uint height, uint samples, bool isDepthStencil, VkFormat format)
        {
            FramebufferParams = new FramebufferParams(Device, view, width, height, samples, isDepthStencil, format);
>>>>>>> 1ec71635b (sync with main branch)
            UpdatePipelineAttachmentFormats();
        }

        public void SetCommandBuffer(CommandBufferScoped cbs)
        {
            CommandBuffer = (Cbs = cbs).CommandBuffer;

            // Restore per-command buffer state.

            if (Pipeline != null)
            {
                Gd.Api.CmdBindPipeline(CommandBuffer, Pbp, Pipeline.Get(CurrentCommandBuffer).Value);
            }

            SignalCommandBufferChange();
        }

        public void Finish()
        {
            EndRenderPass();
        }

        public void Finish(VulkanRenderer gd, CommandBufferScoped cbs)
        {
            Finish();

            if (gd.PipelineInternal.IsCommandBufferActive(cbs.CommandBuffer))
            {
                gd.PipelineInternal.Restore();
            }
        }
    }
}
