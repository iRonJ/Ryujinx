<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
=======
﻿namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    class PollEvent
    {
        public PollEventData Data;
        public IFileDescriptor FileDescriptor { get; }

        public PollEvent(PollEventData data, IFileDescriptor fileDescriptor)
        {
            Data = data;
            FileDescriptor = fileDescriptor;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
