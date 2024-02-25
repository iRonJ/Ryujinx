namespace Ryujinx.Graphics.Shader.IntermediateRepresentation
{
    enum StorageKind
    {
        None,
        Input,
        InputPerPatch,
        Output,
        OutputPerPatch,
        ConstantBuffer,
        StorageBuffer,
        LocalMemory,
        SharedMemory,
<<<<<<< HEAD
        SharedMemory8, // TODO: Remove this and store type as a field on the Operation class itself.
        SharedMemory16, // TODO: Remove this and store type as a field on the Operation class itself.
        GlobalMemory,
        GlobalMemoryS8, // TODO: Remove this and store type as a field on the Operation class itself.
        GlobalMemoryS16, // TODO: Remove this and store type as a field on the Operation class itself.
        GlobalMemoryU8, // TODO: Remove this and store type as a field on the Operation class itself.
        GlobalMemoryU16, // TODO: Remove this and store type as a field on the Operation class itself.
=======
        GlobalMemory
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class StorageKindExtensions
    {
        public static bool IsInputOrOutput(this StorageKind storageKind)
        {
            return storageKind == StorageKind.Input ||
                   storageKind == StorageKind.InputPerPatch ||
                   storageKind == StorageKind.Output ||
                   storageKind == StorageKind.OutputPerPatch;
        }

        public static bool IsOutput(this StorageKind storageKind)
        {
            return storageKind == StorageKind.Output ||
                   storageKind == StorageKind.OutputPerPatch;
        }

        public static bool IsPerPatch(this StorageKind storageKind)
        {
            return storageKind == StorageKind.InputPerPatch ||
                   storageKind == StorageKind.OutputPerPatch;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
