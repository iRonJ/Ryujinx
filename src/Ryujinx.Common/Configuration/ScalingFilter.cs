using Ryujinx.Common.Utilities;
using System.Text.Json.Serialization;

namespace Ryujinx.Common.Configuration
{
    [JsonConverter(typeof(TypedStringEnumConverter<ScalingFilter>))]
    public enum ScalingFilter
    {
        Bilinear,
        Nearest,
<<<<<<< HEAD
        Fsr,
    }
}
=======
        Fsr
    }
}
>>>>>>> 1ec71635b (sync with main branch)
