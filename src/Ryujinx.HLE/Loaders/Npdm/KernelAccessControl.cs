<<<<<<< HEAD
using System.IO;
=======
﻿using System.IO;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.Loaders.Npdm
{
    public class KernelAccessControl
    {
        public int[] Capabilities { get; private set; }

        public KernelAccessControl(Stream stream, int offset, int size)
        {
            stream.Seek(offset, SeekOrigin.Begin);

            Capabilities = new int[size / 4];

<<<<<<< HEAD
            BinaryReader reader = new(stream);
=======
            BinaryReader reader = new BinaryReader(stream);
>>>>>>> 1ec71635b (sync with main branch)

            for (int index = 0; index < Capabilities.Length; index++)
            {
                Capabilities[index] = reader.ReadInt32();
            }
        }
    }
}
