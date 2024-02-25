<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Commands.Sampler;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Commands.Sampler;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Model;

namespace Ryujinx.Graphics.GAL.Multithreading.Resources
{
    class ThreadedSampler : ISampler
    {
<<<<<<< HEAD
        private readonly ThreadedRenderer _renderer;
=======
        private ThreadedRenderer _renderer;
>>>>>>> 1ec71635b (sync with main branch)
        public ISampler Base;

        public ThreadedSampler(ThreadedRenderer renderer)
        {
            _renderer = renderer;
        }

        public void Dispose()
        {
            _renderer.New<SamplerDisposeCommand>().Set(new TableRef<ThreadedSampler>(_renderer, this));
            _renderer.QueueCommand();
        }
    }
}
