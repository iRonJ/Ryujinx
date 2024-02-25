<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Ryujinx.HLE.Loaders.Npdm
{
    public class ServiceAccessControl
    {
        public IReadOnlyDictionary<string, bool> Services { get; private set; }

        public ServiceAccessControl(Stream stream, int offset, int size)
        {
            stream.Seek(offset, SeekOrigin.Begin);

<<<<<<< HEAD
            BinaryReader reader = new(stream);

            int bytesRead = 0;

            Dictionary<string, bool> services = new();
=======
            BinaryReader reader = new BinaryReader(stream);

            int bytesRead = 0;

            Dictionary<string, bool> services = new Dictionary<string, bool>();
>>>>>>> 1ec71635b (sync with main branch)

            while (bytesRead != size)
            {
                byte controlByte = reader.ReadByte();

                if (controlByte == 0)
                {
                    break;
                }

<<<<<<< HEAD
                int length = (controlByte & 0x07) + 1;
=======
                int  length          = (controlByte & 0x07) + 1;
>>>>>>> 1ec71635b (sync with main branch)
                bool registerAllowed = (controlByte & 0x80) != 0;

                services[Encoding.ASCII.GetString(reader.ReadBytes(length))] = registerAllowed;

                bytesRead += length + 1;
            }

            Services = new ReadOnlyDictionary<string, bool>(services);
        }
    }
}
