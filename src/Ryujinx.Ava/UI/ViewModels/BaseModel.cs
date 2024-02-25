<<<<<<< HEAD
using System.ComponentModel;
=======
﻿using System.ComponentModel;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;

namespace Ryujinx.Ava.UI.ViewModels
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
