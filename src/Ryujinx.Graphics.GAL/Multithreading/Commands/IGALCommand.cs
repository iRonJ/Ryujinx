<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IGALCommand
    {
        CommandType CommandType { get; }
    }

    interface IGALCommand<T> where T : IGALCommand
    {
        abstract static void Run(ref T command, ThreadedRenderer threaded, IRenderer renderer);
    }
}
