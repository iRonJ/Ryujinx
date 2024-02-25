using System;
using System.Runtime.CompilerServices;

namespace Ryujinx.HLE.Exceptions
{
<<<<<<< HEAD
    public class InvalidStructLayoutException<T> : Exception
=======
    public class InvalidStructLayoutException<T> : Exception 
>>>>>>> 1ec71635b (sync with main branch)
    {
        static readonly Type _structType = typeof(T);

        public InvalidStructLayoutException(string message) : base(message) { }
<<<<<<< HEAD

        public InvalidStructLayoutException(int expectedSize)
            : base($"Type {_structType.Name} has the wrong size. Expected: {expectedSize} bytes, got: {Unsafe.SizeOf<T>()} bytes") { }
    }
}
=======
        
        public InvalidStructLayoutException(int expectedSize)
            : base($"Type {_structType.Name} has the wrong size. Expected: {expectedSize} bytes, got: {Unsafe.SizeOf<T>()} bytes") { }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
