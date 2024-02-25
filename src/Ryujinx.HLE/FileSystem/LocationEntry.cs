<<<<<<< HEAD
using LibHac.Tools.FsSystem.NcaUtils;
=======
﻿using LibHac.Tools.FsSystem.NcaUtils;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.FileSystem
{
    public struct LocationEntry
    {
<<<<<<< HEAD
        public string ContentPath { get; private set; }
        public int Flag { get; private set; }
        public ulong TitleId { get; private set; }
=======
        public string         ContentPath { get; private set; }
        public int            Flag        { get; private set; }
        public ulong          TitleId     { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)
        public NcaContentType ContentType { get; private set; }

        public LocationEntry(string contentPath, int flag, ulong titleId, NcaContentType contentType)
        {
            ContentPath = contentPath;
<<<<<<< HEAD
            Flag = flag;
            TitleId = titleId;
=======
            Flag        = flag;
            TitleId     = titleId;
>>>>>>> 1ec71635b (sync with main branch)
            ContentType = contentType;
        }

        public void SetFlag(int flag)
        {
            Flag = flag;
        }
    }
}
