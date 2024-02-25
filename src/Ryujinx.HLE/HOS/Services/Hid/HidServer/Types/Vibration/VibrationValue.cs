<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid
{
    public struct VibrationValue
    {
        public float AmplitudeLow;
        public float FrequencyLow;
        public float AmplitudeHigh;
        public float FrequencyHigh;

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is VibrationValue value &&
                   AmplitudeLow == value.AmplitudeLow &&
                   AmplitudeHigh == value.AmplitudeHigh;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
        {
            return HashCode.Combine(AmplitudeLow, AmplitudeHigh);
        }

        public static bool operator ==(VibrationValue left, VibrationValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VibrationValue left, VibrationValue right)
        {
            return !(left == right);
        }
    }
}
=======
        public override int GetHashCode()
        {
            return HashCode.Combine(AmplitudeLow, AmplitudeHigh);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
