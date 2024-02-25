<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Commands.Program;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Commands.Program;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Model;

namespace Ryujinx.Graphics.GAL.Multithreading.Resources
{
    class ThreadedProgram : IProgram
    {
<<<<<<< HEAD
        private readonly ThreadedRenderer _renderer;
=======
        private ThreadedRenderer _renderer;
>>>>>>> 1ec71635b (sync with main branch)

        public IProgram Base;

        internal bool Compiled;

        public ThreadedProgram(ThreadedRenderer renderer)
        {
            _renderer = renderer;
        }

        private TableRef<T> Ref<T>(T reference)
        {
            return new TableRef<T>(_renderer, reference);
        }

        public void Dispose()
        {
            _renderer.New<ProgramDisposeCommand>().Set(Ref(this));
            _renderer.QueueCommand();
        }

        public byte[] GetBinary()
        {
<<<<<<< HEAD
            ResultBox<byte[]> box = new();
=======
            ResultBox<byte[]> box = new ResultBox<byte[]>();
>>>>>>> 1ec71635b (sync with main branch)
            _renderer.New<ProgramGetBinaryCommand>().Set(Ref(this), Ref(box));
            _renderer.InvokeCommand();

            return box.Result;
        }

        public ProgramLinkStatus CheckProgramLink(bool blocking)
        {
<<<<<<< HEAD
            ResultBox<ProgramLinkStatus> box = new();
=======
            ResultBox<ProgramLinkStatus> box = new ResultBox<ProgramLinkStatus>();
>>>>>>> 1ec71635b (sync with main branch)
            _renderer.New<ProgramCheckLinkCommand>().Set(Ref(this), blocking, Ref(box));
            _renderer.InvokeCommand();

            return box.Result;
        }
    }
}
