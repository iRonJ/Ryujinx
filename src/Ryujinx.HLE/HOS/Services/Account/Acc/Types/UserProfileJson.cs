<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Account.Acc.Types
=======
﻿namespace Ryujinx.HLE.HOS.Services.Account.Acc.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    internal struct UserProfileJson
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public AccountState AccountState { get; set; }
        public AccountState OnlinePlayState { get; set; }
        public long LastModifiedTimestamp { get; set; }
        public byte[] Image { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
