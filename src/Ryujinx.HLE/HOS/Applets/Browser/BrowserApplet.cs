<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Logging;
using Ryujinx.Common.Memory;
using Ryujinx.HLE.HOS.Services.Am.AppletAE;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ryujinx.HLE.HOS.Applets.Browser
{
    internal class BrowserApplet : IApplet
    {
        public event EventHandler AppletStateChanged;

        private AppletSession _normalSession;
<<<<<<< HEAD
=======
        private AppletSession _interactiveSession;
>>>>>>> 1ec71635b (sync with main branch)

        private CommonArguments _commonArguments;
        private List<BrowserArgument> _arguments;
        private ShimKind _shimKind;

<<<<<<< HEAD
        public BrowserApplet(Horizon system) { }
=======
        public BrowserApplet(Horizon system) {}
>>>>>>> 1ec71635b (sync with main branch)

        public ResultCode GetResult()
        {
            return ResultCode.Success;
        }

        public ResultCode Start(AppletSession normalSession, AppletSession interactiveSession)
        {
            _normalSession = normalSession;
<<<<<<< HEAD
=======
            _interactiveSession = interactiveSession;
>>>>>>> 1ec71635b (sync with main branch)

            _commonArguments = IApplet.ReadStruct<CommonArguments>(_normalSession.Pop());

            Logger.Stub?.PrintStub(LogClass.ServiceAm, $"WebApplet version: 0x{_commonArguments.AppletVersion:x8}");

            ReadOnlySpan<byte> webArguments = _normalSession.Pop();

            (_shimKind, _arguments) = BrowserArgument.ParseArguments(webArguments);

            Logger.Stub?.PrintStub(LogClass.ServiceAm, $"Web Arguments: {_arguments.Count}");

            foreach (BrowserArgument argument in _arguments)
            {
                Logger.Stub?.PrintStub(LogClass.ServiceAm, $"{argument.Type}: {argument.GetValue()}");
            }

            if ((_commonArguments.AppletVersion >= 0x80000 && _shimKind == ShimKind.Web) || (_commonArguments.AppletVersion >= 0x30000 && _shimKind == ShimKind.Share))
            {
<<<<<<< HEAD
                List<BrowserOutput> result = new()
                {
                    new BrowserOutput(BrowserOutputType.ExitReason, (uint)WebExitReason.ExitButton),
                };
=======
                List<BrowserOutput> result = new List<BrowserOutput>();

                result.Add(new BrowserOutput(BrowserOutputType.ExitReason, (uint)WebExitReason.ExitButton));
>>>>>>> 1ec71635b (sync with main branch)

                _normalSession.Push(BuildResponseNew(result));
            }
            else
            {
<<<<<<< HEAD
                WebCommonReturnValue result = new()
                {
                    ExitReason = WebExitReason.ExitButton,
=======
                WebCommonReturnValue result = new WebCommonReturnValue()
                {
                    ExitReason  = WebExitReason.ExitButton,
>>>>>>> 1ec71635b (sync with main branch)
                };

                _normalSession.Push(BuildResponseOld(result));
            }

            AppletStateChanged?.Invoke(this, null);

            return ResultCode.Success;
        }

<<<<<<< HEAD
        private static byte[] BuildResponseOld(WebCommonReturnValue result)
        {
            using MemoryStream stream = MemoryStreamManager.Shared.GetStream();
            using BinaryWriter writer = new(stream);
            writer.WriteStruct(result);

            return stream.ToArray();
        }
        private byte[] BuildResponseNew(List<BrowserOutput> outputArguments)
        {
            using MemoryStream stream = MemoryStreamManager.Shared.GetStream();
            using BinaryWriter writer = new(stream);
            writer.WriteStruct(new WebArgHeader
            {
                Count = (ushort)outputArguments.Count,
                ShimKind = _shimKind,
            });

            foreach (BrowserOutput output in outputArguments)
            {
                output.Write(writer);
            }

            writer.Write(new byte[0x2000 - writer.BaseStream.Position]);

            return stream.ToArray();
=======
        private byte[] BuildResponseOld(WebCommonReturnValue result)
        {
            using (MemoryStream stream = MemoryStreamManager.Shared.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.WriteStruct(result);

                return stream.ToArray();
            }
        }
        private byte[] BuildResponseNew(List<BrowserOutput> outputArguments)
        {
            using (MemoryStream stream = MemoryStreamManager.Shared.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.WriteStruct(new WebArgHeader
                {
                    Count    = (ushort)outputArguments.Count,
                    ShimKind = _shimKind
                });

                foreach (BrowserOutput output in outputArguments)
                {
                    output.Write(writer);
                }

                writer.Write(new byte[0x2000 - writer.BaseStream.Position]);

                return stream.ToArray();
            }
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
