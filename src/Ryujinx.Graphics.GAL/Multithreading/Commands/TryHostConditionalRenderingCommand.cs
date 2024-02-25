<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct TryHostConditionalRenderingCommand : IGALCommand, IGALCommand<TryHostConditionalRenderingCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.TryHostConditionalRendering;
=======
        public CommandType CommandType => CommandType.TryHostConditionalRendering;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedCounterEvent> _value;
        private ulong _compare;
        private bool _isEqual;

        public void Set(TableRef<ThreadedCounterEvent> value, ulong compare, bool isEqual)
        {
            _value = value;
            _compare = compare;
            _isEqual = isEqual;
        }

        public static void Run(ref TryHostConditionalRenderingCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.TryHostConditionalRendering(command._value.Get(threaded)?.Base, command._compare, command._isEqual);
        }
    }
}
