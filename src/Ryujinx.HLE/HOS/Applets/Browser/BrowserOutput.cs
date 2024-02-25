<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.IO;

namespace Ryujinx.HLE.HOS.Applets.Browser
{
    class BrowserOutput
    {
        public BrowserOutputType Type { get; }
        public byte[] Value { get; }

        public BrowserOutput(BrowserOutputType type, byte[] value)
        {
<<<<<<< HEAD
            Type = type;
=======
            Type  = type;
>>>>>>> 1ec71635b (sync with main branch)
            Value = value;
        }

        public BrowserOutput(BrowserOutputType type, uint value)
        {
<<<<<<< HEAD
            Type = type;
            Value = BitConverter.GetBytes(value);
=======
            Type  = type;
            Value = BitConverter.GetBytes(value); 
>>>>>>> 1ec71635b (sync with main branch)
        }

        public BrowserOutput(BrowserOutputType type, ulong value)
        {
<<<<<<< HEAD
            Type = type;
=======
            Type  = type;
>>>>>>> 1ec71635b (sync with main branch)
            Value = BitConverter.GetBytes(value);
        }

        public BrowserOutput(BrowserOutputType type, bool value)
        {
<<<<<<< HEAD
            Type = type;
=======
            Type  = type;
>>>>>>> 1ec71635b (sync with main branch)
            Value = BitConverter.GetBytes(value);
        }

        public void Write(BinaryWriter writer)
        {
            writer.WriteStruct(new WebArgTLV
            {
                Type = (ushort)Type,
<<<<<<< HEAD
                Size = (ushort)Value.Length,
=======
                Size = (ushort)Value.Length
>>>>>>> 1ec71635b (sync with main branch)
            });

            writer.Write(Value);
        }
    }
}
