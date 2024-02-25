<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct BeginTransformFeedbackCommand : IGALCommand, IGALCommand<BeginTransformFeedbackCommand>
    {
        public readonly CommandType CommandType => CommandType.BeginTransformFeedback;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct BeginTransformFeedbackCommand : IGALCommand, IGALCommand<BeginTransformFeedbackCommand>
    {
        public CommandType CommandType => CommandType.BeginTransformFeedback;
>>>>>>> 1ec71635b (sync with main branch)
        private PrimitiveTopology _topology;

        public void Set(PrimitiveTopology topology)
        {
            _topology = topology;
        }

        public static void Run(ref BeginTransformFeedbackCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.BeginTransformFeedback(command._topology);
        }
    }
}
