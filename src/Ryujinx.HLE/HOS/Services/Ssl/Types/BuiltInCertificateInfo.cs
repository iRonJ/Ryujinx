<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Ssl.Types
=======
﻿namespace Ryujinx.HLE.HOS.Services.Ssl.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    struct BuiltInCertificateInfo
    {
        public CaCertificateId Id;
        public TrustedCertStatus Status;
        public ulong CertificateDataSize;
        public ulong CertificateDataOffset;
    }
}
