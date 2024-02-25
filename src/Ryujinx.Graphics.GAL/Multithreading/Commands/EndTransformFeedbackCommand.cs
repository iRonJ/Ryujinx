<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct EndTransformFeedbackCommand : IGALCommand, IGALCommand<EndTransformFeedbackCommand>
    {
        public readonly CommandType CommandType => CommandType.EndTransformFeedback;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct EndTransformFeedbackCommand : IGALCommand, IGALCommand<EndTransformFeedbackCommand>
    {
        public CommandType CommandType => CommandType.EndTransformFeedback;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref EndTransformFeedbackCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.EndTransformFeedback();
        }
    }
}
