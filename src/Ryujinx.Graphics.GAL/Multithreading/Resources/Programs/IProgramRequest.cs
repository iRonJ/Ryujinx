<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Resources.Programs
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Resources.Programs
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IProgramRequest
    {
        ThreadedProgram Threaded { get; set; }
        IProgram Create(IRenderer renderer);
    }
}
