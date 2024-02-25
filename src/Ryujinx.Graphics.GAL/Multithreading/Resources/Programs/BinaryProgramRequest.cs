<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Resources.Programs
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Resources.Programs
>>>>>>> 1ec71635b (sync with main branch)
{
    class BinaryProgramRequest : IProgramRequest
    {
        public ThreadedProgram Threaded { get; set; }

<<<<<<< HEAD
        private readonly byte[] _data;
        private readonly bool _hasFragmentShader;
=======
        private byte[] _data;
        private bool _hasFragmentShader;
>>>>>>> 1ec71635b (sync with main branch)
        private ShaderInfo _info;

        public BinaryProgramRequest(ThreadedProgram program, byte[] data, bool hasFragmentShader, ShaderInfo info)
        {
            Threaded = program;

            _data = data;
            _hasFragmentShader = hasFragmentShader;
            _info = info;
        }

        public IProgram Create(IRenderer renderer)
        {
            return renderer.LoadProgramBinary(_data, _hasFragmentShader, _info);
        }
    }
}
