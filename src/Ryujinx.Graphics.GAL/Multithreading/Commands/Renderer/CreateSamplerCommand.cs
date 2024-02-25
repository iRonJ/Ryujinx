<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct CreateSamplerCommand : IGALCommand, IGALCommand<CreateSamplerCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.CreateSampler;
=======
        public CommandType CommandType => CommandType.CreateSampler;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedSampler> _sampler;
        private SamplerCreateInfo _info;

        public void Set(TableRef<ThreadedSampler> sampler, SamplerCreateInfo info)
        {
            _sampler = sampler;
            _info = info;
        }

        public static void Run(ref CreateSamplerCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            command._sampler.Get(threaded).Base = renderer.CreateSampler(command._info);
        }
    }
}
