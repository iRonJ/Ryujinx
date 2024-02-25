<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetFrontFaceCommand : IGALCommand, IGALCommand<SetFrontFaceCommand>
    {
        public readonly CommandType CommandType => CommandType.SetFrontFace;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetFrontFaceCommand : IGALCommand, IGALCommand<SetFrontFaceCommand>
    {
        public CommandType CommandType => CommandType.SetFrontFace;
>>>>>>> 1ec71635b (sync with main branch)
        private FrontFace _frontFace;

        public void Set(FrontFace frontFace)
        {
            _frontFace = frontFace;
        }

        public static void Run(ref SetFrontFaceCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetFrontFace(command._frontFace);
        }
    }
}
