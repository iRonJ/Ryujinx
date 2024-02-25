using Microsoft.IdentityModel.Tokens;
<<<<<<< HEAD
using Ryujinx.Ava.UI.Models;
using System;
using System.Collections.ObjectModel;
=======
using System;
using System.Collections.ObjectModel;
using UserProfile = Ryujinx.Ava.UI.Models.UserProfile;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Ava.UI.ViewModels
{
    public class UserProfileViewModel : BaseModel, IDisposable
    {
        public UserProfileViewModel()
        {
            Profiles = new ObservableCollection<BaseModel>();
            LostProfiles = new ObservableCollection<UserProfile>();
            IsEmpty = LostProfiles.IsNullOrEmpty();
        }

        public ObservableCollection<BaseModel> Profiles { get; set; }

        public ObservableCollection<UserProfile> LostProfiles { get; set; }

        public bool IsEmpty { get; set; }

<<<<<<< HEAD
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
=======
        public void Dispose() { }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
