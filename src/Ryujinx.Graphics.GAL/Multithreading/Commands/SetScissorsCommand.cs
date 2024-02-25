<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetScissorsCommand : IGALCommand, IGALCommand<SetScissorsCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetScissor;
=======
        public CommandType CommandType => CommandType.SetScissor;
>>>>>>> 1ec71635b (sync with main branch)
        private SpanRef<Rectangle<int>> _scissors;

        public void Set(SpanRef<Rectangle<int>> scissors)
        {
            _scissors = scissors;
        }

        public static void Run(ref SetScissorsCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetScissors(command._scissors.Get(threaded));

            command._scissors.Dispose(threaded);
        }
    }
}
