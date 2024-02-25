<<<<<<< HEAD
using System.Text.Json.Serialization;
=======
﻿using System.Text.Json.Serialization;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Common.Configuration.Hid.Controller.Motion
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(MotionConfigController))]
    [JsonSerializable(typeof(CemuHookMotionConfigController))]
    [JsonSerializable(typeof(StandardMotionConfigController))]
    public partial class MotionConfigJsonSerializerContext : JsonSerializerContext
    {
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
