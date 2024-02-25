using Ryujinx.Common.Utilities;
using Ryujinx.Horizon.Sdk.Sf.Cmif;

namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    struct Header
    {
        private uint _word0;
        private uint _word1;

        public CommandType Type
        {
<<<<<<< HEAD
            readonly get => (CommandType)_word0.Extract(0, 16);
=======
            get => (CommandType)_word0.Extract(0, 16);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word0 = _word0.Insert(0, 16, (uint)value);
        }

        public int SendStaticsCount
        {
<<<<<<< HEAD
            readonly get => (int)_word0.Extract(16, 4);
=======
            get => (int)_word0.Extract(16, 4);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word0 = _word0.Insert(16, 4, (uint)value);
        }

        public int SendBuffersCount
        {
<<<<<<< HEAD
            readonly get => (int)_word0.Extract(20, 4);
=======
            get => (int)_word0.Extract(20, 4);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word0 = _word0.Insert(20, 4, (uint)value);
        }

        public int ReceiveBuffersCount
        {
<<<<<<< HEAD
            readonly get => (int)_word0.Extract(24, 4);
=======
            get => (int)_word0.Extract(24, 4);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word0 = _word0.Insert(24, 4, (uint)value);
        }

        public int ExchangeBuffersCount
        {
<<<<<<< HEAD
            readonly get => (int)_word0.Extract(28, 4);
=======
            get => (int)_word0.Extract(28, 4);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word0 = _word0.Insert(28, 4, (uint)value);
        }

        public int DataWordsCount
        {
<<<<<<< HEAD
            readonly get => (int)_word1.Extract(0, 10);
=======
            get => (int)_word1.Extract(0, 10);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word1 = _word1.Insert(0, 10, (uint)value);
        }

        public int ReceiveStaticMode
        {
<<<<<<< HEAD
            readonly get => (int)_word1.Extract(10, 4);
=======
            get => (int)_word1.Extract(10, 4);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word1 = _word1.Insert(10, 4, (uint)value);
        }

        public int ReceiveListOffset
        {
<<<<<<< HEAD
            readonly get => (int)_word1.Extract(20, 11);
=======
            get => (int)_word1.Extract(20, 11);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word1 = _word1.Insert(20, 11, (uint)value);
        }

        public bool HasSpecialHeader
        {
<<<<<<< HEAD
            readonly get => _word1.Extract(31);
=======
            get => _word1.Extract(31);
>>>>>>> 1ec71635b (sync with main branch)
            set => _word1 = _word1.Insert(31, value);
        }
    }
}
