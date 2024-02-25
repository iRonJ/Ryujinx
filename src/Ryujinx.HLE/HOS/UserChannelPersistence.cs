<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Am.AppletOE.ApplicationProxyService.ApplicationProxy.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.Am.AppletOE.ApplicationProxyService.ApplicationProxy.Types;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS
{
    public class UserChannelPersistence
    {
<<<<<<< HEAD
        private readonly Stack<byte[]> _userChannelStorages;
=======
        private Stack<byte[]> _userChannelStorages;
>>>>>>> 1ec71635b (sync with main branch)
        public int PreviousIndex { get; private set; }
        public int Index { get; private set; }
        public ProgramSpecifyKind Kind { get; private set; }
        public bool ShouldRestart { get; set; }

        public UserChannelPersistence()
        {
            _userChannelStorages = new Stack<byte[]>();
            Kind = ProgramSpecifyKind.ExecuteProgram;
            PreviousIndex = -1;
            Index = 0;
        }

        public void Clear()
        {
            _userChannelStorages.Clear();
        }

        public void Push(byte[] data)
        {
            _userChannelStorages.Push(data);
        }

        public byte[] Pop()
        {
            _userChannelStorages.TryPop(out byte[] result);

            return result;
        }

        public bool IsEmpty => _userChannelStorages.Count == 0;

        public void ExecuteProgram(ProgramSpecifyKind kind, ulong value)
        {
            Kind = kind;
            PreviousIndex = Index;
            ShouldRestart = true;

            switch (kind)
            {
                case ProgramSpecifyKind.ExecuteProgram:
                    Index = (int)value;
                    break;
                case ProgramSpecifyKind.RestartProgram:
                    break;
                default:
                    throw new NotImplementedException($"{kind} not implemented");
            }
        }
    }
}
