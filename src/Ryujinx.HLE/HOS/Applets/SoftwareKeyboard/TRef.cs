<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
=======
﻿namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Wraps a type in a class so it gets stored in the GC managed heap. This is used as communication mechanism
    /// between classed that need to be disposed and, thus, can't share their references.
    /// </summary>
    /// <typeparam name="T">The internal type.</typeparam>
    class TRef<T>
    {
        public T Value;

        public TRef() { }

        public TRef(T value)
        {
            Value = value;
        }
    }
}
