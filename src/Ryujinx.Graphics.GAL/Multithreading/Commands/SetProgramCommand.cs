<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetProgramCommand : IGALCommand, IGALCommand<SetProgramCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetProgram;
=======
        public CommandType CommandType => CommandType.SetProgram;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<IProgram> _program;

        public void Set(TableRef<IProgram> program)
        {
            _program = program;
        }

        public static void Run(ref SetProgramCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            ThreadedProgram program = command._program.GetAs<ThreadedProgram>(threaded);

            threaded.Programs.WaitForProgram(program);

            renderer.Pipeline.SetProgram(program.Base);
        }
    }
}
