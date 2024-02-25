<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct GetCapabilitiesCommand : IGALCommand, IGALCommand<GetCapabilitiesCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.GetCapabilities;
=======
        public CommandType CommandType => CommandType.GetCapabilities;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ResultBox<Capabilities>> _result;

        public void Set(TableRef<ResultBox<Capabilities>> result)
        {
            _result = result;
        }

        public static void Run(ref GetCapabilitiesCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            command._result.Get(threaded).Result = renderer.GetCapabilities();
        }
    }
}
