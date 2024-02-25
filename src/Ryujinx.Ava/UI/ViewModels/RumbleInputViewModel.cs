namespace Ryujinx.Ava.UI.ViewModels
{
    public class RumbleInputViewModel : BaseModel
    {
        private float _strongRumble;
        public float StrongRumble
        {
            get => _strongRumble;
            set
            {
                _strongRumble = value;
                OnPropertyChanged();
            }
        }

        private float _weakRumble;
        public float WeakRumble
        {
            get => _weakRumble;
            set
            {
                _weakRumble = value;
                OnPropertyChanged();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
