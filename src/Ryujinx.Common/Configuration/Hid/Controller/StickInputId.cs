<<<<<<< HEAD
using Ryujinx.Common.Utilities;
=======
﻿using Ryujinx.Common.Utilities;
>>>>>>> 1ec71635b (sync with main branch)
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration.Hid.Controller
{
    [JsonConverter(typeof(TypedStringEnumConverter<StickInputId>))]
    public enum StickInputId : byte
    {
        Unbound,
        Left,
        Right,

<<<<<<< HEAD
        Count,
    }
}
=======
        Count
    }
}
>>>>>>> 1ec71635b (sync with main branch)
