namespace Ryujinx.Ava.UI.ViewModels
{
    internal class UserProfileImageSelectorViewModel : BaseModel
    {
        private bool _firmwareFound;

        public bool FirmwareFound
        {
            get => _firmwareFound;
<<<<<<< HEAD

=======
        
>>>>>>> 1ec71635b (sync with main branch)
            set
            {
                _firmwareFound = value;
                OnPropertyChanged();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
