<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
{
    struct PollEventData
    {
#pragma warning disable CS0649 // Field is never assigned to
=======
﻿namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
{
    struct PollEventData
    {
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public int SocketFd;
        public PollEventTypeMask InputEvents;
#pragma warning restore CS0649
        public PollEventTypeMask OutputEvents;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
