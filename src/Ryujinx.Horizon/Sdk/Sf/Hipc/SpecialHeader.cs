<<<<<<< HEAD
using Ryujinx.Common.Utilities;
=======
﻿using Ryujinx.Common.Utilities;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    struct SpecialHeader
    {
        private uint _word;

        public bool SendPid
        {
<<<<<<< HEAD
            readonly get => _word.Extract(0);
=======
            get => _word.Extract(0);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word = _word.Insert(0, value);
        }

        public int CopyHandlesCount
        {
<<<<<<< HEAD
            readonly get => (int)_word.Extract(1, 4);
=======
            get => (int)_word.Extract(1, 4);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word = _word.Insert(1, 4, (uint)value);
        }

        public int MoveHandlesCount
        {
<<<<<<< HEAD
            readonly get => (int)_word.Extract(5, 4);
=======
            get => (int)_word.Extract(5, 4);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word = _word.Insert(5, 4, (uint)value);
        }
    }
}
