<<<<<<< HEAD
using Ryujinx.Graphics.Device;
=======
﻿using Ryujinx.Graphics.Device;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;

namespace Ryujinx.Graphics.Host1x
{
    class Devices : IDisposable
    {
<<<<<<< HEAD
        private readonly Dictionary<ClassId, IDeviceState> _devices = new();
=======
        private readonly Dictionary<ClassId, IDeviceState> _devices = new Dictionary<ClassId, IDeviceState>();
>>>>>>> 1ec71635b (sync with main branch)

        public void RegisterDevice(ClassId classId, IDeviceState device)
        {
            _devices[classId] = device;
        }

        public IDeviceState GetDevice(ClassId classId)
        {
            return _devices.TryGetValue(classId, out IDeviceState device) ? device : null;
        }

        public void Dispose()
        {
            foreach (var device in _devices.Values)
            {
                if (device is ThiDevice thi)
                {
                    thi.Dispose();
                }
            }
        }
    }
}
