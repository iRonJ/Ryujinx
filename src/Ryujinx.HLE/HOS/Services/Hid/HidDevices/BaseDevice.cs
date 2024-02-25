namespace Ryujinx.HLE.HOS.Services.Hid
{
    public abstract class BaseDevice
    {
        protected readonly Switch _device;
        public bool Active;

        public BaseDevice(Switch device, bool active)
        {
            _device = device;
            Active = active;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
