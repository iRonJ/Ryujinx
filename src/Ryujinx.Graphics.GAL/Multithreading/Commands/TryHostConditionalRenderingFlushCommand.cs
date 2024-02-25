<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct TryHostConditionalRenderingFlushCommand : IGALCommand, IGALCommand<TryHostConditionalRenderingFlushCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.TryHostConditionalRenderingFlush;
=======
        public CommandType CommandType => CommandType.TryHostConditionalRenderingFlush;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedCounterEvent> _value;
        private TableRef<ThreadedCounterEvent> _compare;
        private bool _isEqual;

        public void Set(TableRef<ThreadedCounterEvent> value, TableRef<ThreadedCounterEvent> compare, bool isEqual)
        {
            _value = value;
            _compare = compare;
            _isEqual = isEqual;
        }

        public static void Run(ref TryHostConditionalRenderingFlushCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.TryHostConditionalRendering(command._value.Get(threaded)?.Base, command._compare.Get(threaded)?.Base, command._isEqual);
        }
    }
}
