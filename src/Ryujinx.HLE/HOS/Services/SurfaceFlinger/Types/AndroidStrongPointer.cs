<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types
{
    class AndroidStrongPointer<T> where T : unmanaged, IFlattenable
=======
﻿namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types
{
    class AndroidStrongPointer<T> where T: unmanaged, IFlattenable
>>>>>>> 1ec71635b (sync with main branch)
    {
        public T Object;

        private bool _hasObject;

        public bool IsNull => !_hasObject;

        public AndroidStrongPointer()
        {
            _hasObject = false;
        }

        public AndroidStrongPointer(T obj)
        {
            Set(obj);
        }

        public void Set(AndroidStrongPointer<T> other)
        {
<<<<<<< HEAD
            Object = other.Object;
=======
            Object     = other.Object;
>>>>>>> 1ec71635b (sync with main branch)
            _hasObject = other._hasObject;
        }

        public void Set(T obj)
        {
<<<<<<< HEAD
            Object = obj;
=======
            Object     = obj;
>>>>>>> 1ec71635b (sync with main branch)
            _hasObject = true;
        }

        public void Reset()
        {
            _hasObject = false;
        }
    }
}
