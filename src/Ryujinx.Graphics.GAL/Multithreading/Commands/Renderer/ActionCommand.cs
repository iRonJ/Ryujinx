<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct ActionCommand : IGALCommand, IGALCommand<ActionCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.Action;
=======
        public CommandType CommandType => CommandType.Action;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<Action> _action;

        public void Set(TableRef<Action> action)
        {
            _action = action;
        }

        public static void Run(ref ActionCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            command._action.Get(threaded)();
        }
    }
}
