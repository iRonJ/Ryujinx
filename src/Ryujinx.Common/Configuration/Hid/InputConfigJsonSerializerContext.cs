<<<<<<< HEAD
using Ryujinx.Common.Configuration.Hid.Controller;
=======
﻿using Ryujinx.Common.Configuration.Hid.Controller;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Configuration.Hid.Keyboard;
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration.Hid
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(InputConfig))]
    [JsonSerializable(typeof(StandardKeyboardInputConfig))]
    [JsonSerializable(typeof(StandardControllerInputConfig))]
    public partial class InputConfigJsonSerializerContext : JsonSerializerContext
    {
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
