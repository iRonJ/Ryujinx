<<<<<<< HEAD
using System.Text.Json.Serialization;
=======
﻿using System.Text.Json.Serialization;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Common.Configuration
{
    public struct DownloadableContentNca
    {
        [JsonPropertyName("path")]
        public string FullPath { get; set; }
        [JsonPropertyName("title_id")]
<<<<<<< HEAD
        public ulong TitleId { get; set; }
        [JsonPropertyName("is_enabled")]
        public bool Enabled { get; set; }
    }
}
=======
        public ulong  TitleId  { get; set; }
        [JsonPropertyName("is_enabled")]
        public bool   Enabled  { get; set; }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
