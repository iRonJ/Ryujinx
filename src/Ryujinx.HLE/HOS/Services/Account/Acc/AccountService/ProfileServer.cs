<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Cpu;
using Ryujinx.HLE.Utilities;
using System.Text;

namespace Ryujinx.HLE.HOS.Services.Account.Acc.AccountService
{
    class ProfileServer
    {
<<<<<<< HEAD
        private readonly UserProfile _profile;
=======
        private UserProfile _profile;
>>>>>>> 1ec71635b (sync with main branch)

        public ProfileServer(UserProfile profile)
        {
            _profile = profile;
        }

        public ResultCode Get(ServiceCtx context)
        {
            context.Response.PtrBuff[0] = context.Response.PtrBuff[0].WithSize(0x80UL);

            ulong bufferPosition = context.Request.RecvListBuff[0].Position;

            MemoryHelper.FillWithZeros(context.Memory, bufferPosition, 0x80);

            // TODO: Determine the struct.
<<<<<<< HEAD
            context.Memory.Write(bufferPosition, 0); // Unknown
            context.Memory.Write(bufferPosition + 4, 1); // Icon ID. 0 = Mii, the rest are character icon IDs.
=======
            context.Memory.Write(bufferPosition,           0); // Unknown
            context.Memory.Write(bufferPosition + 4,       1); // Icon ID. 0 = Mii, the rest are character icon IDs.
>>>>>>> 1ec71635b (sync with main branch)
            context.Memory.Write(bufferPosition + 8, (byte)1); // Profile icon background color ID
            // 0x07 bytes - Unknown
            // 0x10 bytes - Some ID related to the Mii? All zeros when a character icon is used.
            // 0x60 bytes - Usually zeros?

            Logger.Stub?.PrintStub(LogClass.ServiceAcc);

            return GetBase(context);
        }

        public ResultCode GetBase(ServiceCtx context)
        {
            _profile.UserId.Write(context.ResponseData);

            context.ResponseData.Write(_profile.LastModifiedTimestamp);

            byte[] username = StringUtils.GetFixedLengthBytes(_profile.Name, 0x20, Encoding.UTF8);

            context.ResponseData.Write(username);

            return ResultCode.Success;
        }

        public ResultCode GetImageSize(ServiceCtx context)
        {
            context.ResponseData.Write(_profile.Image.Length);

            return ResultCode.Success;
        }

        public ResultCode LoadImage(ServiceCtx context)
        {
            ulong bufferPosition = context.Request.ReceiveBuff[0].Position;
<<<<<<< HEAD
            ulong bufferLen = context.Request.ReceiveBuff[0].Size;
=======
            ulong bufferLen      = context.Request.ReceiveBuff[0].Size;
>>>>>>> 1ec71635b (sync with main branch)

            if ((ulong)_profile.Image.Length > bufferLen)
            {
                return ResultCode.InvalidBufferSize;
            }

            context.Memory.Write(bufferPosition, _profile.Image);

            context.ResponseData.Write(_profile.Image.Length);

            return ResultCode.Success;
        }

        public ResultCode Store(ServiceCtx context)
        {
            ulong userDataPosition = context.Request.PtrBuff[0].Position;
<<<<<<< HEAD
            ulong userDataSize = context.Request.PtrBuff[0].Size;
=======
            ulong userDataSize     = context.Request.PtrBuff[0].Size;
>>>>>>> 1ec71635b (sync with main branch)

            byte[] userData = new byte[userDataSize];

            context.Memory.Read(userDataPosition, userData);

            // TODO: Read the nn::account::profile::ProfileBase and store everything in the savedata.

            Logger.Stub?.PrintStub(LogClass.ServiceAcc, new { userDataSize });

            return ResultCode.Success;
        }

        public ResultCode StoreWithImage(ServiceCtx context)
        {
            ulong userDataPosition = context.Request.PtrBuff[0].Position;
<<<<<<< HEAD
            ulong userDataSize = context.Request.PtrBuff[0].Size;
=======
            ulong userDataSize     = context.Request.PtrBuff[0].Size;
>>>>>>> 1ec71635b (sync with main branch)

            byte[] userData = new byte[userDataSize];

            context.Memory.Read(userDataPosition, userData);

            ulong profileImagePosition = context.Request.SendBuff[0].Position;
<<<<<<< HEAD
            ulong profileImageSize = context.Request.SendBuff[0].Size;
=======
            ulong profileImageSize     = context.Request.SendBuff[0].Size;
>>>>>>> 1ec71635b (sync with main branch)

            byte[] profileImageData = new byte[profileImageSize];

            context.Memory.Read(profileImagePosition, profileImageData);

            // TODO: Read the nn::account::profile::ProfileBase and store everything in the savedata.

            Logger.Stub?.PrintStub(LogClass.ServiceAcc, new { userDataSize, profileImageSize });

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
