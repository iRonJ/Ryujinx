using System;
<<<<<<< HEAD
using System.Runtime.Versioning;

namespace Ryujinx.Memory.WindowsShared
{
    [SupportedOSPlatform("windows")]
=======

namespace Ryujinx.Memory.WindowsShared
{
>>>>>>> 1ec71635b (sync with main branch)
    class WindowsApiException : Exception
    {
        public WindowsApiException()
        {
        }

        public WindowsApiException(string functionName) : base(CreateMessage(functionName))
        {
        }

        public WindowsApiException(string functionName, Exception inner) : base(CreateMessage(functionName), inner)
        {
        }

        private static string CreateMessage(string functionName)
        {
            return $"{functionName} returned error code 0x{WindowsApi.GetLastError():X}.";
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
