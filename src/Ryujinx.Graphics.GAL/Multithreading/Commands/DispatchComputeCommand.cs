<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct DispatchComputeCommand : IGALCommand, IGALCommand<DispatchComputeCommand>
    {
        public readonly CommandType CommandType => CommandType.DispatchCompute;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct DispatchComputeCommand : IGALCommand, IGALCommand<DispatchComputeCommand>
    {
        public CommandType CommandType => CommandType.DispatchCompute;
>>>>>>> 1ec71635b (sync with main branch)
        private int _groupsX;
        private int _groupsY;
        private int _groupsZ;

        public void Set(int groupsX, int groupsY, int groupsZ)
        {
            _groupsX = groupsX;
            _groupsY = groupsY;
            _groupsZ = groupsZ;
        }

        public static void Run(ref DispatchComputeCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.DispatchCompute(command._groupsX, command._groupsY, command._groupsZ);
        }
    }
}
