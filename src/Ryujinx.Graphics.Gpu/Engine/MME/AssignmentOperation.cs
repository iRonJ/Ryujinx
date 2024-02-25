<<<<<<< HEAD
namespace Ryujinx.Graphics.Gpu.Engine.MME
=======
﻿namespace Ryujinx.Graphics.Gpu.Engine.MME
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// GPU Macro assignment operation.
    /// </summary>
    enum AssignmentOperation
    {
        IgnoreAndFetch = 0,
        Move = 1,
        MoveAndSetMaddr = 2,
        FetchAndSend = 3,
        MoveAndSend = 4,
        FetchAndSetMaddr = 5,
        MoveAndSetMaddrThenFetchAndSend = 6,
<<<<<<< HEAD
        MoveAndSetMaddrThenSendHigh = 7,
=======
        MoveAndSetMaddrThenSendHigh = 7
>>>>>>> 1ec71635b (sync with main branch)
    }
}
