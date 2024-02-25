<<<<<<< HEAD
using Ryujinx.Common.Utilities;

namespace Ryujinx.Graphics.Vic.Types
{
    readonly struct LumaKeyStruct
    {
        private readonly long _word0;
        private readonly long _word1;
=======
﻿using Ryujinx.Common.Utilities;

namespace Ryujinx.Graphics.Vic.Types
{
    struct LumaKeyStruct
    {
        private long _word0;
        private long _word1;
>>>>>>> 1ec71635b (sync with main branch)

        public int LumaCoeff0 => (int)_word0.Extract(0, 20);
        public int LumaCoeff1 => (int)_word0.Extract(20, 20);
        public int LumaCoeff2 => (int)_word0.Extract(40, 20);
        public int LumaRShift => (int)_word0.Extract(60, 4);
        public int LumaCoeff3 => (int)_word1.Extract(64, 20);
        public int LumaKeyLower => (int)_word1.Extract(84, 10);
        public int LumaKeyUpper => (int)_word1.Extract(94, 10);
        public bool LumaKeyEnabled => _word1.Extract(104);
    }
}
