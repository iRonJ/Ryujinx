<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    readonly struct HipcReceiveListEntry
    {
#pragma warning disable IDE0052 // Remove unread private member
        private readonly uint _addressLow;
        private readonly uint _word1;
#pragma warning restore IDE0052
=======
﻿namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    struct HipcReceiveListEntry
    {
        private uint _addressLow;
        private uint _word1;
>>>>>>> 1ec71635b (sync with main branch)

        public HipcReceiveListEntry(ulong address, ulong size)
        {
            _addressLow = (uint)address;
<<<<<<< HEAD
            _word1 = (ushort)(address >> 32) | (uint)(size << 16);
=======
            _word1      = (ushort)(address >> 32) | (uint)(size << 16);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
