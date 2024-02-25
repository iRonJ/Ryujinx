<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices;
=======
﻿using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Text;

namespace Ryujinx.HLE.HOS.Services.Nv.Types
{
    class NvIoctlNotImplementedException : Exception
    {
<<<<<<< HEAD
        public ServiceCtx Context { get; }
        public NvDeviceFile DeviceFile { get; }
        public NvIoctl Command { get; }
=======
        public ServiceCtx   Context    { get; }
        public NvDeviceFile DeviceFile { get; }
        public NvIoctl      Command    { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public NvIoctlNotImplementedException(ServiceCtx context, NvDeviceFile deviceFile, NvIoctl command)
            : this(context, deviceFile, command, "The ioctl is not implemented.")
        { }

        public NvIoctlNotImplementedException(ServiceCtx context, NvDeviceFile deviceFile, NvIoctl command, string message)
            : base(message)
        {
<<<<<<< HEAD
            Context = context;
            DeviceFile = deviceFile;
            Command = command;
=======
            Context    = context;
            DeviceFile = deviceFile;
            Command    = command;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override string Message
        {
            get
            {
                return base.Message +
                    Environment.NewLine +
                    Environment.NewLine +
                    BuildMessage();
            }
        }

        private string BuildMessage()
        {
<<<<<<< HEAD
            StringBuilder sb = new();
=======
            StringBuilder sb = new StringBuilder();
>>>>>>> 1ec71635b (sync with main branch)

            sb.AppendLine($"Device File: {DeviceFile.GetType().Name}");
            sb.AppendLine();

            sb.AppendLine($"Ioctl (0x{Command.RawValue:x8})");
            sb.AppendLine($"\tNumber: 0x{Command.Number:x8}");
            sb.AppendLine($"\tType: 0x{Command.Type:x8}");
            sb.AppendLine($"\tSize: 0x{Command.Size:x8}");
            sb.AppendLine($"\tDirection: {Command.DirectionValue}");

            sb.AppendLine("Guest Stack Trace:");
            sb.AppendLine(Context.Thread.GetGuestStackTrace());

            return sb.ToString();
        }
    }
}
