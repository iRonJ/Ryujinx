<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x48)]
    struct StoreDataElement : IElement
    {
        public StoreData StoreData;
<<<<<<< HEAD
        public Source Source;
=======
        public Source    Source;
>>>>>>> 1ec71635b (sync with main branch)

        public void SetFromStoreData(StoreData storeData)
        {
            StoreData = storeData;
        }

        public void SetSource(Source source)
        {
            Source = source;
        }
    }
}
