<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using Ryujinx.Graphics.Shader;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetTextureAndSamplerCommand : IGALCommand, IGALCommand<SetTextureAndSamplerCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetTextureAndSampler;
=======
        public CommandType CommandType => CommandType.SetTextureAndSampler;
>>>>>>> 1ec71635b (sync with main branch)
        private ShaderStage _stage;
        private int _binding;
        private TableRef<ITexture> _texture;
        private TableRef<ISampler> _sampler;

        public void Set(ShaderStage stage, int binding, TableRef<ITexture> texture, TableRef<ISampler> sampler)
        {
            _stage = stage;
            _binding = binding;
            _texture = texture;
            _sampler = sampler;
        }

        public static void Run(ref SetTextureAndSamplerCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetTextureAndSampler(command._stage, command._binding, command._texture.GetAs<ThreadedTexture>(threaded)?.Base, command._sampler.GetAs<ThreadedSampler>(threaded)?.Base);
        }
    }
}
