<<<<<<< HEAD
namespace Ryujinx.Graphics.Nvdec.Vp9
=======
﻿namespace Ryujinx.Graphics.Nvdec.Vp9
>>>>>>> 1ec71635b (sync with main branch)
{
    internal struct InternalErrorInfo
    {
        public CodecErr ErrorCode;

        public void InternalError(CodecErr error, string message)
        {
            ErrorCode = error;

            throw new InternalErrorException(message);
        }
    }
}
