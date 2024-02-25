<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.OsTypes
=======
﻿namespace Ryujinx.Horizon.Sdk.OsTypes
>>>>>>> 1ec71635b (sync with main branch)
{
    struct SystemEventType
    {
        public enum InitializationState : byte
        {
            NotInitialized,
            InitializedAsEvent,
<<<<<<< HEAD
            InitializedAsInterProcess,
=======
            InitializedAsInterProcess
>>>>>>> 1ec71635b (sync with main branch)
        }

        public InterProcessEventType InterProcessEvent;
        public InitializationState State;

<<<<<<< HEAD
        public readonly bool NotInitialized => State == InitializationState.NotInitialized;
=======
        public bool NotInitialized => State == InitializationState.NotInitialized;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
