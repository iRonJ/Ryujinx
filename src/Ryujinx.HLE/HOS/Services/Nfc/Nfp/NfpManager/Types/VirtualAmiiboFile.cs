<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    struct VirtualAmiiboFile
    {
<<<<<<< HEAD
        public uint FileVersion { get; set; }
        public byte[] TagUuid { get; set; }
        public string AmiiboId { get; set; }
        public DateTime FirstWriteDate { get; set; }
        public DateTime LastWriteDate { get; set; }
        public ushort WriteCounter { get; set; }
=======
        public uint     FileVersion    { get; set; }
        public byte[]   TagUuid        { get; set; }
        public string   AmiiboId       { get; set; }
        public DateTime FirstWriteDate { get; set; }
        public DateTime LastWriteDate  { get; set; }
        public ushort   WriteCounter   { get; set; }
>>>>>>> 1ec71635b (sync with main branch)
        public List<VirtualAmiiboApplicationArea> ApplicationAreas { get; set; }
    }

    struct VirtualAmiiboApplicationArea
    {
<<<<<<< HEAD
        public uint ApplicationAreaId { get; set; }
        public byte[] ApplicationArea { get; set; }
=======
        public uint   ApplicationAreaId { get; set; }
        public byte[] ApplicationArea   { get; set; }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
