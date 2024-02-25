namespace Ryujinx.HLE.HOS.Services.Am.AppletAE
{
    class IStorage : IpcService
    {
<<<<<<< HEAD
        public bool IsReadOnly { get; private set; }
        public byte[] Data { get; private set; }
=======
        public bool   IsReadOnly { get; private set; }
        public byte[] Data       { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public IStorage(byte[] data, bool isReadOnly = false)
        {
            IsReadOnly = isReadOnly;
<<<<<<< HEAD
            Data = data;
=======
            Data       = data;
>>>>>>> 1ec71635b (sync with main branch)
        }

        [CommandCmif(0)]
        // Open() -> object<nn::am::service::IStorageAccessor>
        public ResultCode Open(ServiceCtx context)
        {
            MakeObject(context, new IStorageAccessor(this));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
