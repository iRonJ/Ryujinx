<<<<<<< HEAD
=======
﻿using Microsoft.IO;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Memory;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Ryujinx.Common.Utilities
{
    public static class StreamUtils
    {
        public static byte[] StreamToBytes(Stream input)
        {
<<<<<<< HEAD
            using MemoryStream stream = MemoryStreamManager.Shared.GetStream();


            input.CopyTo(stream);

            return stream.ToArray();
=======
            using (MemoryStream stream = MemoryStreamManager.Shared.GetStream())
            {
                input.CopyTo(stream);

                return stream.ToArray();
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static async Task<byte[]> StreamToBytesAsync(Stream input, CancellationToken cancellationToken = default)
        {
<<<<<<< HEAD
            using MemoryStream stream = MemoryStreamManager.Shared.GetStream();

            await input.CopyToAsync(stream, cancellationToken);

            return stream.ToArray();
        }
    }
}
=======
            using (MemoryStream stream = MemoryStreamManager.Shared.GetStream())
            {
                await input.CopyToAsync(stream, cancellationToken);

                return stream.ToArray();
            }
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
