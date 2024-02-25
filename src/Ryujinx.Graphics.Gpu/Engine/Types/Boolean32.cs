<<<<<<< HEAD
namespace Ryujinx.Graphics.Gpu.Engine.Types
=======
﻿namespace Ryujinx.Graphics.Gpu.Engine.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Boolean value, stored as a 32-bits integer in memory.
    /// </summary>
<<<<<<< HEAD
    readonly struct Boolean32
    {
        private readonly uint _value;

        public Boolean32(uint value)
        {
            _value = value;
        }
=======
    struct Boolean32
    {
#pragma warning disable CS0649
        private uint _value;
#pragma warning restore CS0649
>>>>>>> 1ec71635b (sync with main branch)

        public static implicit operator bool(Boolean32 value)
        {
            return (value._value & 1) != 0;
        }
    }
}
