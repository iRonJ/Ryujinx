<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration
{
    public struct DownloadableContentContainer
    {
        [JsonPropertyName("path")]
        public string ContainerPath { get; set; }
        [JsonPropertyName("dlc_nca_list")]
        public List<DownloadableContentNca> DownloadableContentNcaList { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
