<<<<<<< HEAD
using Ryujinx.Common.Utilities;
=======
﻿using Ryujinx.Common.Utilities;
>>>>>>> 1ec71635b (sync with main branch)
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration.Hid
{
    [JsonConverter(typeof(TypedStringEnumConverter<InputBackendType>))]
    public enum InputBackendType
    {
        Invalid,
        WindowKeyboard,
        GamepadSDL2,
    }
}
