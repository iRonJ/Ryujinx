<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Sampler
{
    struct SamplerDisposeCommand : IGALCommand, IGALCommand<SamplerDisposeCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SamplerDispose;
=======
        public CommandType CommandType => CommandType.SamplerDispose;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedSampler> _sampler;

        public void Set(TableRef<ThreadedSampler> sampler)
        {
            _sampler = sampler;
        }

        public static void Run(ref SamplerDisposeCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            command._sampler.Get(threaded).Base.Dispose();
        }
    }
}
