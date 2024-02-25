<<<<<<< HEAD
using Ryujinx.Ava.UI.ViewModels;
=======
﻿using Ryujinx.Ava.UI.ViewModels;
>>>>>>> 1ec71635b (sync with main branch)
using System.IO;

namespace Ryujinx.Ava.UI.Models
{
    public class DownloadableContentModel : BaseModel
    {
        private bool _enabled;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;

                OnPropertyChanged();
            }
        }

<<<<<<< HEAD
        public string TitleId { get; }
        public string ContainerPath { get; }
        public string FullPath { get; }
=======
        public string TitleId       { get; }
        public string ContainerPath { get; }
        public string FullPath      { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public string FileName => Path.GetFileName(ContainerPath);

        public DownloadableContentModel(string titleId, string containerPath, string fullPath, bool enabled)
        {
<<<<<<< HEAD
            TitleId = titleId;
            ContainerPath = containerPath;
            FullPath = fullPath;
            Enabled = enabled;
        }
    }
}
=======
            TitleId       = titleId;
            ContainerPath = containerPath;
            FullPath      = fullPath;
            Enabled       = enabled;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
