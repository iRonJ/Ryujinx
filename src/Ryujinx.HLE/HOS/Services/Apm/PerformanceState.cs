<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Apm
=======
﻿namespace Ryujinx.HLE.HOS.Services.Apm
>>>>>>> 1ec71635b (sync with main branch)
{
    class PerformanceState
    {
        public PerformanceState() { }

        public bool CpuOverclockEnabled = false;

        public PerformanceMode PerformanceMode = PerformanceMode.Default;
<<<<<<< HEAD
        public CpuBoostMode CpuBoostMode = CpuBoostMode.Disabled;

        public PerformanceConfiguration DefaultPerformanceConfiguration = PerformanceConfiguration.PerformanceConfiguration7;
        public PerformanceConfiguration BoostPerformanceConfiguration = PerformanceConfiguration.PerformanceConfiguration8;
=======
        public CpuBoostMode    CpuBoostMode    = CpuBoostMode.Disabled;

        public PerformanceConfiguration DefaultPerformanceConfiguration = PerformanceConfiguration.PerformanceConfiguration7;
        public PerformanceConfiguration BoostPerformanceConfiguration   = PerformanceConfiguration.PerformanceConfiguration8;
>>>>>>> 1ec71635b (sync with main branch)

        public PerformanceConfiguration GetCurrentPerformanceConfiguration(PerformanceMode performanceMode)
        {
            return performanceMode switch
            {
                PerformanceMode.Default => DefaultPerformanceConfiguration,
<<<<<<< HEAD
                PerformanceMode.Boost => BoostPerformanceConfiguration,
                _ => PerformanceConfiguration.PerformanceConfiguration7,
            };
        }
    }
}
=======
                PerformanceMode.Boost   => BoostPerformanceConfiguration,
                _                       => PerformanceConfiguration.PerformanceConfiguration7
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
