<<<<<<< HEAD
using Ryujinx.Common.Utilities;
=======
﻿using Ryujinx.Common.Utilities;
>>>>>>> 1ec71635b (sync with main branch)
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration.Hid.Controller.Motion
{
    [JsonConverter(typeof(TypedStringEnumConverter<MotionInputBackendType>))]
    public enum MotionInputBackendType : byte
    {
        Invalid,
        GamepadDriver,
<<<<<<< HEAD
        CemuHook,
=======
        CemuHook
>>>>>>> 1ec71635b (sync with main branch)
    }
}
