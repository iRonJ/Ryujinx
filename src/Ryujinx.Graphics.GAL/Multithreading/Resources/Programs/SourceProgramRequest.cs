<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Resources.Programs
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Resources.Programs
>>>>>>> 1ec71635b (sync with main branch)
{
    class SourceProgramRequest : IProgramRequest
    {
        public ThreadedProgram Threaded { get; set; }

<<<<<<< HEAD
        private readonly ShaderSource[] _shaders;
=======
        private ShaderSource[] _shaders;
>>>>>>> 1ec71635b (sync with main branch)
        private ShaderInfo _info;

        public SourceProgramRequest(ThreadedProgram program, ShaderSource[] shaders, ShaderInfo info)
        {
            Threaded = program;

            _shaders = shaders;
            _info = info;
        }

        public IProgram Create(IRenderer renderer)
        {
            return renderer.CreateProgram(_shaders, _info);
        }
    }
}
