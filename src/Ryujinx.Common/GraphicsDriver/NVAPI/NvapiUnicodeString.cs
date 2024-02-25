<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)
using System.Text;

namespace Ryujinx.Common.GraphicsDriver.NVAPI
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct NvapiUnicodeString
    {
        private fixed byte _data[4096];

        public NvapiUnicodeString(string text)
        {
            Set(text);
        }

<<<<<<< HEAD
        public readonly string Get()
=======
        public string Get()
>>>>>>> 1ec71635b (sync with main branch)
        {
            fixed (byte* data = _data)
            {
                string text = Encoding.Unicode.GetString(data, 4096);

                int index = text.IndexOf('\0');
                if (index > -1)
                {
                    text = text.Remove(index);
                }

                return text;
            }
        }

<<<<<<< HEAD
        public readonly void Set(string text)
=======
        public void Set(string text)
>>>>>>> 1ec71635b (sync with main branch)
        {
            text += '\0';
            fixed (char* textPtr = text)
            fixed (byte* data = _data)
            {
                int written = Encoding.Unicode.GetBytes(textPtr, text.Length, data, 4096);
            }
        }
    }
}
