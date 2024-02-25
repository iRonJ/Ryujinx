<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetUserClipDistanceCommand : IGALCommand, IGALCommand<SetUserClipDistanceCommand>
    {
        public readonly CommandType CommandType => CommandType.SetUserClipDistance;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetUserClipDistanceCommand : IGALCommand, IGALCommand<SetUserClipDistanceCommand>
    {
        public CommandType CommandType => CommandType.SetUserClipDistance;
>>>>>>> 1ec71635b (sync with main branch)
        private int _index;
        private bool _enableClip;

        public void Set(int index, bool enableClip)
        {
            _index = index;
            _enableClip = enableClip;
        }

        public static void Run(ref SetUserClipDistanceCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetUserClipDistance(command._index, command._enableClip);
        }
    }
}
