<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Ro
{
    class NrrInfo
    {
<<<<<<< HEAD
        public NrrHeader Header { get; private set; }
        public List<byte[]> Hashes { get; private set; }
        public ulong NrrAddress { get; private set; }
=======
        public NrrHeader    Header     { get; private set; }
        public List<byte[]> Hashes     { get; private set; }
        public ulong        NrrAddress { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public NrrInfo(ulong nrrAddress, NrrHeader header, List<byte[]> hashes)
        {
            NrrAddress = nrrAddress;
<<<<<<< HEAD
            Header = header;
            Hashes = hashes;
        }
    }
}
=======
            Header     = header;
            Hashes     = hashes;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
