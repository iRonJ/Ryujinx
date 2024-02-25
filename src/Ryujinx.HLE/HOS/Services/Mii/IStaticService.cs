<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Services.Mii.StaticService;
using Ryujinx.HLE.HOS.Services.Mii.Types;

namespace Ryujinx.HLE.HOS.Services.Mii
{
    [Service("mii:e", true)]
    [Service("mii:u", false)]
    class IStaticService : IpcService
    {
<<<<<<< HEAD
        private readonly DatabaseImpl _databaseImpl;

        private readonly bool _isSystem;

        public IStaticService(ServiceCtx context, bool isSystem)
        {
            _isSystem = isSystem;
=======
        private DatabaseImpl _databaseImpl;

        private bool _isSystem;

        public IStaticService(ServiceCtx context, bool isSystem)
        {
            _isSystem     = isSystem;
>>>>>>> 1ec71635b (sync with main branch)
            _databaseImpl = DatabaseImpl.Instance;
        }

        [CommandCmif(0)]
        // GetDatabaseService(u32 mii_key_code) -> object<nn::mii::detail::IDatabaseService>
        public ResultCode GetDatabaseService(ServiceCtx context)
        {
            SpecialMiiKeyCode miiKeyCode = context.RequestData.ReadStruct<SpecialMiiKeyCode>();

            MakeObject(context, new DatabaseServiceImpl(_databaseImpl, _isSystem, miiKeyCode));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
