<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Services.Account.Acc;
using Ryujinx.HLE.HOS.Services.Am.AppletAE;
using System;
using System.IO;

namespace Ryujinx.HLE.HOS.Applets
{
    internal class PlayerSelectApplet : IApplet
    {
<<<<<<< HEAD
        private readonly Horizon _system;

        private AppletSession _normalSession;
#pragma warning disable IDE0052 // Remove unread private member
        private AppletSession _interactiveSession;
#pragma warning restore IDE0052
=======
        private Horizon _system;

        private AppletSession _normalSession;
        private AppletSession _interactiveSession;
>>>>>>> 1ec71635b (sync with main branch)

        public event EventHandler AppletStateChanged;

        public PlayerSelectApplet(Horizon system)
        {
            _system = system;
        }

        public ResultCode Start(AppletSession normalSession, AppletSession interactiveSession)
        {
<<<<<<< HEAD
            _normalSession = normalSession;
=======
            _normalSession      = normalSession;
>>>>>>> 1ec71635b (sync with main branch)
            _interactiveSession = interactiveSession;

            // TODO(jduncanator): Parse PlayerSelectConfig from input data
            _normalSession.Push(BuildResponse());

            AppletStateChanged?.Invoke(this, null);

            _system.ReturnFocus();

            return ResultCode.Success;
        }

        public ResultCode GetResult()
        {
            return ResultCode.Success;
        }

        private byte[] BuildResponse()
        {
            UserProfile currentUser = _system.AccountManager.LastOpenedUser;

<<<<<<< HEAD
            using MemoryStream stream = MemoryStreamManager.Shared.GetStream();
            using BinaryWriter writer = new(stream);

            writer.Write((ulong)PlayerSelectResult.Success);

            currentUser.UserId.Write(writer);

            return stream.ToArray();
=======
            using (MemoryStream stream = MemoryStreamManager.Shared.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write((ulong)PlayerSelectResult.Success);

                currentUser.UserId.Write(writer);

                return stream.ToArray();
            }
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
